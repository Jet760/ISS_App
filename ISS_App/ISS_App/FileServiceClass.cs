using ISS_App.Notifications;
using Newtonsoft.Json;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using FileSystem = PCLStorage.FileSystem;

namespace ISS_App
{
    public class FileServiceClass
    {
        public class FileService
        {
            string folderName = "ISSAppFolder";
            string filename = "notificationsFile.txt";

            string units = "metric";
            int distance = 4000;
            bool autoUpdate = true;

            /// <summary>
            /// Checks if the file and folder exist, and if not creates them. Async method
            /// </summary>
            public async Task CreateFileAsync()
            {
                // Gets the location for the folder
                IFolder folder = FileSystem.Current.LocalStorage;
                // Checks if the folder named "ISSAppFolder" exists, opens if it does and creates it if it doesn't
                folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
                // Checks if the file named "notificationsFile.txt" exists, opens if it does and creates it if it doesn't
                IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);

            }

            /// <summary>
            /// Adds the notification object passed through the parameter to the file. Async method
            /// </summary>
            /// <param name="newNotif"></param>
            public async Task AddNotifToFileAsync(NotificationClass.Notification newNotif)
            {
                // Gets the JSON string from the file
                string fileContents = await ReadFileAsync();

                // Gets the location for the folder
                IFolder folder = FileSystem.Current.LocalStorage;
                // Checks if the folder named "ISSAppFolder" exists, opens if it does and creates it if it doesn't
                folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
                // Checks if the file named "notificationsFile.txt" exists, opens if it does and creates it if it doesn't
                IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);

                // Deserializes the JSON into a list of notification objects
                List<NotificationClass.Notification> notifList = JsonConvert.DeserializeObject<List<NotificationClass.Notification>>(fileContents);

                // If the file is empty it returns null, this makes sure that if the file is empty a new list is created
                if (notifList == null)
                {
                    notifList = new List<NotificationClass.Notification>();
                }
                // Adds the new notification objects onto the end of the list
                notifList.Add(newNotif);
                // Serializes the list back into JSON
                string jsonData = JsonConvert.SerializeObject(notifList);
                // Writes the JSON back into the file
                await file.WriteAllTextAsync(jsonData);
            }

            /// <summary>
            /// Returns the JSON string from the file. Async method
            /// </summary>
            /// <returns>string json</returns>
            public async Task<string> ReadFileAsync()
            {
                // Gets the location for the folder
                IFolder folder = FileSystem.Current.LocalStorage;
                // Checks if the folder named "ISSAppFolder" exists, opens if it does and creates it if it doesn't
                folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
                // Gets the file named "notificationsFile.txt"
                IFile file = await folder.GetFileAsync(filename);
                // Gets the contents of the files
                string loadedContent = await file.ReadAllTextAsync();
                // Returns the JSON string
                return loadedContent;
            }
            /// <summary>
            /// Gets the contents of the file and returns it as a list of notification objects. Async method
            /// </summary>
            /// <returns>List NotificationClass.Notification </returns>
            public async Task<List<NotificationClass.Notification>> GetNotifListAsync()
            {
                // Gets the contents of the file as a JSON string
                string fileContents = await ReadFileAsync();
                // Deserializes the JSON into a list of notification objects
                List<NotificationClass.Notification> notifList = JsonConvert.DeserializeObject<List<NotificationClass.Notification>>(fileContents);
                // Returns the list of notification objects
                return notifList;
            }

            /// <summary>
            /// Checks the preferences and updates the units variable with the result
            /// </summary>
            public void UpdateUnits()
            {
                units = Preferences.Get("Units", "metric");
            }

            /// <summary>
            /// Updates the units variable from the preferences and returns it as a string
            /// </summary> 
            /// <returns>string units</returns>
            public string CheckUnits()
            {
                UpdateUnits();
                return units;
            }

            /// <summary>
            /// Checks the preferences and updates the distance variable with the result
            /// </summary>
            public void UpdateDistance()
            {
                distance = Preferences.Get("Distance", 4000);
            }

            /// <summary>
            /// Updates the distance variable from the preferences and returns it as an int
            /// </summary> 
            /// <returns>int distance</returns>
            public int CheckDistance()
            {
                UpdateDistance();
                return distance;
            }

            /// <summary>
            /// Checks the preferences and updates the autoUpdate variable with the result
            /// </summary>
            public void UpdateAutoUpdate()
            {
                autoUpdate = Preferences.Get("AutoUpdate", true);
            }

            /// <summary>
            /// Updates the autoUpdate variable from the preferences and returns it as a bool
            /// </summary> 
            /// <returns>bool autoUpdate</returns>
            public bool CheckAutoUpdate()
            {
                UpdateAutoUpdate();
                return autoUpdate;
            }
        }
    }
}
