using System.Collections.Generic;

namespace Artis.Data.Sql.DAO
{
    public class Category
    {
        public Category()
        {
            Items = new List<Item>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}