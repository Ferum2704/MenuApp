using Common;
using Common.Extensions;
using Common.Interfaces;
using FluentMigrator.Runner;
using MediatR;
using MenuItemService.Domain.IRepositories;
using MenuItemService.Domain.Models;
using MenuItemService.Persistency.Repositories;
using MenuItemService.Proxies.ProxyInterfaces;
using MenuItemService.Proxies;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IOrderServiceProxy, OrderServiceProxy>();
builder.Services.AddSingleton<IDapperContext, DapperContext>();
builder.Services.AddSingleton<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
.AddFluentMigratorCore()
        .ConfigureRunner(c => c.AddSqlServer2016()
            .WithGlobalConnectionString(builder.Configuration.GetConnectionString("DefaultConnection"))
            .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
var app = builder.Build();
app.EnsureDatabase("MenuItemServiceDb");
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
