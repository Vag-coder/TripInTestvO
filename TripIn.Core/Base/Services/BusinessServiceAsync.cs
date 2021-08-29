using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripIn.Core.Interfaces;
using TripIn.Core.Models;

namespace TripIn.Core.Base.Services
{
    public abstract class BusinessServiceAsync<TEntity> : IBusinessServiceAsync<TEntity> where TEntity: class
    {
        private IMongoDatabase db;
        protected BusinessServiceAsync()
        {
            MongoClient client = new MongoClient("mongodb+srv://vagglan:Trelos95@cluster0test.qyubx.mongodb.net/Cluster0Test?retryWrites=true&w=majority");
            db = client.GetDatabase("MyFirstTest");
        }
        public void InsertRecord<TEntity>(string table, TEntity record)
        {
            var collection = db.GetCollection<TEntity>(table);
            collection.InsertOne(record);
        }
        public List<TEntity> LoadRecords(string table)
        {
            var collection = db.GetCollection<TEntity>(table);
     
            return collection.Find(new BsonDocument()).ToList();
        }
        public TEntity LoadRecordById(Guid id, string table)
        {
            var collection = db.GetCollection<TEntity>(table);
            var filter = Builders<TEntity>.Filter.Eq("Id", id);

            return collection.Find(filter).First();
        }

        public void UpsertRecord<TEntity>(Guid id, TEntity entity, string table)
        {
            var collection = db.GetCollection<TEntity>(table);
            var filter = Builders<TEntity>.Filter.Eq("Id", id);
            var result = collection.ReplaceOne(                 
                filter,
                entity,
                new ReplaceOptions { IsUpsert = true }
                );
        }
        public void DeleteRecord<TEntity>(Guid id, string table)
        {
            var collection = db.GetCollection<TEntity>(table);
            var filter = Builders<TEntity>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);
        }
    }
}
