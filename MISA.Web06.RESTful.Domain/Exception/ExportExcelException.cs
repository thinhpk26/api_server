using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain
{
    /// <summary>
    /// Lỗi xuất file excel
    /// </summary>
    /// Created by: Nguyễn Văn Thịnh (07/09/2023)
    public class ExportExcelException : HttpResponseBaseException
    {
        public ExportExcelException(string userMsg, string devMsg) : base(userMsg, devMsg)
        {
        }
    }
}
