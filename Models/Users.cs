using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSClient.Models
{
    public class Users
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string UserType { get; set; } = null!;

        public bool IsManager { get; set; }

        //public virtual List<UserTask> UserTasks { get; set; } = new List<UserTask>();

        public AppUser() { }
    }
}
