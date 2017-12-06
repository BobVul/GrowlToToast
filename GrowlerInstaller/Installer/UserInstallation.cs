using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowlerInstaller.Installer
{
    class UserInstallation : Installation
    {
        public override string Name { get; } = "Current user";
    }
}
