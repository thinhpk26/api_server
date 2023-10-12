using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MISA.Web06.RESTful.Application.Service;
using MISA.Web06.RESTful.Application.UnitOfWork;
using MISA.Web06.RESTful.Domain;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace MISA.Web06.RESTful.Application.UnitTests.Service
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private IEmployeeRepository _employeeRepository { get; set; }
        private IMapper _mapper { get; set; }
        private IEmployeeManager _employeeManager { get; set; }
        private IUnitOfWork _unitOfWork { get; set; }
        private IDepartmentManager _departmentManager { get; set; }
        private EmployeeService _employeeService { get; set; }

        /// <summary>
        /// Thiết lập các đối tượng chung
        /// </summary>
        /// Created by: Nguyễn Văn Thịnh (24/08/2023)
        [SetUp]
        public void SetUp()
        {
            _employeeRepository = Substitute.For<IEmployeeRepository>();
            _mapper = Substitute.For<IMapper>();
            _employeeManager = Substitute.For<IEmployeeManager>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _departmentManager = Substitute.For<IDepartmentManager>();
            _employeeService = Substitute.For<EmployeeService>(_employeeRepository, _mapper, _unitOfWork, _employeeManager, _departmentManager);
            //_employeeService = new EmployeeService(_employeeRepository, _mapper, _unitOfWork, _employeeManager, _departmentManager);
        }

        /// <summary>
        /// Kiểm tra nhân viên không tồn tại trả về false
        /// </summary>
        /// <returns>false</returns>
        /// Created by: Nguyễn Văn Thịnh (24/08/2023)
        [Test]
        public async Task CheckDuplicateCodeAsync_EmployeeNotExist_ReturnFalse()
        {
            // Arrange
            var code = "NV-NotExist";
            _employeeRepository.FindByCodeAsync(code).ReturnsNull();

            // Act
            var actualResult = await _employeeService.IsDuplicateCodeAsync(code);

            // Assert
            Assert.That(actualResult, Is.False);

            await _employeeRepository.Received(1).FindByCodeAsync(code);
        }

        /// <summary>
        /// Kiểm tra nhân tồn tại trả về true
        /// </summary>
        /// <returns>true</returns>
        /// Created by: Nguyễn Văn Thịnh (24/08/2023)
        [Test]
        public async Task CheckDuplicateCodeAsync_EmployeeExist_ReturnTrue()
        {
            // Arrange
            var code = "NV-NotExist";
            var employee = new Employee();
            _employeeRepository.FindByCodeAsync(code).Returns(employee);

            // Act
            var actualResult = await _employeeService.IsDuplicateCodeAsync(code);

            // Assert
            Assert.That(actualResult, Is.True);

            await _employeeRepository.Received(1).FindByCodeAsync(code);
        }

        /// <summary>
        /// Xóa nhiều nhân viên trong nhiều nhân viên
        /// </summary>
        /// <returns>10</returns>
        /// Created by: Nguyễn Văn Thịnh (24/08/2023)
        [Test]
        public async Task DeleteManyAsync_List10Ids_Delete10Entity()
        {
            // Arrange
            var ids = new List<Guid>();
            for(int i=0; i<10; i++)
            {
                ids.Add(Guid.NewGuid());
            }

            var employees = ids.Select(id => new Employee()
            {
                EmployeeId = id,
            }).ToList();

            _employeeRepository.GetManyAsync(ids).Returns((employees, new List<Guid>()));

            _employeeRepository.DeleteManyEntityAsync(employees).Returns(10);

            var expectedResult = 10;

            // Act
            var actualResult = await _employeeService.DeleteManyEntityAsync(ids);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));

            await _employeeRepository.Received(1).DeleteManyEntityAsync(employees);
        }

        /// <summary>
        /// Xóa nhiều nhân viên nhưng một vài mã không tồn tại
        /// </summary>
        /// <returns>NotFoundException</returns>
        /// Created by: Nguyễn Văn Thịnh (24/08/2023)
        [Test]
        public async Task DeleteManyAsync_List10Ids8Entity_Exception()
        {
            // Arrange
            var successIds = new List<Guid>();
            var errorIds = new List<Guid>();
            for (int i = 0; i < 8; i++)
            {
                successIds.Add(Guid.NewGuid());
            }
            for (int i =0; i < 2; i++)
            {
                errorIds.Add(Guid.NewGuid());
            }

            var ids = successIds.Concat(errorIds).ToList();

            var employees = successIds.Select(id => new Employee()
            {
                EmployeeId = id,
            }).ToList();

            _employeeRepository.GetManyAsync(ids).Returns((employees, errorIds));

            // Act
            var handler = async () => await _employeeService.DeleteManyEntityAsync(ids);

            // Assert
            Assert.ThrowsAsync<NotFoundException>(() => handler());

            await _employeeRepository.Received(0).DeleteManyEntityAsync(employees);
        }

        /// <summary>
        /// Kiểm tra map employee sang employeeDto có đúng không
        /// </summary>
        /// Created by: Nguyễn Văn Thịnh (24/08/2023)
        [Test]
        public void MapEntityToEntityDto_Employee_employeeDto()
        {
            // Arrange
            var employee = new Employee();

            var expectedResult = new EmployeeDto();

            _mapper.Map<EmployeeDto>(employee).Returns(expectedResult);

            _employeeService.When(x => x.MapEntityToEntityDto(employee)).CallBase();

            // Act
            var actualResult = _employeeService.MapEntityToEntityDto(employee);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));

            _mapper.Received(1).Map<EmployeeDto>(employee);
        }

        /// <summary>
        /// kiểm tra ánh xạ từ employeeInsertDto thành công
        /// </summary>
        /// <returns>Employee</returns>
        /// Created by: Nguyễn Văn Thịnh (25/08/2023)
        [Test]
        public async Task MapEntityInsertDtoToEntityDto_EmployeeInsertDto_Employee()
        {
            // Arrange
            var employeeInsertDto = new EmployeeInsertDto();

            _employeeManager.CheckDuplicateCode(employeeInsertDto.EmployeeCode).Returns(Task.CompletedTask);

            _departmentManager.IsExistDepartment(employeeInsertDto.DepartmentId).Returns(Task.CompletedTask);

            var expectedResult = new Employee();
            _mapper.Map<Employee>(employeeInsertDto).Returns(expectedResult);

            _employeeService.When(x => x.MapEntityInsertDtoToEntityDto(employeeInsertDto)).CallBase();

            // Act
            var actualResult = await _employeeService.MapEntityInsertDtoToEntityDto(employeeInsertDto);

            // Assert
            await _employeeManager.Received(1).CheckDuplicateCode(employeeInsertDto.EmployeeCode);

            await _departmentManager.Received(1).IsExistDepartment(employeeInsertDto.DepartmentId);

            Assert.That(actualResult, Is.
                EqualTo(expectedResult));
        }

        /// <summary>
        /// Hàm chuyển đổi sang employee thành công
        /// </summary>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (25/08/2023)
        [Test]
        public async Task MapEntityUpdateDtoToEntityDto_employeeUpdateDto_employee()
        {
            // Arrange
            var employeeId = Guid.NewGuid();
            var employeeUpdateDto = new EmployeeUpdateDto();
            var employeeExist = new Employee()
            {
                EmployeeId = employeeId,
            };
            var employee = new Employee();

            _employeeManager.IsExistEmployee(employeeId).Returns(Task.CompletedTask);

            _employeeRepository.FindByCodeAsync(employeeUpdateDto.EmployeeCode).Returns(employeeExist);

            _departmentManager.IsExistDepartment(employeeUpdateDto.DepartmentId).Returns(Task.CompletedTask);
            
            _mapper.Map<Employee>(employeeUpdateDto).Returns(employee);

            _employeeService.When(x => x.MapEntityUpdateDtoToEntityDto(employeeId, employeeUpdateDto)).CallBase();

            // Act
            var actualResult = await _employeeService.MapEntityUpdateDtoToEntityDto(employeeId, employeeUpdateDto);

            // Assert
            Assert.That(actualResult, Is.EqualTo(employee));

            // Check employeeId
            Assert.That(actualResult.EmployeeId, Is.EqualTo(employeeId));

            // Check đã chạy một lần vào hàm kiểm tra tồn tại employee
            await _employeeManager.Received(1).IsExistEmployee(employeeId);

            // Check đã chạy một lần vào hàm kiểm tra employeeCode
            await _employeeRepository.Received(1).FindByCodeAsync(employeeUpdateDto.EmployeeCode);

            // Check đã chạy một lần vào hàm kiểm tra departmentId
            await _departmentManager.Received(1).IsExistDepartment(employeeUpdateDto.DepartmentId);

            // Check đã chạy một lần vào hàm map
            _mapper.Received(1).Map<Employee>(employeeUpdateDto);
        }

        /// <summary>
        /// hàm insert thành công
        /// </summary>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (25/08/2023)
        [Test]
        public async Task InsertEntityAsync_entityDtoInsert_Success()
        {
            // Arrange
            var employeeInsertDto = new EmployeeInsertDto();

            var employeeInsert = new Employee();
            var employeeDto = new EmployeeDto();

            _employeeService.MapEntityInsertDtoToEntityDto(employeeInsertDto).Returns(employeeInsert);

            _employeeRepository.InsertEntityAsync(employeeInsert).Returns(employeeInsert);

            _employeeService.MapEntityToEntityDto(employeeInsert).Returns(employeeDto);

            // Act
            var actualResult = await _employeeService.InsertEntityAsync(employeeInsertDto);

            // Assert
            Assert.That(actualResult, Is.EqualTo(employeeDto));

            await _employeeService.Received(1).MapEntityInsertDtoToEntityDto(employeeInsertDto);

            await _employeeRepository.Received(requiredNumberOfCalls: 1).InsertEntityAsync(employeeInsert);

            _employeeService.Received(1).MapEntityToEntityDto(employeeInsert);
        }

        /// <summary>
        /// Hàm update thành công
        /// </summary>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (25/08/2023)
        [Test]
        public async Task UpdateEntityAsync_entityUpdateDto_Success()
        {
            // Arrange 
            var employeeId = Guid.NewGuid();
            var employeeUpdateDto = new EmployeeUpdateDto();

            var employee = new Employee()
            {
                EmployeeId = employeeId
            };

            var employeeDto = new EmployeeDto();

            _employeeService.MapEntityUpdateDtoToEntityDto(employeeId, employeeUpdateDto).Returns(employee);

            _employeeRepository.UpdateEntityAsync(employee).Returns(employee);

            _employeeService.MapEntityToEntityDto(employee).Returns(employeeDto);

            // Act
            var actualresult = await _employeeService.UpdateEntityAsync(employeeId, employeeUpdateDto);


            // Assert
            Assert.That(actualresult, Is.EqualTo(employeeDto));

            await _employeeService.Received(1).MapEntityUpdateDtoToEntityDto(employeeId, employeeUpdateDto);

            await _employeeRepository.Received(1).UpdateEntityAsync(employee);

            _employeeService.Received(1).MapEntityToEntityDto(employee);

        }

        /// <summary>
        /// Hàm delete thành công
        /// </summary>
        /// Created by: Nguyễn Văn Thịnh (25/08/2023)
        [Test]
        public async Task DeleteEntityAsync_employeeId_Success()
        {
            // Arrange
            var employeeId = Guid.NewGuid();
            var employee = new Employee();

            var expectedResult = 1;
            _employeeRepository.GetAsync(employeeId).Returns(employee);

            _employeeRepository.DeleteEntityAsync(employee).Returns(expectedResult);

            // Act
            var actualResult = await _employeeService.DeleteEntityAsync(employeeId);


            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));

            await _employeeRepository.Received(1).GetAsync(employeeId);

            await _employeeRepository.Received(1).DeleteEntityAsync(employee);
        }

    }
}
