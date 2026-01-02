Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports InventoryManagement.DataAccess

Namespace Forms.InventoryControl

    Partial Public Class StockHistoryForm

        Private ReadOnly _historyDAO As New StockHistoryDAO()

        Public Sub New()
            InitializeComponent()
            SetupForm()
            SetupGrid()
            LoadData()
        End Sub

        Private Sub SetupForm()
            dtpFromDate.EditValue = DateTime.Now.AddMonths(-1)
            dtpToDate.EditValue = DateTime.Now
        End Sub

        Private Sub SetupGrid()
            gridView.Columns.Clear()

            Dim colDate As New GridColumn()
            colDate.FieldName = "Transaction_Date"
            colDate.Caption = "Date/Time"
            colDate.Width = 130
            colDate.Visible = True
            colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            colDate.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
            gridView.Columns.Add(colDate)

            Dim colItem As New GridColumn()
            colItem.FieldName = "Item.Item_Name"
            colItem.Caption = "Item"
            colItem.Width = 180
            colItem.Visible = True
            gridView.Columns.Add(colItem)

            Dim colType As New GridColumn()
            colType.FieldName = "Transaction_Type"
            colType.Caption = "Type"
            colType.Width = 80
            colType.Visible = True
            gridView.Columns.Add(colType)

            Dim colRef As New GridColumn()
            colRef.FieldName = "Reference_Type"
            colRef.Caption = "Reference"
            colRef.Width = 120
            colRef.Visible = True
            gridView.Columns.Add(colRef)

            Dim colChange As New GridColumn()
            colChange.FieldName = "Quantity_Change"
            colChange.Caption = "Qty Change"
            colChange.Width = 90
            colChange.Visible = True
            gridView.Columns.Add(colChange)

            Dim colBefore As New GridColumn()
            colBefore.FieldName = "Stock_Before"
            colBefore.Caption = "Before"
            colBefore.Width = 70
            colBefore.Visible = True
            gridView.Columns.Add(colBefore)

            Dim colAfter As New GridColumn()
            colAfter.FieldName = "Stock_After"
            colAfter.Caption = "After"
            colAfter.Width = 70
            colAfter.Visible = True
            gridView.Columns.Add(colAfter)

            Dim colCost As New GridColumn()
            colCost.FieldName = "Unit_Cost"
            colCost.Caption = "Unit Cost"
            colCost.Width = 80
            colCost.Visible = True
            colCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colCost.DisplayFormat.FormatString = "C2"
            gridView.Columns.Add(colCost)

            Dim colNotes As New GridColumn()
            colNotes.FieldName = "Notes"
            colNotes.Caption = "Notes"
            colNotes.Width = 150
            colNotes.Visible = True
            gridView.Columns.Add(colNotes)

            gridView.BestFitColumns()
        End Sub

        Private Sub LoadData()
            Try
                Dim fromDate = CDate(dtpFromDate.EditValue)
                Dim toDate = CDate(dtpToDate.EditValue).AddDays(1)
                Dim history = _historyDAO.GetByDateRange(fromDate, toDate)
                gridHistory.DataSource = history
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
            LoadData()
        End Sub

        Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
            LoadData()
        End Sub

    End Class

End Namespace
