using Common;
using Common.Extensions;
using Common.Interfaces;
using FluentMigrator.Runner;
using MediatR;
using OrderService.Application;
using OrderService.Domain;
using OrderService.Domain.IRepositories;
using OrderService.Persistency.Repositories;
using OrderService.Proxies;
using OrderService.Proxies.ProxyInterfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IMenuItemServiceProxy, MenuItemServiceProxy>();
builder.Services.AddSingleton<IDapperContext, DapperContext>();
builder.Services.AddSingleton<IOrderRepository, OrderDapperRepository>();
builder.Services.AddSingleton<IMenuItemOrderRepository, MenuItemOrderDapperRepository>();
builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
.AddFluentMigratorCore()
        .ConfigureRunner(c => c.AddSqlServer2016()
            .WithGlobalConnectionString(builder.Configuration.GetConnectionString("DefaultConnection"))
            .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(x =>
{
    x.AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true) // allow any origin
        .AllowCredentials();
});
app.EnsureDatabase("OrderServiceDb");
app.MigrateDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
