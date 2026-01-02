Imports InventoryManagement.Entities
Imports Microsoft.Data.SqlClient

Namespace DataAccess

    ''' <summary>
    ''' Data Access Object for OrderHeader and OrderLine entities
    ''' </summary>
    Public Class OrderDAO
        Inherits BaseDAO

        ''' <summary>
        ''' Get all orders
        ''' </summary>
        Public Function GetAll() As List(Of OrderHeader)
            Dim orders As New List(Of OrderHeader)()
            Using helper = CreateHelper()
                Dim sql = "SELECT * FROM ORDER_HEADER ORDER BY Order_Date DESC"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        orders.Add(MapOrderHeader(reader))
                    End While
                End Using
            End Using
            Return orders
        End Function

        ''' <summary>
        ''' Get orders by status
        ''' </summary>
        Public Function GetByStatus(status As String) As List(Of OrderHeader)
            Dim orders As New List(Of OrderHeader)()
            Using helper = CreateHelper()
                helper.AddParameter("@Status", status)
                Dim sql = "SELECT * FROM ORDER_HEADER WHERE Order_Status = @Status ORDER BY Order_Date DESC"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        orders.Add(MapOrderHeader(reader))
                    End While
                End Using
            End Using
            Return orders
        End Function

        ''' <summary>
        ''' Get orders by date range
        ''' </summary>
        Public Function GetByDateRange(startDate As DateTime, endDate As DateTime) As List(Of OrderHeader)
            Dim orders As New List(Of OrderHeader)()
            Using helper = CreateHelper()
                helper.AddParameter("@StartDate", startDate)
                helper.AddParameter("@EndDate", endDate)
                Dim sql = "SELECT * FROM ORDER_HEADER WHERE Order_Date >= @StartDate AND Order_Date <= @EndDate ORDER BY Order_Date DESC"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        orders.Add(MapOrderHeader(reader))
                    End While
                End Using
            End Using
            Return orders
        End Function

        ''' <summary>
        ''' Get order by ID with lines
        ''' </summary>
        Public Function GetById(orderId As Integer) As OrderHeader
            Using helper = CreateHelper()
                helper.AddParameter("@Id", orderId)
                Dim sql = "SELECT * FROM ORDER_HEADER WHERE Order_ID = @Id"
                Using reader = helper.ExecuteReader(sql)
                    If reader.Read() Then
                        Dim order = MapOrderHeader(reader)
                        order.OrderLines = GetOrderLines(orderId)
                        Return order
                    End If
                End Using
            End Using
            Return Nothing
        End Function

        ''' <summary>
        ''' Get order lines for an order
        ''' </summary>
        Public Function GetOrderLines(orderId As Integer) As List(Of OrderLine)
            Dim lines As New List(Of OrderLine)()
            Using helper = CreateHelper()
                helper.AddParameter("@OrderId", orderId)
                Dim sql = "SELECT ol.*, i.Item_Code, i.Item_Name, i.Stock_Quantity " &
                         "FROM ORDER_LINE ol INNER JOIN ITEM i ON ol.Item_ID = i.Item_ID " &
                         "WHERE ol.Order_ID = @OrderId ORDER BY ol.Line_Number"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        Dim line = MapOrderLine(reader)
                        line.Item = New Item() With {
                            .Item_ID = line.Item_ID,
                            .Item_Code = GetString(reader, "Item_Code"),
                            .Item_Name = GetString(reader, "Item_Name"),
                            .Stock_Quantity = GetDecimal(reader, "Stock_Quantity")
                        }
                        lines.Add(line)
                    End While
                End Using
            End Using
            Return lines
        End Function

        ''' <summary>
        ''' Get next order number
        ''' </summary>
        Public Function GetNextOrderNumber(prefix As String) As String
            Using helper = CreateHelper()
                Dim year = DateTime.Now.Year
                Dim sql = $"SELECT ISNULL(MAX(CAST(RIGHT(Order_Number, 4) AS INT)), 0) + 1 " &
                         $"FROM ORDER_HEADER WHERE Order_Number LIKE '{prefix}{year}-%'"
                Dim result = helper.ExecuteScalar(sql)
                Dim nextNum = If(result IsNot Nothing, Convert.ToInt32(result), 1)
                Return $"{prefix}{year}-{nextNum:D4}"
            End Using
        End Function

        ''' <summary>
        ''' Insert a new order
        ''' </summary>
        Public Function Insert(order As OrderHeader) As Integer
            Using helper = CreateHelper()
                helper.AddParameter("@Number", order.Order_Number)
                helper.AddParameter("@Date", order.Order_Date)
                helper.AddParameter("@CustomerId", order.Customer_ID)
                helper.AddParameter("@CustomerName", order.Customer_Name)
                helper.AddParameter("@CustomerContact", order.Customer_Contact)
                helper.AddParameter("@PaymentTermId", order.Payment_Term_ID)
                helper.AddParameter("@PaymentMethod", order.Payment_Method)
                helper.AddParameter("@Currency", order.Currency)
                helper.AddParameter("@Status", order.Order_Status)
                helper.AddParameter("@Subtotal", order.Subtotal)
                helper.AddParameter("@TaxAmount", order.Tax_Amount)
                helper.AddParameter("@TotalAmount", order.Total_Amount)
                helper.AddParameter("@DeliveryDate", order.Delivery_Date)
                helper.AddParameter("@DeliveryAddress", order.Delivery_Address)
                helper.AddParameter("@Notes", order.Notes)
                helper.AddParameter("@CreatedBy", order.Created_By_User_ID)

                Dim sql = "INSERT INTO ORDER_HEADER (Order_Number, Order_Date, Customer_ID, Customer_Name, " &
                         "Customer_Contact, Payment_Term_ID, Payment_Method, Currency, Order_Status, Subtotal, " &
                         "Tax_Amount, Total_Amount, Delivery_Date, Delivery_Address, Notes, Created_Date, " &
                         "Created_By_User_ID) VALUES (@Number, @Date, @CustomerId, @CustomerName, @CustomerContact, " &
                         "@PaymentTermId, @PaymentMethod, @Currency, @Status, @Subtotal, @TaxAmount, @TotalAmount, " &
                         "@DeliveryDate, @DeliveryAddress, @Notes, GETDATE(), @CreatedBy); SELECT SCOPE_IDENTITY();"

                Dim result = helper.ExecuteScalar(sql)
                If result IsNot Nothing Then
                    order.Order_ID = Convert.ToInt32(result)
                    Return order.Order_ID
                End If
            End Using
            Return 0
        End Function

        ''' <summary>
        ''' Update an existing order
        ''' </summary>
        Public Function Update(order As OrderHeader) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", order.Order_ID)
                helper.AddParameter("@CustomerName", order.Customer_Name)
                helper.AddParameter("@CustomerContact", order.Customer_Contact)
                helper.AddParameter("@PaymentTermId", order.Payment_Term_ID)
                helper.AddParameter("@PaymentMethod", order.Payment_Method)
                helper.AddParameter("@Currency", order.Currency)
                helper.AddParameter("@Status", order.Order_Status)
                helper.AddParameter("@Subtotal", order.Subtotal)
                helper.AddParameter("@TaxAmount", order.Tax_Amount)
                helper.AddParameter("@TotalAmount", order.Total_Amount)
                helper.AddParameter("@DeliveryDate", order.Delivery_Date)
                helper.AddParameter("@DeliveryAddress", order.Delivery_Address)
                helper.AddParameter("@Notes", order.Notes)

                Dim sql = "UPDATE ORDER_HEADER SET Customer_Name = @CustomerName, Customer_Contact = @CustomerContact, " &
                         "Payment_Term_ID = @PaymentTermId, Payment_Method = @PaymentMethod, Currency = @Currency, " &
                         "Order_Status = @Status, Subtotal = @Subtotal, Tax_Amount = @TaxAmount, " &
                         "Total_Amount = @TotalAmount, Delivery_Date = @DeliveryDate, " &
                         "Delivery_Address = @DeliveryAddress, Notes = @Notes WHERE Order_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Update order status
        ''' </summary>
        Public Function UpdateStatus(orderId As Integer, status As String) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", orderId)
                helper.AddParameter("@Status", status)
                Dim sql = "UPDATE ORDER_HEADER SET Order_Status = @Status WHERE Order_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Approve an order
        ''' </summary>
        Public Function ApproveOrder(orderId As Integer, userId As Integer) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", orderId)
                helper.AddParameter("@UserId", userId)
                Dim sql = "UPDATE ORDER_HEADER SET Order_Status = 'Approved', Is_Approved = 1, " &
                         "Approved_By_User_ID = @UserId, Approved_Date = GETDATE() WHERE Order_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Insert an order line
        ''' </summary>
        Public Function InsertLine(line As OrderLine) As Integer
            Using helper = CreateHelper()
                helper.AddParameter("@OrderId", line.Order_ID)
                helper.AddParameter("@LineNumber", line.Line_Number)
                helper.AddParameter("@ItemId", line.Item_ID)
                helper.AddParameter("@Quantity", line.Quantity)
                helper.AddParameter("@UnitPrice", line.Unit_Price)
                helper.AddParameter("@DiscountPercent", line.Discount_Percent)
                helper.AddParameter("@LineTotal", line.Line_Total)
                helper.AddParameter("@Notes", line.Notes)

                Dim sql = "INSERT INTO ORDER_LINE (Order_ID, Line_Number, Item_ID, Quantity, Unit_Price, " &
                         "Discount_Percent, Line_Total, Notes, Created_Date) VALUES (@OrderId, @LineNumber, " &
                         "@ItemId, @Quantity, @UnitPrice, @DiscountPercent, @LineTotal, @Notes, GETDATE()); " &
                         "SELECT SCOPE_IDENTITY();"

                Dim result = helper.ExecuteScalar(sql)
                If result IsNot Nothing Then
                    line.Order_Line_ID = Convert.ToInt32(result)
                    Return line.Order_Line_ID
                End If
            End Using
            Return 0
        End Function

        ''' <summary>
        ''' Update an order line
        ''' </summary>
        Public Function UpdateLine(line As OrderLine) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", line.Order_Line_ID)
                helper.AddParameter("@ItemId", line.Item_ID)
                helper.AddParameter("@Quantity", line.Quantity)
                helper.AddParameter("@UnitPrice", line.Unit_Price)
                helper.AddParameter("@DiscountPercent", line.Discount_Percent)
                helper.AddParameter("@LineTotal", line.Line_Total)
                helper.AddParameter("@Notes", line.Notes)

                Dim sql = "UPDATE ORDER_LINE SET Item_ID = @ItemId, Quantity = @Quantity, Unit_Price = @UnitPrice, " &
                         "Discount_Percent = @DiscountPercent, Line_Total = @LineTotal, Notes = @Notes " &
                         "WHERE Order_Line_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Delete an order line
        ''' </summary>
        Public Function DeleteLine(lineId As Integer) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", lineId)
                Dim sql = "DELETE FROM ORDER_LINE WHERE Order_Line_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Delete all lines for an order
        ''' </summary>
        Public Function DeleteOrderLines(orderId As Integer) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@OrderId", orderId)
                Dim sql = "DELETE FROM ORDER_LINE WHERE Order_ID = @OrderId"
                Return helper.ExecuteNonQuery(sql) >= 0
            End Using
        End Function

        Private Function MapOrderHeader(reader As SqlDataReader) As OrderHeader
            Return New OrderHeader() With {
                .Order_ID = GetInt32(reader, "Order_ID"),
                .Order_Number = GetString(reader, "Order_Number"),
                .Order_Date = GetDateTime(reader, "Order_Date"),
                .Customer_ID = GetNullableInt32(reader, "Customer_ID"),
                .Customer_Name = GetString(reader, "Customer_Name"),
                .Customer_Contact = GetString(reader, "Customer_Contact"),
                .Payment_Term_ID = GetNullableInt32(reader, "Payment_Term_ID"),
                .Payment_Method = GetString(reader, "Payment_Method"),
                .Currency = GetString(reader, "Currency"),
                .Order_Status = GetString(reader, "Order_Status"),
                .Subtotal = GetDecimal(reader, "Subtotal"),
                .Tax_Amount = GetDecimal(reader, "Tax_Amount"),
                .Total_Amount = GetDecimal(reader, "Total_Amount"),
                .Delivery_Date = GetNullableDateTime(reader, "Delivery_Date"),
                .Delivery_Address = GetString(reader, "Delivery_Address"),
                .Notes = GetString(reader, "Notes"),
                .Is_Approved = GetBoolean(reader, "Is_Approved"),
                .Approved_By_User_ID = GetNullableInt32(reader, "Approved_By_User_ID"),
                .Approved_Date = GetNullableDateTime(reader, "Approved_Date"),
                .Created_Date = GetDateTime(reader, "Created_Date"),
                .Created_By_User_ID = GetNullableInt32(reader, "Created_By_User_ID")
            }
        End Function

        Private Function MapOrderLine(reader As SqlDataReader) As OrderLine
            Return New OrderLine() With {
                .Order_Line_ID = GetInt32(reader, "Order_Line_ID"),
                .Order_ID = GetInt32(reader, "Order_ID"),
                .Line_Number = GetInt32(reader, "Line_Number"),
                .Item_ID = GetInt32(reader, "Item_ID"),
                .Quantity = GetDecimal(reader, "Quantity"),
                .Unit_Price = GetDecimal(reader, "Unit_Price"),
                .Discount_Percent = GetDecimal(reader, "Discount_Percent"),
                .Line_Total = GetDecimal(reader, "Line_Total"),
                .Notes = GetString(reader, "Notes"),
                .Created_Date = GetDateTime(reader, "Created_Date")
            }
        End Function

    End Class

End Namespace
