using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripIn.Core.Models;

namespace TripIn.Core.Interfaces
{
    public interface IBusinessServiceAsync<TEntity> where TEntity: class
    {
        void InsertRecord<TEntity>(string table, TEntity record);
        List<TEntity> LoadRecords(string table);
        TEntity LoadRecordById(Guid id, string table);
        void UpsertRecord<TEntity>(Guid id, TEntity entity, string table);
        void DeleteRecord<TEntity>(Guid id, string table);
    }
}
