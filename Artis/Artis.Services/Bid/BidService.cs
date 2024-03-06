using Artis.Domain.DomainExceptions;
using Artis.IData.Bid;
using Artis.IServices.Bid;
using Artis.IServices.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Artis.Services.Bid
{
    public class BidService: IBidService
    {
        private readonly IBidRepository _bidRepository;

        public BidService(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }

        public Task<Domain.Bid.Bid> GetBidById(int id)
        {
            return _bidRepository.GetBidById(id);
        }

        public Task<List<Domain.Bid.Bid>> GetUserBids(int userId)
        {
            return _bidRepository.GetUserBids(userId);
        }

        public Task<List<Domain.Bid.Bid>> GetBidsByItem(int itemId)
        {
            return _bidRepository.GetBidsByItem(itemId);
        }

        public async Task<Domain.Bid.Bid> CreateBid(CreateBid createBid)
        {
            var bid = new Domain.Bid.Bid(
                createBid.ItemId,
                createBid.UserId,
                createBid.Amount);
            bid.BidId = await _bidRepository.CreateBid(bid);
            return bid;
        }

        public async Task EditBid(EditBid editBid, int id)
        {
            var bid = await _bidRepository.GetBidById(id);
            if (editBid.Amount < bid.Amount) throw new InvalidBidException(bid.Amount, editBid.Amount);
            bid.EditBid(editBid.Amount);
            await _bidRepository.EditBid(bid);
        }
    }
}
