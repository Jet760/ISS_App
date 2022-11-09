using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ISS_App.Home
{
    internal class HomeDataModel
    {
        // initialize the API JSON data class
        WhereTheISSAPI.Rootobject LocationAPI = new WhereTheISSAPI.Rootobject();


        /// <summary>
        /// Calls the where is the ISS API and converts the data into a WhereTheISSAPI.Rootobject object. Async method
        /// </summary>
        public async Task GetAPI()
        {
            try
            {
                // Calls the API
                var client = new HttpClient();
                var response = await client.GetAsync("https://api.wheretheiss.at/v1/satellites/25544");
                var responseString = await response.Content.ReadAsStringAsync();

                // Converts the API JSON into the data class object
                LocationAPI = JsonConvert.DeserializeObject<WhereTheISSAPI.Rootobject>(responseString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ISS API call failed and threw: {ex}");
                return;
            }
        }

        /// <summary>
        /// Gets telemetry data from the API and returns it as a tuple. Async method
        /// </summary>
        /// <returns>(double latitude, double longitude, double altitude, double velocity)</returns>
        public async Task<(double latitude, double longitude, double altitude, double velocity)> GetTelemDataAsync()
        {
            await GetAPI();
            return (LocationAPI.latitude, LocationAPI.longitude, LocationAPI.altitude, LocationAPI.velocity);
        }

    }
}
