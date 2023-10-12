using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain
{
    /// <summary>
    /// Không tìm thấy dữ liệu
    /// </summary>
    /// Created by: Nguyễn Văn Thịnh (15/08/2023)
    public class NotFoundException : HttpResponseBaseException
    {
        /// <summary>
        /// Khởi tạo đối tượng
        /// </summary>
        /// <param name="userMsg">Thông báo đến khách hàng</param>
        /// <param name="devMsg">Thông báo đến nhà phát triển</param>
        public NotFoundException(string userMsg, string devMsg) : base(userMsg, devMsg) { }
    }
}
