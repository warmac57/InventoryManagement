Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports InventoryManagement.BusinessLogic
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Entities

Namespace Forms.Admin

    Partial Public Class UserEditForm

        Private _userId As Integer
        Private _user As User
        Private ReadOnly _authManager As New AuthenticationManager()
        Private ReadOnly _userDAO As New UserDAO()

        Public Sub New(Optional userId As Integer = 0)
            _userId = userId
            InitializeComponent()
            SetupForm()
            LoadData()
        End Sub

        Private Sub SetupForm()
            Me.Text = If(_userId = 0, "New User", "Edit User")
            chkActive.Checked = True
            btnResetPassword.Visible = _userId > 0

            If _userId > 0 Then
                txtPassword.Properties.NullText = "[Leave blank to keep current]"
                txtConfirmPassword.Properties.NullText = "[Leave blank to keep current]"
            End If
        End Sub

        Private Sub LoadData()
            If _userId > 0 Then
                _user = _userDAO.GetById(_userId)
                If _user IsNot Nothing Then
                    txtUsername.Text = _user.Username
                    cboRole.Text = _user.Role
                    chkActive.Checked = _user.Is_Active
                End If
            Else
                _user = New User()
            End If
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If String.IsNullOrEmpty(txtUsername.Text.Trim()) Then
                XtraMessageBox.Show("Username is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If _userId = 0 AndAlso String.IsNullOrEmpty(txtPassword.Text) Then
                XtraMessageBox.Show("Password is required for new users.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If Not String.IsNullOrEmpty(txtPassword.Text) AndAlso txtPassword.Text <> txtConfirmPassword.Text Then
                XtraMessageBox.Show("Passwords do not match.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                _user.Username = txtUsername.Text.Trim()
                _user.Role = cboRole.Text
                _user.Is_Active = chkActive.Checked

                If _userId = 0 Then
                    _authManager.CreateUser(_user.Username, txtPassword.Text, _user.Role)
                Else
                    _authManager.UpdateUser(_user)
                    If Not String.IsNullOrEmpty(txtPassword.Text) Then
                        _authManager.ResetPassword(_user.User_ID, txtPassword.Text)
                    End If
                End If

                Me.DialogResult = DialogResult.OK
                Me.Close()
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnResetPassword_Click(sender As Object, e As EventArgs) Handles btnResetPassword.Click
            Dim newPass = XtraInputBox.Show("Enter new password:", "Reset Password", "")
            If Not String.IsNullOrEmpty(newPass) Then
                Try
                    _authManager.ResetPassword(_userId, newPass)
                    XtraMessageBox.Show("Password reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub

    End Class

End Namespace
