using ISS_App.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISS_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        // initialize the controller class
        SettingsController controller = new SettingsController();

        public SettingsPage()
        {
            InitializeComponent();
            RefreshPreferences();
        }


        public void RefreshPreferences()
        {
            var preferences = controller.RefreshPreferences();
            string theme = preferences.theme;
            string units = preferences.units;
            bool update = preferences.update;
            int distance = preferences.distance;

            if (theme == "dark")
            {
                switchDarkMode.IsToggled = true;
            }
            else
            {
                switchDarkMode.IsToggled = false;
            }
            if (units == "metric")
            {
                switchUnitOfMeasurement.IsToggled = true;
                labelUnitValue.Text = "Metric";
                ((App)App.Current).fileService.UpdateUnits();
            }
            else
            {
                switchUnitOfMeasurement.IsToggled = false;
                labelUnitValue.Text = "Imperial";
            }
            if (update == true)
            {
                switchAutoUpdate.IsToggled = true;
            }
            else
            {
                switchAutoUpdate.IsToggled = false;
            }
            sliderDistance.Value = distance;
            labelDistanceValue.Text = distance.ToString();
        }
            
        public void UpdateDistance(int value)
        {
            controller.UpdateDistance(value);
        }

        private void sliderDistance_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateDistance(Convert.ToInt32(sliderDistance.Value));
            return;
        }

        private void buttonSavePreferences_Clicked(object sender, EventArgs e)
        {
            RefreshPreferences();
        }
    }
}