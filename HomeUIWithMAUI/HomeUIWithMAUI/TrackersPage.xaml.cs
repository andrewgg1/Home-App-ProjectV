using Microsoft.Maui.Controls;

namespace HomeUIWithMAUI
{
    public partial class TrackersPage : ContentPage
    {
        public TrackersPage()
        {
            InitializeComponent();
        }

        private void OnLocateTrackerClicked(object sender, EventArgs e)
        {
            DisplayAlert("Tracker Location", "The location of the tracker is being displayed.", "OK");
        }
    }
}
