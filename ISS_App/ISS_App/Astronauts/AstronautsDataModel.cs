using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ISS_App.Astronauts
{
    internal class AstronautsDataModel
    {
        PeopleInSpaceAPI.Rootobject AstronautAPI = new PeopleInSpaceAPI.Rootobject();
        public async void GetAPI()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://api.open-notify.org/astros.json");
            var responseString = await response.Content.ReadAsStringAsync();
            AstronautAPI = JsonConvert.DeserializeObject<PeopleInSpaceAPI.Rootobject>(responseString);
            
        }

        public PeopleInSpaceAPI.Person[] GetPeopleList()
        {
            GetAPI();
            return AstronautAPI.people;
        }
    }
}
