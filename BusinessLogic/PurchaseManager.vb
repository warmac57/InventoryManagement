Imports InventoryManagement.Common
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Entities

Namespace BusinessLogic

    ''' <summary>
    ''' Handles purchase order management operations
    ''' </summary>
    Public Class PurchaseManager
        Private ReadOnly _purchaseDAO As New PurchaseDAO()
        Private ReadOnly _itemDAO As New ItemDAO()
        Private ReadOnly _stockHistoryDAO As New StockHistoryDAO()

        ''' <summary>
        ''' Get all purchases
        ''' </summary>
        Public Function GetAllPurchases() As List(Of PurchaseHeader)
            Return _purchaseDAO.GetAll()
        End Function

        ''' <summary>
        ''' Get purchases by status
        ''' </summary>
        Public Function GetPurchasesByStatus(status As String) As List(Of PurchaseHeader)
            Return _purchaseDAO.GetByStatus(status)
        End Function

        ''' <summary>
        ''' Get purchase by ID with items
        ''' </summary>
        Public Function GetPurchaseById(purchaseId As Integer) As PurchaseHeader
            Return _purchaseDAO.GetById(purchaseId)
        End Function

        ''' <summary>
        ''' Create a new purchase order
        ''' </summary>
        Public Function CreateNewPurchase() As PurchaseHeader
            Dim purchase As New PurchaseHeader() With {
                .Purchase_Number = _purchaseDAO.GetNextPurchaseNumber(AppSettings.Instance.PurchaseNumberPrefix),
                .Purchase_Date = DateTime.Now,
                .Purchase_Status = "Draft",
                .Created_By_User_ID = SessionManager.Instance.CurrentUser?.User_ID
            }
            Return purchase
        End Function

        ''' <summary>
        ''' Save a purchase order (insert or update)
        ''' </summary>
        Public Function SavePurchase(purchase As PurchaseHeader) As Integer
            ' Calculate totals
            purchase.CalculateTotals(AppSettings.Instance.TaxRate)

            If purchase.Purchase_ID = 0 Then
                Return _purchaseDAO.Insert(purchase)
            Else
                _purchaseDAO.Update(purchase)
                Return purchase.Purchase_ID
            End If
        End Function

        ''' <summary>
        ''' Add an item to a purchase
        ''' </summary>
        Public Function AddPurchaseItem(item As PurchaseItem) As Integer
            item.CalculateLineTotal()
            Return _purchaseDAO.InsertItem(item)
        End Function

        ''' <summary>
        ''' Update a purchase item
        ''' </summary>
        Public Function UpdatePurchaseItem(item As PurchaseItem) As Boolean
            item.CalculateLineTotal()
            Return _purchaseDAO.UpdateItem(item)
        End Function

        ''' <summary>
        ''' Delete a purchase item
        ''' </summary>
        Public Function DeletePurchaseItem(itemId As Integer) As Boolean
            Return _purchaseDAO.DeleteItem(itemId)
        End Function

        ''' <summary>
        ''' Validate a purchase order
        ''' </summary>
        Public Function ValidatePurchase(purchase As PurchaseHeader) As List(Of String)
            Dim errors As New List(Of String)()

            If purchase.Supplier_ID = 0 Then
                errors.Add("Supplier is required")
            End If

            If purchase.PurchaseItems Is Nothing OrElse purchase.PurchaseItems.Count = 0 Then
                errors.Add("Purchase order must have at least one line item")
            Else
                For Each item In purchase.PurchaseItems
                    Dim msg = item.GetValidationMessage()
                    If Not String.IsNullOrEmpty(msg) Then
                        errors.Add($"Line {item.Line_Number}: {msg}")
                    End If
                Next
            End If

            Return errors
        End Function

        ''' <summary>
        ''' Approve a purchase order
        ''' </summary>
        Public Function ApprovePurchase(purchaseId As Integer) As Boolean
            Dim purchase = _purchaseDAO.GetById(purchaseId)
            If purchase Is Nothing Then Return False

            Dim errors = ValidatePurchase(purchase)
            If errors.Count > 0 Then
                Throw New InvalidOperationException(String.Join(Environment.NewLine, errors))
            End If

            Using helper As New DatabaseHelper()
                helper.AddParameter("@Id", purchaseId)
                Dim sql = "UPDATE PURCHASE_HEADER SET Purchase_Status = 'Approved' WHERE Purchase_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Receive a purchase order (add stock)
        ''' </summary>
        Public Function ReceivePurchase(purchaseId As Integer) As Boolean
            Dim purchase = _purchaseDAO.GetById(purchaseId)
            If purchase Is Nothing Then Return False

            ' Process each item
            For Each purchaseItem In purchase.PurchaseItems
                Dim item = _itemDAO.GetById(purchaseItem.Item_ID)
                If item IsNot Nothing AndAlso item.Track_Inventory Then
                    ' Calculate new moving average cost if enabled
                    If AppSettings.Instance.MovingAveragePrice Then
                        Dim newCost = item.CalculateMovingAverage(purchaseItem.Quantity, purchaseItem.Unit_Cost)
                        _itemDAO.UpdateCost(purchaseItem.Item_ID, newCost)
                    End If

                    ' Log the transaction
                    _stockHistoryDAO.LogTransaction(item, purchaseItem.Quantity, "PURCHASE", purchase.Purchase_ID,
                                                   purchase.Purchase_Number, SessionManager.Instance.CurrentUser?.User_ID,
                                                   $"Purchase receipt: {purchase.Purchase_Number}")

                    ' Update stock
                    _itemDAO.UpdateStock(purchaseItem.Item_ID, item.Stock_Quantity + purchaseItem.Quantity)
                End If
            Next

            ' Mark purchase as received
            Return _purchaseDAO.ReceivePurchase(purchaseId, SessionManager.Instance.CurrentUser?.User_ID)
        End Function

        ''' <summary>
        ''' Cancel a purchase order
        ''' </summary>
        Public Function CancelPurchase(purchaseId As Integer) As Boolean
            Using helper As New DatabaseHelper()
                helper.AddParameter("@Id", purchaseId)
                Dim sql = "UPDATE PURCHASE_HEADER SET Purchase_Status = 'Cancelled' WHERE Purchase_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

    End Class

End Namespace
