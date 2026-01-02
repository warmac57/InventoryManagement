Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Entities

Namespace Forms.Catalog

    Partial Public Class CategoryEditForm

        Private _categoryId As Integer
        Private _category As Category
        Private ReadOnly _categoryDAO As New CategoryDAO()

        Public Sub New(Optional categoryId As Integer = 0)
            _categoryId = categoryId
            InitializeComponent()
            SetupForm()
            LoadLookups()
            LoadData()
        End Sub

        Private Sub SetupForm()
            Me.Text = If(_categoryId = 0, "New Category", "Edit Category")
            chkActive.Checked = True
        End Sub

        Private Sub LoadLookups()
            ' Configure parent category lookup columns
            cboParent.Properties.Columns.Clear()
            cboParent.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Category_Name", "Category", 180))
            cboParent.Properties.PopupWidth = 200

            Dim categories = _categoryDAO.GetActiveCategories()
            If _categoryId > 0 Then
                categories = categories.Where(Function(c) c.Category_ID <> _categoryId).ToList()
            End If
            cboParent.Properties.DataSource = categories
        End Sub

        Private Sub LoadData()
            If _categoryId > 0 Then
                _category = _categoryDAO.GetById(_categoryId)
                If _category IsNot Nothing Then
                    txtName.Text = _category.Category_Name
                    txtDescription.Text = _category.Description
                    cboParent.EditValue = _category.Parent_Category_ID
                    chkActive.Checked = _category.Is_Active
                End If
            Else
                _category = New Category()
            End If
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If String.IsNullOrEmpty(txtName.Text.Trim()) Then
                XtraMessageBox.Show("Category name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                _category.Category_Name = txtName.Text.Trim()
                _category.Description = txtDescription.Text
                _category.Parent_Category_ID = If(cboParent.EditValue IsNot Nothing, CInt(cboParent.EditValue), Nothing)
                _category.Is_Active = chkActive.Checked

                If _categoryId = 0 Then
                    _categoryDAO.Insert(_category)
                Else
                    _categoryDAO.Update(_category)
                End If

                Me.DialogResult = DialogResult.OK
                Me.Close()
            Catch ex As Exception
                XtraMessageBox.Show("Error saving category: " & ex.Message, "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub

    End Class

End Namespace
