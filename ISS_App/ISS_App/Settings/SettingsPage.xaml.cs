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

        /// <summary>
        /// Refresh the UI with the current settings
        /// </summary>
        public void RefreshPreferences()
        {
            // Get the preferences from the controller 
            var preferences = controller.RefreshPreferences();
            string theme = preferences.theme;
            string units = preferences.units;
            bool update = preferences.update;
            int distance = preferences.distance;

            // Assign the colours for the dark theme <3
            if (theme == "dark")
            {
                switchDarkMode.IsToggled = true;
                App.Current.Resources["PageBackgroundColour"] = Color.FromHex("#36393f");
                App.Current.Resources["NavigationBarColour"] = Color.FromHex("#292929");
                App.Current.Resources["SelectedTabColor"] = Color.White;
                App.Current.Resources["UnselectedTabColor"] = Color.Gray;
                App.Current.Resources["ButtonColour"] = Color.FromHex("#484848");
                App.Current.Resources["PrimaryTextColour"] = Color.White;
                App.Current.Resources["SecondaryTextColour"] = Color.FromHex("#B9BBBE");
                App.Current.Resources["SwitchColour"] = Color.FromHex("#C269C5");
                App.Current.Resources["ThumbColour"] = Color.White;
            }
            // Assign the colours for the light theme (ahhh my eyes burnnnnnn)
            else
            {
                switchDarkMode.IsToggled = false;
                App.Current.Resources["PageBackgroundColour"] = Color.White;
                App.Current.Resources["NavigationBarColour"] = Color.FromHex("#F2F3F5");
                App.Current.Resources["SelectedTabColor"] = Color.Black;
                App.Current.Resources["UnselectedTabColor"] = Color.FromHex("#484848");
                App.Current.Resources["ButtonColour"] = Color.FromHex("#DBDEE1");
                App.Current.Resources["PrimaryTextColour"] = Color.Black;
                App.Current.Resources["SecondaryTextColour"] = Color.DarkGray;
                App.Current.Resources["SwitchColour"] = Color.FromHex("#C269C5");
                App.Current.Resources["ThumbColour"] = Color.White;
            }

            // Check if the units is metric or not and toggle the switch accordingly 
            if (units == "metric")
            {
                switchUnitOfMeasurement.IsToggled = true;
                labelUnitValue.Text = "Metric";
            }
            else
            {
                switchUnitOfMeasurement.IsToggled = false;
                labelUnitValue.Text = "Imperial";
            }

            // Check if the map should be auto updating or not and toggle the switch accordingly 
            if (update == true)
            {
                switchAutoUpdate.IsToggled = true;
            }
            else
            {
                switchAutoUpdate.IsToggled = false;
            }

            // Set the slider to the user defined distance
            sliderDistance.Value = distance;
            labelDistanceValue.Text = distance.ToString();
        }
        
        /// <summary>
        /// Call the controller to update the distance value
        /// </summary>
        /// <param name="value"></param>
        public void UpdateDistance(int value)
        {
            controller.UpdateDistance(value);
        }

        /// <summary>
        /// When the user changes the value of the slider update the file service so the map knows and change the label text to refect the slider value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sliderDistance_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateDistance(Convert.ToInt32(sliderDistance.Value));
            labelDistanceValue.Text = Convert.ToInt32(sliderDistance.Value).ToString();
        }

        /// <summary>
        /// Save the changes to the preferences
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSavePreferences_Clicked(object sender, EventArgs e)
        {
            // Default vaules
            string theme = "dark";
            string units = "metric";
            bool update = true;
            int distance = Convert.ToInt32(sliderDistance.Value);

            // Check if the switches have been changed from the default position
            if (!switchDarkMode.IsToggled)
            {
                theme = "light";
            }

            if (!switchUnitOfMeasurement.IsToggled)
            {
                units = "imperial";
            }

            if (!switchAutoUpdate.IsToggled)
            {
                update = false;
            }

            // Send the preferences to the controller so they can get updated
            controller.SetPreferences((theme, units, update, distance));
            RefreshPreferences();
        }

        /// <summary>
        /// Reset the settings to their default values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonResetPreferences_Clicked(object sender, EventArgs e)
        {
            controller.RestoreDefaults();
            RefreshPreferences();
        }
    }
}