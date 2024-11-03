using Microsoft.Maui.Controls;
using HomeUIWithMAUI.ViewModels;

namespace HomeUIWithMAUI
{
    public partial class DeviceHubPage : ContentPage
    {
        public DeviceHubPage()
        {
            InitializeComponent();
            BindingContext = new DeviceHubViewModel();
        }
    }
}
