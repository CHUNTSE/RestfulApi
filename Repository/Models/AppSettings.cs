using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public class AppSettings
    {
        public AppSettings(IConfiguration configuration)
        {
            configuration.Bind(this);
        }
    }
}
