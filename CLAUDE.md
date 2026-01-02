# CLAUDE.md - Project Intelligence for Inventory Management System

This file provides context and conventions for Claude Code when working on this project.

## Project Overview

This is a VB.NET Windows Forms application for inventory management using DevExpress WinForms 24.2 components and SQL Server database.

## Technology Stack

- **Language:** VB.NET
- **Framework:** .NET 8.0 Windows Forms
- **UI Components:** DevExpress WinForms 24.2.6
- **Database:** Microsoft SQL Server
- **ORM:** ADO.NET (no Entity Framework)

## Architecture

3-tier architecture with clear separation:

```
Forms/          → Presentation Layer (UI)
BusinessLogic/  → Business Logic Layer
DataAccess/     → Data Access Layer (DAOs)
Entities/       → Domain Models
Common/         → Shared utilities (AppSettings, DatabaseHelper, SessionManager)
```

## Coding Conventions

### Naming

- **Tables:** UPPERCASE with underscores (e.g., `ORDER_HEADER`, `PURCHASE_ITEM`)
- **Columns:** Mixed_Case with underscores (e.g., `Order_Status`, `Item_Name`)
- **Classes:** PascalCase (e.g., `OrderHeader`, `PurchaseItem`)
- **Private fields:** Prefix with underscore (e.g., `_orderId`, `_item`)
- **Controls:** Hungarian notation prefix (e.g., `txtName`, `cboCategory`, `btnSave`, `gridItems`)

### Control Prefixes

| Prefix | Control Type |
|--------|-------------|
| `txt` | TextEdit, MemoEdit |
| `cbo` | LookUpEdit, ComboBoxEdit |
| `chk` | CheckEdit |
| `btn` | SimpleButton |
| `dtp` | DateEdit |
| `grid` | GridControl |
| `lbl` | LabelControl |
| `pnl` | PanelControl |

### Form Patterns

**Designer.vb Files:**
- Must contain full `InitializeComponent()` with all control definitions
- Use `ISupportInitialize` pattern for DevExpress controls (BeginInit/EndInit)
- Declare controls as `Friend WithEvents`
- Include proper namespace: `Namespace Forms.{SubFolder}`

**Code-behind Files (.vb):**
- Keep business logic only - no control creation
- Use `Handles` clause for event handlers
- Grid column setup can remain in code (runtime configuration)

### LookUpEdit Configuration

Always configure LookUpEdit columns explicitly to avoid showing all database columns:

```vb
cboSupplier.Properties.Columns.Clear()
cboSupplier.Properties.Columns.Add(New LookUpColumnInfo("Supplier_Name", "Name", 200))
cboSupplier.Properties.PopupWidth = 220
cboSupplier.Properties.DataSource = _supplierDAO.GetActiveSuppliers()
```

### Database Access Pattern

Use `DatabaseHelper` with `Using` block:

```vb
Using db As New DatabaseHelper()
    Dim result = db.ExecuteScalar(sql)
    ' or
    Dim dt = db.GetDataTable(sql)
End Using
```

### Table Names (IMPORTANT)

Database tables use UPPERCASE names:
- `ITEM` (not Items)
- `CATEGORY` (not Categories)
- `ORDER_HEADER` (not Order_Header)
- `ORDER_LINE`
- `PURCHASE_HEADER`
- `PURCHASE_ITEM`
- `SUPPLIER`
- `USER`
- `STOCK_HISTORY`
- `INVENTORY_COUNT`
- `PAYMENT_TERM`
- `UNIT_OF_MEASURE`
- `STORE_SETTINGS`
- `LOV`

## Build Commands

```bash
# Build
dotnet build

# Run
dotnet run

# Clean and rebuild
dotnet clean && dotnet build
```

## Project Structure

```
InventoryManagement/
├── BusinessLogic/
│   ├── AuthenticationManager.vb
│   ├── InventoryManager.vb
│   ├── OrderManager.vb
│   └── PurchaseManager.vb
├── Common/
│   ├── AppSettings.vb          # Singleton settings
│   ├── DatabaseHelper.vb       # ADO.NET wrapper
│   ├── SessionManager.vb       # User session
│   └── Enums.vb
├── DataAccess/
│   ├── BaseDAO.vb
│   ├── ItemDAO.vb
│   ├── OrderDAO.vb
│   ├── DashboardDAO.vb
│   └── ...
├── Entities/
│   ├── Item.vb
│   ├── OrderHeader.vb
│   └── ...
├── Forms/
│   ├── LoginForm.vb
│   ├── MainForm.vb
│   ├── DashboardForm.vb
│   ├── Admin/
│   ├── Catalog/
│   ├── Orders/
│   ├── Purchases/
│   ├── InventoryControl/
│   └── Reports/
├── Database/
│   ├── 01_CreateDatabase.sql
│   └── 02_SampleData.sql
└── Docs/
    └── mermaid/
```

## DevExpress Components Used

- **RibbonControl** - Main navigation
- **TileControl** - Dashboard tiles
- **ChartControl** - Pie charts
- **GridControl/GridView** - Data grids
- **XtraForm** - Base form class
- **XtraEditors** - TextEdit, LookUpEdit, SpinEdit, DateEdit, CheckEdit, MemoEdit, SimpleButton, LabelControl, PanelControl

## Key Patterns

### Form with Grid (List Forms)

```vb
Public Class ItemListForm
    Private ReadOnly _itemDAO As New ItemDAO()

    Private Sub LoadData()
        gridControl.DataSource = _itemDAO.GetAll()
    End Sub

    Private Sub SetupGrid()
        gridView.Columns.Clear()
        ' Add columns...
    End Sub
End Class
```

### Edit Forms

```vb
Public Class ItemEditForm
    Private _itemId As Integer
    Private _item As Item

    Public Sub New(Optional itemId As Integer = 0)
        _itemId = itemId
        InitializeComponent()
        LoadLookups()
        LoadData()
    End Sub
End Class
```

### DAO Pattern

```vb
Public Class ItemDAO
    Public Function GetAll() As List(Of Item)
        Using db As New DatabaseHelper()
            Dim dt = db.GetDataTable("SELECT * FROM ITEM")
            Return MapToList(dt)
        End Using
    End Function
End Class
```

## Common Issues & Solutions

### "Invalid object name" Error
- Check table name case - use UPPERCASE (e.g., `ITEM` not `Items`)

### LookUpEdit Shows Too Many Columns
- Always configure `Properties.Columns` explicitly before setting `DataSource`

### Form Not Opening in Designer
- Ensure Designer.vb has full control definitions in `InitializeComponent()`
- Check namespace matches between .vb and .Designer.vb files

## Git Workflow

```bash
# Commit format
git commit -m "Brief description of change"

# Push to GitHub
git push origin main
```

## Connection String

Located in `Common/AppSettings.vb`:
```vb
Private Const DEFAULT_CONNECTION_STRING As String = "Server=.\SQLEXPRESS;Database=InventoryManagement;Trusted_Connection=True;TrustServerCertificate=True;"
```

## Testing Credentials

| Username | Password | Role |
|----------|----------|------|
| admin | password123 | Administrator |
| manager | password123 | Manager |
| sales | password123 | Sales |
| warehouse | password123 | Warehouse |
| purchasing | password123 | Purchasing |
