namespace HomeUIWithMAUI
{
    public partial class ProfileAndSettingsPage : ContentPage
    {
        public ProfileAndSettingsPage()
        {
            InitializeComponent();  
        }

        private async void OnSaveChangesClicked(object sender, EventArgs e)
        {
            // Ensure all controls are accessible
            string userName = UserNameEntry.Text;
            string email = EmailEntry.Text;
            bool notificationsEnabled = NotificationsSwitch.IsToggled;
            bool darkModeEnabled = DarkModeSwitch.IsToggled;

            string message = $"Settings saved!\n" +
                             $"Name: {userName}\n" +
                             $"Email: {email}\n" +
                             $"Notifications: {(notificationsEnabled ? "Enabled" : "Disabled")}\n" +
                             $"Dark Mode: {(darkModeEnabled ? "Enabled" : "Disabled")}";

            await DisplayAlert("Profile & Settings", message, "OK");
        }
    }
}
