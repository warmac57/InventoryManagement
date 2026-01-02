Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Entities

Namespace Forms.Admin

    Partial Public Class PaymentTermListForm

        Private ReadOnly _paymentTermDAO As New PaymentTermDAO()

        Public Sub New()
            InitializeComponent()
            SetupGrid()
        End Sub

        Private Sub SetupGrid()
            gridView.Columns.Clear()

            Dim colCode As New GridColumn()
            colCode.FieldName = "Term_Code"
            colCode.Caption = "Code"
            colCode.Width = 80
            colCode.Visible = True
            gridView.Columns.Add(colCode)

            Dim colDesc As New GridColumn()
            colDesc.FieldName = "Term_Description"
            colDesc.Caption = "Description"
            colDesc.Width = 200
            colDesc.Visible = True
            gridView.Columns.Add(colDesc)

            Dim colDays As New GridColumn()
            colDays.FieldName = "Days_Due"
            colDays.Caption = "Days Due"
            colDays.Width = 80
            colDays.Visible = True
            gridView.Columns.Add(colDays)

            Dim colDiscount As New GridColumn()
            colDiscount.FieldName = "Discount_Percent"
            colDiscount.Caption = "Discount %"
            colDiscount.Width = 80
            colDiscount.Visible = True
            gridView.Columns.Add(colDiscount)

            Dim colActive As New GridColumn()
            colActive.FieldName = "Is_Active"
            colActive.Caption = "Active"
            colActive.Width = 60
            colActive.Visible = True
            gridView.Columns.Add(colActive)

            gridView.BestFitColumns()
        End Sub

        Private Sub LoadData()
            Try
                gridControl.DataSource = _paymentTermDAO.GetAll()
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub AddNew()
            Dim frm As New PaymentTermEditForm()
            If frm.ShowDialog() = DialogResult.OK Then LoadData()
        End Sub

        Private Sub EditSelected()
            If gridView.FocusedRowHandle < 0 Then Return
            Dim term = TryCast(gridView.GetFocusedRow(), PaymentTerm)
            If term IsNot Nothing Then
                Dim frm As New PaymentTermEditForm(term.Payment_Term_ID)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End If
        End Sub

        Private Sub DeleteSelected()
            If gridView.FocusedRowHandle < 0 Then Return
            Dim term = TryCast(gridView.GetFocusedRow(), PaymentTerm)
            If term IsNot Nothing Then
                If XtraMessageBox.Show($"Delete '{term.Term_Code}'?", "Confirm",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Try
                        _paymentTermDAO.Delete(term.Payment_Term_ID)
                        LoadData()
                    Catch ex As Exception
                        XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End Sub

        Private Sub PaymentTermListForm_Load(sender As Object, e As EventArgs) Handles Me.Load
            LoadData()
        End Sub

        Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            AddNew()
        End Sub

        Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
            EditSelected()
        End Sub

        Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
            DeleteSelected()
        End Sub

        Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
            LoadData()
        End Sub

        Private Sub gridView_DoubleClick(sender As Object, e As EventArgs) Handles gridView.DoubleClick
            EditSelected()
        End Sub

    End Class

End Namespace
