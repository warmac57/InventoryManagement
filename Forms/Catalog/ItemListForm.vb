Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports InventoryManagement.BusinessLogic
Imports InventoryManagement.Entities

Namespace Forms.Catalog

    Partial Public Class ItemListForm

        Private ReadOnly _inventoryManager As New InventoryManager()
        Private _items As List(Of Item)

        Public Sub New()
            InitializeComponent()
            SetupGrid()
        End Sub

        Private Sub SetupGrid()
            gridView.Columns.Clear()

            Dim colCode As New GridColumn()
            colCode.FieldName = "Item_Code"
            colCode.Caption = "Item Code"
            colCode.Width = 100
            colCode.Visible = True
            gridView.Columns.Add(colCode)

            Dim colName As New GridColumn()
            colName.FieldName = "Item_Name"
            colName.Caption = "Item Name"
            colName.Width = 200
            colName.Visible = True
            gridView.Columns.Add(colName)

            Dim colStock As New GridColumn()
            colStock.FieldName = "Stock_Quantity"
            colStock.Caption = "Stock Qty"
            colStock.Width = 80
            colStock.Visible = True
            colStock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colStock.DisplayFormat.FormatString = "N2"
            gridView.Columns.Add(colStock)

            Dim colCost As New GridColumn()
            colCost.FieldName = "Current_Item_Cost"
            colCost.Caption = "Unit Cost"
            colCost.Width = 80
            colCost.Visible = True
            colCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colCost.DisplayFormat.FormatString = "C2"
            gridView.Columns.Add(colCost)

            Dim colReorder As New GridColumn()
            colReorder.FieldName = "Reorder_Level"
            colReorder.Caption = "Reorder Level"
            colReorder.Width = 80
            colReorder.Visible = True
            gridView.Columns.Add(colReorder)

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
                _items = _inventoryManager.GetAllItems()
                gridControl.DataSource = _items
            Catch ex As Exception
                XtraMessageBox.Show("Error loading items: " & ex.Message, "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub AddNew()
            Dim frm As New ItemEditForm()
            If frm.ShowDialog() = DialogResult.OK Then
                LoadData()
            End If
        End Sub

        Private Sub EditSelected()
            If gridView.FocusedRowHandle < 0 Then Return

            Dim item = TryCast(gridView.GetFocusedRow(), Item)
            If item IsNot Nothing Then
                Dim frm As New ItemEditForm(item.Item_ID)
                If frm.ShowDialog() = DialogResult.OK Then
                    LoadData()
                End If
            End If
        End Sub

        Private Sub DeleteSelected()
            If gridView.FocusedRowHandle < 0 Then Return

            Dim item = TryCast(gridView.GetFocusedRow(), Item)
            If item IsNot Nothing Then
                If XtraMessageBox.Show($"Are you sure you want to delete '{item.Item_Name}'?",
                                      "Confirm Delete", MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question) = DialogResult.Yes Then
                    Try
                        _inventoryManager.DeleteItem(item.Item_ID)
                        LoadData()
                    Catch ex As Exception
                        XtraMessageBox.Show("Error deleting item: " & ex.Message, "Error",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End Sub

        Private Sub ItemListForm_Load(sender As Object, e As EventArgs) Handles Me.Load
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
