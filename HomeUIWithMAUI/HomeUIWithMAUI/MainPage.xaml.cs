using Microsoft.Maui.Controls;
using HomeUIWithMAUI.Connection;
using HomeUIWithMAUI.Models;
using Pool = HomeUIWithMAUI.DevicePool.DevicePool;
using Device = HomeUIWithMAUI.Models.Device;

using System;

namespace HomeUIWithMAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly HighCapacityTcpServer _tcpServer;

        // devices
        private Models.Thermostat _thermostat;
        private Models.Fridge _fridge;
        private Models.Dehumidifier _dehumidifier;

        public MainPage()
        {
            InitializeComponent();
            _tcpServer = new HighCapacityTcpServer();

            // Start the TCP server asynchronously
            StartServerAsync();

            // Retrieve devices from the DevicePool
            _thermostat = Pool.Devices.OfType<Models.Thermostat>().FirstOrDefault();
            _fridge = Pool.Devices.OfType<Models.Fridge>().FirstOrDefault();
            _dehumidifier = Pool.Devices.OfType<Models.Dehumidifier>().FirstOrDefault();
        }

        private async Task StartServerAsync()
        {
            await Task.Run(() => _tcpServer.StartServerAsync()); // Run server in a background task
        }

        // Event handler for adjusting the thermostat temperature
        private async void OnAdjustThermostatTemperature(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync(
                "Adjust Temperature",
                "Enter desired temperature (°C):",
                initialValue: _thermostat?.CurrentTemperature.ToString(),
                maxLength: 2,
                keyboard: Keyboard.Numeric
            );

            if (double.TryParse(result, out double newTemperature) && _thermostat != null)
            {
                _thermostat.SetTemperature(newTemperature);
                await DisplayAlert(
                    "Thermostat Updated",
                    $"Thermostat set to {newTemperature}°C.",
                    "OK"
                );
            }
        }

        // Event handler for toggling Fridge Power
        private void OnToggleFridgePower(object sender, ToggledEventArgs e)
        {
            if (_fridge != null)
            {
                var newState = e.Value ? Models.State.On : Models.State.Off;
                _fridge.UpdateState(newState);
                DisplayAlert(
                    "Fridge Power",
                    $"Fridge is now {(e.Value ? "On" : "Off")}.",
                    "OK"
                );
            }
        }

        // Event handler for toggling Dehumidifier Power
        private void OnToggleDehumidifierPower(object sender, EventArgs e)
        {
            bool isOn = DehumidifierSwitch.IsToggled;
            // Placeholder for integration with Home Business Layer
            // Example: Call a method to update the dehumidifier power state
            DisplayAlert("Dehumidifier Power", $"Dehumidifier is now {(isOn ? "On" : "Off")}.", "OK");
        }

        // Method to update Fridge data (to be called by the Home Business Layer)
        public void UpdateFridgeData(int fridgeTemp, int freezerTemp)
        {
            FridgeTempLabel.Text = $"{fridgeTemp}°C";
            FreezerTempLabel.Text = $"{freezerTemp}°C";
        }

        // Method to update Dehumidifier data (to be called by the Home Business Layer)
        public void UpdateDehumidifierData(int waterLevel, int humidity)
        {
            WaterLevelLabel.Text = $"{waterLevel}%";
            HumidityLabel.Text = $"{humidity}%";
        }

        // Navigation to Locks Page
        private async void OnOpenLocksPageClicked(object sender, EventArgs e)
        {
            // Placeholder for navigation logic
            await Navigation.PushAsync(new LocksPage());
        }

        // Navigation to Sensors Page
        private async void OnOpenSensorsPageClicked(object sender, EventArgs e)
        {
            // Placeholder for navigation logic
            await Navigation.PushAsync(new SensorsPage());
        }

        // Navigation to Cameras Page
        private async void OnOpenCamerasPageClicked(object sender, EventArgs e)
        {
            // Placeholder for navigation logic
            await Navigation.PushAsync(new CamerasPage());
        }

        // Navigation to Alarms Page
        private async void OnOpenAlarmsPageClicked(object sender, EventArgs e)
        {
            // Placeholder for navigation logic
            await Navigation.PushAsync(new AlarmsPage());
        }

        // Navigation to Trackers Page
        private async void OnOpenTrackersPageClicked(object sender, EventArgs e)
        {
            // Placeholder for navigation logic
            await Navigation.PushAsync(new TrackersPage());
        }
    }
}
