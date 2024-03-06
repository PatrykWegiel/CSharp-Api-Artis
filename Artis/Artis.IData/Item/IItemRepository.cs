using System.Collections.Generic;
using System.Threading.Tasks;

namespace Artis.IData.Item
{
    public interface IItemRepository
    {
        Task<Domain.Item.Item> GetAuctionItem(int id);
        Task<int> CreateAuctionItem(Domain.Item.Item item);
        Task EditAuctionItem(Domain.Item.Item item);
        Task<List<Domain.Item.Item>> GetAuctionItemsByUser(int userId);
        Task<List<Domain.Item.Item>> GetAuctionItemsByCategory(int categoryId);
    }
}
