Namespace Entities

    ''' <summary>
    ''' Purchase Item entity - Purchase order line items
    ''' </summary>
    Public Class PurchaseItem
        Public Property Purchase_Item_ID As Integer
        Public Property Purchase_ID As Integer
        Public Property Line_Number As Integer
        Public Property Item_ID As Integer
        Public Property Quantity As Decimal
        Public Property Unit_Cost As Decimal
        Public Property Line_Total As Decimal
        Public Property Notes As String
        Public Property Created_Date As DateTime

        ' Navigation properties
        Public Property Item As Item

        Public Sub New()
            Quantity = 0D
            Unit_Cost = 0D
            Line_Total = 0D
            Created_Date = DateTime.Now
        End Sub

        ''' <summary>
        ''' Calculate line total
        ''' </summary>
        Public Sub CalculateLineTotal()
            Line_Total = Quantity * Unit_Cost
        End Sub

        ''' <summary>
        ''' Process receipt - updates item cost and stock
        ''' </summary>
        Public Sub ProcessReceipt()
            If Item IsNot Nothing Then
                ' Calculate new average cost
                Dim newCost = Item.CalculateMovingAverage(Quantity, Unit_Cost)
                Item.Current_Item_Cost = newCost
                Item.Stock_Quantity += Quantity
                Item.Modified_Date = DateTime.Now
            End If
        End Sub

        ''' <summary>
        ''' Get validation message
        ''' </summary>
        Public Function GetValidationMessage() As String
            If Item Is Nothing Then
                Return "Item is required"
            End If
            If Quantity <= 0 Then
                Return "Quantity must be greater than zero"
            End If
            If Unit_Cost < 0 Then
                Return "Unit cost cannot be negative"
            End If
            Return String.Empty
        End Function

    End Class

End Namespace
