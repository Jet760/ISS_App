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
        WhereTheISSAPI.Rootobject LocationAPI = new WhereTheISSAPI.Rootobject();

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
            GetAPI();
            
        }

        

        public async void GetAPI()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://api.wheretheiss.at/v1/satellites/25544");
            var responseString = await response.Content.ReadAsStringAsync();
            LocationAPI = JsonConvert.DeserializeObject<WhereTheISSAPI.Rootobject>(responseString);
            RefreshUI();
        }

        private void buttonRefresh_Clicked(object sender, EventArgs e)
        {
            
            GetAPI();
        }

       

        private void RefreshUI()
        {
            double latitude = LocationAPI.latitude;
            double longitude = LocationAPI.longitude;
            Position issPosition = new Position(latitude, longitude);
            pin.Position = issPosition;
            pin.Address = $"Altitude: {LocationAPI.altitude}  Velocity: {LocationAPI.velocity}";
            mapHomeMap.MoveToRegion(MapSpan.FromCenterAndRadius(issPosition, Distance.FromKilometers(2000)));
            labelLatitude.Text = Math.Round(latitude,4).ToString();
            labelLongitude.Text = Math.Round(longitude, 4).ToString();
            labelAltitude.Text = LocationAPI.altitude.ToString();
            labelVelocity.Text = LocationAPI.velocity.ToString();

        }
    }
}