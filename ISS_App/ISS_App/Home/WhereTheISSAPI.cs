using System;
using System.Collections.Generic;
using System.Text;

namespace ISS_App.Home
{
    internal class WhereTheISSAPI
    {

        public class Rootobject
        {
            public string name { get; set; }
            public int id { get; set; }
            public float latitude { get; set; }
            public float longitude { get; set; }
            public float altitude { get; set; }
            public float velocity { get; set; }
            public string visibility { get; set; }
            public float footprint { get; set; }
            public int timestamp { get; set; }
            public float daynum { get; set; }
            public float solar_lat { get; set; }
            public float solar_lon { get; set; }
            public string units { get; set; }
        }

    }
}
