using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public class EmployeeConfigEntity
    {
        public int EmployeeId { get; set; }

        public string PassWord { get; set; }

        public bool IsEnable { get; set; }
    }
}
