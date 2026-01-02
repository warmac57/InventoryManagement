Imports InventoryManagement.Entities
Imports Microsoft.Data.SqlClient

Namespace DataAccess

    ''' <summary>
    ''' Data Access Object for Supplier entity
    ''' </summary>
    Public Class SupplierDAO
        Inherits BaseDAO

        ''' <summary>
        ''' Get all suppliers
        ''' </summary>
        Public Function GetAll() As List(Of Supplier)
            Dim suppliers As New List(Of Supplier)()
            Using helper = CreateHelper()
                Dim sql = "SELECT * FROM SUPPLIER ORDER BY Supplier_Name"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        suppliers.Add(MapSupplier(reader))
                    End While
                End Using
            End Using
            Return suppliers
        End Function

        ''' <summary>
        ''' Get active suppliers only
        ''' </summary>
        Public Function GetActiveSuppliers() As List(Of Supplier)
            Dim suppliers As New List(Of Supplier)()
            Using helper = CreateHelper()
                Dim sql = "SELECT * FROM SUPPLIER WHERE Is_Active = 1 ORDER BY Supplier_Name"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        suppliers.Add(MapSupplier(reader))
                    End While
                End Using
            End Using
            Return suppliers
        End Function

        ''' <summary>
        ''' Get supplier by ID
        ''' </summary>
        Public Function GetById(supplierId As Integer) As Supplier
            Using helper = CreateHelper()
                helper.AddParameter("@Id", supplierId)
                Dim sql = "SELECT * FROM SUPPLIER WHERE Supplier_ID = @Id"
                Using reader = helper.ExecuteReader(sql)
                    If reader.Read() Then
                        Return MapSupplier(reader)
                    End If
                End Using
            End Using
            Return Nothing
        End Function

        ''' <summary>
        ''' Insert a new supplier
        ''' </summary>
        Public Function Insert(supplier As Supplier) As Integer
            Using helper = CreateHelper()
                helper.AddParameter("@Code", supplier.Supplier_Code)
                helper.AddParameter("@Name", supplier.Supplier_Name)
                helper.AddParameter("@Contact", supplier.Contact_Person)
                helper.AddParameter("@Email", supplier.Email)
                helper.AddParameter("@Phone", supplier.Phone)
                helper.AddParameter("@Address", supplier.Address)
                helper.AddParameter("@City", supplier.City)
                helper.AddParameter("@State", supplier.State)
                helper.AddParameter("@Zip", supplier.Zip_Code)
                helper.AddParameter("@Country", supplier.Country)
                helper.AddParameter("@IsActive", supplier.Is_Active)

                Dim sql = "INSERT INTO SUPPLIER (Supplier_Code, Supplier_Name, Contact_Person, Email, Phone, " &
                         "Address, City, State, Zip_Code, Country, Is_Active, Created_Date) " &
                         "VALUES (@Code, @Name, @Contact, @Email, @Phone, @Address, @City, @State, @Zip, " &
                         "@Country, @IsActive, GETDATE()); SELECT SCOPE_IDENTITY();"

                Dim result = helper.ExecuteScalar(sql)
                If result IsNot Nothing Then
                    supplier.Supplier_ID = Convert.ToInt32(result)
                    Return supplier.Supplier_ID
                End If
            End Using
            Return 0
        End Function

        ''' <summary>
        ''' Update an existing supplier
        ''' </summary>
        Public Function Update(supplier As Supplier) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", supplier.Supplier_ID)
                helper.AddParameter("@Code", supplier.Supplier_Code)
                helper.AddParameter("@Name", supplier.Supplier_Name)
                helper.AddParameter("@Contact", supplier.Contact_Person)
                helper.AddParameter("@Email", supplier.Email)
                helper.AddParameter("@Phone", supplier.Phone)
                helper.AddParameter("@Address", supplier.Address)
                helper.AddParameter("@City", supplier.City)
                helper.AddParameter("@State", supplier.State)
                helper.AddParameter("@Zip", supplier.Zip_Code)
                helper.AddParameter("@Country", supplier.Country)
                helper.AddParameter("@IsActive", supplier.Is_Active)

                Dim sql = "UPDATE SUPPLIER SET Supplier_Code = @Code, Supplier_Name = @Name, " &
                         "Contact_Person = @Contact, Email = @Email, Phone = @Phone, Address = @Address, " &
                         "City = @City, State = @State, Zip_Code = @Zip, Country = @Country, " &
                         "Is_Active = @IsActive WHERE Supplier_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Delete a supplier (soft delete)
        ''' </summary>
        Public Function Delete(supplierId As Integer) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", supplierId)
                Dim sql = "UPDATE SUPPLIER SET Is_Active = 0 WHERE Supplier_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        Private Function MapSupplier(reader As SqlDataReader) As Supplier
            Return New Supplier() With {
                .Supplier_ID = GetInt32(reader, "Supplier_ID"),
                .Supplier_Code = GetString(reader, "Supplier_Code"),
                .Supplier_Name = GetString(reader, "Supplier_Name"),
                .Contact_Person = GetString(reader, "Contact_Person"),
                .Email = GetString(reader, "Email"),
                .Phone = GetString(reader, "Phone"),
                .Address = GetString(reader, "Address"),
                .City = GetString(reader, "City"),
                .State = GetString(reader, "State"),
                .Zip_Code = GetString(reader, "Zip_Code"),
                .Country = GetString(reader, "Country"),
                .Is_Active = GetBoolean(reader, "Is_Active"),
                .Created_Date = GetDateTime(reader, "Created_Date")
            }
        End Function

    End Class

End Namespace
