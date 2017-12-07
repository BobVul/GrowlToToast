using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowlerInstaller.Install
{
    class UserInstallation : Installation
    {
        public override string Name { get; } = "Current user";
        public override string InstallPath { get; set; } = "foo";
    }
}
