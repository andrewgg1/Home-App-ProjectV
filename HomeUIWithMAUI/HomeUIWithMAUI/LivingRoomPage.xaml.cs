namespace HomeUIWithMAUI
{
    public partial class LivingRoomPage : ContentPage
    {
        public LivingRoomPage()
        {
            InitializeComponent();
        }

        private void OnToggleLivingRoomLightClicked(object sender, EventArgs e)
        {
            LivingRoomLightSwitch.IsToggled = !LivingRoomLightSwitch.IsToggled;
        }

        private void OnToggleLivingRoomFanClicked(object sender, EventArgs e)
        {
            LivingRoomFanSwitch.IsToggled = !LivingRoomFanSwitch.IsToggled;
        }
    }
}
