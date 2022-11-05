using System;
using System.Collections.Generic;
using System.Text;

namespace ISS_App.Astronauts
{
    internal class PeopleInSpaceAPI
    {

        public class Rootobject
        {
            public string message { get; set; }
            public Person[] people { get; set; }
            public int number { get; set; }
        }

        public class Person
        {
            public string name { get; set; }
            public string craft { get; set; }
        }

    }
}
