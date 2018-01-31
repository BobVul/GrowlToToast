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

        // https://github.com/briandunnington/growl-for-windows/blob/6a4ba006eae20fd9b454b4b6d0fbd1cb87bb279b/Growl/Growl/_source/Utility.cs#L47
        private static string pluginroot = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public override string InstallPath { get; set; } = Path.Combine(pluginroot, @"Growl\2.0.0.0\Displays", Constants.DefaultInstallDir);
    }
}
