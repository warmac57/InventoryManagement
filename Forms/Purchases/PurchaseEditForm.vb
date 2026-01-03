Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports InventoryManagement.BusinessLogic
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Entities
Imports InventoryManagement.Common

Namespace Forms.Purchases

    Partial Public Class PurchaseEditForm

        Private _purchaseId As Integer
        Private _purchase As PurchaseHeader
        Private ReadOnly _purchaseManager As New PurchaseManager()
        Private ReadOnly _supplierDAO As New SupplierDAO()
        Private ReadOnly _itemDAO As New ItemDAO()

        Public Sub New(Optional purchaseId As Integer = 0)
            _purchaseId = purchaseId
            InitializeComponent()
            Me.Text = If(_purchaseId = 0, "New Purchase Order", "Edit Purchase Order")
            dtpPurchaseDate.EditValue = DateTime.Now
            SetupItemsGrid()
            LoadLookups()
            LoadData()
        End Sub

        Private Sub SetupItemsGrid()
            gridViewItems.Columns.Clear()

            Dim colLineNum As New GridColumn()
            colLineNum.FieldName = "Line_Number"
            colLineNum.Caption = "#"
            colLineNum.Width = 40
            colLineNum.Visible = True
            gridViewItems.Columns.Add(colLineNum)

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
            gridViewItems.Columns.Add(colItem)

            Dim colQty As New GridColumn()
            colQty.FieldName = "Quantity"
            colQty.Caption = "Quantity"
            colQty.Width = 80
            colQty.Visible = True
            gridViewItems.Columns.Add(colQty)

            Dim colCost As New GridColumn()
            colCost.FieldName = "Unit_Cost"
            colCost.Caption = "Unit Cost"
            colCost.Width = 90
            colCost.Visible = True
            colCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colCost.DisplayFormat.FormatString = "C2"
            gridViewItems.Columns.Add(colCost)

            Dim colTotal As New GridColumn()
            colTotal.FieldName = "Line_Total"
            colTotal.Caption = "Line Total"
            colTotal.Width = 100
            colTotal.Visible = True
            colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colTotal.DisplayFormat.FormatString = "C2"
            gridViewItems.Columns.Add(colTotal)

            AddHandler gridViewItems.CellValueChanged, AddressOf GridViewItems_CellValueChanged
        End Sub

        Private Sub GridViewItems_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
            If e.Column.FieldName = "Quantity" OrElse e.Column.FieldName = "Unit_Cost" Then
                CalculateLineTotal(e.RowHandle)
                CalculateTotals()
            End If
        End Sub

        Private Sub CalculateLineTotal(rowHandle As Integer)
            If rowHandle < 0 Then Return
            Dim qty = Convert.ToDecimal(If(gridViewItems.GetRowCellValue(rowHandle, "Quantity"), 0))
            Dim cost = Convert.ToDecimal(If(gridViewItems.GetRowCellValue(rowHandle, "Unit_Cost"), 0))
            gridViewItems.SetRowCellValue(rowHandle, "Line_Total", qty * cost)
        End Sub

        Private Sub CalculateTotals()
            Dim subtotal As Decimal = 0
            For i = 0 To gridViewItems.RowCount - 1
                Dim lineTotal = Convert.ToDecimal(If(gridViewItems.GetRowCellValue(i, "Line_Total"), 0))
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
            ' Configure supplier lookup columns
            cboSupplier.Properties.Columns.Clear()
            cboSupplier.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Supplier_Name", "Supplier Name", 200))
            cboSupplier.Properties.PopupWidth = 220
            cboSupplier.Properties.DataSource = _supplierDAO.GetActiveSuppliers()
        End Sub

        Private Sub LoadData()
            If _purchaseId > 0 Then
                _purchase = _purchaseManager.GetPurchaseById(_purchaseId)
                If _purchase IsNot Nothing Then
                    txtPurchaseNumber.Text = _purchase.Purchase_Number
                    dtpPurchaseDate.EditValue = _purchase.Purchase_Date
                    cboSupplier.EditValue = _purchase.Supplier_ID
                    dtpExpectedDate.EditValue = _purchase.Expected_Date
                    txtNotes.Text = _purchase.Notes
                    gridItems.DataSource = _purchase.PurchaseItems
                    CalculateTotals()
                    UpdateButtonStates()
                End If
            Else
                _purchase = _purchaseManager.CreateNewPurchase()
                txtPurchaseNumber.Text = _purchase.Purchase_Number
                dtpPurchaseDate.EditValue = _purchase.Purchase_Date
                _purchase.PurchaseItems = New List(Of PurchaseItem)()
                gridItems.DataSource = _purchase.PurchaseItems
            End If
        End Sub

        Private Sub UpdateButtonStates()
            Dim canEdit = _purchase.CanEdit
            cboSupplier.Properties.ReadOnly = Not canEdit
            dtpExpectedDate.Properties.ReadOnly = Not canEdit
            txtNotes.Properties.ReadOnly = Not canEdit
            gridViewItems.OptionsBehavior.Editable = canEdit

            btnAddItem.Enabled = canEdit
            btnRemoveItem.Enabled = canEdit
            btnSave.Enabled = canEdit
            btnApprove.Enabled = _purchase.Purchase_Status = "Draft" AndAlso SessionManager.Instance.IsManager
            btnReceive.Enabled = _purchase.CanReceive
            btnCancel.Enabled = _purchase.CanCancel
        End Sub

        Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
            Dim newItem As New PurchaseItem()
            newItem.Purchase_ID = _purchase.Purchase_ID
            newItem.Line_Number = _purchase.PurchaseItems.Count + 1
            _purchase.PurchaseItems.Add(newItem)
            gridItems.RefreshDataSource()
        End Sub

        Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
            If gridViewItems.FocusedRowHandle >= 0 Then
                _purchase.PurchaseItems.RemoveAt(gridViewItems.FocusedRowHandle)
                gridItems.RefreshDataSource()
                CalculateTotals()
            End If
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            Try
                If cboSupplier.EditValue Is Nothing Then
                    XtraMessageBox.Show("Please select a supplier.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                _purchase.Purchase_Date = CDate(dtpPurchaseDate.EditValue)
                _purchase.Supplier_ID = CInt(cboSupplier.EditValue)
                _purchase.Expected_Date = If(dtpExpectedDate.EditValue IsNot Nothing, CDate(dtpExpectedDate.EditValue), Nothing)
                _purchase.Notes = txtNotes.Text
                _purchase.Subtotal = Convert.ToDecimal(txtSubtotal.EditValue)
                _purchase.Tax_Amount = Convert.ToDecimal(txtTax.EditValue)
                _purchase.Total_Amount = Convert.ToDecimal(txtTotal.EditValue)

                _purchaseManager.SavePurchase(_purchase)

                Dim purchaseDAO As New PurchaseDAO()
                For Each item In _purchase.PurchaseItems
                    item.Purchase_ID = _purchase.Purchase_ID
                    If item.Purchase_Item_ID = 0 Then
                        purchaseDAO.InsertItem(item)
                    Else
                        purchaseDAO.UpdateItem(item)
                    End If
                Next

                XtraMessageBox.Show("Purchase saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _purchaseId = _purchase.Purchase_ID
                LoadData()
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
            Try
                _purchaseManager.ApprovePurchase(_purchase.Purchase_ID)
                XtraMessageBox.Show("Purchase approved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnReceive_Click(sender As Object, e As EventArgs) Handles btnReceive.Click
            Try
                If XtraMessageBox.Show("This will add stock to inventory and update costs. Continue?", "Confirm Receive",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    _purchaseManager.ReceivePurchase(_purchase.Purchase_ID)
                    XtraMessageBox.Show("Purchase received and stock updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadData()
                End If
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Try
                If XtraMessageBox.Show("Are you sure you want to cancel this purchase?", "Confirm Cancel",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    _purchaseManager.CancelPurchase(_purchase.Purchase_ID)
                    XtraMessageBox.Show("Purchase cancelled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadData()
                End If
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub

        Private Sub PurchaseEditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        End Sub
    End Class

End Namespace
