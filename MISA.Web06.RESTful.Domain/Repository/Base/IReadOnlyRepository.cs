using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain
{
    public interface IReadOnlyRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        /// <summary>
        /// Hàm lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: Nguyễn Văn Thịnh (17/08/2023)
        Task<List<TEntity>> GetAllAsync();

        /// <summary>
        /// Hàm lấy danh sách entity theo Id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>List<typeparamref name="TEntity"/></returns>
        /// Created by: Nguyễn Văn Thịnh
        Task<(List<TEntity>, List<TKey>)> GetManyAsync(List<TKey> ids);

        /// <summary>
        /// Hàm lấy 1 bản ghi
        /// </summary>
        /// <param name="id">id bản ghi</param>
        /// <returns>Bản ghi</returns>
        /// Created by: Nguyễn Văn Thịnh (17/08/2023)
        Task<TEntity> GetAsync(TKey id);

        /// <summary>
        /// Hàm tìm bản ghi theo id bản ghi
        /// </summary>
        /// <param name="id">Id bản ghi</param>
        /// <returns>bản ghi or null</returns>
        /// Created by: Nguyễn Văn Thịnh (17/08/2023)
        Task<TEntity?> FindEntityAsync(TKey id);
    }
}
