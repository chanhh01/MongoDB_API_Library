using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MongoRepository
{
    public class DBClient<TItem> : IDBClient<TItem> 
    {
        private readonly IMongoCollection<TItem> _item;
        public DBClient(IOptions<DBConfig> dbconfig)
        {
            string ConnectionString = "mongodb+srv://chan:chh428493@testcluster.axotv.mongodb.net/newTest?retryWrites=true&w=majority";
            string Database_Name = "newTest";
            string Collection_Name = "Item";


            MongoClient client = new MongoClient(ConnectionString);
            IMongoDatabase database = client.GetDatabase(Database_Name);
            _item = database.GetCollection<TItem>(Collection_Name);

            // The code below will commuicate with dbconfig which should retrieve connection string from appsettings.json,
            // database name and collection name from launchsettings.json. This code would only work if you run the code using IIS
            // instead of running it in debug file since the code in debug file would not refer to launchsettings and appsettings for some reason.

            //MongoClient client = new MongoClient(dbconfig.Value.ConnectionString);
            //IMongoDatabase database = client.GetDatabase(dbconfig.Value.Database_Name);
            //_item = database.GetCollection<Item>(dbconfig.Value.Collection_Name);
        }

        public IMongoCollection<TItem> GetCollection()
        {
            return _item;
        }

    }
}