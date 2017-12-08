using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowlerInstaller.Install
{
    class CustomInstallation : Installation
    {
        public override string Name { get; } = "Custom";
        public override string InstallPath { get; set; } = "";
        public override bool InstallPathEditable { get; } = true;
    }
}
