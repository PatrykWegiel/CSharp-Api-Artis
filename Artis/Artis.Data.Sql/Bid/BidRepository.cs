using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artis.IData.Bid;
using Microsoft.EntityFrameworkCore;

namespace Artis.Data.Sql.Bid
{
    public class BidRepository : IBidRepository
    {
        private ArtisDbContext _context;

        public BidRepository(ArtisDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Bid.Bid> GetBidById(int id)
        {
            var bid = await _context.Bid.FirstOrDefaultAsync(x => x.BidId == id);
            return new Domain.Bid.Bid(
                bid.BidId,
                bid.ItemId,
                bid.UserId,
                bid.Amount,
                bid.CreationDate);
        }

        public async Task<int> CreateBid(Domain.Bid.Bid createBid)
        {
            var bid = new DAO.Bid
            {
                ItemId = createBid.ItemId,
                UserId = createBid.UserId,
                Amount = createBid.Amount,
                CreationDate = DateTime.UtcNow
            };
            await _context.AddAsync(bid);
            await _context.SaveChangesAsync();
            return bid.BidId;
        }

        public async Task<List<Domain.Bid.Bid>> GetUserBids(int userId)
        {
            var bids = await _context.Bid.Where(x => x.UserId == userId).ToListAsync();
            return bids.Select(bid => new Domain.Bid.Bid(
                            bid.BidId,
                            bid.ItemId,
                            bid.UserId,
                            bid.Amount,
                            bid.CreationDate)).ToList();
        }
        public async Task<List<Domain.Bid.Bid>> GetBidsByItem(int itemId)
        {
            var bids = await _context.Bid.Where(x => x.ItemId == itemId).ToListAsync();
            return bids.Select(bid => new Domain.Bid.Bid(
                            bid.BidId,
                            bid.ItemId,
                            bid.UserId,
                            bid.Amount,
                            bid.CreationDate)).ToList();
        }

        public async Task EditBid(Domain.Bid.Bid editBid)
        {
            var bid = await _context.Bid.FirstOrDefaultAsync(x => x.BidId == editBid.BidId);
            bid.BidId = editBid.BidId;
            bid.ItemId = editBid.ItemId;
            bid.UserId = editBid.UserId;
            bid.Amount = editBid.Amount;
            bid.CreationDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
