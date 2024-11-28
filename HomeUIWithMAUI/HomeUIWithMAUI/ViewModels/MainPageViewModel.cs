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
            LoadThermostat();

            AdjustThermostatCommand = new Command(async () => await AdjustThermostatAsync());
            ToggleThermostatCommand = new Command(async () => await ToggleThermostatStateAsync());
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

        public ICommand AdjustThermostatCommand { get; }
        public ICommand ToggleThermostatCommand { get; }

        private async void LoadThermostat()
        {
            _thermostat = await _deviceService.GetThermostatAsync(0); // Load the first thermostat
            if (_thermostat != null)
            {
                ThermostatStatus = $"Thermostat - Status: {_thermostat.CurrentTemperature}°F";
                IsThermostatOn = _thermostat.CurrentState == State.On;
            }
        }

        private async Task AdjustThermostatAsync()
        {
            string result = await Application.Current.MainPage.DisplayPromptAsync(
                "Adjust Temperature",
                "Enter desired temperature (°F):",
                initialValue: "72",
                maxLength: 3,
                keyboard: Keyboard.Numeric);

            if (double.TryParse(result, out double newTemperature))
            {
                _thermostat.SetTemperature(newTemperature);
                await _deviceService.UpdateThermostatTemperatureAsync(_thermostat.DeviceId, newTemperature);

                ThermostatStatus = $"Thermostat - Status: {newTemperature}°F";
                await App.Current.MainPage.DisplayAlert("Thermostat Updated", $"Thermostat set to {newTemperature}°F.", "OK");
            }
        }

        private async Task ToggleThermostatStateAsync()
        {
            _thermostat.UpdateState(IsThermostatOn ? State.On : State.Off);
            await _deviceService.UpdateThermostatStateAsync(_thermostat.DeviceId, _thermostat.CurrentState);

            ThermostatStatus = IsThermostatOn
                ? "Thermostat - Status: ON"
                : "Thermostat - Status: OFF";
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
