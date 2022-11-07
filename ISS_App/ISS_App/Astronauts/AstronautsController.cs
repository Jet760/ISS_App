using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISS_App.Astronauts
{
    internal class AstronautsController
    {
        AstronautsDataModel model = new AstronautsDataModel();

        public async Task<PeopleInSpaceAPI.Person[]> GetPeopleListAsync()
        {
            Console.WriteLine("C getpeople");
            PeopleInSpaceAPI.Person[] list = await model.GetPeopleListAsync();
            Console.WriteLine(list);
            return list;
        }
    }
}
