using AB.Service.Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AB.Service.Core.Services
{
	public class MongoDbHandler
	{
        private readonly IMongoClient client;
        private readonly IMongoDatabase db;    
        private const string connectionString =
          "mongodb+srv://automation:1q2w3e$r@cluster0-fvm1p.mongodb.net/test?retryWrites=true&w=majority";
        private const string dbName = "AccountMongoDb";
        private const string collectionRequestDocumentName = "BACollection";

        public MongoDbHandler()
        {
            client = new MongoClient(connectionString);
            db = client.GetDatabase(dbName);
        }

        public IMongoCollection<MongoRequestModel> GetCollection()
        {
            var result  = db.GetCollection<MongoRequestModel>(collectionRequestDocumentName);
            return db.GetCollection<MongoRequestModel>(collectionRequestDocumentName);
        }
        public void CreateRequests(Item item)
        {
            var json = JsonConvert.SerializeObject(item);         
            var collection = db.GetCollection<BsonDocument>(collectionRequestDocumentName);
            BsonDocument document = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(json);
            collection.InsertOne(document);
        }

    }
}
