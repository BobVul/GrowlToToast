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
        private const string APP_ID = "GrowlToToast.Toaster";

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
                                }
                            }
                        };

                        if (bread.Image != null)
                        {
                            string imagePath = GetTempImagePath(".png");
                            bread.Image.Save(imagePath, ImageFormat.Png);
                            content.Visual.AppLogoOverride = new ToastAppLogo
                            {
                                Source = new ToastImageSource("file:///" + imagePath)
                            };
                        }

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

                ClearOldImages(30);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"GrowlToToast encountered an error. Details saved to {Path.GetFullPath("GrowlToToast.Toaster.log")}\r\n\r\n{ex.ToString()}", "GrowlToToast error");
                File.AppendAllText("GrowlToToast.Toaster.log", ex.ToString());
                throw;
            }
        }

        private static void ClearOldImages(int days)
        {
            var tempPath = Path.Combine(Path.GetTempPath(), "GrowlToToast.Toaster.Images");
            var threshold = DateTime.UtcNow.AddDays(-days);
            foreach (string file in Directory.EnumerateFiles(tempPath))
            {
                FileInfo fi = new FileInfo(file);
                if (fi.CreationTimeUtc < threshold)
                {
                    fi.Delete();
                }
            }
        }

        private static string GetTempImagePath(string extension)
        {
            var tempPath = Path.Combine(Path.GetTempPath(), "GrowlToToast.Toaster.Images");
            Directory.CreateDirectory(tempPath);
            string tempImagePath;
            do
            {
                tempImagePath = Path.Combine(tempPath, Path.ChangeExtension(Guid.NewGuid().ToString(), extension));
            } while (File.Exists(tempImagePath));
            
            return tempImagePath;
        }
    }
}
