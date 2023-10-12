using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.UnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        /// <summary>
        /// Kiểm tra hàm cộng 
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <param name="expectedResult">Kết quả mong chờ</param>
        /// Created by: Nguyễn Văn Thịnh (13/08/2023)
        [TestCase(1, 2, 3)]
        [TestCase(5, 2, 7)]
        [TestCase(-1, 2, 1)]
        [TestCase(int.MaxValue, int.MaxValue, (long)int.MaxValue * 2)]
        public void Add_InputValid_SumTwoNumber(int x, int y, long expectedResult)
        {
            // Act
            var actualResult = new Calculator().Add(x, y);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Kiểm tra hàm trừ
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <param name="expectedResult">Kết quả mong chờ</param>
        /// Created by: Nguyễn Văn Thịnh (13/08/2023)
        [TestCase(1, 2, -1)]
        [TestCase(5, 2, 3)]
        [TestCase(-1, 2, -3)]
        [TestCase(int.MaxValue, int.MinValue, (long)int.MaxValue * 2 + 1)]
        public void Sub_InputValid_SubTwoNumber(int x, int y, long expectedResult)
        {
            // Act
            var actualResult = new Calculator().Sub(x, y);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Kiểm tra hàm nhân
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <param name="expectedResult">Kết quả mong chờ</param>
        /// Created by: Nguyễn Văn Thịnh (13/08/2023)
        [TestCase(1, 2, 2)]
        [TestCase(5, 2, 10)]
        [TestCase(-1, 2, -2)]
        [TestCase(int.MaxValue, int.MinValue, (long)int.MaxValue * int.MinValue)]
        public void Mul_InputValid_SubTwoNumber(int x, int y, long expectedResult)
        {
            // Act
            var actualResult = new Calculator().Mul(x, y);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Kiểm tra lỗi hàm chia khi toán hạng thứ 2 bằng 0
        /// </summary>
        [Test]
        public void Div_InputValid_Exception()
        {
            // Arrage
            var x = 1;
            var y = 0;
            var expectedMessage = "Không cho phép chia cho 0";

            // Act
            var exception = Assert.Throws<Exception>(() => new Calculator().Div(x, y));

            // Assert
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }

        /// <summary>
        /// Kiểm tra lỗi hàm chia đúng kết quả mong chờ
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <param name="expectedResult">Kết quả mong chờ</param>
        /// Created by: Nguyễn Văn Thịnh
        [TestCase(1, 2, 0.5d)]
        [TestCase(1, 3, 1/(float)3)]
        public void Div_InputValid_DivTwoNumber(int x, int y, double expectedResult)
        {
            // Act
            var actualResult = new Calculator().Div(x, y);

            // Assert
            Assert.That(Math.Abs(actualResult - expectedResult), Is.LessThan(10e-6));
        }

        /// <summary>
        /// Khi chuỗi truyền vào là rỗng
        /// </summary>
        [Test]
        public void Add_InputValid_Zero()
        {
            // Array
            var numberString = "";
            var expectedResult = 0;

            // Act
            var actualResult = new Calculator().Add(numberString);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Khi chuỗi truyền vào không thể chuyển sang số
        /// </summary>
        [Test]
        public void Add_InputError_Exception()
        {
            // Arrange
            string numberString = "dfd, 1";
            string expectedMsg = "Không thể chuyển đổi giá trị của từng phần tử sang số";

            // Act
            var actualException = Assert.Throws<Exception>(() => new Calculator().Add(numberString));

            // Assert
            Assert.That(actualException.Message, Is.EqualTo(expectedMsg));
        }

        /// <summary>
        /// Kiểm tra giá trị với chuỗi có giá trị âm
        /// </summary>
        /// <param name="numberString">Chuỗi số</param>
        [TestCase("34, -5, -9, -8")]
        public void Add_InputValid_Exception(string numberString)
        {
            // Arrage
            var number = new List<int>();
            string expectedMsg = "Không chấp nhận toán tử âm: -5, -9, -8";

            // Act
            var actualException = Assert.Throws<Exception>(() => new Calculator().Add(numberString));

            // Assert
            Assert.That(actualException.Message, Is.EqualTo(expectedMsg));
        }

        /// <summary>
        /// Kiểm tra giá trị 
        /// </summary>
        /// <param name="numberString">Chuỗi số</param>
        /// <param name="expectedResult">Kết quả mong chờ</param>
        [TestCase("6, 9, 8, 0", 23)]
        [TestCase("3, 0, 8, 0", 11)]
        public void Add_InputValid_SumNumberString(string numberString, int expectedResult)
        {
            // Act
            var actualResult = new Calculator().Add(numberString);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
