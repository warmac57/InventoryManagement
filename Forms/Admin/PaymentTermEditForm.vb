Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Entities

Namespace Forms.Admin

    Partial Public Class PaymentTermEditForm

        Private _termId As Integer
        Private _term As PaymentTerm
        Private ReadOnly _paymentTermDAO As New PaymentTermDAO()

        Public Sub New(Optional termId As Integer = 0)
            _termId = termId
            InitializeComponent()
            SetupForm()
            LoadData()
        End Sub

        Private Sub SetupForm()
            Me.Text = If(_termId = 0, "New Payment Term", "Edit Payment Term")
            chkActive.Checked = True
        End Sub

        Private Sub LoadData()
            If _termId > 0 Then
                _term = _paymentTermDAO.GetById(_termId)
                If _term IsNot Nothing Then
                    txtCode.Text = _term.Term_Code
                    txtDescription.Text = _term.Term_Description
                    txtDaysDue.Value = _term.Days_Due
                    txtDiscountPercent.Value = _term.Discount_Percent
                    txtDiscountDays.Value = _term.Discount_Days
                    chkActive.Checked = _term.Is_Active
                End If
            Else
                _term = New PaymentTerm()
            End If
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If String.IsNullOrEmpty(txtCode.Text.Trim()) Then
                XtraMessageBox.Show("Code is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                _term.Term_Code = txtCode.Text.Trim()
                _term.Term_Description = txtDescription.Text
                _term.Days_Due = CInt(txtDaysDue.Value)
                _term.Discount_Percent = txtDiscountPercent.Value
                _term.Discount_Days = CInt(txtDiscountDays.Value)
                _term.Is_Active = chkActive.Checked

                If _termId = 0 Then
                    _paymentTermDAO.Insert(_term)
                Else
                    _paymentTermDAO.Update(_term)
                End If

                Me.DialogResult = DialogResult.OK
                Me.Close()
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub

    End Class

End Namespace
