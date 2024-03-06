using System.Collections.Generic;
using System.Threading.Tasks;

namespace Artis.IData.Bid
{
    public interface IBidRepository
    {
        Task<Domain.Bid.Bid> GetBidById(int id);
        Task<int> CreateBid(Domain.Bid.Bid bid);
        Task EditBid(Domain.Bid.Bid bid);
        Task<List<Domain.Bid.Bid>> GetUserBids(int userId);
        Task<List<Domain.Bid.Bid>> GetBidsByItem(int itemId);
    }
}
