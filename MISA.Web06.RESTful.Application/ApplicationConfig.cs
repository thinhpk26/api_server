using Microsoft.Extensions.DependencyInjection;
using MISA.Web06.RESTful.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Application
{
    public class ApplicationConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
        }
    }
}
