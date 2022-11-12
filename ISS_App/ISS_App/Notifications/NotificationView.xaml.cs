using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotification;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISS_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationView : ContentView
    {
        public NotificationView(string locationName, string latitude, string longitude, string icon)
        {
            InitializeComponent();
            labelLocationName.Text = locationName;
            labelLatitude.Text = latitude;
            labelLongitude.Text = longitude;
            string colour = string.Empty;
            // Check the current theme and pick the corresponding coloured icons
            if (Preferences.Get("AppTheme", "dark") == "dark")
            {
                colour = "white";
            }
            else
            {
                colour = "black";
            }
            imageLocationNotifIcon.Source = $"{icon.ToLower()}_{colour}";

        }

        /* TO BE ADDED IN FUTURE
         * The locations were orignially going to send the user notifications but I have run out of time to implement this :(
         * I do hope to add this in the future so I'd rather keep this code here for safe keeping
         * I also hope to add in the ability to delete the locations but that was also a bit much for the time I had
         * 
        private void Button_Clicked(object sender, EventArgs e)
        {
            //stackLayoutLocationNotifs.Children.Remove(labelLocationName);//
            NotificationRequest notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "The ISS is passing over {location name}",
                Title = "ISS Passover",
                NotificationId = 1
            };
            LocalNotificationCenter.Current.Show(notification);
            return; 
        }*/
    }
}