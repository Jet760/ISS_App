using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISS_App
{
    public partial class App : Application
    {
        public FileServiceClass.FileService fileService = new FileServiceClass.FileService();

        public App()
        {
            InitializeComponent();

            MainPage = new NavTab();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
