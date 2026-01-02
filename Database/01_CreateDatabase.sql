-- =============================================
-- Inventory Management System - Database Creation Script
-- Version: 1.0
-- =============================================

USE master;
GO

-- Drop database if exists (for development only)
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'InventoryManagement')
BEGIN
    ALTER DATABASE [InventoryManagement] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [InventoryManagement];
END
GO

-- Create database
CREATE DATABASE [InventoryManagement];
GO

USE [InventoryManagement];
GO

-- =============================================
-- USER Table - Authentication and Authorization
-- =============================================
CREATE TABLE [dbo].[USER] (
    [User_ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Username] NVARCHAR(50) NOT NULL,
    [Password_Hash] NVARCHAR(256) NOT NULL,
    [Role] NVARCHAR(50) NOT NULL DEFAULT 'User',
    [Is_Active] BIT NOT NULL DEFAULT 1,
    [Created_Date] DATETIME NOT NULL DEFAULT GETDATE(),
    [Last_Login] DATETIME NULL,
    CONSTRAINT [UQ_User_Username] UNIQUE ([Username])
);
GO

-- =============================================
-- STORE_SETTINGS Table - System Configuration
-- =============================================
CREATE TABLE [dbo].[STORE_SETTINGS] (
    [Setting_ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Setting_Name] NVARCHAR(100) NOT NULL,
    [Setting_Value] NVARCHAR(500) NULL,
    [Data_Type] NVARCHAR(50) NOT NULL DEFAULT 'String',
    [Description] NVARCHAR(500) NULL,
    [Modified_Date] DATETIME NOT NULL DEFAULT GETDATE(),
    [Modified_By_User_ID] INT NULL,
    CONSTRAINT [UQ_StoreSettings_Name] UNIQUE ([Setting_Name]),
    CONSTRAINT [FK_StoreSettings_User] FOREIGN KEY ([Modified_By_User_ID]) REFERENCES [dbo].[USER]([User_ID])
);
GO

-- =============================================
-- LOV Table - List of Values for Dropdowns
-- =============================================
CREATE TABLE [dbo].[LOV] (
    [LOV_ID] INT IDENTITY(1,1) PRIMARY KEY,
    [LOV_Type] NVARCHAR(50) NOT NULL,
    [LOV_Code] NVARCHAR(50) NOT NULL,
    [LOV_Value] NVARCHAR(200) NOT NULL,
    [Display_Order] INT NOT NULL DEFAULT 0,
    [Is_Active] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [UQ_LOV_Code] UNIQUE ([LOV_Type], [LOV_Code])
);
GO

-- =============================================
-- PAYMENT_TERM Table - Payment Terms
-- =============================================
CREATE TABLE [dbo].[PAYMENT_TERM] (
    [Payment_Term_ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Term_Code] NVARCHAR(20) NOT NULL,
    [Term_Description] NVARCHAR(200) NOT NULL,
    [Days_Due] INT NOT NULL DEFAULT 0,
    [Discount_Percent] DECIMAL(5,2) NOT NULL DEFAULT 0,
    [Discount_Days] INT NOT NULL DEFAULT 0,
    [Is_Active] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [UQ_PaymentTerm_Code] UNIQUE ([Term_Code])
);
GO

