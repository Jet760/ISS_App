using ISS_App.Home;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
namespace ISS_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        // initialize the controller class
        HomeController controller = new HomeController();
        bool autoUpdate = true;
        bool autoUpdateCurrentlyRunning = true;

        // initialize the pin for the ISS for the map
        Pin pin = new Pin
        {
            Label = "International Space Station",
            Type = PinType.Generic,
            Position = new Position(0, 0)
        };

        public HomePage()
        {
            InitializeComponent();
            
            RefreshUI();
            AutoUpdateUI();

            // Hides the refresh button if the map auto refreshes
            if (autoUpdate)
            {
                buttonRefresh.IsVisible = false;
            }
            else
            {
                buttonRefresh.IsVisible = true;
            }
            
        }

        /// <summary>
        /// Method for when the manual refresh button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefresh_Clicked(object sender, EventArgs e)
        {
            RefreshUI();
        }

        /// <summary>
        /// Updates the UI every 10s to refresh the map. Async method
        /// </summary>
        private async Task AutoUpdateUI()
        {
            // Checks the setting for auto update
            autoUpdate = ((App)App.Current).fileService.CheckAutoUpdate();
            while (autoUpdate)
            {
                // Checks the setting for auto update
                autoUpdate = ((App)App.Current).fileService.CheckAutoUpdate();
                // While auto update is running  keep this variable as true - this relates to whether the manual button is shown or not
                autoUpdateCurrentlyRunning = true;
                // Delay the next call 10s so we don't over call the API (it starts returning 0 if you over do it lol)
                await Task.Delay(10000);
                RefreshUI();
            };

            // If auto update stops running make autoUpdateCurrentlyRunning false and show the refresh button
            autoUpdateCurrentlyRunning = false;
            buttonRefresh.IsVisible = true;
        }

        /// <summary>
        /// Get the data from the API and updates the ISS pin on the map. Async method
        /// </summary>
        private async void RefreshUI()
        {
            // Checks if auto update is running
            if (!autoUpdateCurrentlyRunning)
            {
                // Checks the setting for auto update
                autoUpdate = ((App)App.Current).fileService.CheckAutoUpdate();
                // If auto update isn't running then we need to check if it should be
                if (autoUpdate)
                {
                    // Hide the manual refresh button
                    buttonRefresh.IsVisible = false;
                    // Start auto update again!
                    await AutoUpdateUI();
                }
            }
            // Get telem data from the controller
            var telemData = await controller.GetTelemDataAsync();
            double latitude = telemData.latitude;
            double longitude = telemData.longitude;
            double altitude = telemData.altitude;
            double velocity = telemData.velocity;

            // Set the string for the data according to the user preferences
            string altitudeString = string.Empty;
            string velocityString = string.Empty;

            // Get what unit of measurement the setting says we should be using
            string unitOfMeasurement = ((App)App.Current).fileService.CheckUnits();
            // Check if metric or imperial
            if (unitOfMeasurement == "metric")
            {
                // Make some cute strings with metric units <3
                altitudeString = Math.Round(altitude, 1).ToString() + " km";
                velocityString = Math.Round(velocity, 0).ToString() + " km/h";
            }
            else
            {
                // Make some yucky strings by converting the data and adding imperial units </3
                altitudeString = Math.Round((altitude / 1.609), 0).ToString() + " miles";
                velocityString = Math.Round((velocity / 1.609), 0).ToString() + " mph";
            }

            // Update the position of the ISS pin on the map
            Position issPosition = new Position(latitude, longitude);
            pin.Position = issPosition;

            // Add some data to the pin to be displayed when it is tapped
            pin.Address = $"Altitude: {altitudeString}  Velocity: {velocityString}";

            // Move the view of the map to centre the ISS pin
            int distance = ((App)App.Current).fileService.CheckDistance();
            mapHomeMap.MoveToRegion(MapSpan.FromCenterAndRadius(issPosition, Distance.FromKilometers(distance)));

            // Populate the on screen text for the telem data
            labelLatitude.Text = Math.Round(latitude, 4).ToString();
            labelLongitude.Text = Math.Round(longitude, 4).ToString();
            labelAltitude.Text = altitudeString;
            labelVelocity.Text = velocityString;


            // Clear the current pins ready for redrawing
            mapHomeMap.Pins.Clear();
            // Add ISS pin to the map
            mapHomeMap.Pins.Add(pin);
            // Add the notif location pins
            List<Pin> pinList = await controller.GetPinListAsync();
            if (pinList != null)
            {
                foreach (Pin pin in pinList)
                {
                    mapHomeMap.Pins.Add(pin);
                }
            }
            
            

        }
    }
}