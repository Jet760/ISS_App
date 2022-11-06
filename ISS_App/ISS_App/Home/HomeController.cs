using System;
using System.Collections.Generic;
using System.Text;

namespace ISS_App.Home
{
    internal class HomeController
    {
        HomeDataModel model = new HomeDataModel();

        double latitude = 0;
        double longitude = 0;
        double altitude = 0;
        double velocity = 0;

        public HomeController()
        {
            UpdateTelemData();
        }

        private void UpdateTelemData()
        {
            latitude = model.GetLatitude();
            longitude = model.GetLongitude();
            altitude = model.GetAltitude();
            velocity = model.GetVelocity();
        }

        public double GetLatitude()
        {
            UpdateTelemData();
            return latitude;
        }
        public double GetLongitude()
        {
            UpdateTelemData();
            return longitude;
        }
        public double GetAltitude()
        {
            UpdateTelemData();
            return altitude;
        }
        public double GetVelocity()
        {
            UpdateTelemData();
            return velocity;
        }
    }
}
