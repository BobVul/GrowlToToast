using GrowlerInstaller.Installer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GrowlerInstaller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BindingList<Installation> Installations { get; } = new BindingList<Installation>();
        public BindingList<string> Test { get; } = new BindingList<string>();

        public MainWindow()
        {

            Test.Add("foo");

            Installations.Add(new SystemInstallation());
            Installations.Add(new UserInstallation());
            Installations.Add(new CustomInstallation());
            InitializeComponent();
        }
    }
}