-- =============================================
-- CATEGORY Table - Product Categories (Hierarchical)
-- =============================================
CREATE TABLE [dbo].[CATEGORY] (
    [Category_ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Category_Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(500) NULL,
    [Parent_Category_ID] INT NULL,
    [Is_Active] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [UQ_Category_Name] UNIQUE ([Category_Name]),
    CONSTRAINT [FK_Category_Parent] FOREIGN KEY ([Parent_Category_ID]) REFERENCES [dbo].[CATEGORY]([Category_ID])
);
GO

-- =============================================
-- UNIT_OF_MEASURE Table - Units of Measurement
-- =============================================
CREATE TABLE [dbo].[UNIT_OF_MEASURE] (
    [UoM_ID] INT IDENTITY(1,1) PRIMARY KEY,
    [UoM_Code] NVARCHAR(20) NOT NULL,
    [UoM_Name] NVARCHAR(100) NOT NULL,
    [Conversion_Factor] DECIMAL(18,6) NOT NULL DEFAULT 1,
    [Is_Active] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [UQ_UoM_Code] UNIQUE ([UoM_Code])
);
GO

-- =============================================
-- SUPPLIER Table - Vendor Information
-- =============================================
CREATE TABLE [dbo].[SUPPLIER] (
    [Supplier_ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Supplier_Code] NVARCHAR(20) NOT NULL,
    [Supplier_Name] NVARCHAR(200) NOT NULL,
    [Contact_Person] NVARCHAR(100) NULL,
    [Email] NVARCHAR(100) NULL,
    [Phone] NVARCHAR(50) NULL,
    [Address] NVARCHAR(500) NULL,
    [City] NVARCHAR(100) NULL,
    [State] NVARCHAR(100) NULL,
    [Zip_Code] NVARCHAR(20) NULL,
    [Country] NVARCHAR(100) NULL,
    [Is_Active] BIT NOT NULL DEFAULT 1,
    [Created_Date] DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [UQ_Supplier_Code] UNIQUE ([Supplier_Code])
);
GO

-- =============================================
-- ITEM Table - Product Master Data
-- =============================================
CREATE TABLE [dbo].[ITEM] (
    [Item_ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Item_Code] NVARCHAR(50) NOT NULL,
    [Item_Name] NVARCHAR(200) NOT NULL,
    [Description] NVARCHAR(1000) NULL,
    [Category_ID] INT NULL,
    [UoM_ID] INT NULL,
    [Current_Item_Cost] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Stock_Quantity] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Reorder_Level] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Min_Stock_Level] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Max_Stock_Level] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Track_Inventory] BIT NOT NULL DEFAULT 1,
    [Is_Active] BIT NOT NULL DEFAULT 1,
    [Created_Date] DATETIME NOT NULL DEFAULT GETDATE(),
    [Modified_Date] DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [UQ_Item_Code] UNIQUE ([Item_Code]),
    CONSTRAINT [FK_Item_Category] FOREIGN KEY ([Category_ID]) REFERENCES [dbo].[CATEGORY]([Category_ID]),
    CONSTRAINT [FK_Item_UoM] FOREIGN KEY ([UoM_ID]) REFERENCES [dbo].[UNIT_OF_MEASURE]([UoM_ID])
);
GO

-- =============================================
-- ORDER_HEADER Table - Sales Order Header
-- =============================================
CREATE TABLE [dbo].[ORDER_HEADER] (
    [Order_ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Order_Number] NVARCHAR(50) NOT NULL,
    [Order_Date] DATETIME NOT NULL DEFAULT GETDATE(),
    [Customer_ID] INT NULL,
    [Customer_Name] NVARCHAR(200) NOT NULL,
    [Customer_Contact] NVARCHAR(100) NULL,
    [Payment_Term_ID] INT NULL,
    [Payment_Method] NVARCHAR(50) NULL,
    [Currency] NVARCHAR(10) NULL DEFAULT 'USD',
    [Order_Status] NVARCHAR(50) NOT NULL DEFAULT 'Draft',
    [Subtotal] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Tax_Amount] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Total_Amount] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Delivery_Date] DATETIME NULL,
    [Delivery_Address] NVARCHAR(500) NULL,
    [Notes] NVARCHAR(1000) NULL,
    [Is_Approved] BIT NOT NULL DEFAULT 0,
    [Approved_By_User_ID] INT NULL,
    [Approved_Date] DATETIME NULL,
    [Created_Date] DATETIME NOT NULL DEFAULT GETDATE(),
    [Created_By_User_ID] INT NULL,
    CONSTRAINT [UQ_OrderHeader_Number] UNIQUE ([Order_Number]),
    CONSTRAINT [FK_OrderHeader_PaymentTerm] FOREIGN KEY ([Payment_Term_ID]) REFERENCES [dbo].[PAYMENT_TERM]([Payment_Term_ID]),
    CONSTRAINT [FK_OrderHeader_ApprovedBy] FOREIGN KEY ([Approved_By_User_ID]) REFERENCES [dbo].[USER]([User_ID]),
    CONSTRAINT [FK_OrderHeader_CreatedBy] FOREIGN KEY ([Created_By_User_ID]) REFERENCES [dbo].[USER]([User_ID])
);
GO

