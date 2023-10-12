using MISA.Web06.RESTful.Application.UnitOfWork;
using MISA.Web06.RESTful.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Infrastructure
{
    public class DepartmentRepository : BaseReadOnlyRepository<Department, Guid>, IDepartmentRepository
    {
        public DepartmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
