Imports InventoryManagement.Entities

Namespace Common

    ''' <summary>
    ''' Manages user session and authentication state
    ''' </summary>
    Public Class SessionManager
        Private Shared _instance As SessionManager
        Private Shared ReadOnly _lock As New Object()

        Private _currentUser As User
        Private _loginTime As DateTime

        ''' <summary>
        ''' Singleton instance
        ''' </summary>
        Public Shared ReadOnly Property Instance As SessionManager
            Get
                If _instance Is Nothing Then
                    SyncLock _lock
                        If _instance Is Nothing Then
                            _instance = New SessionManager()
                        End If
                    End SyncLock
                End If
                Return _instance
            End Get
        End Property

        ''' <summary>
        ''' Currently logged in user
        ''' </summary>
        Public Property CurrentUser As User
            Get
                Return _currentUser
            End Get
            Set(value As User)
                _currentUser = value
                If value IsNot Nothing Then
                    _loginTime = DateTime.Now
                End If
            End Set
        End Property

        ''' <summary>
        ''' Time of login
        ''' </summary>
        Public ReadOnly Property LoginTime As DateTime
            Get
                Return _loginTime
            End Get
        End Property

        ''' <summary>
        ''' Check if user is logged in
        ''' </summary>
        Public ReadOnly Property IsLoggedIn As Boolean
            Get
                Return _currentUser IsNot Nothing
            End Get
        End Property

        ''' <summary>
        ''' Check if current user is an administrator
        ''' </summary>
        Public ReadOnly Property IsAdmin As Boolean
            Get
                Return _currentUser IsNot Nothing AndAlso _currentUser.Role = "Administrator"
            End Get
        End Property

        ''' <summary>
        ''' Check if current user is a manager
        ''' </summary>
        Public ReadOnly Property IsManager As Boolean
            Get
                Return _currentUser IsNot Nothing AndAlso (_currentUser.Role = "Manager" OrElse _currentUser.Role = "Administrator")
            End Get
        End Property

        ''' <summary>
        ''' Check if current user has sales access
        ''' </summary>
        Public ReadOnly Property HasSalesAccess As Boolean
            Get
                Return _currentUser IsNot Nothing AndAlso (
                    _currentUser.Role = "Administrator" OrElse
                    _currentUser.Role = "Manager" OrElse
                    _currentUser.Role = "Sales")
            End Get
        End Property

        ''' <summary>
        ''' Check if current user has purchasing access
        ''' </summary>
        Public ReadOnly Property HasPurchasingAccess As Boolean
            Get
                Return _currentUser IsNot Nothing AndAlso (
                    _currentUser.Role = "Administrator" OrElse
                    _currentUser.Role = "Manager" OrElse
                    _currentUser.Role = "Purchasing")
            End Get
        End Property

        ''' <summary>
        ''' Check if current user has warehouse access
        ''' </summary>
        Public ReadOnly Property HasWarehouseAccess As Boolean
            Get
                Return _currentUser IsNot Nothing AndAlso (
                    _currentUser.Role = "Administrator" OrElse
                    _currentUser.Role = "Manager" OrElse
                    _currentUser.Role = "Warehouse")
            End Get
        End Property

        Private Sub New()
            ' Private constructor for singleton
        End Sub

        ''' <summary>
        ''' Log out the current user
        ''' </summary>
        Public Sub Logout()
            _currentUser = Nothing
            _loginTime = DateTime.MinValue
        End Sub

        ''' <summary>
        ''' Check if user has a specific role
        ''' </summary>
        Public Function HasRole(role As String) As Boolean
            If _currentUser Is Nothing Then Return False
            Return _currentUser.Role.Equals(role, StringComparison.OrdinalIgnoreCase) OrElse
                   _currentUser.Role.Equals("Administrator", StringComparison.OrdinalIgnoreCase)
        End Function

        ''' <summary>
        ''' Get session duration
        ''' </summary>
        Public ReadOnly Property SessionDuration As TimeSpan
            Get
                If _loginTime = DateTime.MinValue Then
                    Return TimeSpan.Zero
                End If
                Return DateTime.Now - _loginTime
            End Get
        End Property

    End Class

End Namespace
