using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Enums;

namespace Repository.Helper
{
    public class DBHelper
    {
        public static DapperHelper Sql
        {
            get
            {
                return GetDB(DatabaseTypeEnum.Sql, AppSettings.ConnectionStrings.Sql);
            }
        }
        public static DapperHelper GetDB(DatabaseTypeEnum Type, string Connection)
        {
            DapperHelper dapperHelper = new DapperHelper(Type, Connection);

            return dapperHelper;
        }
    }
}
