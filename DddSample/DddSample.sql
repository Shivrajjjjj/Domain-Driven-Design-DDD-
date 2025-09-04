-- Create Database
CREATE DATABASE DddSampleDb;
GO

USE DddSampleDb;
GO

CREATE TABLE [Products] (
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [Sku] NVARCHAR(50) NOT NULL,
    [Name] NVARCHAR(200) NOT NULL,
    [CreatedAtUtc] DATETIME2 NOT NULL
);

CREATE TABLE [ProductPrice] (
    [Id] INT NOT NULL IDENTITY,
    [ProductId] UNIQUEIDENTIFIER NOT NULL,
    [Currency] NVARCHAR(3) NOT NULL,
    [Amount] DECIMAL(18,2) NOT NULL,
    CONSTRAINT [PK_ProductPrice] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductPrice_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products]([Id]) ON DELETE CASCADE
);

GO
drop table Products;
-- Insert a product
DECLARE @ProductId UNIQUEIDENTIFIER = NEWID();

INSERT INTO [Products] (Id, Sku, Name, CreatedAtUtc)
VALUES (@ProductId, 'SKU001', N'Gaming Laptop', SYSDATETIME());

-- Insert related prices
INSERT INTO [ProductPrice] (ProductId, Currency, Amount)
VALUES (@ProductId, 'USD', 1200.00);

INSERT INTO [ProductPrice] (ProductId, Currency, Amount)
VALUES (@ProductId, 'INR', 95000.00);


-- Insert another product
DECLARE @ProductId2 UNIQUEIDENTIFIER = NEWID();

INSERT INTO [Products] (Id, Sku, Name, CreatedAtUtc)
VALUES (@ProductId2, 'SKU002', N'Wireless Mouse', SYSDATETIME());

INSERT INTO [ProductPrice] (ProductId, Currency, Amount)
VALUES (@ProductId2, 'USD', 25.99);

INSERT INTO [ProductPrice] (ProductId, Currency, Amount)
VALUES (@ProductId2, 'INR', 2100.00);


SELECT * FROM Products;
SELECT * FROM ProductPrice;
