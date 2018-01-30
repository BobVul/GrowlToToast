using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowlToToast.GrowlerInstaller.Install
{
    class UserInstallation : Installation
    {
        public override string Name { get; } = "Current user";
        public override string InstallPath { get; set; } = Path.Combine(Environment.ExpandEnvironmentVariables(@"%LocalAppData%\Growl\2.0.0.0\Displays"), Constants.DefaultInstallDir);
    }
}
