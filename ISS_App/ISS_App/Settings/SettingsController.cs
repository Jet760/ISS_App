using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace ISS_App.Settings
{
    internal class SettingsController
    {
        // initialize the model class
        SettingsDataModel model = new SettingsDataModel();

        public SettingsController()
        {
            
        }

        public (string theme, string units, bool update, int distance) RefreshPreferences()
        {
            return model.GetPreferences();
        }

        public void UpdateDistance(int value)
        {
            model.UpdateDistance(value);
        }
    }
}
