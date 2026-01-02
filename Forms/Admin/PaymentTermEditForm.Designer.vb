Imports DevExpress.XtraEditors

Namespace Forms.Admin
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PaymentTermEditForm
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
            Me.lblCode = New DevExpress.XtraEditors.LabelControl()
            Me.lblDescription = New DevExpress.XtraEditors.LabelControl()
            Me.lblDaysDue = New DevExpress.XtraEditors.LabelControl()
            Me.lblDiscountPercent = New DevExpress.XtraEditors.LabelControl()
            Me.lblDiscountDays = New DevExpress.XtraEditors.LabelControl()
            Me.txtCode = New DevExpress.XtraEditors.TextEdit()
            Me.txtDescription = New DevExpress.XtraEditors.TextEdit()
            Me.txtDaysDue = New DevExpress.XtraEditors.SpinEdit()
            Me.txtDiscountPercent = New DevExpress.XtraEditors.SpinEdit()
            Me.txtDiscountDays = New DevExpress.XtraEditors.SpinEdit()
            Me.chkActive = New DevExpress.XtraEditors.CheckEdit()
            Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
            Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
            CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtDaysDue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtDiscountPercent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtDiscountDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            ' lblCode
            '
            Me.lblCode.Location = New System.Drawing.Point(20, 23)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(28, 13)
            Me.lblCode.TabIndex = 0
            Me.lblCode.Text = "Code:"
            '
            ' lblDescription
            '
            Me.lblDescription.Location = New System.Drawing.Point(20, 58)
            Me.lblDescription.Name = "lblDescription"
            Me.lblDescription.Size = New System.Drawing.Size(57, 13)
            Me.lblDescription.TabIndex = 1
            Me.lblDescription.Text = "Description:"
            '
            ' lblDaysDue
            '
            Me.lblDaysDue.Location = New System.Drawing.Point(20, 93)
            Me.lblDaysDue.Name = "lblDaysDue"
            Me.lblDaysDue.Size = New System.Drawing.Size(49, 13)
            Me.lblDaysDue.TabIndex = 2
            Me.lblDaysDue.Text = "Days Due:"
            '
            ' lblDiscountPercent
            '
            Me.lblDiscountPercent.Location = New System.Drawing.Point(20, 128)
            Me.lblDiscountPercent.Name = "lblDiscountPercent"
            Me.lblDiscountPercent.Size = New System.Drawing.Size(55, 13)
            Me.lblDiscountPercent.TabIndex = 3
            Me.lblDiscountPercent.Text = "Discount %:"
            '
            ' lblDiscountDays
            '
            Me.lblDiscountDays.Location = New System.Drawing.Point(20, 163)
            Me.lblDiscountDays.Name = "lblDiscountDays"
            Me.lblDiscountDays.Size = New System.Drawing.Size(72, 13)
            Me.lblDiscountDays.TabIndex = 4
            Me.lblDiscountDays.Text = "Discount Days:"
            '
            ' txtCode
            '
            Me.txtCode.Location = New System.Drawing.Point(130, 20)
            Me.txtCode.Name = "txtCode"
            Me.txtCode.Size = New System.Drawing.Size(100, 20)
            Me.txtCode.TabIndex = 5
            '
            ' txtDescription
            '
            Me.txtDescription.Location = New System.Drawing.Point(130, 55)
            Me.txtDescription.Name = "txtDescription"
            Me.txtDescription.Size = New System.Drawing.Size(220, 20)
            Me.txtDescription.TabIndex = 6
            '
            ' txtDaysDue
            '
            Me.txtDaysDue.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.txtDaysDue.Location = New System.Drawing.Point(130, 90)
            Me.txtDaysDue.Name = "txtDaysDue"
            Me.txtDaysDue.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.txtDaysDue.Properties.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.txtDaysDue.Size = New System.Drawing.Size(80, 20)
            Me.txtDaysDue.TabIndex = 7
            '
            ' txtDiscountPercent
            '
            Me.txtDiscountPercent.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.txtDiscountPercent.Location = New System.Drawing.Point(130, 125)
            Me.txtDiscountPercent.Name = "txtDiscountPercent"
            Me.txtDiscountPercent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.txtDiscountPercent.Properties.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
            Me.txtDiscountPercent.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
            Me.txtDiscountPercent.Properties.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.txtDiscountPercent.Size = New System.Drawing.Size(80, 20)
            Me.txtDiscountPercent.TabIndex = 8
            '
            ' txtDiscountDays
            '
            Me.txtDiscountDays.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.txtDiscountDays.Location = New System.Drawing.Point(130, 160)
            Me.txtDiscountDays.Name = "txtDiscountDays"
            Me.txtDiscountDays.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.txtDiscountDays.Properties.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.txtDiscountDays.Size = New System.Drawing.Size(80, 20)
            Me.txtDiscountDays.TabIndex = 9
            '
            ' chkActive
            '
            Me.chkActive.Location = New System.Drawing.Point(130, 195)
            Me.chkActive.Name = "chkActive"
            Me.chkActive.Properties.Caption = "Active"
            Me.chkActive.Size = New System.Drawing.Size(75, 20)
            Me.chkActive.TabIndex = 10
            '
            ' btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(170, 235)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(80, 28)
            Me.btnSave.TabIndex = 11
            Me.btnSave.Text = "Save"
            '
            ' btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(260, 235)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(80, 28)
            Me.btnCancel.TabIndex = 12
            Me.btnCancel.Text = "Cancel"
            '
            ' PaymentTermEditForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(384, 281)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.chkActive)
            Me.Controls.Add(Me.txtDiscountDays)
            Me.Controls.Add(Me.txtDiscountPercent)
            Me.Controls.Add(Me.txtDaysDue)
            Me.Controls.Add(Me.txtDescription)
            Me.Controls.Add(Me.txtCode)
            Me.Controls.Add(Me.lblDiscountDays)
            Me.Controls.Add(Me.lblDiscountPercent)
            Me.Controls.Add(Me.lblDaysDue)
            Me.Controls.Add(Me.lblDescription)
            Me.Controls.Add(Me.lblCode)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "PaymentTermEditForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Payment Term"
            CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtDaysDue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtDiscountPercent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtDiscountDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Friend WithEvents lblCode As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblDescription As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblDaysDue As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblDiscountPercent As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblDiscountDays As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtCode As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtDescription As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtDaysDue As DevExpress.XtraEditors.SpinEdit
        Friend WithEvents txtDiscountPercent As DevExpress.XtraEditors.SpinEdit
        Friend WithEvents txtDiscountDays As DevExpress.XtraEditors.SpinEdit
        Friend WithEvents chkActive As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton

    End Class
End Namespace
