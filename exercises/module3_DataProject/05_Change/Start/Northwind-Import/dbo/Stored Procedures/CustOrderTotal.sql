﻿

CREATE PROCEDURE [dbo].[CustOrderTotal] 
@CustomerID nchar(5),
@TotalSales money OUTPUT
AS
SELECT @TotalSales = SUM(OD.UNITPRICE*(1-OD.DISCOUNT) * OD.QUANTITY)
FROM ORDERS O, "ORDER DETAILS" OD
where O.CUSTOMERID = @CustomerID AND O.ORDERID = OD.ORDERID


