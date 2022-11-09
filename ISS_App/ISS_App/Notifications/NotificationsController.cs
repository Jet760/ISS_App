using PCLStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISS_App.Notifications
{
    internal class NotificationsController
    {
        // initialize the model class
        NotificationsDataModel model = new NotificationsDataModel();

        /// <summary>
        /// Creates a new notification object and adds it to the file. Async method
        /// </summary>
        /// <param name="name"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="icon"></param>
        public async Task AddNotifToFileAsync(string name, string latitude, string longitude, string icon)
        {
            // Creates a new notification object with the paramaters received
            NotificationClass.Notification newNotif = new NotificationClass.Notification(name, latitude, longitude, icon);
            // Calls the model to add the notification object to the file
            await model.AddNotifToFileAsync(newNotif);
        }

        /// <summary>
        /// Gets the list of notifications from the model and returns it. Async method
        /// </summary>
        /// <returns> List<NotificationClass.Notification> </returns>
        public async Task<List<NotificationClass.Notification>> GetNotifListAsync()
        {
            return await model.GetNotifListAsync();
        }
        
        /// <summary>
        /// Makes sure there is a file when the app first opens, creates the file if it doesn't exist. Async method
        /// </summary>
        public async void StartUpAsync()
        {
            await model.CreateFileAsync();
        }
    }
}
