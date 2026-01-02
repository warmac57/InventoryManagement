Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports InventoryManagement.BusinessLogic
Imports InventoryManagement.Entities

Namespace Forms.Admin

    Partial Public Class UserListForm

        Private ReadOnly _authManager As New AuthenticationManager()
        Private _users As List(Of User)

        Public Sub New()
            InitializeComponent()
            SetupGrid()
        End Sub

        Private Sub SetupGrid()
            gridView.Columns.Clear()

            Dim colUsername As New GridColumn()
            colUsername.FieldName = "Username"
            colUsername.Caption = "Username"
            colUsername.Width = 150
            colUsername.Visible = True
            gridView.Columns.Add(colUsername)

            Dim colRole As New GridColumn()
            colRole.FieldName = "Role"
            colRole.Caption = "Role"
            colRole.Width = 120
            colRole.Visible = True
            gridView.Columns.Add(colRole)

            Dim colActive As New GridColumn()
            colActive.FieldName = "Is_Active"
            colActive.Caption = "Active"
            colActive.Width = 60
            colActive.Visible = True
            gridView.Columns.Add(colActive)

            Dim colCreated As New GridColumn()
            colCreated.FieldName = "Created_Date"
            colCreated.Caption = "Created"
            colCreated.Width = 120
            colCreated.Visible = True
            colCreated.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            colCreated.DisplayFormat.FormatString = "yyyy-MM-dd"
            gridView.Columns.Add(colCreated)

            Dim colLastLogin As New GridColumn()
            colLastLogin.FieldName = "Last_Login"
            colLastLogin.Caption = "Last Login"
            colLastLogin.Width = 140
            colLastLogin.Visible = True
            colLastLogin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            colLastLogin.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
            gridView.Columns.Add(colLastLogin)

            gridView.BestFitColumns()
        End Sub

        Private Sub LoadData()
            Try
                _users = _authManager.GetAllUsers()
                gridControl.DataSource = _users
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub AddNew()
            Dim frm As New UserEditForm()
            If frm.ShowDialog() = DialogResult.OK Then LoadData()
        End Sub

        Private Sub EditSelected()
            If gridView.FocusedRowHandle < 0 Then Return
            Dim user = TryCast(gridView.GetFocusedRow(), User)
            If user IsNot Nothing Then
                Dim frm As New UserEditForm(user.User_ID)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End If
        End Sub

        Private Sub DeleteSelected()
            If gridView.FocusedRowHandle < 0 Then Return
            Dim user = TryCast(gridView.GetFocusedRow(), User)
            If user IsNot Nothing Then
                If XtraMessageBox.Show($"Deactivate user '{user.Username}'?", "Confirm",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Try
                        _authManager.DeactivateUser(user.User_ID)
                        LoadData()
                    Catch ex As Exception
                        XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End Sub

        Private Sub UserListForm_Load(sender As Object, e As EventArgs) Handles Me.Load
            LoadData()
        End Sub

        Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            AddNew()
        End Sub

        Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
            EditSelected()
        End Sub

        Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
            DeleteSelected()
        End Sub

        Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
            LoadData()
        End Sub

        Private Sub gridView_DoubleClick(sender As Object, e As EventArgs) Handles gridView.DoubleClick
            EditSelected()
        End Sub

    End Class

End Namespace