-- =============================================
-- ORDER_LINE Table - Sales Order Lines
-- =============================================
CREATE TABLE [dbo].[ORDER_LINE] (
    [Order_Line_ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Order_ID] INT NOT NULL,
    [Line_Number] INT NOT NULL,
    [Item_ID] INT NOT NULL,
    [Quantity] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Unit_Price] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Discount_Percent] DECIMAL(5,2) NOT NULL DEFAULT 0,
    [Line_Total] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Notes] NVARCHAR(500) NULL,
    [Created_Date] DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [FK_OrderLine_OrderHeader] FOREIGN KEY ([Order_ID]) REFERENCES [dbo].[ORDER_HEADER]([Order_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderLine_Item] FOREIGN KEY ([Item_ID]) REFERENCES [dbo].[ITEM]([Item_ID])
);
GO

-- =============================================
-- PURCHASE_HEADER Table - Purchase Order Header
-- =============================================
CREATE TABLE [dbo].[PURCHASE_HEADER] (
    [Purchase_ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Purchase_Number] NVARCHAR(50) NOT NULL,
    [Purchase_Date] DATETIME NOT NULL DEFAULT GETDATE(),
    [Supplier_ID] INT NOT NULL,
    [Purchase_Status] NVARCHAR(50) NOT NULL DEFAULT 'Draft',
    [Subtotal] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Tax_Amount] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Total_Amount] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Expected_Date] DATETIME NULL,
    [Received_Date] DATETIME NULL,
    [Notes] NVARCHAR(1000) NULL,
    [Is_Received] BIT NOT NULL DEFAULT 0,
    [Received_By_User_ID] INT NULL,
    [Created_Date] DATETIME NOT NULL DEFAULT GETDATE(),
    [Created_By_User_ID] INT NULL,
    CONSTRAINT [UQ_PurchaseHeader_Number] UNIQUE ([Purchase_Number]),
    CONSTRAINT [FK_PurchaseHeader_Supplier] FOREIGN KEY ([Supplier_ID]) REFERENCES [dbo].[SUPPLIER]([Supplier_ID]),
    CONSTRAINT [FK_PurchaseHeader_ReceivedBy] FOREIGN KEY ([Received_By_User_ID]) REFERENCES [dbo].[USER]([User_ID]),
    CONSTRAINT [FK_PurchaseHeader_CreatedBy] FOREIGN KEY ([Created_By_User_ID]) REFERENCES [dbo].[USER]([User_ID])
);
GO

-- =============================================
-- PURCHASE_ITEM Table - Purchase Order Lines
-- =============================================
CREATE TABLE [dbo].[PURCHASE_ITEM] (
    [Purchase_Item_ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Purchase_ID] INT NOT NULL,
    [Line_Number] INT NOT NULL,
    [Item_ID] INT NOT NULL,
    [Quantity] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Unit_Cost] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Line_Total] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Notes] NVARCHAR(500) NULL,
    [Created_Date] DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [FK_PurchaseItem_PurchaseHeader] FOREIGN KEY ([Purchase_ID]) REFERENCES [dbo].[PURCHASE_HEADER]([Purchase_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_PurchaseItem_Item] FOREIGN KEY ([Item_ID]) REFERENCES [dbo].[ITEM]([Item_ID])
);
GO

