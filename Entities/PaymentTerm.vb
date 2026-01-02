Namespace Entities

    ''' <summary>
    ''' Payment term entity
    ''' </summary>
    Public Class PaymentTerm
        Public Property Payment_Term_ID As Integer
        Public Property Term_Code As String
        Public Property Term_Description As String
        Public Property Days_Due As Integer
        Public Property Discount_Percent As Decimal
        Public Property Discount_Days As Integer
        Public Property Is_Active As Boolean

        Public Sub New()
            Is_Active = True
            Days_Due = 0
            Discount_Percent = 0D
            Discount_Days = 0
        End Sub

        ''' <summary>
        ''' Display text for combo boxes
        ''' </summary>
        Public Overrides Function ToString() As String
            Return $"{Term_Code} - {Term_Description}"
        End Function

        ''' <summary>
        ''' Calculate due date from order date
        ''' </summary>
        Public Function CalculateDueDate(orderDate As DateTime) As DateTime
            Return orderDate.AddDays(Days_Due)
        End Function

        ''' <summary>
        ''' Calculate discount amount
        ''' </summary>
        Public Function CalculateDiscount(amount As Decimal) As Decimal
            Return amount * (Discount_Percent / 100)
        End Function

    End Class

End Namespace
