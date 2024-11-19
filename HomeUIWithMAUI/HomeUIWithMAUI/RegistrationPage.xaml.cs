using System;

namespace HomeUIWithMAUI
{
    public partial class RegistrationPage : ContentPage
    {
        private readonly UserService _userService;

        public RegistrationPage(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;
            var email = EmailEntry.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
            {
                await DisplayAlert("Error", "Please fill in all fields", "OK");
                return;
            }

            if (_userService.RegisterUser(username, password, email))
            {
                await DisplayAlert("Success", "User registered successfully!", "OK");
                await Navigation.PopAsync(); // Navigate back to LoginPage
            }
            else
            {
                await DisplayAlert("Error", "Username already exists", "OK");
            }
        }
    }
}
