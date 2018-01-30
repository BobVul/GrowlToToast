using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GrowlToToast.Bread
{
    public class Message
    {
        public ActionType Action { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool Silent { get; set; }

        [JsonConverter(typeof(ImageJsonConverter))]
        public Image Image { get; set; }

        public string AppName { get; set; }

        public bool PersistNotifications { get; set; }
    }
}
