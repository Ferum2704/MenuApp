using MenuItemService.Application.Queries;
using MenuItemService.Domain.IRepositories;
using MenuItemService.Domain.Models;
using MenuItemService.Presentation.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MenuItemService.Application.Queries.GetCategoriesWithMenuItemsQuery;

namespace UnitTestsCopy.MenuItemServiceTests
{
    public class MenuItemServiceTests
    {
        [Fact]
        public void GetCategoriesWithMenuItemsQuery_ReturnsListOfCategoryViewModels()
        {
            var menuItemRepositoryStub = new Mock<IMenuItemDapperRepository>();
            menuItemRepositoryStub.Setup(x => x.GetCategorizedMenuItems()).ReturnsAsync(new List<CategoriedMenuItem>()
            {
                new CategoriedMenuItem()
                {
                    CategoryName= "TestCategoryName1",
                    CategoryId = Guid.NewGuid(),
                    Priority= 1,
                },
                new CategoriedMenuItem()
                {
                    CategoryName= "TestCategoryName2",
                    CategoryId = Guid.NewGuid(),
                    Priority= 2,
                }
            });
            var getCategoriesWithMenuItemsQuery = new GetCategoriesWithMenuItemsQuery();
            var getCategoriesWithMenuItemsQueryHandler = new GetCategoriesWithMenuItemsQueryHandler(menuItemRepositoryStub.Object);
            Task<IEnumerable<CategoryViewModel>> categoriesList = getCategoriesWithMenuItemsQueryHandler
                .Handle(getCategoriesWithMenuItemsQuery, CancellationToken.None);
            Assert.Equal(2, categoriesList.Result.Count());
        }
    }
}
