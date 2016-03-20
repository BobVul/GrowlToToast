using Growl.DisplayStyle;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace Growler
{
    public class Growler : Display
    {
        public Growler()
        {
            this.SettingsPanel = new GrowlerSettingsPanel();
        }

        protected override void HandleNotification(Notification notification, string displayName)
        {
            string title = notification.Title;
            string message = notification.Description;

            LaunchToaster(String.Format("show {0} {1} {2}", Base64Encode(title), Base64Encode(message), this.GetSettingOrDefault<bool>(GrowlerSetting.Silent, false)));
        }

        public override void CloseAllOpenNotifications()
        {
            if (!this.GetSettingOrDefault<bool>(GrowlerSetting.IgnoreClose, false))
            {
                LaunchToaster("closeall");
            }
        }

        public override void CloseLastNotification()
        {
            if (!this.GetSettingOrDefault<bool>(GrowlerSetting.IgnoreClose, false))
            {
                LaunchToaster("closelast");
            }
        }

        public override string Author
        {
            get { return "Vulpin"; }
        }

        public override string Description
        {
            get { return "Sends Growl notifications to Windows 10 toasts"; }
        }

        public override string Name
        {
            get { return "GrowlToToast"; }
        }

        public override string Version
        {
            get { return "0.1"; }
        }

        public override string Website
        {
            get { return "https://github.com/Elusive138/GrowlToToast"; }
        }

        private T GetSettingOrDefault<T>(GrowlerSetting setting, T def)
        {
            string key = GrowlerSettingKeymap.GetKey(setting);
            if (!this.SettingsCollection.ContainsKey(key))
                return def;
            return (T)this.SettingsCollection[key];
        }

        private void LaunchToaster(string args)
        {
            Process.Start(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Toaster\Toaster.exe"), args);
        }

        private string Base64Encode(string text)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
        }
    }
}
