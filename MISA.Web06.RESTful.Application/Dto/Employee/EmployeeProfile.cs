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
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeInsertDto, Employee>()
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday.Value.ToUniversalTime().UtcDateTime))
                .ForMember(dest => dest.PersonalIdDate, opt => opt.MapFrom(src => src.PersonalIdDate.Value.ToUniversalTime().UtcDateTime))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => ""))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<EmployeeUpdateDto, Employee>()
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday.Value.ToUniversalTime().UtcDateTime))
                .ForMember(dest => dest.PersonalIdDate, opt => opt.MapFrom(src => src.PersonalIdDate.Value.ToUniversalTime().UtcDateTime))
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.ModifiedBy, opt => opt.MapFrom(src => ""));

            CreateMap<EmployeeModel, EmployeeModelDto>()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department));
        }
    }
}
