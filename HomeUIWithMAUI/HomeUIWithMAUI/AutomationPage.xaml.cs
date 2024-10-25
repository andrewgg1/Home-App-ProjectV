namespace HomeUIWithMAUI
{
    public partial class AutomationPage : ContentPage
    {
        public AutomationPage()
        {
            InitializeComponent();
        }

        private async void OnGoodMorningClicked(object sender, EventArgs e)
        {
            // Simulate turning on devices for the morning scene
            await DisplayAlert("Good Morning",
                "Turning on lights and adjusting thermostat...", "OK");
        }

        private async void OnGoodNightClicked(object sender, EventArgs e)
        {
            // Simulate turning off devices for the night scene
            await DisplayAlert("Good Night",
                "Turning off lights and setting thermostat to 68°F...", "OK");
        }

        private async void OnAllDevicesOffClicked(object sender, EventArgs e)
        {
            // Simulate turning off all devices
            await DisplayAlert("All Devices Off",
                "All devices have been turned off.", "OK");
        }
    }
}
