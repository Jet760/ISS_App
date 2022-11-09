using Newtonsoft.Json;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ISS_App.Notifications
{
    internal class NotificationsDataModel
    {

        /// <summary>
        /// Calls the file service to check if the file exists and creat it if it doesn't. Async method
        /// </summary>
        public async Task CreateFileAsync()
        {
             await ((App)App.Current).fileService.CreateFileAsync();
        }

        /// <summary>
        /// Adds the notification object passed as a parameter to the file via the file service. Async method
        /// </summary>
        /// <param name="newNotif"></param>
        public async Task AddNotifToFileAsync(NotificationClass.Notification newNotif)
        {
            await ((App)App.Current).fileService.AddNotifToFileAsync(newNotif);
        }

        /// <summary>
        /// Calls the file service to get the list of notifications. Async method
        /// </summary>
        /// <returns>List NotificationClass.Notification</returns>
        public async Task<List<NotificationClass.Notification>> GetNotifListAsync()
        {
            return await ((App)App.Current).fileService.GetNotifListAsync();
        }

        
    }
}
