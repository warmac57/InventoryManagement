Imports InventoryManagement.Entities
Imports Microsoft.Data.SqlClient

Namespace DataAccess

    ''' <summary>
    ''' Data Access Object for PurchaseHeader and PurchaseItem entities
    ''' </summary>
    Public Class PurchaseDAO
        Inherits BaseDAO

        ''' <summary>
        ''' Get all purchases
        ''' </summary>
        Public Function GetAll() As List(Of PurchaseHeader)
            Dim purchases As New List(Of PurchaseHeader)()
            Using helper = CreateHelper()
                Dim sql = "SELECT p.*, s.Supplier_Name FROM PURCHASE_HEADER p " &
                         "INNER JOIN SUPPLIER s ON p.Supplier_ID = s.Supplier_ID ORDER BY p.Purchase_Date DESC"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        Dim purchase = MapPurchaseHeader(reader)
                        purchase.Supplier = New Supplier() With {
                            .Supplier_ID = purchase.Supplier_ID,
                            .Supplier_Name = GetString(reader, "Supplier_Name")
                        }
                        purchases.Add(purchase)
                    End While
                End Using
            End Using
            Return purchases
        End Function

        ''' <summary>
        ''' Get purchases by status
        ''' </summary>
        Public Function GetByStatus(status As String) As List(Of PurchaseHeader)
            Dim purchases As New List(Of PurchaseHeader)()
            Using helper = CreateHelper()
                helper.AddParameter("@Status", status)
                Dim sql = "SELECT p.*, s.Supplier_Name FROM PURCHASE_HEADER p " &
                         "INNER JOIN SUPPLIER s ON p.Supplier_ID = s.Supplier_ID " &
                         "WHERE p.Purchase_Status = @Status ORDER BY p.Purchase_Date DESC"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        Dim purchase = MapPurchaseHeader(reader)
                        purchase.Supplier = New Supplier() With {
                            .Supplier_ID = purchase.Supplier_ID,
                            .Supplier_Name = GetString(reader, "Supplier_Name")
                        }
                        purchases.Add(purchase)
                    End While
                End Using
            End Using
            Return purchases
        End Function

        ''' <summary>
        ''' Get purchase by ID with items
        ''' </summary>
        Public Function GetById(purchaseId As Integer) As PurchaseHeader
            Using helper = CreateHelper()
                helper.AddParameter("@Id", purchaseId)
                Dim sql = "SELECT p.*, s.Supplier_Name, s.Supplier_Code FROM PURCHASE_HEADER p " &
                         "INNER JOIN SUPPLIER s ON p.Supplier_ID = s.Supplier_ID WHERE p.Purchase_ID = @Id"
                Using reader = helper.ExecuteReader(sql)
                    If reader.Read() Then
                        Dim purchase = MapPurchaseHeader(reader)
                        purchase.Supplier = New Supplier() With {
                            .Supplier_ID = purchase.Supplier_ID,
                            .Supplier_Code = GetString(reader, "Supplier_Code"),
                            .Supplier_Name = GetString(reader, "Supplier_Name")
                        }
                        purchase.PurchaseItems = GetPurchaseItems(purchaseId)
                        Return purchase
                    End If
                End Using
            End Using
            Return Nothing
        End Function

        ''' <summary>
        ''' Get purchase items for a purchase
        ''' </summary>
        Public Function GetPurchaseItems(purchaseId As Integer) As List(Of PurchaseItem)
            Dim items As New List(Of PurchaseItem)()
            Using helper = CreateHelper()
                helper.AddParameter("@PurchaseId", purchaseId)
                Dim sql = "SELECT pi.*, i.Item_Code, i.Item_Name, i.Current_Item_Cost, i.Stock_Quantity " &
                         "FROM PURCHASE_ITEM pi INNER JOIN ITEM i ON pi.Item_ID = i.Item_ID " &
                         "WHERE pi.Purchase_ID = @PurchaseId ORDER BY pi.Line_Number"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        Dim item = MapPurchaseItem(reader)
                        item.Item = New Item() With {
                            .Item_ID = item.Item_ID,
                            .Item_Code = GetString(reader, "Item_Code"),
                            .Item_Name = GetString(reader, "Item_Name"),
                            .Current_Item_Cost = GetDecimal(reader, "Current_Item_Cost"),
                            .Stock_Quantity = GetDecimal(reader, "Stock_Quantity")
                        }
                        items.Add(item)
                    End While
                End Using
            End Using
            Return items
        End Function

        ''' <summary>
        ''' Get next purchase number
        ''' </summary>
        Public Function GetNextPurchaseNumber(prefix As String) As String
            Using helper = CreateHelper()
                Dim year = DateTime.Now.Year
                Dim sql = $"SELECT ISNULL(MAX(CAST(RIGHT(Purchase_Number, 4) AS INT)), 0) + 1 " &
                         $"FROM PURCHASE_HEADER WHERE Purchase_Number LIKE '{prefix}{year}-%'"
                Dim result = helper.ExecuteScalar(sql)
                Dim nextNum = If(result IsNot Nothing, Convert.ToInt32(result), 1)
                Return $"{prefix}{year}-{nextNum:D4}"
            End Using
        End Function

        ''' <summary>
        ''' Insert a new purchase
        ''' </summary>
        Public Function Insert(purchase As PurchaseHeader) As Integer
            Using helper = CreateHelper()
                helper.AddParameter("@Number", purchase.Purchase_Number)
                helper.AddParameter("@Date", purchase.Purchase_Date)
                helper.AddParameter("@SupplierId", purchase.Supplier_ID)
                helper.AddParameter("@Status", purchase.Purchase_Status)
                helper.AddParameter("@Subtotal", purchase.Subtotal)
                helper.AddParameter("@TaxAmount", purchase.Tax_Amount)
                helper.AddParameter("@TotalAmount", purchase.Total_Amount)
                helper.AddParameter("@ExpectedDate", purchase.Expected_Date)
                helper.AddParameter("@Notes", purchase.Notes)
                helper.AddParameter("@CreatedBy", purchase.Created_By_User_ID)

                Dim sql = "INSERT INTO PURCHASE_HEADER (Purchase_Number, Purchase_Date, Supplier_ID, " &
                         "Purchase_Status, Subtotal, Tax_Amount, Total_Amount, Expected_Date, Notes, " &
                         "Created_Date, Created_By_User_ID) VALUES (@Number, @Date, @SupplierId, @Status, " &
                         "@Subtotal, @TaxAmount, @TotalAmount, @ExpectedDate, @Notes, GETDATE(), @CreatedBy); " &
                         "SELECT SCOPE_IDENTITY();"

                Dim result = helper.ExecuteScalar(sql)
                If result IsNot Nothing Then
                    purchase.Purchase_ID = Convert.ToInt32(result)
                    Return purchase.Purchase_ID
                End If
            End Using
            Return 0
        End Function

        ''' <summary>
        ''' Update an existing purchase
        ''' </summary>
        Public Function Update(purchase As PurchaseHeader) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", purchase.Purchase_ID)
                helper.AddParameter("@SupplierId", purchase.Supplier_ID)
                helper.AddParameter("@Status", purchase.Purchase_Status)
                helper.AddParameter("@Subtotal", purchase.Subtotal)
                helper.AddParameter("@TaxAmount", purchase.Tax_Amount)
                helper.AddParameter("@TotalAmount", purchase.Total_Amount)
                helper.AddParameter("@ExpectedDate", purchase.Expected_Date)
                helper.AddParameter("@Notes", purchase.Notes)

                Dim sql = "UPDATE PURCHASE_HEADER SET Supplier_ID = @SupplierId, Purchase_Status = @Status, " &
                         "Subtotal = @Subtotal, Tax_Amount = @TaxAmount, Total_Amount = @TotalAmount, " &
                         "Expected_Date = @ExpectedDate, Notes = @Notes WHERE Purchase_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Receive a purchase order
        ''' </summary>
        Public Function ReceivePurchase(purchaseId As Integer, userId As Integer) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", purchaseId)
                helper.AddParameter("@UserId", userId)
                Dim sql = "UPDATE PURCHASE_HEADER SET Purchase_Status = 'Received', Is_Received = 1, " &
                         "Received_By_User_ID = @UserId, Received_Date = GETDATE() WHERE Purchase_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Insert a purchase item
        ''' </summary>
        Public Function InsertItem(item As PurchaseItem) As Integer
            Using helper = CreateHelper()
                helper.AddParameter("@PurchaseId", item.Purchase_ID)
                helper.AddParameter("@LineNumber", item.Line_Number)
                helper.AddParameter("@ItemId", item.Item_ID)
                helper.AddParameter("@Quantity", item.Quantity)
                helper.AddParameter("@UnitCost", item.Unit_Cost)
                helper.AddParameter("@LineTotal", item.Line_Total)
                helper.AddParameter("@Notes", item.Notes)

                Dim sql = "INSERT INTO PURCHASE_ITEM (Purchase_ID, Line_Number, Item_ID, Quantity, Unit_Cost, " &
                         "Line_Total, Notes, Created_Date) VALUES (@PurchaseId, @LineNumber, @ItemId, @Quantity, " &
                         "@UnitCost, @LineTotal, @Notes, GETDATE()); SELECT SCOPE_IDENTITY();"

                Dim result = helper.ExecuteScalar(sql)
                If result IsNot Nothing Then
                    item.Purchase_Item_ID = Convert.ToInt32(result)
                    Return item.Purchase_Item_ID
                End If
            End Using
            Return 0
        End Function

        ''' <summary>
        ''' Update a purchase item
        ''' </summary>
        Public Function UpdateItem(item As PurchaseItem) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", item.Purchase_Item_ID)
                helper.AddParameter("@ItemId", item.Item_ID)
                helper.AddParameter("@Quantity", item.Quantity)
                helper.AddParameter("@UnitCost", item.Unit_Cost)
                helper.AddParameter("@LineTotal", item.Line_Total)
                helper.AddParameter("@Notes", item.Notes)

                Dim sql = "UPDATE PURCHASE_ITEM SET Item_ID = @ItemId, Quantity = @Quantity, " &
                         "Unit_Cost = @UnitCost, Line_Total = @LineTotal, Notes = @Notes " &
                         "WHERE Purchase_Item_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Delete a purchase item
        ''' </summary>
        Public Function DeleteItem(itemId As Integer) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", itemId)
                Dim sql = "DELETE FROM PURCHASE_ITEM WHERE Purchase_Item_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        Private Function MapPurchaseHeader(reader As SqlDataReader) As PurchaseHeader
            Return New PurchaseHeader() With {
                .Purchase_ID = GetInt32(reader, "Purchase_ID"),
                .Purchase_Number = GetString(reader, "Purchase_Number"),
                .Purchase_Date = GetDateTime(reader, "Purchase_Date"),
                .Supplier_ID = GetInt32(reader, "Supplier_ID"),
                .Purchase_Status = GetString(reader, "Purchase_Status"),
                .Subtotal = GetDecimal(reader, "Subtotal"),
                .Tax_Amount = GetDecimal(reader, "Tax_Amount"),
                .Total_Amount = GetDecimal(reader, "Total_Amount"),
                .Expected_Date = GetNullableDateTime(reader, "Expected_Date"),
                .Received_Date = GetNullableDateTime(reader, "Received_Date"),
                .Notes = GetString(reader, "Notes"),
                .Is_Received = GetBoolean(reader, "Is_Received"),
                .Received_By_User_ID = GetNullableInt32(reader, "Received_By_User_ID"),
                .Created_Date = GetDateTime(reader, "Created_Date"),
                .Created_By_User_ID = GetNullableInt32(reader, "Created_By_User_ID")
            }
        End Function

        Private Function MapPurchaseItem(reader As SqlDataReader) As PurchaseItem
            Return New PurchaseItem() With {
                .Purchase_Item_ID = GetInt32(reader, "Purchase_Item_ID"),
                .Purchase_ID = GetInt32(reader, "Purchase_ID"),
                .Line_Number = GetInt32(reader, "Line_Number"),
                .Item_ID = GetInt32(reader, "Item_ID"),
                .Quantity = GetDecimal(reader, "Quantity"),
                .Unit_Cost = GetDecimal(reader, "Unit_Cost"),
                .Line_Total = GetDecimal(reader, "Line_Total"),
                .Notes = GetString(reader, "Notes"),
                .Created_Date = GetDateTime(reader, "Created_Date")
            }
        End Function

    End Class

End Namespace
