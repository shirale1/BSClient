using BSClient.Models;
using BSClient.ViewModels;
using BSClient.Views;

namespace BSClient
{
    public partial class App : Application
    {
        Users? LoggedInUser { get; set; }
        public App(IServiceProvider serviceProvider)
        {
            LoggedInUser = null;
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(serviceProvider.GetService<LoginPage>());
        }
    }
}