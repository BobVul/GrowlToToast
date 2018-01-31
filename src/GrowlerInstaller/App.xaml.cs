using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GrowlToToast.GrowlerInstaller
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            if (MessageBox.Show("An unhandled exception occurred: " + e.Exception.Message + "\r\n\r\nWould you like to report this error to the developer?", "Error", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Helpers.ErrorReporter.LaunchReporter(e.Exception);
            }
            e.Handled = true;
            Application.Current.Shutdown();
        }
    }
}
