Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Namespace Forms.Orders
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class OrderEditForm
        Inherits DevExpress.XtraEditors.XtraForm

        Private components As System.ComponentModel.IContainer

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.pnlHeader = New DevExpress.XtraEditors.PanelControl()
            Me.lblOrderNumber = New DevExpress.XtraEditors.LabelControl()
            Me.lblOrderDate = New DevExpress.XtraEditors.LabelControl()
            Me.lblCustomerName = New DevExpress.XtraEditors.LabelControl()
            Me.lblContact = New DevExpress.XtraEditors.LabelControl()
            Me.lblPaymentTerm = New DevExpress.XtraEditors.LabelControl()
            Me.lblNotes = New DevExpress.XtraEditors.LabelControl()
            Me.txtOrderNumber = New DevExpress.XtraEditors.TextEdit()
            Me.dtpOrderDate = New DevExpress.XtraEditors.DateEdit()
            Me.txtCustomerName = New DevExpress.XtraEditors.TextEdit()
            Me.txtCustomerContact = New DevExpress.XtraEditors.TextEdit()
            Me.cboPaymentTerm = New DevExpress.XtraEditors.LookUpEdit()
            Me.txtNotes = New DevExpress.XtraEditors.MemoEdit()
            Me.pnlTotals = New DevExpress.XtraEditors.PanelControl()
            Me.lblSubtotal = New DevExpress.XtraEditors.LabelControl()
            Me.lblTax = New DevExpress.XtraEditors.LabelControl()
            Me.lblTotal = New DevExpress.XtraEditors.LabelControl()
            Me.txtSubtotal = New DevExpress.XtraEditors.TextEdit()
            Me.txtTax = New DevExpress.XtraEditors.TextEdit()
            Me.txtTotal = New DevExpress.XtraEditors.TextEdit()
            Me.btnAddLine = New DevExpress.XtraEditors.SimpleButton()
            Me.btnRemoveLine = New DevExpress.XtraEditors.SimpleButton()
            Me.pnlButtons = New DevExpress.XtraEditors.PanelControl()
            Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
            Me.btnSubmit = New DevExpress.XtraEditors.SimpleButton()
            Me.btnApprove = New DevExpress.XtraEditors.SimpleButton()
            Me.btnDeliver = New DevExpress.XtraEditors.SimpleButton()
            Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
            Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
            Me.gridLines = New DevExpress.XtraGrid.GridControl()
            Me.gridViewLines = New DevExpress.XtraGrid.Views.Grid.GridView()
            CType(Me.pnlHeader, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlHeader.SuspendLayout()
            CType(Me.txtOrderNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtpOrderDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtpOrderDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtCustomerName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtCustomerContact.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboPaymentTerm.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtNotes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pnlTotals, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlTotals.SuspendLayout()
            CType(Me.txtSubtotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pnlButtons, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlButtons.SuspendLayout()
            CType(Me.gridLines, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridViewLines, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            ' pnlHeader
            '
            Me.pnlHeader.Controls.Add(Me.txtNotes)
            Me.pnlHeader.Controls.Add(Me.cboPaymentTerm)
            Me.pnlHeader.Controls.Add(Me.txtCustomerContact)
            Me.pnlHeader.Controls.Add(Me.txtCustomerName)
            Me.pnlHeader.Controls.Add(Me.dtpOrderDate)
            Me.pnlHeader.Controls.Add(Me.txtOrderNumber)
            Me.pnlHeader.Controls.Add(Me.lblNotes)
            Me.pnlHeader.Controls.Add(Me.lblPaymentTerm)
            Me.pnlHeader.Controls.Add(Me.lblContact)
            Me.pnlHeader.Controls.Add(Me.lblCustomerName)
            Me.pnlHeader.Controls.Add(Me.lblOrderDate)
            Me.pnlHeader.Controls.Add(Me.lblOrderNumber)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New System.Drawing.Size(884, 150)
            Me.pnlHeader.TabIndex = 0
            '
            ' lblOrderNumber
            '
            Me.lblOrderNumber.Location = New System.Drawing.Point(20, 18)
            Me.lblOrderNumber.Name = "lblOrderNumber"
            Me.lblOrderNumber.Size = New System.Drawing.Size(71, 13)
            Me.lblOrderNumber.TabIndex = 0
            Me.lblOrderNumber.Text = "Order Number:"
            '
            ' lblOrderDate
            '
            Me.lblOrderDate.Location = New System.Drawing.Point(300, 18)
            Me.lblOrderDate.Name = "lblOrderDate"
            Me.lblOrderDate.Size = New System.Drawing.Size(58, 13)
            Me.lblOrderDate.TabIndex = 1
            Me.lblOrderDate.Text = "Order Date:"
            '
            ' lblCustomerName
            '
            Me.lblCustomerName.Location = New System.Drawing.Point(20, 53)
            Me.lblCustomerName.Name = "lblCustomerName"
            Me.lblCustomerName.Size = New System.Drawing.Size(80, 13)
            Me.lblCustomerName.TabIndex = 2
            Me.lblCustomerName.Text = "Customer Name:"
            '
            ' lblContact
            '
            Me.lblContact.Location = New System.Drawing.Point(400, 53)
            Me.lblContact.Name = "lblContact"
            Me.lblContact.Size = New System.Drawing.Size(42, 13)
            Me.lblContact.TabIndex = 3
            Me.lblContact.Text = "Contact:"
            '
            ' lblPaymentTerm
            '
            Me.lblPaymentTerm.Location = New System.Drawing.Point(20, 88)
            Me.lblPaymentTerm.Name = "lblPaymentTerm"
            Me.lblPaymentTerm.Size = New System.Drawing.Size(73, 13)
            Me.lblPaymentTerm.TabIndex = 4
            Me.lblPaymentTerm.Text = "Payment Term:"
            '
            ' lblNotes
            '
            Me.lblNotes.Location = New System.Drawing.Point(20, 123)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(31, 13)
            Me.lblNotes.TabIndex = 5
            Me.lblNotes.Text = "Notes:"
            '
            ' txtOrderNumber
            '
            Me.txtOrderNumber.Location = New System.Drawing.Point(120, 15)
            Me.txtOrderNumber.Name = "txtOrderNumber"
            Me.txtOrderNumber.Properties.ReadOnly = True
            Me.txtOrderNumber.Size = New System.Drawing.Size(150, 20)
            Me.txtOrderNumber.TabIndex = 6
            '
            ' dtpOrderDate
            '
            Me.dtpOrderDate.EditValue = Nothing
            Me.dtpOrderDate.Location = New System.Drawing.Point(380, 15)
            Me.dtpOrderDate.Name = "dtpOrderDate"
            Me.dtpOrderDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dtpOrderDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dtpOrderDate.Size = New System.Drawing.Size(120, 20)
            Me.dtpOrderDate.TabIndex = 7
            '
            ' txtCustomerName
            '
            Me.txtCustomerName.Location = New System.Drawing.Point(120, 50)
            Me.txtCustomerName.Name = "txtCustomerName"
            Me.txtCustomerName.Size = New System.Drawing.Size(250, 20)
            Me.txtCustomerName.TabIndex = 8
            '
            ' txtCustomerContact
            '
            Me.txtCustomerContact.Location = New System.Drawing.Point(460, 50)
            Me.txtCustomerContact.Name = "txtCustomerContact"
            Me.txtCustomerContact.Size = New System.Drawing.Size(200, 20)
            Me.txtCustomerContact.TabIndex = 9
            '
            ' cboPaymentTerm
            '
            Me.cboPaymentTerm.Location = New System.Drawing.Point(120, 85)
            Me.cboPaymentTerm.Name = "cboPaymentTerm"
            Me.cboPaymentTerm.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.cboPaymentTerm.Properties.DisplayMember = "Term_Description"
            Me.cboPaymentTerm.Properties.NullText = "[Select Payment Term]"
            Me.cboPaymentTerm.Properties.ValueMember = "Payment_Term_ID"
            Me.cboPaymentTerm.Size = New System.Drawing.Size(200, 20)
            Me.cboPaymentTerm.TabIndex = 10
            '
            ' txtNotes
            '
            Me.txtNotes.Location = New System.Drawing.Point(120, 120)
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.Size = New System.Drawing.Size(540, 25)
            Me.txtNotes.TabIndex = 11
            '
            ' pnlTotals
            '
            Me.pnlTotals.Controls.Add(Me.btnRemoveLine)
            Me.pnlTotals.Controls.Add(Me.btnAddLine)
            Me.pnlTotals.Controls.Add(Me.txtTotal)
            Me.pnlTotals.Controls.Add(Me.txtTax)
            Me.pnlTotals.Controls.Add(Me.txtSubtotal)
            Me.pnlTotals.Controls.Add(Me.lblTotal)
            Me.pnlTotals.Controls.Add(Me.lblTax)
            Me.pnlTotals.Controls.Add(Me.lblSubtotal)
            Me.pnlTotals.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnlTotals.Location = New System.Drawing.Point(684, 150)
            Me.pnlTotals.Name = "pnlTotals"
            Me.pnlTotals.Size = New System.Drawing.Size(200, 411)
            Me.pnlTotals.TabIndex = 1
            '
            ' lblSubtotal
            '
            Me.lblSubtotal.Location = New System.Drawing.Point(20, 20)
            Me.lblSubtotal.Name = "lblSubtotal"
            Me.lblSubtotal.Size = New System.Drawing.Size(43, 13)
            Me.lblSubtotal.TabIndex = 0
            Me.lblSubtotal.Text = "Subtotal:"
            '
            ' lblTax
            '
            Me.lblTax.Location = New System.Drawing.Point(20, 50)
            Me.lblTax.Name = "lblTax"
            Me.lblTax.Size = New System.Drawing.Size(18, 13)
            Me.lblTax.TabIndex = 1
            Me.lblTax.Text = "Tax:"
            '
            ' lblTotal
            '
            Me.lblTotal.Location = New System.Drawing.Point(20, 80)
            Me.lblTotal.Name = "lblTotal"
            Me.lblTotal.Size = New System.Drawing.Size(27, 13)
            Me.lblTotal.TabIndex = 2
            Me.lblTotal.Text = "Total:"
            '
            ' txtSubtotal
            '
            Me.txtSubtotal.Location = New System.Drawing.Point(90, 17)
            Me.txtSubtotal.Name = "txtSubtotal"
            Me.txtSubtotal.Properties.DisplayFormat.FormatString = "C2"
            Me.txtSubtotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.txtSubtotal.Properties.ReadOnly = True
            Me.txtSubtotal.Size = New System.Drawing.Size(90, 20)
            Me.txtSubtotal.TabIndex = 3
            '
            ' txtTax
            '
            Me.txtTax.Location = New System.Drawing.Point(90, 47)
            Me.txtTax.Name = "txtTax"
            Me.txtTax.Properties.DisplayFormat.FormatString = "C2"
            Me.txtTax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.txtTax.Properties.ReadOnly = True
            Me.txtTax.Size = New System.Drawing.Size(90, 20)
            Me.txtTax.TabIndex = 4
            '
            ' txtTotal
            '
            Me.txtTotal.Location = New System.Drawing.Point(90, 77)
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.txtTotal.Properties.Appearance.Options.UseFont = True
            Me.txtTotal.Properties.DisplayFormat.FormatString = "C2"
            Me.txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.txtTotal.Properties.ReadOnly = True
            Me.txtTotal.Size = New System.Drawing.Size(90, 20)
            Me.txtTotal.TabIndex = 5
            '
            ' btnAddLine
            '
            Me.btnAddLine.Location = New System.Drawing.Point(20, 130)
            Me.btnAddLine.Name = "btnAddLine"
            Me.btnAddLine.Size = New System.Drawing.Size(80, 25)
            Me.btnAddLine.TabIndex = 6
            Me.btnAddLine.Text = "Add Line"
            '
            ' btnRemoveLine
            '
            Me.btnRemoveLine.Location = New System.Drawing.Point(105, 130)
            Me.btnRemoveLine.Name = "btnRemoveLine"
            Me.btnRemoveLine.Size = New System.Drawing.Size(80, 25)
            Me.btnRemoveLine.TabIndex = 7
            Me.btnRemoveLine.Text = "Remove"
            '
            ' pnlButtons
            '
            Me.pnlButtons.Controls.Add(Me.btnClose)
            Me.pnlButtons.Controls.Add(Me.btnCancel)
            Me.pnlButtons.Controls.Add(Me.btnDeliver)
            Me.pnlButtons.Controls.Add(Me.btnApprove)
            Me.pnlButtons.Controls.Add(Me.btnSubmit)
            Me.pnlButtons.Controls.Add(Me.btnSave)
            Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlButtons.Location = New System.Drawing.Point(0, 561)
            Me.pnlButtons.Name = "pnlButtons"
            Me.pnlButtons.Size = New System.Drawing.Size(884, 50)
            Me.pnlButtons.TabIndex = 2
            '
            ' btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(20, 10)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(80, 30)
            Me.btnSave.TabIndex = 0
            Me.btnSave.Text = "Save"
            '
            ' btnSubmit
            '
            Me.btnSubmit.Location = New System.Drawing.Point(110, 10)
            Me.btnSubmit.Name = "btnSubmit"
            Me.btnSubmit.Size = New System.Drawing.Size(80, 30)
            Me.btnSubmit.TabIndex = 1
            Me.btnSubmit.Text = "Submit"
            '
            ' btnApprove
            '
            Me.btnApprove.Location = New System.Drawing.Point(200, 10)
            Me.btnApprove.Name = "btnApprove"
            Me.btnApprove.Size = New System.Drawing.Size(80, 30)
            Me.btnApprove.TabIndex = 2
            Me.btnApprove.Text = "Approve"
            '
            ' btnDeliver
            '
            Me.btnDeliver.Location = New System.Drawing.Point(290, 10)
            Me.btnDeliver.Name = "btnDeliver"
            Me.btnDeliver.Size = New System.Drawing.Size(80, 30)
            Me.btnDeliver.TabIndex = 3
            Me.btnDeliver.Text = "Deliver"
            '
            ' btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(380, 10)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(90, 30)
            Me.btnCancel.TabIndex = 4
            Me.btnCancel.Text = "Cancel Order"
            '
            ' btnClose
            '
            Me.btnClose.Location = New System.Drawing.Point(784, 10)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(80, 30)
            Me.btnClose.TabIndex = 5
            Me.btnClose.Text = "Close"
            '
            ' gridLines
            '
            Me.gridLines.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gridLines.Location = New System.Drawing.Point(0, 150)
            Me.gridLines.MainView = Me.gridViewLines
            Me.gridLines.Name = "gridLines"
            Me.gridLines.Size = New System.Drawing.Size(684, 411)
            Me.gridLines.TabIndex = 3
            Me.gridLines.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridViewLines})
            '
            ' gridViewLines
            '
            Me.gridViewLines.GridControl = Me.gridLines
            Me.gridViewLines.Name = "gridViewLines"
            Me.gridViewLines.OptionsView.ShowGroupPanel = False
            Me.gridViewLines.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom
            '
            ' OrderEditForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(884, 611)
            Me.Controls.Add(Me.gridLines)
            Me.Controls.Add(Me.pnlTotals)
            Me.Controls.Add(Me.pnlButtons)
            Me.Controls.Add(Me.pnlHeader)
            Me.Name = "OrderEditForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Order"
            CType(Me.pnlHeader, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            CType(Me.txtOrderNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtpOrderDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtpOrderDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtCustomerName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtCustomerContact.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboPaymentTerm.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtNotes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pnlTotals, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlTotals.ResumeLayout(False)
            Me.pnlTotals.PerformLayout()
            CType(Me.txtSubtotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pnlButtons, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlButtons.ResumeLayout(False)
            CType(Me.gridLines, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridViewLines, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents pnlHeader As DevExpress.XtraEditors.PanelControl
        Friend WithEvents lblOrderNumber As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblOrderDate As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblCustomerName As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblContact As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblPaymentTerm As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblNotes As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtOrderNumber As DevExpress.XtraEditors.TextEdit
        Friend WithEvents dtpOrderDate As DevExpress.XtraEditors.DateEdit
        Friend WithEvents txtCustomerName As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtCustomerContact As DevExpress.XtraEditors.TextEdit
        Friend WithEvents cboPaymentTerm As DevExpress.XtraEditors.LookUpEdit
        Friend WithEvents txtNotes As DevExpress.XtraEditors.MemoEdit
        Friend WithEvents pnlTotals As DevExpress.XtraEditors.PanelControl
        Friend WithEvents lblSubtotal As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblTax As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblTotal As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtSubtotal As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtTax As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtTotal As DevExpress.XtraEditors.TextEdit
        Friend WithEvents btnAddLine As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnRemoveLine As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents pnlButtons As DevExpress.XtraEditors.PanelControl
        Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnSubmit As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnApprove As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnDeliver As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents gridLines As DevExpress.XtraGrid.GridControl
        Friend WithEvents gridViewLines As DevExpress.XtraGrid.Views.Grid.GridView

    End Class
End Namespace
