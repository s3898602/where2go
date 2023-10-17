using Microsoft.Maui.Controls;
using System;

namespace Way2Go
{
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // Save settings to your application or a settings manager
            bool notificationsEnabled = NotificationsSwitch.IsToggled;
            double soundVolume = VolumeSlider.Value;
            string emailAddress = EmailEntry.Text;

            // Perform actions to save settings (e.g., to a preferences/settings manager)
            // You can use the values above to save the user's preferences.

            // For simplicity, this example just displays the values in an alert.
            DisplayAlert("Settings Saved", $"Notifications: {notificationsEnabled}\nVolume: {soundVolume}\nEmail: {emailAddress}", "OK");
        }
    }
}
