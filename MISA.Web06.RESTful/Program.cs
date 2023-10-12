using AutoMapper;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using MISA.Web06.RESTful;
using MISA.Web06.RESTful.Application;
using MISA.Web06.RESTful.Application.Service;
using MISA.Web06.RESTful.Domain;
using MISA.Web06.RESTful.Infrastructure;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cấu hình xử lý validate dữ liệu
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errorCode = ErrorCode.Invalid;

        var errors = new List<object>();

        foreach (var entry in context.ModelState)
        {
            var fieldKey = entry.Key;
            var fieldErrors = entry.Value.Errors.Select(error => error.ErrorMessage);

            foreach (var error in fieldErrors)
            {
                errors.Add( new
                {
                    FieldName = fieldKey,
                    ErrorMessage = error
                });
            }
        }

        var userMsg = errors;
        var devMsg = errors;
        var traceId = context.HttpContext.TraceIdentifier;

        var responseError = new ResponseError<List<object>>()
        {
            ErrorCode = errorCode,
            UserMsg = userMsg,
            DevMsg = devMsg,
            TraceId = traceId
        };

        return new BadRequestObjectResult(responseError)
        {
            StatusCode = StatusCodes.Status400BadRequest,
            ContentTypes = { "application/json" }
        };
    };
});

// Cấu hình autoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Cấu hình kết nối cơ sở dữ liệu
var connectionString = builder.Configuration["ConnectionStrings:MySql"];

// Cấu hình các tầng
InfrastructureConfig.Configure(builder.Services, connectionString);
DomainConfig.Configure(builder.Services);
ApplicationConfig.Configure(builder.Services);

// Cấu hình CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Cấu hình đối tượng trả về của controller
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

var app = builder.Build();

app.UseStatusCodePages();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
