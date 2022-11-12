using ISS_App.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace ISS_App.Home
{
    internal class HomeController
    {
        // initialize the data model class
        HomeDataModel model = new HomeDataModel();

        public HomeController()
        {
            
        }

        /// <summary>
        /// Gets the telemetry data for the space station from the model class and assigns them to the variables. Async method
        /// </summary>
        /// <returns>(double latitude, double longitude, double altitude, double velocity)</returns>
        public async Task<(double latitude, double longitude, double altitude, double velocity)> GetTelemDataAsync()
        {
            // Get data from the model
            var telemData = await model.GetTelemDataAsync();

            // Assign data to variables
            double latitude = telemData.latitude;
            double longitude = telemData.longitude;
            double altitude = telemData.altitude;
            double velocity = telemData.velocity;

            // pass data back
            return (latitude, longitude, altitude, velocity);
        }


        /// <summary>
        /// Gets list of locations and creates a list of pins based on it. Returns null if no locations to make pins of. Async method
        /// </summary>
        /// <returns>List Pin </returns>
        public async Task<List<Pin>> GetPinListAsync()
        {
            // New list to store the pins
            List<Pin> pinList = new List<Pin>();

            // Get notif list from the file
            List<NotificationClass.Notification> notifList = await ((App)App.Current).fileService.GetNotifListAsync();
            // Make sure list isn't empty
            if (notifList != null)
            {
                // Run through the list of locations
                foreach (NotificationClass.Notification location in notifList)
                {
                    try
                    {
                        // Make a new pin with the data from the current location
                        double latitude = Convert.ToDouble(location.latitude);
                        double longitude = Convert.ToDouble(location.longitude);

                        Pin pin = new Pin
                        {
                            Label = location.name,
                            Type = PinType.Generic,
                            Position = new Position(latitude, longitude)
                        };

                        // Add the current new pin to the list
                        pinList.Add(pin);
                    }
                    // Catch if either of the converts fails and skip that location
                    catch
                    {
                        continue;
                    }
                }

                return pinList;
            }
            else
            {
                // If list is empty return null
                return null;
            }
            
        }
    }
}
