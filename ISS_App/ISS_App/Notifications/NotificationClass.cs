using System;
using System.Collections.Generic;
using System.Text;

namespace ISS_App.Notifications
{
    internal class NotificationClass
    {
        public class Notification
        {
            public string name { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string icon { get; set; }

            public Notification(string name, string latitude, string longitude, string icon)
            {
                this.name = name;
                this.latitude = latitude;
                this.longitude = longitude;
                this.icon = icon;
            }
        }
        
    }
}
    

