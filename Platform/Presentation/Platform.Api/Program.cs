using FluentValidation;
using FluentValidation.AspNetCore;
using Platform.Api;
using Platform.Application;
using Platform.Application.Validators.Company;
using Platform.Infrastructure;
using Platform.Persistence;
using Serilog;
using Serilog.Context;
using System.Data.Common;
using Utilities.Infrastructure.UtilityInfrastructure;
using Utilities.Infrastructure.UtilityInfrastructure.Filters;
using Utilities.Infrastructure.UtilityInfrastructure.Services.Storage.Local;
using Utilities.Presentation.UtilityApi.Middleware;
using Utilities.Presentation.UtilityApi.Middleware.GlobalException;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPlatformApiServices();
builder.Services.AddPlatformPersistenceServices();
builder.Services.AddPlatformApplicationServices();
builder.Services.AddPlatformInfrastructureServices();
builder.Services.AddUtilityInfrastructureServices();
builder.Services.AddStroage<LocalStorage>();

var corsUrls = builder.Configuration.GetSection("CorsPolicy:Urls").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins(corsUrls)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
        });
});

builder.Services.AddCustomHttpLogging();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwaggerCustom();
builder.Services.AddCustomJwtAuthentication(builder.Configuration);

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>());
builder.Services.AddValidatorsFromAssemblyContaining<CreateCompanyRequestValidator>();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
var logger = SerilogExtension.CreateLogger(builder.Configuration);
builder.Host.UseSerilog(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
var environment = builder.Environment.EnvironmentName;
var connectionString = builder.Configuration.GetSection("ConnectionStrings:PlatformSqlServer").Value;
var dbBuilder = new DbConnectionStringBuilder { ConnectionString = connectionString };
// Server ve Database bilgilerini al
var server = dbBuilder["Server"];
var database = dbBuilder["Database"];
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{server}_{database}_Platform Local API");
    });
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{server}_{database}_Platform API");
    c.RoutePrefix = string.Empty;
});

app.UseStaticFiles();

app.UseSerilogRequestLogging();

app.UseCors();

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseErrorWrappingMiddleware();
app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    var userName = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
    LogContext.PushProperty("CreatedBy", userName);
    await next();
});

app.MapControllers();

app.Run();