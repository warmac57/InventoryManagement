Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports InventoryManagement.BusinessLogic

Namespace Forms.Reports

    Partial Public Class ReorderReportForm

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
            colStock.Caption = "Current Stock"
            colStock.Width = 100
            colStock.Visible = True
            colStock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colStock.DisplayFormat.FormatString = "N2"
            gridView.Columns.Add(colStock)

            Dim colReorder As New GridColumn()
            colReorder.FieldName = "Reorder_Level"
            colReorder.Caption = "Reorder Level"
            colReorder.Width = 100
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

            gridView.BestFitColumns()
        End Sub

        Private Sub LoadData()
            Try
                Dim items = _inventoryManager.GetItemsNeedingReorder()
                gridItems.DataSource = items
                lblCount.Text = $"Items to Reorder: {items.Count}"
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
                    saveDialog.FileName = $"ReorderReport_{DateTime.Now:yyyyMMdd}.xlsx"
                    If saveDialog.ShowDialog() = DialogResult.OK Then
                        gridView.ExportToXlsx(saveDialog.FileName)
                        XtraMessageBox.Show("Report exported successfully.", "Success",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnCreatePO_Click(sender As Object, e As EventArgs) Handles btnCreatePO.Click
            XtraMessageBox.Show("Purchase Order functionality not yet implemented.", "Info",
                               MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

    End Class

End Namespace
