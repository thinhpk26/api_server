using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Application.UnitOfWork
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        #region Properties
        /// <summary>
        /// Connection kết nối csdl
        /// </summary>
        DbConnection Connection { get; }

        /// <summary>
        /// Hứng transaction 
        /// </summary>
        DbTransaction? Transaction { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Mở transaction
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Mở transaction bất đồng bộ
        /// </summary>
        /// <returns></returns>
        Task BeginTransactionAsync();

        /// <summary>
        /// Xác nhận thành công
        /// </summary>
        void Commit();

        /// <summary>
        /// Xác nhận thành công bất đồng bộ
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();

        /// <summary>
        /// Hủy transaction
        /// </summary>
        void Rollback();

        /// <summary>
        /// Hủy transaction bất đồng bộ
        /// </summary>
        /// <returns></returns>
        Task RollbackAsync(); 
        #endregion

    }
}
