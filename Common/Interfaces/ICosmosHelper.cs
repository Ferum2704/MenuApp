using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ICosmosHelper
    {
        Database Database { get; set; }
        CosmosClient GetCosmosClient();
        Container GetContainer(string containerName);
    }
}
