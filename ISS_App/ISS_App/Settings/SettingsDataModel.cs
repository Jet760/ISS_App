using Newtonsoft.Json;
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
            StartPreferences();
        }

        private void StartPreferences()
        {
            Preferences.Get("AppTheme", "dark");
            Preferences.Get("Units", "metric");
            Preferences.Get("AutoUpdate", true);
            Preferences.Get("Distance", 4000);
        }
        public (string theme, string units, bool update, int distance) GetPreferences()
        {
            string theme = Preferences.Get("AppTheme", "dark");
            string units = Preferences.Get("Units", "metric");
            bool update = Preferences.Get("AutoUpdate", true);
            int distance = Preferences.Get("Distance", 4000);

            return (theme, units, update, distance);
        }

        public void UpdateAppTheme(string value)
        {
            if (value.ToLower() == "dark" || value.ToLower() == "light")
            {
                Preferences.Set("AppTheme", value);
            }
            else
            {
                Console.WriteLine("Setting the theme failed, not dark or light");
            }
            
        }
        public void UpdateUnits(string value)
        {
            if (value.ToLower() == "metric" || value.ToLower() == "imperial")
            {
                Preferences.Set("Units", value);
            }
            else
            {
                Console.WriteLine("Setting the units failed, not metric or imperial");
            }
            
        }
        
        public void UpdateAutoUpdate(bool value)
        {
            if (value == true || value == false)
            {
                Preferences.Set("AutoUpdate", value);
            }
            else
            {
                Console.WriteLine("Setting the auto update failed, not a bool");
            }
            
        }
        public void UpdateDistance(int value)
        {
            if (value > 100 || value < 10000)
            {
                Preferences.Set("Distance", value);
                ((App)App.Current).fileService.UpdateDistance();

            }
            else
            {
                Console.WriteLine("Setting the Distance failed, not in the right int range");
            }
            
        }
        
        
        
    }
}
