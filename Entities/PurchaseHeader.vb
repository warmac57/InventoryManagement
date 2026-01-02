Namespace Entities

    ''' <summary>
    ''' Purchase Header entity - Purchase order
    ''' </summary>
    Public Class PurchaseHeader
        Public Property Purchase_ID As Integer
        Public Property Purchase_Number As String
        Public Property Purchase_Date As DateTime
        Public Property Supplier_ID As Integer
        Public Property Purchase_Status As String
        Public Property Subtotal As Decimal
        Public Property Tax_Amount As Decimal
        Public Property Total_Amount As Decimal
        Public Property Expected_Date As DateTime?
        Public Property Received_Date As DateTime?
        Public Property Notes As String
        Public Property Is_Received As Boolean
        Public Property Received_By_User_ID As Integer?
        Public Property Created_Date As DateTime
        Public Property Created_By_User_ID As Integer?

        ' Navigation properties
        Public Property Supplier As Supplier
        Public Property PurchaseItems As List(Of PurchaseItem)
        Public Property CreatedByUser As User
        Public Property ReceivedByUser As User

        Public Sub New()
            Purchase_Date = DateTime.Now
            Purchase_Status = "Draft"
            Subtotal = 0D
            Tax_Amount = 0D
            Total_Amount = 0D
            Is_Received = False
            Created_Date = DateTime.Now
            PurchaseItems = New List(Of PurchaseItem)()
        End Sub

        ''' <summary>
        ''' Display text
        ''' </summary>
        Public Overrides Function ToString() As String
            If Supplier IsNot Nothing Then
                Return $"{Purchase_Number} - {Supplier.Supplier_Name}"
            End If
            Return Purchase_Number
        End Function

        ''' <summary>
        ''' Calculate purchase totals from lines
        ''' </summary>
        Public Sub CalculateTotals(taxRate As Decimal)
            Subtotal = 0D
            If PurchaseItems IsNot Nothing Then
                For Each item In PurchaseItems
                    Subtotal += item.Line_Total
                Next
            End If
            Tax_Amount = Subtotal * (taxRate / 100)
            Total_Amount = Subtotal + Tax_Amount
        End Sub

        ''' <summary>
        ''' Receive the purchase order
        ''' </summary>
        Public Sub ReceivePurchase(userId As Integer)
            If Purchase_Status = "Approved" OrElse Purchase_Status = "Sent" Then
                Purchase_Status = "Received"
                Is_Received = True
                Received_By_User_ID = userId
                Received_Date = DateTime.Now
            End If
        End Sub

        ''' <summary>
        ''' Check if purchase can be edited
        ''' </summary>
        Public ReadOnly Property CanEdit As Boolean
            Get
                Return Purchase_Status = "Draft"
            End Get
        End Property

        ''' <summary>
        ''' Check if purchase can be received
        ''' </summary>
        Public ReadOnly Property CanReceive As Boolean
            Get
                Return Purchase_Status = "Approved" OrElse Purchase_Status = "Sent"
            End Get
        End Property

        ''' <summary>
        ''' Check if purchase can be cancelled
        ''' </summary>
        Public ReadOnly Property CanCancel As Boolean
            Get
                Return Purchase_Status <> "Received" AndAlso
                       Purchase_Status <> "Completed" AndAlso
                       Purchase_Status <> "Cancelled"
            End Get
        End Property

    End Class

End Namespace
