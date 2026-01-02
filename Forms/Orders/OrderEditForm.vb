Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports InventoryManagement.BusinessLogic
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Entities
Imports InventoryManagement.Common

Namespace Forms.Orders

    Partial Public Class OrderEditForm

        Private _orderId As Integer
        Private _order As OrderHeader
        Private ReadOnly _orderManager As New OrderManager()
        Private ReadOnly _paymentTermDAO As New PaymentTermDAO()
        Private ReadOnly _itemDAO As New ItemDAO()

        Public Sub New(Optional orderId As Integer = 0)
            _orderId = orderId
            InitializeComponent()
            SetupForm()
            SetupLinesGrid()
            LoadLookups()
            LoadData()
        End Sub

        Private Sub SetupForm()
            Me.Text = If(_orderId = 0, "New Order", "Edit Order")
            dtpOrderDate.EditValue = DateTime.Now
        End Sub

        Private Sub SetupLinesGrid()
            gridViewLines.Columns.Clear()

            Dim colLineNum As New GridColumn()
            colLineNum.FieldName = "Line_Number"
            colLineNum.Caption = "#"
            colLineNum.Width = 40
            colLineNum.Visible = True
            gridViewLines.Columns.Add(colLineNum)

            Dim colItem As New GridColumn()
            colItem.FieldName = "Item_ID"
            colItem.Caption = "Item"
            colItem.Width = 200
            colItem.Visible = True
            Dim itemLookup As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            itemLookup.Columns.Clear()
            itemLookup.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Item_Code", "Code", 80))
            itemLookup.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Item_Name", "Name", 200))
            itemLookup.PopupWidth = 300
            itemLookup.DataSource = _itemDAO.GetActiveItems()
            itemLookup.DisplayMember = "Item_Name"
            itemLookup.ValueMember = "Item_ID"
            colItem.ColumnEdit = itemLookup
            gridViewLines.Columns.Add(colItem)

            Dim colQty As New GridColumn()
            colQty.FieldName = "Quantity"
            colQty.Caption = "Quantity"
            colQty.Width = 80
            colQty.Visible = True
            gridViewLines.Columns.Add(colQty)

            Dim colPrice As New GridColumn()
            colPrice.FieldName = "Unit_Price"
            colPrice.Caption = "Unit Price"
            colPrice.Width = 90
            colPrice.Visible = True
            colPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colPrice.DisplayFormat.FormatString = "C2"
            gridViewLines.Columns.Add(colPrice)

            Dim colDiscount As New GridColumn()
            colDiscount.FieldName = "Discount_Percent"
            colDiscount.Caption = "Discount %"
            colDiscount.Width = 80
            colDiscount.Visible = True
            gridViewLines.Columns.Add(colDiscount)

            Dim colTotal As New GridColumn()
            colTotal.FieldName = "Line_Total"
            colTotal.Caption = "Line Total"
            colTotal.Width = 100
            colTotal.Visible = True
            colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colTotal.DisplayFormat.FormatString = "C2"
            gridViewLines.Columns.Add(colTotal)

            AddHandler gridViewLines.CellValueChanged, AddressOf GridViewLines_CellValueChanged
        End Sub

        Private Sub GridViewLines_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
            If e.Column.FieldName = "Quantity" OrElse e.Column.FieldName = "Unit_Price" OrElse e.Column.FieldName = "Discount_Percent" Then
                CalculateLineTotal(e.RowHandle)
                CalculateTotals()
            End If
        End Sub

        Private Sub CalculateLineTotal(rowHandle As Integer)
            If rowHandle < 0 Then Return
            Dim qty = Convert.ToDecimal(If(gridViewLines.GetRowCellValue(rowHandle, "Quantity"), 0))
            Dim price = Convert.ToDecimal(If(gridViewLines.GetRowCellValue(rowHandle, "Unit_Price"), 0))
            Dim discount = Convert.ToDecimal(If(gridViewLines.GetRowCellValue(rowHandle, "Discount_Percent"), 0))

            Dim subtotal = qty * price
            Dim discountAmt = subtotal * (discount / 100)
            Dim total = subtotal - discountAmt

            gridViewLines.SetRowCellValue(rowHandle, "Line_Total", total)
        End Sub

        Private Sub CalculateTotals()
            Dim subtotal As Decimal = 0
            For i = 0 To gridViewLines.RowCount - 1
                Dim lineTotal = Convert.ToDecimal(If(gridViewLines.GetRowCellValue(i, "Line_Total"), 0))
                subtotal += lineTotal
            Next

            Dim taxRate = AppSettings.Instance.TaxRate
            Dim tax = subtotal * (taxRate / 100)
            Dim total = subtotal + tax

            txtSubtotal.EditValue = subtotal
            txtTax.EditValue = tax
            txtTotal.EditValue = total
        End Sub

        Private Sub LoadLookups()
            ' Configure payment term lookup columns
            cboPaymentTerm.Properties.Columns.Clear()
            cboPaymentTerm.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Term_Code", "Code", 60))
            cboPaymentTerm.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Term_Description", "Description", 150))
            cboPaymentTerm.Properties.PopupWidth = 230
            cboPaymentTerm.Properties.DataSource = _paymentTermDAO.GetActiveTerms()
        End Sub

        Private Sub LoadData()
            If _orderId > 0 Then
                _order = _orderManager.GetOrderById(_orderId)
                If _order IsNot Nothing Then
                    txtOrderNumber.Text = _order.Order_Number
                    dtpOrderDate.EditValue = _order.Order_Date
                    txtCustomerName.Text = _order.Customer_Name
                    txtCustomerContact.Text = _order.Customer_Contact
                    cboPaymentTerm.EditValue = _order.Payment_Term_ID
                    txtNotes.Text = _order.Notes
                    gridLines.DataSource = _order.OrderLines
                    CalculateTotals()
                    UpdateButtonStates()
                End If
            Else
                _order = _orderManager.CreateNewOrder()
                txtOrderNumber.Text = _order.Order_Number
                dtpOrderDate.EditValue = _order.Order_Date
                _order.OrderLines = New List(Of OrderLine)()
                gridLines.DataSource = _order.OrderLines
            End If
        End Sub

        Private Sub UpdateButtonStates()
            Dim canEdit = _order.CanEdit
            txtCustomerName.Properties.ReadOnly = Not canEdit
            txtCustomerContact.Properties.ReadOnly = Not canEdit
            cboPaymentTerm.Properties.ReadOnly = Not canEdit
            txtNotes.Properties.ReadOnly = Not canEdit
            gridViewLines.OptionsBehavior.Editable = canEdit

            btnAddLine.Enabled = canEdit
            btnRemoveLine.Enabled = canEdit
            btnSave.Enabled = canEdit
            btnSubmit.Enabled = _order.Order_Status = "Draft"
            btnApprove.Enabled = _order.Order_Status = "Submitted" AndAlso SessionManager.Instance.IsManager
            btnDeliver.Enabled = _order.Order_Status = "Approved"
            btnCancel.Enabled = _order.CanCancel
        End Sub

        Private Sub btnAddLine_Click(sender As Object, e As EventArgs) Handles btnAddLine.Click
            Dim newLine As New OrderLine()
            newLine.Order_ID = _order.Order_ID
            newLine.Line_Number = _order.OrderLines.Count + 1
            _order.OrderLines.Add(newLine)
            gridLines.RefreshDataSource()
        End Sub

        Private Sub btnRemoveLine_Click(sender As Object, e As EventArgs) Handles btnRemoveLine.Click
            If gridViewLines.FocusedRowHandle >= 0 Then
                _order.OrderLines.RemoveAt(gridViewLines.FocusedRowHandle)
                gridLines.RefreshDataSource()
                CalculateTotals()
            End If
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            Try
                UpdateOrderFromForm()
                _orderManager.SaveOrder(_order)

                Dim orderDAO As New OrderDAO()
                orderDAO.DeleteOrderLines(_order.Order_ID)
                For Each line In _order.OrderLines
                    line.Order_ID = _order.Order_ID
                    orderDAO.InsertLine(line)
                Next

                XtraMessageBox.Show("Order saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _orderId = _order.Order_ID
                LoadData()
            Catch ex As Exception
                XtraMessageBox.Show("Error saving order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub UpdateOrderFromForm()
            _order.Order_Date = CDate(dtpOrderDate.EditValue)
            _order.Customer_Name = txtCustomerName.Text
            _order.Customer_Contact = txtCustomerContact.Text
            _order.Payment_Term_ID = If(cboPaymentTerm.EditValue IsNot Nothing, CInt(cboPaymentTerm.EditValue), Nothing)
            _order.Notes = txtNotes.Text
            _order.Subtotal = Convert.ToDecimal(txtSubtotal.EditValue)
            _order.Tax_Amount = Convert.ToDecimal(txtTax.EditValue)
            _order.Total_Amount = Convert.ToDecimal(txtTotal.EditValue)
        End Sub

        Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
            Try
                btnSave_Click(sender, e)
                _orderManager.SubmitOrder(_order.Order_ID)
                XtraMessageBox.Show("Order submitted for approval.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
            Try
                _orderManager.ApproveOrder(_order.Order_ID)
                XtraMessageBox.Show("Order approved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnDeliver_Click(sender As Object, e As EventArgs) Handles btnDeliver.Click
            Try
                If XtraMessageBox.Show("This will deduct stock from inventory. Continue?", "Confirm Delivery",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    _orderManager.ProcessDelivery(_order.Order_ID)
                    XtraMessageBox.Show("Order delivered and stock updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadData()
                End If
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Try
                If XtraMessageBox.Show("Are you sure you want to cancel this order?", "Confirm Cancel",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    _orderManager.CancelOrder(_order.Order_ID)
                    XtraMessageBox.Show("Order cancelled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadData()
                End If
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub

    End Class

End Namespace
