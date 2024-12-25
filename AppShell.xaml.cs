using BSClient.ViewModels;
using BSClient.Views;

namespace BSClient
{
    public partial class AppShell : Shell
    {
        public AppShell(AppShellViewModel vm)
        {
            this.BindingContext = vm;
            InitializeComponent();

            Routing.RegisterRoute("Login", typeof(LoginPage));
            Routing.RegisterRoute("Register", typeof(Register));
        }
    }
}
