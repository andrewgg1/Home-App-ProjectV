using System.Collections.ObjectModel;

namespace HomeUIWithMAUI
{
    public partial class DeviceManagementPage : ContentPage
    {
        public ObservableCollection<Device> Devices { get; set; }

        public DeviceManagementPage()
        {
            InitializeComponent();
            Devices = new ObservableCollection<Device>
            {
                new Device { Name = "Smart Light", IsEnabled = true },
                new Device { Name = "Thermostat", IsEnabled = false },
                new Device { Name = "Smart Fan", IsEnabled = true }
            };
            DeviceListView.ItemsSource = Devices;
        }

        private void OnRemoveDeviceClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var device = (Device)button.BindingContext;
            Devices.Remove(device);
        }

        private async void OnAddDeviceClicked(object sender, EventArgs e)
        {
            string newDeviceName = await DisplayPromptAsync("Add Device", "Enter device name:");
            if (!string.IsNullOrEmpty(newDeviceName))
            {
                Devices.Add(new Device { Name = newDeviceName, IsEnabled = false });
            }
        }
    }

    public class Device
    {
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
    }
}
