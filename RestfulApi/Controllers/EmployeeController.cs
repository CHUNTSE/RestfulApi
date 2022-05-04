using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service.Interfaces;

namespace RestfulApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeEntity>>> GetAsync()
        {
            return await _employeeService.GetAll();
        }

        [HttpGet("{employeeId:int}")]
        public async Task<ActionResult<EmployeeEntity>> GetByEmployeeIdAsync(int employeeId)
        {
            return await _employeeService.GetByEmployeeId(employeeId);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] List<EmployeeEntity> employeeList)
        {
            _employeeService.Update(employeeList);
        }

        [HttpPut("{employeeId:int}")]
        public void Put(int employeeId, [FromBody] EmployeeEntity employeeData)
        {
            _employeeService.UpdateByEmployeeId(employeeId, employeeData);
        }

        [HttpDelete("{employeeId:int}")]
        public void Delete(int employeeId)
        {
            _employeeService.Delete(employeeId);
        }
    }
}