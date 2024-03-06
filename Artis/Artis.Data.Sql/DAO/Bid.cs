using System;

namespace Artis.Data.Sql.DAO
{
    public class Bid
    {
        public int BidId { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public int Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual User User { get; set; }
        public virtual Item Item { get; set; }
        public virtual Delivery Delivery { get; set; }

    }
}
