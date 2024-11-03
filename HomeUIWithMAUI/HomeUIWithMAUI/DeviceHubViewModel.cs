using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace HomeUIWithMAUI.ViewModels
{
    public class DeviceHubViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Hubs { get; set; }
        public ObservableCollection<Device> Devices { get; set; }
        private string selectedHub;

        public string SelectedHub
        {
            get => selectedHub;
            set
            {
                if (selectedHub != value)
                {
                    selectedHub = value;
                    OnPropertyChanged(nameof(SelectedHub));
                    LoadDevices(selectedHub);
                }
            }
        }

        public DeviceHubViewModel()
        {
            Hubs = new ObservableCollection<string> { "Locks", "Sensors", "Cameras", "Alarms", "Trackers" };
            Devices = new ObservableCollection<Device>();
        }

        private void LoadDevices(string hubName)
        {
            Devices.Clear();
            var hubDevices = GetDevicesForHub(hubName);
            foreach (var device in hubDevices)
                Devices.Add(device);
        }

        private List<Device> GetDevicesForHub(string hubName)
        {
            // Dummy device list based on selected hub
            return hubName switch
            {
                "Locks" => new List<Device> { new Device("Front door smart lock"), new Device("Garage door smart lock") },
                "Sensors" => new List<Device> { new Device("Motion sensor"), new Device("Door sensor") },
                _ => new List<Device>()
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public class Device
    {
        public string Name { get; set; }
        public ICommand ShowDetailsCommand { get; set; }

        public Device(string name)
        {
            Name = name;
            ShowDetailsCommand = new Command(() => ShowDetails());
        }

        private void ShowDetails()
        {
            Console.WriteLine($"Showing details for {Name}");
        }
    }
}
