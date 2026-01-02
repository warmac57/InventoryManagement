Imports DevExpress.XtraEditors

Namespace Forms.Admin
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UnitOfMeasureEditForm
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
            Me.lblName = New DevExpress.XtraEditors.LabelControl()
            Me.lblFactor = New DevExpress.XtraEditors.LabelControl()
            Me.txtCode = New DevExpress.XtraEditors.TextEdit()
            Me.txtName = New DevExpress.XtraEditors.TextEdit()
            Me.txtFactor = New DevExpress.XtraEditors.SpinEdit()
            Me.chkActive = New DevExpress.XtraEditors.CheckEdit()
            Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
            Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
            CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtFactor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
            ' lblName
            '
            Me.lblName.Location = New System.Drawing.Point(20, 58)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(31, 13)
            Me.lblName.TabIndex = 1
            Me.lblName.Text = "Name:"
            '
            ' lblFactor
            '
            Me.lblFactor.Location = New System.Drawing.Point(20, 93)
            Me.lblFactor.Name = "lblFactor"
            Me.lblFactor.Size = New System.Drawing.Size(92, 13)
            Me.lblFactor.TabIndex = 2
            Me.lblFactor.Text = "Conversion Factor:"
            '
            ' txtCode
            '
            Me.txtCode.Location = New System.Drawing.Point(130, 20)
            Me.txtCode.Name = "txtCode"
            Me.txtCode.Size = New System.Drawing.Size(80, 20)
            Me.txtCode.TabIndex = 3
            '
            ' txtName
            '
            Me.txtName.Location = New System.Drawing.Point(130, 55)
            Me.txtName.Name = "txtName"
            Me.txtName.Size = New System.Drawing.Size(170, 20)
            Me.txtName.TabIndex = 4
            '
            ' txtFactor
            '
            Me.txtFactor.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.txtFactor.Location = New System.Drawing.Point(130, 90)
            Me.txtFactor.Name = "txtFactor"
            Me.txtFactor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.txtFactor.Properties.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
            Me.txtFactor.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 393216})
            Me.txtFactor.Size = New System.Drawing.Size(100, 20)
            Me.txtFactor.TabIndex = 5
            '
            ' chkActive
            '
            Me.chkActive.Location = New System.Drawing.Point(130, 125)
            Me.chkActive.Name = "chkActive"
            Me.chkActive.Properties.Caption = "Active"
            Me.chkActive.Size = New System.Drawing.Size(75, 20)
            Me.chkActive.TabIndex = 6
            '
            ' btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(120, 170)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(80, 28)
            Me.btnSave.TabIndex = 7
            Me.btnSave.Text = "Save"
            '
            ' btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(210, 170)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(80, 28)
            Me.btnCancel.TabIndex = 8
            Me.btnCancel.Text = "Cancel"
            '
            ' UnitOfMeasureEditForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(334, 211)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.chkActive)
            Me.Controls.Add(Me.txtFactor)
            Me.Controls.Add(Me.txtName)
            Me.Controls.Add(Me.txtCode)
            Me.Controls.Add(Me.lblFactor)
            Me.Controls.Add(Me.lblName)
            Me.Controls.Add(Me.lblCode)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "UnitOfMeasureEditForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Unit of Measure"
            CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtFactor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Friend WithEvents lblCode As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblName As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblFactor As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtCode As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtFactor As DevExpress.XtraEditors.SpinEdit
        Friend WithEvents chkActive As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton

    End Class
End Namespace
