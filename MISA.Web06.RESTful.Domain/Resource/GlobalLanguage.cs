using MISA.Web06.RESTful.Domain.Enum;
using MISA.Web06.RESTful.Domain.Resource.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using MISA.Web06.RESTful.Domain.Resource.Exception;

namespace MISA.Web06.RESTful.Domain
{
    /// <summary>
    /// Lấy chuỗi theo ngôn ngữ
    /// Created by: Nguyễn Văn Thịnh (08/09/2023)
    /// </summary>
    public static class GlobalLanguage
    {
        private static LanguageCode _langCode = LanguageCode.VN;

        /// <summary>
        /// Lấy chuỗi thuộc nhân viên
        /// Author: Nguyễn Văn Thịnh (08/09/2023)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string getEmployee(string key)
        {
            var resourceType = typeof(EmployeeVN);

            var resourceManager = new ResourceManager(resourceType);

            var value = resourceManager.GetString(key) ?? "";

            return value;
        }

        /// <summary>
        /// Lấy chuỗi thuộc nhân viên
        /// Author: Nguyễn Văn Thịnh (08/09/2023)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="langCode"></param>
        /// <returns></returns>
        public static string getEmployee(string key, LanguageCode langCode)
        {
            var resourceType = typeof(EmployeeVN);
            if (langCode == LanguageCode.US)
            {
                resourceType = typeof(EmployeeUS);
            }

            var resourceManager = new ResourceManager(resourceType);

            var value = resourceManager.GetString(key) ?? "";

            return value;
        }

        /// <summary>
        /// Lấy chuỗi thuộc exception
        /// Author: Nguyễn Văn Thịnh (08/09/2023)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string getException(string key)
        {
            var resourceType = typeof(ExceptionMsgVN);

            var resourceManager = new ResourceManager(resourceType);

            var value = resourceManager.GetString(key) ?? "";

            return value;
        }

        /// <summary>
        /// Lấy chuỗi thuộc exception
        /// Author: Nguyễn Văn Thịnh (08/09/2023)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="languageCode"></param>
        /// <returns></returns>
        public static string getException(string key, LanguageCode languageCode)
        {
            var resourceType = typeof(ExceptionMsgVN);
            if (languageCode == LanguageCode.US)
            {
                resourceType = typeof(ExceptionMsgUS);
            }

            var resourceManager = new ResourceManager(resourceType);

            var value = resourceManager.GetString(key) ?? "";

            return value;
        }
    }
}
