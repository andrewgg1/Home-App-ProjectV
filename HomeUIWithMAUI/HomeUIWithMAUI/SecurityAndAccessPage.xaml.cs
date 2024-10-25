using System;
using System.Collections.ObjectModel;

namespace HomeUIWithMAUI
{
    public partial class SecurityAndAccessPage : ContentPage
    {
        public ObservableCollection<User> Users { get; set; }

        public SecurityAndAccessPage()
        {
            InitializeComponent();
            Users = new ObservableCollection<User>
            {
                new User { Name = "Ethan", Role = "Admin" },
                new User { Name = "Mayank", Role = "Guest" }
            };
            UserListView.ItemsSource = Users;
        }

        private void OnRemoveUserClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var user = (User)button.BindingContext;
            Users.Remove(user);
        }

        private async void OnAddUserClicked(object sender, EventArgs e)
        {
            string userName = await DisplayPromptAsync("Add User", "Enter the user's name:");
            if (!string.IsNullOrEmpty(userName))
            {
                string role = await DisplayActionSheet("Select Role", "Cancel", null, "Admin", "Guest");
                if (role != "Cancel")
                {
                    Users.Add(new User { Name = userName, Role = role });
                }
            }
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
