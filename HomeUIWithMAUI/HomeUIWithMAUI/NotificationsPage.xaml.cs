using System;
using System.Collections.ObjectModel;

namespace HomeUIWithMAUI
{
    public partial class NotificationsPage : ContentPage
    {
        public ObservableCollection<Notification> Notifications { get; set; }

        public NotificationsPage()
        {
            InitializeComponent();
            Notifications = new ObservableCollection<Notification>();
            NotificationsListView.ItemsSource = Notifications;
        }

        private void OnGenerateNotificationClicked(object sender, EventArgs e)
        {
            // Generate a sample notification
            var notification = new Notification
            {
                Message = "New Alert: High energy consumption detected!",
                Timestamp = DateTime.Now.ToString("g")  // Display timestamp in a readable format
            };

            Notifications.Add(notification);
        }
    }

    public class Notification
    {
        public string Message { get; set; }
        public string Timestamp { get; set; }
    }
}
