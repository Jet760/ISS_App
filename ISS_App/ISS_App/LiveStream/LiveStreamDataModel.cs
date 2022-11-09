using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ISS_App.LiveStream
{
    internal class LiveStreamDataModel
    {
        // initialize the API object
        APODAPI.Rootobject pictureAPI = new APODAPI.Rootobject();

        /// <summary>
        /// Calls the APOD API and puts the data in a pictureAPI object
        /// </summary>
        public async Task GetAPIAsync()
        {
            try
            {
                // Calls the API
                var client = new HttpClient();
                var response = await client.GetAsync("https://api.nasa.gov/planetary/apod?api_key=Q0rkk2qrxonZtxnz82Iz6vI31xOX5h6zdhjC0Ssq");
                var responseString = await response.Content.ReadAsStringAsync();

                // Converts the API JSON into the data class object
                pictureAPI = JsonConvert.DeserializeObject<APODAPI.Rootobject>(responseString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"APOD API call failed and threw: {ex}");
                return;
            }
        }

        /// <summary>
        /// Calls the API, gets the data and returns it as a tuple. Async method
        /// </summary>
        /// <returns>tuple (string type, string url, string explination)</returns>
        public async Task<(string type, string url, string explination)> GetDataAsync()
        {
            // Calls method that clls the API and puts it into the pictureAPI object
            await GetAPIAsync();

            // Get the data from the pictureAPI object and return it as a tuple
            return (pictureAPI.media_type, pictureAPI.url, pictureAPI.explanation);
        }

    }
}
