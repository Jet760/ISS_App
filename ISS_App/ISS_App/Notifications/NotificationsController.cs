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
            Console.WriteLine("C ADD TO FILE");
            NotificationClass.Notification newNotif = new NotificationClass.Notification(name, latitude, longitude, icon);
            await model.AddANotifToFileAsync(newNotif);
        }

        public async Task<List<NotificationClass.Notification>> GetNotifListAsync()
        {
            Console.WriteLine("C GET LIST");
            return await model.GetNotifListAsync();
        }

        public async void StartUpAsync()
        {
            Console.WriteLine("C START UP");
            await model.CreateFileAsync();
        }
    }
}
