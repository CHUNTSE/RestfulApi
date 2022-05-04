using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Enums;

namespace Repository.Helper
{
    public class DapperHelper
    {
        private static readonly int commandTimeout = 30;

        private IDbConnection _sharedConnection;

        public DapperHelper(DatabaseTypeEnum dbType, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ApplicationException(string.Format("DB Nmae={0}，查無連線字串!", connectionString));
            }

            switch (dbType)
            {
                case DatabaseTypeEnum.Sql:
                    this._sharedConnection = new SqlConnection(connectionString);
                    break;
            }
        }

        /// <summary>
        ///  執行sql返回一個對象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public T Get<T>(string sql, object param = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
            {
                using (IDbConnection conn = _sharedConnection)
                {
                    conn.Open();

                    return conn.QueryFirstOrDefault<T>(sql, param, commandTimeout: commandTimeout);
                }
            }
            else
            {
                var conn = transaction.Connection;

                return conn.QueryFirstOrDefault<T>(sql, param, commandTimeout: commandTimeout, transaction: transaction);
            }

        }

        /// <summary>
        /// 執行sql返回多個對象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="useWriteConn"></param>
        /// <returns></returns>
        public IEnumerable<T> GetList<T>(string sql, object param = null, bool useWriteConn = false, IDbTransaction transaction = null)
        {
            using (IDbConnection conn = _sharedConnection)
            {
                conn.Open();

                return conn.Query<T>(sql, param, commandTimeout: commandTimeout, transaction: transaction).ToList();
            }
        }

        /// <summary>
        /// 執行sql返回一個對象--異步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="useWriteConn"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string sql, object param = null, bool useWriteConn = false)
        {
            using (IDbConnection conn = _sharedConnection)
            {
                conn.Open();

                return await conn.QueryFirstOrDefaultAsync<T>(sql, param, commandTimeout: commandTimeout).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// 執行sql返回多個對象--異步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="useWriteConn"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetListAsync<T>(string sql, object param = null, bool useWriteConn = false)
        {
            using (IDbConnection conn = _sharedConnection)
            {
                conn.Open();

                var list = await conn.QueryAsync<T>(sql, param, commandTimeout: commandTimeout).ConfigureAwait(false);

                return list.ToList();
            }
        }

        /// <summary>
        /// 執行sql，返回影響行數 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int ExecuteSqlInt(string sql, object param = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
            {
                using (IDbConnection conn = _sharedConnection)
                {
                    conn.Open();

                    return conn.Execute(sql, param, commandTimeout: commandTimeout, commandType: CommandType.Text);
                }
            }
            else
            {
                var conn = transaction.Connection;

                return conn.Execute(sql, param, transaction: transaction, commandTimeout: commandTimeout, commandType: CommandType.Text);
            }
        }

        /// <summary>
        /// 執行sql，返回影響行數--異步
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<int> InsertAsync(string sql, object param = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
            {
                using (IDbConnection conn = _sharedConnection)
                {
                    conn.Open();

                    return await conn.ExecuteAsync(sql, param, commandTimeout: commandTimeout, commandType: CommandType.Text).ConfigureAwait(false);
                }
            }
            else
            {
                var conn = transaction.Connection;

                return await conn.ExecuteAsync(sql, param, transaction: transaction, commandTimeout: commandTimeout, commandType: CommandType.Text).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// 根據id獲取實體
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <param name="useWriteConn"></param>
        /// <returns></returns>
        public T GetById<T>(int id, IDbTransaction transaction = null, bool useWriteConn = false) where T : class
        {
            if (transaction == null)
            {
                using (IDbConnection conn = _sharedConnection)
                {
                    conn.Open();

                    return conn.Get<T>(id, commandTimeout: commandTimeout);
                }
            }
            else
            {
                var conn = transaction.Connection;

                return conn.Get<T>(id, transaction: transaction, commandTimeout: commandTimeout);
            }
        }
        /// <summary>
        /// 根據id獲取實體--異步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync<T>(int id, IDbTransaction transaction = null) where T : class
        {
            if (transaction == null)
            {
                using (IDbConnection conn = _sharedConnection)
                {
                    conn.Open();

                    return await conn.GetAsync<T>(id, commandTimeout: commandTimeout);
                }
            }
            else
            {
                var conn = transaction.Connection;

                return await conn.GetAsync<T>(id, transaction: transaction, commandTimeout: commandTimeout);
            }
        }

        /// <summary>
        /// 插入實體
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int Insert<T>(T item, IDbTransaction transaction = null) where T : class
        {
            if (transaction == null)
            {
                using (IDbConnection conn = _sharedConnection)
                {
                    conn.Open();

                    return (int)conn.Insert<T>(item, commandTimeout: commandTimeout);
                }
            }
            else
            {
                var conn = transaction.Connection;

                return (int)conn.Insert(item, transaction: transaction, commandTimeout: commandTimeout);
            }
        }

        /// <summary>
        /// 批量插入實體
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="transaction"></param>
        public int InsertList<T>(IEnumerable<T> list, IDbTransaction transaction = null) where T : class
        {
            if (transaction == null)
            {
                using (IDbConnection conn = _sharedConnection)
                {
                    conn.Open();

                    return (int)conn.Insert(list, commandTimeout: commandTimeout);
                }
            }
            else
            {
                var conn = transaction.Connection;

                return (int)conn.Insert(list, transaction: transaction, commandTimeout: commandTimeout);
            }
        }

        /// <summary>
        /// 更新單個實體
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Update<T>(T item, IDbTransaction transaction = null) where T : class
        {
            if (transaction == null)
            {
                using (IDbConnection conn = _sharedConnection)
                {
                    conn.Open();

                    return conn.Update(item, commandTimeout: commandTimeout);
                }
            }
            else
            {
                var conn = transaction.Connection;

                return conn.Update(item, transaction: transaction, commandTimeout: commandTimeout);
            }
        }

        /// <summary>
        /// 批量更新實體
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool UpdateList<T>(List<T> item, IDbTransaction transaction = null) where T : class
        {
            if (transaction == null)
            {
                using (IDbConnection conn = _sharedConnection)
                {
                    conn.Open();

                    return conn.Update(item, commandTimeout: commandTimeout);
                }
            }
            else
            {
                var conn = transaction.Connection;

                return conn.Update(item, transaction: transaction, commandTimeout: commandTimeout);
            }
        }
    }
}
