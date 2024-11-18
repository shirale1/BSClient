using BSClient.ViewModels;
using BSClient.Views;

namespace BSClient
{
    public partial class App : Application
    {
        public App(LoginPageViewModel login)
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new LoginPage(login);
        }
    }
}