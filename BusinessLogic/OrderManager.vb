Imports InventoryManagement.Common
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Entities

Namespace BusinessLogic

    ''' <summary>
    ''' Handles order management operations
    ''' </summary>
    Public Class OrderManager
        Private ReadOnly _orderDAO As New OrderDAO()
        Private ReadOnly _itemDAO As New ItemDAO()
        Private ReadOnly _stockHistoryDAO As New StockHistoryDAO()

        ''' <summary>
        ''' Get all orders
        ''' </summary>
        Public Function GetAllOrders() As List(Of OrderHeader)
            Return _orderDAO.GetAll()
        End Function

        ''' <summary>
        ''' Get orders by status
        ''' </summary>
        Public Function GetOrdersByStatus(status As String) As List(Of OrderHeader)
            Return _orderDAO.GetByStatus(status)
        End Function

        ''' <summary>
        ''' Get orders by date range
        ''' </summary>
        Public Function GetOrdersByDateRange(startDate As DateTime, endDate As DateTime) As List(Of OrderHeader)
            Return _orderDAO.GetByDateRange(startDate, endDate)
        End Function

        ''' <summary>
        ''' Get order by ID with lines
        ''' </summary>
        Public Function GetOrderById(orderId As Integer) As OrderHeader
            Return _orderDAO.GetById(orderId)
        End Function

        ''' <summary>
        ''' Create a new order
        ''' </summary>
        Public Function CreateNewOrder() As OrderHeader
            Dim order As New OrderHeader() With {
                .Order_Number = _orderDAO.GetNextOrderNumber(AppSettings.Instance.OrderNumberPrefix),
                .Order_Date = DateTime.Now,
                .Order_Status = "Draft",
                .Currency = AppSettings.Instance.DefaultCurrency,
                .Created_By_User_ID = SessionManager.Instance.CurrentUser?.User_ID
            }
            Return order
        End Function

        ''' <summary>
        ''' Save an order (insert or update)
        ''' </summary>
        Public Function SaveOrder(order As OrderHeader) As Integer
            ' Calculate totals
            order.CalculateTotals(AppSettings.Instance.TaxRate)

            If order.Order_ID = 0 Then
                Return _orderDAO.Insert(order)
            Else
                _orderDAO.Update(order)
                Return order.Order_ID
            End If
        End Function

        ''' <summary>
        ''' Add a line to an order
        ''' </summary>
        Public Function AddOrderLine(line As OrderLine) As Integer
            ' Validate stock if required
            If AppSettings.Instance.InStockCheck Then
                Dim item = _itemDAO.GetById(line.Item_ID)
                If item IsNot Nothing AndAlso item.Track_Inventory Then
                    If Not item.CheckStockAvailability(line.Quantity) Then
                        Throw New InvalidOperationException($"Insufficient stock. Available: {item.Stock_Quantity}")
                    End If
                End If
            End If

            line.CalculateLineTotal()
            Return _orderDAO.InsertLine(line)
        End Function

        ''' <summary>
        ''' Update an order line
        ''' </summary>
        Public Function UpdateOrderLine(line As OrderLine) As Boolean
            line.CalculateLineTotal()
            Return _orderDAO.UpdateLine(line)
        End Function

        ''' <summary>
        ''' Delete an order line
        ''' </summary>
        Public Function DeleteOrderLine(lineId As Integer) As Boolean
            Return _orderDAO.DeleteLine(lineId)
        End Function

        ''' <summary>
        ''' Validate an order
        ''' </summary>
        Public Function ValidateOrder(order As OrderHeader) As List(Of String)
            Dim errors As New List(Of String)()

            If String.IsNullOrEmpty(order.Customer_Name) Then
                errors.Add("Customer name is required")
            End If

            If order.OrderLines Is Nothing OrElse order.OrderLines.Count = 0 Then
                errors.Add("Order must have at least one line item")
            Else
                For Each line In order.OrderLines
                    Dim msg = line.GetValidationMessage()
                    If Not String.IsNullOrEmpty(msg) Then
                        errors.Add($"Line {line.Line_Number}: {msg}")
                    End If
                Next
            End If

            Return errors
        End Function

        ''' <summary>
        ''' Submit an order for approval
        ''' </summary>
        Public Function SubmitOrder(orderId As Integer) As Boolean
            Dim order = _orderDAO.GetById(orderId)
            If order Is Nothing Then Return False

            Dim errors = ValidateOrder(order)
            If errors.Count > 0 Then
                Throw New InvalidOperationException(String.Join(Environment.NewLine, errors))
            End If

            Return _orderDAO.UpdateStatus(orderId, "Submitted")
        End Function

        ''' <summary>
        ''' Approve an order
        ''' </summary>
        Public Function ApproveOrder(orderId As Integer) As Boolean
            Return _orderDAO.ApproveOrder(orderId, SessionManager.Instance.CurrentUser?.User_ID)
        End Function

        ''' <summary>
        ''' Process order delivery (deduct stock)
        ''' </summary>
        Public Function ProcessDelivery(orderId As Integer) As Boolean
            Dim order = _orderDAO.GetById(orderId)
            If order Is Nothing Then Return False

            ' Deduct stock for each line
            For Each line In order.OrderLines
                Dim item = _itemDAO.GetById(line.Item_ID)
                If item IsNot Nothing AndAlso item.Track_Inventory Then
                    ' Check stock availability
                    If Not AppSettings.Instance.NegativeStockAllowed AndAlso item.Stock_Quantity < line.Quantity Then
                        Throw New InvalidOperationException($"Insufficient stock for {item.Item_Name}")
                    End If

                    ' Log the transaction
                    _stockHistoryDAO.LogTransaction(item, -line.Quantity, "SALE", order.Order_ID,
                                                   order.Order_Number, SessionManager.Instance.CurrentUser?.User_ID,
                                                   $"Order delivery: {order.Order_Number}")

                    ' Update stock
                    _itemDAO.UpdateStock(line.Item_ID, item.Stock_Quantity - line.Quantity)
                End If
            Next

            ' Update order status
            Return _orderDAO.UpdateStatus(orderId, "Delivered")
        End Function

        ''' <summary>
        ''' Cancel an order
        ''' </summary>
        Public Function CancelOrder(orderId As Integer) As Boolean
            Return _orderDAO.UpdateStatus(orderId, "Cancelled")
        End Function

    End Class

End Namespace
