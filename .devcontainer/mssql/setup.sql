CREATE DATABASE StockslyDb;
GO

USE StockslyDb;

CREATE TABLE [dbo].[Suppliers]
(
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    [Telephone] NVARCHAR (50) NULL,
    [Territory] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Products]
(
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [Code] NVARCHAR (50) NOT NULL,
    [DisplayName] NVARCHAR (50) NOT NULL,
    [ReorderLevel] INT CONSTRAINT [DF_Products_ReorderQuantity] DEFAULT ((100)) NOT NULL,
    [Stocks] INT CONSTRAINT [DF_Products_Stocks] DEFAULT ((100)) NOT NULL,
    [UnitPrice] MONEY NOT NULL,
    [SupplierId] INT NOT NULL,
    [Discontinued] BIT CONSTRAINT [DF_Products_Archived] DEFAULT ((0)) NOT NULL,
    [DiscontinuedDate] DATETIME NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Products_Suppliers] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Suppliers] ([Id])
);
GO

CREATE TABLE [dbo].[PurchaseOrders]
(
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [OrderedTime] DATETIME CONSTRAINT [DF_PurchaseOrders_OrderedTime] DEFAULT (getdate()) NOT NULL,
    [Count] INT CONSTRAINT [DF_PurchaseOrders_Count] DEFAULT ((1)) NOT NULL,
    [Total] MONEY CONSTRAINT [DF_PurchaseOrders_Total] DEFAULT ((0)) NOT NULL,
    [SupplierId] INT NOT NULL,
    [SupplierName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_PurchaseOrders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PurchaseOrders_Suppliers] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Suppliers] ([Id])
);
GO

CREATE TABLE [dbo].[PurchaseOrderItems]
(
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [PurchaseOrderId] INT NOT NULL,
    [ProductId] INT NOT NULL,
    [ProductCode] NVARCHAR (50) NOT NULL,
    [ProductDisplayName] NVARCHAR (50) NOT NULL,
    [Quantity] INT CONSTRAINT [DF_PurchaseOrderItems_Quantity] DEFAULT ((1)) NOT NULL,
    [UnitPrice] MONEY CONSTRAINT [DF_PurchaseOrderItems_UnitPrice] DEFAULT ((0)) NOT NULL,
    [Total] MONEY CONSTRAINT [DF_PurchaseOrderItems_Total] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PurchaseOrderItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PurchaseOrderItems_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]),
    CONSTRAINT [FK_PurchaseOrderItems_PurchaseOrders] FOREIGN KEY ([Id]) REFERENCES [dbo].[PurchaseOrders] ([Id])
);
GO

USE StockslyDb;
GO

PRINT 'Pushing default seed data.';

SET identity_insert dbo.Suppliers ON;
INSERT INTO dbo.Suppliers
    (Id, Name, Telephone, Territory)
VALUES
    (1, 'Ceylone Tobaco', '77944171', 'WWW'),
    (2, 'Neliya Cottah', '11509813', 'LK'),
    (3, 'Thissa Veda Gedara', '342339592', 'LK-WP');
SET identity_insert dbo.Suppliers OFF;

SET identity_insert dbo.Products ON;
INSERT INTO dbo.Products
    (Id, Code, DisplayName, ReorderLevel, Stocks, UnitPrice, SupplierId)
VALUES
    (1, 'COF87992', 'Arabic Blended Coffee Beans', 40, 2000, 1500, 2),
    (2, 'TEA19284', 'Neliya Black Tea', 50, 400, 1350, 1),
    (3, 'HNY08237', 'Kitul Peni', 15, 250, 2730, 3);
SET identity_insert dbo.Products OFF;
