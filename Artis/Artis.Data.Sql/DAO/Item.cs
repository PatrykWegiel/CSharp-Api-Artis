using Artis.Common.Enum;
using System;
using System.Collections.Generic;

namespace Artis.Data.Sql.DAO
{
    public class Item
    {
        public Item()
        {
            Bids = new List<Bid>();
        }

        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public int StartingPrice { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemImageHref { get; set; }
        public ItemCondition Condition { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Banned { get; set; }
        public bool Visible { get; set; }
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
    }
}
