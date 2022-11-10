using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace ISS_App.Settings
{
    internal class SettingsDataModel
    {
        
        public SettingsDataModel()
        {
            Preferences.Set("AppTheme", "Dark");
            Preferences.Set("Units", "Metric");
            Preferences.Set("AutoUpdate", true);
            Preferences.Set("Distance", 4000);
        }
        //
        int mgdofg = 0;
        
        
    }
}
