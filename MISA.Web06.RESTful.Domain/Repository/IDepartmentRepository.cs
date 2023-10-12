using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain
{
    public interface IDepartmentRepository : IReadOnlyRepository<Department, Guid>
    {

    }
}
