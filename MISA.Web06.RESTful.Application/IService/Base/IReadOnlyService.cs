using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Application
{
    public interface IReadOnlyService<TEntityDto, TKey> where TEntityDto : class
    {
        /// <summary>
        /// Hàm lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: Nguyễn Văn Thịnh (18/08/2023)
        Task<List<TEntityDto>> GetAllEntityAsync();

        /// <summary>
        /// Hàm lấy 1 bản ghi
        /// </summary>
        /// <param name="id">id bản ghi</param>
        /// <returns>bản ghi</returns>
        /// Created by: Nguyễn Văn Thịnh (18/08/2023)
        Task<TEntityDto> GetEntityAsync(TKey id);
    }
}
