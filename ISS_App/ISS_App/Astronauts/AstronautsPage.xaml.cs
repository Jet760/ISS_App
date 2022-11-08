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
        // initialize the controller class
        AstronautsController controller = new AstronautsController();

        public AstronautsPage()
        {
            InitializeComponent();
            PopulateUIAsync();
            
        }

        /// <summary>
        /// Gets the list of people in space from the API and displays them in the UI. Async method
        /// </summary>
        public async void PopulateUIAsync()
        {
            // Calls the controller's method to get the list of people
            PeopleInSpaceAPI.Person[] peopleList = await controller.GetPeopleListAsync();
            int peopleCounter = 0;
            // Loops through all the people in the list and displays them on the UI
            foreach (PeopleInSpaceAPI.Person astro in peopleList)
            {
                // Create a new view populated with the data from the person and add it to the stacklayout in the UI
                stackLayoutAstronauts.Children.Add(new AstronautView(astro.name, astro.craft));
                // Increment the people counter to display in the UI how many people
                peopleCounter++;

            }

            // Populates the UI with the count of how many people
            labelNumberOfPeople.Text = peopleCounter.ToString();
        }
    }
}