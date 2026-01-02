Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Entities

Namespace Forms.Catalog

    Partial Public Class CategoryListForm

        Private ReadOnly _categoryDAO As New CategoryDAO()
        Private _categories As List(Of Category)

        Public Sub New()
            InitializeComponent()
            SetupGrid()
        End Sub

        Private Sub SetupGrid()
            gridView.Columns.Clear()

            Dim colName As New GridColumn()
            colName.FieldName = "Category_Name"
            colName.Caption = "Category Name"
            colName.Width = 200
            colName.Visible = True
            gridView.Columns.Add(colName)

            Dim colDesc As New GridColumn()
            colDesc.FieldName = "Description"
            colDesc.Caption = "Description"
            colDesc.Width = 300
            colDesc.Visible = True
            gridView.Columns.Add(colDesc)

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
                _categories = _categoryDAO.GetAll()
                gridControl.DataSource = _categories
            Catch ex As Exception
                XtraMessageBox.Show("Error loading categories: " & ex.Message, "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub AddNew()
            Dim frm As New CategoryEditForm()
            If frm.ShowDialog() = DialogResult.OK Then
                LoadData()
            End If
        End Sub

        Private Sub EditSelected()
            If gridView.FocusedRowHandle < 0 Then Return
            Dim category = TryCast(gridView.GetFocusedRow(), Category)
            If category IsNot Nothing Then
                Dim frm As New CategoryEditForm(category.Category_ID)
                If frm.ShowDialog() = DialogResult.OK Then
                    LoadData()
                End If
            End If
        End Sub

        Private Sub DeleteSelected()
            If gridView.FocusedRowHandle < 0 Then Return
            Dim category = TryCast(gridView.GetFocusedRow(), Category)
            If category IsNot Nothing Then
                If XtraMessageBox.Show($"Are you sure you want to delete '{category.Category_Name}'?",
                                      "Confirm Delete", MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question) = DialogResult.Yes Then
                    Try
                        _categoryDAO.Delete(category.Category_ID)
                        LoadData()
                    Catch ex As Exception
                        XtraMessageBox.Show("Error deleting category: " & ex.Message, "Error",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End Sub

        Private Sub CategoryListForm_Load(sender As Object, e As EventArgs) Handles Me.Load
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
