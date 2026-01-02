Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports InventoryManagement.BusinessLogic
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Entities

Namespace Forms.InventoryControl

    Partial Public Class InventoryCountListForm

        Private ReadOnly _inventoryManager As New InventoryManager()
        Private _counts As List(Of InventoryCount)

        Public Sub New()
            InitializeComponent()
            SetupGrid()
        End Sub

        Private Sub SetupGrid()
            gridView.Columns.Clear()

            Dim colDate As New GridColumn()
            colDate.FieldName = "Count_Date"
            colDate.Caption = "Count Date"
            colDate.Width = 120
            colDate.Visible = True
            colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            colDate.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
            gridView.Columns.Add(colDate)

            Dim colItem As New GridColumn()
            colItem.FieldName = "Item.Item_Name"
            colItem.Caption = "Item"
            colItem.Width = 200
            colItem.Visible = True
            gridView.Columns.Add(colItem)

            Dim colSystem As New GridColumn()
            colSystem.FieldName = "System_Quantity"
            colSystem.Caption = "System Qty"
            colSystem.Width = 90
            colSystem.Visible = True
            gridView.Columns.Add(colSystem)

            Dim colCounted As New GridColumn()
            colCounted.FieldName = "Quantity_Counted"
            colCounted.Caption = "Counted"
            colCounted.Width = 80
            colCounted.Visible = True
            gridView.Columns.Add(colCounted)

            Dim colChange As New GridColumn()
            colChange.FieldName = "Quantity_Change"
            colChange.Caption = "Variance"
            colChange.Width = 80
            colChange.Visible = True
            gridView.Columns.Add(colChange)

            Dim colValue As New GridColumn()
            colValue.FieldName = "Variance_Value"
            colValue.Caption = "Variance Value"
            colValue.Width = 100
            colValue.Visible = True
            colValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colValue.DisplayFormat.FormatString = "C2"
            gridView.Columns.Add(colValue)

            Dim colStatus As New GridColumn()
            colStatus.FieldName = "Count_Status"
            colStatus.Caption = "Status"
            colStatus.Width = 80
            colStatus.Visible = True
            gridView.Columns.Add(colStatus)

            gridView.BestFitColumns()
        End Sub

        Private Sub LoadData()
            Try
                _counts = _inventoryManager.GetAllCounts()
                gridControl.DataSource = _counts
            Catch ex As Exception
                XtraMessageBox.Show("Error loading counts: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub AddNew()
            Dim frm As New InventoryCountForm()
            If frm.ShowDialog() = DialogResult.OK Then
                LoadData()
            End If
        End Sub

        Private Sub EditSelected()
            If gridView.FocusedRowHandle < 0 Then Return
            Dim count = TryCast(gridView.GetFocusedRow(), InventoryCount)
            If count IsNot Nothing Then
                Dim frm As New InventoryCountForm(count.Count_ID)
                If frm.ShowDialog() = DialogResult.OK Then
                    LoadData()
                End If
            End If
        End Sub

        Private Sub DeleteSelected()
            If gridView.FocusedRowHandle < 0 Then Return
            Dim count = TryCast(gridView.GetFocusedRow(), InventoryCount)
            If count IsNot Nothing AndAlso count.Count_Status <> "Applied" Then
                If XtraMessageBox.Show("Delete this count?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Try
                        Dim dao As New InventoryCountDAO()
                        dao.Delete(count.Count_ID)
                        LoadData()
                    Catch ex As Exception
                        XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End Sub

        Private Sub InventoryCountListForm_Load(sender As Object, e As EventArgs) Handles Me.Load
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
