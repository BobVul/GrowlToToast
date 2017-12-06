using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowlerInstaller.Installer
{
    [AddINotifyPropertyChangedInterface]
    public abstract class Installation
    {
        public virtual string Name { get; } = "Installation";
        public string InstallPath { get; set; }
        public virtual bool InstallPathEditable { get; } = false;
        public bool IsInstalled { get; set; }
    }
}
