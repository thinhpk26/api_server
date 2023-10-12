using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Application
{
    public class FilterDto<TEntities>
    {
        #region Properties
        /// <summary>
        /// Tổng tất cả record tìm được
        /// </summary>
        public int TotalRecord { get; set; }

        /// <summary>
        /// Tất cả record trong trang
        /// </summary>
        public List<TEntities> Data { get; set; } 
        #endregion
    }
}
