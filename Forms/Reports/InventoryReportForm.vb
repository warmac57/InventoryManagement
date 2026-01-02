Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports InventoryManagement.BusinessLogic

Namespace Forms.Reports

    Partial Public Class InventoryReportForm

        Private ReadOnly _inventoryManager As New InventoryManager()

        Public Sub New()
            InitializeComponent()
            SetupGrid()
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
            colStock.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            colStock.SummaryItem.DisplayFormat = "Total: {0:N2}"
            gridView.Columns.Add(colStock)

            Dim colCost As New GridColumn()
            colCost.FieldName = "Current_Item_Cost"
            colCost.Caption = "Unit Cost"
            colCost.Width = 90
            colCost.Visible = True
            colCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colCost.DisplayFormat.FormatString = "C2"
            gridView.Columns.Add(colCost)

            Dim colValue As New GridColumn()
            colValue.FieldName = "InventoryValue"
            colValue.Caption = "Total Value"
            colValue.Width = 110
            colValue.Visible = True
            colValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colValue.DisplayFormat.FormatString = "C2"
            colValue.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            colValue.SummaryItem.DisplayFormat = "Total: {0:C2}"
            gridView.Columns.Add(colValue)

            Dim colReorder As New GridColumn()
            colReorder.FieldName = "Reorder_Level"
            colReorder.Caption = "Reorder Level"
            colReorder.Width = 90
            colReorder.Visible = True
            gridView.Columns.Add(colReorder)

            Dim colNeedsReorder As New GridColumn()
            colNeedsReorder.FieldName = "NeedsReorder"
            colNeedsReorder.Caption = "Needs Reorder"
            colNeedsReorder.Width = 90
            colNeedsReorder.Visible = True
            gridView.Columns.Add(colNeedsReorder)

            gridView.BestFitColumns()
        End Sub

        Private Sub LoadData()
            Try
                Dim items = _inventoryManager.GetActiveItems()
                gridItems.DataSource = items

                Dim totalValue = items.Sum(Function(i) i.InventoryValue)
                lblTotalValue.Text = $"Total Inventory Value: {totalValue:C2}"
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
            LoadData()
        End Sub

        Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Try
                Using saveDialog As New SaveFileDialog()
                    saveDialog.Filter = "Excel Files|*.xlsx"
                    saveDialog.FileName = $"InventoryReport_{DateTime.Now:yyyyMMdd}.xlsx"
                    If saveDialog.ShowDialog() = DialogResult.OK Then
                        gridView.ExportToXlsx(saveDialog.FileName)
                        XtraMessageBox.Show("Report exported successfully.", "Success",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception
                XtraMessageBox.Show("Error exporting: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class

End Namespace
