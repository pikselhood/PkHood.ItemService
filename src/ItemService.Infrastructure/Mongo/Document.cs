using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ItemService.Infrastructure.Mongo
{
    public abstract class Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public object? Id { get; set; }
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
