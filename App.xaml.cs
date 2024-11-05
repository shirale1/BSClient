using BSClient.ViewModels;
using BSClient.Views;

namespace BSClient
{
    public partial class App : Application
    {
        public App(RegisterPageViewModel Register)
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new Register(Register); 
        }
    }
}
