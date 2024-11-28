using HomeUIWithMAUI.Models;
using HomeUIWithMAUI.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HomeUIWithMAUI.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly IDeviceService _deviceService;
        private Thermostat _thermostat;

        public MainPageViewModel(IDeviceService deviceService)
        {
            _deviceService = deviceService;

            // Initialize commands
            AdjustThermostatCommand = new Command(async () => await AdjustThermostatAsync());
            ToggleThermostatCommand = new Command(async () => await ToggleThermostatStateAsync());
            RetryLoadCommand = new Command(LoadThermostat);

            // Load initial thermostat data
            LoadThermostat();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Thermostat Status
        private string _thermostatStatus;
        public string ThermostatStatus
        {
            get => _thermostatStatus;
            set
            {
                _thermostatStatus = value;
                OnPropertyChanged();
            }
        }

        // Thermostat ON/OFF state
        private bool _isThermostatOn;
        public bool IsThermostatOn
        {
            get => _isThermostatOn;
            set
            {
                if (_isThermostatOn != value)
                {
                    _isThermostatOn = value;
                    OnPropertyChanged();
                }
            }
        }

        // Determines if a thermostat is available
        private bool _hasThermostat;
        public bool HasThermostat
        {
            get => _hasThermostat;
            set
            {
                if (_hasThermostat != value)
                {
                    _hasThermostat = value;
                    OnPropertyChanged();
                }
            }
        }

        // Commands
        public ICommand AdjustThermostatCommand { get; }
        public ICommand ToggleThermostatCommand { get; }
        public ICommand RetryLoadCommand { get; }

        // Load Thermostat Data
        private async void LoadThermostat()
        {
            try
            {
                //  fetch thermostat data
                _thermostat = await _deviceService.GetThermostatAsync(0);

                if (_thermostat != null)
                {
                    // update properties if thermostat exists
                    HasThermostat = true;
                    ThermostatStatus = $"Thermostat - Status: {_thermostat.CurrentTemperature}°F";
                    IsThermostatOn = _thermostat.CurrentState == State.On;
                }
                else
                {
                    // fallback for missing data
                    HasThermostat = false;
                    ThermostatStatus = "No thermostat data available.";
                    IsThermostatOn = false;
                }
            }
            catch (Exception ex)
            {
                // handle exceptions
                Console.WriteLine($"Error loading thermostat: {ex.Message}");

                // update fallback UI state
                HasThermostat = false;
                ThermostatStatus = "Failed to load thermostat data.";
                IsThermostatOn = false;
            }
        }

        // Adjust thermostat temperature
        private async Task AdjustThermostatAsync()
        {
            try
            {
                string result = await App.Current.MainPage.DisplayPromptAsync(
                    "Adjust Temperature",
                    "Enter desired temperature (°F):",
                    initialValue: "72",
                    maxLength: 3,
                    keyboard: Keyboard.Numeric);

                if (double.TryParse(result, out double newTemperature) && newTemperature >= 50 && newTemperature <= 90)
                {
                    _thermostat.SetTemperature(newTemperature);
                    await _deviceService.UpdateThermostatTemperatureAsync(_thermostat.DeviceId, newTemperature);

                    ThermostatStatus = $"Thermostat - Status: {newTemperature}°F";
                    await App.Current.MainPage.DisplayAlert("Thermostat Updated", $"Thermostat set to {newTemperature}°F.", "OK");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Invalid Input", "Please enter a valid temperature between 50°F and 90°F.", "OK");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Failed to adjust thermostat: {ex.Message}", "OK");
            }
        }

        // Toggle thermostat state
        private async Task ToggleThermostatStateAsync()
        {
            try
            {
                _thermostat.UpdateState(IsThermostatOn ? State.On : State.Off);
                await _deviceService.UpdateThermostatStateAsync(_thermostat.DeviceId, _thermostat.CurrentState);

                ThermostatStatus = IsThermostatOn
                    ? "Thermostat - Status: ON"
                    : "Thermostat - Status: OFF";
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Failed to toggle thermostat: {ex.Message}", "OK");
            }
        }

        // Notify property change
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
