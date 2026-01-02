Imports InventoryManagement.Entities
Imports Microsoft.Data.SqlClient

Namespace DataAccess

    ''' <summary>
    ''' Data Access Object for StockHistory entity
    ''' </summary>
    Public Class StockHistoryDAO
        Inherits BaseDAO

        ''' <summary>
        ''' Get all stock history
        ''' </summary>
        Public Function GetAll() As List(Of StockHistory)
            Dim histories As New List(Of StockHistory)()
            Using helper = CreateHelper()
                Dim sql = "SELECT sh.*, i.Item_Code, i.Item_Name FROM STOCK_HISTORY sh " &
                         "INNER JOIN ITEM i ON sh.Item_ID = i.Item_ID ORDER BY sh.Transaction_Date DESC"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        Dim history = MapStockHistory(reader)
                        history.Item = New Item() With {
                            .Item_ID = history.Item_ID,
                            .Item_Code = GetString(reader, "Item_Code"),
                            .Item_Name = GetString(reader, "Item_Name")
                        }
                        histories.Add(history)
                    End While
                End Using
            End Using
            Return histories
        End Function

        ''' <summary>
        ''' Get stock history for an item
        ''' </summary>
        Public Function GetByItemId(itemId As Integer) As List(Of StockHistory)
            Dim histories As New List(Of StockHistory)()
            Using helper = CreateHelper()
                helper.AddParameter("@ItemId", itemId)
                Dim sql = "SELECT * FROM STOCK_HISTORY WHERE Item_ID = @ItemId ORDER BY Transaction_Date DESC"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        histories.Add(MapStockHistory(reader))
                    End While
                End Using
            End Using
            Return histories
        End Function

        ''' <summary>
        ''' Get stock history by date range
        ''' </summary>
        Public Function GetByDateRange(startDate As DateTime, endDate As DateTime) As List(Of StockHistory)
            Dim histories As New List(Of StockHistory)()
            Using helper = CreateHelper()
                helper.AddParameter("@StartDate", startDate)
                helper.AddParameter("@EndDate", endDate)
                Dim sql = "SELECT sh.*, i.Item_Code, i.Item_Name FROM STOCK_HISTORY sh " &
                         "INNER JOIN ITEM i ON sh.Item_ID = i.Item_ID " &
                         "WHERE sh.Transaction_Date >= @StartDate AND sh.Transaction_Date <= @EndDate " &
                         "ORDER BY sh.Transaction_Date DESC"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        Dim history = MapStockHistory(reader)
                        history.Item = New Item() With {
                            .Item_ID = history.Item_ID,
                            .Item_Code = GetString(reader, "Item_Code"),
                            .Item_Name = GetString(reader, "Item_Name")
                        }
                        histories.Add(history)
                    End While
                End Using
            End Using
            Return histories
        End Function

        ''' <summary>
        ''' Get stock history by transaction type
        ''' </summary>
        Public Function GetByTransactionType(transactionType As String) As List(Of StockHistory)
            Dim histories As New List(Of StockHistory)()
            Using helper = CreateHelper()
                helper.AddParameter("@Type", transactionType)
                Dim sql = "SELECT sh.*, i.Item_Code, i.Item_Name FROM STOCK_HISTORY sh " &
                         "INNER JOIN ITEM i ON sh.Item_ID = i.Item_ID " &
                         "WHERE sh.Transaction_Type = @Type ORDER BY sh.Transaction_Date DESC"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        Dim history = MapStockHistory(reader)
                        history.Item = New Item() With {
                            .Item_ID = history.Item_ID,
                            .Item_Code = GetString(reader, "Item_Code"),
                            .Item_Name = GetString(reader, "Item_Name")
                        }
                        histories.Add(history)
                    End While
                End Using
            End Using
            Return histories
        End Function

        ''' <summary>
        ''' Insert a new stock history record
        ''' </summary>
        Public Function Insert(history As StockHistory) As Integer
            Using helper = CreateHelper()
                helper.AddParameter("@ItemId", history.Item_ID)
                helper.AddParameter("@TransactionDate", history.Transaction_Date)
                helper.AddParameter("@TransactionType", history.Transaction_Type)
                helper.AddParameter("@ReferenceId", history.Reference_ID)
                helper.AddParameter("@ReferenceType", history.Reference_Type)
                helper.AddParameter("@QuantityChange", history.Quantity_Change)
                helper.AddParameter("@StockBefore", history.Stock_Before)
                helper.AddParameter("@StockAfter", history.Stock_After)
                helper.AddParameter("@UnitCost", history.Unit_Cost)
                helper.AddParameter("@UserId", history.User_ID)
                helper.AddParameter("@Notes", history.Notes)

                Dim sql = "INSERT INTO STOCK_HISTORY (Item_ID, Transaction_Date, Transaction_Type, " &
                         "Reference_ID, Reference_Type, Quantity_Change, Stock_Before, Stock_After, " &
                         "Unit_Cost, User_ID, Notes, Created_Date) VALUES (@ItemId, @TransactionDate, " &
                         "@TransactionType, @ReferenceId, @ReferenceType, @QuantityChange, @StockBefore, " &
                         "@StockAfter, @UnitCost, @UserId, @Notes, GETDATE()); SELECT SCOPE_IDENTITY();"

                Dim result = helper.ExecuteScalar(sql)
                If result IsNot Nothing Then
                    history.History_ID = Convert.ToInt32(result)
                    Return history.History_ID
                End If
            End Using
            Return 0
        End Function

        ''' <summary>
        ''' Log a stock transaction
        ''' </summary>
        Public Function LogTransaction(item As Item, quantityChange As Decimal, transactionType As String,
                                       referenceId As Integer?, referenceType As String, userId As Integer?,
                                       notes As String) As Integer
            Dim history = StockHistory.CreateHistory(item, quantityChange, transactionType,
                                                    referenceId, referenceType, userId, notes)
            Return Insert(history)
        End Function

        Private Function MapStockHistory(reader As SqlDataReader) As StockHistory
            Return New StockHistory() With {
                .History_ID = GetInt32(reader, "History_ID"),
                .Item_ID = GetInt32(reader, "Item_ID"),
                .Transaction_Date = GetDateTime(reader, "Transaction_Date"),
                .Transaction_Type = GetString(reader, "Transaction_Type"),
                .Reference_ID = GetNullableInt32(reader, "Reference_ID"),
                .Reference_Type = GetString(reader, "Reference_Type"),
                .Quantity_Change = GetDecimal(reader, "Quantity_Change"),
                .Stock_Before = GetDecimal(reader, "Stock_Before"),
                .Stock_After = GetDecimal(reader, "Stock_After"),
                .Unit_Cost = GetDecimal(reader, "Unit_Cost"),
                .User_ID = GetNullableInt32(reader, "User_ID"),
                .Notes = GetString(reader, "Notes"),
                .Created_Date = GetDateTime(reader, "Created_Date")
            }
        End Function

    End Class

End Namespace
