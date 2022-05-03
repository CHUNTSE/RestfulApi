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

        /// <summary>
        /// DB連線字串
        /// </summary>
        public static DB ConnectionStrings { get; set; }
    }

    public class DB
    {
        public string Sql { get; set; }
    }
}
