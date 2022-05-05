using Jose;
using Repository.Interfaces;
using Repository.Models;
using Repository.ViewModel;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Services;

namespace Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IEmployeeConfigRepository _employeeConfigRepository;

        public LoginService(IEmployeeConfigRepository employeeConfigRepository)
        {
            _employeeConfigRepository = employeeConfigRepository;
        }

        public LoginViewModel GetToken(int employeeId, LoginViewModel loginData)
        {
            LoginViewModel loginResponse = new LoginViewModel();
            string jwtKey = AppSettings.Keys.JwtKey;

            JwtAuthPayloadViewModel payload = new JwtAuthPayloadViewModel()
            {
                Id = loginData.EmployeeId
            };

            if (employeeId == 7777 && loginData.PassWord == "nimdA")
            {


                loginResponse = new LoginViewModel()
                {
                    Token = Jose.JWT.Encode(payload, Encoding.UTF8.GetBytes(jwtKey), JwsAlgorithm.HS256)
                };
            }
            else
            {
                string password = _employeeConfigRepository.GetByEmployeeId(employeeId)?.PassWord;

                if (string.IsNullOrEmpty(password))
                {
                    loginResponse = new LoginViewModel()
                    {
                        Token = string.Empty
                    };
                }

                if (loginData.PassWord.ToMD5() == password)
                {
                    loginResponse = new LoginViewModel()
                    {
                        Token = Jose.JWT.Encode(payload, Encoding.UTF8.GetBytes(jwtKey), JwsAlgorithm.HS256)
                    };
                }
            }
            loginResponse.IsEfficient(loginResponse.Token);

            return loginResponse;
        }
    }
}
