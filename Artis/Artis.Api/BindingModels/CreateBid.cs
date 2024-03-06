namespace Artis.Api.BindingModels
{
    public class CreateBid
    {
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public int Amount { get; set; }
    }
}
