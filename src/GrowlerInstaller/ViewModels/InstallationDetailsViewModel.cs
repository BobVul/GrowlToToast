﻿using GrowlToToast.GrowlerInstaller.Helpers;
using GrowlToToast.GrowlerInstaller.Install;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Installer ins = new Installer(Source, Target);
                ins.Install();
                TargetVersion = ""; // hacky way to refresh property
            });

            RemoveCommand = new RelayCommand(() =>
            {
                Installer ins = new Installer(Source, Target);
                ins.Remove();
                TargetVersion = ""; // hacky way to refresh property
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
