using System;

namespace Artis.Domain.DomainExceptions
{
    public class InvalidBidException : Exception
    {
        public InvalidBidException(int Amount) : base(ModifyMessage(Amount)) { }

        public InvalidBidException(int currentAmount, int newAmount) : base(ModifyMessage(currentAmount, newAmount)) { }

        private static string ModifyMessage(int Amount)
        {
            return $"Bid amount cannot be negative or equal zero. Amount: {Amount}";
        }
        private static string ModifyMessage(int currentAmount, int newAmount)
        {
            return $"New bid amount cannot be lower than current. Current: {currentAmount} New: {newAmount}";
        }
    }
}
