Imports InventoryManagement.Entities
Imports Microsoft.Data.SqlClient

Namespace DataAccess

    ''' <summary>
    ''' Data Access Object for LOV (List of Values) entity
    ''' </summary>
    Public Class LOVDAO
        Inherits BaseDAO

        ''' <summary>
        ''' Get all LOV entries
        ''' </summary>
        Public Function GetAll() As List(Of LOV)
            Dim lovs As New List(Of LOV)()
            Using helper = CreateHelper()
                Dim sql = "SELECT * FROM LOV ORDER BY LOV_Type, Display_Order"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        lovs.Add(MapLOV(reader))
                    End While
                End Using
            End Using
            Return lovs
        End Function

        ''' <summary>
        ''' Get LOV entries by type
        ''' </summary>
        Public Function GetByType(lovType As String) As List(Of LOV)
            Dim lovs As New List(Of LOV)()
            Using helper = CreateHelper()
                helper.AddParameter("@Type", lovType)
                Dim sql = "SELECT * FROM LOV WHERE LOV_Type = @Type AND Is_Active = 1 ORDER BY Display_Order"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        lovs.Add(MapLOV(reader))
                    End While
                End Using
            End Using
            Return lovs
        End Function

        ''' <summary>
        ''' Get distinct LOV types
        ''' </summary>
        Public Function GetTypes() As List(Of String)
            Dim types As New List(Of String)()
            Using helper = CreateHelper()
                Dim sql = "SELECT DISTINCT LOV_Type FROM LOV ORDER BY LOV_Type"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        types.Add(GetString(reader, "LOV_Type"))
                    End While
                End Using
            End Using
            Return types
        End Function

        ''' <summary>
        ''' Get LOV by ID
        ''' </summary>
        Public Function GetById(lovId As Integer) As LOV
            Using helper = CreateHelper()
                helper.AddParameter("@Id", lovId)
                Dim sql = "SELECT * FROM LOV WHERE LOV_ID = @Id"
                Using reader = helper.ExecuteReader(sql)
                    If reader.Read() Then
                        Return MapLOV(reader)
                    End If
                End Using
            End Using
            Return Nothing
        End Function

        ''' <summary>
        ''' Get LOV by type and code
        ''' </summary>
        Public Function GetByTypeAndCode(lovType As String, lovCode As String) As LOV
            Using helper = CreateHelper()
                helper.AddParameter("@Type", lovType)
                helper.AddParameter("@Code", lovCode)
                Dim sql = "SELECT * FROM LOV WHERE LOV_Type = @Type AND LOV_Code = @Code"
                Using reader = helper.ExecuteReader(sql)
                    If reader.Read() Then
                        Return MapLOV(reader)
                    End If
                End Using
            End Using
            Return Nothing
        End Function

        ''' <summary>
        ''' Insert a new LOV entry
        ''' </summary>
        Public Function Insert(lov As LOV) As Integer
            Using helper = CreateHelper()
                helper.AddParameter("@Type", lov.LOV_Type)
                helper.AddParameter("@Code", lov.LOV_Code)
                helper.AddParameter("@Value", lov.LOV_Value)
                helper.AddParameter("@Order", lov.Display_Order)
                helper.AddParameter("@IsActive", lov.Is_Active)

                Dim sql = "INSERT INTO LOV (LOV_Type, LOV_Code, LOV_Value, Display_Order, Is_Active) " &
                         "VALUES (@Type, @Code, @Value, @Order, @IsActive); SELECT SCOPE_IDENTITY();"

                Dim result = helper.ExecuteScalar(sql)
                If result IsNot Nothing Then
                    lov.LOV_ID = Convert.ToInt32(result)
                    Return lov.LOV_ID
                End If
            End Using
            Return 0
        End Function

        ''' <summary>
        ''' Update an existing LOV entry
        ''' </summary>
        Public Function Update(lov As LOV) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", lov.LOV_ID)
                helper.AddParameter("@Type", lov.LOV_Type)
                helper.AddParameter("@Code", lov.LOV_Code)
                helper.AddParameter("@Value", lov.LOV_Value)
                helper.AddParameter("@Order", lov.Display_Order)
                helper.AddParameter("@IsActive", lov.Is_Active)

                Dim sql = "UPDATE LOV SET LOV_Type = @Type, LOV_Code = @Code, LOV_Value = @Value, " &
                         "Display_Order = @Order, Is_Active = @IsActive WHERE LOV_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Delete a LOV entry (soft delete)
        ''' </summary>
        Public Function Delete(lovId As Integer) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", lovId)
                Dim sql = "UPDATE LOV SET Is_Active = 0 WHERE LOV_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        Private Function MapLOV(reader As SqlDataReader) As LOV
            Return New LOV() With {
                .LOV_ID = GetInt32(reader, "LOV_ID"),
                .LOV_Type = GetString(reader, "LOV_Type"),
                .LOV_Code = GetString(reader, "LOV_Code"),
                .LOV_Value = GetString(reader, "LOV_Value"),
                .Display_Order = GetInt32(reader, "Display_Order"),
                .Is_Active = GetBoolean(reader, "Is_Active")
            }
        End Function

    End Class

End Namespace
