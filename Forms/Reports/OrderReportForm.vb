Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports InventoryManagement.BusinessLogic

Namespace Forms.Reports

    Partial Public Class OrderReportForm

        Private ReadOnly _orderManager As New OrderManager()

        Public Sub New()
            InitializeComponent()
            SetupForm()
            SetupGrid()
            LoadData()
        End Sub

        Private Sub SetupForm()
            dtpFromDate.EditValue = DateTime.Now.AddMonths(-1)
            dtpToDate.EditValue = DateTime.Now
            cboStatus.SelectedIndex = 0
        End Sub

        Private Sub SetupGrid()
            gridView.Columns.Clear()

            Dim colNumber As New GridColumn()
            colNumber.FieldName = "Order_Number"
            colNumber.Caption = "Order #"
            colNumber.Width = 120
            colNumber.Visible = True
            gridView.Columns.Add(colNumber)

            Dim colDate As New GridColumn()
            colDate.FieldName = "Order_Date"
            colDate.Caption = "Date"
            colDate.Width = 100
            colDate.Visible = True
            colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            colDate.DisplayFormat.FormatString = "yyyy-MM-dd"
            gridView.Columns.Add(colDate)

            Dim colCustomer As New GridColumn()
            colCustomer.FieldName = "Customer_Name"
            colCustomer.Caption = "Customer"
            colCustomer.Width = 180
            colCustomer.Visible = True
            gridView.Columns.Add(colCustomer)

            Dim colStatus As New GridColumn()
            colStatus.FieldName = "Order_Status"
            colStatus.Caption = "Status"
            colStatus.Width = 90
            colStatus.Visible = True
            gridView.Columns.Add(colStatus)

            Dim colSubtotal As New GridColumn()
            colSubtotal.FieldName = "Subtotal"
            colSubtotal.Caption = "Subtotal"
            colSubtotal.Width = 90
            colSubtotal.Visible = True
            colSubtotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colSubtotal.DisplayFormat.FormatString = "C2"
            colSubtotal.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            colSubtotal.SummaryItem.DisplayFormat = "{0:C2}"
            gridView.Columns.Add(colSubtotal)

            Dim colTax As New GridColumn()
            colTax.FieldName = "Tax_Amount"
            colTax.Caption = "Tax"
            colTax.Width = 80
            colTax.Visible = True
            colTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colTax.DisplayFormat.FormatString = "C2"
            gridView.Columns.Add(colTax)

            Dim colTotal As New GridColumn()
            colTotal.FieldName = "Total_Amount"
            colTotal.Caption = "Total"
            colTotal.Width = 100
            colTotal.Visible = True
            colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colTotal.DisplayFormat.FormatString = "C2"
            colTotal.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            colTotal.SummaryItem.DisplayFormat = "Total: {0:C2}"
            gridView.Columns.Add(colTotal)

            gridView.BestFitColumns()
        End Sub

        Private Sub LoadData()
            Try
                Dim fromDate = CDate(dtpFromDate.EditValue)
                Dim toDate = CDate(dtpToDate.EditValue).AddDays(1)

                Dim orders = _orderManager.GetOrdersByDateRange(fromDate, toDate)

                If cboStatus.Text <> "All" Then
                    orders = orders.Where(Function(o) o.Order_Status = cboStatus.Text).ToList()
                End If

                gridOrders.DataSource = orders

                Dim totalSales = orders.Sum(Function(o) o.Total_Amount)
                lblTotalSales.Text = $"Total: {totalSales:C2}"
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
            LoadData()
        End Sub

        Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Try
                Using saveDialog As New SaveFileDialog()
                    saveDialog.Filter = "Excel Files|*.xlsx"
                    saveDialog.FileName = $"OrderReport_{DateTime.Now:yyyyMMdd}.xlsx"
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

    End Class

End Namespace
