Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports InventoryManagement.BusinessLogic
Imports InventoryManagement.Entities

Namespace Forms.Orders

    Partial Public Class OrderListForm

        Private ReadOnly _orderManager As New OrderManager()
        Private _orders As List(Of OrderHeader)

        Public Sub New()
            InitializeComponent()
            SetupGrid()
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
            colDate.Caption = "Order Date"
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

            Dim colApproved As New GridColumn()
            colApproved.FieldName = "Is_Approved"
            colApproved.Caption = "Approved"
            colApproved.Width = 70
            colApproved.Visible = True
            gridView.Columns.Add(colApproved)

            gridView.BestFitColumns()
        End Sub

        Private Sub LoadData()
            Try
                _orders = _orderManager.GetAllOrders()
                gridControl.DataSource = _orders
            Catch ex As Exception
                XtraMessageBox.Show("Error loading orders: " & ex.Message, "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub AddNew()
            Dim frm As New OrderEditForm()
            frm.MdiParent = Me.MdiParent
            frm.Show()
        End Sub

        Private Sub EditSelected()
            If gridView.FocusedRowHandle < 0 Then Return
            Dim order = TryCast(gridView.GetFocusedRow(), OrderHeader)
            If order IsNot Nothing Then
                Dim frm As New OrderEditForm(order.Order_ID)
                frm.MdiParent = Me.MdiParent
                frm.Show()
            End If
        End Sub

        Private Sub DeleteSelected()
            If gridView.FocusedRowHandle < 0 Then Return
            Dim order = TryCast(gridView.GetFocusedRow(), OrderHeader)
            If order IsNot Nothing Then
                If order.Order_Status <> "Draft" Then
                    XtraMessageBox.Show("Only draft orders can be deleted.", "Cannot Delete",
                                       MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                If XtraMessageBox.Show($"Are you sure you want to delete order '{order.Order_Number}'?",
                                      "Confirm Delete", MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question) = DialogResult.Yes Then
                    Try
                        _orderManager.CancelOrder(order.Order_ID)
                        LoadData()
                    Catch ex As Exception
                        XtraMessageBox.Show("Error cancelling order: " & ex.Message, "Error",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End Sub

        Private Sub OrderListForm_Load(sender As Object, e As EventArgs) Handles Me.Load
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
