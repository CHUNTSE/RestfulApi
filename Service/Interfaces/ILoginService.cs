using Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface ILoginService
    {
        LoginViewModel GetToken(int employeeId, LoginViewModel loginData);
    }
}
