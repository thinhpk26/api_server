using MISA.Web06.RESTful.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain
{
    public interface IEmployeeRepository : ICrudRepository<Employee, Guid>
    {
        /// <summary>
        /// Hàm tìm nhân viên theo mã nhân viên
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <returns>Nhân viên or null</returns>
        /// Created by: Nguyễn Văn Thịnh (15/08/2023)
        Task<Employee?> FindByCodeAsync(string code);

        /// <summary>
        /// Hàm lọc nhân viên theo pageSize, currentPage, employeeName và employeeCode
        /// </summary>
        /// <param name="expectedString"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns>EmployeeModel</returns>
        /// Created by: Nguyễn Văn Thịnh (23/08/2023)
        Task<List<EmployeeModel>> FilterEmployee(string expectedString, int currentPage, int pageSize);

        /// <summary>
        /// Hàm lọc nhân viên theo employeeName và employeeCode
        /// </summary>
        /// <param name="expectedString"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns>EmployeeModel</returns>
        /// Created by: Nguyễn Văn Thịnh (23/08/2023)
        Task<List<EmployeeModel>> FilterEmployee(string expectedString);


        /// <summary>
        /// Hàm lấy tổng số bản ghi khi lọc
        /// </summary>
        /// <param name="expectedString"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (25/08/2023)
        Task<int> GetTotalFilterEmployee(string expectedString);

        /// <summary>
        /// Hàm lấy nhân viên bao gồm thông tin phòng ban
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (26/08/2023)
        Task<EmployeeModel> GetEmployeeWithDepartemt(Employee employee);

        /// <summary>
        /// Hàm lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (10/09/2023)
        Task<string> GetNewestCode();
    }
}
