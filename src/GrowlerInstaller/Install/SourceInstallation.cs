using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GrowlerInstaller.Install
{
    public class SourceInstallation : Installation
    {
        public override string InstallPath
        {
            get
            {
                var installerExe = Assembly.GetEntryAssembly().Location;
                var installerDir = Path.GetDirectoryName(installerExe);
                var growlerDir = Path.GetFullPath(Path.Combine(installerDir, Constants.GrowlerDirRelativePath));
                return growlerDir;
            }
        }
    }
}
