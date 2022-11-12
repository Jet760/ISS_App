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
        // initialize the data model class
        LiveStreamDataModel model = new LiveStreamDataModel();

        /// <summary>
        /// Gets the type, url and explination data from the model. Async method
        /// </summary>
        /// <returns>tuple (string type, string url, string explination)</returns>
        public async Task<(string type, string url, string explination)> GetDataAsync()
        {
            return await model.GetDataAsync();
        }

    }
}
