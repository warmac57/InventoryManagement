Imports InventoryManagement.Common

Namespace Entities

    ''' <summary>
    ''' Inventory Count entity - Physical inventory count
    ''' </summary>
    Public Class InventoryCount
        Public Property Count_ID As Integer
        Public Property Count_Date As DateTime
        Public Property Item_ID As Integer
        Public Property System_Quantity As Decimal
        Public Property Quantity_Counted As Decimal
        Public Property Quantity_Change As Decimal
        Public Property Unit_Cost As Decimal
        Public Property Variance_Value As Decimal
        Public Property Count_Status As String
        Public Property Counted_By_User_ID As Integer?
        Public Property Approved_By_User_ID As Integer?
        Public Property Approved_Date As DateTime?
        Public Property Notes As String
        Public Property Created_Date As DateTime

        ' Navigation properties
        Public Property Item As Item
        Public Property CountedByUser As User
        Public Property ApprovedByUser As User

        Public Sub New()
            Count_Date = DateTime.Now
            System_Quantity = 0D
            Quantity_Counted = 0D
            Quantity_Change = 0D
            Unit_Cost = 0D
            Variance_Value = 0D
            Count_Status = "Initiated"
            Created_Date = DateTime.Now
        End Sub

        ''' <summary>
        ''' Calculate variance
        ''' </summary>
        Public Sub CalculateVariance()
            Quantity_Change = Quantity_Counted - System_Quantity
            Variance_Value = Quantity_Change * Unit_Cost
        End Sub

        ''' <summary>
        ''' Validate if count can be applied
        ''' </summary>
        Public Function CanApplyCount() As Boolean
            ' Check if adjustment would create negative stock
            If Quantity_Change < 0 AndAlso Not AppSettings.Instance.NegativeStockAllowed Then
                Dim newStock = System_Quantity + Quantity_Change
                If newStock < 0 Then
                    Return False
                End If
            End If
            Return True
        End Function

        ''' <summary>
        ''' Apply count results to item stock
        ''' </summary>
        Public Function ApplyCountResults() As Boolean
            If Not CanApplyCount() Then
                Return False
            End If

            If Item IsNot Nothing Then
                Item.Stock_Quantity = Quantity_Counted
                Item.Modified_Date = DateTime.Now
            End If

            Count_Status = "Applied"
            Return True
        End Function

        ''' <summary>
        ''' Get validation message
        ''' </summary>
        Public Function GetValidationMessage() As String
            If Item Is Nothing Then
                Return "Item is required"
            End If
            If Quantity_Counted < 0 Then
                Return "Counted quantity cannot be negative"
            End If
            If Not CanApplyCount() Then
                Return "Adjustment would create negative stock and negative stock is not allowed"
            End If
            Return String.Empty
        End Function

        ''' <summary>
        ''' Check if count can be edited
        ''' </summary>
        Public ReadOnly Property CanEdit As Boolean
            Get
                Return Count_Status = "Initiated" OrElse Count_Status = "InProgress"
            End Get
        End Property

        ''' <summary>
        ''' Check if count is a positive variance
        ''' </summary>
        Public ReadOnly Property IsPositiveVariance As Boolean
            Get
                Return Quantity_Change > 0
            End Get
        End Property

        ''' <summary>
        ''' Check if count is a negative variance
        ''' </summary>
        Public ReadOnly Property IsNegativeVariance As Boolean
            Get
                Return Quantity_Change < 0
            End Get
        End Property

        ''' <summary>
        ''' Variance percentage
        ''' </summary>
        Public ReadOnly Property VariancePercent As Decimal
            Get
                If System_Quantity = 0 Then
                    If Quantity_Change = 0 Then Return 0
                    Return 100 ' 100% variance if system was 0
                End If
                Return (Quantity_Change / System_Quantity) * 100
            End Get
        End Property

    End Class

End Namespace
