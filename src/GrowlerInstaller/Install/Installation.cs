using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowlToToast.GrowlerInstaller.Install
{
    [AddINotifyPropertyChangedInterface]
    public abstract class Installation
    {
        public virtual string Name { get; } = "Installation";
        public virtual string InstallPath { get; set; }
        public virtual bool InstallPathEditable { get; } = false;
        public virtual bool Installable { get; } = true;

        [AlsoNotifyFor("ProductVersion")]
        [DoNotCheckEqualityAttribute]
        public bool Installed
        {
            get
            {
                var dllPath = Path.Combine(InstallPath ?? "", Constants.GrowlerDllName);
                return File.Exists(dllPath);
            }
            private set
            {
                // do nothing, used to support updates
            }
        }

        [DoNotCheckEqualityAttribute]
        public string ProductVersion
        {
            get
            {
                var dllPath = Path.Combine(InstallPath, Constants.GrowlerDllName);
                return FileVersionInfo.GetVersionInfo(dllPath).ProductVersion;
            }
        }

        public void RefreshInstallStatus()
        {
            // trigger property change notifications; does not actually set anything
            this.Installed = false;
        }
    }
}
