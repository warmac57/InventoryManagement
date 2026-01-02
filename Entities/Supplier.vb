Namespace Entities

    ''' <summary>
    ''' Supplier/Vendor entity
    ''' </summary>
    Public Class Supplier
        Public Property Supplier_ID As Integer
        Public Property Supplier_Code As String
        Public Property Supplier_Name As String
        Public Property Contact_Person As String
        Public Property Email As String
        Public Property Phone As String
        Public Property Address As String
        Public Property City As String
        Public Property State As String
        Public Property Zip_Code As String
        Public Property Country As String
        Public Property Is_Active As Boolean
        Public Property Created_Date As DateTime

        Public Sub New()
            Is_Active = True
            Created_Date = DateTime.Now
            Country = "USA"
        End Sub

        ''' <summary>
        ''' Display text for combo boxes
        ''' </summary>
        Public Overrides Function ToString() As String
            Return $"{Supplier_Code} - {Supplier_Name}"
        End Function

        ''' <summary>
        ''' Full address as single string
        ''' </summary>
        Public ReadOnly Property FullAddress As String
            Get
                Dim parts As New List(Of String)()
                If Not String.IsNullOrEmpty(Address) Then parts.Add(Address)
                If Not String.IsNullOrEmpty(City) Then parts.Add(City)
                If Not String.IsNullOrEmpty(State) Then parts.Add(State)
                If Not String.IsNullOrEmpty(Zip_Code) Then parts.Add(Zip_Code)
                If Not String.IsNullOrEmpty(Country) Then parts.Add(Country)
                Return String.Join(", ", parts)
            End Get
        End Property

    End Class

End Namespace
