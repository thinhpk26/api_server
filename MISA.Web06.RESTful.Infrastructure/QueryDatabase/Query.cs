using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Infrastructure
{
    /// <summary>
    /// Model cho các câu lệnh truy vấn
    /// Created by: Nguyễn Văn Thịnh (23/08/2023)
    /// </summary>
    public class Query
    {
        public string Sql { get; set; }

        public DynamicParameters Param { get; set; }
    }
}
