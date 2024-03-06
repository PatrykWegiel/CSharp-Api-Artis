using Artis.Domain.DomainExceptions;
using System;

namespace Artis.Domain.Bid
{
    public class Bid
    {
        public int BidId { get; set; }
        public int ItemId { get; private set; }
        public int UserId { get; private set; }
        public int Amount { get; private set; }
        public DateTime CreationDate { get; private set; }

        public Bid(int BidId, int ItemId, int UserId, int Amount, DateTime CreationDate)
        {
            this.BidId = BidId;
            this.ItemId = ItemId;
            this.UserId = UserId;
            this.Amount = Amount;
            this.CreationDate = CreationDate;
        }

        public Bid(int ItemId, int UserId, int Amount)
        {
            if (Amount <= 0) throw new InvalidBidException(Amount);
            this.ItemId = ItemId;
            this.UserId = UserId;
            this.Amount = Amount;
            CreationDate = DateTime.UtcNow;
        }

        public void EditBid(int Amount)
        {
            this.Amount = Amount;
            CreationDate = DateTime.UtcNow;
        }
    }
}
