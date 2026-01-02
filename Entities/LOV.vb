Namespace Entities

    ''' <summary>
    ''' List of Values entity for dropdown data
    ''' </summary>
    Public Class LOV
        Public Property LOV_ID As Integer
        Public Property LOV_Type As String
        Public Property LOV_Code As String
        Public Property LOV_Value As String
        Public Property Display_Order As Integer
        Public Property Is_Active As Boolean

        Public Sub New()
            Is_Active = True
            Display_Order = 0
        End Sub

        ''' <summary>
        ''' Display text for combo boxes
        ''' </summary>
        Public Overrides Function ToString() As String
            Return LOV_Value
        End Function

    End Class

End Namespace
