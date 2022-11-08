using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISS_App.Astronauts
{
    internal class AstronautsController
    {
        // initialize the data model class
        AstronautsDataModel model = new AstronautsDataModel();

        /// <summary>
        /// Retrieves the list of people from the people in space API in the model class.  
        /// Async method
        /// </summary>
        /// <returns>PeopleInSpaceAPI.Person[] </returns>
        public async Task<PeopleInSpaceAPI.Person[]> GetPeopleListAsync()
        {
            PeopleInSpaceAPI.Person[] list = await model.GetPeopleListAsync();
            return list;
        }
    }
}
