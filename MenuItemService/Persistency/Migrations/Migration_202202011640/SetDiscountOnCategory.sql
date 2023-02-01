CREATE OR ALTER PROCEDURE SetDiscountOnCategory @Discount int, @CategoryName nvarchar(50), @MinPrice decimal(19,5)=NULL, @MaxPrice decimal(19,5)=NULL
AS
DECLARE @sql nvarchar(1000)
DECLARE @priceFilter nvarchar(50)
DECLARE @paramDefinition nvarchar(max)
CREATE TABLE #menuItemNames ( MenuItemName nvarchar(max) )
SET @sql = 'INSERT INTO #menuItemNames (MenuItemName) SELECT MenuItem.Name FROM MenuItem INNER JOIN Category ON MenuItem.CategoryId = Category.Id WHERE Category.Name = @categoryName'
SET @priceFilter = CASE 
WHEN @MinPrice IS NULL AND @MaxPrice IS NOT NULL THEN ' AND MenuItem.Price < @maxPrice'
WHEN @MinPrice IS NOT NULL AND @MaxPrice IS NULL THEN ' AND MenuItem.Price > @minPrice'
WHEN @MinPrice IS NOT NULL AND @MaxPrice IS NOT NULL THEN ' AND MenuItem.Price BETWEEN @minPrice AND @maxPrice'
ELSE ''
END
SET @sql = @sql + @priceFilter
SET @paramDefinition = '@categoryName nvarchar(50), @minPrice decimal(19,5), @maxPrice decimal(19,5)'
EXEC sp_executesql @sql, @paramDefinition, @categoryName = @CategoryName, @minPrice = @MinPrice, @maxPrice = @MaxPrice 
SELECT * FROM #menuItemNames
DECLARE @menuItemName nvarchar(max)
DECLARE cursor_menuItem CURSOR FOR SELECT MenuItemName FROM #menuItemNames
OPEN cursor_menuItem
FETCH NEXT FROM cursor_menuItem INTO @menuItemName
WHILE @@FETCH_STATUS = 0 
	BEGIN
	PRINT(@menuItemName)
	UPDATE MenuItem SET Price = Price * (1 - @Discount/100.0) WHERE Name = @menuItemName
	FETCH NEXT FROM cursor_menuItem INTO @menuItemName
	END
CLOSE cursor_menuItem;  
DEALLOCATE cursor_menuItem; 