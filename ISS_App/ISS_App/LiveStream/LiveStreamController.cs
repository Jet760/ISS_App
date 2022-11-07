using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ISS_App.LiveStream
{
    internal class LiveStreamController
    {
        LiveStreamDataModel model = new LiveStreamDataModel();
        string url = string.Empty;
        string type = string.Empty;
        string explanation = string.Empty;

        public async Task PopulateDataAsync()
        {

            url = await model.GetUrlAsync();
            type = await model.GetTypeAsync();
            explanation = await model.GetExplinationAsync();
        }

        public async Task<string> GetTypeAsync()
        {
            await PopulateDataAsync();
            return type;
        }

        public async Task<string> GetUrlAsync()
        {
            await PopulateDataAsync();
            return url;
        }
        public async Task<string> GetExplinationAsync()
        {
            await PopulateDataAsync();
            return explanation;
        }
    }
}
