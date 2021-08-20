using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripInTest.MongoDB
{
    public class MongoDBGenerics
    {
        private IMongoDatabase db;
        public MongoDBGenerics(string databaseName)
        {
            MongoClient client = new MongoClient("mongodb+srv://vagglan:Trelos95@cluster0test.qyubx.mongodb.net/Cluster0Test?retryWrites=true&w=majority");
            db = client.GetDatabase("MyFirstTest");
        }
        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }
    }
}
