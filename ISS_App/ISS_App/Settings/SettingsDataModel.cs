using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ISS_App.Settings
{
    internal class SettingsDataModel
    {
        
        public SettingsDataModel()
        { 
        }

        /// <summary>
        /// Restores the app settings to their default values
        /// </summary>
        public void ResetDefaultPreferences()
        {
            Preferences.Set("AppTheme", "dark");
            Preferences.Set("Units", "metric");
            Preferences.Set("AutoUpdate", true);
            Preferences.Set("Distance", 4000);
        }

        /// <summary>
        /// Sets the app preferences from the input tuple
        /// </summary>
        /// <param name="values"></param>
        public void SetPreferences((string theme, string units, bool update, int distance) values)
        {
            Preferences.Set("AppTheme", values.theme);
            Preferences.Set("Units", values.units);
            Preferences.Set("AutoUpdate", values.update);
            Preferences.Set("Distance", values.distance);
        }

        /// <summary>
        /// Gets the app preferences and returns them as a tuple
        /// </summary>
        /// <returns>(string theme, string units, bool update, int distance)</returns>
        public (string theme, string units, bool update, int distance) GetPreferences()
        {
            string theme = Preferences.Get("AppTheme", "dark");
            string units = Preferences.Get("Units", "metric");
            bool update = Preferences.Get("AutoUpdate", true);
            int distance = Preferences.Get("Distance", 4000);
            return (theme, units, update, distance);
        }
        
        /// <summary>
        /// Updates the distance in the app's file service so that it can be accessed by the home page
        /// </summary>
        /// <param name="value"></param>
        public void UpdateDistance(int value)
        {
            if (value > 100 || value < 10000)
            {
                ((App)App.Current).fileService.UpdateDistance();
            }
            else
            {
                Console.WriteLine("Setting the Distance failed, not in the right int range");
            }
        }
    }
}
