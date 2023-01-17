using Common.Interfaces;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extesions
{
    public static class CosmosMigrationManager
    {
        public static IApplicationBuilder EnsureCosmosDatabase(this IApplicationBuilder builder, string dbName)
        {
            using var scope = builder.ApplicationServices.CreateScope();
            var helper = scope.ServiceProvider.GetService<ICosmosHelper>();
            CosmosClient cosmosClient = helper.GetCosmosClient();
            Database database = cosmosClient.CreateDatabaseIfNotExistsAsync(dbName).GetAwaiter().GetResult();
            helper.Database = database;
            return builder;
        }
        public static IApplicationBuilder EnsureCosmosContainer(this IApplicationBuilder builder, 
            ContainerProperties containerProperties)
        {
            using var scope = builder.ApplicationServices.CreateScope();
            var helper = scope.ServiceProvider.GetService<ICosmosHelper>();
            helper.Database?.CreateContainerIfNotExistsAsync(containerProperties).GetAwaiter().GetResult();
            return builder;
        }
    }
}
