Imports DevExpress.XtraEditors

Namespace Forms.Purchases
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PurchaseEditForm
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
            Me.lblPONumber = New DevExpress.XtraEditors.LabelControl()
            Me.txtPurchaseNumber = New DevExpress.XtraEditors.TextEdit()
            Me.lblPODate = New DevExpress.XtraEditors.LabelControl()
            Me.dtpPurchaseDate = New DevExpress.XtraEditors.DateEdit()
            Me.lblExpected = New DevExpress.XtraEditors.LabelControl()
            Me.dtpExpectedDate = New DevExpress.XtraEditors.DateEdit()
            Me.lblSupplier = New DevExpress.XtraEditors.LabelControl()
            Me.cboSupplier = New DevExpress.XtraEditors.LookUpEdit()
            Me.lblNotes = New DevExpress.XtraEditors.LabelControl()
            Me.txtNotes = New DevExpress.XtraEditors.MemoEdit()
            Me.pnlTotals = New DevExpress.XtraEditors.PanelControl()
            Me.lblSubtotal = New DevExpress.XtraEditors.LabelControl()
            Me.txtSubtotal = New DevExpress.XtraEditors.TextEdit()
            Me.lblTax = New DevExpress.XtraEditors.LabelControl()
            Me.txtTax = New DevExpress.XtraEditors.TextEdit()
            Me.lblTotal = New DevExpress.XtraEditors.LabelControl()
            Me.txtTotal = New DevExpress.XtraEditors.TextEdit()
            Me.btnAddItem = New DevExpress.XtraEditors.SimpleButton()
            Me.btnRemoveItem = New DevExpress.XtraEditors.SimpleButton()
            Me.pnlButtons = New DevExpress.XtraEditors.PanelControl()
            Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
            Me.btnApprove = New DevExpress.XtraEditors.SimpleButton()
            Me.btnReceive = New DevExpress.XtraEditors.SimpleButton()
            Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
            Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
            Me.gridItems = New DevExpress.XtraGrid.GridControl()
            Me.gridViewItems = New DevExpress.XtraGrid.Views.Grid.GridView()
            CType(Me.pnlHeader, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlHeader.SuspendLayout()
            CType(Me.txtPurchaseNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtpPurchaseDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtpPurchaseDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtpExpectedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtpExpectedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboSupplier.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtNotes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pnlTotals, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlTotals.SuspendLayout()
            CType(Me.txtSubtotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pnlButtons, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlButtons.SuspendLayout()
            CType(Me.gridItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridViewItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            ' pnlHeader
            '
            Me.pnlHeader.Controls.Add(Me.txtNotes)
            Me.pnlHeader.Controls.Add(Me.lblNotes)
            Me.pnlHeader.Controls.Add(Me.cboSupplier)
            Me.pnlHeader.Controls.Add(Me.lblSupplier)
            Me.pnlHeader.Controls.Add(Me.dtpExpectedDate)
            Me.pnlHeader.Controls.Add(Me.lblExpected)
            Me.pnlHeader.Controls.Add(Me.dtpPurchaseDate)
            Me.pnlHeader.Controls.Add(Me.lblPODate)
            Me.pnlHeader.Controls.Add(Me.txtPurchaseNumber)
            Me.pnlHeader.Controls.Add(Me.lblPONumber)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New System.Drawing.Size(884, 130)
            Me.pnlHeader.TabIndex = 0
            '
            ' lblPONumber
            '
            Me.lblPONumber.Location = New System.Drawing.Point(20, 18)
            Me.lblPONumber.Name = "lblPONumber"
            Me.lblPONumber.Size = New System.Drawing.Size(57, 13)
            Me.lblPONumber.TabIndex = 0
            Me.lblPONumber.Text = "PO Number:"
            '
            ' txtPurchaseNumber
            '
            Me.txtPurchaseNumber.Location = New System.Drawing.Point(100, 15)
            Me.txtPurchaseNumber.Name = "txtPurchaseNumber"
            Me.txtPurchaseNumber.Properties.ReadOnly = True
            Me.txtPurchaseNumber.Size = New System.Drawing.Size(150, 20)
            Me.txtPurchaseNumber.TabIndex = 1
            '
            ' lblPODate
            '
            Me.lblPODate.Location = New System.Drawing.Point(280, 18)
            Me.lblPODate.Name = "lblPODate"
            Me.lblPODate.Size = New System.Drawing.Size(44, 13)
            Me.lblPODate.TabIndex = 2
            Me.lblPODate.Text = "PO Date:"
            '
            ' dtpPurchaseDate
            '
            Me.dtpPurchaseDate.EditValue = Nothing
            Me.dtpPurchaseDate.Location = New System.Drawing.Point(340, 15)
            Me.dtpPurchaseDate.Name = "dtpPurchaseDate"
            Me.dtpPurchaseDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dtpPurchaseDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dtpPurchaseDate.Size = New System.Drawing.Size(120, 20)
            Me.dtpPurchaseDate.TabIndex = 3
            '
            ' lblExpected
            '
            Me.lblExpected.Location = New System.Drawing.Point(500, 18)
            Me.lblExpected.Name = "lblExpected"
            Me.lblExpected.Size = New System.Drawing.Size(50, 13)
            Me.lblExpected.TabIndex = 4
            Me.lblExpected.Text = "Expected:"
            '
            ' dtpExpectedDate
            '
            Me.dtpExpectedDate.EditValue = Nothing
            Me.dtpExpectedDate.Location = New System.Drawing.Point(565, 15)
            Me.dtpExpectedDate.Name = "dtpExpectedDate"
            Me.dtpExpectedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dtpExpectedDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dtpExpectedDate.Size = New System.Drawing.Size(120, 20)
            Me.dtpExpectedDate.TabIndex = 5
            '
            ' lblSupplier
            '
            Me.lblSupplier.Location = New System.Drawing.Point(20, 53)
            Me.lblSupplier.Name = "lblSupplier"
            Me.lblSupplier.Size = New System.Drawing.Size(42, 13)
            Me.lblSupplier.TabIndex = 6
            Me.lblSupplier.Text = "Supplier:"
            '
            ' cboSupplier
            '
            Me.cboSupplier.Location = New System.Drawing.Point(100, 50)
            Me.cboSupplier.Name = "cboSupplier"
            Me.cboSupplier.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.cboSupplier.Properties.DisplayMember = "Supplier_Name"
            Me.cboSupplier.Properties.NullText = "[Select Supplier]"
            Me.cboSupplier.Properties.ValueMember = "Supplier_ID"
            Me.cboSupplier.Size = New System.Drawing.Size(300, 20)
            Me.cboSupplier.TabIndex = 7
            '
            ' lblNotes
            '
            Me.lblNotes.Location = New System.Drawing.Point(20, 88)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(31, 13)
            Me.lblNotes.TabIndex = 8
            Me.lblNotes.Text = "Notes:"
            '
            ' txtNotes
            '
            Me.txtNotes.Location = New System.Drawing.Point(100, 85)
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.Size = New System.Drawing.Size(585, 40)
            Me.txtNotes.TabIndex = 9
            '
            ' pnlTotals
            '
            Me.pnlTotals.Controls.Add(Me.btnRemoveItem)
            Me.pnlTotals.Controls.Add(Me.btnAddItem)
            Me.pnlTotals.Controls.Add(Me.txtTotal)
            Me.pnlTotals.Controls.Add(Me.lblTotal)
            Me.pnlTotals.Controls.Add(Me.txtTax)
            Me.pnlTotals.Controls.Add(Me.lblTax)
            Me.pnlTotals.Controls.Add(Me.txtSubtotal)
            Me.pnlTotals.Controls.Add(Me.lblSubtotal)
            Me.pnlTotals.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnlTotals.Location = New System.Drawing.Point(684, 130)
            Me.pnlTotals.Name = "pnlTotals"
            Me.pnlTotals.Size = New System.Drawing.Size(200, 370)
            Me.pnlTotals.TabIndex = 1
            '
            ' lblSubtotal
            '
            Me.lblSubtotal.Location = New System.Drawing.Point(20, 23)
            Me.lblSubtotal.Name = "lblSubtotal"
            Me.lblSubtotal.Size = New System.Drawing.Size(43, 13)
            Me.lblSubtotal.TabIndex = 0
            Me.lblSubtotal.Text = "Subtotal:"
            '
            ' txtSubtotal
            '
            Me.txtSubtotal.Location = New System.Drawing.Point(90, 20)
            Me.txtSubtotal.Name = "txtSubtotal"
            Me.txtSubtotal.Properties.DisplayFormat.FormatString = "C2"
            Me.txtSubtotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.txtSubtotal.Properties.ReadOnly = True
            Me.txtSubtotal.Size = New System.Drawing.Size(90, 20)
            Me.txtSubtotal.TabIndex = 1
            '
            ' lblTax
            '
            Me.lblTax.Location = New System.Drawing.Point(20, 53)
            Me.lblTax.Name = "lblTax"
            Me.lblTax.Size = New System.Drawing.Size(18, 13)
            Me.lblTax.TabIndex = 2
            Me.lblTax.Text = "Tax:"
            '
            ' txtTax
            '
            Me.txtTax.Location = New System.Drawing.Point(90, 50)
            Me.txtTax.Name = "txtTax"
            Me.txtTax.Properties.DisplayFormat.FormatString = "C2"
            Me.txtTax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.txtTax.Properties.ReadOnly = True
            Me.txtTax.Size = New System.Drawing.Size(90, 20)
            Me.txtTax.TabIndex = 3
            '
            ' lblTotal
            '
            Me.lblTotal.Location = New System.Drawing.Point(20, 83)
            Me.lblTotal.Name = "lblTotal"
            Me.lblTotal.Size = New System.Drawing.Size(27, 13)
            Me.lblTotal.TabIndex = 4
            Me.lblTotal.Text = "Total:"
            '
            ' txtTotal
            '
            Me.txtTotal.Location = New System.Drawing.Point(90, 80)
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.txtTotal.Properties.Appearance.Options.UseFont = True
            Me.txtTotal.Properties.DisplayFormat.FormatString = "C2"
            Me.txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.txtTotal.Properties.ReadOnly = True
            Me.txtTotal.Size = New System.Drawing.Size(90, 20)
            Me.txtTotal.TabIndex = 5
            '
            ' btnAddItem
            '
            Me.btnAddItem.Location = New System.Drawing.Point(20, 130)
            Me.btnAddItem.Name = "btnAddItem"
            Me.btnAddItem.Size = New System.Drawing.Size(80, 25)
            Me.btnAddItem.TabIndex = 6
            Me.btnAddItem.Text = "Add Item"
            '
            ' btnRemoveItem
            '
            Me.btnRemoveItem.Location = New System.Drawing.Point(105, 130)
            Me.btnRemoveItem.Name = "btnRemoveItem"
            Me.btnRemoveItem.Size = New System.Drawing.Size(80, 25)
            Me.btnRemoveItem.TabIndex = 7
            Me.btnRemoveItem.Text = "Remove"
            '
            ' pnlButtons
            '
            Me.pnlButtons.Controls.Add(Me.btnClose)
            Me.pnlButtons.Controls.Add(Me.btnCancel)
            Me.pnlButtons.Controls.Add(Me.btnReceive)
            Me.pnlButtons.Controls.Add(Me.btnApprove)
            Me.pnlButtons.Controls.Add(Me.btnSave)
            Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlButtons.Location = New System.Drawing.Point(0, 500)
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
            ' btnApprove
            '
            Me.btnApprove.Location = New System.Drawing.Point(110, 10)
            Me.btnApprove.Name = "btnApprove"
            Me.btnApprove.Size = New System.Drawing.Size(80, 30)
            Me.btnApprove.TabIndex = 1
            Me.btnApprove.Text = "Approve"
            '
            ' btnReceive
            '
            Me.btnReceive.Location = New System.Drawing.Point(200, 10)
            Me.btnReceive.Name = "btnReceive"
            Me.btnReceive.Size = New System.Drawing.Size(80, 30)
            Me.btnReceive.TabIndex = 2
            Me.btnReceive.Text = "Receive"
            '
            ' btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(290, 10)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(80, 30)
            Me.btnCancel.TabIndex = 3
            Me.btnCancel.Text = "Cancel PO"
            '
            ' btnClose
            '
            Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnClose.Location = New System.Drawing.Point(784, 10)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(80, 30)
            Me.btnClose.TabIndex = 4
            Me.btnClose.Text = "Close"
            '
            ' gridItems
            '
            Me.gridItems.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gridItems.Location = New System.Drawing.Point(0, 130)
            Me.gridItems.MainView = Me.gridViewItems
            Me.gridItems.Name = "gridItems"
            Me.gridItems.Size = New System.Drawing.Size(684, 370)
            Me.gridItems.TabIndex = 3
            Me.gridItems.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridViewItems})
            '
            ' gridViewItems
            '
            Me.gridViewItems.GridControl = Me.gridItems
            Me.gridViewItems.Name = "gridViewItems"
            Me.gridViewItems.OptionsView.ShowGroupPanel = False
            '
            ' PurchaseEditForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(884, 550)
            Me.Controls.Add(Me.gridItems)
            Me.Controls.Add(Me.pnlTotals)
            Me.Controls.Add(Me.pnlButtons)
            Me.Controls.Add(Me.pnlHeader)
            Me.Name = "PurchaseEditForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Purchase Order"
            CType(Me.pnlHeader, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            CType(Me.txtPurchaseNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtpPurchaseDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtpPurchaseDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtpExpectedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtpExpectedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboSupplier.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtNotes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pnlTotals, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlTotals.ResumeLayout(False)
            Me.pnlTotals.PerformLayout()
            CType(Me.txtSubtotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pnlButtons, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlButtons.ResumeLayout(False)
            CType(Me.gridItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridViewItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents pnlHeader As DevExpress.XtraEditors.PanelControl
        Friend WithEvents lblPONumber As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtPurchaseNumber As DevExpress.XtraEditors.TextEdit
        Friend WithEvents lblPODate As DevExpress.XtraEditors.LabelControl
        Friend WithEvents dtpPurchaseDate As DevExpress.XtraEditors.DateEdit
        Friend WithEvents lblExpected As DevExpress.XtraEditors.LabelControl
        Friend WithEvents dtpExpectedDate As DevExpress.XtraEditors.DateEdit
        Friend WithEvents lblSupplier As DevExpress.XtraEditors.LabelControl
        Friend WithEvents cboSupplier As DevExpress.XtraEditors.LookUpEdit
        Friend WithEvents lblNotes As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtNotes As DevExpress.XtraEditors.MemoEdit
        Friend WithEvents pnlTotals As DevExpress.XtraEditors.PanelControl
        Friend WithEvents lblSubtotal As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtSubtotal As DevExpress.XtraEditors.TextEdit
        Friend WithEvents lblTax As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtTax As DevExpress.XtraEditors.TextEdit
        Friend WithEvents lblTotal As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtTotal As DevExpress.XtraEditors.TextEdit
        Friend WithEvents btnAddItem As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnRemoveItem As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents pnlButtons As DevExpress.XtraEditors.PanelControl
        Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnApprove As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnReceive As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents gridItems As DevExpress.XtraGrid.GridControl
        Friend WithEvents gridViewItems As DevExpress.XtraGrid.Views.Grid.GridView

    End Class
End Namespace
