Imports InventoryManagement.Entities
Imports Microsoft.Data.SqlClient

Namespace DataAccess

    ''' <summary>
    ''' Data Access Object for User entity
    ''' </summary>
    Public Class UserDAO
        Inherits BaseDAO

        ''' <summary>
        ''' Get all users
        ''' </summary>
        Public Function GetAll() As List(Of User)
            Dim users As New List(Of User)()
            Using helper = CreateHelper()
                Dim sql = "SELECT * FROM [USER] ORDER BY Username"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        users.Add(MapUser(reader))
                    End While
                End Using
            End Using
            Return users
        End Function

        ''' <summary>
        ''' Get active users only
        ''' </summary>
        Public Function GetActiveUsers() As List(Of User)
            Dim users As New List(Of User)()
            Using helper = CreateHelper()
                Dim sql = "SELECT * FROM [USER] WHERE Is_Active = 1 ORDER BY Username"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        users.Add(MapUser(reader))
                    End While
                End Using
            End Using
            Return users
        End Function

        ''' <summary>
        ''' Get user by ID
        ''' </summary>
        Public Function GetById(userId As Integer) As User
            Using helper = CreateHelper()
                helper.AddParameter("@Id", userId)
                Dim sql = "SELECT * FROM [USER] WHERE User_ID = @Id"
                Using reader = helper.ExecuteReader(sql)
                    If reader.Read() Then
                        Return MapUser(reader)
                    End If
                End Using
            End Using
            Return Nothing
        End Function

        ''' <summary>
        ''' Get user by username
        ''' </summary>
        Public Function GetByUsername(username As String) As User
            Using helper = CreateHelper()
                helper.AddParameter("@Username", username)
                Dim sql = "SELECT * FROM [USER] WHERE Username = @Username"
                Using reader = helper.ExecuteReader(sql)
                    If reader.Read() Then
                        Return MapUser(reader)
                    End If
                End Using
            End Using
            Return Nothing
        End Function

        ''' <summary>
        ''' Authenticate user with username and password hash
        ''' </summary>
        Public Function Authenticate(username As String, passwordHash As String) As User
            Using helper = CreateHelper()
                helper.AddParameter("@Username", username)
                helper.AddParameter("@Password", passwordHash)
                Dim sql = "SELECT * FROM [USER] WHERE Username = @Username AND Password_Hash = @Password AND Is_Active = 1"
                Using reader = helper.ExecuteReader(sql)
                    If reader.Read() Then
                        Dim user = MapUser(reader)
                        ' Update last login
                        UpdateLastLogin(user.User_ID)
                        Return user
                    End If
                End Using
            End Using
            Return Nothing
        End Function

        ''' <summary>
        ''' Insert a new user
        ''' </summary>
        Public Function Insert(user As User) As Integer
            Using helper = CreateHelper()
                helper.AddParameter("@Username", user.Username)
                helper.AddParameter("@Password", user.Password_Hash)
                helper.AddParameter("@Role", user.Role)
                helper.AddParameter("@IsActive", user.Is_Active)

                Dim sql = "INSERT INTO [USER] (Username, Password_Hash, Role, Is_Active, Created_Date) " &
                         "VALUES (@Username, @Password, @Role, @IsActive, GETDATE()); SELECT SCOPE_IDENTITY();"

                Dim result = helper.ExecuteScalar(sql)
                If result IsNot Nothing Then
                    user.User_ID = Convert.ToInt32(result)
                    Return user.User_ID
                End If
            End Using
            Return 0
        End Function

        ''' <summary>
        ''' Update an existing user
        ''' </summary>
        Public Function Update(user As User) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", user.User_ID)
                helper.AddParameter("@Username", user.Username)
                helper.AddParameter("@Role", user.Role)
                helper.AddParameter("@IsActive", user.Is_Active)

                Dim sql = "UPDATE [USER] SET Username = @Username, Role = @Role, Is_Active = @IsActive WHERE User_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Update user password
        ''' </summary>
        Public Function UpdatePassword(userId As Integer, passwordHash As String) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", userId)
                helper.AddParameter("@Password", passwordHash)

                Dim sql = "UPDATE [USER] SET Password_Hash = @Password WHERE User_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Update last login time
        ''' </summary>
        Public Sub UpdateLastLogin(userId As Integer)
            Using helper = CreateHelper()
                helper.AddParameter("@Id", userId)
                Dim sql = "UPDATE [USER] SET Last_Login = GETDATE() WHERE User_ID = @Id"
                helper.ExecuteNonQuery(sql)
            End Using
        End Sub

        ''' <summary>
        ''' Delete a user (soft delete)
        ''' </summary>
        Public Function Delete(userId As Integer) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", userId)
                Dim sql = "UPDATE [USER] SET Is_Active = 0 WHERE User_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Check if username exists
        ''' </summary>
        Public Function UsernameExists(username As String, Optional excludeUserId As Integer = 0) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Username", username)
                helper.AddParameter("@ExcludeId", excludeUserId)
                Dim sql = "SELECT COUNT(*) FROM [USER] WHERE Username = @Username AND User_ID <> @ExcludeId"
                Dim result = helper.ExecuteScalar(sql)
                Return Convert.ToInt32(result) > 0
            End Using
        End Function

        Private Function MapUser(reader As SqlDataReader) As User
            Return New User() With {
                .User_ID = GetInt32(reader, "User_ID"),
                .Username = GetString(reader, "Username"),
                .Password_Hash = GetString(reader, "Password_Hash"),
                .Role = GetString(reader, "Role"),
                .Is_Active = GetBoolean(reader, "Is_Active"),
                .Created_Date = GetDateTime(reader, "Created_Date"),
                .Last_Login = GetNullableDateTime(reader, "Last_Login")
            }
        End Function

    End Class

End Namespace
