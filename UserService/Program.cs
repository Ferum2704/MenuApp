using Common;
using Common.Extesions;
using Common.Interfaces;
using MediatR;
using Microsoft.Azure.Cosmos;
using System.Reflection;
using UserService.Domain.IRepositories;
using UserService.Persistency.Repositories;
using UserService.Proxies;
using UserService.Proxies.ProxyInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IOrderServiceProxy, OrderServiceProxy>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ICosmosHelper, CosmosHelper>();
builder.Services.AddControllers();
builder.Services.AddSingleton<IUserCosmosRepository, UserCosmosRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.EnsureCosmosDatabase("TestInternshipDB");
app.EnsureCosmosContainer(new ContainerProperties()
{
    Id = "users",
    PartitionKeyPath = "/phoneNumber",
});
app.UseCors(x =>
{
    x.AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true) // allow any origin
        .AllowCredentials();
});

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
