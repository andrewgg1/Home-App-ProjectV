using Microsoft.Maui.Controls;

namespace HomeUIWithMAUI
{
    public partial class AlarmsPage : ContentPage
    {
        public AlarmsPage()
        {
            InitializeComponent();
        }

        private void OnTestAlarmClicked(object sender, EventArgs e)
        {
            DisplayAlert("Alarm Test", "The alarm has been triggered for testing.", "OK");
        }
    }
}
