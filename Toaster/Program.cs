using GrowlToToast.Bread;
using Newtonsoft.Json;
using NotificationsExtensions.Toasts;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace GrowlToToast.Toaster
{
    static class Program
    {
        private const string APP_ID = "GrowlToToast";

        static void Main()
        {
            try
            {
                Message bread = JsonConvert.DeserializeObject<Message>(Console.ReadLine());
                switch (bread.Action)
                {
                    case ActionType.CloseAll:
                        ToastNotificationManager.History.Clear();
                        break;

                    case ActionType.CloseLast:
                        ToastNotificationManager.History.Remove(ToastNotificationManager.History.GetHistory().Last().Tag);
                        break;

                    case ActionType.Show:
                        string imagePath = Path.ChangeExtension(Path.GetTempFileName(), "png");
                        bread.Image.Save(imagePath, ImageFormat.Png);
                        ToastContent content = new ToastContent()
                        {
                            Visual = new ToastVisual()
                            {
                                TitleText = new ToastText()
                                {
                                    Text = bread.Title
                                },
                                BodyTextLine1 = new ToastText()
                                {
                                    Text = bread.Body
                                },
                                BodyTextLine2 = new ToastText()
                                {
                                    Text = bread.AppName,
                                },
                                AppLogoOverride = new ToastAppLogo
                                {
                                    Source = new ToastImageSource("file:///" + imagePath)
                                }
                            }
                        };

                        if (bread.Silent)
                        {
                            content.Audio = new ToastAudio()
                            {
                                Silent = true
                            };
                        }

                        if (bread.PersistNotifications)
                        {
                            content.ActivationType = ToastActivationType.Background;
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
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"GrowlToToast encountered an error. Details saved to {Path.GetFullPath("GrowlToToast.Toaster.log")}\r\n\r\n{ex.ToString()}", "GrowlToToast error");
                File.AppendAllText("GrowlToToast.Toaster.log", ex.ToString());
                throw;
            }
        }
    }
}
