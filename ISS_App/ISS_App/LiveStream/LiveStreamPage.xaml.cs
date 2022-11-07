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
        LiveStreamController controller = new LiveStreamController();
        public LiveStreamPage()
        {
            InitializeComponent();
            PopulateUIAsync();
            
        }
        

            public async void PopulateUIAsync()
        {
            string type = await controller.GetTypeAsync();
            string url = await controller.GetUrlAsync();


            if (type == "image")
            {
                
                imagePicOfTheDay.Source = url;
                imagePicOfTheDay.Opacity = 100;

            }
            else
            {
                webViewPicOfTheDay.Source = url;
                webViewPicOfTheDay.IsEnabled = true;
                imagePicOfTheDay.Opacity = 0;
            }
                labelExplination.Text = await controller.GetExplinationAsync();
        }
    }
}