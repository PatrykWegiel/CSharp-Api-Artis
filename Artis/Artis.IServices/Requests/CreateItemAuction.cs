using Artis.Common.Enum;
using System;

namespace Artis.IServices.Requests
{
    public class CreateAuctionItem
    {
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public int StartingPrice { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemImageHref { get; set; }
        public ItemCondition Condition { get; set; }
        public DateTime EndDate { get; set; }
    }
}
