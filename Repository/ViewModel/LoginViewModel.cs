using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ViewModel
{
    public class LoginViewModel
    {
        public string EmployeeId { get; set; }

        public string PassWord { get; set; }

        public string Token { get; set; }

        public bool IsEnable { get; private set; }

        /// <summary>
        /// 判斷是否有效
        /// </summary>
        /// <param name="token"></param>
        public void IsEfficient(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                IsEnable = false;
            }
            else
            {
                IsEnable = true;
            }
        }
    }
}
