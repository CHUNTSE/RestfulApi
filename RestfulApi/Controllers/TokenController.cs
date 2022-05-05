using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.ViewModel;
using Service.Interfaces;

namespace RestfulApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public TokenController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("{employeeId:int}")]
        public LoginViewModel ProduceToken(int employeeId, [FromBody] LoginViewModel loginData)
        {
            return _loginService.GetToken(employeeId, loginData);
        }
    }
}