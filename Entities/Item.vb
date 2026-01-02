Imports InventoryManagement.Common

Namespace Entities

    ''' <summary>
    ''' Item/Product entity - Core inventory entity
    ''' </summary>
    Public Class Item
        Public Property Item_ID As Integer
        Public Property Item_Code As String
        Public Property Item_Name As String
        Public Property Description As String
        Public Property Category_ID As Integer?
        Public Property UoM_ID As Integer?
        Public Property Current_Item_Cost As Decimal
        Public Property Stock_Quantity As Decimal
        Public Property Reorder_Level As Decimal
        Public Property Min_Stock_Level As Decimal
        Public Property Max_Stock_Level As Decimal
        Public Property Track_Inventory As Boolean
        Public Property Is_Active As Boolean
        Public Property Created_Date As DateTime
        Public Property Modified_Date As DateTime

        ' Navigation properties
        Public Property Category As Category
        Public Property UnitOfMeasure As UnitOfMeasure

        Public Sub New()
            Is_Active = True
            Track_Inventory = True
            Current_Item_Cost = 0D
            Stock_Quantity = 0D
            Reorder_Level = 0D
            Min_Stock_Level = 0D
            Max_Stock_Level = 0D
            Created_Date = DateTime.Now
            Modified_Date = DateTime.Now
        End Sub

        ''' <summary>
        ''' Display text for combo boxes
        ''' </summary>
        Public Overrides Function ToString() As String
            Return $"{Item_Code} - {Item_Name}"
        End Function

        ''' <summary>
        ''' Calculate moving average cost
        ''' </summary>
        Public Function CalculateMovingAverage(receiptQty As Decimal, receiptCost As Decimal) As Decimal
            If Not AppSettings.Instance.MovingAveragePrice Then
                Return Current_Item_Cost
            End If

            If Stock_Quantity = 0 Then
                Return receiptCost
            End If

            Dim currentValue As Decimal = Stock_Quantity * Current_Item_Cost
            Dim receiptValue As Decimal = receiptQty * receiptCost
            Dim totalValue As Decimal = currentValue + receiptValue
            Dim totalQty As Decimal = Stock_Quantity + receiptQty

            If totalQty = 0 Then Return receiptCost
            Return totalValue / totalQty
        End Function

        ''' <summary>
        ''' Check stock availability for order
        ''' </summary>
        Public Function CheckStockAvailability(quantity As Decimal) As Boolean
            If Not Track_Inventory Then Return True
            If Not AppSettings.Instance.InStockCheck Then Return True
            Return Stock_Quantity >= quantity
        End Function

        ''' <summary>
        ''' Check if item needs reorder
        ''' </summary>
        Public ReadOnly Property NeedsReorder As Boolean
            Get
                Return Track_Inventory AndAlso Stock_Quantity <= Reorder_Level
            End Get
        End Property

        ''' <summary>
        ''' Check if item is below minimum stock
        ''' </summary>
        Public ReadOnly Property BelowMinimum As Boolean
            Get
                Return Track_Inventory AndAlso Stock_Quantity < Min_Stock_Level
            End Get
        End Property

        ''' <summary>
        ''' Total inventory value
        ''' </summary>
        Public ReadOnly Property InventoryValue As Decimal
            Get
                Return Stock_Quantity * Current_Item_Cost
            End Get
        End Property

    End Class

End Namespace
