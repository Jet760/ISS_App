using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotification;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISS_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationView : ContentView
    {
        public NotificationView(string locationName, string latitude, string longitude, string iconSource)
        {
            InitializeComponent();
            labelLocationName.Text = locationName;
            labelLatitude.Text = latitude;
            labelLongitude.Text = longitude;
            imageLocationNotifIcon.Source = iconSource;
            
        }

        /* BUTTON TO BE ADDED IN FUTURE
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