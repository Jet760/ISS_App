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
        PeopleInSpaceAPI.Rootobject AstronautAPI = new PeopleInSpaceAPI.Rootobject();
        public async Task GetAPIAsync()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://api.open-notify.org/astros.json");
            var responseString = await response.Content.ReadAsStringAsync();
            AstronautAPI = JsonConvert.DeserializeObject<PeopleInSpaceAPI.Rootobject>(responseString);
            
        }

        public async Task<PeopleInSpaceAPI.Person[]> GetPeopleListAsync()
        {
            await GetAPIAsync();
            return AstronautAPI.people;
        }
    }
}
