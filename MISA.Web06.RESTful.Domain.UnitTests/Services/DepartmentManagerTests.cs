using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace MISA.Web06.RESTful.Domain.UnitTests.Services
{
    [TestFixture]
    public class DepartmentManagerTests
    {
        private IDepartmentRepository _departmentRespository;
        private IDepartmentManager _departmentManager;
        [SetUp]
        public void SetUp()
        {
            _departmentRespository = Substitute.For<IDepartmentRepository>();
            _departmentManager = new DepartmentManager(_departmentRespository);
        }

        /// <summary>
        /// Hàm kiểm tra phòng ban có tồn tại
        /// </summary>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (24/08/2023)
        [Test]
        public async Task IsExistDepartment_departmentId_Success()
        {
            // Arrange
            var departmentId = Guid.NewGuid();
            _departmentRespository.FindEntityAsync(departmentId).Returns(new Department());

            // Act
            await _departmentManager.IsExistDepartment(departmentId);

            // Assert
            await _departmentRespository.Received(1).FindEntityAsync(departmentId);
        }

        /// <summary>
        /// Hàm kiểm tra phòng ban không tồn tại trả về lỗi
        /// </summary>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (24/08/2023)
        [Test]
        public async Task IsExistDepartment_departmentId_Exception()
        {
            // Arrange
            var departmentId = Guid.NewGuid();

            _departmentRespository.FindEntityAsync(departmentId).ReturnsNull();

            var notFoundException = new NotFoundException("Id phòng ban không tồn tại", "Không tồn tại departmentId: " + departmentId);

            // Act
            var handler = async () => await _departmentManager.IsExistDepartment(departmentId); 

            var actualResult = Assert.ThrowsAsync<NotFoundException>(() => handler());

            // Assert
            Assert.That(actualResult.UserMsg, Is.EqualTo(notFoundException.UserMsg));


            await _departmentRespository.Received(1).FindEntityAsync(departmentId);
        }
    }
}
