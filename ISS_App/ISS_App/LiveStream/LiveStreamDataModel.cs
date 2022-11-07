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
        APODAPI.Rootobject pictureAPI = new APODAPI.Rootobject();
        public async Task GetAPIAsync()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://api.nasa.gov/planetary/apod?api_key=Q0rkk2qrxonZtxnz82Iz6vI31xOX5h6zdhjC0Ssq");
            var responseString = await response.Content.ReadAsStringAsync();
            pictureAPI = JsonConvert.DeserializeObject<APODAPI.Rootobject>(responseString);
        }

        public async Task<string> GetTypeAsync()
        {
            await GetAPIAsync();
            return pictureAPI.media_type;
        }

        public async Task<string> GetUrlAsync()
        {
            await GetAPIAsync();
            return pictureAPI.url;
        }
        public async Task<string> GetExplinationAsync()
        {
            await GetAPIAsync();
            return pictureAPI.explanation;

        }
    }
}
