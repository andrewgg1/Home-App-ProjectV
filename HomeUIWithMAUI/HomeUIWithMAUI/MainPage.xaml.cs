using System;

namespace HomeUIWithMAUI
{
    public partial class MainPage : ContentPage
    {
        // Hardcoded data
        private double _thermostatTargetTemperature = 22.0;
        private double _fridgeTemperature = 4.0;
        private double _freezerTemperature = -2.0;
        private int _dehumidifierWaterLevel = 50;
        private int _dehumidifierHumidity = 20;

        public MainPage()
        {
            InitializeComponent();
            LoadUI();
        }

        private void LoadUI()
        {
            // Initialize Thermostat
            ThermostatStatusLabel.Text = $"Thermostat - Status: {_thermostatTargetTemperature}°C";
            ThermostatSwitch.IsToggled = true;

            // Initialize Fridge
            FridgeTempLabel.Text = $"{_fridgeTemperature}°C";
            FridgeTempSlider.Value = _fridgeTemperature;

            // Initialize Dehumidifier
            WaterLevelLabel.Text = $"{_dehumidifierWaterLevel}%";
            WaterLevelSlider.Value = _dehumidifierWaterLevel;

            HumidityLabel.Text = $"{_dehumidifierHumidity}%";
            HumiditySlider.Value = _dehumidifierHumidity;
        }

        // Event handler for thermostat adjustment
        private async void OnAdjustThermostatTemperature(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync(
                "Adjust Temperature",
                "Enter desired temperature (°C):",
                initialValue: _thermostatTargetTemperature.ToString(),
                keyboard: Keyboard.Numeric
            );

            if (double.TryParse(result, out double newTemperature))
            {
                _thermostatTargetTemperature = newTemperature;
                ThermostatStatusLabel.Text = $"Thermostat - Status: {_thermostatTargetTemperature}°C";
                await DisplayAlert("Thermostat Updated", $"Thermostat set to {_thermostatTargetTemperature}°C.", "OK");
            }
        }

        // Event handler for fridge temperature adjustment
        private void OnFridgeTempSliderChanged(object sender, ValueChangedEventArgs e)
        {
            _fridgeTemperature = e.NewValue;
            FridgeTempLabel.Text = $"{_fridgeTemperature:F1}°C"; // Display with 1 decimal place
        }

        // Event handler for freezer temperature adjustment
        private void OnFreezerTempSliderChanged(object sender, ValueChangedEventArgs e)
        {
            _freezerTemperature = e.NewValue;
            FreezerTempLabel.Text = $"{_freezerTemperature:F1}°C"; // Display with 1 decimal place
        }

        // Event handler for dehumidifier water level adjustment
        private void OnWaterLevelSliderChanged(object sender, ValueChangedEventArgs e)
        {
            _dehumidifierWaterLevel = (int)e.NewValue;
            WaterLevelLabel.Text = $"{_dehumidifierWaterLevel}%";
        }

        // Event handler for dehumidifier humidity adjustment
        private void OnHumiditySliderChanged(object sender, ValueChangedEventArgs e)
        {
            _dehumidifierHumidity = (int)e.NewValue;
            HumidityLabel.Text = $"{_dehumidifierHumidity}%";
        }

        private void OnToggleFridgePower(object sender, EventArgs e)
        {
            // Simulate toggling fridge power
            bool isFridgeOn = FridgeSwitch.IsToggled;
            DisplayAlert("Fridge Power", $"Fridge is now {(isFridgeOn ? "On" : "Off")}.", "OK");
        }

        private void OnToggleDehumidifierPower(object sender, EventArgs e)
        {
            // Simulate toggling dehumidifier power
            bool isDehumidifierOn = DehumidifierSwitch.IsToggled;
            DisplayAlert("Dehumidifier Power", $"Dehumidifier is now {(isDehumidifierOn ? "On" : "Off")}.", "OK");
        }

        // Navigation Handlers
        private async void OnOpenLocksPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LocksPage());
        }

        private async void OnOpenSensorsPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SensorsPage());
        }

        private async void OnOpenCamerasPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CamerasPage());
        }

        private async void OnOpenAlarmsPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AlarmsPage());
        }

        private async void OnOpenTrackersPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrackersPage());
        }
    }
}
