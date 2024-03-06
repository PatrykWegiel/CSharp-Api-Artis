using System.Collections.Generic;
using System.Threading.Tasks;
using Artis.IServices.Requests;

namespace Artis.IServices.Item
{
    public interface IItemService
    {
        Task<Domain.Item.Item> GetAuctionItem(int id);
        Task<Domain.Item.Item> CreateAuctionItem(CreateAuctionItem item);
        Task EditAuctionItem(EditAuctionItem item, int id);
        Task<List<Domain.Item.Item>> GetAuctionItemsByUser(int userId);
        Task<List<Domain.Item.Item>> GetAuctionItemsByCategory(int categoryId);
    }
}
