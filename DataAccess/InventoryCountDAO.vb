Imports InventoryManagement.Entities
Imports Microsoft.Data.SqlClient

Namespace DataAccess

    ''' <summary>
    ''' Data Access Object for InventoryCount entity
    ''' </summary>
    Public Class InventoryCountDAO
        Inherits BaseDAO

        ''' <summary>
        ''' Get all inventory counts
        ''' </summary>
        Public Function GetAll() As List(Of InventoryCount)
            Dim counts As New List(Of InventoryCount)()
            Using helper = CreateHelper()
                Dim sql = "SELECT ic.*, i.Item_Code, i.Item_Name FROM INVENTORY_COUNT ic " &
                         "INNER JOIN ITEM i ON ic.Item_ID = i.Item_ID ORDER BY ic.Count_Date DESC"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        Dim count = MapInventoryCount(reader)
                        count.Item = New Item() With {
                            .Item_ID = count.Item_ID,
                            .Item_Code = GetString(reader, "Item_Code"),
                            .Item_Name = GetString(reader, "Item_Name")
                        }
                        counts.Add(count)
                    End While
                End Using
            End Using
            Return counts
        End Function

        ''' <summary>
        ''' Get inventory counts by status
        ''' </summary>
        Public Function GetByStatus(status As String) As List(Of InventoryCount)
            Dim counts As New List(Of InventoryCount)()
            Using helper = CreateHelper()
                helper.AddParameter("@Status", status)
                Dim sql = "SELECT ic.*, i.Item_Code, i.Item_Name FROM INVENTORY_COUNT ic " &
                         "INNER JOIN ITEM i ON ic.Item_ID = i.Item_ID " &
                         "WHERE ic.Count_Status = @Status ORDER BY ic.Count_Date DESC"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        Dim count = MapInventoryCount(reader)
                        count.Item = New Item() With {
                            .Item_ID = count.Item_ID,
                            .Item_Code = GetString(reader, "Item_Code"),
                            .Item_Name = GetString(reader, "Item_Name")
                        }
                        counts.Add(count)
                    End While
                End Using
            End Using
            Return counts
        End Function

        ''' <summary>
        ''' Get inventory count by ID
        ''' </summary>
        Public Function GetById(countId As Integer) As InventoryCount
            Using helper = CreateHelper()
                helper.AddParameter("@Id", countId)
                Dim sql = "SELECT ic.*, i.Item_Code, i.Item_Name, i.Stock_Quantity, i.Current_Item_Cost " &
                         "FROM INVENTORY_COUNT ic INNER JOIN ITEM i ON ic.Item_ID = i.Item_ID " &
                         "WHERE ic.Count_ID = @Id"
                Using reader = helper.ExecuteReader(sql)
                    If reader.Read() Then
                        Dim count = MapInventoryCount(reader)
                        count.Item = New Item() With {
                            .Item_ID = count.Item_ID,
                            .Item_Code = GetString(reader, "Item_Code"),
                            .Item_Name = GetString(reader, "Item_Name"),
                            .Stock_Quantity = GetDecimal(reader, "Stock_Quantity"),
                            .Current_Item_Cost = GetDecimal(reader, "Current_Item_Cost")
                        }
                        Return count
                    End If
                End Using
            End Using
            Return Nothing
        End Function

        ''' <summary>
        ''' Get counts for an item
        ''' </summary>
        Public Function GetByItemId(itemId As Integer) As List(Of InventoryCount)
            Dim counts As New List(Of InventoryCount)()
            Using helper = CreateHelper()
                helper.AddParameter("@ItemId", itemId)
                Dim sql = "SELECT * FROM INVENTORY_COUNT WHERE Item_ID = @ItemId ORDER BY Count_Date DESC"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        counts.Add(MapInventoryCount(reader))
                    End While
                End Using
            End Using
            Return counts
        End Function

        ''' <summary>
        ''' Insert a new inventory count
        ''' </summary>
        Public Function Insert(count As InventoryCount) As Integer
            Using helper = CreateHelper()
                helper.AddParameter("@CountDate", count.Count_Date)
                helper.AddParameter("@ItemId", count.Item_ID)
                helper.AddParameter("@SystemQuantity", count.System_Quantity)
                helper.AddParameter("@QuantityCounted", count.Quantity_Counted)
                helper.AddParameter("@QuantityChange", count.Quantity_Change)
                helper.AddParameter("@UnitCost", count.Unit_Cost)
                helper.AddParameter("@VarianceValue", count.Variance_Value)
                helper.AddParameter("@Status", count.Count_Status)
                helper.AddParameter("@CountedBy", count.Counted_By_User_ID)
                helper.AddParameter("@Notes", count.Notes)

                Dim sql = "INSERT INTO INVENTORY_COUNT (Count_Date, Item_ID, System_Quantity, Quantity_Counted, " &
                         "Quantity_Change, Unit_Cost, Variance_Value, Count_Status, Counted_By_User_ID, Notes, " &
                         "Created_Date) VALUES (@CountDate, @ItemId, @SystemQuantity, @QuantityCounted, " &
                         "@QuantityChange, @UnitCost, @VarianceValue, @Status, @CountedBy, @Notes, GETDATE()); " &
                         "SELECT SCOPE_IDENTITY();"

                Dim result = helper.ExecuteScalar(sql)
                If result IsNot Nothing Then
                    count.Count_ID = Convert.ToInt32(result)
                    Return count.Count_ID
                End If
            End Using
            Return 0
        End Function

        ''' <summary>
        ''' Update an existing inventory count
        ''' </summary>
        Public Function Update(count As InventoryCount) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", count.Count_ID)
                helper.AddParameter("@QuantityCounted", count.Quantity_Counted)
                helper.AddParameter("@QuantityChange", count.Quantity_Change)
                helper.AddParameter("@VarianceValue", count.Variance_Value)
                helper.AddParameter("@Status", count.Count_Status)
                helper.AddParameter("@Notes", count.Notes)

                Dim sql = "UPDATE INVENTORY_COUNT SET Quantity_Counted = @QuantityCounted, " &
                         "Quantity_Change = @QuantityChange, Variance_Value = @VarianceValue, " &
                         "Count_Status = @Status, Notes = @Notes WHERE Count_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Approve an inventory count
        ''' </summary>
        Public Function ApproveCount(countId As Integer, userId As Integer) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", countId)
                helper.AddParameter("@UserId", userId)
                Dim sql = "UPDATE INVENTORY_COUNT SET Count_Status = 'Completed', " &
                         "Approved_By_User_ID = @UserId, Approved_Date = GETDATE() WHERE Count_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Mark count as applied
        ''' </summary>
        Public Function MarkAsApplied(countId As Integer) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", countId)
                Dim sql = "UPDATE INVENTORY_COUNT SET Count_Status = 'Applied' WHERE Count_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Delete an inventory count
        ''' </summary>
        Public Function Delete(countId As Integer) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", countId)
                Dim sql = "DELETE FROM INVENTORY_COUNT WHERE Count_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        Private Function MapInventoryCount(reader As SqlDataReader) As InventoryCount
            Return New InventoryCount() With {
                .Count_ID = GetInt32(reader, "Count_ID"),
                .Count_Date = GetDateTime(reader, "Count_Date"),
                .Item_ID = GetInt32(reader, "Item_ID"),
                .System_Quantity = GetDecimal(reader, "System_Quantity"),
                .Quantity_Counted = GetDecimal(reader, "Quantity_Counted"),
                .Quantity_Change = GetDecimal(reader, "Quantity_Change"),
                .Unit_Cost = GetDecimal(reader, "Unit_Cost"),
                .Variance_Value = GetDecimal(reader, "Variance_Value"),
                .Count_Status = GetString(reader, "Count_Status"),
                .Counted_By_User_ID = GetNullableInt32(reader, "Counted_By_User_ID"),
                .Approved_By_User_ID = GetNullableInt32(reader, "Approved_By_User_ID"),
                .Approved_Date = GetNullableDateTime(reader, "Approved_Date"),
                .Notes = GetString(reader, "Notes"),
                .Created_Date = GetDateTime(reader, "Created_Date")
            }
        End Function

    End Class

End Namespace
