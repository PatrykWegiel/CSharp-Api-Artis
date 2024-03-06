using System;

namespace Artis.Data.Sql.DAO
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public int BidId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuldingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual Bid Bid { get; set; }

    }
}
