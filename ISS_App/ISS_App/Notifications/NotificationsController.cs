using PCLStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISS_App.Notifications
{
    internal class NotificationsController
    {
        NotificationsDataModel model = new NotificationsDataModel();

        public async Task AddNotifToFileAsync(string name, string latitude, string longitude, string icon)
        {
            NotificationClass.Notification newNotif = new NotificationClass.Notification(name, latitude, longitude, icon);
            await model.AddNotifToFileAsync(newNotif);
        }

        public async Task<List<NotificationClass.Notification>> GetNotifListAsync()
        {
            return await model.GetNotifListAsync();
        }

        public async void StartUpAsync()
        {
            await model.CreateFileAsync();
        }
    }
}
