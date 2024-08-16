using GCharge.Api.Services.OcppCoreServer;
using GCharge.Application;
using GCharge.Domain.Entities.Identity;
using GCharge.Infrastructure;
using GCharge.Persistence;
using GCharge.Persistence.Services.Identity;
using Microsoft.AspNetCore.Identity;
using Utilities.Infrastructure.UtilityInfrastructure;
using Utilities.Infrastructure.UtilityInfrastructure.Services.Storage.Local;
using Utilities.Presentation.UtilityApi.Middleware;
using Utilities.Presentation.UtilityApi.Middleware.GlobalException;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOcppCoreServerService, OcppCoreServerService>();
builder.Services.AddGChargeInfrastructureServices();
builder.Services.AddGChargePersistenceServices();
builder.Services.AddGChargeApplicationServices();
builder.Services.AddUtilityInfrastructureServices();
builder.Services.AddStroage<LocalStorage>();

var corsUrls = builder.Configuration.GetSection("CorsPolicy:Urls").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddCustomHttpLogging();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwaggerCustom();
builder.Services.AddCustomJwtAuthentication(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
//var logger = SerilogExtension.CreateLogger(builder.Configuration);
//builder.Host.UseSerilog(logger);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GCharge Local API");
    });
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GCharge API");
    c.RoutePrefix = string.Empty;
});

app.UseStaticFiles();

//app.UseSerilogRequestLogging();

app.UseCors();

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseErrorWrappingMiddleware();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    await UserRoleService.InitializeAsync(services, userManager);
}

app.Run();
