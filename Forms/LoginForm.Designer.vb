Imports DevExpress.XtraEditors

Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class LoginForm
        Inherits XtraForm

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
            Me.lblTitle = New DevExpress.XtraEditors.LabelControl()
            Me.lblUsername = New DevExpress.XtraEditors.LabelControl()
            Me.lblPassword = New DevExpress.XtraEditors.LabelControl()
            Me.lblStatus = New DevExpress.XtraEditors.LabelControl()
            Me.txtUsername = New DevExpress.XtraEditors.TextEdit()
            Me.txtPassword = New DevExpress.XtraEditors.TextEdit()
            Me.btnLogin = New DevExpress.XtraEditors.SimpleButton()
            Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
            CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            ' lblTitle
            '
            Me.lblTitle.Appearance.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.Appearance.Options.UseFont = True
            Me.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
            Me.lblTitle.Location = New System.Drawing.Point(50, 20)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(300, 30)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "Inventory Management System"
            '
            ' lblUsername
            '
            Me.lblUsername.Location = New System.Drawing.Point(50, 70)
            Me.lblUsername.Name = "lblUsername"
            Me.lblUsername.Size = New System.Drawing.Size(52, 13)
            Me.lblUsername.TabIndex = 1
            Me.lblUsername.Text = "Username:"
            '
            ' txtUsername
            '
            Me.txtUsername.Location = New System.Drawing.Point(50, 90)
            Me.txtUsername.Name = "txtUsername"
            Me.txtUsername.Size = New System.Drawing.Size(280, 20)
            Me.txtUsername.TabIndex = 2
            '
            ' lblPassword
            '
            Me.lblPassword.Location = New System.Drawing.Point(50, 125)
            Me.lblPassword.Name = "lblPassword"
            Me.lblPassword.Size = New System.Drawing.Size(50, 13)
            Me.lblPassword.TabIndex = 3
            Me.lblPassword.Text = "Password:"
            '
            ' txtPassword
            '
            Me.txtPassword.Location = New System.Drawing.Point(50, 145)
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.Properties.PasswordChar = "*"c
            Me.txtPassword.Size = New System.Drawing.Size(280, 20)
            Me.txtPassword.TabIndex = 4
            '
            ' lblStatus
            '
            Me.lblStatus.Appearance.ForeColor = System.Drawing.Color.Red
            Me.lblStatus.Appearance.Options.UseForeColor = True
            Me.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
            Me.lblStatus.Location = New System.Drawing.Point(50, 180)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(280, 20)
            Me.lblStatus.TabIndex = 5
            '
            ' btnLogin
            '
            Me.btnLogin.Location = New System.Drawing.Point(135, 210)
            Me.btnLogin.Name = "btnLogin"
            Me.btnLogin.Size = New System.Drawing.Size(100, 30)
            Me.btnLogin.TabIndex = 6
            Me.btnLogin.Text = "Login"
            '
            ' btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(245, 210)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(85, 30)
            Me.btnCancel.TabIndex = 7
            Me.btnCancel.Text = "Cancel"
            '
            ' LoginForm
            '
            Me.AcceptButton = Me.btnLogin
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(384, 261)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnLogin)
            Me.Controls.Add(Me.lblStatus)
            Me.Controls.Add(Me.txtPassword)
            Me.Controls.Add(Me.lblPassword)
            Me.Controls.Add(Me.txtUsername)
            Me.Controls.Add(Me.lblUsername)
            Me.Controls.Add(Me.lblTitle)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.KeyPreview = True
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "LoginForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Inventory Management - Login"
            CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Friend WithEvents lblTitle As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblUsername As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblPassword As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblStatus As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtUsername As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtPassword As DevExpress.XtraEditors.TextEdit
        Friend WithEvents btnLogin As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton

    End Class
End Namespace
