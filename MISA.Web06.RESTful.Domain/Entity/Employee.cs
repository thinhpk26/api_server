using MISA.Web06.RESTful.Domain;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace MISA.Web06.RESTful.Domain
{
    public class Employee : BaseAuditEntity, IEntity<Guid>
    {
        #region Properties

        /// <summary>
        /// id nhân viên
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>ký tự")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        public string? Mobiphone { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        public string? Standlinephone { get; set; }

        /// <summary>
        /// id của phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// id vị trí
        /// </summary>
        public Guid? PositionId { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// căn cước công dân
        /// </summary>
        public string? PersonalId { get; set; }

        /// <summary>
        /// Ngày cấp căn cước
        /// </summary>
        public DateTime? PersonalIdDate { get; set; }

        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string? PersonalIdAddress { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        public string? BankAccount { get; set; }

        /// <summary>
        /// Tên tài khoản
        /// </summary>
        public string? BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        public string? BankAddress { get; set; }

        #endregion

        #region Methods

        public Guid GetId()
        {
            return EmployeeId;
        }

        public bool isEqualId(Guid id)
        {
            return EmployeeId.Equals(id);
        }

        public void SetId(Guid id)
        {
            EmployeeId = id;
        }

        #endregion

    }
}
