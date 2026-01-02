# Inventory Management System - Complete UML Documentation

## Document Overview

This comprehensive UML documentation suite provides complete design specifications for implementing an Inventory Management System in VB.NET. The documentation follows a structured approach from high-level architecture down to detailed implementation flows.

---

## 📋 Document Set Contents

### 1. **Class Diagram** (`inventory_uml_class_diagram.mermaid`)
**Purpose:** Defines the complete object model with entities, attributes, relationships, and operations.

**Key Features:**
- 13 core entity classes with full attribute definitions
- Method signatures for critical operations
- Cardinality relationships (1-to-many, many-to-one)
- Critical validation points marked with ★
- Self-logging mechanism illustrated

**Use For:**
- Creating VB.NET class files
- Understanding data model relationships
- Implementing business logic methods
- Planning database schema

---

### 2. **Use Case Diagram** (`use_case_diagram.mermaid`)
**Purpose:** Shows all user interactions and system functionality from an actor perspective.

**Key Features:**
- 4 actor types (Administrator, Inventory Manager, Sales User, Purchasing User)
- 18 use cases organized by functional area
- Include/extend relationships showing dependencies
- Shared functionality identification

**Use For:**
- Understanding user roles and permissions
- Planning form/screen development
- Identifying required user workflows
- Scoping feature requirements

---

### 3. **Sequence Diagrams** (3 files)

#### a) `sequence_order_processing.mermaid`
**Purpose:** Order entry and fulfillment flow with stock validation.

**Critical Points:**
- ★ Payment Term validation
- ★ In_Stock_Check setting enforcement
- ★ Stock availability validation
- ★ Self-logging to STOCK_HISTORY

**Use For:**
- Implementing Order Entry Form
- Building stock validation logic
- Understanding order approval workflow
- Creating stock update procedures

#### b) `sequence_purchase_receipt.mermaid`
**Purpose:** Purchase receipt processing with moving average cost calculation.

**Critical Points:**
- ★ Moving_Average_Price setting check
- ★ Detailed cost calculation formula
- ★ Stock increase processing
- ★ Audit trail creation

**Use For:**
- Implementing Purchase Receipt Form
- Building cost calculation engine
- Creating stock receipt procedures
- Understanding inventory valuation

#### c) `sequence_inventory_count.mermaid`
**Purpose:** Physical inventory count with variance handling.

**Critical Points:**
- ★ Variance calculation logic
- ★ Negative stock validation
- ★ Adjustment approval workflow
- ★ History logging for audits

**Use For:**
- Implementing Inventory Count Form
- Building variance analysis
- Creating adjustment procedures
- Handling count exceptions

---

### 4. **Activity Diagrams** (3 files)

#### a) `activity_order_validation.mermaid`
**Purpose:** Decision flow for order line stock validation.

**Decision Points:**
- In_Stock_Check enabled/disabled
- Stock availability check
- Negative_Stock_Allowed setting
- User response to validation failures

**Use For:**
- Implementing OrderLine validation logic
- Creating error handling workflows
- Building user feedback mechanisms
- Understanding settings interaction

#### b) `activity_moving_average.mermaid`
**Purpose:** Step-by-step moving average cost calculation process.

**Process Flow:**
- Current inventory value calculation
- Receipt value calculation
- New average cost formula
- Sanity checks and overrides

**Use For:**
- Implementing cost calculation functions
- Creating purchase receipt logic
- Building calculation validators
- Understanding cost update triggers

#### c) `activity_inventory_count.mermaid`
**Purpose:** Complete inventory count and adjustment workflow.

**Process Flow:**
- Variance calculation
- Positive vs. negative adjustments
- Negative stock validation
- Override approval handling

**Use For:**
- Implementing count adjustment logic
- Creating approval workflows
- Building variance reporting
- Handling exception scenarios

---

### 5. **Component Diagram** (`component_diagram.mermaid`)
**Purpose:** Shows 3-tier architecture with all forms, business managers, and DAOs.

**Architecture Layers:**
- **Presentation Layer:** All Windows Forms organized by function
- **Business Logic Layer:** Manager classes and validation engine
- **Data Access Layer:** DAO pattern with Database Context
- **Database Layer:** SQL Server database

**Use For:**
- Planning VB.NET project structure
- Organizing classes and namespaces
- Understanding tier responsibilities
- Designing dependency injection

---

### 6. **State Diagram** (`state_diagram.mermaid`)
**Purpose:** Lifecycle states and transitions for Orders, Purchases, and Counts.

**Entity Lifecycles:**
- **Order:** Draft → Submitted → Validated → Approved → Ready → Delivered
- **Purchase:** Draft → Approved → Sent → Receiving → Received → Completed
- **Count:** Initiated → In Progress → Complete → Applied

**Use For:**
- Implementing status field enumerations
- Creating state transition logic
- Building workflow approval processes
- Understanding allowable state changes

---

