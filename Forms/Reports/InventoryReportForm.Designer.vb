Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Namespace Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class InventoryReportForm
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
            Me.pnlToolbar = New DevExpress.XtraEditors.PanelControl()
            Me.btnRefresh = New DevExpress.XtraEditors.SimpleButton()
            Me.btnExport = New DevExpress.XtraEditors.SimpleButton()
            Me.lblTotalValue = New DevExpress.XtraEditors.LabelControl()
            Me.gridItems = New DevExpress.XtraGrid.GridControl()
            Me.gridView = New DevExpress.XtraGrid.Views.Grid.GridView()
            CType(Me.pnlToolbar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlToolbar.SuspendLayout()
            CType(Me.gridItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            ' pnlToolbar
            '
            Me.pnlToolbar.Controls.Add(Me.lblTotalValue)
            Me.pnlToolbar.Controls.Add(Me.btnExport)
            Me.pnlToolbar.Controls.Add(Me.btnRefresh)
            Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
            Me.pnlToolbar.Name = "pnlToolbar"
            Me.pnlToolbar.Size = New System.Drawing.Size(884, 45)
            Me.pnlToolbar.TabIndex = 0
            '
            ' btnRefresh
            '
            Me.btnRefresh.Location = New System.Drawing.Point(10, 8)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(80, 28)
            Me.btnRefresh.TabIndex = 0
            Me.btnRefresh.Text = "Refresh"
            '
            ' btnExport
            '
            Me.btnExport.Location = New System.Drawing.Point(100, 8)
            Me.btnExport.Name = "btnExport"
            Me.btnExport.Size = New System.Drawing.Size(110, 28)
            Me.btnExport.TabIndex = 1
            Me.btnExport.Text = "Export to Excel"
            '
            ' lblTotalValue
            '
            Me.lblTotalValue.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblTotalValue.Appearance.Options.UseFont = True
            Me.lblTotalValue.Location = New System.Drawing.Point(600, 14)
            Me.lblTotalValue.Name = "lblTotalValue"
            Me.lblTotalValue.Size = New System.Drawing.Size(0, 19)
            Me.lblTotalValue.TabIndex = 2
            '
            ' gridItems
            '
            Me.gridItems.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gridItems.Location = New System.Drawing.Point(0, 45)
            Me.gridItems.MainView = Me.gridView
            Me.gridItems.Name = "gridItems"
            Me.gridItems.Size = New System.Drawing.Size(884, 516)
            Me.gridItems.TabIndex = 1
            Me.gridItems.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridView})
            '
            ' gridView
            '
            Me.gridView.GridControl = Me.gridItems
            Me.gridView.Name = "gridView"
            Me.gridView.OptionsBehavior.Editable = False
            Me.gridView.OptionsView.ShowGroupPanel = False
            Me.gridView.OptionsView.ShowFooter = True
            '
            ' InventoryReportForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(884, 561)
            Me.Controls.Add(Me.gridItems)
            Me.Controls.Add(Me.pnlToolbar)
            Me.Name = "InventoryReportForm"
            Me.Text = "Inventory Valuation Report"
            CType(Me.pnlToolbar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlToolbar.ResumeLayout(False)
            Me.pnlToolbar.PerformLayout()
            CType(Me.gridItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents pnlToolbar As DevExpress.XtraEditors.PanelControl
        Friend WithEvents btnRefresh As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnExport As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents lblTotalValue As DevExpress.XtraEditors.LabelControl
        Friend WithEvents gridItems As DevExpress.XtraGrid.GridControl
        Friend WithEvents gridView As DevExpress.XtraGrid.Views.Grid.GridView

    End Class
End Namespace
