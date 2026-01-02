Imports InventoryManagement.Entities
Imports Microsoft.Data.SqlClient

Namespace DataAccess

    ''' <summary>
    ''' Data Access Object for Item entity
    ''' </summary>
    Public Class ItemDAO
        Inherits BaseDAO

        ''' <summary>
        ''' Get all items
        ''' </summary>
        Public Function GetAll() As List(Of Item)
            Dim items As New List(Of Item)()
            Using helper = CreateHelper()
                Dim sql = "SELECT * FROM ITEM ORDER BY Item_Code"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        items.Add(MapItem(reader))
                    End While
                End Using
            End Using
            Return items
        End Function

        ''' <summary>
        ''' Get active items only
        ''' </summary>
        Public Function GetActiveItems() As List(Of Item)
            Dim items As New List(Of Item)()
            Using helper = CreateHelper()
                Dim sql = "SELECT * FROM ITEM WHERE Is_Active = 1 ORDER BY Item_Code"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        items.Add(MapItem(reader))
                    End While
                End Using
            End Using
            Return items
        End Function

        ''' <summary>
        ''' Get items by category
        ''' </summary>
        Public Function GetByCategory(categoryId As Integer) As List(Of Item)
            Dim items As New List(Of Item)()
            Using helper = CreateHelper()
                helper.AddParameter("@CategoryId", categoryId)
                Dim sql = "SELECT * FROM ITEM WHERE Category_ID = @CategoryId AND Is_Active = 1 ORDER BY Item_Code"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        items.Add(MapItem(reader))
                    End While
                End Using
            End Using
            Return items
        End Function

        ''' <summary>
        ''' Get items needing reorder
        ''' </summary>
        Public Function GetItemsNeedingReorder() As List(Of Item)
            Dim items As New List(Of Item)()
            Using helper = CreateHelper()
                Dim sql = "SELECT * FROM ITEM WHERE Is_Active = 1 AND Track_Inventory = 1 " &
                         "AND Stock_Quantity <= Reorder_Level ORDER BY Item_Code"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        items.Add(MapItem(reader))
                    End While
                End Using
            End Using
            Return items
        End Function

        ''' <summary>
        ''' Get item by ID
        ''' </summary>
        Public Function GetById(itemId As Integer) As Item
            Using helper = CreateHelper()
                helper.AddParameter("@Id", itemId)
                Dim sql = "SELECT * FROM ITEM WHERE Item_ID = @Id"
                Using reader = helper.ExecuteReader(sql)
                    If reader.Read() Then
                        Return MapItem(reader)
                    End If
                End Using
            End Using
            Return Nothing
        End Function

        ''' <summary>
        ''' Get item by code
        ''' </summary>
        Public Function GetByCode(itemCode As String) As Item
            Using helper = CreateHelper()
                helper.AddParameter("@Code", itemCode)
                Dim sql = "SELECT * FROM ITEM WHERE Item_Code = @Code"
                Using reader = helper.ExecuteReader(sql)
                    If reader.Read() Then
                        Return MapItem(reader)
                    End If
                End Using
            End Using
            Return Nothing
        End Function

        ''' <summary>
        ''' Search items by name or code
        ''' </summary>
        Public Function Search(searchText As String) As List(Of Item)
            Dim items As New List(Of Item)()
            Using helper = CreateHelper()
                helper.AddParameter("@Search", "%" & searchText & "%")
                Dim sql = "SELECT * FROM ITEM WHERE Is_Active = 1 AND " &
                         "(Item_Code LIKE @Search OR Item_Name LIKE @Search) ORDER BY Item_Code"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        items.Add(MapItem(reader))
                    End While
                End Using
            End Using
            Return items
        End Function

        ''' <summary>
        ''' Insert a new item
        ''' </summary>
        Public Function Insert(item As Item) As Integer
            Using helper = CreateHelper()
                helper.AddParameter("@Code", item.Item_Code)
                helper.AddParameter("@Name", item.Item_Name)
                helper.AddParameter("@Description", item.Description)
                helper.AddParameter("@CategoryId", item.Category_ID)
                helper.AddParameter("@UoMId", item.UoM_ID)
                helper.AddParameter("@Cost", item.Current_Item_Cost)
                helper.AddParameter("@Stock", item.Stock_Quantity)
                helper.AddParameter("@Reorder", item.Reorder_Level)
                helper.AddParameter("@MinStock", item.Min_Stock_Level)
                helper.AddParameter("@MaxStock", item.Max_Stock_Level)
                helper.AddParameter("@TrackInventory", item.Track_Inventory)
                helper.AddParameter("@IsActive", item.Is_Active)

                Dim sql = "INSERT INTO ITEM (Item_Code, Item_Name, Description, Category_ID, UoM_ID, " &
                         "Current_Item_Cost, Stock_Quantity, Reorder_Level, Min_Stock_Level, Max_Stock_Level, " &
                         "Track_Inventory, Is_Active, Created_Date, Modified_Date) " &
                         "VALUES (@Code, @Name, @Description, @CategoryId, @UoMId, @Cost, @Stock, @Reorder, " &
                         "@MinStock, @MaxStock, @TrackInventory, @IsActive, GETDATE(), GETDATE()); " &
                         "SELECT SCOPE_IDENTITY();"

                Dim result = helper.ExecuteScalar(sql)
                If result IsNot Nothing Then
                    item.Item_ID = Convert.ToInt32(result)
                    Return item.Item_ID
                End If
            End Using
            Return 0
        End Function

        ''' <summary>
        ''' Update an existing item
        ''' </summary>
        Public Function Update(item As Item) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", item.Item_ID)
                helper.AddParameter("@Code", item.Item_Code)
                helper.AddParameter("@Name", item.Item_Name)
                helper.AddParameter("@Description", item.Description)
                helper.AddParameter("@CategoryId", item.Category_ID)
                helper.AddParameter("@UoMId", item.UoM_ID)
                helper.AddParameter("@Cost", item.Current_Item_Cost)
                helper.AddParameter("@Reorder", item.Reorder_Level)
                helper.AddParameter("@MinStock", item.Min_Stock_Level)
                helper.AddParameter("@MaxStock", item.Max_Stock_Level)
                helper.AddParameter("@TrackInventory", item.Track_Inventory)
                helper.AddParameter("@IsActive", item.Is_Active)

                Dim sql = "UPDATE ITEM SET Item_Code = @Code, Item_Name = @Name, Description = @Description, " &
                         "Category_ID = @CategoryId, UoM_ID = @UoMId, Current_Item_Cost = @Cost, " &
                         "Reorder_Level = @Reorder, Min_Stock_Level = @MinStock, Max_Stock_Level = @MaxStock, " &
                         "Track_Inventory = @TrackInventory, Is_Active = @IsActive, Modified_Date = GETDATE() " &
                         "WHERE Item_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Update item stock quantity
        ''' </summary>
        Public Function UpdateStock(itemId As Integer, newStock As Decimal) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", itemId)
                helper.AddParameter("@Stock", newStock)
                Dim sql = "UPDATE ITEM SET Stock_Quantity = @Stock, Modified_Date = GETDATE() WHERE Item_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Update item cost
        ''' </summary>
        Public Function UpdateCost(itemId As Integer, newCost As Decimal) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", itemId)
                helper.AddParameter("@Cost", newCost)
                Dim sql = "UPDATE ITEM SET Current_Item_Cost = @Cost, Modified_Date = GETDATE() WHERE Item_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Delete an item (soft delete)
        ''' </summary>
        Public Function Delete(itemId As Integer) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", itemId)
                Dim sql = "UPDATE ITEM SET Is_Active = 0, Modified_Date = GETDATE() WHERE Item_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        Private Function MapItem(reader As SqlDataReader) As Item
            Return New Item() With {
                .Item_ID = GetInt32(reader, "Item_ID"),
                .Item_Code = GetString(reader, "Item_Code"),
                .Item_Name = GetString(reader, "Item_Name"),
                .Description = GetString(reader, "Description"),
                .Category_ID = GetNullableInt32(reader, "Category_ID"),
                .UoM_ID = GetNullableInt32(reader, "UoM_ID"),
                .Current_Item_Cost = GetDecimal(reader, "Current_Item_Cost"),
                .Stock_Quantity = GetDecimal(reader, "Stock_Quantity"),
                .Reorder_Level = GetDecimal(reader, "Reorder_Level"),
                .Min_Stock_Level = GetDecimal(reader, "Min_Stock_Level"),
                .Max_Stock_Level = GetDecimal(reader, "Max_Stock_Level"),
                .Track_Inventory = GetBoolean(reader, "Track_Inventory"),
                .Is_Active = GetBoolean(reader, "Is_Active"),
                .Created_Date = GetDateTime(reader, "Created_Date"),
                .Modified_Date = GetDateTime(reader, "Modified_Date")
            }
        End Function

    End Class

End Namespace
