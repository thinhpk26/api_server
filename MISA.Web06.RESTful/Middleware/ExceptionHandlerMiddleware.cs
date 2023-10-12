using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MISA.Web06.RESTful.Domain;
using System.Diagnostics;
using System.Threading;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MISA.Web06.RESTful
{
    public class ExceptionHandlerMiddleware
    {
        /// <summary>
        /// Ủy quyền đến middleware tiếp theo
        /// </summary>
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Cấu hình middleware khi có lỗi nghiệp vụ
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        /// Created by: Nguyễn Văn Thịnh (10/08/2023)
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            } catch(Exception ex)
            {
                int statusCode;

                ResponseError<string> description;
                
                switch (ex)
                {
                    case NotFoundException notFoundEx:
                        statusCode = StatusCodes.Status404NotFound;

                        description = new ResponseError<string>()
                        {
                            ErrorCode = ErrorCode.NotFound,
                            DevMsg = String.Format(GlobalLanguage.getException("NotFoundOfUser"), notFoundEx.DevMsg),
                            UserMsg = String.Format(GlobalLanguage.getException("NotFoundOfDev"), notFoundEx.UserMsg),
                            MoreInfo = "",
                            TraceId = httpContext.TraceIdentifier,
                        };
                        break;
                    case ConflictException conflictEx:
                        statusCode = StatusCodes.Status409Conflict;

                        description = new ResponseError<string>()
                        {
                            ErrorCode = ErrorCode.NotFound,
                            DevMsg = String.Format(GlobalLanguage.getException("ConflictOfDev"), conflictEx.DevMsg),
                            UserMsg = String.Format(GlobalLanguage.getException("ConflictOfUser"), conflictEx.UserMsg),
                            MoreInfo = "",
                            TraceId = httpContext.TraceIdentifier,
                        };
                        break;
                    case ExportExcelException exportEx:
                        statusCode = StatusCodes.Status500InternalServerError;

                        description = new ResponseError<string>()
                        {
                            ErrorCode = ErrorCode.NotFound,
                            DevMsg = GlobalLanguage.getException("ExportExcelOfDev"),
                            UserMsg = GlobalLanguage.getException("ExportExcelOfUser"),
                            MoreInfo = "",
                            TraceId = httpContext.TraceIdentifier,
                        };
                        break;
                    default:
                        statusCode = StatusCodes.Status500InternalServerError;

                        description = new ResponseError<string>()
                        {
                            ErrorCode = ErrorCode.NotFound,
                            DevMsg = ex.Message,
                            UserMsg = GlobalLanguage.getException("Server"),
                            MoreInfo = "",
                            TraceId = httpContext.TraceIdentifier,
                        };
                        break;
                }

                // Cấu hình middleWare trả về PascalCase
                var jsonSerializerOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = new PascalCaseNamingPolicy(),
                };

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = statusCode;
                await JsonSerializer.SerializeAsync(httpContext.Response.Body, description, jsonSerializerOptions);
            }
        }
    }
}
