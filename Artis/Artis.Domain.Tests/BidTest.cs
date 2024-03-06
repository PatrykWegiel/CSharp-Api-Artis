using Artis.Domain.DomainExceptions;
using System;
using Xunit;

namespace Artis.Domain.Tests
{
    public class BidTest
    {
        [Fact]
        public void CreateBid_Return_throws_InvalidBidException()
        {
            Assert.Throws<InvalidBidException>(() => new Domain.Bid.Bid(1, 1, 0));
        }

        [Fact]
        public void CreateBid_Return_Correct_Result()
        {
            var bid = new Domain.Bid.Bid(1, 1, 1000);
            Assert.Equal(1, bid.ItemId);
            Assert.Equal(1, bid.UserId);
            Assert.Equal(1000, bid.Amount);
        }
    }
}
