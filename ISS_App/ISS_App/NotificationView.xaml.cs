using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}