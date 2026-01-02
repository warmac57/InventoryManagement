-- =============================================
-- Inventory Management System - Sample Data Script
-- Version: 1.0
-- =============================================

USE [InventoryManagement];
GO

-- =============================================
-- Insert Users (Password is 'password123' hashed with SHA256)
-- For testing, use plain text comparison in development
-- =============================================
INSERT INTO [dbo].[USER] ([Username], [Password_Hash], [Role], [Is_Active])
VALUES
    ('admin', 'EF92B778BAFE771E89245B89ECBC08A44A4E166C06659911881F383D4473E94F', 'Administrator', 1),
    ('manager', 'EF92B778BAFE771E89245B89ECBC08A44A4E166C06659911881F383D4473E94F', 'Manager', 1),
    ('sales', 'EF92B778BAFE771E89245B89ECBC08A44A4E166C06659911881F383D4473E94F', 'Sales', 1),
    ('warehouse', 'EF92B778BAFE771E89245B89ECBC08A44A4E166C06659911881F383D4473E94F', 'Warehouse', 1),
    ('purchasing', 'EF92B778BAFE771E89245B89ECBC08A44A4E166C06659911881F383D4473E94F', 'Purchasing', 1);
GO

-- =============================================
-- Insert Store Settings
-- =============================================
INSERT INTO [dbo].[STORE_SETTINGS] ([Setting_Name], [Setting_Value], [Data_Type], [Description], [Modified_By_User_ID])
VALUES
    ('Negative_Stock_Allowed', 'False', 'Boolean', 'Allow stock to go negative', 1),
    ('In_Stock_Check', 'True', 'Boolean', 'Check stock availability before order', 1),
    ('Moving_Average_Price', 'True', 'Boolean', 'Use moving average for item costing', 1),
    ('Company_Name', 'Inventory Solutions Inc.', 'String', 'Company name for reports', 1),
    ('Tax_Rate', '8.25', 'Decimal', 'Default tax rate percentage', 1),
    ('Default_Currency', 'USD', 'String', 'Default currency code', 1),
    ('Auto_Generate_Order_Number', 'True', 'Boolean', 'Auto-generate order numbers', 1),
    ('Auto_Generate_Purchase_Number', 'True', 'Boolean', 'Auto-generate purchase numbers', 1),
    ('Order_Number_Prefix', 'ORD-', 'String', 'Prefix for order numbers', 1),
    ('Purchase_Number_Prefix', 'PO-', 'String', 'Prefix for purchase order numbers', 1);
GO

-- =============================================
-- Insert LOV (List of Values)
-- =============================================
INSERT INTO [dbo].[LOV] ([LOV_Type], [LOV_Code], [LOV_Value], [Display_Order], [Is_Active])
VALUES
    -- Order Status
    ('ORDER_STATUS', 'DRAFT', 'Draft', 1, 1),
    ('ORDER_STATUS', 'SUBMITTED', 'Submitted', 2, 1),
    ('ORDER_STATUS', 'APPROVED', 'Approved', 3, 1),
    ('ORDER_STATUS', 'PROCESSING', 'Processing', 4, 1),
    ('ORDER_STATUS', 'SHIPPED', 'Shipped', 5, 1),
    ('ORDER_STATUS', 'DELIVERED', 'Delivered', 6, 1),
    ('ORDER_STATUS', 'CANCELLED', 'Cancelled', 7, 1),

    -- Purchase Status
    ('PURCHASE_STATUS', 'DRAFT', 'Draft', 1, 1),
    ('PURCHASE_STATUS', 'APPROVED', 'Approved', 2, 1),
    ('PURCHASE_STATUS', 'SENT', 'Sent to Supplier', 3, 1),
    ('PURCHASE_STATUS', 'PARTIAL', 'Partially Received', 4, 1),
    ('PURCHASE_STATUS', 'RECEIVED', 'Received', 5, 1),
    ('PURCHASE_STATUS', 'COMPLETED', 'Completed', 6, 1),
    ('PURCHASE_STATUS', 'CANCELLED', 'Cancelled', 7, 1),

    -- Count Status
    ('COUNT_STATUS', 'INITIATED', 'Initiated', 1, 1),
    ('COUNT_STATUS', 'IN_PROGRESS', 'In Progress', 2, 1),
    ('COUNT_STATUS', 'COMPLETED', 'Completed', 3, 1),
    ('COUNT_STATUS', 'APPLIED', 'Applied', 4, 1),

    -- Payment Methods
    ('PAYMENT_METHOD', 'CASH', 'Cash', 1, 1),
    ('PAYMENT_METHOD', 'CHECK', 'Check', 2, 1),
    ('PAYMENT_METHOD', 'CREDIT', 'Credit Card', 3, 1),
    ('PAYMENT_METHOD', 'WIRE', 'Wire Transfer', 4, 1),
    ('PAYMENT_METHOD', 'NET', 'Net Terms', 5, 1),

    -- Currency
    ('CURRENCY', 'USD', 'US Dollar', 1, 1),
    ('CURRENCY', 'EUR', 'Euro', 2, 1),
    ('CURRENCY', 'GBP', 'British Pound', 3, 1),
    ('CURRENCY', 'CAD', 'Canadian Dollar', 4, 1),

    -- Transaction Types
    ('TRANSACTION_TYPE', 'PURCHASE', 'Purchase Receipt', 1, 1),
    ('TRANSACTION_TYPE', 'SALE', 'Sale/Order', 2, 1),
    ('TRANSACTION_TYPE', 'ADJUSTMENT', 'Inventory Adjustment', 3, 1),
    ('TRANSACTION_TYPE', 'COUNT', 'Physical Count', 4, 1),
    ('TRANSACTION_TYPE', 'TRANSFER', 'Stock Transfer', 5, 1),

    -- User Roles
    ('USER_ROLE', 'ADMIN', 'Administrator', 1, 1),
    ('USER_ROLE', 'MANAGER', 'Manager', 2, 1),
    ('USER_ROLE', 'SALES', 'Sales User', 3, 1),
    ('USER_ROLE', 'WAREHOUSE', 'Warehouse Staff', 4, 1),
    ('USER_ROLE', 'PURCHASING', 'Purchasing Agent', 5, 1);
