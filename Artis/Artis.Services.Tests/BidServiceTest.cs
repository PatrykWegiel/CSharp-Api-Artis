using Artis.Domain.DomainExceptions;
using Artis.IData.Bid;
using Artis.IServices.Bid;
using Artis.IServices.Requests;
using Artis.Services.Bid;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Artis.Services.Tests
{
    public class BidServiceTest
    {
        private readonly IBidService _bidService;
        private readonly Mock<IBidRepository> _bidRepositoryMock;

        public BidServiceTest()
        {
            _bidRepositoryMock = new Mock<IBidRepository>();
            _bidService = new BidService(_bidRepositoryMock.Object);
        }

        [Fact]
        public void CreateBid_Returns_throws_InvalidBidException()
        {
            var bid = new CreateBid
            {
                ItemId = 1,
                UserId = 1,
                Amount = 0
            };

            Assert.ThrowsAsync<InvalidBidException>(() => _bidService.CreateBid(bid));
        }

        [Fact]
        public async void CreateBid_Returns_Correct_Response()
        {
            int expectedResult = 0;
            var bid = new CreateBid
            {
                ItemId = 1,
                UserId = 1,
                Amount = 10000
            };
            _bidRepositoryMock.Setup(x => x.CreateBid(new Domain.Bid.Bid(
                bid.ItemId,
                bid.UserId,
                bid.UserId))).Returns(Task.FromResult(expectedResult));
            
            var result = await _bidService.CreateBid(bid);

            Assert.IsType<Domain.Bid.Bid>(result);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.BidId);
        }
    }
}
