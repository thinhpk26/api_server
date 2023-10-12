using Microsoft.Extensions.DependencyInjection;
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
    public class InfrastructureConfig
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddTransient<IUnitOfWork>(option =>
            {
                return new UnitOfWork(connectionString);
            });

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        }
    }
}
