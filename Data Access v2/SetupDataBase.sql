use Northwind

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[getProductsByCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[getProductsByCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[addProduct]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[addProduct]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[updateProduct]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[updateProduct]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[deleteProduct]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[deleteProduct]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[getProductDetails]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[getProductDetails]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[getProductName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[getProductName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[debit]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[debit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[credit]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[credit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Credits]') and OBJECTPROPERTY(id, N'IsTable') = 1)
drop table [dbo].[Credits]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Debits]') and OBJECTPROPERTY(id, N'IsTable') = 1)
drop table [dbo].[Debits]
GO

/* TimeStamp support */
ALTER TABLE Products ADD LastUpdate DateTime

GO

CREATE TRIGGER Products_Insert_tr ON dbo.Products
FOR INSERT
AS

Update 
  Products
Set
  LastUpdate = GetDate()
From
  Products p Inner Join Inserted i On p.ProductID = i.ProductID
Where
  p.ProductID = i.ProductID

GO

CREATE TRIGGER Products_Update_tr ON dbo.Products
FOR UPDATE
AS

Update 
  Products
Set
  LastUpdate = GetDate()
From
  Products p Inner Join Inserted i On p.ProductID = i.ProductID
Where
  p.ProductID = i.ProductID

GO

UPDATE Products SET LastUpdate = GetDate()
GO
/* TimeStamp support */

-- RetrieveDataReader() and RetrieveDataset() samples
CREATE PROCEDURE getProductsByCategory @CategoryID INTEGER
AS
SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice, LastUpdate
FROM Products
WHERE CategoryID = @CategoryID
GO

-- RetrieveSingleRow() sample
CREATE PROCEDURE getProductDetails
	@ProductID int,
	@ProductName nvarchar(40) OUTPUT,
	@UnitPrice money OUTPUT,
	@QtyPerUnit nvarchar(20) OUTPUT
AS
SELECT 	@ProductName = ProductName, 
       	@UnitPrice = UnitPrice,
       	@QtyPerUnit = QuantityPerUnit
FROM Products 
WHERE ProductID = @ProductID
GO

-- LookupSingleItem() sample
CREATE PROCEDURE getProductName @ProductID int
AS
SELECT ProductName
FROM Products
WHERE ProductID = @ProductID
GO


-- PerformTransactionalUpdate() sample
CREATE TABLE Credits
(CreditNo INTEGER IDENTITY,
 AccountNo CHAR(20),
 Amount SMALLMONEY
)
GO
CREATE TABLE Debits
(CreditNo INTEGER IDENTITY,
 AccountNo CHAR(20),
 Amount SMALLMONEY
)
GO
CREATE PROCEDURE credit 
	@AccountNo CHAR(20),
	@Amount SMALLMONEY
AS
INSERT Credits
VALUES
(@AccountNo, @Amount)
GO
CREATE PROCEDURE debit 
	@AccountNo CHAR(20),
	@Amount SMALLMONEY
AS
INSERT Debits
VALUES
(@AccountNo, @Amount)
GO

CREATE PROCEDURE addProduct 
@ProductName nvarchar(40),
@UnitPrice money
AS

INSERT INTO  
  Products (ProductName, UnitPrice)
VALUES 
 (@ProductName, @UnitPrice)

SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice
FROM Products
WHERE ProductID = SCOPE_IDENTITY()
GO

CREATE PROCEDURE updateProduct 
@ProductID int,
@ProductName nvarchar(40),
@LastUpdate datetime
AS

UPDATE
  Products 
SET
  ProductName = @ProductName
WHERE
  ProductID = @ProductID AND
  LastUpdate = @LastUpdate
 
IF @@ROWCOUNT > 0
  -- This statement is used to update the DataSet if changes are done on the updated record (identities, timestamps or triggers )
  SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice
  FROM Products
  WHERE ProductID = @ProductID
GO

CREATE PROCEDURE deleteProduct 
@ProductID int
AS

DELETE Products WHERE ProductID = @ProductID
GO 
