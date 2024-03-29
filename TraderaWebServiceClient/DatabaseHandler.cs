﻿using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TraderaWebServiceClient
{
    class DatabaseHandler
    {
        //private string connectionString = "mongodb://localhost";
        private MongoClient dbClient;
        private IMongoDatabase database;
        public DatabaseHandler(string databaseName, string connectionString)
        {
            dbClient = new MongoClient(connectionString);
            database = dbClient.GetDatabase(databaseName);
        }


        /**
         * Return all documents
         **/
        public List<C_CategoryItem> findAllDocuments(string collectionName)
        {
            var collection = database.GetCollection<C_CategoryItem>(collectionName);
            return collection.Find(new BsonDocument()).ToList();
        }

        /**
         * Returns the category with the given category id
        **/
        public List<C_CategoryItem> findCategoryById<C_CategoryItem>(string collectionName, int categoryId)
        {
            var collection = database.GetCollection<C_CategoryItem>(collectionName);
            var filter = Builders<C_CategoryItem>.Filter.Eq("categoryId", categoryId);

            return collection.Find(filter).ToList();
        }

        /**
         * Insert a list of category items
         * Replaces the category if it already exists in the database
         **/
        public bool insertCategoryList(List<C_CategoryItem> list, string collectionName)
        {
            bool returnVal = false;
            var collection = database.GetCollection<C_CategoryItem>(collectionName);
            foreach (var categoryItem in list)
            {
                var replaceOpt = new ReplaceOptions();
                replaceOpt.IsUpsert = true;
                var filter = Builders<C_CategoryItem>.Filter.Eq("categoryId", categoryItem.categoryId);
                ReplaceOneResult result = collection.ReplaceOne(filter, categoryItem, replaceOpt);
                returnVal = result.IsAcknowledged;
            }
            return returnVal;
        }

        /**
         * Insert one category item
         **/
        public void insertCategory(C_CategoryItem categoryItem, string collectionName)
        {
            var collection = database.GetCollection<C_CategoryItem>(collectionName);
            collection.InsertOne(categoryItem);
        }

        public List<C_CategoryItem> FindAllTopCategories(string collectionName)
        {
            var collection = database.GetCollection<C_CategoryItem>(collectionName);
            var filter = Builders<C_CategoryItem>.Filter.Eq("topcategory", true);

            return collection.Find(filter).ToList();
        }

    }
}
