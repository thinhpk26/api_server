using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain
{
    /// <summary>
    /// Kiểm tra ngày có nhỏ hơn ngày hiện tại hay không
    /// </summary>
    /// Created by: Nguyễn Văn Thịnh (16/08/2023)
    public class DateLessThanNowAttribute : ValidationAttribute
    {
        /// <summary>
        /// Kiểm tra ngày hiện tại
        /// </summary>
        /// <param name="value">Giá trị ngày</param>
        /// <returns>True: nhỏ hơn - false: lớn hơn hoặc bằng</returns>
        /// Created by: Nguyễn Văn Thịnh (16/08/2023)
        public override bool IsValid(object value)
        {
            if(value == null)
            {
                return true;
            }
            if(value is DateTimeOffset dateOffset)
            {
                return dateOffset < DateTimeOffset.Now;
            }
            if(value is DateTime date)
            {
                return date < DateTime.Now;
            }
            return false;
        }
    }
}
