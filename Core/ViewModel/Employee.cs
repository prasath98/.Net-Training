using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel
{
    public class Employee
    {
        public int Employee_Id { get; set; }
        public string Name { get; set; }
        public string status { get; set; }
        public string Manager { get;set; }
        public string wfm_manager { get; set; }
        public string email { get; set; }
        public string lockstatus { get; set; } 
        public decimal Experience { get; set; }

        public int profile_Id { get; set; }
    }
}
