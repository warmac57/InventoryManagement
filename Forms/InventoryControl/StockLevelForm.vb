Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports InventoryManagement.BusinessLogic
Imports InventoryManagement.Entities

Namespace Forms.InventoryControl

    Partial Public Class StockLevelForm

        Private ReadOnly _inventoryManager As New InventoryManager()

        Public Sub New()
            InitializeComponent()
            SetupGrid()
            AddHandler chkShowLowStock.CheckedChanged, AddressOf ChkShowLowStock_Changed
            LoadData()
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
            colStock.Width = 90
            colStock.Visible = True
            colStock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colStock.DisplayFormat.FormatString = "N2"
            gridView.Columns.Add(colStock)

            Dim colReorder As New GridColumn()
            colReorder.FieldName = "Reorder_Level"
            colReorder.Caption = "Reorder Level"
            colReorder.Width = 90
            colReorder.Visible = True
            gridView.Columns.Add(colReorder)

            Dim colMin As New GridColumn()
            colMin.FieldName = "Min_Stock_Level"
            colMin.Caption = "Min Level"
            colMin.Width = 80
            colMin.Visible = True
            gridView.Columns.Add(colMin)

            Dim colMax As New GridColumn()
            colMax.FieldName = "Max_Stock_Level"
            colMax.Caption = "Max Level"
            colMax.Width = 80
            colMax.Visible = True
            gridView.Columns.Add(colMax)

            Dim colCost As New GridColumn()
            colCost.FieldName = "Current_Item_Cost"
            colCost.Caption = "Unit Cost"
            colCost.Width = 80
            colCost.Visible = True
            colCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colCost.DisplayFormat.FormatString = "C2"
            gridView.Columns.Add(colCost)

            Dim colValue As New GridColumn()
            colValue.FieldName = "InventoryValue"
            colValue.Caption = "Total Value"
            colValue.Width = 100
            colValue.Visible = True
            colValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colValue.DisplayFormat.FormatString = "C2"
            gridView.Columns.Add(colValue)

            gridView.BestFitColumns()
        End Sub

        Private Sub LoadData()
            Try
                Dim items As List(Of Item)
                If chkShowLowStock.Checked Then
                    items = _inventoryManager.GetItemsNeedingReorder()
                Else
                    items = _inventoryManager.GetActiveItems()
                End If
                gridItems.DataSource = items
            Catch ex As Exception
                XtraMessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
            LoadData()
        End Sub

        Private Sub ChkShowLowStock_Changed(sender As Object, e As EventArgs)
            LoadData()
        End Sub

        Private Sub btnReorderReport_Click(sender As Object, e As EventArgs) Handles btnReorderReport.Click
            Dim frm As New Reports.ReorderReportForm()
            frm.MdiParent = Me.MdiParent
            frm.Show()
        End Sub

    End Class

End Namespace
