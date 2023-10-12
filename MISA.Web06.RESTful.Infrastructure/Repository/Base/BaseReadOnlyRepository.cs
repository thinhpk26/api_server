using Dapper;
using MISA.Web06.RESTful.Application.UnitOfWork;
using MISA.Web06.RESTful.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Infrastructure
{
    public abstract class BaseReadOnlyRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected virtual string TableName { get; set; } = typeof(TEntity).Name;

        protected BaseReadOnlyRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {TableName};";

            var entityList = await UnitOfWork.Connection.QueryAsync<TEntity>(sql, transaction: UnitOfWork.Transaction);

            return entityList.ToList();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            var entityExist = await FindEntityAsync(id);
            if (entityExist == null)
            {
                var userMsg = String.Format(GlobalLanguage.getException("NotFoundOfUser"), GlobalLanguage.getException("ID") + $"<{id}>");
                var devMsg = String.Format(GlobalLanguage.getException("NotFoundOfDev"), GlobalLanguage.getException("ID") + $"<{id}>");
                throw new NotFoundException(userMsg, devMsg);
            }

            return entityExist;
        }

        public async Task<TEntity?> FindEntityAsync(TKey id)
        {
            var sql = $"SELECT * FROM {TableName} WHERE {TableName}Id=@{TableName}Id;";

            var param = new DynamicParameters();
            param.Add($"@{TableName}Id", id);

            var result = await UnitOfWork.Connection.QueryFirstOrDefaultAsync<TEntity>(sql, param, transaction: UnitOfWork.Transaction);

            return result;
        }

        public async Task<(List<TEntity>, List<TKey>)> GetManyAsync(List<TKey> ids)
        {
            var sql = $"SELECT * FROM {TableName} WHERE {TableName}Id IN @ids";

            var param = new DynamicParameters();
            param.Add("@ids", ids.ToList());

            var result = await UnitOfWork.Connection.QueryAsync<TEntity>(sql, param, transaction: UnitOfWork.Transaction);

            var entities = result.ToList();
            List<TKey> notExistedIds = new List<TKey>();

            if (entities.Count < ids.Count)
            {
                notExistedIds = ids.Where(id =>
                {
                    var isInEntity = entities.FirstOrDefault(entity => !entity.isEqualId(id));
                    if (isInEntity == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }).ToList();
            }

            return (entities, notExistedIds);
        }
    }
}
