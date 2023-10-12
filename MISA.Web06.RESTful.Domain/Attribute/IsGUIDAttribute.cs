using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain.Attribute
{
    /// <summary>
    /// Check có phải là GUID hay không
    /// Created by: Nguyễn Văn Thịnh (07/09/2023)
    /// </summary>
    public class IsGUIDAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            Guid result;
            return Guid.TryParse(value.ToString(), out result);
        }
    }
}
