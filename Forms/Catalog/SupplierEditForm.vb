Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Entities

Namespace Forms.Catalog

    Partial Public Class SupplierEditForm

        Private _supplierId As Integer
        Private _supplier As Supplier
        Private ReadOnly _supplierDAO As New SupplierDAO()

        Public Sub New(Optional supplierId As Integer = 0)
            _supplierId = supplierId
            InitializeComponent()
            SetupForm()
            LoadData()
        End Sub

        Private Sub SetupForm()
            Me.Text = If(_supplierId = 0, "New Supplier", "Edit Supplier")
            chkActive.Checked = True
            txtCountry.Text = "USA"
        End Sub

        Private Sub LoadData()
            If _supplierId > 0 Then
                _supplier = _supplierDAO.GetById(_supplierId)
                If _supplier IsNot Nothing Then
                    txtCode.Text = _supplier.Supplier_Code
                    txtName.Text = _supplier.Supplier_Name
                    txtContact.Text = _supplier.Contact_Person
                    txtEmail.Text = _supplier.Email
                    txtPhone.Text = _supplier.Phone
                    txtAddress.Text = _supplier.Address
                    txtCity.Text = _supplier.City
                    txtState.Text = _supplier.State
                    txtZip.Text = _supplier.Zip_Code
                    txtCountry.Text = _supplier.Country
                    chkActive.Checked = _supplier.Is_Active
                End If
            Else
                _supplier = New Supplier()
            End If
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If String.IsNullOrEmpty(txtCode.Text.Trim()) OrElse String.IsNullOrEmpty(txtName.Text.Trim()) Then
                XtraMessageBox.Show("Supplier code and name are required.", "Validation",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                _supplier.Supplier_Code = txtCode.Text.Trim()
                _supplier.Supplier_Name = txtName.Text.Trim()
                _supplier.Contact_Person = txtContact.Text
                _supplier.Email = txtEmail.Text
                _supplier.Phone = txtPhone.Text
                _supplier.Address = txtAddress.Text
                _supplier.City = txtCity.Text
                _supplier.State = txtState.Text
                _supplier.Zip_Code = txtZip.Text
                _supplier.Country = txtCountry.Text
                _supplier.Is_Active = chkActive.Checked

                If _supplierId = 0 Then
                    _supplierDAO.Insert(_supplier)
                Else
                    _supplierDAO.Update(_supplier)
                End If

                Me.DialogResult = DialogResult.OK
                Me.Close()
            Catch ex As Exception
                XtraMessageBox.Show("Error saving supplier: " & ex.Message, "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub

    End Class

End Namespace
