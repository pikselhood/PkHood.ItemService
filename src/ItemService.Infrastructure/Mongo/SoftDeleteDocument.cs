using MongoDB.Bson.Serialization.Attributes;

namespace ItemService.Infrastructure.Mongo
{
    public abstract class SoftDeleteDocument : Document
    {
        [BsonElement("deletedAt")]
        public DateTime DeletedAt { get; set; }
        
        [BsonElement("isDeleted")]
        public bool IsDeleted { get; set; }
    }
}