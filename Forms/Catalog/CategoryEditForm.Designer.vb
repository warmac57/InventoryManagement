Imports DevExpress.XtraEditors

Namespace Forms.Catalog
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CategoryEditForm
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
            Me.lblName = New DevExpress.XtraEditors.LabelControl()
            Me.lblParent = New DevExpress.XtraEditors.LabelControl()
            Me.lblDescription = New DevExpress.XtraEditors.LabelControl()
            Me.txtName = New DevExpress.XtraEditors.TextEdit()
            Me.cboParent = New DevExpress.XtraEditors.LookUpEdit()
            Me.txtDescription = New DevExpress.XtraEditors.MemoEdit()
            Me.chkActive = New DevExpress.XtraEditors.CheckEdit()
            Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
            Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
            CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboParent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            ' lblName
            '
            Me.lblName.Location = New System.Drawing.Point(20, 23)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(77, 13)
            Me.lblName.TabIndex = 0
            Me.lblName.Text = "Category Name:"
            '
            ' lblParent
            '
            Me.lblParent.Location = New System.Drawing.Point(20, 58)
            Me.lblParent.Name = "lblParent"
            Me.lblParent.Size = New System.Drawing.Size(82, 13)
            Me.lblParent.TabIndex = 1
            Me.lblParent.Text = "Parent Category:"
            '
            ' lblDescription
            '
            Me.lblDescription.Location = New System.Drawing.Point(20, 93)
            Me.lblDescription.Name = "lblDescription"
            Me.lblDescription.Size = New System.Drawing.Size(57, 13)
            Me.lblDescription.TabIndex = 2
            Me.lblDescription.Text = "Description:"
            '
            ' txtName
            '
            Me.txtName.Location = New System.Drawing.Point(130, 20)
            Me.txtName.Name = "txtName"
            Me.txtName.Size = New System.Drawing.Size(280, 20)
            Me.txtName.TabIndex = 3
            '
            ' cboParent
            '
            Me.cboParent.Location = New System.Drawing.Point(130, 55)
            Me.cboParent.Name = "cboParent"
            Me.cboParent.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
            Me.cboParent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.cboParent.Properties.DisplayMember = "Category_Name"
            Me.cboParent.Properties.NullText = "[None - Root Category]"
            Me.cboParent.Properties.ValueMember = "Category_ID"
            Me.cboParent.Size = New System.Drawing.Size(280, 20)
            Me.cboParent.TabIndex = 4
            '
            ' txtDescription
            '
            Me.txtDescription.Location = New System.Drawing.Point(130, 90)
            Me.txtDescription.Name = "txtDescription"
            Me.txtDescription.Size = New System.Drawing.Size(280, 80)
            Me.txtDescription.TabIndex = 5
            '
            ' chkActive
            '
            Me.chkActive.Location = New System.Drawing.Point(130, 185)
            Me.chkActive.Name = "chkActive"
            Me.chkActive.Properties.Caption = "Active"
            Me.chkActive.Size = New System.Drawing.Size(75, 20)
            Me.chkActive.TabIndex = 6
            '
            ' btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(230, 225)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(80, 28)
            Me.btnSave.TabIndex = 7
            Me.btnSave.Text = "Save"
            '
            ' btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(320, 225)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(80, 28)
            Me.btnCancel.TabIndex = 8
            Me.btnCancel.Text = "Cancel"
            '
            ' CategoryEditForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(434, 271)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.chkActive)
            Me.Controls.Add(Me.txtDescription)
            Me.Controls.Add(Me.cboParent)
            Me.Controls.Add(Me.txtName)
            Me.Controls.Add(Me.lblDescription)
            Me.Controls.Add(Me.lblParent)
            Me.Controls.Add(Me.lblName)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "CategoryEditForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Category"
            CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboParent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Friend WithEvents lblName As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblParent As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblDescription As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
        Friend WithEvents cboParent As DevExpress.XtraEditors.LookUpEdit
        Friend WithEvents txtDescription As DevExpress.XtraEditors.MemoEdit
        Friend WithEvents chkActive As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton

    End Class
End Namespace
