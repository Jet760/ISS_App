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

        public async Task CreateFileAsync()
        {
             await ((App)App.Current).fileService.CreateFileAsync();
        }

        public async Task AddNotifToFileAsync(NotificationClass.Notification newNotif)
        {
            await ((App)App.Current).fileService.AddNotifToFileAsync(newNotif);
        }

        public async Task<string> ReadFileAsync()
        {
            return await ((App)App.Current).fileService.ReadFileAsync();
        }

        public async Task<List<NotificationClass.Notification>> GetNotifListAsync()
        {
            return await ((App)App.Current).fileService.GetNotifListAsync();
        }

        
    }
}
