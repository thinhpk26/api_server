using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Application
{
    public interface ICrudService<TEntityDto, TEntityInsertDto, TEntityUpdateDto, TKey> : IReadOnlyService<TEntityDto, TKey> where TEntityDto : class where TEntityInsertDto : class where TEntityUpdateDto : class
    {
        /// <summary>Guid
        /// Hàm thêm một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi kiểu insert</param>
        /// <returns>Bản ghi</returns>
        /// Created by: Nguyễn Văn Thịnh (18/08/2023)
        Task<TEntityDto> InsertEntityAsync(TEntityInsertDto entity);

        /// <summary>
        /// Hàm cập nhật bản ghi
        /// </summary>
        /// <param name="id">Id bản ghi</param>
        /// <param name="entity">Bản ghi kiểu update</param>
        /// <returns>Bản ghi</returns>
        /// Created by: Nguyễn Văn Thịnh (18/08/2023)
        Task<TEntityDto> UpdateEntityAsync(TKey id, TEntityUpdateDto entity);

        /// <summary>
        /// Hàm xóa bản ghi
        /// </summary>
        /// <param name="id">id bản ghi</param>
        /// <returns>Số lượng dòng đã xóa</returns>
        /// Created by: Nguyễn Văn Thịnh (18/08/2023)
        Task<int> DeleteEntityAsync(TKey id);

        /// <summary>
        /// Hàm xóa nhiều bản ghi
        /// </summary>
        /// <param name="ids">Danh sách bản ghi</param>
        /// <returns>Số lượng bản ghi đã xóa</returns>
        /// Created by: Nguyễn Văn Thịnh (18/08/2023)
        Task<int> DeleteManyEntityAsync(List<TKey> ids);
    }
}
