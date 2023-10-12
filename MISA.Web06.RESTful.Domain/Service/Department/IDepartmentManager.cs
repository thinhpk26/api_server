using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain
{
    public interface IDepartmentManager
    {
        /// <summary>
        /// Kiểm tra tồn tại phòng ban
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (10/08/2023)
        Task IsExistDepartment(Guid departmentId);
    }
}
