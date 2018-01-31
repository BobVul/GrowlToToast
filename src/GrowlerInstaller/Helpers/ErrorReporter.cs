using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GrowlToToast.GrowlerInstaller.Helpers
{
    static class ErrorReporter
    {
        public static void LaunchReporter(string errorTitle, string errorMessage)
        {
            System.Diagnostics.Process.Start($"https://github.com/BobVul/GrowlToToast/issues/new?title={WebUtility.UrlEncode(errorTitle)}&body={WebUtility.UrlEncode(errorMessage)}");
        }

        public static void LaunchReporter(Exception exception)
        {
            var title = "Exception: " + exception.Message;
            var body =
@"Describe what you were doing when this happened. Please include any data entered to make it easier to reproduce and fix.


---

```
" + exception.StackTrace + @"
```";
            LaunchReporter(title, body);
        }
    }
}
