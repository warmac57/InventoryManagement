Imports DevExpress.XtraEditors

Namespace Forms.Admin
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UserEditForm
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
            Me.lblUsername = New DevExpress.XtraEditors.LabelControl()
            Me.lblPassword = New DevExpress.XtraEditors.LabelControl()
            Me.lblConfirmPassword = New DevExpress.XtraEditors.LabelControl()
            Me.lblRole = New DevExpress.XtraEditors.LabelControl()
            Me.txtUsername = New DevExpress.XtraEditors.TextEdit()
            Me.txtPassword = New DevExpress.XtraEditors.TextEdit()
            Me.txtConfirmPassword = New DevExpress.XtraEditors.TextEdit()
            Me.cboRole = New DevExpress.XtraEditors.ComboBoxEdit()
            Me.chkActive = New DevExpress.XtraEditors.CheckEdit()
            Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
            Me.btnResetPassword = New DevExpress.XtraEditors.SimpleButton()
            Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
            CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtConfirmPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboRole.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            ' lblUsername
            '
            Me.lblUsername.Location = New System.Drawing.Point(20, 23)
            Me.lblUsername.Name = "lblUsername"
            Me.lblUsername.Size = New System.Drawing.Size(52, 13)
            Me.lblUsername.TabIndex = 0
            Me.lblUsername.Text = "Username:"
            '
            ' lblPassword
            '
            Me.lblPassword.Location = New System.Drawing.Point(20, 58)
            Me.lblPassword.Name = "lblPassword"
            Me.lblPassword.Size = New System.Drawing.Size(50, 13)
            Me.lblPassword.TabIndex = 1
            Me.lblPassword.Text = "Password:"
            '
            ' lblConfirmPassword
            '
            Me.lblConfirmPassword.Location = New System.Drawing.Point(20, 93)
            Me.lblConfirmPassword.Name = "lblConfirmPassword"
            Me.lblConfirmPassword.Size = New System.Drawing.Size(89, 13)
            Me.lblConfirmPassword.TabIndex = 2
            Me.lblConfirmPassword.Text = "Confirm Password:"
            '
            ' lblRole
            '
            Me.lblRole.Location = New System.Drawing.Point(20, 128)
            Me.lblRole.Name = "lblRole"
            Me.lblRole.Size = New System.Drawing.Size(24, 13)
            Me.lblRole.TabIndex = 3
            Me.lblRole.Text = "Role:"
            '
            ' txtUsername
            '
            Me.txtUsername.Location = New System.Drawing.Point(130, 20)
            Me.txtUsername.Name = "txtUsername"
            Me.txtUsername.Size = New System.Drawing.Size(220, 20)
            Me.txtUsername.TabIndex = 4
            '
            ' txtPassword
            '
            Me.txtPassword.Location = New System.Drawing.Point(130, 55)
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.Properties.PasswordChar = "*"c
            Me.txtPassword.Size = New System.Drawing.Size(220, 20)
            Me.txtPassword.TabIndex = 5
            '
            ' txtConfirmPassword
            '
            Me.txtConfirmPassword.Location = New System.Drawing.Point(130, 90)
            Me.txtConfirmPassword.Name = "txtConfirmPassword"
            Me.txtConfirmPassword.Properties.PasswordChar = "*"c
            Me.txtConfirmPassword.Size = New System.Drawing.Size(220, 20)
            Me.txtConfirmPassword.TabIndex = 6
            '
            ' cboRole
            '
            Me.cboRole.Location = New System.Drawing.Point(130, 125)
            Me.cboRole.Name = "cboRole"
            Me.cboRole.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.cboRole.Properties.Items.AddRange(New Object() {"Administrator", "Manager", "Sales", "Warehouse", "Purchasing"})
            Me.cboRole.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            Me.cboRole.Size = New System.Drawing.Size(150, 20)
            Me.cboRole.TabIndex = 7
            '
            ' chkActive
            '
            Me.chkActive.Location = New System.Drawing.Point(130, 160)
            Me.chkActive.Name = "chkActive"
            Me.chkActive.Properties.Caption = "Active"
            Me.chkActive.Size = New System.Drawing.Size(75, 20)
            Me.chkActive.TabIndex = 8
            '
            ' btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(60, 210)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(80, 28)
            Me.btnSave.TabIndex = 9
            Me.btnSave.Text = "Save"
            '
            ' btnResetPassword
            '
            Me.btnResetPassword.Location = New System.Drawing.Point(150, 210)
            Me.btnResetPassword.Name = "btnResetPassword"
            Me.btnResetPassword.Size = New System.Drawing.Size(110, 28)
            Me.btnResetPassword.TabIndex = 10
            Me.btnResetPassword.Text = "Reset Password"
            '
            ' btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(270, 210)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(80, 28)
            Me.btnCancel.TabIndex = 11
            Me.btnCancel.Text = "Cancel"
            '
            ' UserEditForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(384, 261)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnResetPassword)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.chkActive)
            Me.Controls.Add(Me.cboRole)
            Me.Controls.Add(Me.txtConfirmPassword)
            Me.Controls.Add(Me.txtPassword)
            Me.Controls.Add(Me.txtUsername)
            Me.Controls.Add(Me.lblRole)
            Me.Controls.Add(Me.lblConfirmPassword)
            Me.Controls.Add(Me.lblPassword)
            Me.Controls.Add(Me.lblUsername)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "UserEditForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "User"
            CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtConfirmPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboRole.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Friend WithEvents lblUsername As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblPassword As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblConfirmPassword As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblRole As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtUsername As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtPassword As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtConfirmPassword As DevExpress.XtraEditors.TextEdit
        Friend WithEvents cboRole As DevExpress.XtraEditors.ComboBoxEdit
        Friend WithEvents chkActive As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnResetPassword As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton

    End Class
End Namespace
