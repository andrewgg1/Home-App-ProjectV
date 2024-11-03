using Microsoft.Maui.Controls;

namespace HomeUIWithMAUI
{
    public partial class CamerasPage : ContentPage
    {
        public CamerasPage()
        {
            InitializeComponent();
        }

        private void OnViewCameraClicked(object sender, EventArgs e)
        {
            DisplayAlert("Camera Feed", "Displaying camera feed.", "OK");
        }
    }
}
