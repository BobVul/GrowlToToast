using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GrowlToToast.GrowlerInstaller.Install
{
    public class SourceInstallation : Installation
    {
        public string InstallerDir
        {
            get
            {
                var installerExe = Assembly.GetEntryAssembly().Location;
                var installerDir = Path.GetDirectoryName(installerExe);
                return installerDir;
            }
        }

        public string ToasterExePath
        {
            get
            {
                var toasterDir = Path.Combine(InstallerDir, Constants.ToasterDirRelativePath);
                var toasterPath = Path.Combine(toasterDir, Constants.ToasterExeName);
                return toasterPath;
            }
        }

        public override string InstallPath
        {
            get
            {
                var growlerDir = Path.GetFullPath(Path.Combine(InstallerDir, Constants.GrowlerDirRelativePath));
                return growlerDir;
            }
        }
    }
}