### 7. **Deployment Diagram** (`deployment_diagram.mermaid`)
**Purpose:** Physical infrastructure and deployment topology.

**Deployment Options:**
- **Option 1:** Direct client-to-database (simpler, fewer servers)
- **Option 2:** App server + database (scalable, centralized)

**Infrastructure Components:**
- Client workstations with local cache
- Application server (optional) with validation services
- Database server with SQL Server
- File server for reports and exports
- Network infrastructure

**Use For:**
- Planning hardware requirements
- Designing deployment strategy
- Understanding network architecture
- Configuring backup systems

---

### 8. **Entity Relationship Diagram** (`entity_relationship_diagram.mermaid`)
**Purpose:** Complete database schema with all tables and relationships.

**Database Tables:**
- Core: USER, STORE_SETTINGS, LOV
- Catalog: CATEGORY, UNIT_OF_MEASURE, ITEM, SUPPLIER
- Transactions: ORDER_HEADER, ORDER_LINE, PURCHASE_HEADER, PURCHASE_ITEM
- Control: STOCK_HISTORY, INVENTORY_COUNT, PAYMENT_TERM

**Use For:**
- Creating database schema scripts
- Defining foreign key relationships
- Planning indexes and constraints
- Understanding data model completely

---

## 🎯 Implementation Roadmap

### Phase 1: Foundation (Weeks 1-2)
**What to Build:**
1. Database schema from ERD
2. Core entity classes from Class Diagram
3. DAO layer from Component Diagram
4. User authentication from Use Case Diagram

**Documents to Reference:**
- Entity Relationship Diagram
- Class Diagram
- Component Diagram
- Deployment Diagram

---

### Phase 2: Administration (Weeks 3-4)
**What to Build:**
1. Settings management (STORE_SETTINGS table)
2. LOV management for dropdowns
3. Category and UoM setup
4. User management

**Documents to Reference:**
- Use Case Diagram (Administration section)
- Class Diagram (StoreSettings, LOV)
- Component Diagram (Admin Forms)

---

### Phase 3: Catalog Setup (Weeks 5-6)
**What to Build:**
1. Item master data entry
2. Supplier management
3. Category hierarchy
4. Initial stock loading

**Documents to Reference:**
- Use Case Diagram (Catalog Management)
- Class Diagram (Item, Category, Supplier)
- Sequence Diagrams (for understanding data flow)

---

### Phase 4: Order Processing (Weeks 7-9)
**What to Build:**
1. Order entry form
2. Order line validation (★ critical)
3. Order approval workflow
4. Stock update on delivery

**Documents to Reference:**
- Sequence Diagram: Order Processing
- Activity Diagram: Order Validation
- State Diagram: Order Lifecycle
- Component Diagram: Order Managers

**Critical Implementation:**
```vb
' Implement stock validation per activity_order_validation.mermaid
Public Function ValidateOrderLine(orderLine As OrderLine) As ValidationResult
    Dim settings As StoreSettings = settingsMgr.GetSettings()
    
    If settings.In_Stock_Check Then
        If orderLine.Quantity > orderLine.Item.Stock_Quantity Then
            Return New ValidationResult(False, "Insufficient stock")
        End If
    ElseIf Not settings.Negative_Stock_Allowed Then
        Return New ValidationResult(False, "Invalid configuration")
    End If
    
    Return New ValidationResult(True)
End Function
```

---

### Phase 5: Purchasing (Weeks 10-12)
**What to Build:**
1. Purchase order entry
2. Receipt processing
3. Moving average cost calculation (★ critical)
4. Vendor management

**Documents to Reference:**
- Sequence Diagram: Purchase Receipt
- Activity Diagram: Moving Average
- State Diagram: Purchase Lifecycle
- Component Diagram: Purchase Managers

**Critical Implementation:**
```vb
' Implement moving average per activity_moving_average.mermaid
Public Function CalculateMovingAverage(item As Item, receiptQty As Decimal, receiptCost As Decimal) As Decimal
    Dim settings As StoreSettings = settingsMgr.GetSettings()
    
    If Not settings.Moving_Average_Price Then
        Return item.Current_Item_Cost ' No change
    End If
    
    If item.Stock_Quantity = 0 Then
        Return receiptCost ' First receipt
    End If
    
    Dim currentValue As Decimal = item.Stock_Quantity * item.Current_Item_Cost
    Dim receiptValue As Decimal = receiptQty * receiptCost
    Dim totalValue As Decimal = currentValue + receiptValue
    Dim totalQty As Decimal = item.Stock_Quantity + receiptQty
    
    Return totalValue / totalQty
End Function
```

---

### Phase 6: Inventory Control (Weeks 13-15)
**What to Build:**
1. Physical count entry
2. Variance calculation
3. Adjustment approval
4. Stock history reporting

**Documents to Reference:**
- Sequence Diagram: Inventory Count
- Activity Diagram: Inventory Count
- State Diagram: Count Lifecycle
- Component Diagram: Stock Managers

