using ISS_App.LiveStream;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISS_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LiveStreamPage : ContentPage
    {
        // initialize the controller class
        LiveStreamController controller = new LiveStreamController();
        public LiveStreamPage()
        {
            InitializeComponent();
            PopulateUIAsync();
            
        }
        
        /// <summary>
        /// Get the picture of the day data from the controller and populates the UI. Async method
        /// </summary>
         public async void PopulateUIAsync()
         {
            var data = await controller.GetDataAsync();
            string type = data.type;
            string url = data.url;

         if (type == "image")
         {
             // Set the source
             imagePicOfTheDay.Source = url;
             // Make the picture visible 
             imagePicOfTheDay.Opacity = 100;

         }
         else
         {
             // Set the source
             webViewPicOfTheDay.Source = url;
             // Make sure the web view shows
             webViewPicOfTheDay.IsEnabled = true;
             // Hides the image
             imagePicOfTheDay.Opacity = 0;
         }

         // populates the explination text
         labelExplination.Text = data.explination;
        }
    }
}