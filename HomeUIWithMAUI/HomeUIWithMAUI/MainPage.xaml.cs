using Microsoft.Maui.Controls;

namespace HomeUIWithMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Event handler for toggling the smart bulb
        private void OnToggleLightClicked(object sender, EventArgs e)
        {
            // Toggle the WiproSmartBulbSwitch state
            WiproSmartBulbSwitch.IsToggled = !WiproSmartBulbSwitch.IsToggled;
        }

        // Event handler for adjusting the thermostat
        private void OnAdjustThermostatClicked(object sender, EventArgs e)
        {
            // Adjust the ThermostatSwitch as needed
           
        }

        // Event handler for toggling the smart fan
        private void OnToggleFanClicked(object sender, EventArgs e)
        {
            // Toggle the XiaomiSmartFanSwitch state
            XiaomiSmartFanSwitch.IsToggled = !XiaomiSmartFanSwitch.IsToggled;
        }

        private void OnWiproSmartBulbSwitchToggled(object sender, ToggledEventArgs e)
        {
            // Handle the toggle for Wipro Smart Bulb
            if (e.Value)
            {
                // The Wipro Smart Bulb is ON
            }
            else
            {
                // The Wipro Smart Bulb is OFF
            }
        }

        private void OnXiaomiSmartFanSwitchToggled(object sender, ToggledEventArgs e)
        {
            // Handle the toggle for Xiaomi Smart Fan
            if (e.Value)
            {
                // The Xiaomi Smart Fan is ON
            }
            else
            {
                // The Xiaomi Smart Fan is OFF
            }
        }

        private void OnThermostatSwitchToggled(object sender, ToggledEventArgs e)
        {
            // Handle the toggle for Thermostat
            if (e.Value)
            {
                // The Thermostat is ON
            }
            else
            {
                // The Thermostat is OFF
            }
        }

        // Event handler for toggling Wi-Fi switch
        private void OnToggleWiFiClicked(object sender, ToggledEventArgs e)
        {
            // Logic for toggling Wi-Fi
            bool isWiFiEnabled = e.Value;
        }

        // Event handler for disconnect button
        private void OnDisconnectButtonClicked(object sender, EventArgs e)
        {
            // Logic for disconnecting Wi-Fi
            WiFiSwitch.IsToggled = false; // Optionally toggle the switch off
            // Add your code for disconnecting Wi-Fi
        }

        private void OnSwitchOffAllClicked(object sender, EventArgs e)
        {
            // Switch off all devices
            WiproSmartBulbSwitch.IsToggled = false;
            XiaomiSmartFanSwitch.IsToggled = false;
            ThermostatSwitch.IsToggled = false;
        }

        private async void OnLivingRoomClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LivingRoomPage());
        }

        private async void OnBedroomClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BedroomPage());
        }

        private async void OnKitchenClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new KitchenPage());
        }

        private async void OnEnergyClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EnergyPage());
        }

        private async void OnAutomationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AutomationPage());
        }

        private async void OnWiFiClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WifiPage());
        }

        private async void OnDeviceManagementClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeviceManagementPage());
        }

        private async void OnNotificationsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotificationsPage());
        }

        private async void OnProfileAndSettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfileAndSettingsPage());
        }


        private async void OnSecurityAndAccessClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecurityAndAccessPage());
        }


        private async void OnVoiceControlClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VoiceControlPage());
        }


        //Voice Control Simulation 
        private void OnExecuteCommandClicked(object sender, EventArgs e)
        {
            string userCommand = UserCommandEntry.Text?.ToLower();
            string response = "Sorry, I didn't understand that command.";

            // Search the shared command store for a matching command
            foreach (var command in CommandStore.Instance.Commands)
            {
                if (userCommand.Contains(command.Command.ToLower()))
                {
                    response = command.Response;
                    break;
                }
            }

            CommandResponseLabel.Text = response;
            UserCommandEntry.Text = string.Empty; // Clear the input field
        }


    }
}
