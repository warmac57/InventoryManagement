Imports DevExpress.XtraEditors

Namespace Forms.Admin
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SettingsForm
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
            Me.lblCompanyName = New DevExpress.XtraEditors.LabelControl()
            Me.txtCompanyName = New DevExpress.XtraEditors.TextEdit()
            Me.lblTaxRate = New DevExpress.XtraEditors.LabelControl()
            Me.txtTaxRate = New DevExpress.XtraEditors.SpinEdit()
            Me.lblOrderPrefix = New DevExpress.XtraEditors.LabelControl()
            Me.txtOrderPrefix = New DevExpress.XtraEditors.TextEdit()
            Me.lblPurchasePrefix = New DevExpress.XtraEditors.LabelControl()
            Me.txtPurchasePrefix = New DevExpress.XtraEditors.TextEdit()
            Me.grpInventory = New DevExpress.XtraEditors.GroupControl()
            Me.chkNegativeStock = New DevExpress.XtraEditors.CheckEdit()
            Me.chkInStockCheck = New DevExpress.XtraEditors.CheckEdit()
            Me.chkMovingAverage = New DevExpress.XtraEditors.CheckEdit()
            Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
            Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
            CType(Me.txtCompanyName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtTaxRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtOrderPrefix.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtPurchasePrefix.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grpInventory, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpInventory.SuspendLayout()
            CType(Me.chkNegativeStock.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkInStockCheck.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkMovingAverage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            ' lblCompanyName
            '
            Me.lblCompanyName.Location = New System.Drawing.Point(20, 23)
            Me.lblCompanyName.Name = "lblCompanyName"
            Me.lblCompanyName.Size = New System.Drawing.Size(77, 13)
            Me.lblCompanyName.TabIndex = 0
            Me.lblCompanyName.Text = "Company Name:"
            '
            ' txtCompanyName
            '
            Me.txtCompanyName.Location = New System.Drawing.Point(160, 20)
            Me.txtCompanyName.Name = "txtCompanyName"
            Me.txtCompanyName.Size = New System.Drawing.Size(250, 20)
            Me.txtCompanyName.TabIndex = 1
            '
            ' lblTaxRate
            '
            Me.lblTaxRate.Location = New System.Drawing.Point(20, 63)
            Me.lblTaxRate.Name = "lblTaxRate"
            Me.lblTaxRate.Size = New System.Drawing.Size(65, 13)
            Me.lblTaxRate.TabIndex = 2
            Me.lblTaxRate.Text = "Tax Rate (%):"
            '
            ' txtTaxRate
            '
            Me.txtTaxRate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.txtTaxRate.Location = New System.Drawing.Point(160, 60)
            Me.txtTaxRate.Name = "txtTaxRate"
            Me.txtTaxRate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.txtTaxRate.Properties.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
            Me.txtTaxRate.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
            Me.txtTaxRate.Properties.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.txtTaxRate.Size = New System.Drawing.Size(100, 20)
            Me.txtTaxRate.TabIndex = 3
            '
            ' lblOrderPrefix
            '
            Me.lblOrderPrefix.Location = New System.Drawing.Point(20, 103)
            Me.lblOrderPrefix.Name = "lblOrderPrefix"
            Me.lblOrderPrefix.Size = New System.Drawing.Size(102, 13)
            Me.lblOrderPrefix.TabIndex = 4
            Me.lblOrderPrefix.Text = "Order Number Prefix:"
            '
            ' txtOrderPrefix
            '
            Me.txtOrderPrefix.Location = New System.Drawing.Point(160, 100)
            Me.txtOrderPrefix.Name = "txtOrderPrefix"
            Me.txtOrderPrefix.Size = New System.Drawing.Size(100, 20)
            Me.txtOrderPrefix.TabIndex = 5
            '
            ' lblPurchasePrefix
            '
            Me.lblPurchasePrefix.Location = New System.Drawing.Point(20, 143)
            Me.lblPurchasePrefix.Name = "lblPurchasePrefix"
            Me.lblPurchasePrefix.Size = New System.Drawing.Size(119, 13)
            Me.lblPurchasePrefix.TabIndex = 6
            Me.lblPurchasePrefix.Text = "Purchase Number Prefix:"
            '
            ' txtPurchasePrefix
            '
            Me.txtPurchasePrefix.Location = New System.Drawing.Point(160, 140)
            Me.txtPurchasePrefix.Name = "txtPurchasePrefix"
            Me.txtPurchasePrefix.Size = New System.Drawing.Size(100, 20)
            Me.txtPurchasePrefix.TabIndex = 7
            '
            ' grpInventory
            '
            Me.grpInventory.Controls.Add(Me.chkMovingAverage)
            Me.grpInventory.Controls.Add(Me.chkInStockCheck)
            Me.grpInventory.Controls.Add(Me.chkNegativeStock)
            Me.grpInventory.Location = New System.Drawing.Point(20, 180)
            Me.grpInventory.Name = "grpInventory"
            Me.grpInventory.Size = New System.Drawing.Size(390, 120)
            Me.grpInventory.TabIndex = 8
            Me.grpInventory.Text = "Inventory Settings"
            '
            ' chkNegativeStock
            '
            Me.chkNegativeStock.Location = New System.Drawing.Point(20, 30)
            Me.chkNegativeStock.Name = "chkNegativeStock"
            Me.chkNegativeStock.Properties.Caption = "Allow Negative Stock"
            Me.chkNegativeStock.Size = New System.Drawing.Size(200, 20)
            Me.chkNegativeStock.TabIndex = 0
            '
            ' chkInStockCheck
            '
            Me.chkInStockCheck.Location = New System.Drawing.Point(20, 55)
            Me.chkInStockCheck.Name = "chkInStockCheck"
            Me.chkInStockCheck.Properties.Caption = "Check Stock Availability Before Order"
            Me.chkInStockCheck.Size = New System.Drawing.Size(250, 20)
            Me.chkInStockCheck.TabIndex = 1
            '
            ' chkMovingAverage
            '
            Me.chkMovingAverage.Location = New System.Drawing.Point(20, 80)
            Me.chkMovingAverage.Name = "chkMovingAverage"
            Me.chkMovingAverage.Properties.Caption = "Use Moving Average for Item Costing"
            Me.chkMovingAverage.Size = New System.Drawing.Size(250, 20)
            Me.chkMovingAverage.TabIndex = 2
            '
            ' btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(200, 320)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(100, 28)
            Me.btnSave.TabIndex = 9
            Me.btnSave.Text = "Save Settings"
            '
            ' btnClose
            '
            Me.btnClose.Location = New System.Drawing.Point(310, 320)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(80, 28)
            Me.btnClose.TabIndex = 10
            Me.btnClose.Text = "Close"
            '
            ' SettingsForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(434, 361)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.grpInventory)
            Me.Controls.Add(Me.txtPurchasePrefix)
            Me.Controls.Add(Me.lblPurchasePrefix)
            Me.Controls.Add(Me.txtOrderPrefix)
            Me.Controls.Add(Me.lblOrderPrefix)
            Me.Controls.Add(Me.txtTaxRate)
            Me.Controls.Add(Me.lblTaxRate)
            Me.Controls.Add(Me.txtCompanyName)
            Me.Controls.Add(Me.lblCompanyName)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "SettingsForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Store Settings"
            CType(Me.txtCompanyName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtTaxRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtOrderPrefix.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtPurchasePrefix.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkNegativeStock.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkInStockCheck.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkMovingAverage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grpInventory, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpInventory.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Friend WithEvents lblCompanyName As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtCompanyName As DevExpress.XtraEditors.TextEdit
        Friend WithEvents lblTaxRate As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtTaxRate As DevExpress.XtraEditors.SpinEdit
        Friend WithEvents lblOrderPrefix As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtOrderPrefix As DevExpress.XtraEditors.TextEdit
        Friend WithEvents lblPurchasePrefix As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtPurchasePrefix As DevExpress.XtraEditors.TextEdit
        Friend WithEvents grpInventory As DevExpress.XtraEditors.GroupControl
        Friend WithEvents chkNegativeStock As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents chkInStockCheck As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents chkMovingAverage As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton

    End Class
End Namespace
