using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IEmployeeConfigRepository
    {
        EmployeeConfigEntity GetByEmployeeId(int employeeId);
    }
}
