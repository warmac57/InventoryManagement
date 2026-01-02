Namespace Entities

    ''' <summary>
    ''' Category entity for item classification
    ''' </summary>
    Public Class Category
        Public Property Category_ID As Integer
        Public Property Category_Name As String
        Public Property Description As String
        Public Property Parent_Category_ID As Integer?
        Public Property Is_Active As Boolean

        ' Navigation property
        Public Property ParentCategory As Category
        Public Property SubCategories As List(Of Category)

        Public Sub New()
            Is_Active = True
            SubCategories = New List(Of Category)()
        End Sub

        ''' <summary>
        ''' Display text for combo boxes
        ''' </summary>
        Public Overrides Function ToString() As String
            Return Category_Name
        End Function

        ''' <summary>
        ''' Full path including parent categories
        ''' </summary>
        Public ReadOnly Property FullPath As String
            Get
                If ParentCategory IsNot Nothing Then
                    Return $"{ParentCategory.FullPath} > {Category_Name}"
                End If
                Return Category_Name
            End Get
        End Property

    End Class

End Namespace
