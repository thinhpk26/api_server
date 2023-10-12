using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain
{
    public interface IEmployeeManager
    {
        /// <summary>
        /// Kiểm tra trùng mã
        /// </summary>
        /// <param name="code">mã</param>
        /// <returns>Nếu trùng mã return exception</returns>
        /// Created by: Nguyễn Văn Thịnh (10/08/2023)
        Task CheckDuplicateCode(string code);

        /// <summary>
        /// Kiểm tra đã tồn tại employee
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (10/08/2023)
        Task IsExistEmployee(Guid empployeeId);
    }
}
