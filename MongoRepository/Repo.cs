using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepository
{
    public class Repo<TItem> : IRepo<TItem> where TItem : Item
    {
        public IMongoCollection<TItem> _item;
        public Repo(IDBClient<TItem> dbclient)
        {
            _item = dbclient.GetCollection();
        }

        public async Task<bool> InsertOne(TItem item)
        {
            await _item.InsertOneAsync(item);
            return true;
        }

        public async Task DeleteOne(string id)
        {
            await _item.DeleteOneAsync(item => item.Id == id);
        }

        public async Task<List<TItem>> GetAll()
        {
            List<TItem> item = (await _item.FindAsync(item => true)).ToList();
            return item;
        }

        public async Task<TItem> GetById(string id)
        {
            TItem item = (await _item.FindAsync(item => item.Id == id)).First();
            return item;
        }

        public async Task<TItem> UpdateOne(string id, TItem item)
        {
            await _item.ReplaceOneAsync(s => s.Id == item.Id, item);
            return item;
        }
    }
}
