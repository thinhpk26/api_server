using System.Text.Json;
using System.Text.Json.Serialization;

namespace MISA.Web06.RESTful
{
    /// <summary>
    /// Cấu hình thuộc tính trong đối tượng trả về
    /// Created by: Nguyễn Văn Thịnh (10/09/2023)
    /// </summary>
    public class PascalCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }

            // Chuyển đổi chữ cái đầu tiên thành chữ hoa và trả về
            return char.ToUpper(name[0]) + name.Substring(1);
        }
    }
}
