Namespace Entities

    ''' <summary>
    ''' Stock History entity - Audit trail for stock movements
    ''' </summary>
    Public Class StockHistory
        Public Property History_ID As Integer
        Public Property Item_ID As Integer
        Public Property Transaction_Date As DateTime
        Public Property Transaction_Type As String
        Public Property Reference_ID As Integer?
        Public Property Reference_Type As String
        Public Property Quantity_Change As Decimal
        Public Property Stock_Before As Decimal
        Public Property Stock_After As Decimal
        Public Property Unit_Cost As Decimal
        Public Property User_ID As Integer?
        Public Property Notes As String
        Public Property Created_Date As DateTime

        ' Navigation properties
        Public Property Item As Item
        Public Property User As User

        Public Sub New()
            Transaction_Date = DateTime.Now
            Quantity_Change = 0D
            Stock_Before = 0D
            Stock_After = 0D
            Unit_Cost = 0D
            Created_Date = DateTime.Now
        End Sub

        ''' <summary>
        ''' Create a stock history record
        ''' </summary>
        Public Shared Function CreateHistory(item As Item, quantityChange As Decimal, transactionType As String,
                                             referenceId As Integer?, referenceType As String,
                                             userId As Integer?, notes As String) As StockHistory
            Dim history As New StockHistory()
            history.Item_ID = item.Item_ID
            history.Item = item
            history.Transaction_Date = DateTime.Now
            history.Transaction_Type = transactionType
            history.Reference_ID = referenceId
            history.Reference_Type = referenceType
            history.Quantity_Change = quantityChange
            history.Stock_Before = item.Stock_Quantity
            history.Stock_After = item.Stock_Quantity + quantityChange
            history.Unit_Cost = item.Current_Item_Cost
            history.User_ID = userId
            history.Notes = notes
            Return history
        End Function

        ''' <summary>
        ''' Transaction value (quantity * cost)
        ''' </summary>
        Public ReadOnly Property TransactionValue As Decimal
            Get
                Return Quantity_Change * Unit_Cost
            End Get
        End Property

        ''' <summary>
        ''' Description for display
        ''' </summary>
        Public ReadOnly Property TransactionDescription As String
            Get
                Dim direction = If(Quantity_Change >= 0, "+", "")
                Return $"{Transaction_Type}: {direction}{Quantity_Change} ({Reference_Type})"
            End Get
        End Property

    End Class

End Namespace
