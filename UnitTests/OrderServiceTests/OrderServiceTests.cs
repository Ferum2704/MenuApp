using Moq;
using OrderService.Application.Queries;
using OrderService.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static OrderService.Application.Queries.GetMostPopularMenuItemIdsQuery;

namespace UnitTests.OrderServiceTests
{
    public class OrderServiceTests
    {
        [Fact]
        public void GetMostPopularMenuItemIdsQuery_ReturnListOfMostPopularMenuItemIds()
        {
            var orderRepositoryStub = new Mock<IOrderDapperRepository>();
            orderRepositoryStub.Setup(x => x.GetMostPopularItemsId(It.IsAny<int>())).ReturnsAsync(new List<Guid>()
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
            });
            var getMostPopularMenuItemIdsQueryHandler = new GetMostPopularMenuItemIdsQueryHandler(orderRepositoryStub.Object);
            var getMostPopularMenuItemIdsQuery = new GetMostPopularMenuItemIdsQuery() { ItemsNumber= 1 };
            Task<IEnumerable<Guid>> menuItemsIds = getMostPopularMenuItemIdsQueryHandler
                .Handle(getMostPopularMenuItemIdsQuery, CancellationToken.None);
            Assert.Equal(3, menuItemsIds.Result.Count());
        }
    }
}
