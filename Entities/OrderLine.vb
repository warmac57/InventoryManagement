Imports InventoryManagement.Common

Namespace Entities

    ''' <summary>
    ''' Order Line entity - Sales order line items
    ''' </summary>
    Public Class OrderLine
        Public Property Order_Line_ID As Integer
        Public Property Order_ID As Integer
        Public Property Line_Number As Integer
        Public Property Item_ID As Integer
        Public Property Quantity As Decimal
        Public Property Unit_Price As Decimal
        Public Property Discount_Percent As Decimal
        Public Property Line_Total As Decimal
        Public Property Notes As String
        Public Property Created_Date As DateTime

        ' Navigation properties
        Public Property Item As Item

        Public Sub New()
            Quantity = 0D
            Unit_Price = 0D
            Discount_Percent = 0D
            Line_Total = 0D
            Created_Date = DateTime.Now
        End Sub

        ''' <summary>
        ''' Calculate line total
        ''' </summary>
        Public Sub CalculateLineTotal()
            Dim subtotal As Decimal = Quantity * Unit_Price
            Dim discount As Decimal = subtotal * (Discount_Percent / 100)
            Line_Total = subtotal - discount
        End Sub

        ''' <summary>
        ''' Validate stock availability
        ''' </summary>
        Public Function ValidateStock() As Boolean
            If Item Is Nothing Then Return False
            If Not Item.Track_Inventory Then Return True
            If Not AppSettings.Instance.InStockCheck Then Return True
            Return Item.Stock_Quantity >= Quantity
        End Function

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
            If Unit_Price < 0 Then
                Return "Unit price cannot be negative"
            End If
            If Not ValidateStock() Then
                Return $"Insufficient stock. Available: {Item.Stock_Quantity}"
            End If
            Return String.Empty
        End Function

    End Class

End Namespace
