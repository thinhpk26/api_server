using Dapper;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Math;
using MISA.Web06.RESTful.Application.UnitOfWork;
using MISA.Web06.RESTful.Domain;
using MISA.Web06.RESTful.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace MISA.Web06.RESTful.Infrastructure
{
    public class EmployeeRepository : BaseCrudRepository<Employee, Guid>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Employee?> FindByCodeAsync(string code)
        {
            var sql = $"SELECT * FROM employee WHERE {TableName}Code=@{TableName}Code;";

            var param = new DynamicParameters();
            param.Add($"@{TableName}Code", code);

            var result = await UnitOfWork.Connection.QueryFirstOrDefaultAsync<Employee>(sql, param, transaction: UnitOfWork.Transaction);

            return result;
        }

        public async Task<List<EmployeeModel>> FilterEmployee(string expectedString, int currentPage, int pageSize)
        {
            var offset = (currentPage - 1) * pageSize;
            var limit = pageSize;

            var sql = $"SELECT * FROM Employee LEFT JOIN Department on Employee.DepartmentId = Department.DepartmentId WHERE EmployeeName LIKE @ExpectedString OR EmployeeCode LIKE @ExpectedString ORDER BY CASE WHEN employee.ModifiedDate IS NULL THEN employee.CreatedDate ELSE employee.ModifiedDate END DESC LIMIT @Limit OFFSET @Offset";

            var param = new DynamicParameters();
            param.Add("ExpectedString",  "%" + expectedString + "%");
            param.Add("Limit", limit);
            param.Add("Offset", offset);

            var employees = await UnitOfWork.Connection.QueryAsync<EmployeeModel, DepartmentModel, EmployeeModel>(sql, param: param, map: (employee, department) =>
            {
                employee.Department = department;
                return employee;
            }, splitOn: "departmentId");

            return employees.ToList();
        }

        public async Task<List<EmployeeModel>> FilterEmployee(string expectedString)
        {
            var sql = $"SELECT * FROM Employee LEFT JOIN Department on Employee.DepartmentId = Department.DepartmentId WHERE EmployeeName LIKE @ExpectedString OR EmployeeCode LIKE @ExpectedString ORDER BY CASE WHEN employee.ModifiedDate IS NULL THEN employee.CreatedDate ELSE employee.ModifiedDate END DESC";

            var param = new DynamicParameters();
            param.Add("ExpectedString", "%" + expectedString + "%");

            var employees = await UnitOfWork.Connection.QueryAsync<EmployeeModel, DepartmentModel, EmployeeModel>(sql, param: param, map: (employee, department) =>
            {
                employee.Department = department;
                return employee;
            }, splitOn: "departmentId");

            return employees.ToList();
        }

        public override Query CreateInsertQueryString(Employee employee)
        {
            var insertQuery = QueryHelper.InsertQueryString(employee, TableName);
            return insertQuery;
        }

        public override Query CreateUpdateQueryString(Employee employee)
        {
            var updateQuery = QueryHelper.UpdateQueryString(employee, TableName);
            return updateQuery;
        }

        public async Task<int> GetTotalFilterEmployee(string expectedString)
        {
            var sql = $"SELECT Count(EmployeeId) FROM employee JOIN department on Employee.DepartmentId = Department.DepartmentId WHERE EmployeeName LIKE @ExpectedString OR EmployeeCode LIKE @ExpectedString";

            var param = new DynamicParameters();
            param.Add("ExpectedString", "%" + expectedString + "%");

            var total = await UnitOfWork.Connection.ExecuteScalarAsync<int>(sql, param);

            return total;
        }

        public async Task<EmployeeModel> GetEmployeeWithDepartemt(Employee employee)
        {
            var sql = $"SELECT * FROM Employee JOIN Department on Employee.DepartmentId = Department.DepartmentId WHERE EmployeeId = @EmployeeId";

            var param = new DynamicParameters();
            param.Add("EmployeeId", employee.EmployeeId);

            var employees = await UnitOfWork.Connection.QueryAsync<EmployeeModel, DepartmentModel, EmployeeModel>(sql, param: param, map: (employee, department) =>
            {
                employee.Department = department;
                return employee;
            }, splitOn: "departmentId");

            return employees.ToList()[0];
        }

        public async Task<string> GetNewestCode()
        {
            var sql = $"SELECT EmployeeCode FROM Employee ORDER BY CAST(SUBSTRING(EmployeeCode, 4) AS INT) DESC LIMIT 1";

            var code = await UnitOfWork.Connection.ExecuteScalarAsync<string>(sql);

            return code;
        }
    }
}