GO

-- =============================================
-- Insert Payment Terms
-- =============================================
INSERT INTO [dbo].[PAYMENT_TERM] ([Term_Code], [Term_Description], [Days_Due], [Discount_Percent], [Discount_Days], [Is_Active])
VALUES
    ('COD', 'Cash on Delivery', 0, 0, 0, 1),
    ('NET15', 'Net 15 Days', 15, 0, 0, 1),
    ('NET30', 'Net 30 Days', 30, 0, 0, 1),
    ('NET60', 'Net 60 Days', 60, 0, 0, 1),
    ('2/10NET30', '2% 10 Days, Net 30', 30, 2.00, 10, 1),
    ('PREPAID', 'Prepaid', 0, 0, 0, 1);
GO

-- =============================================
-- Insert Categories
-- =============================================
INSERT INTO [dbo].[CATEGORY] ([Category_Name], [Description], [Parent_Category_ID], [Is_Active])
VALUES
    ('Electronics', 'Electronic devices and components', NULL, 1),
    ('Office Supplies', 'Office and stationery supplies', NULL, 1),
    ('Hardware', 'Tools and hardware items', NULL, 1),
    ('Furniture', 'Office and home furniture', NULL, 1);
GO

-- Insert Sub-categories
INSERT INTO [dbo].[CATEGORY] ([Category_Name], [Description], [Parent_Category_ID], [Is_Active])
VALUES
    ('Computers', 'Desktop and laptop computers', 1, 1),
    ('Peripherals', 'Computer peripherals and accessories', 1, 1),
    ('Networking', 'Network equipment and cables', 1, 1),
    ('Paper Products', 'Paper and printing supplies', 2, 1),
    ('Writing Instruments', 'Pens, pencils, markers', 2, 1),
    ('Power Tools', 'Electric and battery powered tools', 3, 1),
    ('Hand Tools', 'Manual tools and equipment', 3, 1),
    ('Desks', 'Office desks and workstations', 4, 1),
    ('Chairs', 'Office and guest chairs', 4, 1);
GO

-- =============================================
-- Insert Units of Measure
-- =============================================
INSERT INTO [dbo].[UNIT_OF_MEASURE] ([UoM_Code], [UoM_Name], [Conversion_Factor], [Is_Active])
VALUES
    ('EA', 'Each', 1, 1),
    ('PK', 'Pack', 1, 1),
    ('BX', 'Box', 1, 1),
    ('CS', 'Case', 1, 1),
    ('DZ', 'Dozen', 12, 1),
    ('FT', 'Feet', 1, 1),
    ('M', 'Meter', 3.28084, 1),
    ('LB', 'Pound', 1, 1),
    ('KG', 'Kilogram', 2.20462, 1),
    ('GAL', 'Gallon', 1, 1),
    ('LT', 'Liter', 0.264172, 1);
