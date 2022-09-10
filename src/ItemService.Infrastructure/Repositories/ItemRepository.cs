using System.Linq.Expressions;
using ItemService.Domain.Item;
using ItemService.Infrastructure.Models;
using ItemService.Infrastructure.Mongo.Context;
using ItemService.Infrastructure.Mongo.Enums;
using ItemService.Infrastructure.Mongo.Repository;
using Mapster;
using MongoDB.Driver.Linq;

namespace ItemService.Infrastructure.Repositories
{
    public class ItemRepository : Repository<ItemBaseDto>, IItemRepository
    {
        public ItemRepository(IContext context) : base(context, "item")
        {
            
        }
        public async Task<ItemBase> GetItemById(Guid id, bool isDeleted = false)
        {
            var item = await MongoQueryable.Where(c => c.Id != null && c.Id.Equals(id) && c.IsDeleted == isDeleted)
                .FirstOrDefaultAsync();
            return item.Adapt<ItemBase>();
        }

        public async Task<(List<ItemBase> data,long totalCount)> GetItems(
            Expression<Func<ItemBaseDto, bool>> expression, 
            Expression<Func<ItemBaseDto, bool>> sortDefinition, 
            int offset, 
            int limit)
        {
            var result = await FindManyAsync(expression, sortDefinition, OrderByDirection.Desc, offset, limit);
            return (result.data.Select(x => x.Adapt<ItemBase>()).ToList(), result.totalCount);
        }

        public async Task<Guid> CreateItem(ItemBase item)
        {
            var itemDto = item.Adapt<ItemBaseDto>();
            return (Guid) await InsertOneAsync(itemDto);
        }

        public async Task<ItemBase> ReplaceItem(ItemBase item)
        {
            var itemDto = item.Adapt<ItemBaseDto>();
            var result = await ReplaceOneAsync(c => c.Id == itemDto.Id  && !c.IsDeleted, itemDto);
            
            if (result > 0)
                return item;

            throw new Exception(item.Id.ToString()); // TODO custom exception
        }

        public async Task<ItemBase> UpdateItem(ItemBase item, (Expression<Func<ItemBaseDto, object>>, object) updatedProperties)
        {
            var itemDto = item.Adapt<ItemBaseDto>();
            var result = await UpdateOneAsync(c => c.Id == itemDto.Id  && !c.IsDeleted, updatedProperties);
            
            if (result > 0)
                return item;

            throw new Exception(item.Id.ToString());
        }

        public async Task<bool> DeleteItem(Guid id)
        {
            var result = await UpdateOneAsync(c => c.Id.Equals(id),
                (c => c.DeletedAt, DateTime.Now),(c => c.IsDeleted, true));
            
            return result > 0;
        }
        
        public async Task<bool> HardDeleteItem(Guid id)
        {
            var result = await DeleteOneAsync(c => c.Id.Equals(id));
            
            return result > 0;
        }
        
    }
}