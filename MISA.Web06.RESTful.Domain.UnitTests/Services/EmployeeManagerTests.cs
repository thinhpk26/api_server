using MISA.Web06.RESTful.Domain.UnitTests.Fake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain.UnitTests
{
    [TestFixture]
    public class EmployeeManagerTests
    {
        /// <summary>
        /// Kiểm tra nhân viên đã tồn tại
        /// </summary>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (10/08/2023)
        [Test]
        public async Task CheckDuplicateCode_EmployeeNotExitst_Success()
        {
            // Arrange
            string code = "NV-Helloworld";
            var employeeRepository = new EmployeeRepositoryFake();
            var countCallExpect = 1;

            // Act
            var employeeManager = new EmployeeManager(employeeRepository);

            await employeeManager.CheckDuplicateCode(code);

            var countCallActual = employeeRepository.CountCall;
            
            // Assert
            Assert.That(countCallActual, Is.EqualTo(countCallExpect));
           
        }
    }
}
