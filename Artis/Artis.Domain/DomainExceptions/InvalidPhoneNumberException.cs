using System;

namespace Artis.Domain.DomainExceptions
{
    public class InvalidPhoneNumberException : Exception
    {
        public InvalidPhoneNumberException(string PhoneNumber) : base(ModifyMessage(PhoneNumber)) { }

        private static string ModifyMessage(string PhoneNumber)
        {
            return $"Invalid phone number: {PhoneNumber}";
        }
    }
}
