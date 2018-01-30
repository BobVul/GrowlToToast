using GrowlToToast.GrowlerInstaller.Install;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowlToToast.GrowlerInstaller.ViewModels
{
    public class AdvancedViewModel
    {
        public ObservableCollection<InstallationDetailsViewModel> Installations { get; }  = new ObservableCollection<InstallationDetailsViewModel>();

        public AdvancedViewModel()
        {
            var source = new SourceInstallation();
            Installations.Add(new InstallationDetailsViewModel(source, new UserInstallation()));
            Installations.Add(new InstallationDetailsViewModel(source, new SystemInstallation()));
            Installations.Add(new InstallationDetailsViewModel(source, new CustomInstallation()));
        }
    }
}
