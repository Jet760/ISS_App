using ISS_App.Astronauts;
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
        AstronautsController controller = new AstronautsController();

        public AstronautsPage()
        {
            InitializeComponent();
            PopulateUI();
            
        }
        

        public void PopulateUI()
        {
            PeopleInSpaceAPI.Person[] peopleList = controller.GetPeopleList();
            int peopleCounter = 0;
            foreach (PeopleInSpaceAPI.Person astro in peopleList)
            {
                stackLayoutAstronauts.Children.Add(new AstronautView(astro.name, astro.craft));
                peopleCounter++;

            }
            labelNumberOfPeople.Text = peopleCounter.ToString();
        }
    }
}