using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Application
{
    public interface IDepartmentService :IReadOnlyService<DepartmentDto, Guid>
    {
    }
}
