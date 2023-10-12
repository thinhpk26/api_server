using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain
{
    public class DomainConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IDepartmentManager, DepartmentManager>();
        }
    }
}
