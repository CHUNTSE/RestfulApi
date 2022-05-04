using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Enums;

namespace Repository.Models
{
    public class EmployeeEntity
    {
        /// <summary>
        /// 員工ID
        /// </summary>
        [Key]
        public string EmployeeId { get; set; }

        /// <summary>
        /// 名
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 姓
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public GenderEnum Gender { get; set; }

        /// <summary>
        /// 職位
        /// </summary>
        public PositionEnum Position { get; set; }

        /// <summary>
        /// 入質時間
        /// </summary>
        public DateTime EntryTime { get; set; }

        /// <summary>
        /// 離職時間
        /// </summary>
        public DateTime ResignationTime { get; set; }

        /// <summary>
        /// 薪水
        /// </summary>
        public int Salary { get; set; }
    }
}
