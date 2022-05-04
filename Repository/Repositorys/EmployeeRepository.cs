using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Repository.Helper;

namespace Repository.Repositorys
{
    public class EmployeeRepository : DBHelper, IEmployeeRepository
    {
        public async Task<IEnumerable<EmployeeEntity>> GetAllAsync()
        {
            const string sql = @"SELECT * FROM Employee WITH(NOLOCK)";

            return await Sql.GetListAsync<EmployeeEntity>(sql);
        }

        public void Insert(List<EmployeeEntity> employeeList)
        {
            Sql.Insert(employeeList);
        }

        public void Update(List<EmployeeEntity> employeeList)
        {
            Sql.UpdateList(employeeList);
        }

        public void Delete(int employeeId)
        {
            const string sql = @"DELETE Employee WHERE EmployeeId = @EmployeeId";

            Sql.ExecuteSqlInt(sql, new { EmployeeId = employeeId });
        }

    }
}
