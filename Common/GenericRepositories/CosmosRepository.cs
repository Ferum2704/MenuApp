using Common.Interfaces;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.GenericRepositories
{
    public class CosmosRepository<T> : ICosmosRepository<T> where T : class
    {
        protected readonly Container _container;
        public CosmosRepository(ICosmosHelper cosmosHelper)
        {
            _container = cosmosHelper.GetContainer(typeof(T).Name.ToLower() + "s");
        }

        public async Task<T> AddAsync(T entity)
        {
            ItemResponse<T> response = await _container.CreateItemAsync(entity);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return response.Resource;
            }
            return null;
        }

        public Task AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            ResponseMessage response = await _container.ReadItemStreamAsync(id: id.ToString(), partitionKey: new PartitionKey(id.ToString()));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader streamReader = new StreamReader(response.Content);
                return JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
            }
            return null;
        }
        public async Task<T> GetByPartitionKey(string partitionKeyValue)
        {
            ContainerProperties containerProperties = await _container.ReadContainerAsync();
            string partitionKeyPath = containerProperties.PartitionKeyPath;
            string containerName = _container.Id;
            string queryScript = $"SELECT * FROM {containerName} WHERE {containerName}.{partitionKeyPath.TrimStart('/')} = @partitionKeyValue";
            QueryDefinition query = new QueryDefinition(queryScript)
                .WithParameter("@partitionKeyValue", partitionKeyValue);
            using var feed = _container.GetItemQueryStreamIterator(queryDefinition: query);
            var response = await feed.ReadNextAsync();
            if (response.Content is not null)
            {
                StreamReader streamReader = new StreamReader(response.Content);
                JObject jsonResult = JObject.Parse(streamReader.ReadToEnd());
                JToken jsonItem = jsonResult["Documents"].First;
                T item = jsonItem.ToObject<T>();
                return item;
            }
            return null;
        }
    }
}
