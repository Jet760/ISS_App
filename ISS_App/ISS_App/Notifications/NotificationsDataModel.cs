using Newtonsoft.Json;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISS_App.Notifications
{
    internal class NotificationsDataModel
    {
        String folderName = "ISSAppFolder";
        String filename = "notificationsFile.txt";

        public async Task AddANotifToFileAsync(NotificationClass.Notification newNotif)
        {
            string fileContents = await ReadFileAsync();

            IFolder folder = FileSystem.Current.LocalStorage;
            folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);

            List<NotificationClass.Notification> notifList = JsonConvert.DeserializeObject<List<NotificationClass.Notification>>(fileContents);
            notifList.Add(newNotif);
            string jsonData = JsonConvert.SerializeObject(notifList);

            await file.WriteAllTextAsync(jsonData);
        }

        public async Task<string> ReadFileAsync()
        {
            IFolder folder = FileSystem.Current.LocalStorage;
            folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
            IFile file = await folder.GetFileAsync(filename);
            string loadedContent = await file.ReadAllTextAsync();
            return loadedContent;
        }

        public async Task<List<NotificationClass.Notification>> GetNotifListAsync()
        {
            string fileContents = await ReadFileAsync();
            List<NotificationClass.Notification> notifList = JsonConvert.DeserializeObject<List<NotificationClass.Notification>>(fileContents);
            return notifList;
        }

        
    }
}
