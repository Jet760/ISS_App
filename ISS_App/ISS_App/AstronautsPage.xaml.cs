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
    public partial class AstronautsPage : ContentPage
    {
        PeopleInSpaceAPI.Rootobject AstronautAPI = new PeopleInSpaceAPI.Rootobject();
        public AstronautsPage()
        {
            InitializeComponent();
            GetAPI();
            
        }
        public async void GetAPI()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://api.open-notify.org/astros.json");
            var responseString = await response.Content.ReadAsStringAsync();
            AstronautAPI = JsonConvert.DeserializeObject<PeopleInSpaceAPI.Rootobject>(responseString);
            if(AstronautAPI.message != null)
            {
                Console.WriteLine("CALLED API");
            }
            PopulateUI();
        }

        public void PopulateUI()
        {
            int peopleCounter = 0;
            foreach (PeopleInSpaceAPI.Person astro in AstronautAPI.people)
            {
                stackLayoutAstronauts.Children.Add(new AstronautView(astro.name, astro.craft));
                peopleCounter++;

            }
            labelNumberOfPeople.Text = peopleCounter.ToString();
        }
    }
}