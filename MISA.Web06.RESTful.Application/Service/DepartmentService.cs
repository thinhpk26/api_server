using AutoMapper;
using MISA.Web06.RESTful.Application.Service.Base;
using MISA.Web06.RESTful.Application.UnitOfWork;
using MISA.Web06.RESTful.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Application.Service
{
    public class DepartmentService : BaseReadOnlyService<Department, DepartmentDto, Guid>, IDepartmentService
    {
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepository repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }

        public override DepartmentDto MapEntityToEntityDto(Department department)
        {
            var departmentDto = _mapper.Map<DepartmentDto>(department);

            return departmentDto;
        }
    }
}