GO

-- =============================================
-- Insert Suppliers
-- =============================================
INSERT INTO [dbo].[SUPPLIER] ([Supplier_Code], [Supplier_Name], [Contact_Person], [Email], [Phone], [Address], [City], [State], [Zip_Code], [Country], [Is_Active])
VALUES
    ('SUP001', 'Tech Distributors Inc.', 'John Smith', 'john@techdist.com', '555-0101', '123 Tech Blvd', 'San Jose', 'CA', '95134', 'USA', 1),
    ('SUP002', 'Office Plus Wholesale', 'Mary Johnson', 'mary@officeplus.com', '555-0102', '456 Commerce St', 'Chicago', 'IL', '60601', 'USA', 1),
    ('SUP003', 'Global Hardware Supply', 'Robert Brown', 'robert@globalhw.com', '555-0103', '789 Industrial Ave', 'Houston', 'TX', '77001', 'USA', 1),
    ('SUP004', 'Furniture World Ltd.', 'Susan Davis', 'susan@furnitureworld.com', '555-0104', '321 Design Center', 'Atlanta', 'GA', '30301', 'USA', 1),
    ('SUP005', 'Electronic Components Co.', 'Mike Wilson', 'mike@eleccomp.com', '555-0105', '654 Circuit Lane', 'Austin', 'TX', '78701', 'USA', 1);
GO

-- =============================================
-- Insert Items
-- =============================================
INSERT INTO [dbo].[ITEM] ([Item_Code], [Item_Name], [Description], [Category_ID], [UoM_ID], [Current_Item_Cost], [Stock_Quantity], [Reorder_Level], [Min_Stock_Level], [Max_Stock_Level], [Track_Inventory], [Is_Active])
VALUES
    -- Electronics - Computers
    ('COMP-001', 'Desktop Computer - Standard', '15.6" laptop with i5 processor', 5, 1, 599.99, 25, 10, 5, 50, 1, 1),
    ('COMP-002', 'Desktop Computer - Premium', '17.3" laptop with i7 processor', 5, 1, 999.99, 15, 5, 3, 30, 1, 1),
    ('COMP-003', 'Laptop - Business', '14" business laptop', 5, 1, 849.99, 20, 8, 4, 40, 1, 1),

    -- Electronics - Peripherals
    ('PERI-001', 'Wireless Mouse', 'Ergonomic wireless mouse', 6, 1, 29.99, 100, 25, 10, 200, 1, 1),
    ('PERI-002', 'Mechanical Keyboard', 'RGB mechanical keyboard', 6, 1, 79.99, 50, 15, 10, 100, 1, 1),
    ('PERI-003', '24" Monitor', 'Full HD LED monitor', 6, 1, 199.99, 30, 10, 5, 60, 1, 1),
    ('PERI-004', 'Webcam HD', '1080p HD webcam', 6, 1, 59.99, 40, 15, 10, 80, 1, 1),

    -- Electronics - Networking
    ('NET-001', 'Network Cable Cat6 - 10ft', 'Category 6 ethernet cable', 7, 1, 8.99, 200, 50, 25, 500, 1, 1),
    ('NET-002', 'Wireless Router', 'Dual-band WiFi 6 router', 7, 1, 129.99, 25, 10, 5, 50, 1, 1),
    ('NET-003', 'Network Switch 8-Port', 'Gigabit ethernet switch', 7, 1, 49.99, 20, 8, 4, 40, 1, 1),

    -- Office Supplies - Paper
    ('PAP-001', 'Copy Paper - Ream', '500 sheets, 20lb white paper', 8, 2, 4.99, 500, 100, 50, 1000, 1, 1),
    ('PAP-002', 'Legal Pads - Pack', 'Yellow legal pads, 12 pack', 8, 2, 12.99, 100, 25, 10, 200, 1, 1),
    ('PAP-003', 'Sticky Notes - Pack', '3x3 sticky notes, 12 pack', 8, 2, 8.99, 150, 40, 20, 300, 1, 1),

    -- Office Supplies - Writing
    ('PEN-001', 'Ballpoint Pens - Box', 'Black ink, 12 pack', 9, 3, 6.99, 200, 50, 25, 400, 1, 1),
    ('PEN-002', 'Permanent Markers - Pack', 'Assorted colors, 8 pack', 9, 2, 9.99, 100, 25, 15, 200, 1, 1),
    ('PEN-003', 'Highlighters - Pack', 'Assorted colors, 6 pack', 9, 2, 5.99, 120, 30, 15, 250, 1, 1),

    -- Hardware - Power Tools
    ('PWR-001', 'Cordless Drill', '20V lithium battery drill', 10, 1, 89.99, 15, 5, 3, 30, 1, 1),
    ('PWR-002', 'Circular Saw', '7-1/4" circular saw', 10, 1, 129.99, 10, 4, 2, 20, 1, 1),

    -- Hardware - Hand Tools
    ('HND-001', 'Hammer - 16oz', 'Claw hammer with fiberglass handle', 11, 1, 19.99, 30, 10, 5, 60, 1, 1),
    ('HND-002', 'Screwdriver Set', '10-piece precision set', 11, 1, 24.99, 25, 8, 4, 50, 1, 1),
    ('HND-003', 'Tape Measure - 25ft', 'Heavy duty tape measure', 11, 1, 14.99, 40, 15, 8, 80, 1, 1),

    -- Furniture - Desks
    ('DSK-001', 'Office Desk - Standard', '60" x 30" laminate desk', 12, 1, 249.99, 10, 3, 2, 20, 1, 1),
    ('DSK-002', 'Standing Desk', 'Electric height adjustable desk', 12, 1, 449.99, 8, 3, 2, 15, 1, 1),

    -- Furniture - Chairs
    ('CHR-001', 'Office Chair - Standard', 'Ergonomic mesh back chair', 13, 1, 149.99, 20, 5, 3, 40, 1, 1),
    ('CHR-002', 'Executive Chair', 'Leather executive chair', 13, 1, 349.99, 10, 3, 2, 20, 1, 1),
    ('CHR-003', 'Guest Chair', 'Stackable guest chair', 13, 1, 79.99, 30, 10, 5, 60, 1, 1);
