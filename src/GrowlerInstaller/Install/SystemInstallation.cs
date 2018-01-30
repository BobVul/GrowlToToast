using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowlToToast.GrowlerInstaller.Install
{
    class SystemInstallation : Installation
    {
        public override string Name { get; } = "All users";
        public override bool Installable { get; } = false;

        public SystemInstallation()
        {
            var detector = new Growl.CoreLibrary.Detector();
            if (detector.IsInstalled)
            {
                Installable = true;
                InstallPath = Path.Combine(detector.DisplaysFolder, Constants.DefaultInstallDir);
            }
        }
    }
}
