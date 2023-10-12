using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Web06.RESTful.Application;
using MISA.Web06.RESTful.Application.Dto;
using MISA.Web06.RESTful.Application.Service;
using MISA.Web06.RESTful.Controllers;
using MISA.Web06.RESTful.Domain;
using MySqlConnector;
using System;
using System.ComponentModel.DataAnnotations;

namespace MISA.Web06.RESTful
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseCrudController<EmployeeDto, EmployeeInsertDto, EmployeeUpdateDto, Guid>
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Kiểm tra tồn tại employeeCode
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (25/08/2023)
        [HttpGet]
        [Route("exist-code")]
        public async Task<IActionResult> CheckExistCode(string code)
        {
            var result = await _employeeService.IsDuplicateCodeAsync(code);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Lọc tất cả employee theo tên, số lượng, phân trang
        /// </summary>
        /// <param name="employeeFilter"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>FilterDto<EmployeeModelDto></returns>
        /// Created by: Nguyễn Văn Thịnh (27/08/2023)
        [HttpGet]
        [Route("filter")]
        public async Task<IActionResult> FilterEmployee([FromQuery] string? employeeFilter, [FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            if(employeeFilter == null)
            {
                employeeFilter = "";
            }
            var result = await _employeeService.FilterEmployee(employeeFilter, pageNumber, pageSize);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Xuất file excel dựa trên đối tượng đã tìm thấy
        /// </summary>
        /// <param name="expectedString"></param>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (05/09/2023)
        [HttpGet]
        [Route("export-excel")]
        public async Task<IActionResult> ExportExcel([FromQuery] string? expectedString)
        {
            if (expectedString == null)
            {
                expectedString = "";
            }

            var excelData = await _employeeService.ExportExcelWithFilterEmplooyee(expectedString);
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = GlobalLanguage.getEmployee("Excel.NameFile");
            var file =  File(excelData, contentType, fileName);

            return file;
        }

        /// <summary>
        /// Lấy employee với thông tin chi tiếi của department
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>EmployeeModelDto</returns>
        /// Created by: Nguyễn Văn Thịnh (27/08/2023)
        [HttpGet]
        [Route("employees-with-departments/{employeeId}")]
        public async Task<IActionResult> GetEmployeeWithDepartment([FromRoute]Guid employeeId)
        {
            var result = await _employeeService.GetEmployeeWithDepartment(employeeId);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Lấy employeeCode mới
        /// </summary>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (27/08/2023)
        [HttpGet]
        [Route("new-code")]
        public async Task<string> GetNewEmployeeCode()
        {
            var result = await _employeeService.GetNewEmployeeCode();

            return result;
        }
    }
}
