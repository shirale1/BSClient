using BSClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSClient.Models;
using BSClient.ViewModels;
using BSClient.Views;

namespace BSClient.ViewModels
{
    public class AppShellViewModel:ViewModelBase
    {
        private Users? currentUser;
        private IServiceProvider serviceProvider;
        public AppShellViewModel(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.currentUser = ((App)Application.Current).LoggedInUser;
        }

        private bool isBabySiter;
        public bool IsBabySiter
        {
            get
            {
                Users? u = ((App)Application.Current).LoggedInUser;
                return (u is Babysiter);
            }
        }

        private bool isParent;
        public bool IsParent
        {
            get
            {
                Users? u = ((App)Application.Current).LoggedInUser;
                return (u is Parent);
            }
        }
        private bool isAdmin;
        public bool IsAdmin
        {
            get
            {
                Users? u = ((App)Application.Current).LoggedInUser;
                return (u.IsAdmin);
            }
        }
        public Command LogoutCommand
        {
            get
            {
                return new Command(OnLogout);
            }
        }
        //this method will be trigger upon Logout button click
        public void OnLogout()
        {
            ((App)Application.Current).LoggedInUser = null;

            ((App)Application.Current).MainPage = new NavigationPage(serviceProvider.GetService<LoginPage>());
        }
    }
}
