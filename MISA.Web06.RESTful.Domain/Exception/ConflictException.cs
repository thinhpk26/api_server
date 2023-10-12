using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain
{
    /// <summary>
    /// Lỗi xung đột dữ liệu
    /// Created by: Nguyễn Văn Thịnh (10/08/2023)
    /// </summary>
    public class ConflictException : HttpResponseBaseException
    {
        public ConflictException(string userMsg, string devMsg) : base(userMsg, devMsg){ }
    }
}
