using MISA.Web06.RESTful.Application.Service.Base;
using MISA.Web06.RESTful.Application.UnitOfWork;
using MISA.Web06.RESTful.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Application
{
    public abstract class BaseCrudService<TEntity, TEntityDto, TEntityInsertDto, TEntityUpdateDto, TKey> : BaseReadOnlyService<TEntity, TEntityDto, TKey>, ICrudService<TEntityDto, TEntityInsertDto, TEntityUpdateDto, TKey> where TEntity : IEntity<TKey> where TEntityDto : class where TEntityInsertDto : class where TEntityUpdateDto : class
    {
        protected readonly ICrudRepository<TEntity, TKey> CrudRepository;
        protected BaseCrudService(ICrudRepository<TEntity, TKey> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            CrudRepository = repository;
        }

        public async Task<TEntityDto> InsertEntityAsync(TEntityInsertDto entityDtoInsert)
        {
            var insertedEntity = await MapEntityInsertDtoToEntityDto(entityDtoInsert);

            var result = await CrudRepository.InsertEntityAsync(insertedEntity);

            var entityDto = MapEntityToEntityDto(result);

            return entityDto;
        }

        public async Task<TEntityDto> UpdateEntityAsync(TKey id, TEntityUpdateDto entityUpdateDto)
        {
            var entity = await MapEntityUpdateDtoToEntityDto(id, entityUpdateDto);

            var result = await CrudRepository.UpdateEntityAsync(entity);

            var entityDto = MapEntityToEntityDto(result);

            return entityDto;
        }

        public async Task<int> DeleteEntityAsync(TKey id)
        {
            var entity = await CrudRepository.GetAsync(id);

            var result = await CrudRepository.DeleteEntityAsync(entity);

            return result;
        }

        public async Task<int> DeleteManyEntityAsync(List<TKey> ids)
        {
            var (entities, notExitstIds) = await ReadOnlyRepository.GetManyAsync(ids);

            if(notExitstIds.Count > 0)
            {
                var notExistedIdsString = string.Join(", ", notExitstIds);
                var userMsg = GlobalLanguage.getException("ID") + $" <{notExistedIdsString}>";
                var devMsg = GlobalLanguage.getException("ID") + $" <{notExistedIdsString}>";
                throw new NotFoundException(userMsg, devMsg);
            }

            var rowAffect = await CrudRepository.DeleteManyEntityAsync(entities);

            return rowAffect;
        }

        /// <summary>
        /// Map từ entityInsertDto sang entityDto
        /// </summary>
        /// <param name="entityInsertDto">entity dạng insert</param>
        /// <returns>entityDto</returns>
        /// Created by: Nguyễn Văn Thịnh
        public abstract Task<TEntity> MapEntityInsertDtoToEntityDto(TEntityInsertDto entityInsertDto);

        /// <summary>
        /// Map từ entityUpdateDto sang entityDto
        /// </summary>
        /// <param name="id">id của entity</param>
        /// <param name="entityUpdateDto">entity dạng update</param>
        /// <returns>entityDto</returns>
        /// Created by: Nguyễn Văn Thịnh
        public abstract Task<TEntity> MapEntityUpdateDtoToEntityDto(TKey id, TEntityUpdateDto entityUpdateDto);
    }
}
