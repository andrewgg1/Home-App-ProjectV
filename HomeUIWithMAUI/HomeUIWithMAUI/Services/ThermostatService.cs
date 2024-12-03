//using HomeUIWithMAUI.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http.Json;
//using System.Text;
//using System.Threading.Tasks;

//namespace HomeUIWithMAUI.Services
//{
//    public class ThermostatService
//    {
//        private readonly HttpClient _httpClient;

//        public ThermostatService()
//        {
//            _httpClient = new HttpClient { BaseAddress = new Uri("http://10.0.0.192:5069/api/") }; 
//        }

//        // Fetch the current thermostat state
//        public async Task<Thermostat> GetThermostatAsync()
//        {
//            return await _httpClient.GetFromJsonAsync<Thermostat>("thermostat") ?? new Thermostat();
//        }

//        // Set a new target temperature
//        public async Task SetTargetTemperatureAsync(double temperature)
//        {
//            await _httpClient.PutAsJsonAsync("thermostat/setTemperature", temperature);
//        }

//        // Toggle the thermostat's power
//        public async Task ToggleThermostatPowerAsync()
//        {
//            await _httpClient.PutAsync("thermostat/togglePower", null);
//        }
//    }
//}
