Namespace Common

    ''' <summary>
    ''' User roles in the system
    ''' </summary>
    Public Enum UserRole
        Administrator
        Manager
        Sales
        Warehouse
        Purchasing
    End Enum

    ''' <summary>
    ''' Order status values
    ''' </summary>
    Public Enum OrderStatus
        Draft
        Submitted
        Approved
        Processing
        Shipped
        Delivered
        Cancelled
    End Enum

    ''' <summary>
    ''' Purchase order status values
    ''' </summary>
    Public Enum PurchaseStatus
        Draft
        Approved
        Sent
        PartiallyReceived
        Received
        Completed
        Cancelled
    End Enum

    ''' <summary>
    ''' Inventory count status values
    ''' </summary>
    Public Enum CountStatus
        Initiated
        InProgress
        Completed
        Applied
    End Enum

    ''' <summary>
    ''' Transaction types for stock history
    ''' </summary>
    Public Enum TransactionType
        Purchase
        Sale
        Adjustment
        Count
        Transfer
    End Enum

End Namespace
