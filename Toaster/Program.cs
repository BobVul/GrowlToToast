using NotificationsExtensions.Toasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace GrowlToToast.Toaster
{
    static class Program
    {
        private const string APP_ID = "GrowlToToast";

        static void Main(string[] args)
        {
            switch (args[0])
            {
                case "closeall":
                    ToastNotificationManager.History.Clear();
                    break;
                case "closelast":
                    ToastNotificationManager.History.Remove(ToastNotificationManager.History.GetHistory().Last().Tag);
                    break;
                case "show":
                    string title = Base64Decode(args[1]);
                    string message = Base64Decode(args[2]);
                    bool silent = Boolean.Parse(args[3]);

                    ToastContent content = new ToastContent()
                    {
                        Visual = new ToastVisual()
                        {
                            TitleText = new ToastText()
                            {
                                Text = title
                            },
                            BodyTextLine1 = new ToastText()
                            {
                                Text = message
                            }
                        }
                    };

                    if (silent)
                    {
                        content.Audio = new ToastAudio()
                        {
                            Silent = true
                        };
                    }

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(content.GetContent());
                    ToastNotification toast = new ToastNotification(doc);
                    // too long for a tag?
                    //toast.Tag = Guid.NewGuid().ToString();

                    ToastNotificationManager.CreateToastNotifier(APP_ID).Show(toast);
                    break;
            }
        }

        private static string Base64Decode(string encoded)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
        }
    }
}
