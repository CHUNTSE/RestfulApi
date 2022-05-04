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

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeEntity>> GetAll()
        {
            var task = await _employeeRepository.GetAllAsync();

            List<EmployeeEntity> employeeList = task.ToList();

            return employeeList;
        }

        public async Task<EmployeeEntity> GetByEmployeeId(int employeeId)
        {
            var task = _employeeRepository.GetAllAsync();

            EmployeeEntity employeeData = (await task).FirstOrDefault(x => x.EmployeeId == employeeId) ?? new EmployeeEntity();

            return employeeData;
        }

        public void Insert(List<EmployeeEntity> employeeList)
        {
            _employeeRepository.Insert(employeeList);
        }

        public void Update(List<EmployeeEntity> employeeList)
        {
            _employeeRepository.Update(employeeList);
        }

        public void UpdateByEmployeeId(int employeeId, EmployeeEntity employeeData)
        {
            EmployeeEntity specifyEmployeeData = GetByEmployeeId(employeeId).Result;

            if (specifyEmployeeData != null && specifyEmployeeData.EmployeeId == employeeId)
            {
                employeeData.EmployeeId = employeeId;

                List<EmployeeEntity> employeeList = new List<EmployeeEntity>() { employeeData };

                _employeeRepository.Update(employeeList);
            }
        }

        public void Delete(int employeeId)
        {
            _employeeRepository.Delete(employeeId);
        }
    }
}
