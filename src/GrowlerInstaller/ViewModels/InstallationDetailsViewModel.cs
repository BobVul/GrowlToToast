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

        public InstallationDetailsViewModel(Installation source, Installation target)
        {
            Source = source;
            Target = target;
        }
    }
}
