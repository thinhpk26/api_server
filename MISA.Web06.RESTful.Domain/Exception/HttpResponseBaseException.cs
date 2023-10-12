using Microsoft.AspNetCore.Http;

namespace MISA.Web06.RESTful.Domain
{
    /// <summary>
    /// Định nghĩa exception
    /// </summary>
    /// Author: Nguyễn Văn Thịnh (15/08/2023)
    public abstract class HttpResponseBaseException : Exception
    {
        #region Properties
        /// <summary>
        /// Thông báo đến người dùng
        /// </summary>
        public string UserMsg { get; set; }

        /// <summary>
        /// Thông báo đến nhà phát triển
        /// </summary>
        public string DevMsg { get; set; }
        #endregion

        #region Methods
        public HttpResponseBaseException(string userMsg, string devMsg)
        {
            UserMsg = userMsg;
            DevMsg = devMsg;
        } 
        #endregion
    }
}
