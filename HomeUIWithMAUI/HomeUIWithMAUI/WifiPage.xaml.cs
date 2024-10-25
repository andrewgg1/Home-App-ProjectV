namespace HomeUIWithMAUI
{
    public partial class WifiPage : ContentPage
    {
        public WifiPage()
        {
            InitializeComponent();
        }

        private void OnWiFiToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                NetworkStatusLabel.Text = "Network Status: Connected";
            }
            else
            {
                NetworkStatusLabel.Text = "Network Status: Disconnected";
            }
        }

        private async void OnDisconnectClicked(object sender, EventArgs e)
        {
            WiFiSwitch.IsToggled = false;
            await DisplayAlert("Wi-Fi", "You have disconnected from the network.", "OK");
        }

        private async void OnReconnectClicked(object sender, EventArgs e)
        {
            WiFiSwitch.IsToggled = true;
            await DisplayAlert("Wi-Fi", "Reconnected to the network successfully.", "OK");
        }
    }
}
