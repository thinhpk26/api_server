using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain
{
    public interface ICrudRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        /// <summary>
        /// Hàm thêm một bản ghi
        /// </summary>
        /// <param name="entity">bản ghi</param>
        /// <returns>bản ghi đã thêm</returns>
        /// Created by: Nguyễn Văn Thịnh(17/08/2023)
        Task<TEntity> InsertEntityAsync(TEntity entity);

        /// <summary>
        /// Hàm cập nhật bản ghi
        /// </summary>
        /// <param name="entity">bản ghi cần cập nhật</param>
        /// <returns>bản ghi đã cập nhật</returns>
        /// Created by: Nguyễn Văn Thịnh (17/08/2023)
        Task<TEntity> UpdateEntityAsync(TEntity entity);

        /// <summary>
        /// Hàm xóa bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi</param>
        /// <returns>Số lượng dòng đã thêm</returns>
        /// Created by: Nguyễn Văn Thịnh (17/08/2023)
        Task<int> DeleteEntityAsync(TEntity entity);

        /// <summary>
        /// Hàm xóa nhiều bản ghi
        /// </summary>
        /// <param name="entitys">Danh sách bản ghi</param>
        /// <returns>Số lượng bản ghi bị xóa</returns>
        /// Created by: Nguyễn Văn Thịnh (17/08/2023)
        Task<int> DeleteManyEntityAsync(List<TEntity> entities);
    }
}
