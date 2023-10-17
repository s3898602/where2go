using Microsoft.Maui.Controls;
using System;

namespace Way2Go
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            // Perform authentication logic here (validate against a database or authentication service).
            // For this example, we'll assume a basic username/password check.
            if (IsValidUser(username, password))
            {
                await DisplayAlert("Login Successful", "Welcome, " + username, "OK");

                // Redirect to the "Navigation" page after the user clicks "OK"
                await Navigation.PushAsync(new Navigation()); // Replace with the actual page you want to navigate to
            }
            else
            {
                await DisplayAlert("Login Failed", "Invalid username or password", "OK");
            }

            // Clear the username and password fields.
            usernameEntry.Text = string.Empty;
            passwordEntry.Text = string.Empty;
        }


        private async void OnGuestButtonClicked(object sender, EventArgs e)
        {
            // Perform actions for guests or navigate to the guest experience.
            await DisplayAlert("Guest Access", "You are accessing as a guest.", "OK");

            // Redirect to the "Navigation" page after the user clicks "OK"
            await Navigation.PushAsync(new Navigation()); // Replace with the actual page you want to navigate to
        }

        private bool IsValidUser(string username, string password)
        {
            // Implement your authentication logic here.
            // For a basic example, you can hard-code a username and password for testing.
            return username == "admin" && password == "password";
        }
    }
}
