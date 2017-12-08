using GrowlerInstaller.Install;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowlerInstaller.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class InstallationDetailsViewModel
    {
        public Installation Source { get; }
        public Installation Target { get; }

        public string SourceVersion
        {
            get
            {
                return GetVersionInfo(Source);
            }
        }

        public string TargetVersion
        {
            get
            {
                return GetVersionInfo(Target);
            }
        }

        public InstallationDetailsViewModel(Installation source, Installation target)
        {
            Source = source;
            Target = target;
        }

        private string GetVersionInfo(Installation ins)
        {
            try
            {
                if (!ins.IsInstalled)
                {
                    return "Not installed";
                }
                return ins.ProductVersion;
            }
            catch
            {
                return "Unknown";
            }
        }
    }
}
