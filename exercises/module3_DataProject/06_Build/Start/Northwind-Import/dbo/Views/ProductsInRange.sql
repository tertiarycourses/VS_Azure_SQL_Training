CREATE VIEW ProductsInRange
	AS 
	Select Products.ProductName as ProductsInRange ,
       Products.UnitPrice as ProductPrice
from Products
where Products.UnitPrice between 5 and 10
--Order by Products.UnitPrice Desc