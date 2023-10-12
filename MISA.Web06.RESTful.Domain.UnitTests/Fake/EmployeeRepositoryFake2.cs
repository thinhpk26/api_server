using MISA.Web06.RESTful.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain.UnitTests.Fake
{
    public class EmployeeRepositoryFake2 : IEmployeeRepository
    {
        public int CountCall { get; set; }
        public Task<int> DeleteEntityAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteManyEntityAsync(List<Employee> entities)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeModel> FilterEmployee(string employeeName, int currentPage, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeModel>> FilterEmployee(string expectedString)
        {
            throw new NotImplementedException();
        }

        public Task<Employee?> FindByCodeAsync(string code)
        {
            CountCall++;

            var employee = new Employee();

            return Task.FromResult<Employee?>(employee);
        }

        public Task<Employee?> FindEntityAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeModel> GetEmployeeWithDepartemt(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetManyAsync(List<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalFilterEmployee(string expectedString)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> InsertEntityAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEntityAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        Task<List<EmployeeModel>> IEmployeeRepository.FilterEmployee(string expectedString, int currentPage, int pageSize)
        {
            throw new NotImplementedException();
        }

        Task<(List<Employee>, List<Guid>)> IReadOnlyRepository<Employee, Guid>.GetManyAsync(List<Guid> ids)
        {
            throw new NotImplementedException();
        }
    }
}
