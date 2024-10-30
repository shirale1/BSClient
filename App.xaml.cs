using BSClient.ViewModels;
using BSClient.Views;

namespace BSClient
{
    public partial class App : Application
    {
        public App(LoginPage loginPage)
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(loginPage); 
        }
    }
}
