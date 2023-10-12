using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml.Office;
using MISA.Web06.RESTful.Application.Dto;
using MISA.Web06.RESTful.Application.UnitOfWork;
using MISA.Web06.RESTful.Domain;
using MISA.Web06.RESTful.Domain.Model;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Application.Service
{
    public class EmployeeService : BaseCrudService<Employee, EmployeeDto, EmployeeInsertDto, EmployeeUpdateDto, Guid>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IEmployeeManager _employeeManager;
        private readonly IDepartmentManager _departmentManager;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IEmployeeManager employeeManager, IDepartmentManager departmentManager) : base(repository, unitOfWork)
        {
            _employeeRepository = repository;
            _mapper = mapper;
            _employeeManager = employeeManager;
            _departmentManager = departmentManager;
        }

        public async Task<bool> IsDuplicateCodeAsync(string code)
        {
            var employee = await _employeeRepository.FindByCodeAsync(code);

            if(employee == null)
            {
                return false;
            }
            return true;
        }

        public async Task<FilterDto<EmployeeModelDto>> FilterEmployee(string expectedString, int currentPage, int pageSize)
        {
            var employees = await _employeeRepository.FilterEmployee(expectedString, currentPage, pageSize);

            var totalRecord = await _employeeRepository.GetTotalFilterEmployee(expectedString);

            var employeeModelDtos = employees.Select(employee => MapEmployeeModelToEmployeeModelDto(employee)).ToList();

            var filterDto = new FilterDto<EmployeeModelDto>()
            {
                TotalRecord = totalRecord,
                Data = employeeModelDtos,
            };

            return filterDto;
        }

        public async Task<Byte[]?> ExportExcelWithFilterEmplooyee(string expectedString)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var employeeList = await _employeeRepository.FilterEmployee(expectedString);

                var workSheet = package.Workbook.Worksheets.Add(GlobalLanguage.getEmployee("Excel.NameSheet"));

                int row = 1;

                // Đặt độ rộng cho các cột
                workSheet.Column(1).Width = 4;
                workSheet.Column(2).Width = 15;
                workSheet.Column(3).Width = 30;
                workSheet.Column(4).Width = 10;
                workSheet.Column(5).Width = 15;
                workSheet.Column(6).Width = 20;
                workSheet.Column(7).Width = 40;
                workSheet.Column(8).Width = 20;
                workSheet.Column(9).Width = 50;

                // Đặt tiêu đề cho danh sách
                ExcelRange range = workSheet.Cells[row, 1, row, 9];
                range.Merge = true;
                range.Value = GlobalLanguage.getEmployee("Excel.Title");
                range.Style.Font.Name = "Arial";
                range.Style.Font.Bold = true;
                range.Style.Font.Size = 16;
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                row++;

                // Cách tiêu đề 1 dòng
                ExcelRange rangeSpace = workSheet.Cells[row, 1, row, 9];
                rangeSpace.Merge = true;

                row++;

                // Đặt tiêu đề cột
                workSheet.Cells[row, 1].Value = GlobalLanguage.getEmployee("Excel.Column1");
                workSheet.Cells[row, 2].Value = GlobalLanguage.getEmployee("Excel.Column2");
                workSheet.Cells[row, 3].Value = GlobalLanguage.getEmployee("Excel.Column3");
                workSheet.Cells[row, 4].Value = GlobalLanguage.getEmployee("Excel.Column4");
                workSheet.Cells[row, 5].Value = GlobalLanguage.getEmployee("Excel.Column5");
                workSheet.Cells[row, 6].Value = GlobalLanguage.getEmployee("Excel.Column6");
                workSheet.Cells[row, 7].Value = GlobalLanguage.getEmployee("Excel.Column7");
                workSheet.Cells[row, 8].Value = GlobalLanguage.getEmployee("Excel.Column8");
                workSheet.Cells[row, 9].Value = GlobalLanguage.getEmployee("Excel.Column9");
                var rangeTitleColumn = workSheet.Cells[row, 1, row, 9];
                rangeTitleColumn.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rangeTitleColumn.Style.Fill.BackgroundColor.SetColor(1, 216, 216, 216);
                rangeTitleColumn.Style.Font.Bold = true;
                rangeTitleColumn.Style.Font.Size = 10;
                rangeTitleColumn.Style.Font.Name = "Arial";
                foreach (var cell in rangeTitleColumn)
                {
                    cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                row++;

                // Set giá trị cho bảng
                foreach (var employee in employeeList)
                {
                    // Set style
                    var rangeEmployee = workSheet.Cells[row, 1, row, 9];
                    rangeEmployee.Style.Font.Name = "Times New Roman";
                    rangeEmployee.Style.Font.Size = 11;
                    foreach(var cell in rangeEmployee)
                    {
                        cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    }

                    // Set giá trị
                    // Row - 3 vì trước đó đã sử dụng 3 dòng 
                    workSheet.Cells[row, 1].Value = row - 3;
                    workSheet.Cells[row, 2].Value = employee.EmployeeCode;
                    workSheet.Cells[row, 3].Value = employee.EmployeeName;
                    workSheet.Cells[row, 4].Value = employee.Gender == null ? null : GlobalLanguage.getEmployee($"Gender.{Enum.GetName(typeof(Gender), employee.Gender)}");
                    workSheet.Cells[row, 5].Value = employee.Birthday;
                    workSheet.Cells[row, 5].Style.Numberformat.Format = "dd/MM/YYYY";
                    workSheet.Cells[row, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Cells[row, 6].Value = employee.PositionId;
                    workSheet.Cells[row, 7].Value = employee.Department.DepartmentName;
                    workSheet.Cells[row, 8].Value = employee.BankAccount;
                    workSheet.Cells[row, 9].Value = employee.BankName;

                    row++;
                }

                return package.GetAsByteArray();
            }
        }

        public async Task<EmployeeModelDto> GetEmployeeWithDepartment(Guid employeeId)
        {
            var employee = await _employeeRepository.FindEntityAsync(employeeId);

            if(employee == null)
            {
                var userMsg = GlobalLanguage.getException("ID") + $" <{employeeId}>";
                var devMsg = GlobalLanguage.getException("ID") + $" <{employeeId}>";
                throw new NotFoundException(userMsg, devMsg);
            }

            var employeeModel = await _employeeRepository.GetEmployeeWithDepartemt(employee);

            var employeeModelDto = MapEmployeeModelToEmployeeModelDto(employeeModel);

            return employeeModelDto;
        }


        public EmployeeModelDto MapEmployeeModelToEmployeeModelDto(EmployeeModel employeeModel)
        {
            var employeeModelDto = _mapper.Map<EmployeeModelDto>(employeeModel);

            return employeeModelDto;
        }

        public override EmployeeDto MapEntityToEntityDto(Employee employee)
        {
            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public override async Task<Employee> MapEntityInsertDtoToEntityDto(EmployeeInsertDto employeeInsertDto)
        {
            // Kiểm tra trùng employeeCode
            await _employeeManager.CheckDuplicateCode(employeeInsertDto.EmployeeCode);

            // Kiểm tra đã tồn tại departmentId chưa
            await _departmentManager.IsExistDepartment(employeeInsertDto.DepartmentId);

            var employee = _mapper.Map<Employee>(employeeInsertDto);
            employee.EmployeeId = Guid.NewGuid();

            return employee;
        }

        public override async Task<Employee> MapEntityUpdateDtoToEntityDto(Guid employeeId, EmployeeUpdateDto employeeUpdateDto)
        {
            // Kiểm tra tồn tại employee 
            await _employeeManager.IsExistEmployee(employeeId);

            // Kiểm tra trùng employeeCode với nhân viên khác trong cơ sở dữ liệu
            var employeeExist = await _employeeRepository.FindByCodeAsync(employeeUpdateDto.EmployeeCode);

            if(employeeExist != null && employeeExist.EmployeeId != employeeId)
            {
                var userMsg = GlobalLanguage.getException("ID") + $" <{employeeUpdateDto.EmployeeCode}>";
                var devMsg = GlobalLanguage.getException("ID") + $" <{employeeUpdateDto.EmployeeCode}>";

                throw new ConflictException(userMsg, devMsg);
            }

            // Kiểm tra đã tồn tại departmentId chưa
            await _departmentManager.IsExistDepartment(employeeUpdateDto.DepartmentId);

            var employee = _mapper.Map<Employee>(employeeUpdateDto);
            employee.EmployeeId = employeeId;

            return employee;
        }

        public async Task<string> GetNewEmployeeCode()
        {
            // Lấy mã lớn nhất
            string newestCode = await _employeeRepository.GetNewestCode();

            // Chuyển thành mã tiếp theo
            int distance = 1;

            string pre = newestCode[..3];
            int code = int.Parse(newestCode[3..]) + distance;

            return pre + code;
        }
    }
}
