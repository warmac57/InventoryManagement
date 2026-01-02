Imports DevExpress.XtraEditors

Namespace Forms.InventoryControl
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class InventoryCountForm
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
            Me.lblItem = New DevExpress.XtraEditors.LabelControl()
            Me.lblSystemQty = New DevExpress.XtraEditors.LabelControl()
            Me.lblCountedQty = New DevExpress.XtraEditors.LabelControl()
            Me.lblVariance = New DevExpress.XtraEditors.LabelControl()
            Me.lblVarianceValue = New DevExpress.XtraEditors.LabelControl()
            Me.lblNotes = New DevExpress.XtraEditors.LabelControl()
            Me.lblStatusLabel = New DevExpress.XtraEditors.LabelControl()
            Me.cboItem = New DevExpress.XtraEditors.LookUpEdit()
            Me.txtSystemQty = New DevExpress.XtraEditors.SpinEdit()
            Me.txtCountedQty = New DevExpress.XtraEditors.SpinEdit()
            Me.txtVariance = New DevExpress.XtraEditors.TextEdit()
            Me.txtVarianceValue = New DevExpress.XtraEditors.TextEdit()
            Me.txtNotes = New DevExpress.XtraEditors.MemoEdit()
            Me.lblStatus = New DevExpress.XtraEditors.LabelControl()
            Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
            Me.btnApply = New DevExpress.XtraEditors.SimpleButton()
            Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
            CType(Me.cboItem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtSystemQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtCountedQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtVariance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtVarianceValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtNotes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            ' lblItem
            '
            Me.lblItem.Location = New System.Drawing.Point(20, 23)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(24, 13)
            Me.lblItem.TabIndex = 0
            Me.lblItem.Text = "Item:"
            '
            ' lblSystemQty
            '
            Me.lblSystemQty.Location = New System.Drawing.Point(20, 58)
            Me.lblSystemQty.Name = "lblSystemQty"
            Me.lblSystemQty.Size = New System.Drawing.Size(83, 13)
            Me.lblSystemQty.TabIndex = 1
            Me.lblSystemQty.Text = "System Quantity:"
            '
            ' lblCountedQty
            '
            Me.lblCountedQty.Location = New System.Drawing.Point(20, 93)
            Me.lblCountedQty.Name = "lblCountedQty"
            Me.lblCountedQty.Size = New System.Drawing.Size(89, 13)
            Me.lblCountedQty.TabIndex = 2
            Me.lblCountedQty.Text = "Counted Quantity:"
            '
            ' lblVariance
            '
            Me.lblVariance.Location = New System.Drawing.Point(20, 128)
            Me.lblVariance.Name = "lblVariance"
            Me.lblVariance.Size = New System.Drawing.Size(46, 13)
            Me.lblVariance.TabIndex = 3
            Me.lblVariance.Text = "Variance:"
            '
            ' lblVarianceValue
            '
            Me.lblVarianceValue.Location = New System.Drawing.Point(20, 163)
            Me.lblVarianceValue.Name = "lblVarianceValue"
            Me.lblVarianceValue.Size = New System.Drawing.Size(74, 13)
            Me.lblVarianceValue.TabIndex = 4
            Me.lblVarianceValue.Text = "Variance Value:"
            '
            ' lblNotes
            '
            Me.lblNotes.Location = New System.Drawing.Point(20, 198)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(31, 13)
            Me.lblNotes.TabIndex = 5
            Me.lblNotes.Text = "Notes:"
            '
            ' lblStatusLabel
            '
            Me.lblStatusLabel.Location = New System.Drawing.Point(20, 273)
            Me.lblStatusLabel.Name = "lblStatusLabel"
            Me.lblStatusLabel.Size = New System.Drawing.Size(35, 13)
            Me.lblStatusLabel.TabIndex = 6
            Me.lblStatusLabel.Text = "Status:"
            '
            ' cboItem
            '
            Me.cboItem.Location = New System.Drawing.Point(130, 20)
            Me.cboItem.Name = "cboItem"
            Me.cboItem.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.cboItem.Properties.DisplayMember = "Item_Name"
            Me.cboItem.Properties.NullText = "[Select Item]"
            Me.cboItem.Properties.ValueMember = "Item_ID"
            Me.cboItem.Size = New System.Drawing.Size(280, 20)
            Me.cboItem.TabIndex = 7
            '
            ' txtSystemQty
            '
            Me.txtSystemQty.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.txtSystemQty.Location = New System.Drawing.Point(130, 55)
            Me.txtSystemQty.Name = "txtSystemQty"
            Me.txtSystemQty.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.txtSystemQty.Properties.ReadOnly = True
            Me.txtSystemQty.Size = New System.Drawing.Size(120, 20)
            Me.txtSystemQty.TabIndex = 8
            '
            ' txtCountedQty
            '
            Me.txtCountedQty.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.txtCountedQty.Location = New System.Drawing.Point(130, 90)
            Me.txtCountedQty.Name = "txtCountedQty"
            Me.txtCountedQty.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.txtCountedQty.Properties.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.txtCountedQty.Size = New System.Drawing.Size(120, 20)
            Me.txtCountedQty.TabIndex = 9
            '
            ' txtVariance
            '
            Me.txtVariance.Location = New System.Drawing.Point(130, 125)
            Me.txtVariance.Name = "txtVariance"
            Me.txtVariance.Properties.ReadOnly = True
            Me.txtVariance.Size = New System.Drawing.Size(120, 20)
            Me.txtVariance.TabIndex = 10
            '
            ' txtVarianceValue
            '
            Me.txtVarianceValue.Location = New System.Drawing.Point(130, 160)
            Me.txtVarianceValue.Name = "txtVarianceValue"
            Me.txtVarianceValue.Properties.DisplayFormat.FormatString = "C2"
            Me.txtVarianceValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.txtVarianceValue.Properties.ReadOnly = True
            Me.txtVarianceValue.Size = New System.Drawing.Size(120, 20)
            Me.txtVarianceValue.TabIndex = 11
            '
            ' txtNotes
            '
            Me.txtNotes.Location = New System.Drawing.Point(130, 195)
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.Size = New System.Drawing.Size(280, 60)
            Me.txtNotes.TabIndex = 12
            '
            ' lblStatus
            '
            Me.lblStatus.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.lblStatus.Appearance.Options.UseFont = True
            Me.lblStatus.Location = New System.Drawing.Point(130, 273)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(42, 13)
            Me.lblStatus.TabIndex = 13
            Me.lblStatus.Text = "Initiated"
            '
            ' btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(130, 313)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(80, 28)
            Me.btnSave.TabIndex = 14
            Me.btnSave.Text = "Save"
            '
            ' btnApply
            '
            Me.btnApply.Location = New System.Drawing.Point(220, 313)
            Me.btnApply.Name = "btnApply"
            Me.btnApply.Size = New System.Drawing.Size(90, 28)
            Me.btnApply.TabIndex = 15
            Me.btnApply.Text = "Apply Count"
            '
            ' btnClose
            '
            Me.btnClose.Location = New System.Drawing.Point(320, 313)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(80, 28)
            Me.btnClose.TabIndex = 16
            Me.btnClose.Text = "Close"
            '
            ' InventoryCountForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(434, 361)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.btnApply)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.lblStatus)
            Me.Controls.Add(Me.txtNotes)
            Me.Controls.Add(Me.txtVarianceValue)
            Me.Controls.Add(Me.txtVariance)
            Me.Controls.Add(Me.txtCountedQty)
            Me.Controls.Add(Me.txtSystemQty)
            Me.Controls.Add(Me.cboItem)
            Me.Controls.Add(Me.lblStatusLabel)
            Me.Controls.Add(Me.lblNotes)
            Me.Controls.Add(Me.lblVarianceValue)
            Me.Controls.Add(Me.lblVariance)
            Me.Controls.Add(Me.lblCountedQty)
            Me.Controls.Add(Me.lblSystemQty)
            Me.Controls.Add(Me.lblItem)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "InventoryCountForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Inventory Count"
            CType(Me.cboItem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtSystemQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtCountedQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtVariance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtVarianceValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtNotes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Friend WithEvents lblItem As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblSystemQty As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblCountedQty As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblVariance As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblVarianceValue As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblNotes As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblStatusLabel As DevExpress.XtraEditors.LabelControl
        Friend WithEvents cboItem As DevExpress.XtraEditors.LookUpEdit
        Friend WithEvents txtSystemQty As DevExpress.XtraEditors.SpinEdit
        Friend WithEvents txtCountedQty As DevExpress.XtraEditors.SpinEdit
        Friend WithEvents txtVariance As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtVarianceValue As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtNotes As DevExpress.XtraEditors.MemoEdit
        Friend WithEvents lblStatus As DevExpress.XtraEditors.LabelControl
        Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnApply As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton

    End Class
End Namespace
