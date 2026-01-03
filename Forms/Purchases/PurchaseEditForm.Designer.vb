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
            pnlHeader = New PanelControl()
            txtNotes = New MemoEdit()
            lblNotes = New LabelControl()
            cboSupplier = New LookUpEdit()
            lblSupplier = New LabelControl()
            dtpExpectedDate = New DateEdit()
            lblExpected = New LabelControl()
            dtpPurchaseDate = New DateEdit()
            lblPODate = New LabelControl()
            txtPurchaseNumber = New TextEdit()
            lblPONumber = New LabelControl()
            pnlTotals = New PanelControl()
            btnRemoveItem = New SimpleButton()
            btnAddItem = New SimpleButton()
            txtTotal = New TextEdit()
            lblTotal = New LabelControl()
            txtTax = New TextEdit()
            lblTax = New LabelControl()
            txtSubtotal = New TextEdit()
            lblSubtotal = New LabelControl()
            pnlButtons = New PanelControl()
            btnClose = New SimpleButton()
            btnCancel = New SimpleButton()
            btnReceive = New SimpleButton()
            btnApprove = New SimpleButton()
            btnSave = New SimpleButton()
            gridItems = New DevExpress.XtraGrid.GridControl()
            gridViewItems = New DevExpress.XtraGrid.Views.Grid.GridView()
            CType(pnlHeader, ComponentModel.ISupportInitialize).BeginInit()
            pnlHeader.SuspendLayout()
            CType(txtNotes.Properties, ComponentModel.ISupportInitialize).BeginInit()
            CType(cboSupplier.Properties, ComponentModel.ISupportInitialize).BeginInit()
            CType(dtpExpectedDate.Properties, ComponentModel.ISupportInitialize).BeginInit()
            CType(dtpExpectedDate.Properties.CalendarTimeProperties, ComponentModel.ISupportInitialize).BeginInit()
            CType(dtpPurchaseDate.Properties, ComponentModel.ISupportInitialize).BeginInit()
            CType(dtpPurchaseDate.Properties.CalendarTimeProperties, ComponentModel.ISupportInitialize).BeginInit()
            CType(txtPurchaseNumber.Properties, ComponentModel.ISupportInitialize).BeginInit()
            CType(pnlTotals, ComponentModel.ISupportInitialize).BeginInit()
            pnlTotals.SuspendLayout()
            CType(txtTotal.Properties, ComponentModel.ISupportInitialize).BeginInit()
            CType(txtTax.Properties, ComponentModel.ISupportInitialize).BeginInit()
            CType(txtSubtotal.Properties, ComponentModel.ISupportInitialize).BeginInit()
            CType(pnlButtons, ComponentModel.ISupportInitialize).BeginInit()
            pnlButtons.SuspendLayout()
            CType(gridItems, ComponentModel.ISupportInitialize).BeginInit()
            CType(gridViewItems, ComponentModel.ISupportInitialize).BeginInit()
            SuspendLayout()
            ' 
            ' pnlHeader
            ' 
            pnlHeader.Controls.Add(txtNotes)
            pnlHeader.Controls.Add(lblNotes)
            pnlHeader.Controls.Add(cboSupplier)
            pnlHeader.Controls.Add(lblSupplier)
            pnlHeader.Controls.Add(dtpExpectedDate)
            pnlHeader.Controls.Add(lblExpected)
            pnlHeader.Controls.Add(dtpPurchaseDate)
            pnlHeader.Controls.Add(lblPODate)
            pnlHeader.Controls.Add(txtPurchaseNumber)
            pnlHeader.Controls.Add(lblPONumber)
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            pnlHeader.Location = New System.Drawing.Point(0, 0)
            pnlHeader.Name = "pnlHeader"
            pnlHeader.Size = New System.Drawing.Size(884, 130)
            pnlHeader.TabIndex = 0
            ' 
            ' txtNotes
            ' 
            txtNotes.Location = New System.Drawing.Point(100, 85)
            txtNotes.Name = "txtNotes"
            txtNotes.Size = New System.Drawing.Size(585, 40)
            txtNotes.TabIndex = 9
            ' 
            ' lblNotes
            ' 
            lblNotes.Location = New System.Drawing.Point(20, 88)
            lblNotes.Name = "lblNotes"
            lblNotes.Size = New System.Drawing.Size(32, 13)
            lblNotes.TabIndex = 8
            lblNotes.Text = "Notes:"
            ' 
            ' cboSupplier
            ' 
            cboSupplier.Location = New System.Drawing.Point(100, 50)
            cboSupplier.Name = "cboSupplier"
            cboSupplier.Properties.Buttons.AddRange(New Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            cboSupplier.Properties.DisplayMember = "Supplier_Name"
            cboSupplier.Properties.NullText = "[Select Supplier]"
            cboSupplier.Properties.ValueMember = "Supplier_ID"
            cboSupplier.Size = New System.Drawing.Size(300, 20)
            cboSupplier.TabIndex = 7
            ' 
            ' lblSupplier
            ' 
            lblSupplier.Location = New System.Drawing.Point(20, 53)
            lblSupplier.Name = "lblSupplier"
            lblSupplier.Size = New System.Drawing.Size(42, 13)
            lblSupplier.TabIndex = 6
            lblSupplier.Text = "Supplier:"
            ' 
            ' dtpExpectedDate
            ' 
            dtpExpectedDate.EditValue = Nothing
            dtpExpectedDate.Location = New System.Drawing.Point(565, 15)
            dtpExpectedDate.Name = "dtpExpectedDate"
            dtpExpectedDate.Properties.Buttons.AddRange(New Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            dtpExpectedDate.Properties.CalendarTimeProperties.Buttons.AddRange(New Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            dtpExpectedDate.Size = New System.Drawing.Size(120, 20)
            dtpExpectedDate.TabIndex = 5
            ' 
            ' lblExpected
            ' 
            lblExpected.Location = New System.Drawing.Point(500, 18)
            lblExpected.Name = "lblExpected"
            lblExpected.Size = New System.Drawing.Size(49, 13)
            lblExpected.TabIndex = 4
            lblExpected.Text = "Expected:"
            ' 
            ' dtpPurchaseDate
            ' 
            dtpPurchaseDate.EditValue = Nothing
            dtpPurchaseDate.Location = New System.Drawing.Point(340, 15)
            dtpPurchaseDate.Name = "dtpPurchaseDate"
            dtpPurchaseDate.Properties.Buttons.AddRange(New Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            dtpPurchaseDate.Properties.CalendarTimeProperties.Buttons.AddRange(New Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            dtpPurchaseDate.Size = New System.Drawing.Size(120, 20)
            dtpPurchaseDate.TabIndex = 3
            ' 
            ' lblPODate
            ' 
            lblPODate.Location = New System.Drawing.Point(280, 18)
            lblPODate.Name = "lblPODate"
            lblPODate.Size = New System.Drawing.Size(44, 13)
            lblPODate.TabIndex = 2
            lblPODate.Text = "PO Date:"
            ' 
            ' txtPurchaseNumber
            ' 
            txtPurchaseNumber.Location = New System.Drawing.Point(100, 15)
            txtPurchaseNumber.Name = "txtPurchaseNumber"
            txtPurchaseNumber.Properties.ReadOnly = True
            txtPurchaseNumber.Size = New System.Drawing.Size(150, 20)
            txtPurchaseNumber.TabIndex = 1
            ' 
            ' lblPONumber
            ' 
            lblPONumber.Location = New System.Drawing.Point(20, 18)
            lblPONumber.Name = "lblPONumber"
            lblPONumber.Size = New System.Drawing.Size(58, 13)
            lblPONumber.TabIndex = 0
            lblPONumber.Text = "PO Number:"
            ' 
            ' pnlTotals
            ' 
            pnlTotals.Controls.Add(btnRemoveItem)
            pnlTotals.Controls.Add(btnAddItem)
            pnlTotals.Controls.Add(txtTotal)
            pnlTotals.Controls.Add(lblTotal)
            pnlTotals.Controls.Add(txtTax)
            pnlTotals.Controls.Add(lblTax)
            pnlTotals.Controls.Add(txtSubtotal)
            pnlTotals.Controls.Add(lblSubtotal)
            pnlTotals.Dock = System.Windows.Forms.DockStyle.Right
            pnlTotals.Location = New System.Drawing.Point(684, 130)
            pnlTotals.Name = "pnlTotals"
            pnlTotals.Size = New System.Drawing.Size(200, 370)
            pnlTotals.TabIndex = 1
            ' 
            ' btnRemoveItem
            ' 
            btnRemoveItem.Location = New System.Drawing.Point(105, 130)
            btnRemoveItem.Name = "btnRemoveItem"
            btnRemoveItem.Size = New System.Drawing.Size(80, 25)
            btnRemoveItem.TabIndex = 7
            btnRemoveItem.Text = "Remove"
            ' 
            ' btnAddItem
            ' 
            btnAddItem.Location = New System.Drawing.Point(20, 130)
            btnAddItem.Name = "btnAddItem"
            btnAddItem.Size = New System.Drawing.Size(80, 25)
            btnAddItem.TabIndex = 6
            btnAddItem.Text = "Add Item"
            ' 
            ' txtTotal
            ' 
            txtTotal.Location = New System.Drawing.Point(90, 80)
            txtTotal.Name = "txtTotal"
            txtTotal.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold)
            txtTotal.Properties.Appearance.Options.UseFont = True
            txtTotal.Properties.DisplayFormat.FormatString = "C2"
            txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            txtTotal.Properties.ReadOnly = True
            txtTotal.Size = New System.Drawing.Size(90, 20)
            txtTotal.TabIndex = 5
            ' 
            ' lblTotal
            ' 
            lblTotal.Location = New System.Drawing.Point(20, 83)
            lblTotal.Name = "lblTotal"
            lblTotal.Size = New System.Drawing.Size(28, 13)
            lblTotal.TabIndex = 4
            lblTotal.Text = "Total:"
            ' 
            ' txtTax
            ' 
            txtTax.Location = New System.Drawing.Point(90, 50)
            txtTax.Name = "txtTax"
            txtTax.Properties.DisplayFormat.FormatString = "C2"
            txtTax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            txtTax.Properties.ReadOnly = True
            txtTax.Size = New System.Drawing.Size(90, 20)
            txtTax.TabIndex = 3
            ' 
            ' lblTax
            ' 
            lblTax.Location = New System.Drawing.Point(20, 53)
            lblTax.Name = "lblTax"
            lblTax.Size = New System.Drawing.Size(22, 13)
            lblTax.TabIndex = 2
            lblTax.Text = "Tax:"
            ' 
            ' txtSubtotal
            ' 
            txtSubtotal.Location = New System.Drawing.Point(90, 20)
            txtSubtotal.Name = "txtSubtotal"
            txtSubtotal.Properties.DisplayFormat.FormatString = "C2"
            txtSubtotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            txtSubtotal.Properties.ReadOnly = True
            txtSubtotal.Size = New System.Drawing.Size(90, 20)
            txtSubtotal.TabIndex = 1
            ' 
            ' lblSubtotal
            ' 
            lblSubtotal.Location = New System.Drawing.Point(20, 23)
            lblSubtotal.Name = "lblSubtotal"
            lblSubtotal.Size = New System.Drawing.Size(44, 13)
            lblSubtotal.TabIndex = 0
            lblSubtotal.Text = "Subtotal:"
            ' 
            ' pnlButtons
            ' 
            pnlButtons.Controls.Add(btnClose)
            pnlButtons.Controls.Add(btnCancel)
            pnlButtons.Controls.Add(btnReceive)
            pnlButtons.Controls.Add(btnApprove)
            pnlButtons.Controls.Add(btnSave)
            pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
            pnlButtons.Location = New System.Drawing.Point(0, 500)
            pnlButtons.Name = "pnlButtons"
            pnlButtons.Size = New System.Drawing.Size(884, 50)
            pnlButtons.TabIndex = 2
            ' 
            ' btnClose
            ' 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
            btnClose.Location = New System.Drawing.Point(784, 10)
            btnClose.Name = "btnClose"
            btnClose.Size = New System.Drawing.Size(80, 30)
            btnClose.TabIndex = 4
            btnClose.Text = "Close"
            ' 
            ' btnCancel
            ' 
            btnCancel.Location = New System.Drawing.Point(290, 10)
            btnCancel.Name = "btnCancel"
            btnCancel.Size = New System.Drawing.Size(80, 30)
            btnCancel.TabIndex = 3
            btnCancel.Text = "Cancel PO"
            ' 
            ' btnReceive
            ' 
            btnReceive.Location = New System.Drawing.Point(200, 10)
            btnReceive.Name = "btnReceive"
            btnReceive.Size = New System.Drawing.Size(80, 30)
            btnReceive.TabIndex = 2
            btnReceive.Text = "Receive"
            ' 
            ' btnApprove
            ' 
            btnApprove.Location = New System.Drawing.Point(110, 10)
            btnApprove.Name = "btnApprove"
            btnApprove.Size = New System.Drawing.Size(80, 30)
            btnApprove.TabIndex = 1
            btnApprove.Text = "Approve"
            ' 
            ' btnSave
            ' 
            btnSave.Location = New System.Drawing.Point(20, 10)
            btnSave.Name = "btnSave"
            btnSave.Size = New System.Drawing.Size(80, 30)
            btnSave.TabIndex = 0
            btnSave.Text = "Save"
            ' 
            ' gridItems
            ' 
            gridItems.Dock = System.Windows.Forms.DockStyle.Fill
            gridItems.Location = New System.Drawing.Point(0, 130)
            gridItems.MainView = gridViewItems
            gridItems.Name = "gridItems"
            gridItems.Size = New System.Drawing.Size(684, 370)
            gridItems.TabIndex = 3
            gridItems.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {gridViewItems})
            ' 
            ' gridViewItems
            ' 
            gridViewItems.GridControl = gridItems
            gridViewItems.Name = "gridViewItems"
            gridViewItems.OptionsView.ShowGroupPanel = False
            ' 
            ' PurchaseEditForm
            ' 
            AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            ClientSize = New System.Drawing.Size(884, 550)
            Controls.Add(gridItems)
            Controls.Add(pnlTotals)
            Controls.Add(pnlButtons)
            Controls.Add(pnlHeader)
            Name = "PurchaseEditForm"
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "Purchase Order"
            CType(pnlHeader, ComponentModel.ISupportInitialize).EndInit()
            pnlHeader.ResumeLayout(False)
            pnlHeader.PerformLayout()
            CType(txtNotes.Properties, ComponentModel.ISupportInitialize).EndInit()
            CType(cboSupplier.Properties, ComponentModel.ISupportInitialize).EndInit()
            CType(dtpExpectedDate.Properties.CalendarTimeProperties, ComponentModel.ISupportInitialize).EndInit()
            CType(dtpExpectedDate.Properties, ComponentModel.ISupportInitialize).EndInit()
            CType(dtpPurchaseDate.Properties.CalendarTimeProperties, ComponentModel.ISupportInitialize).EndInit()
            CType(dtpPurchaseDate.Properties, ComponentModel.ISupportInitialize).EndInit()
            CType(txtPurchaseNumber.Properties, ComponentModel.ISupportInitialize).EndInit()
            CType(pnlTotals, ComponentModel.ISupportInitialize).EndInit()
            pnlTotals.ResumeLayout(False)
            pnlTotals.PerformLayout()
            CType(txtTotal.Properties, ComponentModel.ISupportInitialize).EndInit()
            CType(txtTax.Properties, ComponentModel.ISupportInitialize).EndInit()
            CType(txtSubtotal.Properties, ComponentModel.ISupportInitialize).EndInit()
            CType(pnlButtons, ComponentModel.ISupportInitialize).EndInit()
            pnlButtons.ResumeLayout(False)
            CType(gridItems, ComponentModel.ISupportInitialize).EndInit()
            CType(gridViewItems, ComponentModel.ISupportInitialize).EndInit()
            ResumeLayout(False)
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
