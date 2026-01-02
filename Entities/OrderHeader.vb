Namespace Entities

    ''' <summary>
    ''' Order Header entity - Sales order
    ''' </summary>
    Public Class OrderHeader
        Public Property Order_ID As Integer
        Public Property Order_Number As String
        Public Property Order_Date As DateTime
        Public Property Customer_ID As Integer?
        Public Property Customer_Name As String
        Public Property Customer_Contact As String
        Public Property Payment_Term_ID As Integer?
        Public Property Payment_Method As String
        Public Property Currency As String
        Public Property Order_Status As String
        Public Property Subtotal As Decimal
        Public Property Tax_Amount As Decimal
        Public Property Total_Amount As Decimal
        Public Property Delivery_Date As DateTime?
        Public Property Delivery_Address As String
        Public Property Notes As String
        Public Property Is_Approved As Boolean
        Public Property Approved_By_User_ID As Integer?
        Public Property Approved_Date As DateTime?
        Public Property Created_Date As DateTime
        Public Property Created_By_User_ID As Integer?

        ' Navigation properties
        Public Property PaymentTerm As PaymentTerm
        Public Property OrderLines As List(Of OrderLine)
        Public Property CreatedByUser As User
        Public Property ApprovedByUser As User

        Public Sub New()
            Order_Date = DateTime.Now
            Order_Status = "Draft"
            Currency = "USD"
            Subtotal = 0D
            Tax_Amount = 0D
            Total_Amount = 0D
            Is_Approved = False
            Created_Date = DateTime.Now
            OrderLines = New List(Of OrderLine)()
        End Sub

        ''' <summary>
        ''' Display text
        ''' </summary>
        Public Overrides Function ToString() As String
            Return $"{Order_Number} - {Customer_Name}"
        End Function

        ''' <summary>
        ''' Calculate order totals from lines
        ''' </summary>
        Public Sub CalculateTotals(taxRate As Decimal)
            Subtotal = 0D
            If OrderLines IsNot Nothing Then
                For Each line In OrderLines
                    Subtotal += line.Line_Total
                Next
            End If
            Tax_Amount = Subtotal * (taxRate / 100)
            Total_Amount = Subtotal + Tax_Amount
        End Sub

        ''' <summary>
        ''' Submit order for approval
        ''' </summary>
        Public Sub SubmitOrder()
            If Order_Status = "Draft" Then
                Order_Status = "Submitted"
            End If
        End Sub

        ''' <summary>
        ''' Approve the order
        ''' </summary>
        Public Sub ApproveOrder(userId As Integer)
            If Order_Status = "Submitted" Then
                Order_Status = "Approved"
                Is_Approved = True
                Approved_By_User_ID = userId
                Approved_Date = DateTime.Now
            End If
        End Sub

        ''' <summary>
        ''' Check if order can be edited
        ''' </summary>
        Public ReadOnly Property CanEdit As Boolean
            Get
                Return Order_Status = "Draft"
            End Get
        End Property

        ''' <summary>
        ''' Check if order can be cancelled
        ''' </summary>
        Public ReadOnly Property CanCancel As Boolean
            Get
                Return Order_Status <> "Delivered" AndAlso Order_Status <> "Cancelled"
            End Get
        End Property

    End Class

End Namespace
