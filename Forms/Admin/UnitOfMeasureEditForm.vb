Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Entities

Namespace Forms.Admin

    Partial Public Class UnitOfMeasureEditForm

        Private _uomId As Integer
        Private _uom As UnitOfMeasure
        Private ReadOnly _uomDAO As New UnitOfMeasureDAO()

        Public Sub New(Optional uomId As Integer = 0)
            _uomId = uomId
            InitializeComponent()
            SetupForm()
            LoadData()
        End Sub

        Private Sub SetupForm()
            Me.Text = If(_uomId = 0, "New Unit of Measure", "Edit Unit of Measure")
            chkActive.Checked = True
            txtFactor.Value = 1D
        End Sub

        Private Sub LoadData()
            If _uomId > 0 Then
                _uom = _uomDAO.GetById(_uomId)
                If _uom IsNot Nothing Then
                    txtCode.Text = _uom.UoM_Code
                    txtName.Text = _uom.UoM_Name
                    txtFactor.Value = _uom.Conversion_Factor
                    chkActive.Checked = _uom.Is_Active
                End If
            Else
                _uom = New UnitOfMeasure()
            End If
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If String.IsNullOrEmpty(txtCode.Text.Trim()) OrElse String.IsNullOrEmpty(txtName.Text.Trim()) Then
                XtraMessageBox.Show("Code and Name are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                _uom.UoM_Code = txtCode.Text.Trim()
                _uom.UoM_Name = txtName.Text.Trim()
                _uom.Conversion_Factor = txtFactor.Value
                _uom.Is_Active = chkActive.Checked

                If _uomId = 0 Then
                    _uomDAO.Insert(_uom)
                Else
                    _uomDAO.Update(_uom)
                End If

                Me.DialogResult = DialogResult.OK
                Me.Close()
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub

    End Class

End Namespace
