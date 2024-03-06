using System;

namespace Artis.Data.Sql.DAO
{
    public class Opinion
    {
        public int OpinionId { get; set; }
        public int AuthorId { get; set; }
        public int RatedUserId { get; set; }
        public int Rate { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Banned { get; set; }
        public virtual User Author { get; set; }
        public virtual User RatedUser { get; set; }

    }
}
