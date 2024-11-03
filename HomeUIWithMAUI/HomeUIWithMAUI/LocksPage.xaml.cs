using Microsoft.Maui.Controls;

namespace HomeUIWithMAUI
{
    public partial class LocksPage : ContentPage
    {
        public LocksPage()
        {
            InitializeComponent();
        }

        private void OnLockUnlockClicked(object sender, EventArgs e)
        {
            DisplayAlert("Lock Status", "The lock state has been toggled.", "OK");
        }
    }
}
