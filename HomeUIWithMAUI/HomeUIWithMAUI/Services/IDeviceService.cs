using HomeUIWithMAUI.Models;

namespace HomeUIWithMAUI.Services
{
    public interface IDeviceService
    {
        Task<List<Thermostat>> GetAllThermostatsAsync();
        //Task<List<SmartLock>> GetAllSmartLocksAsync();
        Task AddDeviceAsync<T>(T device) where T : class;
        Task UpdateDeviceAsync<T>(T device) where T : class;
        Task<Thermostat> GetThermostatAsync(int v);
        Task UpdateThermostatTemperatureAsync(int deviceId, double newTemperature);
        Task UpdateThermostatStateAsync(int deviceId, State currentState);
    }
}

