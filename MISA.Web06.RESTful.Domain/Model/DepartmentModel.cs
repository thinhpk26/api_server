using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain.Model
{
    public class DepartmentModel : BaseAuditModel
    {
        #region Properties
        /// <summary>
        /// id của phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Mô tả phòng ban
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Tên của phòng ban
        /// </summary>
        public string? DepartmentName { get; set; }

        /// <summary>
        /// Các nhân viên trong phòng ban
        /// </summary>
        public ICollection<EmployeeModel> Employees { get; set; } 
        #endregion
    }
}
