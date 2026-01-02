Imports DevExpress.XtraEditors

Namespace Forms.Catalog
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SupplierEditForm
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
            Me.lblContact = New DevExpress.XtraEditors.LabelControl()
            Me.lblEmail = New DevExpress.XtraEditors.LabelControl()
            Me.lblPhone = New DevExpress.XtraEditors.LabelControl()
            Me.lblAddress = New DevExpress.XtraEditors.LabelControl()
            Me.lblCity = New DevExpress.XtraEditors.LabelControl()
            Me.lblState = New DevExpress.XtraEditors.LabelControl()
            Me.lblZip = New DevExpress.XtraEditors.LabelControl()
            Me.lblCountry = New DevExpress.XtraEditors.LabelControl()
            Me.txtCode = New DevExpress.XtraEditors.TextEdit()
            Me.txtName = New DevExpress.XtraEditors.TextEdit()
            Me.txtContact = New DevExpress.XtraEditors.TextEdit()
            Me.txtEmail = New DevExpress.XtraEditors.TextEdit()
            Me.txtPhone = New DevExpress.XtraEditors.TextEdit()
            Me.txtAddress = New DevExpress.XtraEditors.MemoEdit()
            Me.txtCity = New DevExpress.XtraEditors.TextEdit()
            Me.txtState = New DevExpress.XtraEditors.TextEdit()
            Me.txtZip = New DevExpress.XtraEditors.TextEdit()
            Me.txtCountry = New DevExpress.XtraEditors.TextEdit()
            Me.chkActive = New DevExpress.XtraEditors.CheckEdit()
            Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
            Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
            CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtContact.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtPhone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtCity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtState.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtZip.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtCountry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            ' lblCode
            '
            Me.lblCode.Location = New System.Drawing.Point(20, 23)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(70, 13)
            Me.lblCode.TabIndex = 0
            Me.lblCode.Text = "Supplier Code:"
            '
            ' lblName
            '
            Me.lblName.Location = New System.Drawing.Point(20, 58)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(73, 13)
            Me.lblName.TabIndex = 1
            Me.lblName.Text = "Supplier Name:"
            '
            ' lblContact
            '
            Me.lblContact.Location = New System.Drawing.Point(20, 93)
            Me.lblContact.Name = "lblContact"
            Me.lblContact.Size = New System.Drawing.Size(77, 13)
            Me.lblContact.TabIndex = 2
            Me.lblContact.Text = "Contact Person:"
            '
            ' lblEmail
            '
            Me.lblEmail.Location = New System.Drawing.Point(20, 128)
            Me.lblEmail.Name = "lblEmail"
            Me.lblEmail.Size = New System.Drawing.Size(27, 13)
            Me.lblEmail.TabIndex = 3
            Me.lblEmail.Text = "Email:"
            '
            ' lblPhone
            '
            Me.lblPhone.Location = New System.Drawing.Point(260, 128)
            Me.lblPhone.Name = "lblPhone"
            Me.lblPhone.Size = New System.Drawing.Size(33, 13)
            Me.lblPhone.TabIndex = 4
            Me.lblPhone.Text = "Phone:"
            '
            ' lblAddress
            '
            Me.lblAddress.Location = New System.Drawing.Point(20, 163)
            Me.lblAddress.Name = "lblAddress"
            Me.lblAddress.Size = New System.Drawing.Size(42, 13)
            Me.lblAddress.TabIndex = 5
            Me.lblAddress.Text = "Address:"
            '
            ' lblCity
            '
            Me.lblCity.Location = New System.Drawing.Point(20, 238)
            Me.lblCity.Name = "lblCity"
            Me.lblCity.Size = New System.Drawing.Size(21, 13)
            Me.lblCity.TabIndex = 6
            Me.lblCity.Text = "City:"
            '
            ' lblState
            '
            Me.lblState.Location = New System.Drawing.Point(260, 238)
            Me.lblState.Name = "lblState"
            Me.lblState.Size = New System.Drawing.Size(29, 13)
            Me.lblState.TabIndex = 7
            Me.lblState.Text = "State:"
            '
            ' lblZip
            '
            Me.lblZip.Location = New System.Drawing.Point(20, 273)
            Me.lblZip.Name = "lblZip"
            Me.lblZip.Size = New System.Drawing.Size(46, 13)
            Me.lblZip.TabIndex = 8
            Me.lblZip.Text = "Zip Code:"
            '
            ' lblCountry
            '
            Me.lblCountry.Location = New System.Drawing.Point(260, 273)
            Me.lblCountry.Name = "lblCountry"
            Me.lblCountry.Size = New System.Drawing.Size(41, 13)
            Me.lblCountry.TabIndex = 9
            Me.lblCountry.Text = "Country:"
            '
            ' txtCode
            '
            Me.txtCode.Location = New System.Drawing.Point(120, 20)
            Me.txtCode.Name = "txtCode"
            Me.txtCode.Size = New System.Drawing.Size(120, 20)
            Me.txtCode.TabIndex = 10
            '
            ' txtName
            '
            Me.txtName.Location = New System.Drawing.Point(120, 55)
            Me.txtName.Name = "txtName"
            Me.txtName.Size = New System.Drawing.Size(330, 20)
            Me.txtName.TabIndex = 11
            '
            ' txtContact
            '
            Me.txtContact.Location = New System.Drawing.Point(120, 90)
            Me.txtContact.Name = "txtContact"
            Me.txtContact.Size = New System.Drawing.Size(200, 20)
            Me.txtContact.TabIndex = 12
            '
            ' txtEmail
            '
            Me.txtEmail.Location = New System.Drawing.Point(120, 125)
            Me.txtEmail.Name = "txtEmail"
            Me.txtEmail.Size = New System.Drawing.Size(130, 20)
            Me.txtEmail.TabIndex = 13
            '
            ' txtPhone
            '
            Me.txtPhone.Location = New System.Drawing.Point(310, 125)
            Me.txtPhone.Name = "txtPhone"
            Me.txtPhone.Size = New System.Drawing.Size(140, 20)
            Me.txtPhone.TabIndex = 14
            '
            ' txtAddress
            '
            Me.txtAddress.Location = New System.Drawing.Point(120, 160)
            Me.txtAddress.Name = "txtAddress"
            Me.txtAddress.Size = New System.Drawing.Size(330, 60)
            Me.txtAddress.TabIndex = 15
            '
            ' txtCity
            '
            Me.txtCity.Location = New System.Drawing.Point(120, 235)
            Me.txtCity.Name = "txtCity"
            Me.txtCity.Size = New System.Drawing.Size(130, 20)
            Me.txtCity.TabIndex = 16
            '
            ' txtState
            '
            Me.txtState.Location = New System.Drawing.Point(310, 235)
            Me.txtState.Name = "txtState"
            Me.txtState.Size = New System.Drawing.Size(140, 20)
            Me.txtState.TabIndex = 17
            '
            ' txtZip
            '
            Me.txtZip.Location = New System.Drawing.Point(120, 270)
            Me.txtZip.Name = "txtZip"
            Me.txtZip.Size = New System.Drawing.Size(100, 20)
            Me.txtZip.TabIndex = 18
            '
            ' txtCountry
            '
            Me.txtCountry.Location = New System.Drawing.Point(310, 270)
            Me.txtCountry.Name = "txtCountry"
            Me.txtCountry.Size = New System.Drawing.Size(140, 20)
            Me.txtCountry.TabIndex = 19
            '
            ' chkActive
            '
            Me.chkActive.Location = New System.Drawing.Point(120, 305)
            Me.chkActive.Name = "chkActive"
            Me.chkActive.Properties.Caption = "Active"
            Me.chkActive.Size = New System.Drawing.Size(75, 20)
            Me.chkActive.TabIndex = 20
            '
            ' btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(260, 350)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(80, 28)
            Me.btnSave.TabIndex = 21
            Me.btnSave.Text = "Save"
            '
            ' btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(350, 350)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(80, 28)
            Me.btnCancel.TabIndex = 22
            Me.btnCancel.Text = "Cancel"
            '
            ' SupplierEditForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(474, 391)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.chkActive)
            Me.Controls.Add(Me.txtCountry)
            Me.Controls.Add(Me.txtZip)
            Me.Controls.Add(Me.txtState)
            Me.Controls.Add(Me.txtCity)
            Me.Controls.Add(Me.txtAddress)
            Me.Controls.Add(Me.txtPhone)
            Me.Controls.Add(Me.txtEmail)
            Me.Controls.Add(Me.txtContact)
            Me.Controls.Add(Me.txtName)
            Me.Controls.Add(Me.txtCode)
            Me.Controls.Add(Me.lblCountry)
            Me.Controls.Add(Me.lblZip)
            Me.Controls.Add(Me.lblState)
            Me.Controls.Add(Me.lblCity)
            Me.Controls.Add(Me.lblAddress)
            Me.Controls.Add(Me.lblPhone)
            Me.Controls.Add(Me.lblEmail)
            Me.Controls.Add(Me.lblContact)
            Me.Controls.Add(Me.lblName)
            Me.Controls.Add(Me.lblCode)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "SupplierEditForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Supplier"
            CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtContact.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtPhone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtCity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtState.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtZip.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtCountry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Friend WithEvents lblCode As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblName As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblContact As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblEmail As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblPhone As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblAddress As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblCity As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblState As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblZip As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblCountry As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtCode As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtContact As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtEmail As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtPhone As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtAddress As DevExpress.XtraEditors.MemoEdit
        Friend WithEvents txtCity As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtState As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtZip As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtCountry As DevExpress.XtraEditors.TextEdit
        Friend WithEvents chkActive As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton

    End Class
End Namespace
