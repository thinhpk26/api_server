using MISA.Web06.RESTful.Application.Dto;
using MISA.Web06.RESTful.Domain;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Application
{
    public interface IEmployeeService : ICrudService<EmployeeDto, EmployeeInsertDto, EmployeeUpdateDto, Guid>
    {
        /// <summary>
        /// Kiểm tra employeeCode có tồn tại chưa
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (25/08/2023)
        Task<bool> IsDuplicateCodeAsync(string code);

        /// <summary>
        /// Lọc employee theo điều kiện
        /// </summary>
        /// <param name="expectedString"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <returns>EmployeeModelDto</returns>
        /// Created by: Nguyễn Văn Thịnh (25/08/2023)
        Task<FilterDto<EmployeeModelDto>> FilterEmployee(string expectedString, int currentPage, int pageSize);

        /// <summary>
        /// Xuất file excel theo điều kiện tìm kiếm theo chuỗi
        /// </summary>
        /// <param name="expectedString"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (07/09/2023)
        Task<Byte[]?> ExportExcelWithFilterEmplooyee(string expectedString);

        /// <summary>
        /// Lấy thông tin employee bao gồm department theo id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (26/08/2023)
        Task<EmployeeModelDto> GetEmployeeWithDepartment(Guid employeeId);

        /// <summary>
        /// Tạo ra một chuỗi code ngẫu nhiên 
        /// </summary>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (25/08/2023)
        Task<string> GetNewEmployeeCode();
    }
}
