CREATE PROCEDURE ProductsByPriceRange
	@MinPrice Money,
	@MaxPrice Money
AS
		Select Products.ProductName as ProductsInRange ,
       Products.UnitPrice as ProductPrice
				from Products
				where Products.UnitPrice between @MinPrice and @MaxPrice
				Order by Products.UnitPrice Desc