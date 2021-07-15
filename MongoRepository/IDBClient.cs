using MongoDB.Driver;

namespace MongoRepository
{
    ///<summary>
    ///This is the database client interface that helps to initialize<see cref="GetCollection"></see>.
    ///</summary>
    ///<typeparam name = "TItem" >
    ///The implementation class type.
    ///</typeparam>
    /// <include file='docs.xml' path='docs/members[@name="DBClient"]/IDBClient/*'/>
    public interface IDBClient<TItem>
    {
        ///<summary>
        ///This method is used to retrieve the whole collection from the database based on the connection string upon launch.
        ///</summary>
        ///<returns>
        ///Returns the whole collection retrieved from the connection string.
        ///</returns>
        /// <include file='docs.xml' path='docs/members[@name="DBClient"]/GetCollection/*'/>
        IMongoCollection<TItem> GetCollection();
    }
}
