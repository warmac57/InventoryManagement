Imports System.Security.Cryptography
Imports System.Text
Imports InventoryManagement.Common
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Entities

Namespace BusinessLogic

    ''' <summary>
    ''' Handles user authentication and authorization
    ''' </summary>
    Public Class AuthenticationManager
        Private ReadOnly _userDAO As New UserDAO()

        ''' <summary>
        ''' Authenticate a user with username and password
        ''' </summary>
        Public Function Login(username As String, password As String) As Boolean
            If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
                Return False
            End If

            Dim passwordHash = HashPassword(password)
            Dim user = _userDAO.Authenticate(username, passwordHash)

            If user IsNot Nothing Then
                SessionManager.Instance.CurrentUser = user
                AppSettings.Instance.LoadSettings()
                Return True
            End If

            Return False
        End Function

        ''' <summary>
        ''' Log out the current user
        ''' </summary>
        Public Sub Logout()
            SessionManager.Instance.Logout()
        End Sub

        ''' <summary>
        ''' Hash a password using SHA256
        ''' </summary>
        Public Function HashPassword(password As String) As String
            Using sha256 As SHA256 = SHA256.Create()
                Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
                Dim builder As New StringBuilder()
                For Each b As Byte In bytes
                    builder.Append(b.ToString("X2"))
                Next
                Return builder.ToString()
            End Using
        End Function

        ''' <summary>
        ''' Change user password
        ''' </summary>
        Public Function ChangePassword(userId As Integer, currentPassword As String, newPassword As String) As Boolean
            Dim user = _userDAO.GetById(userId)
            If user Is Nothing Then Return False

            Dim currentHash = HashPassword(currentPassword)
            If user.Password_Hash <> currentHash Then
                Return False
            End If

            Dim newHash = HashPassword(newPassword)
            Return _userDAO.UpdatePassword(userId, newHash)
        End Function

        ''' <summary>
        ''' Create a new user
        ''' </summary>
        Public Function CreateUser(username As String, password As String, role As String) As User
            If _userDAO.UsernameExists(username) Then
                Throw New Exception("Username already exists")
            End If

            Dim user As New User() With {
                .Username = username,
                .Password_Hash = HashPassword(password),
                .Role = role,
                .Is_Active = True
            }

            Dim id = _userDAO.Insert(user)
            If id > 0 Then
                user.User_ID = id
                Return user
            End If

            Return Nothing
        End Function

        ''' <summary>
        ''' Update user details
        ''' </summary>
        Public Function UpdateUser(user As User) As Boolean
            Return _userDAO.Update(user)
        End Function

        ''' <summary>
        ''' Reset user password (admin function)
        ''' </summary>
        Public Function ResetPassword(userId As Integer, newPassword As String) As Boolean
            Dim newHash = HashPassword(newPassword)
            Return _userDAO.UpdatePassword(userId, newHash)
        End Function

        ''' <summary>
        ''' Get all users
        ''' </summary>
        Public Function GetAllUsers() As List(Of User)
            Return _userDAO.GetAll()
        End Function

        ''' <summary>
        ''' Get active users
        ''' </summary>
        Public Function GetActiveUsers() As List(Of User)
            Return _userDAO.GetActiveUsers()
        End Function

        ''' <summary>
        ''' Deactivate a user
        ''' </summary>
        Public Function DeactivateUser(userId As Integer) As Boolean
            Return _userDAO.Delete(userId)
        End Function

    End Class

End Namespace
