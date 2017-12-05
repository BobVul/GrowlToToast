using System;
using WixSharp;
using WixSharp.Controls;
using WixSharp.Forms;

namespace WixSharp_Setup
{
    class Program
    {
        static void Main()
        {
            var project = new Project("GrowlToToast",
                              new Dir(@"%ProgramFiles%\GrowlToToast",
                                  new Files(@"..\build\Release\*.*")));

            project.GUID = new Guid("69141597-0065-4998-810F-FF2480AD7447");
            project.OutDir = @"..\build";

            project.LicenceFile = @"..\LICENSE.rtf";

            project.UI = WUI.WixUI_InstallDir;
            
            project.BuildMsi();
        }
    }
}