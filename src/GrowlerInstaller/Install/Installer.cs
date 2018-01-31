using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowlToToast.GrowlerInstaller.Install
{
    public class Installer
    {
        SourceInstallation source;
        Installation target;

        public string TargetPath
        {
            get
            {
                return target.InstallPath;
            }
        }

        public Installer(SourceInstallation source, Installation target)
        {
            this.source = source;
            this.target = target;
        }

        public void Install()
        {
            CopyDirectory(new DirectoryInfo(source.InstallPath), new DirectoryInfo(TargetPath), true, true);
            var toasterPath = Path.GetFullPath(Path.Combine(source.InstallerDir, Constants.ToasterDirRelativePath, Constants.ToasterExeName));
            File.WriteAllText(Path.Combine(TargetPath, "toasterpath"), toasterPath);
            target.RefreshInstallStatus();
        }

        public void Remove()
        {
            Directory.Delete(TargetPath, true);
            target.RefreshInstallStatus();
        }

        /// <summary>
        /// Copy a directory specified by the source path to the target path.
        /// </summary>
        /// <param name="source">The Directory to copy from</param>
        /// <param name="target">The Directory to copy to</param>
        /// <param name="subdirs">Include subdirectories (recursive)</param>
        /// <param name="overwrite">Overwrite existing files</param>
        private static void CopyDirectory(DirectoryInfo source, DirectoryInfo target, bool subdirs, bool overwrite)
        {
            target.Create();

            foreach (var file in source.EnumerateFiles())
            {
                file.CopyTo(Path.Combine(target.FullName, file.Name), overwrite);
            }

            if (subdirs)
            {
                foreach (var dir in source.EnumerateDirectories())
                {
                    CopyDirectory(dir, new DirectoryInfo(Path.Combine(target.FullName, dir.Name)), subdirs, overwrite);
                }
            }
        }
    }
}
