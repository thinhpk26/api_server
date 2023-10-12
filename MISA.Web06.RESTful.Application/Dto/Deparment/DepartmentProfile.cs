using AutoMapper;
using MISA.Web06.RESTful.Application.Dto;
using MISA.Web06.RESTful.Domain;
using MISA.Web06.RESTful.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Application
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentModel, DepartmentModelDto>().ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees));
        }
    }
}
