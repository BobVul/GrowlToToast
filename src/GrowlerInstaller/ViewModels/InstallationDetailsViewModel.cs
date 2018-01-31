using GrowlToToast.GrowlerInstaller.Helpers;
using GrowlToToast.GrowlerInstaller.Install;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GrowlToToast.GrowlerInstaller.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class InstallationDetailsViewModel
    {
        public SourceInstallation Source { get; }
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
            private set
            {
                // does nothing; exists only for property change notifications
            }
        }

        public ICommand InstallCommand { get; }
        public ICommand RemoveCommand { get; }

        public InstallationDetailsViewModel(SourceInstallation source, Installation target)
        {
            Source = source;
            Target = target;

            InstallCommand = new RelayCommand(() =>
            {
                try
                {
                    Installer ins = new Installer(Source, Target);
                    if (MessageBox.Show($"Install in {ins.TargetPath}?", "Confirm install", MessageBoxButton.YesNo, MessageBoxImage.None, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        ins.Install();
                    }

                    TargetVersion = ""; // hacky way to refresh property
                }
                catch (Exception ex)
                {
                    if (MessageBox.Show("An exception occurred: " + ex.Message + "\r\n\r\nWould you like to report this error to the developer?", "Error", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Helpers.ErrorReporter.LaunchReporter(ex);
                    }
                }
            });

            RemoveCommand = new RelayCommand(() =>
            {
                try
                {
                    Installer ins = new Installer(Source, Target);
                    if (MessageBox.Show($"Remove all files in {ins.TargetPath}?", "Confirm removal", MessageBoxButton.YesNo, MessageBoxImage.None, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        ins.Remove();
                    }

                    TargetVersion = ""; // hacky way to refresh property
                }
                catch (Exception ex)
                {
                    if (MessageBox.Show("An exception occurred: " + ex.Message + "\r\n\r\nWould you like to report this error to the developer?", "Error", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Helpers.ErrorReporter.LaunchReporter(ex);
                    }
                }
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