-- =============================================
-- STOCK_HISTORY Table - Audit Trail for Stock Movements
-- =============================================
CREATE TABLE [dbo].[STOCK_HISTORY] (
    [History_ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Item_ID] INT NOT NULL,
    [Transaction_Date] DATETIME NOT NULL DEFAULT GETDATE(),
    [Transaction_Type] NVARCHAR(50) NOT NULL,
    [Reference_ID] INT NULL,
    [Reference_Type] NVARCHAR(50) NULL,
    [Quantity_Change] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Stock_Before] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Stock_After] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Unit_Cost] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [User_ID] INT NULL,
    [Notes] NVARCHAR(500) NULL,
    [Created_Date] DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [FK_StockHistory_Item] FOREIGN KEY ([Item_ID]) REFERENCES [dbo].[ITEM]([Item_ID]),
    CONSTRAINT [FK_StockHistory_User] FOREIGN KEY ([User_ID]) REFERENCES [dbo].[USER]([User_ID])
);
GO

-- =============================================
-- INVENTORY_COUNT Table - Physical Inventory Counts
-- =============================================
CREATE TABLE [dbo].[INVENTORY_COUNT] (
    [Count_ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Count_Date] DATETIME NOT NULL DEFAULT GETDATE(),
    [Item_ID] INT NOT NULL,
    [System_Quantity] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Quantity_Counted] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Quantity_Change] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Unit_Cost] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Variance_Value] DECIMAL(18,4) NOT NULL DEFAULT 0,
    [Count_Status] NVARCHAR(50) NOT NULL DEFAULT 'Initiated',
    [Counted_By_User_ID] INT NULL,
    [Approved_By_User_ID] INT NULL,
    [Approved_Date] DATETIME NULL,
    [Notes] NVARCHAR(500) NULL,
    [Created_Date] DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [FK_InventoryCount_Item] FOREIGN KEY ([Item_ID]) REFERENCES [dbo].[ITEM]([Item_ID]),
    CONSTRAINT [FK_InventoryCount_CountedBy] FOREIGN KEY ([Counted_By_User_ID]) REFERENCES [dbo].[USER]([User_ID]),
    CONSTRAINT [FK_InventoryCount_ApprovedBy] FOREIGN KEY ([Approved_By_User_ID]) REFERENCES [dbo].[USER]([User_ID])
);
GO

-- =============================================
-- Create Indexes for Performance
-- =============================================
CREATE INDEX [IX_Item_Category] ON [dbo].[ITEM]([Category_ID]);
CREATE INDEX [IX_Item_Active] ON [dbo].[ITEM]([Is_Active]);
CREATE INDEX [IX_OrderHeader_Status] ON [dbo].[ORDER_HEADER]([Order_Status]);
CREATE INDEX [IX_OrderHeader_Date] ON [dbo].[ORDER_HEADER]([Order_Date]);
CREATE INDEX [IX_OrderLine_OrderID] ON [dbo].[ORDER_LINE]([Order_ID]);
CREATE INDEX [IX_PurchaseHeader_Status] ON [dbo].[PURCHASE_HEADER]([Purchase_Status]);
CREATE INDEX [IX_PurchaseHeader_Supplier] ON [dbo].[PURCHASE_HEADER]([Supplier_ID]);
CREATE INDEX [IX_PurchaseItem_PurchaseID] ON [dbo].[PURCHASE_ITEM]([Purchase_ID]);
CREATE INDEX [IX_StockHistory_Item] ON [dbo].[STOCK_HISTORY]([Item_ID]);
CREATE INDEX [IX_StockHistory_Date] ON [dbo].[STOCK_HISTORY]([Transaction_Date]);
CREATE INDEX [IX_InventoryCount_Item] ON [dbo].[INVENTORY_COUNT]([Item_ID]);
CREATE INDEX [IX_InventoryCount_Status] ON [dbo].[INVENTORY_COUNT]([Count_Status]);
GO

PRINT 'Database and tables created successfully.';
GO
