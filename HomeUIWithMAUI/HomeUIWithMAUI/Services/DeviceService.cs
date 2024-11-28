using HomeUIWithMAUI.Data;
using HomeUIWithMAUI.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeUIWithMAUI.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly ApplicationDbContext _context;

        public DeviceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Thermostat> GetThermostatAsync(int deviceId)
        {
            return await _context.Thermostats.FindAsync(deviceId);
        }

        public async Task<List<Thermostat>> GetAllThermostatsAsync()
        {
            return await _context.Thermostats.ToListAsync();
        }

        public async Task AddDeviceAsync<T>(T device) where T : class
        {
            _context.Add(device);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDeviceAsync<T>(T device) where T : class
        {
            _context.Update(device);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateThermostatTemperatureAsync(int deviceId, double temperature)
        {
            var thermostat = await _context.Thermostats.FindAsync(deviceId);
            if (thermostat != null)
            {
                thermostat.SetTemperature(temperature);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateThermostatStateAsync(int deviceId, State state)
        {
            var thermostat = await _context.Thermostats.FindAsync(deviceId);
            if (thermostat != null)
            {
                thermostat.UpdateState(state);
                await _context.SaveChangesAsync();
            }
        }


    }
}
