using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain
{
    /// <summary>
    /// Quản lý truy vấn dữ liệu
    /// </summary>
    public abstract class BaseAuditEntity
    {
        #region Properties
        /// <summary>
        /// Người tạo
        /// </summary>
        [CreatedProperty]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        [CreatedProperty]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Người thay đổi
        /// </summary>
        [ModifiedProperty]
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// Ngày thay đổi
        /// </summary>
        [ModifiedProperty]
        public DateTime? ModifiedDate { get; set; } 
        #endregion
    }
}
