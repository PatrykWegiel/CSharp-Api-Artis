using System;

namespace Artis.Api.ViewModels
{
    public class BidViewModel
    {
        public int BidId { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public int Amount { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
