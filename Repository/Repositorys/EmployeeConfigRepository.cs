using Repository.Helper;
using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositorys
{
    public class EmployeeConfigRepository : DBHelper, IEmployeeConfigRepository
    {
        public EmployeeConfigEntity GetByEmployeeId(int employeeId)
        {
            return Sql.GetById<EmployeeConfigEntity>(employeeId);
        }
    }

}
