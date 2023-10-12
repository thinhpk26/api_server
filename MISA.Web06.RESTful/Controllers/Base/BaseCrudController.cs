using Microsoft.AspNetCore.Mvc;
using MISA.Web06.RESTful.Application;
using MISA.Web06.RESTful.Application.Service;

namespace MISA.Web06.RESTful.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseCrudController<TEntityDto, TEntityInsertDto, TEntityUpdateDto, TKey> : BaseReadOnlyController<TEntityDto, TKey> where TEntityDto : class where TEntityInsertDto :class where TEntityUpdateDto :class
    {
        protected readonly ICrudService<TEntityDto, TEntityInsertDto, TEntityUpdateDto, TKey> CrudService;

        public BaseCrudController(ICrudService<TEntityDto, TEntityInsertDto, TEntityUpdateDto, TKey> crudService) : base(crudService)
        {
            CrudService = crudService;
        }

        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="entityInsertDto">Yêu cầu bao gồm một bản ghi</param>
        /// <returns>Bản ghi đã được thêm</returns>
        /// Author: Nguyễn Văn Thịnh (18/08/2023)
        [HttpPost]
        public async Task<IActionResult> InsertEntityAsync([FromBody] TEntityInsertDto entityInsertDto)
        {
            var result = await CrudService.InsertEntityAsync(entityInsertDto);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="id">mã bản ghi</param>
        /// <param name="entityUpdateDto">Bản ghi đã được thay đổi</param>
        /// <returns>Bản ghi đã được thay đổi</returns>
        /// Created by: Nguyễn Văn Thịnh (18/08/2023)
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] TKey id, [FromBody] TEntityUpdateDto entityUpdateDto)
        {
            var result = await CrudService.UpdateEntityAsync(id, entityUpdateDto);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="id">mã bản ghi</param>
        /// <returns>Số lượng dòng bị ảnh hưởng</returns>
        /// Created by: Nguyễn Văn Thịnh (12/08/2023)
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEntityByIdAsync([FromRoute] TKey id)
        {
            var result = await CrudService.DeleteEntityAsync(id);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Xóa nhiều bản ghi theo id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>Số lượng bản ghi đã bị thay đổi</returns>
        /// Created by: Nguyễn Văn thinh (24/02/2023)
        [HttpDelete]
        public async Task<IActionResult> DeleteManyEntityByIdAsync([FromBody] List<TKey> ids)
        {
            var result = await CrudService.DeleteManyEntityAsync(ids);

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
