using System.Collections.Generic;
using System.Threading.Tasks;
using Artis.IServices.Requests;

namespace Artis.IServices.Bid
{
    public interface IBidService
    {
        Task<Domain.Bid.Bid> GetBidById(int id);
        Task<Domain.Bid.Bid> CreateBid(CreateBid bid);
        Task EditBid(EditBid bid, int id);
        Task<List<Domain.Bid.Bid>> GetUserBids(int userId);
        Task<List<Domain.Bid.Bid>> GetBidsByItem(int itemId);
    }
}
