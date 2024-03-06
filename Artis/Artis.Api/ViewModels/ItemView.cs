using Artis.Common.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Artis.Api.ViewModels
{
    public class ItemViewModel
    {
        
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
    }
}
