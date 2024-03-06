using Artis.Domain.DomainExceptions;
using System;
using System.Linq;

namespace Artis.Domain.User
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime EditionDate { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Banned { get; private set; }
        public bool Active { get; private set; }

        public User(int UserId, string UserName, string Email, string Name, string Surname, string PhoneNumber,
            DateTime RegistrationDate, DateTime EditionDate, DateTime BirthDate, bool Banned, bool Active)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.Email = Email;
            this.Name = Name;
            this.Surname = Surname;
            this.PhoneNumber = PhoneNumber;
            this.RegistrationDate = RegistrationDate;
            this.EditionDate = EditionDate;
            this.BirthDate = BirthDate;
            this.Banned = Banned;
            this.Active = Active;
        }
        public User(string UserName, string Name, string Surname, string PhoneNumber, string Email, DateTime BirthDate)
        {
            if (PhoneNumber.Length > 9 || !PhoneNumber.All(char.IsDigit)) throw new InvalidPhoneNumberException(PhoneNumber);
            if (BirthDate >= DateTime.UtcNow || BirthDate.AddYears(150) < DateTime.UtcNow) throw new InvalidBirthDateException(BirthDate);
            this.UserName = UserName;
            this.Name = Name;
            this.Surname = Surname;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.BirthDate = BirthDate;
            RegistrationDate = DateTime.UtcNow;
            EditionDate = DateTime.UtcNow;
            Active = true;
            Banned = false;
        }

        public void EditUser(string UserName, string Name, string Surname, string PhoneNumber, string Email)
        {
            this.UserName = UserName;
            this.Name = Name;
            this.Surname = Surname;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            EditionDate = DateTime.UtcNow;
        }
    }
}
