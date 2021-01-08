using IBP_API.Database.Models.IOT;
using IOT_API2.Database.Models;
using IOT_API2.Database.Models.IOT;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BooksApi.Services
{
    public class ForestService
    {
        private readonly IMongoCollection<Forest> _forests;

        public Forest(IIoTDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _forests = database.GetCollection<Forest>(settings.IoTCollectionName);
        }

        public List<Forest> Get() =>
            _forests.Find(forest => true).ToList();

        public Forest Get(string id) =>
            _forests.Find<Book>(forest => forest.Id == id).FirstOrDefault();

        public Forest Create(Forest forest)
        {
            _forests.InsertOne(forest);
            return forest;
        }

        public void Update(string id, Forest forestIn) =>
            _forests.ReplaceOne(forest => forest.Id == id, forestIn);

        public void Remove(Forest forestIn) =>
            _forests.DeleteOne(forest => forest.Id == forestIn.Id);

        public void Remove(string id) =>
            _forests.DeleteOne(forest => forest.Id == id);
    }
}