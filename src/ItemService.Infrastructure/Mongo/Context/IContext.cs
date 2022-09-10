using MongoDB.Driver;

namespace ItemService.Infrastructure.Mongo.Context
{
    public interface IContext
    {
        IMongoCollection<T> DbSet<T>(string collection) where T : Document;
    }
}
