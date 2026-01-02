Imports InventoryManagement.Entities
Imports Microsoft.Data.SqlClient

Namespace DataAccess

    ''' <summary>
    ''' Data Access Object for Category entity
    ''' </summary>
    Public Class CategoryDAO
        Inherits BaseDAO

        ''' <summary>
        ''' Get all categories
        ''' </summary>
        Public Function GetAll() As List(Of Category)
            Dim categories As New List(Of Category)()
            Using helper = CreateHelper()
                Dim sql = "SELECT * FROM CATEGORY ORDER BY Category_Name"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        categories.Add(MapCategory(reader))
                    End While
                End Using
            End Using
            Return categories
        End Function

        ''' <summary>
        ''' Get active categories only
        ''' </summary>
        Public Function GetActiveCategories() As List(Of Category)
            Dim categories As New List(Of Category)()
            Using helper = CreateHelper()
                Dim sql = "SELECT * FROM CATEGORY WHERE Is_Active = 1 ORDER BY Category_Name"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        categories.Add(MapCategory(reader))
                    End While
                End Using
            End Using
            Return categories
        End Function

        ''' <summary>
        ''' Get root categories (no parent)
        ''' </summary>
        Public Function GetRootCategories() As List(Of Category)
            Dim categories As New List(Of Category)()
            Using helper = CreateHelper()
                Dim sql = "SELECT * FROM CATEGORY WHERE Parent_Category_ID IS NULL AND Is_Active = 1 ORDER BY Category_Name"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        categories.Add(MapCategory(reader))
                    End While
                End Using
            End Using
            Return categories
        End Function

        ''' <summary>
        ''' Get sub-categories of a parent
        ''' </summary>
        Public Function GetSubCategories(parentId As Integer) As List(Of Category)
            Dim categories As New List(Of Category)()
            Using helper = CreateHelper()
                helper.AddParameter("@ParentId", parentId)
                Dim sql = "SELECT * FROM CATEGORY WHERE Parent_Category_ID = @ParentId AND Is_Active = 1 ORDER BY Category_Name"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        categories.Add(MapCategory(reader))
                    End While
                End Using
            End Using
            Return categories
        End Function

        ''' <summary>
        ''' Get category by ID
        ''' </summary>
        Public Function GetById(categoryId As Integer) As Category
            Using helper = CreateHelper()
                helper.AddParameter("@Id", categoryId)
                Dim sql = "SELECT * FROM CATEGORY WHERE Category_ID = @Id"
                Using reader = helper.ExecuteReader(sql)
                    If reader.Read() Then
                        Return MapCategory(reader)
                    End If
                End Using
            End Using
            Return Nothing
        End Function

        ''' <summary>
        ''' Insert a new category
        ''' </summary>
        Public Function Insert(category As Category) As Integer
            Using helper = CreateHelper()
                helper.AddParameter("@Name", category.Category_Name)
                helper.AddParameter("@Description", category.Description)
                helper.AddParameter("@ParentId", category.Parent_Category_ID)
                helper.AddParameter("@IsActive", category.Is_Active)

                Dim sql = "INSERT INTO CATEGORY (Category_Name, Description, Parent_Category_ID, Is_Active) " &
                         "VALUES (@Name, @Description, @ParentId, @IsActive); SELECT SCOPE_IDENTITY();"

                Dim result = helper.ExecuteScalar(sql)
                If result IsNot Nothing Then
                    category.Category_ID = Convert.ToInt32(result)
                    Return category.Category_ID
                End If
            End Using
            Return 0
        End Function

        ''' <summary>
        ''' Update an existing category
        ''' </summary>
        Public Function Update(category As Category) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", category.Category_ID)
                helper.AddParameter("@Name", category.Category_Name)
                helper.AddParameter("@Description", category.Description)
                helper.AddParameter("@ParentId", category.Parent_Category_ID)
                helper.AddParameter("@IsActive", category.Is_Active)

                Dim sql = "UPDATE CATEGORY SET Category_Name = @Name, Description = @Description, " &
                         "Parent_Category_ID = @ParentId, Is_Active = @IsActive WHERE Category_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Delete a category (soft delete)
        ''' </summary>
        Public Function Delete(categoryId As Integer) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", categoryId)
                Dim sql = "UPDATE CATEGORY SET Is_Active = 0 WHERE Category_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        Private Function MapCategory(reader As SqlDataReader) As Category
            Return New Category() With {
                .Category_ID = GetInt32(reader, "Category_ID"),
                .Category_Name = GetString(reader, "Category_Name"),
                .Description = GetString(reader, "Description"),
                .Parent_Category_ID = GetNullableInt32(reader, "Parent_Category_ID"),
                .Is_Active = GetBoolean(reader, "Is_Active")
            }
        End Function

    End Class

End Namespace
