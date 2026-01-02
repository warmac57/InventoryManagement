Namespace Entities

    ''' <summary>
    ''' Store settings entity for system configuration
    ''' </summary>
    Public Class StoreSettings
        Public Property Setting_ID As Integer
        Public Property Setting_Name As String
        Public Property Setting_Value As String
        Public Property Data_Type As String
        Public Property Description As String
        Public Property Modified_Date As DateTime
        Public Property Modified_By_User_ID As Integer?

        Public Sub New()
            Data_Type = "String"
            Modified_Date = DateTime.Now
        End Sub

        ''' <summary>
        ''' Get value as Boolean
        ''' </summary>
        Public Function GetBooleanValue() As Boolean
            Return Setting_Value IsNot Nothing AndAlso Boolean.TryParse(Setting_Value, Nothing) AndAlso Boolean.Parse(Setting_Value)
        End Function

        ''' <summary>
        ''' Get value as Decimal
        ''' </summary>
        Public Function GetDecimalValue() As Decimal
            If Setting_Value IsNot Nothing AndAlso Decimal.TryParse(Setting_Value, Nothing) Then
                Return Decimal.Parse(Setting_Value)
            End If
            Return 0D
        End Function

        ''' <summary>
        ''' Get value as Integer
        ''' </summary>
        Public Function GetIntegerValue() As Integer
            If Setting_Value IsNot Nothing AndAlso Integer.TryParse(Setting_Value, Nothing) Then
                Return Integer.Parse(Setting_Value)
            End If
            Return 0
        End Function

    End Class

End Namespace
