using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ISS_App.Astronauts
{
    internal class AstronautsDataModel
    {
        // initialize the API JSON data class
        PeopleInSpaceAPI.Rootobject AstronautAPI = new PeopleInSpaceAPI.Rootobject();

        /// <summary>
        /// Calls the people in space API and converts the data into a PeopleInSpaceAPI.Rootobject object. Async method
        /// </summary>
        public async Task GetAPIAsync()
        {
            // Calls the API
            var client = new HttpClient();
            var response = await client.GetAsync("http://api.open-notify.org/astros.json");
            var responseString = await response.Content.ReadAsStringAsync();
            // Converts the API JSON into the data class object
            AstronautAPI = JsonConvert.DeserializeObject<PeopleInSpaceAPI.Rootobject>(responseString);
            
        }

        /// <summary>
        /// Calls the API method to return the list of people in space. Async method
        /// </summary>
        /// <returns>PeopleInSpaceAPI.Person[]</returns>
        public async Task<PeopleInSpaceAPI.Person[]> GetPeopleListAsync()
        {
            await GetAPIAsync();
            return AstronautAPI.people;
        }
    }
}
