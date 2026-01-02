Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports InventoryManagement.BusinessLogic
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Entities

Namespace Forms.Catalog

    Partial Public Class ItemEditForm

        Private _itemId As Integer
        Private _item As Item
        Private ReadOnly _inventoryManager As New InventoryManager()
        Private ReadOnly _categoryDAO As New CategoryDAO()
        Private ReadOnly _uomDAO As New UnitOfMeasureDAO()

        Public Sub New(Optional itemId As Integer = 0)
            _itemId = itemId
            InitializeComponent()
            SetupForm()
            LoadLookups()
            LoadData()
        End Sub

        Private Sub SetupForm()
            Me.Text = If(_itemId = 0, "New Item", "Edit Item")
            chkTrackInventory.Checked = True
            chkActive.Checked = True
            If _itemId > 0 Then
                txtStock.Properties.ReadOnly = True
            End If
        End Sub

        Private Sub LoadLookups()
            ' Configure category lookup columns
            cboCategory.Properties.Columns.Clear()
            cboCategory.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Category_Name", "Category", 180))
            cboCategory.Properties.PopupWidth = 200

            ' Configure unit of measure lookup columns
            cboUoM.Properties.Columns.Clear()
            cboUoM.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("UoM_Code", "Code", 60))
            cboUoM.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("UoM_Name", "Name", 120))
            cboUoM.Properties.PopupWidth = 200

            cboCategory.Properties.DataSource = _categoryDAO.GetActiveCategories()
            cboUoM.Properties.DataSource = _uomDAO.GetActiveUnits()
        End Sub

        Private Sub LoadData()
            If _itemId > 0 Then
                _item = _inventoryManager.GetItemById(_itemId)
                If _item IsNot Nothing Then
                    txtCode.Text = _item.Item_Code
                    txtName.Text = _item.Item_Name
                    txtDescription.Text = _item.Description
                    cboCategory.EditValue = _item.Category_ID
                    cboUoM.EditValue = _item.UoM_ID
                    txtCost.Value = _item.Current_Item_Cost
                    txtStock.Value = _item.Stock_Quantity
                    txtReorderLevel.Value = _item.Reorder_Level
                    txtMinStock.Value = _item.Min_Stock_Level
                    txtMaxStock.Value = _item.Max_Stock_Level
                    chkTrackInventory.Checked = _item.Track_Inventory
                    chkActive.Checked = _item.Is_Active
                End If
            Else
                _item = New Item()
            End If
        End Sub

        Private Function ValidateForm() As Boolean
            If String.IsNullOrEmpty(txtCode.Text.Trim()) Then
                XtraMessageBox.Show("Item code is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCode.Focus()
                Return False
            End If

            If String.IsNullOrEmpty(txtName.Text.Trim()) Then
                XtraMessageBox.Show("Item name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtName.Focus()
                Return False
            End If

            Return True
        End Function

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If Not ValidateForm() Then Return

            Try
                _item.Item_Code = txtCode.Text.Trim()
                _item.Item_Name = txtName.Text.Trim()
                _item.Description = txtDescription.Text
                _item.Category_ID = If(cboCategory.EditValue IsNot Nothing, CInt(cboCategory.EditValue), Nothing)
                _item.UoM_ID = If(cboUoM.EditValue IsNot Nothing, CInt(cboUoM.EditValue), Nothing)
                _item.Current_Item_Cost = txtCost.Value
                If _itemId = 0 Then _item.Stock_Quantity = txtStock.Value
                _item.Reorder_Level = txtReorderLevel.Value
                _item.Min_Stock_Level = txtMinStock.Value
                _item.Max_Stock_Level = txtMaxStock.Value
                _item.Track_Inventory = chkTrackInventory.Checked
                _item.Is_Active = chkActive.Checked

                _inventoryManager.SaveItem(_item)

                Me.DialogResult = DialogResult.OK
                Me.Close()
            Catch ex As Exception
                XtraMessageBox.Show("Error saving item: " & ex.Message, "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub

    End Class

End Namespace
