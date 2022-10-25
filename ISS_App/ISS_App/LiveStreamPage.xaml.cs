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
        APODAPI.Rootobject pictureAPI = new APODAPI.Rootobject();
        public LiveStreamPage()
        {
            InitializeComponent();
            GetAPI();
        }
        public async void GetAPI()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://api.nasa.gov/planetary/apod?api_key=Q0rkk2qrxonZtxnz82Iz6vI31xOX5h6zdhjC0Ssq&date=2022-10-01");
            var responseString = await response.Content.ReadAsStringAsync();
            pictureAPI = JsonConvert.DeserializeObject<APODAPI.Rootobject>(responseString);
            Console.WriteLine("PIC API ");
            PopulateUI();
        }

            public void PopulateUI()
        {
                Console.WriteLine("IN PIC UI");
                Console.WriteLine(pictureAPI.explanation.ToString());
                if (pictureAPI.media_type == "image")
                {
                    imagePicOfTheDay.Source = pictureAPI.url;

                }
            else
            {
                webViewPicOfTheDay.Source = pictureAPI.url;
            }
                labelExplination.Text = pictureAPI.explanation;
        }
    }
}