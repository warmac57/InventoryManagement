Imports System.Data
Imports Microsoft.Data.SqlClient

Namespace Common

    ''' <summary>
    ''' Database helper class for ADO.NET operations
    ''' </summary>
    Public Class DatabaseHelper
        Implements IDisposable

        Private _connection As SqlConnection
        Private _command As SqlCommand
        Private _disposed As Boolean = False

        ''' <summary>
        ''' Initialize database helper with default connection string
        ''' </summary>
        Public Sub New()
            _connection = New SqlConnection(AppSettings.Instance.ConnectionString)
            _command = New SqlCommand()
            _command.Connection = _connection
        End Sub

        ''' <summary>
        ''' Initialize database helper with custom connection string
        ''' </summary>
        Public Sub New(connectionString As String)
            _connection = New SqlConnection(connectionString)
            _command = New SqlCommand()
            _command.Connection = _connection
        End Sub

        ''' <summary>
        ''' Add a parameter to the command
        ''' </summary>
        Public Sub AddParameter(name As String, value As Object)
            If value Is Nothing Then
                _command.Parameters.AddWithValue(name, DBNull.Value)
            Else
                _command.Parameters.AddWithValue(name, value)
            End If
        End Sub

        ''' <summary>
        ''' Clear all parameters
        ''' </summary>
        Public Sub ClearParameters()
            _command.Parameters.Clear()
        End Sub

        ''' <summary>
        ''' Open the database connection
        ''' </summary>
        Private Sub OpenConnection()
            If _connection.State <> ConnectionState.Open Then
                _connection.Open()
            End If
        End Sub

        ''' <summary>
        ''' Execute a non-query command (INSERT, UPDATE, DELETE)
        ''' </summary>
        Public Function ExecuteNonQuery(sql As String) As Integer
            Try
                OpenConnection()
                _command.CommandText = sql
                _command.CommandType = CommandType.Text
                Return _command.ExecuteNonQuery()
            Finally
                ClearParameters()
            End Try
        End Function

        ''' <summary>
        ''' Execute a scalar query (returns single value)
        ''' </summary>
        Public Function ExecuteScalar(sql As String) As Object
            Try
                OpenConnection()
                _command.CommandText = sql
                _command.CommandType = CommandType.Text
                Return _command.ExecuteScalar()
            Finally
                ClearParameters()
            End Try
        End Function

        ''' <summary>
        ''' Execute a reader query (returns multiple rows)
        ''' </summary>
        Public Function ExecuteReader(sql As String) As SqlDataReader
            OpenConnection()
            _command.CommandText = sql
            _command.CommandType = CommandType.Text
            Return _command.ExecuteReader()
        End Function

        ''' <summary>
        ''' Execute a stored procedure
        ''' </summary>
        Public Function ExecuteStoredProcedure(procedureName As String) As Integer
            Try
                OpenConnection()
                _command.CommandText = procedureName
                _command.CommandType = CommandType.StoredProcedure
                Return _command.ExecuteNonQuery()
            Finally
                ClearParameters()
            End Try
        End Function

        ''' <summary>
        ''' Get a DataTable from a query
        ''' </summary>
        Public Function GetDataTable(sql As String) As DataTable
            Try
                OpenConnection()
                _command.CommandText = sql
                _command.CommandType = CommandType.Text

                Dim adapter As New SqlDataAdapter(_command)
                Dim table As New DataTable()
                adapter.Fill(table)
                Return table
            Finally
                ClearParameters()
            End Try
        End Function

        ''' <summary>
        ''' Begin a transaction
        ''' </summary>
        Public Function BeginTransaction() As SqlTransaction
            OpenConnection()
            Dim transaction = _connection.BeginTransaction()
            _command.Transaction = transaction
            Return transaction
        End Function

        ''' <summary>
        ''' Test database connection
        ''' </summary>
        Public Function TestConnection() As Boolean
            Try
                OpenConnection()
                Return True
            Catch
                Return False
            Finally
                If _connection.State = ConnectionState.Open Then
                    _connection.Close()
                End If
            End Try
        End Function

        ''' <summary>
        ''' Get the last inserted identity value
        ''' </summary>
        Public Function GetLastInsertId() As Integer
            Dim result = ExecuteScalar("SELECT SCOPE_IDENTITY()")
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                Return Convert.ToInt32(result)
            End If
            Return 0
        End Function

        ''' <summary>
        ''' Dispose resources
        ''' </summary>
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not _disposed Then
                If disposing Then
                    If _command IsNot Nothing Then
                        _command.Dispose()
                    End If
                    If _connection IsNot Nothing Then
                        If _connection.State = ConnectionState.Open Then
                            _connection.Close()
                        End If
                        _connection.Dispose()
                    End If
                End If
                _disposed = True
            End If
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

    End Class

End Namespace
