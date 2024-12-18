using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSClient.Models
{
    public class Babysiter : Users
    {
        public Babysiter() { }

       
        public int Age { get; set; }

        public int ExperienceY { get; set; }

        public bool License { get; set; }

    }
}
