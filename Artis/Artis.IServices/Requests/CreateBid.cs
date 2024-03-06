namespace Artis.IServices.Requests
{
    public class CreateBid
    {
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public int Amount { get; set; }
    }
}
