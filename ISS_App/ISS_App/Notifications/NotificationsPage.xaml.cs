using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISS_App.Astronauts;
using ISS_App.Notifications;
using PCLStorage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISS_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationsPage : ContentPage
    {
        NotificationsController controller = new NotificationsController();

        public NotificationsPage()
        {
            InitializeComponent();
            
        }

        public async Task UpdateUIAsync()
        {
            List<NotificationClass.Notification> notifList = await controller.GetNotifListAsync();
            foreach (NotificationClass.Notification location in notifList)
            {
                stackLayoutLocationNotifs.Children.Add(new NotificationView(location.name, location.latitude, location.longitude, location.icon));
            }

                
        }

        
        private async void buttonAddNewNotif_Pressed(object sender, EventArgs e)
        {

            string name = await DisplayPromptAsync("Add New Location", "Please enter the name of the new location ", maxLength: 20);
            if (name != null && name != "")
            {
                string latitude = await DisplayPromptAsync("Add New Location", "Please enter latitiude ", keyboard: Keyboard.Numeric, maxLength: 9);
                if (latitude != null && latitude != "")
                {
                    string longitude = await DisplayPromptAsync("Add New Location", "Please enter longitude ", keyboard: Keyboard.Numeric, maxLength: 9);
                    if (longitude != null && latitude != "")
                    {
                        string iconOutput = await DisplayActionSheet("Select icon:", "Cancel", null, "House", "Pin", "Globe", "Marker", "Tree", "Heart", "Horse");
                        if (iconOutput != null)
                        {
                            // TODO: make it so these are black or white depending on colour mode
                            string icon = "";
                            switch (iconOutput){
                                case "House":
                                    icon = "house_white";
                                    break;
                                case "Pin":
                                    icon = "pin_white";
                                    break;
                                case "Globe":
                                    icon = "world_white";
                                    break;
                                case "Marker":
                                    icon = "drop_white";
                                    break;
                                case "Tree":
                                    icon = "tree_white";
                                    break;
                                case "Heart":
                                    icon = "heart_white";
                                    break;
                                case "Horse":
                                    icon = "horse_white";
                                    break;
                                default:
                                    icon = "house_white";
                                    break;

                            }

                            await controller.AddNotifToFileAsync(name, latitude, longitude, icon);
                            
                            
                        }
                        
                    }
                }
            }
            
            
        }
    }
}