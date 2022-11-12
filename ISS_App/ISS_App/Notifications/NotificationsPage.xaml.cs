using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISS_App.Astronauts;
using ISS_App.Notifications;
using PCLStorage;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISS_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationsPage : ContentPage
    {
        // initialize the controller class
        NotificationsController controller = new NotificationsController();

        public NotificationsPage()
        {
            InitializeComponent();
            controller.StartUpAsync();
            
        }
        /// <summary>
        /// Override to attempt to run the UpdateUI as async when the app is started. Async method
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await UpdateUIAsync();
        }

        /// <summary>
        /// Gets the list of locations from the file and populates the UI. Async method
        /// </summary>
        public async Task UpdateUIAsync()
        {
            // Clears the stack layout ready to be re-populated
            stackLayoutLocationNotifs.Children.Clear();
            // Gets the list of notification objects
            List<NotificationClass.Notification> notifList = await controller.GetNotifListAsync();
            if (notifList != null)
            {
                foreach (NotificationClass.Notification location in notifList)
                {
                    // Adds each location to the stack layout as a custom view
                    stackLayoutLocationNotifs.Children.Add(new NotificationView(location.name, location.latitude, location.longitude, location.icon));
                }
            }
            else { return; }

                
        }

        /// <summary>
        /// Asks the user for input for a new notification location, calls the controller to add the input information to the file, then updates the UI. Async method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonAddNewNotif_Pressed(object sender, EventArgs e)
        {
            // Popup asks the user for the name 
            string name = await DisplayPromptAsync("Add New Location", "Please enter the name of the new location ", maxLength: 20);
            // It only prompts the user for the next input if they have put text
            if (name != null && name != "")
            {
                // Popup asks the user for the latitude
                string latitude = await DisplayPromptAsync("Add New Location", "Please enter latitiude ", keyboard: Keyboard.Numeric, maxLength: 9);
                if (latitude != null && latitude != "")
                {
                    // Popup asks the user for the longitude
                    string longitude = await DisplayPromptAsync("Add New Location", "Please enter longitude ", keyboard: Keyboard.Numeric, maxLength: 9);
                    if (longitude != null && latitude != "")
                    {
                        // Popup asks the user to choose one of the icons from a list
                        string icon = await DisplayActionSheet("Select icon:", "Cancel", null, "House", "Pin", "Globe", "Marker", "Tree", "Heart", "Horse");

                        // Calls the controller to add the new notification to the file
                        await controller.AddNotifToFileAsync(name, latitude, longitude, icon);

                        // Update the UI
                        await UpdateUIAsync();
                    }
                }
            }
        }
    }
}