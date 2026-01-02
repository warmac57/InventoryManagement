Imports InventoryManagement.Entities
Imports Microsoft.Data.SqlClient

Namespace DataAccess

    ''' <summary>
    ''' Data Access Object for UnitOfMeasure entity
    ''' </summary>
    Public Class UnitOfMeasureDAO
        Inherits BaseDAO

        ''' <summary>
        ''' Get all units of measure
        ''' </summary>
        Public Function GetAll() As List(Of UnitOfMeasure)
            Dim units As New List(Of UnitOfMeasure)()
            Using helper = CreateHelper()
                Dim sql = "SELECT * FROM UNIT_OF_MEASURE ORDER BY UoM_Code"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        units.Add(MapUoM(reader))
                    End While
                End Using
            End Using
            Return units
        End Function

        ''' <summary>
        ''' Get active units only
        ''' </summary>
        Public Function GetActiveUnits() As List(Of UnitOfMeasure)
            Dim units As New List(Of UnitOfMeasure)()
            Using helper = CreateHelper()
                Dim sql = "SELECT * FROM UNIT_OF_MEASURE WHERE Is_Active = 1 ORDER BY UoM_Code"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        units.Add(MapUoM(reader))
                    End While
                End Using
            End Using
            Return units
        End Function

        ''' <summary>
        ''' Get unit by ID
        ''' </summary>
        Public Function GetById(uomId As Integer) As UnitOfMeasure
            Using helper = CreateHelper()
                helper.AddParameter("@Id", uomId)
                Dim sql = "SELECT * FROM UNIT_OF_MEASURE WHERE UoM_ID = @Id"
                Using reader = helper.ExecuteReader(sql)
                    If reader.Read() Then
                        Return MapUoM(reader)
                    End If
                End Using
            End Using
            Return Nothing
        End Function

        ''' <summary>
        ''' Insert a new unit of measure
        ''' </summary>
        Public Function Insert(uom As UnitOfMeasure) As Integer
            Using helper = CreateHelper()
                helper.AddParameter("@Code", uom.UoM_Code)
                helper.AddParameter("@Name", uom.UoM_Name)
                helper.AddParameter("@Factor", uom.Conversion_Factor)
                helper.AddParameter("@IsActive", uom.Is_Active)

                Dim sql = "INSERT INTO UNIT_OF_MEASURE (UoM_Code, UoM_Name, Conversion_Factor, Is_Active) " &
                         "VALUES (@Code, @Name, @Factor, @IsActive); SELECT SCOPE_IDENTITY();"

                Dim result = helper.ExecuteScalar(sql)
                If result IsNot Nothing Then
                    uom.UoM_ID = Convert.ToInt32(result)
                    Return uom.UoM_ID
                End If
            End Using
            Return 0
        End Function

        ''' <summary>
        ''' Update an existing unit of measure
        ''' </summary>
        Public Function Update(uom As UnitOfMeasure) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", uom.UoM_ID)
                helper.AddParameter("@Code", uom.UoM_Code)
                helper.AddParameter("@Name", uom.UoM_Name)
                helper.AddParameter("@Factor", uom.Conversion_Factor)
                helper.AddParameter("@IsActive", uom.Is_Active)

                Dim sql = "UPDATE UNIT_OF_MEASURE SET UoM_Code = @Code, UoM_Name = @Name, " &
                         "Conversion_Factor = @Factor, Is_Active = @IsActive WHERE UoM_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Delete a unit of measure (soft delete)
        ''' </summary>
        Public Function Delete(uomId As Integer) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", uomId)
                Dim sql = "UPDATE UNIT_OF_MEASURE SET Is_Active = 0 WHERE UoM_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        Private Function MapUoM(reader As SqlDataReader) As UnitOfMeasure
            Return New UnitOfMeasure() With {
                .UoM_ID = GetInt32(reader, "UoM_ID"),
                .UoM_Code = GetString(reader, "UoM_Code"),
                .UoM_Name = GetString(reader, "UoM_Name"),
                .Conversion_Factor = GetDecimal(reader, "Conversion_Factor"),
                .Is_Active = GetBoolean(reader, "Is_Active")
            }
        End Function

    End Class

End Namespace
