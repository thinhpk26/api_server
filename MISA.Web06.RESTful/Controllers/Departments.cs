using Microsoft.AspNetCore.Mvc;
using MISA.Web06.RESTful.Application;

namespace MISA.Web06.RESTful.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Departments : BaseReadOnlyController<DepartmentDto, Guid>
    {
        private readonly IDepartmentService _departmentService;
        public Departments(IDepartmentService departmentService) : base(departmentService)
        {
            _departmentService = departmentService;
        }
    }
}
