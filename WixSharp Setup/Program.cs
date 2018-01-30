using System;
using System.Linq;
using System.Xml.Linq;
using WixSharp;
using WixSharp.Controls;
using WixSharp.Forms;

namespace WixSharp_Setup
{
    class Program
    {
        static string ToasterShortcutId = "GrowlToToast.Shortcut.Toaster";
        static string ToasterAppUserModelId = "GrowlToToast.Toaster";

        static void Main()
        {
            var project = new Project("GrowlToToast",
                              new Dir(@"%ProgramFiles%\GrowlToToast",
                                  new Files(@"..\build\Release\*.*")));

            project.ResolveWildCards();
            project.AllFiles.Single(f => f.Name.EndsWith("GrowlToToast.Toaster.exe"))
                .Shortcuts = new[]
                {
                    new FileShortcut(new Id(ToasterShortcutId), "Toaster", @"%ProgramMenuFolder%\GrowlToToast")
                };
            project.AllFiles.Single(f => f.Name.EndsWith("GrowlToToast.GrowlerInstaller.exe"))
                .Shortcuts = new[]
                {
                    new FileShortcut("GrowlerInstaller", @"%ProgramMenuFolder%\GrowlToToast")
                };

            project.GUID = new Guid("69141597-0065-4998-810F-FF2480AD7447");
            project.OutDir = @"..\build";

            project.LicenceFile = @"..\LICENSE.rtf";
            project.InstallScope = InstallScope.perMachine;

            project.UI = WUI.WixUI_InstallDir;

            project.WixSourceGenerated += (XDocument document) =>
            {
                var allEls = document.Descendants();
                var toasterShortcutEl = allEls.First(el => el.Attribute("Id")?.Value?.EndsWith(ToasterShortcutId) ?? false);
                toasterShortcutEl.Add(
                    new XElement("ShortcutProperty",
                        new XAttribute("Key", "System.AppUserModel.ID"),
                        new XAttribute("Value", ToasterAppUserModelId)));
            };
            
            project.BuildMsi();
        }
    }
}