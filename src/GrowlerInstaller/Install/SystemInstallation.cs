using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowlerInstaller.Install
{
    class SystemInstallation : Installation
    {
        public override string Name { get; } = "All users";
        public override string InstallPath { get; set; } = Path.Combine(new Growl.CoreLibrary.Detector().DisplaysFolder, Constants.DefaultInstallDir);
    }
}
