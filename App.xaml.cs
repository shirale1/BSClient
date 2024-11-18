using BSClient.ViewModels;
using BSClient.Views;

namespace BSClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new AppShell();
        }
    }
}