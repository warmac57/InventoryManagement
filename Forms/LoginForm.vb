Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports InventoryManagement.BusinessLogic

Namespace Forms

    Partial Public Class LoginForm

        Private ReadOnly _authManager As New AuthenticationManager()

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
            Dim username = txtUsername.Text.Trim()
            Dim password = txtPassword.Text

            If String.IsNullOrEmpty(username) Then
                lblStatus.Text = "Please enter username"
                txtUsername.Focus()
                Return
            End If

            If String.IsNullOrEmpty(password) Then
                lblStatus.Text = "Please enter password"
                txtPassword.Focus()
                Return
            End If

            Try
                lblStatus.Text = "Authenticating..."
                Application.DoEvents()

                If _authManager.Login(username, password) Then
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    lblStatus.Text = "Invalid username or password"
                    txtPassword.Text = ""
                    txtPassword.Focus()
                End If
            Catch ex As Exception
                lblStatus.Text = "Connection error. Please check database."
                XtraMessageBox.Show("Error: " & ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles Me.Load
            txtUsername.Focus()
        End Sub

    End Class

End Namespace
