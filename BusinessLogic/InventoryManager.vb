Imports InventoryManagement.Common
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Entities

Namespace BusinessLogic

    ''' <summary>
    ''' Handles inventory management operations
    ''' </summary>
    Public Class InventoryManager
        Private ReadOnly _itemDAO As New ItemDAO()
        Private ReadOnly _stockHistoryDAO As New StockHistoryDAO()
        Private ReadOnly _inventoryCountDAO As New InventoryCountDAO()

        ''' <summary>
        ''' Get all items
        ''' </summary>
        Public Function GetAllItems() As List(Of Item)
            Return _itemDAO.GetAll()
        End Function

        ''' <summary>
        ''' Get active items
        ''' </summary>
        Public Function GetActiveItems() As List(Of Item)
            Return _itemDAO.GetActiveItems()
        End Function

        ''' <summary>
        ''' Get item by ID
        ''' </summary>
        Public Function GetItemById(itemId As Integer) As Item
            Return _itemDAO.GetById(itemId)
        End Function

        ''' <summary>
        ''' Search items
        ''' </summary>
        Public Function SearchItems(searchText As String) As List(Of Item)
            Return _itemDAO.Search(searchText)
        End Function

        ''' <summary>
        ''' Get items needing reorder
        ''' </summary>
        Public Function GetItemsNeedingReorder() As List(Of Item)
            Return _itemDAO.GetItemsNeedingReorder()
        End Function

        ''' <summary>
        ''' Save an item (insert or update)
        ''' </summary>
        Public Function SaveItem(item As Item) As Integer
            If item.Item_ID = 0 Then
                Return _itemDAO.Insert(item)
            Else
                _itemDAO.Update(item)
                Return item.Item_ID
            End If
        End Function

        ''' <summary>
        ''' Delete an item
        ''' </summary>
        Public Function DeleteItem(itemId As Integer) As Boolean
            Return _itemDAO.Delete(itemId)
        End Function

        ''' <summary>
        ''' Update item stock with history logging
        ''' </summary>
        Public Function UpdateStock(itemId As Integer, quantityChange As Decimal, transactionType As String,
                                    referenceId As Integer?, referenceType As String, notes As String) As Boolean
            Dim item = _itemDAO.GetById(itemId)
            If item Is Nothing Then Return False

            ' Check if negative stock would result
            Dim newStock = item.Stock_Quantity + quantityChange
            If newStock < 0 AndAlso Not AppSettings.Instance.NegativeStockAllowed Then
                Throw New InvalidOperationException("This operation would result in negative stock, which is not allowed.")
            End If

            ' Log the transaction
            _stockHistoryDAO.LogTransaction(item, quantityChange, transactionType, referenceId, referenceType,
                                           SessionManager.Instance.CurrentUser?.User_ID, notes)

            ' Update the stock
            Return _itemDAO.UpdateStock(itemId, newStock)
        End Function

        ''' <summary>
        ''' Check stock availability
        ''' </summary>
        Public Function CheckStockAvailability(itemId As Integer, quantity As Decimal) As Boolean
            Dim item = _itemDAO.GetById(itemId)
            If item Is Nothing Then Return False

            Return item.CheckStockAvailability(quantity)
        End Function

        ''' <summary>
        ''' Calculate and update moving average cost
        ''' </summary>
        Public Function UpdateMovingAverageCost(itemId As Integer, receiptQty As Decimal, receiptCost As Decimal) As Decimal
            Dim item = _itemDAO.GetById(itemId)
            If item Is Nothing Then Return 0

            If Not AppSettings.Instance.MovingAveragePrice Then
                Return item.Current_Item_Cost
            End If

            Dim newCost = item.CalculateMovingAverage(receiptQty, receiptCost)
            _itemDAO.UpdateCost(itemId, newCost)
            Return newCost
        End Function

        ''' <summary>
        ''' Get stock history for an item
        ''' </summary>
        Public Function GetStockHistory(itemId As Integer) As List(Of StockHistory)
            Return _stockHistoryDAO.GetByItemId(itemId)
        End Function

        ''' <summary>
        ''' Get stock history by date range
        ''' </summary>
        Public Function GetStockHistoryByDateRange(startDate As DateTime, endDate As DateTime) As List(Of StockHistory)
            Return _stockHistoryDAO.GetByDateRange(startDate, endDate)
        End Function

        ''' <summary>
        ''' Create an inventory count
        ''' </summary>
        Public Function CreateInventoryCount(itemId As Integer) As InventoryCount
            Dim item = _itemDAO.GetById(itemId)
            If item Is Nothing Then Return Nothing

            Dim count As New InventoryCount() With {
                .Item_ID = itemId,
                .Item = item,
                .Count_Date = DateTime.Now,
                .System_Quantity = item.Stock_Quantity,
                .Unit_Cost = item.Current_Item_Cost,
                .Count_Status = "Initiated",
                .Counted_By_User_ID = SessionManager.Instance.CurrentUser?.User_ID
            }

            Return count
        End Function

        ''' <summary>
        ''' Save an inventory count
        ''' </summary>
        Public Function SaveInventoryCount(count As InventoryCount) As Integer
            count.CalculateVariance()

            If count.Count_ID = 0 Then
                Return _inventoryCountDAO.Insert(count)
            Else
                _inventoryCountDAO.Update(count)
                Return count.Count_ID
            End If
        End Function

        ''' <summary>
        ''' Apply inventory count adjustment
        ''' </summary>
        Public Function ApplyInventoryCount(countId As Integer) As Boolean
            Dim count = _inventoryCountDAO.GetById(countId)
            If count Is Nothing Then Return False

            ' Validate
            If Not count.CanApplyCount() Then
                Throw New InvalidOperationException("Cannot apply count: " & count.GetValidationMessage())
            End If

            ' Update item stock
            Dim item = _itemDAO.GetById(count.Item_ID)
            If item Is Nothing Then Return False

            ' Log the adjustment
            _stockHistoryDAO.LogTransaction(item, count.Quantity_Change, "COUNT", count.Count_ID,
                                           "Inventory Count", SessionManager.Instance.CurrentUser?.User_ID,
                                           $"Count variance: {count.Quantity_Change}")

            ' Update stock
            _itemDAO.UpdateStock(count.Item_ID, count.Quantity_Counted)

            ' Mark count as applied
            Return _inventoryCountDAO.MarkAsApplied(countId)
        End Function

        ''' <summary>
        ''' Get all inventory counts
        ''' </summary>
        Public Function GetAllCounts() As List(Of InventoryCount)
            Return _inventoryCountDAO.GetAll()
        End Function

        ''' <summary>
        ''' Get inventory counts by status
        ''' </summary>
        Public Function GetCountsByStatus(status As String) As List(Of InventoryCount)
            Return _inventoryCountDAO.GetByStatus(status)
        End Function

    End Class

End Namespace
