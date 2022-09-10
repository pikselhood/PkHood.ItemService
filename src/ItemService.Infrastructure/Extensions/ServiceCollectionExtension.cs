using ItemService.Infrastructure.Configs;
using ItemService.Infrastructure.Mongo.Context;
using ItemService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace ItemService.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, MongoSettings mongoSettings)
    {
        var mongoClient = new MongoClient(mongoSettings.MongoConnStr);
        services.AddSingleton<IContext, Context>(_ =>  new Context(mongoClient, mongoSettings.MongoDbName));
        services.AddSingleton<IItemRepository, ItemRepository>();

        return services;
    }
}