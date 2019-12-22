using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace TraderaWebServiceClient
{
    class DatabaseHandler
    {
        private string connectionString = "mongodb://localhost";
        private MongoClient dbClient;
        private IMongoDatabase database;
        private IMongoCollection<BsonDocument> collection;
        public DatabaseHandler(string databaseName, string collectionName)
        {
            dbClient = new MongoClient(connectionString);
            database = dbClient.GetDatabase(databaseName);
            collection = database.GetCollection<BsonDocument>(collectionName);
        }
        
        //TODO serialize category object to a Bson document and add it to the collection 
        public void addCategoryToDB(C_CategoryItem categoryItem) 
        {
            //BsonDocument document = categoryItem.ToBson();
            //collection.InsertOne(document);
             
            BsonClassMap.RegisterClassMap<C_CategoryItem>();
        }


     
    }
}
