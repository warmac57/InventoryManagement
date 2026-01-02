Namespace Entities

    ''' <summary>
    ''' User entity for authentication and authorization
    ''' </summary>
    Public Class User
        Public Property User_ID As Integer
        Public Property Username As String
        Public Property Password_Hash As String
        Public Property Role As String
        Public Property Is_Active As Boolean
        Public Property Created_Date As DateTime
        Public Property Last_Login As DateTime?

        Public Sub New()
            Is_Active = True
            Created_Date = DateTime.Now
            Role = "User"
        End Sub

        ''' <summary>
        ''' Display name for the user
        ''' </summary>
        Public ReadOnly Property DisplayName As String
            Get
                Return Username
            End Get
        End Property

        ''' <summary>
        ''' Check if user is an administrator
        ''' </summary>
        Public ReadOnly Property IsAdmin As Boolean
            Get
                Return Role = "Administrator"
            End Get
        End Property

    End Class

End Namespace
