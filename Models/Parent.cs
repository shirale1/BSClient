using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSClient.Models
{
    public class Parent:Users
    {
        public Parent() { }
        public int KidsN { get; set; }

        public bool Pets { get; set; }

    }
}
