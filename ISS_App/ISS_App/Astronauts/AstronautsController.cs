using System;
using System.Collections.Generic;
using System.Text;

namespace ISS_App.Astronauts
{
    internal class AstronautsController
    {
        AstronautsDataModel model = new AstronautsDataModel();

        public PeopleInSpaceAPI.Person[] GetPeopleList()
        {
            return model.GetPeopleList();
        }
    }
}
