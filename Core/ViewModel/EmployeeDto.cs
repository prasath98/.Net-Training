using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string Manager { get; set; }
        public string Wfmmanager { get; set; }
        public string Email { get; set; }
        public string lockstatus { get; set; }
        public int Experience { get; set; }
        public int Profile_Id{ get; set; }
        public List<string> Skills { get; set; }
    }
}
