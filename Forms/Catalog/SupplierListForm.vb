Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Entities

Namespace Forms.Catalog

    Partial Public Class SupplierListForm

        Private ReadOnly _supplierDAO As New SupplierDAO()
        Private _suppliers As List(Of Supplier)

        Public Sub New()
            InitializeComponent()
            SetupGrid()
        End Sub

        Private Sub SetupGrid()
            gridView.Columns.Clear()

            Dim colCode As New GridColumn()
            colCode.FieldName = "Supplier_Code"
            colCode.Caption = "Code"
            colCode.Width = 80
            colCode.Visible = True
            gridView.Columns.Add(colCode)

            Dim colName As New GridColumn()
            colName.FieldName = "Supplier_Name"
            colName.Caption = "Supplier Name"
            colName.Width = 200
            colName.Visible = True
            gridView.Columns.Add(colName)

            Dim colContact As New GridColumn()
            colContact.FieldName = "Contact_Person"
            colContact.Caption = "Contact"
            colContact.Width = 120
            colContact.Visible = True
            gridView.Columns.Add(colContact)

            Dim colPhone As New GridColumn()
            colPhone.FieldName = "Phone"
            colPhone.Caption = "Phone"
            colPhone.Width = 100
            colPhone.Visible = True
            gridView.Columns.Add(colPhone)

            Dim colEmail As New GridColumn()
            colEmail.FieldName = "Email"
            colEmail.Caption = "Email"
            colEmail.Width = 150
            colEmail.Visible = True
            gridView.Columns.Add(colEmail)

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
                _suppliers = _supplierDAO.GetAll()
                gridControl.DataSource = _suppliers
            Catch ex As Exception
                XtraMessageBox.Show("Error loading suppliers: " & ex.Message, "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub AddNew()
            Dim frm As New SupplierEditForm()
            If frm.ShowDialog() = DialogResult.OK Then
                LoadData()
            End If
        End Sub

        Private Sub EditSelected()
            If gridView.FocusedRowHandle < 0 Then Return
            Dim supplier = TryCast(gridView.GetFocusedRow(), Supplier)
            If supplier IsNot Nothing Then
                Dim frm As New SupplierEditForm(supplier.Supplier_ID)
                If frm.ShowDialog() = DialogResult.OK Then
                    LoadData()
                End If
            End If
        End Sub

        Private Sub DeleteSelected()
            If gridView.FocusedRowHandle < 0 Then Return
            Dim supplier = TryCast(gridView.GetFocusedRow(), Supplier)
            If supplier IsNot Nothing Then
                If XtraMessageBox.Show($"Are you sure you want to delete '{supplier.Supplier_Name}'?",
                                      "Confirm Delete", MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question) = DialogResult.Yes Then
                    Try
                        _supplierDAO.Delete(supplier.Supplier_ID)
                        LoadData()
                    Catch ex As Exception
                        XtraMessageBox.Show("Error deleting supplier: " & ex.Message, "Error",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End Sub

        Private Sub SupplierListForm_Load(sender As Object, e As EventArgs) Handles Me.Load
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
