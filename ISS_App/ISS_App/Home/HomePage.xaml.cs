using ISS_App.Home;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace ISS_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        WhereTheISSAPI.Rootobject LocationAPI = new WhereTheISSAPI.Rootobject();
        public HomePage()
        {
            InitializeComponent();
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
            labelLat.Text = LocationAPI.latitude.ToString();
            labelLong.Text = LocationAPI.longitude.ToString();
        }
    }
}