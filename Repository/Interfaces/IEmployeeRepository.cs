using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeEntity>> GetAllAsync();

        void Insert(List<EmployeeEntity> employeeData);

        void Update(List<EmployeeEntity> employeeData);

        void Delete(int employeeId);
    }
}
