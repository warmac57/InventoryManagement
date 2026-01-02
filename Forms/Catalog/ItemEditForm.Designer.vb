Imports DevExpress.XtraEditors

Namespace Forms.Catalog
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ItemEditForm
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
            Me.lblDescription = New DevExpress.XtraEditors.LabelControl()
            Me.lblCategory = New DevExpress.XtraEditors.LabelControl()
            Me.lblUoM = New DevExpress.XtraEditors.LabelControl()
            Me.lblCost = New DevExpress.XtraEditors.LabelControl()
            Me.lblStock = New DevExpress.XtraEditors.LabelControl()
            Me.lblReorderLevel = New DevExpress.XtraEditors.LabelControl()
            Me.lblMinStock = New DevExpress.XtraEditors.LabelControl()
            Me.lblMaxStock = New DevExpress.XtraEditors.LabelControl()
            Me.txtCode = New DevExpress.XtraEditors.TextEdit()
            Me.txtName = New DevExpress.XtraEditors.TextEdit()
            Me.txtDescription = New DevExpress.XtraEditors.MemoEdit()
            Me.cboCategory = New DevExpress.XtraEditors.LookUpEdit()
            Me.cboUoM = New DevExpress.XtraEditors.LookUpEdit()
            Me.txtCost = New DevExpress.XtraEditors.SpinEdit()
            Me.txtStock = New DevExpress.XtraEditors.SpinEdit()
            Me.txtReorderLevel = New DevExpress.XtraEditors.SpinEdit()
            Me.txtMinStock = New DevExpress.XtraEditors.SpinEdit()
            Me.txtMaxStock = New DevExpress.XtraEditors.SpinEdit()
            Me.chkTrackInventory = New DevExpress.XtraEditors.CheckEdit()
            Me.chkActive = New DevExpress.XtraEditors.CheckEdit()
            Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
            Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
            CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboUoM.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtCost.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtStock.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtReorderLevel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtMinStock.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtMaxStock.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkTrackInventory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            ' lblCode
            '
            Me.lblCode.Location = New System.Drawing.Point(20, 23)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(52, 13)
            Me.lblCode.TabIndex = 0
            Me.lblCode.Text = "Item Code:"
            '
            ' lblName
            '
            Me.lblName.Location = New System.Drawing.Point(20, 58)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(55, 13)
            Me.lblName.TabIndex = 1
            Me.lblName.Text = "Item Name:"
            '
            ' lblDescription
            '
            Me.lblDescription.Location = New System.Drawing.Point(20, 93)
            Me.lblDescription.Name = "lblDescription"
            Me.lblDescription.Size = New System.Drawing.Size(57, 13)
            Me.lblDescription.TabIndex = 2
            Me.lblDescription.Text = "Description:"
            '
            ' lblCategory
            '
            Me.lblCategory.Location = New System.Drawing.Point(20, 168)
            Me.lblCategory.Name = "lblCategory"
            Me.lblCategory.Size = New System.Drawing.Size(49, 13)
            Me.lblCategory.TabIndex = 3
            Me.lblCategory.Text = "Category:"
            '
            ' lblUoM
            '
            Me.lblUoM.Location = New System.Drawing.Point(20, 203)
            Me.lblUoM.Name = "lblUoM"
            Me.lblUoM.Size = New System.Drawing.Size(81, 13)
            Me.lblUoM.TabIndex = 4
            Me.lblUoM.Text = "Unit of Measure:"
            '
            ' lblCost
            '
            Me.lblCost.Location = New System.Drawing.Point(20, 238)
            Me.lblCost.Name = "lblCost"
            Me.lblCost.Size = New System.Drawing.Size(63, 13)
            Me.lblCost.TabIndex = 5
            Me.lblCost.Text = "Current Cost:"
            '
            ' lblStock
            '
            Me.lblStock.Location = New System.Drawing.Point(20, 273)
            Me.lblStock.Name = "lblStock"
            Me.lblStock.Size = New System.Drawing.Size(74, 13)
            Me.lblStock.TabIndex = 6
            Me.lblStock.Text = "Stock Quantity:"
            '
            ' lblReorderLevel
            '
            Me.lblReorderLevel.Location = New System.Drawing.Point(20, 308)
            Me.lblReorderLevel.Name = "lblReorderLevel"
            Me.lblReorderLevel.Size = New System.Drawing.Size(69, 13)
            Me.lblReorderLevel.TabIndex = 7
            Me.lblReorderLevel.Text = "Reorder Level:"
            '
            ' lblMinStock
            '
            Me.lblMinStock.Location = New System.Drawing.Point(20, 343)
            Me.lblMinStock.Name = "lblMinStock"
            Me.lblMinStock.Size = New System.Drawing.Size(79, 13)
            Me.lblMinStock.TabIndex = 8
            Me.lblMinStock.Text = "Min Stock Level:"
            '
            ' lblMaxStock
            '
            Me.lblMaxStock.Location = New System.Drawing.Point(20, 378)
            Me.lblMaxStock.Name = "lblMaxStock"
            Me.lblMaxStock.Size = New System.Drawing.Size(82, 13)
            Me.lblMaxStock.TabIndex = 9
            Me.lblMaxStock.Text = "Max Stock Level:"
            '
            ' txtCode
            '
            Me.txtCode.Location = New System.Drawing.Point(140, 20)
            Me.txtCode.Name = "txtCode"
            Me.txtCode.Size = New System.Drawing.Size(300, 20)
            Me.txtCode.TabIndex = 10
            '
            ' txtName
            '
            Me.txtName.Location = New System.Drawing.Point(140, 55)
            Me.txtName.Name = "txtName"
            Me.txtName.Size = New System.Drawing.Size(300, 20)
            Me.txtName.TabIndex = 11
            '
            ' txtDescription
            '
            Me.txtDescription.Location = New System.Drawing.Point(140, 90)
            Me.txtDescription.Name = "txtDescription"
            Me.txtDescription.Size = New System.Drawing.Size(300, 60)
            Me.txtDescription.TabIndex = 12
            '
            ' cboCategory
            '
            Me.cboCategory.Location = New System.Drawing.Point(140, 165)
            Me.cboCategory.Name = "cboCategory"
            Me.cboCategory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.cboCategory.Properties.DisplayMember = "Category_Name"
            Me.cboCategory.Properties.NullText = "[Select Category]"
            Me.cboCategory.Properties.ValueMember = "Category_ID"
            Me.cboCategory.Size = New System.Drawing.Size(300, 20)
            Me.cboCategory.TabIndex = 13
            '
            ' cboUoM
            '
            Me.cboUoM.Location = New System.Drawing.Point(140, 200)
            Me.cboUoM.Name = "cboUoM"
            Me.cboUoM.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.cboUoM.Properties.DisplayMember = "UoM_Name"
            Me.cboUoM.Properties.NullText = "[Select Unit]"
            Me.cboUoM.Properties.ValueMember = "UoM_ID"
            Me.cboUoM.Size = New System.Drawing.Size(300, 20)
            Me.cboUoM.TabIndex = 14
            '
            ' txtCost
            '
            Me.txtCost.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.txtCost.Location = New System.Drawing.Point(140, 235)
            Me.txtCost.Name = "txtCost"
            Me.txtCost.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.txtCost.Properties.DisplayFormat.FormatString = "C2"
            Me.txtCost.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.txtCost.Properties.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
            Me.txtCost.Properties.MaxValue = New Decimal(New Integer() {-1, -1, -1, 0})
            Me.txtCost.Size = New System.Drawing.Size(120, 20)
            Me.txtCost.TabIndex = 15
            '
            ' txtStock
            '
            Me.txtStock.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.txtStock.Location = New System.Drawing.Point(140, 270)
            Me.txtStock.Name = "txtStock"
            Me.txtStock.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.txtStock.Properties.MaxValue = New Decimal(New Integer() {-1, -1, -1, 0})
            Me.txtStock.Size = New System.Drawing.Size(120, 20)
            Me.txtStock.TabIndex = 16
            '
            ' txtReorderLevel
            '
            Me.txtReorderLevel.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.txtReorderLevel.Location = New System.Drawing.Point(140, 305)
            Me.txtReorderLevel.Name = "txtReorderLevel"
            Me.txtReorderLevel.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.txtReorderLevel.Size = New System.Drawing.Size(120, 20)
            Me.txtReorderLevel.TabIndex = 17
            '
            ' txtMinStock
            '
            Me.txtMinStock.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.txtMinStock.Location = New System.Drawing.Point(140, 340)
            Me.txtMinStock.Name = "txtMinStock"
            Me.txtMinStock.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.txtMinStock.Size = New System.Drawing.Size(120, 20)
            Me.txtMinStock.TabIndex = 18
            '
            ' txtMaxStock
            '
            Me.txtMaxStock.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.txtMaxStock.Location = New System.Drawing.Point(140, 375)
            Me.txtMaxStock.Name = "txtMaxStock"
            Me.txtMaxStock.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.txtMaxStock.Size = New System.Drawing.Size(120, 20)
            Me.txtMaxStock.TabIndex = 19
            '
            ' chkTrackInventory
            '
            Me.chkTrackInventory.Location = New System.Drawing.Point(140, 410)
            Me.chkTrackInventory.Name = "chkTrackInventory"
            Me.chkTrackInventory.Properties.Caption = "Track Inventory"
            Me.chkTrackInventory.Size = New System.Drawing.Size(120, 20)
            Me.chkTrackInventory.TabIndex = 20
            '
            ' chkActive
            '
            Me.chkActive.Location = New System.Drawing.Point(140, 440)
            Me.chkActive.Name = "chkActive"
            Me.chkActive.Properties.Caption = "Active"
            Me.chkActive.Size = New System.Drawing.Size(75, 20)
            Me.chkActive.TabIndex = 21
            '
            ' btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(260, 480)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(80, 28)
            Me.btnSave.TabIndex = 22
            Me.btnSave.Text = "Save"
            '
            ' btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(350, 480)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(80, 28)
            Me.btnCancel.TabIndex = 23
            Me.btnCancel.Text = "Cancel"
            '
            ' ItemEditForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(464, 521)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.chkActive)
            Me.Controls.Add(Me.chkTrackInventory)
            Me.Controls.Add(Me.txtMaxStock)
            Me.Controls.Add(Me.txtMinStock)
            Me.Controls.Add(Me.txtReorderLevel)
            Me.Controls.Add(Me.txtStock)
            Me.Controls.Add(Me.txtCost)
            Me.Controls.Add(Me.cboUoM)
            Me.Controls.Add(Me.cboCategory)
            Me.Controls.Add(Me.txtDescription)
            Me.Controls.Add(Me.txtName)
            Me.Controls.Add(Me.txtCode)
            Me.Controls.Add(Me.lblMaxStock)
            Me.Controls.Add(Me.lblMinStock)
            Me.Controls.Add(Me.lblReorderLevel)
            Me.Controls.Add(Me.lblStock)
            Me.Controls.Add(Me.lblCost)
            Me.Controls.Add(Me.lblUoM)
            Me.Controls.Add(Me.lblCategory)
            Me.Controls.Add(Me.lblDescription)
            Me.Controls.Add(Me.lblName)
            Me.Controls.Add(Me.lblCode)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ItemEditForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Item"
            CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboUoM.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtCost.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtStock.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtReorderLevel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtMinStock.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtMaxStock.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkTrackInventory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Friend WithEvents lblCode As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblName As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblDescription As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblCategory As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblUoM As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblCost As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblStock As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblReorderLevel As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblMinStock As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblMaxStock As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtCode As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtDescription As DevExpress.XtraEditors.MemoEdit
        Friend WithEvents cboCategory As DevExpress.XtraEditors.LookUpEdit
        Friend WithEvents cboUoM As DevExpress.XtraEditors.LookUpEdit
        Friend WithEvents txtCost As DevExpress.XtraEditors.SpinEdit
        Friend WithEvents txtStock As DevExpress.XtraEditors.SpinEdit
        Friend WithEvents txtReorderLevel As DevExpress.XtraEditors.SpinEdit
        Friend WithEvents txtMinStock As DevExpress.XtraEditors.SpinEdit
        Friend WithEvents txtMaxStock As DevExpress.XtraEditors.SpinEdit
        Friend WithEvents chkTrackInventory As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents chkActive As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton

    End Class
End Namespace
