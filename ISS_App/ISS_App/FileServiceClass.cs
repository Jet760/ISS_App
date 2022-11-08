using ISS_App.Notifications;
using Newtonsoft.Json;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISS_App
{
    public class FileServiceClass
    {
        public class FileService
        {
            String folderName = "ISSAppFolder";
            String filename = "notificationsFile.txt";

            public async Task CreateFileAsync()
            {
                IFolder folder = FileSystem.Current.LocalStorage;
                folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
                IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);

            }


            public async Task AddNotifToFileAsync(NotificationClass.Notification newNotif)
            {
                string fileContents = await ReadFileAsync();

                IFolder folder = FileSystem.Current.LocalStorage;
                folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
                IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);

                List<NotificationClass.Notification> notifList = JsonConvert.DeserializeObject<List<NotificationClass.Notification>>(fileContents);

                if (notifList == null)
                {
                    notifList = new List<NotificationClass.Notification>();
                }
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
                Console.WriteLine(loadedContent);
                return loadedContent;
            }
            /// <summary>
            /// AHHHHH
            /// </summary>
            /// <returns></returns>
            public async Task<List<NotificationClass.Notification>> GetNotifListAsync()
            {
                string fileContents = await ReadFileAsync();
                List<NotificationClass.Notification> notifList = JsonConvert.DeserializeObject<List<NotificationClass.Notification>>(fileContents);
                return notifList;
            }
        }
    }
}
