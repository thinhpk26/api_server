using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task CheckDuplicateCode(string code)
        {
            var entityExist = await _employeeRepository.FindByCodeAsync(code);

            if (entityExist != null)
            {
                var userMsg = GlobalLanguage.getException("EmployeeCode") + $" <{code}>";
                var devMsg = GlobalLanguage.getException("EmployeeCode") + $" <{code}>";

                throw new ConflictException(userMsg, devMsg);
            }
        }

        public async Task IsExistEmployee(Guid employeeId)
        {
            var entityExist = await _employeeRepository.FindEntityAsync(employeeId);

            if (entityExist == null)
            {
                var userMsg = GlobalLanguage.getException("EmployeeId") + $" <{employeeId}>";
                var devMsg = GlobalLanguage.getException("EmployeeId") + $" <{employeeId}>";

                throw new ConflictException(userMsg, devMsg);
            }
        }
    }
}
