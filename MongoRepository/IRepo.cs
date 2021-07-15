using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoRepository
{
    ///<summary>
    ///This is the repository interface for any implementation of
    ///<typeparamref name="TItem"/>, exposing asynchronous C.R.U.D.functionality.
    ///</summary>
    ///<typeparam name = "TItem" >
    ///The implementation class type.
    ///</typeparam>
    /// <include file='docs.xml' path='docs/members[@name="Repository"]/IRepo/*'/>
    public interface IRepo<TItem> where TItem : Item
    {
        ///<summary>
        ///This method is used to retrieve the whole collection from database.It is implemented in asynchronous way.
        ///</summary>
        ///<returns>
        ///Returns a list of items in Generic type.
        ///</returns>
        /// <include file='docs.xml' path='docs/members[@name="Repository"]/GetAll/*'/>
        Task<List<TItem>> GetAll();

        ///<summary>
        ///This method is used to get single object from database with ID provided.It is implemented in asynchronous way.
        ///</summary>
        ///<param name = "id" > The Object ID of the item to be read from the database</param>
        ///<returns>
        ///Returns an item in Generic type.
        ///</returns>
        /// <include file='docs.xml' path='docs/members[@name="Repository"]/GetById/*'/>
        Task<TItem> GetById(string id);

        
        ///<summary>
        ///This method is used to insert documents to your database.It is implemented in asynchronous way.
        ///</summary>
        ///<param name = "item" > Generic type object.</param>
        ///<returns>
        ///Returns a boolean indicating success or failure.
        ///</returns>
        ///<include file='docs.xml' path='docs/members[@name="Repository"]/InsertOne/*'/>
        Task<bool> InsertOne(TItem item);


        ///<summary>
        ///This method is used to hard-delete documents in your app with ID provided.However, it is recommended to use soft-delete for business
        ///application such as updating a field namely "documentState" and setting it to "updated" thus securing some important data.
        ///</summary>
        ///<param name = "id" > The Object ID of the item to be read from the database</param>
        ///<returns>
        ///Returns a boolean indicating success or failure.
        ///</returns>
        ///<include file='docs.xml' path='docs/members[@name="Repository"]/DeleteOne/*'/>
        Task DeleteOne(string id);


        ///<summary>
        ///This method is used to update an item based on ID provided.
        ///</summary>
        ///<param name = "id" > The Object ID of the item to be read from the database</param>
        ///<param name = "item" > Generic type object.</param>
        ///<returns>
        ///Returns a boolean indicating success or failure.
        ///</returns>
        ///<include file='docs.xml' path='docs/members[@name="Repository"]/UpdateOne/*'/>
        Task<TItem> UpdateOne(string id, TItem item);

    }
}
