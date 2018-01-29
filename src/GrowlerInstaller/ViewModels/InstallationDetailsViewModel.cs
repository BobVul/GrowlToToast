using GrowlerInstaller.Helpers;
using GrowlerInstaller.Install;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public ICommand InstallCommand { get; }
        public ICommand RemoveCommand { get; }

        public InstallationDetailsViewModel(Installation source, Installation target)
        {
            Source = source;
            Target = target;

            InstallCommand = new RelayCommand(() =>
            {
                Installer ins = new Installer(Source, Target);
                ins.Install();
            });

            RemoveCommand = new RelayCommand(() =>
            {
                Installer ins = new Installer(Source, Target);
                ins.Remove();
            }, () =>
            {
                return Target.Installed;
            });
        }

        private string GetVersionInfo(Installation ins)
        {
            try
            {
                if (!ins.Installed)
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
