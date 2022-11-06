using ISS_App.Home;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
namespace ISS_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        HomeController controller = new HomeController();
        bool autoUpdate = true;

        Pin pin = new Pin
        {
            Label = "Internation Space Station",
            Type = PinType.Generic,
            Position = new Position(0, 0)

        };
        public HomePage()
        {
            InitializeComponent();
            mapHomeMap.Pins.Add(pin);
            RefreshUI();
            AutoUpdateUI();
            if (autoUpdate)
            {
                buttonRefresh.IsVisible = false;
            }
            
        }


        private void buttonRefresh_Clicked(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private async void AutoUpdateUI()
        {
            while (autoUpdate)
            {
                await Task.Delay(6000);
                RefreshUI();
            };
        }

        private void RefreshUI()
        {

                double latitude = controller.GetLatitude();
                double longitude = controller.GetLongitude();
                double altitude = controller.GetAltitude();
                double velocity = controller.GetVelocity();
                Position issPosition = new Position(latitude, longitude);
                pin.Position = issPosition;
                pin.Address = $"Altitude: {Math.Round(altitude, 6)}  Velocity: {Math.Round(velocity, 6)}";
                mapHomeMap.MoveToRegion(MapSpan.FromCenterAndRadius(issPosition, Distance.FromKilometers(4000)));
                labelLatitude.Text = Math.Round(latitude, 4).ToString();
                labelLongitude.Text = Math.Round(longitude, 4).ToString();
                labelAltitude.Text = Math.Round(altitude, 4).ToString();
                labelVelocity.Text = Math.Round(velocity, 4).ToString();

        }
    }
}