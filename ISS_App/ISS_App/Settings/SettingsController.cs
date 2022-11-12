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

        /// <summary>
        /// Gets the tuple of preferences from the model and returns it
        /// </summary>
        /// <returns>(string theme, string units, bool update, int distance)</returns>
        public (string theme, string units, bool update, int distance) RefreshPreferences()
        {
            return model.GetPreferences();
        }

        /// <summary>
        /// Resets the settings to their default values
        /// </summary>
        public void RestoreDefaults()
        {
            model.ResetDefaultPreferences();
        }

        /// <summary>
        /// Takes the input value and passes it to the model so it can update the distance
        /// </summary>
        /// <param name="value"></param>
        public void UpdateDistance(int value)
        {
            model.UpdateDistance(value);
        }

        /// <summary>
        /// Takes a tuple input and passes it to the model so it can set the preferences
        /// </summary>
        /// <param name="values"></param>
        public void SetPreferences((string theme, string units, bool update, int distance) values)
        {
            model.SetPreferences(values);
        }
    }
}
