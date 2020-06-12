using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_LINE.Models
{
    public class UserDATA
    {
        public string USERID { get; set; }
        public string PASSWORD { get; set; }
        public string Name { get; set; }
        public string Jobs { get; set; }
        public double Salary { get; set; }
        public string Gender { get; set; }
        public bool User { get; set; }
        public bool Admin { get; set; }
    }
}