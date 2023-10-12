using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentManager(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task IsExistDepartment(Guid departmentId)
        {
            var department = await _departmentRepository.FindEntityAsync(departmentId);

            if (department == null)
            {
                var userMesg = GlobalLanguage.getException("ID") + $" <{departmentId}>";
                var devMsg = GlobalLanguage.getException("ID") + $" <{departmentId}>";
                throw new NotFoundException(userMesg, devMsg);
            }
        }
    }
}
