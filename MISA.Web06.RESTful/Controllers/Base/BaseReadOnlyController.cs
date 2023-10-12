using Microsoft.AspNetCore.Mvc;
using MISA.Web06.RESTful.Application;

namespace MISA.Web06.RESTful.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseReadOnlyController<TEntityDto, TKey> : ControllerBase where TEntityDto : class
    {
        protected readonly IReadOnlyService<TEntityDto, TKey> ReadOnlyService;

        public BaseReadOnlyController(IReadOnlyService<TEntityDto, TKey> readOnlyService)
        {
            ReadOnlyService = readOnlyService;
        }

        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Mảng các bản ghi</returns>
        /// Created by: Nguyễn Văn Thịnh (18/08/2023)
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await ReadOnlyService.GetAllEntityAsync();

            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Lấy bản ghi theo employeeId
        /// </summary>
        /// <returns>Nhân viên</returns>
        /// Created by: Nguyễn Văn Thịnh (12/08/2023)
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployeeByEmployeeIdAsync([FromRoute] TKey id)
        {
            var result = await ReadOnlyService.GetEntityAsync(id);

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
