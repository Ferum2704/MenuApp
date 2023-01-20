using Common.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CosmosHelper:ICosmosHelper
    {
        private Database _database;
        private readonly IConfiguration _configuration;
        private readonly CosmosClient _cosmosClient;

        public Database Database
        {
            get => _database;
            set
            {
                if (_database == null)
                {
                    _database = value;
                }
            }
        }
        public CosmosHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _cosmosClient = new CosmosClient(connectionString: configuration.GetConnectionString("CosmosConnection"));
        }
        public CosmosClient GetCosmosClient()
        {
            return _cosmosClient;
        }
        public Container GetContainer(string containerName)
        {
            return _database.GetContainer(containerName);
        }
    }
}
