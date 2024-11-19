using System;

namespace HomeUIWithMAUI
{
    public partial class LoginPage : ContentPage
    {
        private readonly UserService _userService;

        public LoginPage(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Please enter both username and password", "OK");
                return;
            }

            if (_userService.AuthenticateUser(username, password))
            {
                await Navigation.PushAsync(new MainPage()); // Navigate to MainPage after successful login
            }
            else
            {
                await DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            // Navigate to the Registration Page when the register button is clicked
            await Navigation.PushAsync(new RegistrationPage(_userService));
        }
    }
}
