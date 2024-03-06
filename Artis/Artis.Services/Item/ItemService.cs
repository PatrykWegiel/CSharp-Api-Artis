using Artis.IData.Item;
using Artis.IServices.Item;
using Artis.IServices.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Artis.Services.Item
{
    public class ItemService: IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public Task<Domain.Item.Item> GetAuctionItem(int id)
        {
            return _itemRepository.GetAuctionItem(id);
        }

        public Task<List<Domain.Item.Item>> GetAuctionItemsByUser(int userId)
        {
            return _itemRepository.GetAuctionItemsByUser(userId);
        }

        public Task<List<Domain.Item.Item>> GetAuctionItemsByCategory(int categoryId)
        {
            return _itemRepository.GetAuctionItemsByCategory(categoryId);
        }
        public async Task<Domain.Item.Item> CreateAuctionItem(CreateAuctionItem createItem)
        {
            var item = new Domain.Item.Item(
                createItem.CategoryId,
                createItem.UserId,
                createItem.StartingPrice,
                createItem.ItemName,
                createItem.ItemDescription,
                createItem.ItemImageHref,
                createItem.Condition,
                createItem.EndDate
                );
            item.ItemId = await _itemRepository.CreateAuctionItem(item);
            return item;
        }
        public async Task EditAuctionItem(EditAuctionItem editItem, int id)
        {
            var item = await _itemRepository.GetAuctionItem(id);
            item.EditAuctionItem(
                editItem.CategoryId,
                editItem.StartingPrice,
                editItem.ItemName,
                editItem.ItemDescription,
                editItem.ItemImageHref,
                editItem.Condition,
                editItem.EndDate
                );
            await _itemRepository.EditAuctionItem(item);
        }
    }
}
