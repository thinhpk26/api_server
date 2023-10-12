using AutoMapper;
using MISA.Web06.RESTful.Application.UnitOfWork;
using MISA.Web06.RESTful.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using MISA.Web06.RESTful.Application.Service;
using System.Reflection;
using NSubstitute.ExceptionExtensions;

namespace MISA.Web06.RESTful.Application.UnitTests.Service
{
    [TestFixture]
    public class DepartmentServiveTests
    {
        private IDepartmentRepository _departmentRepository;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private DepartmentService _departmentService;

        [SetUp]
        public void SetUp()
        {
            _departmentRepository = Substitute.For<IDepartmentRepository>();
            _mapper = Substitute.For<IMapper>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _departmentService = Substitute.For<DepartmentService>(_departmentRepository, _mapper, _unitOfWork);
        }

        /// <summary>
        /// Hàm trả về departmentDto
        /// </summary>
        /// Created by: Nguyễn Văn Thịnh (24/08/2023)
        [Test]
        public void MapEntityToEntityDto_Department_DepartmentDto()
        {
            // Arrange
            var department = new Department();

            var expectedResult = new DepartmentDto();

            _mapper.Map<DepartmentDto>(department).Returns(expectedResult);

            _departmentService.When(x => x.MapEntityToEntityDto(department)).CallBase();

            // Act
            var actualResult = _departmentService.MapEntityToEntityDto(department);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));

            _mapper.Received(1).Map<DepartmentDto>(department);
        }

        /// <summary>
        /// Lấy được tất cả phòng ban 
        /// </summary>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (25/08/2023)
        [Test]
        public async Task GetAllEntityAsync_Null_EntityDtos()
        {
            // Arrange
            var departments = new List<Department>()
            {
                new Department()
            };

            var departmentDtos = new List<DepartmentDto>()
            {
                new DepartmentDto()
            };

            _departmentRepository.GetAllAsync().Returns(departments);

            foreach(var department in departments)
            {
                var index = departments.IndexOf(department);
                _departmentService.MapEntityToEntityDto(department).Returns(departmentDtos[index]);
            }

            // Act
            var actualResult = await _departmentService.GetAllEntityAsync();

            // Assert
            Assert.That(actualResult, Is.EqualTo(departmentDtos));

            await _departmentRepository.Received(1).GetAllAsync();
        }

        /// <summary>
        /// Hàm test trả về departmentDto
        /// </summary>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (24/08/2023)
        [Test]
        public async Task GetEntityAsync_departmentId_departmentDto()
        {
            // Arrange
            var departmentId = Guid.NewGuid();
            var department = new Department();
            var departmentDto = new DepartmentDto();

            _departmentRepository.GetAsync(departmentId).Returns(department);

            _departmentService.MapEntityToEntityDto(department).Returns(departmentDto);

            // Act
            var actualResult = await _departmentService.GetEntityAsync(departmentId);

            // Assert
            Assert.That(actualResult, Is.EqualTo(departmentDto));

            await _departmentRepository.Received(1).GetAsync(departmentId);

        }
    }
}
