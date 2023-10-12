using Dapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using MISA.Web06.RESTful.Application.UnitOfWork;
using MISA.Web06.RESTful.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Infrastructure
{
    public abstract class BaseCrudRepository<TEntity, TKey> : BaseReadOnlyRepository<TEntity, TKey>, ICrudRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        protected BaseCrudRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<TEntity> InsertEntityAsync(TEntity entity)
        {
            var entityExist = await FindEntityAsync(entity.GetId());
            if (entityExist != null)
            {
                var userMsg = GlobalLanguage.getException("ID") + $" <{entity.GetId()}>";
                var devMsg = GlobalLanguage.getException("ID") + $" <{entity.GetId()}>";
                throw new ConflictException(userMsg, devMsg);
            }

            var insertQuery = CreateInsertQueryString(entity);

            await UnitOfWork.Connection.ExecuteAsync(insertQuery.Sql, insertQuery.Param, transaction: UnitOfWork.Transaction);

            return entity;
        }

        public async Task<TEntity> UpdateEntityAsync(TEntity entity)
        {
            var entityExist = await FindEntityAsync(entity.GetId());
            if (entityExist == null)
            {
                var userMsg = GlobalLanguage.getException("ID") + $" <{entity.GetId()}>";
                var devMsg = GlobalLanguage.getException("ID") + $" <{entity.GetId()}>";
                throw new NotFoundException(userMsg, devMsg);
            }

            var updateQuery = CreateUpdateQueryString(entity);

            await UnitOfWork.Connection.ExecuteAsync(updateQuery.Sql, updateQuery.Param, transaction: UnitOfWork.Transaction);

            return entity;
        }

        public async Task<int> DeleteEntityAsync(TEntity entity)
        {
            var entityExist = await FindEntityAsync(entity.GetId());
            if (entityExist == null)
            {
                var userMsg = GlobalLanguage.getException("ID") + $" <{entity.GetId()}>";
                var devMsg = GlobalLanguage.getException("ID") + $" <{entity.GetId()}>";
                throw new NotFoundException(userMsg, devMsg);
            }

            var sql = $"DELETE FROM {TableName} WHERE {TableName}Id = @{TableName}Id;";

            var param = new DynamicParameters();
            param.Add($"@{TableName}Id", entity.GetId());

            var result = await UnitOfWork.Connection.ExecuteAsync(sql, param, transaction: UnitOfWork.Transaction);

            return result;
        }

        public async Task<int> DeleteManyEntityAsync(List<TEntity> entities)
        {
            var sql = $"DELETE FROM {TableName} WHERE {TableName}Id IN @{TableName}Ids;";

            var param = new DynamicParameters();
            param.Add($"@{TableName}Ids", entities.Select(entity => entity.GetId()));

            var result = await UnitOfWork.Connection.ExecuteAsync(sql, param, transaction: UnitOfWork.Transaction);

            return result;
        }

        /// <summary>
        /// Định nghĩa câu lệnh insert và param cho chúng
        /// </summary>
        /// <param name="entity">bản ghi</param>
        /// <returns>Query</returns>
        /// Created by: Nguyễn Văn Thịnh (18/08/2023)
        public abstract Query CreateInsertQueryString(TEntity entity);

        /// <summary>
        /// Định nghĩa câu lệnh update và param cho chúng
        /// </summary>
        /// <param name="entity">bản ghi</param>
        /// <returns>Query</returns>
        /// Created by: Nguyễn Văn Thịnh (18/08/2023)
        public abstract Query CreateUpdateQueryString(TEntity entity);
    }
}