**Critical Implementation:**
```vb
' Implement count adjustment per activity_inventory_count.mermaid
Public Function ApplyCountAdjustment(count As InventoryCount) As Boolean
    Dim settings As StoreSettings = settingsMgr.GetSettings()
    Dim qtyChange As Decimal = count.Quantity_Change
    
    If qtyChange < 0 And Not settings.Negative_Stock_Allowed Then
        Dim newStock As Decimal = count.System_Quantity + qtyChange
        If newStock < 0 Then
            Throw New InvalidOperationException("Would create negative stock")
        End If
    End If
    
    ' Apply adjustment and log to STOCK_HISTORY
    stockMgr.UpdateStock(count.Item_ID, qtyChange, "Count Adjustment", count.Count_ID)
    historyMgr.LogTransaction(count.Item_ID, qtyChange, "Inventory Count", count.Count_ID)
    
    Return True
End Function
```

---

## ⚠️ Critical Validation Points (★)

These validation points are marked throughout the diagrams and MUST be implemented:

### 1. In_Stock_Check Validation
- **Location:** Order Line entry
- **Rule:** If enabled, prevent orders exceeding available stock
- **Documents:** `sequence_order_processing.mermaid`, `activity_order_validation.mermaid`

### 2. Negative_Stock_Allowed Validation
- **Location:** All stock decrease operations
- **Rule:** If disabled, prevent stock from going below zero
- **Documents:** All sequence diagrams, activity diagrams

### 3. Moving_Average_Price Calculation
- **Location:** Purchase receipt processing
- **Rule:** If enabled, recalculate item cost on each receipt
- **Documents:** `sequence_purchase_receipt.mermaid`, `activity_moving_average.mermaid`

### 4. Self-Logging Mechanism
- **Location:** ALL stock transactions
- **Rule:** Every stock change must create STOCK_HISTORY record
- **Documents:** All sequence diagrams, class diagram

---

## 🔧 VB.NET Implementation Notes

### Project Structure
```
InventoryManagementSystem/
├── Presentation/
│   ├── Forms/
│   │   ├── Admin/
│   │   ├── Inventory/
│   │   ├── Orders/
│   │   ├── Purchases/
│   │   └── Counts/
│   └── UserControls/
├── BusinessLogic/
│   ├── Managers/
│   ├── Validators/
│   └── Calculators/
├── DataAccess/
│   ├── DAOs/
│   └── Context/
├── Entities/
└── Common/
    ├── Enums/
    └── Utilities/
```

### Key Namespaces
```vb
Namespace InventoryManagement.Entities
Namespace InventoryManagement.BusinessLogic.Managers
Namespace InventoryManagement.BusinessLogic.Validators
Namespace InventoryManagement.DataAccess.DAOs
Namespace InventoryManagement.Presentation.Forms
```

### Database Connection
Use ADO.NET with parameterized queries or stored procedures. Reference the Deployment Diagram for connection architecture.

---

## 📊 Diagram Usage Matrix

| Task | Primary Diagrams | Supporting Diagrams |
|------|-----------------|---------------------|
| Database Design | ERD | Class Diagram |
| Class Creation | Class Diagram | Component Diagram |
| Form Design | Use Case Diagram | Component Diagram |
| Workflow Logic | Sequence Diagrams | Activity Diagrams |
| Status Management | State Diagram | Sequence Diagrams |
| Validation Rules | Activity Diagrams | Sequence Diagrams |
| Infrastructure Planning | Deployment Diagram | Component Diagram |

---

## 🎓 Learning Path

**For New Team Members:**
1. Start with Use Case Diagram (understand what the system does)
2. Review Class Diagram (understand the data model)
3. Study State Diagram (understand status flows)
4. Deep dive Sequence Diagrams (understand critical processes)
5. Review Activity Diagrams (understand decision logic)
6. Study Component and Deployment (understand architecture)

**For Database Developers:**
1. ERD (primary reference)
2. Class Diagram (understand relationships)
3. Sequence Diagrams (understand transaction flows)

**For VB.NET Developers:**
1. Component Diagram (architecture)
2. Class Diagram (entities and methods)
3. Sequence Diagrams (implementation flows)
4. Activity Diagrams (logic details)

---

## 📝 Notes

- All diagrams use Mermaid syntax for easy version control and rendering
- ★ symbols mark critical validation/calculation points requiring careful implementation
- Color coding: Red = validation, Yellow = calculation, Green = success, Blue = data/entity
- The self-logging mechanism ensures complete audit trail for all stock movements

---

## Version Information

**Document Set Version:** 1.0  
**Created:** December 2024  
**Target Implementation:** VB.NET Windows Forms with SQL Server  
**Architecture Pattern:** 3-Tier (Presentation, Business Logic, Data Access)

---

## Contact & Support

For questions about these diagrams or implementation guidance, refer to the specific diagram files which contain detailed annotations and notes.
