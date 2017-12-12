using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowlerInstaller.Install
{
    [AddINotifyPropertyChangedInterface]
    public abstract class Installation
    {
        public virtual string Name { get; } = "Installation";
        public virtual string InstallPath { get; set; }
        public virtual bool InstallPathEditable { get; } = false;

        public bool Installed
        {
            get
            {
                var dllPath = Path.Combine(InstallPath, Constants.GrowlerDllName);
                return File.Exists(dllPath);
            }
        }

        public string ProductVersion
        {
            get
            {
                var dllPath = Path.Combine(InstallPath, Constants.GrowlerDllName);
                return FileVersionInfo.GetVersionInfo(dllPath).ProductVersion;
            }
        }
    }
}
