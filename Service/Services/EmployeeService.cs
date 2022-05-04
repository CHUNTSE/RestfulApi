using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public List<EmployeeEntity> GetAll()
        {
            Task<IEnumerable<EmployeeEntity>> task = _employeeRepository.GetAll();

            List<EmployeeEntity> employeeList = task.Result.ToList();

            return employeeList;
        }

        public void Insert(List<EmployeeEntity> employeeData)
        {
            _employeeRepository.Insert(employeeData);
        }

        public void Update(List<EmployeeEntity> employeeData)
        {
            _employeeRepository.Update(employeeData);
        }

        public void Delete(int employeeId)
        {
            _employeeRepository.Delete(employeeId);
        }
    }
}
