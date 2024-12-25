using BSClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSClient.ViewModels
{
    public class AppShellViewModel:ViewModelBase
    {
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

    }
}
