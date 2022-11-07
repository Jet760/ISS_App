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

        public async Task CreateFileAsync()
        {
            Console.WriteLine("M CREATE FILE");
            IFolder folder = FileSystem.Current.LocalStorage;
            folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
            
        }


        public async Task AddANotifToFileAsync(NotificationClass.Notification newNotif)
        {
            Console.WriteLine("M ADD TO FILE");
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
            // TODO: FIX THISSSSSS
            Console.WriteLine("M READ FILE");
            IFolder folder = FileSystem.Current.LocalStorage;
            Console.WriteLine("1");
            folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
            Console.WriteLine("2");
            IFile file = await folder.GetFileAsync(filename);
            Console.WriteLine("3");
            string loadedContent = await file.ReadAllTextAsync();
            Console.WriteLine("4");
            Console.WriteLine(loadedContent);
            return loadedContent;
        }

        public async Task<List<NotificationClass.Notification>> GetNotifListAsync()
        {
            Console.WriteLine("M GET LIST");
            string fileContents = await ReadFileAsync();
            List<NotificationClass.Notification> notifList = JsonConvert.DeserializeObject<List<NotificationClass.Notification>>(fileContents);
            return notifList;
        }

        
    }
}
