Namespace Entities

    ''' <summary>
    ''' Unit of Measure entity
    ''' </summary>
    Public Class UnitOfMeasure
        Public Property UoM_ID As Integer
        Public Property UoM_Code As String
        Public Property UoM_Name As String
        Public Property Conversion_Factor As Decimal
        Public Property Is_Active As Boolean

        Public Sub New()
            Is_Active = True
            Conversion_Factor = 1D
        End Sub

        ''' <summary>
        ''' Display text for combo boxes
        ''' </summary>
        Public Overrides Function ToString() As String
            Return $"{UoM_Code} - {UoM_Name}"
        End Function

        ''' <summary>
        ''' Convert quantity to base unit
        ''' </summary>
        Public Function ConvertToBase(quantity As Decimal) As Decimal
            Return quantity * Conversion_Factor
        End Function

        ''' <summary>
        ''' Convert quantity from base unit
        ''' </summary>
        Public Function ConvertFromBase(quantity As Decimal) As Decimal
            If Conversion_Factor = 0 Then Return quantity
            Return quantity / Conversion_Factor
        End Function

    End Class

End Namespace
