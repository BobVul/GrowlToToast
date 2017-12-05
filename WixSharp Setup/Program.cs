using System;
using WixSharp;

namespace WixSharp_Setup
{
    class Program
    {
        static void Main()
        {
            var project = new Project("MyProduct",
                              new Dir(@"%ProgramFiles%\My Company\My Product",
                                  new File("Program.cs")));

            project.GUID = new Guid("69141597-0065-4998-810F-FF2480AD7447");
            //project.SourceBaseDir = "<input dir path>";
            //project.OutDir = "<output dir path>";
            

            project.BuildMsi();
        }
    }
}