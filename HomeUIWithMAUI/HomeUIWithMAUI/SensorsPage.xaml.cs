using Microsoft.Maui.Controls;

namespace HomeUIWithMAUI
{
    public partial class SensorsPage : ContentPage
    {
        public SensorsPage()
        {
            InitializeComponent();
        }

        private void OnSensorToggleClicked(object sender, EventArgs e)
        {
            DisplayAlert("Sensor Status", "The sensor has been toggled.", "OK");
        }
    }
}