GO

-- =============================================
-- Insert Sample Orders
-- =============================================
INSERT INTO [dbo].[ORDER_HEADER] ([Order_Number], [Order_Date], [Customer_Name], [Customer_Contact], [Payment_Term_ID], [Payment_Method], [Currency], [Order_Status], [Subtotal], [Tax_Amount], [Total_Amount], [Notes], [Created_By_User_ID])
VALUES
    ('ORD-2024-0001', DATEADD(DAY, -10, GETDATE()), 'Acme Corporation', 'John Doe', 3, 'NET', 'USD', 'Delivered', 1299.95, 107.25, 1407.20, 'Regular customer order', 3),
    ('ORD-2024-0002', DATEADD(DAY, -5, GETDATE()), 'Tech Solutions LLC', 'Jane Smith', 3, 'CREDIT', 'USD', 'Processing', 2549.93, 210.37, 2760.30, 'Priority order', 3),
    ('ORD-2024-0003', GETDATE(), 'StartUp Inc.', 'Bob Wilson', 2, 'CHECK', 'USD', 'Draft', 899.97, 74.25, 974.22, 'New customer', 3);
GO

INSERT INTO [dbo].[ORDER_LINE] ([Order_ID], [Line_Number], [Item_ID], [Quantity], [Unit_Price], [Discount_Percent], [Line_Total])
VALUES
    -- Order 1 lines
    (1, 1, 4, 10, 29.99, 0, 299.90),
    (1, 2, 1, 1, 599.99, 0, 599.99),
    (1, 3, 11, 80, 4.99, 0, 399.20),

    -- Order 2 lines
    (2, 1, 2, 2, 999.99, 0, 1999.98),
    (2, 2, 5, 5, 79.99, 0, 399.95),
    (2, 3, 6, 2, 199.99, 25, 299.99),

    -- Order 3 lines
    (3, 1, 3, 1, 849.99, 0, 849.99),
    (3, 2, 4, 2, 29.99, 0, 59.98);
GO

