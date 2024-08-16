using BaseProject.Application;
using BaseProject.Infrastructure;
using BaseProject.Persistence;
using FluentValidation;
using FluentValidation.AspNetCore;
using GCrm.Application;
using GCrm.Application.Validators.Customer;
using GCrm.Persistence;
using Serilog;
using Utilities.Infrastructure.UtilityInfrastructure;
using Utilities.Infrastructure.UtilityInfrastructure.Services.Storage.Local;
using Utilities.Presentation.UtilityApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBaseProjectApplicationServices();
builder.Services.AddBaseProjectInfrastructureServices();
builder.Services.AddBaseProjectPersistenceServices();
builder.Services.AddUtilityInfrastructureServices();

builder.Services.AddGCrmPersistenceServices();
builder.Services.AddGCrmApplicationServices();
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

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwaggerCustom();
builder.Services.AddCustomJwtAuthentication(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCustomerRequestValidator>();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
var logger = SerilogExtension.CreateLogger(builder.Configuration);
builder.Host.UseSerilog(logger);


var app = builder.Build();

// Configure the HTTP request pipeline.
var environment = builder.Environment.EnvironmentName;
var baseDbName = builder.Configuration.GetSection("ConnectionStrings:BaseProjectDatabase");
var serverName = builder.Configuration.GetSection("ConnectionStrings:Server");
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{serverName.Value}_{baseDbName.Value}_HR Local API");
    });
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{serverName.Value}_{baseDbName.Value}_GCRM API");
    c.RoutePrefix = string.Empty;
});

//app.UseSerilogRequestLogging();
app.UseStaticFiles();

app.UseCors();

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
