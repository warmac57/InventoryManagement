Imports InventoryManagement.Common
Imports Microsoft.Data.SqlClient

Namespace DataAccess

    ''' <summary>
    ''' Base Data Access Object class
    ''' </summary>
    Public MustInherit Class BaseDAO
        Protected ReadOnly Property ConnectionString As String
            Get
                Return AppSettings.Instance.ConnectionString
            End Get
        End Property

        ''' <summary>
        ''' Create a new database helper
        ''' </summary>
        Protected Function CreateHelper() As DatabaseHelper
            Return New DatabaseHelper()
        End Function

        ''' <summary>
        ''' Get a safe string from reader
        ''' </summary>
        Protected Function GetString(reader As SqlDataReader, columnName As String) As String
            Dim ordinal = reader.GetOrdinal(columnName)
            If reader.IsDBNull(ordinal) Then Return Nothing
            Return reader.GetString(ordinal)
        End Function

        ''' <summary>
        ''' Get a safe integer from reader
        ''' </summary>
        Protected Function GetInt32(reader As SqlDataReader, columnName As String) As Integer
            Dim ordinal = reader.GetOrdinal(columnName)
            If reader.IsDBNull(ordinal) Then Return 0
            Return reader.GetInt32(ordinal)
        End Function

        ''' <summary>
        ''' Get a nullable integer from reader
        ''' </summary>
        Protected Function GetNullableInt32(reader As SqlDataReader, columnName As String) As Integer?
            Dim ordinal = reader.GetOrdinal(columnName)
            If reader.IsDBNull(ordinal) Then Return Nothing
            Return reader.GetInt32(ordinal)
        End Function

        ''' <summary>
        ''' Get a safe decimal from reader
        ''' </summary>
        Protected Function GetDecimal(reader As SqlDataReader, columnName As String) As Decimal
            Dim ordinal = reader.GetOrdinal(columnName)
            If reader.IsDBNull(ordinal) Then Return 0D
            Return reader.GetDecimal(ordinal)
        End Function

        ''' <summary>
        ''' Get a safe datetime from reader
        ''' </summary>
        Protected Function GetDateTime(reader As SqlDataReader, columnName As String) As DateTime
            Dim ordinal = reader.GetOrdinal(columnName)
            If reader.IsDBNull(ordinal) Then Return DateTime.MinValue
            Return reader.GetDateTime(ordinal)
        End Function

        ''' <summary>
        ''' Get a nullable datetime from reader
        ''' </summary>
        Protected Function GetNullableDateTime(reader As SqlDataReader, columnName As String) As DateTime?
            Dim ordinal = reader.GetOrdinal(columnName)
            If reader.IsDBNull(ordinal) Then Return Nothing
            Return reader.GetDateTime(ordinal)
        End Function

        ''' <summary>
        ''' Get a safe boolean from reader
        ''' </summary>
        Protected Function GetBoolean(reader As SqlDataReader, columnName As String) As Boolean
            Dim ordinal = reader.GetOrdinal(columnName)
            If reader.IsDBNull(ordinal) Then Return False
            Return reader.GetBoolean(ordinal)
        End Function

    End Class

End Namespace
