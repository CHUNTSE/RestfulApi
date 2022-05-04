using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeEntity> GetAll();

        void Insert(List<EmployeeEntity> employeeData);

        void Update(List<EmployeeEntity> employeeData);

        void Delete(int employeeId);
    }
}
