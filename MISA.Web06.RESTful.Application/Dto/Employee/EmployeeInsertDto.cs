using MISA.Web06.RESTful.Domain;
using MISA.Web06.RESTful.Domain.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Application
{
    public class EmployeeInsertDto
    {
        #region Properties
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [RegularExpression(@"\S{1,20}", ErrorMessage = "Mã nhân viên không được phép để trống và tối đa 20 ký tự")]
        [Required(ErrorMessage = "Mã nhân viên không được phép để trống")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        [MinLength(1, ErrorMessage = "Tên nhân viên không được phép để trống")]
        [MaxLength(100, ErrorMessage = "Tên nhân viên không được vượt quá 100 ký tự")]
        [Required(ErrorMessage = "Tên nhân viên không được phép để trống")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        [MaxLength(100, ErrorMessage = "Địa chỉ không được phép dài hơn 100 ký tự")]
        public string? Address { get; set; }

        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        [RegularExpression("^[0-9]{7,50}$", ErrorMessage = "Số điện thoại di động không đúng định dạng")]
        public string? Mobiphone { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        [RegularExpression("^[0-9]{7,50}$", ErrorMessage = "Số điện thoại cố định không đúng định dạng")]
        public string? Standlinephone { get; set; }

        /// <summary>
        /// id của phòng ban
        /// </summary>
        [Required(ErrorMessage = "Id phòng ban là bắt buộc")]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// id vị trí
        /// </summary>
        public Guid? PositionId { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        [DateLessThanNow(ErrorMessage = "Ngày sinh phải nhỏ hơn ngày hiện tại")]
        public DateTimeOffset? Birthday { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        [Range(0, 2, ErrorMessage = "Giới tính không chính xác")]
        public Gender? Gender { get; set; }

        /// <summary>
        /// căn cước công dân
        /// </summary>
        [RegularExpression(@"^\d+$", ErrorMessage = "Chứng minh thư nhân dân chỉ bao gồm số")]
        [MaxLength(20, ErrorMessage = "Chứng minh thư nhân dân không được phép lớn hơn 20 ký tự")]
        public string? PersonalId { get; set; }

        /// <summary>
        /// Ngày cấp căn cước
        /// </summary>
        [DateLessThanNow(ErrorMessage = "Ngày nhận chứng minh thư phải nhỏ hơn ngày hiện tại")]
        public DateTimeOffset? PersonalIdDate { get; set; }

        /// <summary>
        /// Nơi cấp
        /// </summary>
        [MaxLength(100, ErrorMessage = "Địa chỉ không dài hơn 100 ký tự")]
        public string? PersonalIdAddress { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Trường bạn nhập không phải email")]
        public string? Email { get; set; }

        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        [MaxLength(50, ErrorMessage = "Tài khoản ngân hàng không được lớn hơn 50 ký tự")]
        public string? BankAccount { get; set; }

        /// <summary>
        /// Tên tài khoản
        /// </summary>
        [MaxLength(100, ErrorMessage = "Tên ngân hàng không được lớn hơn 100 ký tự")]
        public string? BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        [MaxLength(100, ErrorMessage = "Địa chỉ không được lớn hơn 100 ký tự")]
        public string? BankAddress { get; set; } 
        #endregion
    }
}
