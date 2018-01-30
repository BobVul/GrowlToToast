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
            if (MessageBox.Show("An unhandled exception occurred: " + e.Exception.Message + "\r\n\r\nWould you like to report this error to the developer?", "An unhandled exception occurred", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var title = "Exception: " + e.Exception.Message;
                var body = 
@"Describe what you were doing when this happened. Please include any data entered to make it easier to reproduce and fix.


---

```
" + e.Exception.StackTrace + @"
```";
                System.Diagnostics.Process.Start($"https://github.com/BobVul/GrowlToToast/issues/new?title={System.Net.WebUtility.UrlEncode(title)}&body={System.Net.WebUtility.UrlEncode(body)}");
            }
            e.Handled = true;
            Application.Current.Shutdown();
        }
    }
}
