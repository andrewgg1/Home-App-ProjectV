namespace HomeUIWithMAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var userService = new UserService(); // Shared instance of UserService
            MainPage = new NavigationPage(new LoginPage(userService));
        }
    }
}
