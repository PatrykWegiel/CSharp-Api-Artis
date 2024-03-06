using Artis.Common.Enum;
using System;

namespace Artis.Domain.Item
{
    public class Item
    {
        public int ItemId { get; set; }
        public int CategoryId { get; private set; }
        public int UserId { get; private set; }
        public int StartingPrice { get; private set; }
        public string ItemName { get; private set; }
        public string ItemDescription { get; private set; }
        public string ItemImageHref { get; private set; }
        public ItemCondition Condition { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool Banned { get; private set; }
        public bool Visible { get; private set; }
        public Item(int ItemId, int CategoryId, int UserId, int StartingPrice, string ItemName, string ItemDescription, string ItemImageHref, ItemCondition Condition,
                    DateTime CreationDate, DateTime EndDate, bool Banned, bool Visible)
        {
            this.ItemId = ItemId;
            this.CategoryId = CategoryId;
            this.UserId = UserId;
            this.StartingPrice = StartingPrice;
            this.ItemName = ItemName;
            this.ItemDescription = ItemDescription;
            this.ItemImageHref = ItemImageHref;
            this.Condition = Condition;
            this.CreationDate = CreationDate;
            this.EndDate = EndDate;
            this.Banned = Banned;
            this.Visible = Visible;
        }

        public Item(int CategoryId, int UserId, int StartingPrice, string ItemName, string ItemDescription, string ItemImageHref, ItemCondition Condition, DateTime EndDate)
        {
            this.CategoryId = CategoryId;
            this.UserId = UserId;
            this.StartingPrice = StartingPrice;
            this.ItemName = ItemName;
            this.ItemDescription = ItemDescription;
            this.ItemImageHref = ItemImageHref;
            this.Condition = Condition;
            CreationDate = DateTime.UtcNow;
            this.EndDate = EndDate;
            Banned = false;
            Visible = true;
        }
        public void EditAuctionItem(int CategoryId, int StartingPrice, string ItemName, string ItemDescription, string ItemImageHref, ItemCondition Condition, DateTime EndDate)
        {
            this.CategoryId = CategoryId;
            this.StartingPrice = StartingPrice;
            this.ItemName = ItemName;
            this.ItemDescription = ItemDescription;
            this.ItemImageHref = ItemImageHref;
            this.Condition = Condition;
            this.EndDate = EndDate;
        }
    }
}
