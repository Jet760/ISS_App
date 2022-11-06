using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ISS_App.Home
{
    internal class HomeDataModel
    {
        WhereTheISSAPI.Rootobject LocationAPI = new WhereTheISSAPI.Rootobject();


        public async void GetAPI()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://api.wheretheiss.at/v1/satellites/25544");
            var responseString = await response.Content.ReadAsStringAsync();
            LocationAPI = JsonConvert.DeserializeObject<WhereTheISSAPI.Rootobject>(responseString);
            
        }

        public double GetLatitude()
        {
            GetAPI();
            return LocationAPI.latitude;
        }
        public double GetLongitude()
        {
            GetAPI();
            return LocationAPI.longitude;
        }
        public double GetAltitude()
        {
            GetAPI();
            return LocationAPI.altitude;
        }
        public double GetVelocity()
        {
            GetAPI();
            return LocationAPI.velocity;
        }
    }
}
