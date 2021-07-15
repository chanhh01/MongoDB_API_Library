using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MongoRepository
{
    //BsonIgnoreExtraElements basically put null on the properties that exists in the model but are not found in the data
    //which in turn prevents the deserializing exception
    [BsonIgnoreExtraElements]
    public class Item 
    {
        //BsonID basically specify a certain property as the primary key ID for a document.
        //BsonRepresentation basically specifies the data type of the property.
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Type")]
        public string Type { get; set; }

    }
}
