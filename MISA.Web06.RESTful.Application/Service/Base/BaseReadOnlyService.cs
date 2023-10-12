using MISA.Web06.RESTful.Application.UnitOfWork;
using MISA.Web06.RESTful.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Application.Service.Base
{
    public abstract class BaseReadOnlyService<TEntity, TEntityDto, TKey> : IReadOnlyService<TEntityDto, TKey> where TEntityDto : class where TEntity : IEntity<TKey>
    {
        protected readonly IReadOnlyRepository<TEntity, TKey> ReadOnlyRepository;
        protected readonly IUnitOfWork UnitOfWork;
        public BaseReadOnlyService(IReadOnlyRepository<TEntity, TKey> repository, IUnitOfWork unitOfWork)
        {
            ReadOnlyRepository = repository;
            UnitOfWork = unitOfWork;
        }

        public async Task<List<TEntityDto>> GetAllEntityAsync()
        {
            var entities = await ReadOnlyRepository.GetAllAsync();

            var entityDtos = entities.Select(entity => MapEntityToEntityDto(entity)).ToList();

            return entityDtos;
        }

        public async Task<TEntityDto> GetEntityAsync(TKey id)
        {
            var entity = await ReadOnlyRepository.GetAsync(id);

            var entityDto = MapEntityToEntityDto(entity);

            return entityDto;
        }

        /// <summary>
        /// Map từ entity sang entityDto
        /// </summary>
        /// <param name="entity">Thực thể</param>
        /// <returns>entityDto</returns>
        /// Created by: Nguyễn Văn Thịnh (18/08/2023)
        public abstract TEntityDto MapEntityToEntityDto(TEntity entity);
    }
}