-- =============================================
-- Insert Sample Purchases
-- =============================================
INSERT INTO [dbo].[PURCHASE_HEADER] ([Purchase_Number], [Purchase_Date], [Supplier_ID], [Purchase_Status], [Subtotal], [Tax_Amount], [Total_Amount], [Expected_Date], [Notes], [Created_By_User_ID])
VALUES
    ('PO-2024-0001', DATEADD(DAY, -15, GETDATE()), 1, 'Received', 5999.90, 494.99, 6494.89, DATEADD(DAY, -10, GETDATE()), 'Quarterly computer order', 5),
    ('PO-2024-0002', DATEADD(DAY, -7, GETDATE()), 2, 'Received', 1249.50, 103.08, 1352.58, DATEADD(DAY, -2, GETDATE()), 'Office supplies restock', 5),
    ('PO-2024-0003', GETDATE(), 3, 'Approved', 899.85, 74.24, 974.09, DATEADD(DAY, 7, GETDATE()), 'Hardware tools order', 5);
GO

INSERT INTO [dbo].[PURCHASE_ITEM] ([Purchase_ID], [Line_Number], [Item_ID], [Quantity], [Unit_Cost], [Line_Total])
VALUES
    -- Purchase 1 lines
    (1, 1, 1, 10, 599.99, 5999.90),

    -- Purchase 2 lines
    (2, 1, 11, 200, 4.99, 998.00),
    (2, 2, 14, 50, 6.99, 349.50),

    -- Purchase 3 lines
    (3, 1, 17, 5, 89.99, 449.95),
    (3, 2, 19, 10, 19.99, 199.90),
    (3, 3, 20, 10, 24.99, 249.90);
GO

-- =============================================
-- Insert Sample Stock History
-- =============================================
INSERT INTO [dbo].[STOCK_HISTORY] ([Item_ID], [Transaction_Date], [Transaction_Type], [Reference_ID], [Reference_Type], [Quantity_Change], [Stock_Before], [Stock_After], [Unit_Cost], [User_ID], [Notes])
VALUES
    -- Initial stock loading
    (1, DATEADD(DAY, -30, GETDATE()), 'ADJUSTMENT', NULL, 'Initial Load', 25, 0, 25, 599.99, 1, 'Initial inventory setup'),
    (4, DATEADD(DAY, -30, GETDATE()), 'ADJUSTMENT', NULL, 'Initial Load', 100, 0, 100, 29.99, 1, 'Initial inventory setup'),
    (11, DATEADD(DAY, -30, GETDATE()), 'ADJUSTMENT', NULL, 'Initial Load', 500, 0, 500, 4.99, 1, 'Initial inventory setup'),

    -- Purchase receipts
    (1, DATEADD(DAY, -10, GETDATE()), 'PURCHASE', 1, 'PO-2024-0001', 10, 25, 35, 599.99, 4, 'Received from PO'),
    (11, DATEADD(DAY, -2, GETDATE()), 'PURCHASE', 2, 'PO-2024-0002', 200, 500, 700, 4.99, 4, 'Received from PO'),

    -- Sales
    (4, DATEADD(DAY, -10, GETDATE()), 'SALE', 1, 'ORD-2024-0001', -10, 100, 90, 29.99, 3, 'Sold on order'),
    (1, DATEADD(DAY, -10, GETDATE()), 'SALE', 1, 'ORD-2024-0001', -1, 35, 34, 599.99, 3, 'Sold on order');
GO

-- =============================================
-- Insert Sample Inventory Counts
-- =============================================
INSERT INTO [dbo].[INVENTORY_COUNT] ([Count_Date], [Item_ID], [System_Quantity], [Quantity_Counted], [Quantity_Change], [Unit_Cost], [Variance_Value], [Count_Status], [Counted_By_User_ID], [Notes])
VALUES
    (DATEADD(DAY, -20, GETDATE()), 4, 100, 98, -2, 29.99, -59.98, 'Applied', 4, 'Minor variance - possible damage'),
    (DATEADD(DAY, -20, GETDATE()), 11, 500, 502, 2, 4.99, 9.98, 'Applied', 4, 'Found extra stock');
GO

PRINT 'Sample data inserted successfully.';
PRINT '';
PRINT 'Test Login Credentials:';
PRINT '------------------------';
PRINT 'Username: admin     Password: password123     Role: Administrator';
PRINT 'Username: manager   Password: password123     Role: Manager';
PRINT 'Username: sales     Password: password123     Role: Sales';
PRINT 'Username: warehouse Password: password123     Role: Warehouse';
PRINT 'Username: purchasing Password: password123    Role: Purchasing';
GO
