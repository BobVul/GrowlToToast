using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowlToToast.Toaster
{
    class Options
    {
        [Option('v', "loglevel-debug", HelpText = "Enable debug logging.")]
        public bool DebugLogging { get; set; }

        [Option('p', "pipe-id", HelpText = "Retrieve the message from this anonymous pipe")]
        public string AnonymousPipeClientId { get; set; }
    }
}
