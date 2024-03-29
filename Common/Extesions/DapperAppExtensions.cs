﻿
using Common.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Linq;

namespace Common.Extensions
{
    public static class DapperAppExtensions
    {
        public static IApplicationBuilder EnsureDatabase(this IApplicationBuilder builder, string dbName)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var query = "SELECT * FROM sys.databases WHERE name = @name";
                var parameters = new DynamicParameters();
                parameters.Add("name", dbName);
                var context = scope.ServiceProvider.GetRequiredService<IDapperContext>();
                using (var connection = context.CreateMasterConnection())
                {
                    var records = connection.Query(query, parameters);
                    if (!records.Any())
                        connection.Execute($"CREATE DATABASE {dbName}");
                }
            }
            return builder;
        }
    }
}
