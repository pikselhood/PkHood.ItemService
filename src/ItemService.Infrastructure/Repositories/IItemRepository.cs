using System.Linq.Expressions;
using ItemService.Domain.Item;
using ItemService.Infrastructure.Models;

namespace ItemService.Infrastructure.Repositories
{
    public interface IItemRepository
    {
        public Task<ItemBase> GetItemById(Guid id, bool isDeleted = false);
        public Task<(List<ItemBase> data,long totalCount)> GetItems(
            Expression<Func<ItemBaseDto, bool>> expression, 
            Expression<Func<ItemBaseDto, bool>> sortDefinition, 
            int offset, 
            int limit);
        public Task<Guid> CreateItem(ItemBase item);
        public Task<ItemBase> ReplaceItem(ItemBase item);
        public Task<ItemBase> UpdateItem(
            ItemBase item, 
            (Expression<Func<ItemBaseDto, object>>, object) updatedProperties);
        public Task<bool> HardDeleteItem(Guid id);
        public Task<bool> DeleteItem(Guid id);
    }
}