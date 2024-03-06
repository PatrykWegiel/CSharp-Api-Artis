using Artis.Common.Enum;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Artis.Api.BindingModels
{
    public class CreateAuctionItem
    {
        [Required]
        [Display(Name = "CategoryId")]
        public int CategoryId { get; set; }

        [JsonProperty(Required = Required.Always)]
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "StartingPrice")]
        public int StartingPrice { get; set; }

        [Required]
        [Display(Name = "ItemName")]
        public string ItemName { get; set; }

        [Required]
        [Display(Name = "ItemDescription")]
        public string ItemDescription { get; set; }

        [Required]
        [Display(Name = "ItemImageHref")]
        public string ItemImageHref { get; set; }

        [Required]
        [Display(Name = "Condition")]
        public ItemCondition Condition { get; set; }

        [Required]
        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }
    }
}
