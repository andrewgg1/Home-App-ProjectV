using Microsoft.Maui.Controls;

namespace HomeUIWithMAUI
{
    public partial class AlarmsPage : ContentPage
    {
        private bool isFireSmokeDetectorOn = false;
        private bool isCODetectorOn = false;
        private bool isGarageAlarmOn = false;
        private bool isMainHouseAlarmOn = false;
        private bool isPanicButtonOn = false;
        private bool isFloodWaterAlarmOn = false;

        public AlarmsPage()
        {
            InitializeComponent();
        }

        private void OnFireSmokeDetectorToggleClicked(object sender, EventArgs e)
        {
            isFireSmokeDetectorOn = !isFireSmokeDetectorOn;
            FireSmokeDetectorStatus.Text = "Status: " + (isFireSmokeDetectorOn ? "On" : "Off");
        }

        private void OnCODetectorToggleClicked(object sender, EventArgs e)
        {
            isCODetectorOn = !isCODetectorOn;
            CODetectorStatus.Text = "Status: " + (isCODetectorOn ? "On" : "Off");
        }

        private void OnGarageAlarmToggleClicked(object sender, EventArgs e)
        {
            isGarageAlarmOn = !isGarageAlarmOn;
            GarageAlarmStatus.Text = "Status: " + (isGarageAlarmOn ? "On" : "Off");
        }

        private void OnMainHouseAlarmToggleClicked(object sender, EventArgs e)
        {
            isMainHouseAlarmOn = !isMainHouseAlarmOn;
            MainHouseAlarmStatus.Text = "Status: " + (isMainHouseAlarmOn ? "On" : "Off");
        }

        private void OnPanicButtonToggleClicked(object sender, EventArgs e)
        {
            isPanicButtonOn = !isPanicButtonOn;
            PanicButtonStatus.Text = "Status: " + (isPanicButtonOn ? "On" : "Off");
        }

        private void OnFloodWaterAlarmToggleClicked(object sender, EventArgs e)
        {
            isFloodWaterAlarmOn = !isFloodWaterAlarmOn;
            FloodWaterAlarmStatus.Text = "Status: " + (isFloodWaterAlarmOn ? "On" : "Off");
        }
    }
}
