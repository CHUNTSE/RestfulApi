using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeEntity>> GetAll();

        Task<EmployeeEntity> GetByEmployeeId(int employeeId);

        void Insert(List<EmployeeEntity> employeeList);

        void Update(List<EmployeeEntity> employeeList);

        void UpdateByEmployeeId(int employeeId, EmployeeEntity employeeData);

        void Delete(int employeeId);
    }
}
