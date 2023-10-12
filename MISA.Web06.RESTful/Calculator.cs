namespace MISA.Web06.RESTful
{
    public class Calculator
    {
        /// <summary>
        /// Hàm cộng hai số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Tổng hai số nguyên</returns>
        /// Created by: Nguyễn Văn Thịnh (13/08/2023)
        public long Add(int x, int y)
        {
            return (long)x + y;
        }

        /// <summary>
        /// Hàm cộng các số phân tách nhau bởi dấu phẩy
        /// </summary>
        /// <param name="numberString">Chuỗi các số</param>
        /// <returns>Tổng các số trong chuỗi</returns>
        /// Created by: Nguyễn Văn Thịnh (13/08/2023)
        public long Add(string numberString)
        {
            if(numberString == "")
            {
                return 0;
            }
            
            string[] numberStringArr = numberString.Split(",");

            long tong = 0;
            var negativeNumberList = new List<int>();
            for (int i=0; i<numberStringArr.Length; i++)
            {
                int number;
                bool isParseSuccess = int.TryParse(numberStringArr[i], out number);
                if(number < 0)
                {
                    negativeNumberList.Add(number);
                }
                if (isParseSuccess) {
                    tong += number;
                } else
                {
                    throw new Exception("Không thể chuyển đổi giá trị của từng phần tử sang số");
                }
            }
            if(negativeNumberList.Count > 0)
            {
                throw new Exception("Không chấp nhận toán tử âm: " + String.Join(", ", negativeNumberList));
            }

            return tong;
        }

        /// <summary>
        /// Hàm trừ hai số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Hiệu hai số nguyên</returns>
        /// Created by: Nguyễn Văn Thịnh (13/08/2023)
        public long Sub(int x, int y)
        {
            return (long)x - y;
        }

        /// <summary>
        /// Hàm nhân hai số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Tích hai số nguyên</returns>
        /// Created by: Nguyễn Văn Thịnh (13/08/2023)
        public long Mul(int x, int y)
        {
            return (long)x * y;
        }

        /// <summary>
        /// Hàm chia hai số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Thương hai số nguyên</returns>
        /// Created by: Nguyễn Văn Thịnh (13/08/2023)
        public double Div(int x, int y)
        {
            if(y == 0)
            {
                throw new Exception("Không cho phép chia cho 0");
            }
            return (double)x / y;
        }
    }
}
