Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports InventoryManagement.BusinessLogic
Imports InventoryManagement.Entities

Namespace Forms.Purchases

    Partial Public Class PurchaseListForm

        Private ReadOnly _purchaseManager As New PurchaseManager()
        Private _purchases As List(Of PurchaseHeader)

        Public Sub New()
            InitializeComponent()
            SetupGrid()
        End Sub

        Private Sub SetupGrid()
            gridView.Columns.Clear()

            Dim colNumber As New GridColumn()
            colNumber.FieldName = "Purchase_Number"
            colNumber.Caption = "PO #"
            colNumber.Width = 120
            colNumber.Visible = True
            gridView.Columns.Add(colNumber)

            Dim colDate As New GridColumn()
            colDate.FieldName = "Purchase_Date"
            colDate.Caption = "PO Date"
            colDate.Width = 100
            colDate.Visible = True
            colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            colDate.DisplayFormat.FormatString = "yyyy-MM-dd"
            gridView.Columns.Add(colDate)

            Dim colSupplier As New GridColumn()
            colSupplier.FieldName = "Supplier.Supplier_Name"
            colSupplier.Caption = "Supplier"
            colSupplier.Width = 180
            colSupplier.Visible = True
            gridView.Columns.Add(colSupplier)

            Dim colStatus As New GridColumn()
            colStatus.FieldName = "Purchase_Status"
            colStatus.Caption = "Status"
            colStatus.Width = 100
            colStatus.Visible = True
            gridView.Columns.Add(colStatus)

            Dim colTotal As New GridColumn()
            colTotal.FieldName = "Total_Amount"
            colTotal.Caption = "Total"
            colTotal.Width = 100
            colTotal.Visible = True
            colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colTotal.DisplayFormat.FormatString = "C2"
            gridView.Columns.Add(colTotal)

            Dim colReceived As New GridColumn()
            colReceived.FieldName = "Is_Received"
            colReceived.Caption = "Received"
            colReceived.Width = 70
            colReceived.Visible = True
            gridView.Columns.Add(colReceived)

            gridView.BestFitColumns()
        End Sub

        Private Sub LoadData()
            Try
                _purchases = _purchaseManager.GetAllPurchases()
                gridControl.DataSource = _purchases
            Catch ex As Exception
                XtraMessageBox.Show("Error loading purchases: " & ex.Message, "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub AddNew()
            Dim frm As New PurchaseEditForm()
            frm.MdiParent = Me.MdiParent
            frm.Show()
        End Sub

        Private Sub EditSelected()
            If gridView.FocusedRowHandle < 0 Then Return
            Dim purchase = TryCast(gridView.GetFocusedRow(), PurchaseHeader)
            If purchase IsNot Nothing Then
                Dim frm As New PurchaseEditForm(purchase.Purchase_ID)
                frm.MdiParent = Me.MdiParent
                frm.Show()
            End If
        End Sub

        Private Sub DeleteSelected()
            If gridView.FocusedRowHandle < 0 Then Return
            Dim purchase = TryCast(gridView.GetFocusedRow(), PurchaseHeader)
            If purchase IsNot Nothing Then
                If purchase.Purchase_Status <> "Draft" Then
                    XtraMessageBox.Show("Only draft purchases can be cancelled.", "Cannot Delete",
                                       MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                If XtraMessageBox.Show($"Are you sure you want to cancel purchase '{purchase.Purchase_Number}'?",
                                      "Confirm Cancel", MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question) = DialogResult.Yes Then
                    Try
                        _purchaseManager.CancelPurchase(purchase.Purchase_ID)
                        LoadData()
                    Catch ex As Exception
                        XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End Sub

        Private Sub PurchaseListForm_Load(sender As Object, e As EventArgs) Handles Me.Load
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
