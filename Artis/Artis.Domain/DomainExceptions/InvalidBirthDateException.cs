using System;

namespace Artis.Domain.DomainExceptions
{
    public class InvalidBirthDateException : Exception
    {
        public InvalidBirthDateException(DateTime BirthDate) : base(ModifyMessage(BirthDate)) { }

        private static string ModifyMessage(DateTime BirthDate)
        {
            return $"Invalid birth date: {BirthDate}";
        }
    }
}
