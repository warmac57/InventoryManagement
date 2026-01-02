Imports InventoryManagement.Entities
Imports Microsoft.Data.SqlClient

Namespace DataAccess

    ''' <summary>
    ''' Data Access Object for PaymentTerm entity
    ''' </summary>
    Public Class PaymentTermDAO
        Inherits BaseDAO

        ''' <summary>
        ''' Get all payment terms
        ''' </summary>
        Public Function GetAll() As List(Of PaymentTerm)
            Dim terms As New List(Of PaymentTerm)()
            Using helper = CreateHelper()
                Dim sql = "SELECT * FROM PAYMENT_TERM ORDER BY Term_Code"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        terms.Add(MapPaymentTerm(reader))
                    End While
                End Using
            End Using
            Return terms
        End Function

        ''' <summary>
        ''' Get active payment terms only
        ''' </summary>
        Public Function GetActiveTerms() As List(Of PaymentTerm)
            Dim terms As New List(Of PaymentTerm)()
            Using helper = CreateHelper()
                Dim sql = "SELECT * FROM PAYMENT_TERM WHERE Is_Active = 1 ORDER BY Term_Code"
                Using reader = helper.ExecuteReader(sql)
                    While reader.Read()
                        terms.Add(MapPaymentTerm(reader))
                    End While
                End Using
            End Using
            Return terms
        End Function

        ''' <summary>
        ''' Get payment term by ID
        ''' </summary>
        Public Function GetById(termId As Integer) As PaymentTerm
            Using helper = CreateHelper()
                helper.AddParameter("@Id", termId)
                Dim sql = "SELECT * FROM PAYMENT_TERM WHERE Payment_Term_ID = @Id"
                Using reader = helper.ExecuteReader(sql)
                    If reader.Read() Then
                        Return MapPaymentTerm(reader)
                    End If
                End Using
            End Using
            Return Nothing
        End Function

        ''' <summary>
        ''' Insert a new payment term
        ''' </summary>
        Public Function Insert(term As PaymentTerm) As Integer
            Using helper = CreateHelper()
                helper.AddParameter("@Code", term.Term_Code)
                helper.AddParameter("@Description", term.Term_Description)
                helper.AddParameter("@DaysDue", term.Days_Due)
                helper.AddParameter("@DiscountPercent", term.Discount_Percent)
                helper.AddParameter("@DiscountDays", term.Discount_Days)
                helper.AddParameter("@IsActive", term.Is_Active)

                Dim sql = "INSERT INTO PAYMENT_TERM (Term_Code, Term_Description, Days_Due, " &
                         "Discount_Percent, Discount_Days, Is_Active) " &
                         "VALUES (@Code, @Description, @DaysDue, @DiscountPercent, @DiscountDays, @IsActive); " &
                         "SELECT SCOPE_IDENTITY();"

                Dim result = helper.ExecuteScalar(sql)
                If result IsNot Nothing Then
                    term.Payment_Term_ID = Convert.ToInt32(result)
                    Return term.Payment_Term_ID
                End If
            End Using
            Return 0
        End Function

        ''' <summary>
        ''' Update an existing payment term
        ''' </summary>
        Public Function Update(term As PaymentTerm) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", term.Payment_Term_ID)
                helper.AddParameter("@Code", term.Term_Code)
                helper.AddParameter("@Description", term.Term_Description)
                helper.AddParameter("@DaysDue", term.Days_Due)
                helper.AddParameter("@DiscountPercent", term.Discount_Percent)
                helper.AddParameter("@DiscountDays", term.Discount_Days)
                helper.AddParameter("@IsActive", term.Is_Active)

                Dim sql = "UPDATE PAYMENT_TERM SET Term_Code = @Code, Term_Description = @Description, " &
                         "Days_Due = @DaysDue, Discount_Percent = @DiscountPercent, Discount_Days = @DiscountDays, " &
                         "Is_Active = @IsActive WHERE Payment_Term_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        ''' <summary>
        ''' Delete a payment term (soft delete)
        ''' </summary>
        Public Function Delete(termId As Integer) As Boolean
            Using helper = CreateHelper()
                helper.AddParameter("@Id", termId)
                Dim sql = "UPDATE PAYMENT_TERM SET Is_Active = 0 WHERE Payment_Term_ID = @Id"
                Return helper.ExecuteNonQuery(sql) > 0
            End Using
        End Function

        Private Function MapPaymentTerm(reader As SqlDataReader) As PaymentTerm
            Return New PaymentTerm() With {
                .Payment_Term_ID = GetInt32(reader, "Payment_Term_ID"),
                .Term_Code = GetString(reader, "Term_Code"),
                .Term_Description = GetString(reader, "Term_Description"),
                .Days_Due = GetInt32(reader, "Days_Due"),
                .Discount_Percent = GetDecimal(reader, "Discount_Percent"),
                .Discount_Days = GetInt32(reader, "Discount_Days"),
                .Is_Active = GetBoolean(reader, "Is_Active")
            }
        End Function

    End Class

End Namespace
