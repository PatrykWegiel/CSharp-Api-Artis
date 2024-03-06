using System;
using System.Collections.Generic;

namespace Artis.Data.Sql.DAO
{
    public class User
    {
        public User()
        {
            Items = new List<Item>();
            UserOpinions = new List<Opinion>();
            UserRating = new List<Opinion>();
            Bids = new List<Bid>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime EditionDate { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Banned { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Opinion> UserRating { get; set; }
        public virtual ICollection<Opinion> UserOpinions { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }

    }
}
