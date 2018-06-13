using CommandLine;
using GrowlToToast.Bread;
using Newtonsoft.Json;
using NotificationsExtensions.Toasts;
using Serilog;
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
        private static string logPath;

        static void Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<Options>(args);

            result.WithParsed(options =>
            {
                var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                logPath = Path.Combine(localAppData, "GrowlToToast", "Toaster.log");

                var logConfig = new LoggerConfiguration()
                    .WriteTo.File(logPath, rollingInterval: RollingInterval.Month, rollOnFileSizeLimit: true, shared: true);

                if (options.DebugLogging)
                {
                    logConfig
                        .MinimumLevel.Debug();
                }

                Log.Logger = logConfig
                    .CreateLogger();

                try
                {
                    ShowToast();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show($"GrowlToToast encountered an error. See log at {Path.GetDirectoryName(logPath)} for details\r\n\r\n{ex.ToString()}", "GrowlToToast error");
                    Log.Error(ex, "Encountered exception, quitting");
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            });
        }

        private static void ShowToast()
        {
            string input = Console.ReadLine();
            Log.Debug("Received \"{Input}\"", input);
            
            Message bread = JsonConvert.DeserializeObject<Message>(input);
            Log.Debug("Deserialized {@Message}", bread);

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

                    Log.Debug("Creating {NotificationXml}", content.GetContent());

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(content.GetContent());

                    ToastNotification toast = new ToastNotification(doc);
                    // too long for a tag?
                    //toast.Tag = Guid.NewGuid().ToString();

                    ToastNotificationManager.CreateToastNotifier(APP_ID).Show(toast);
                    break;
            }

            ClearOldImages(TimeSpan.FromDays(30));
        }

        private static void ClearOldImages(TimeSpan time)
        {
            var tempPath = Path.Combine(Path.GetTempPath(), "GrowlToToast.Toaster.Images");
            if (!Directory.Exists(tempPath))
            {
                // the dir is only created if images were previously used at some point
                // there is the possibility that something deletes this path between the check and the enumeration below
                // but it's probably not worth handling specially (e.g. adding logging functionality)
                return;
            }

            var threshold = DateTime.UtcNow.Subtract(time);
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
