Imports DevExpress.XtraEditors

Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DashboardForm
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
            Me.components = New System.ComponentModel.Container()
            Me.pnlMain = New DevExpress.XtraEditors.PanelControl()
            Me.tileControl = New DevExpress.XtraEditors.TileControl()
            Me.tileGroupInventory = New DevExpress.XtraEditors.TileGroup()
            Me.tileInventoryValue = New DevExpress.XtraEditors.TileItem()
            Me.tileItemCount = New DevExpress.XtraEditors.TileItem()
            Me.tileLowStock = New DevExpress.XtraEditors.TileItem()
            Me.tileGroupOrders = New DevExpress.XtraEditors.TileGroup()
            Me.tilePendingOrders = New DevExpress.XtraEditors.TileItem()
            Me.tilePendingPurchases = New DevExpress.XtraEditors.TileItem()
            Me.tileTodaySales = New DevExpress.XtraEditors.TileItem()
            Me.pnlChart = New DevExpress.XtraEditors.PanelControl()
            Me.chartControl = New DevExpress.XtraCharts.ChartControl()
            Me.lblChartTitle = New DevExpress.XtraEditors.LabelControl()
            Me.pnlQuickActions = New DevExpress.XtraEditors.PanelControl()
            Me.btnNewOrder = New DevExpress.XtraEditors.SimpleButton()
            Me.btnNewPurchase = New DevExpress.XtraEditors.SimpleButton()
            Me.btnInventoryCount = New DevExpress.XtraEditors.SimpleButton()
            Me.btnReorderReport = New DevExpress.XtraEditors.SimpleButton()
            Me.lblQuickActions = New DevExpress.XtraEditors.LabelControl()
            Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
            CType(Me.pnlMain, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlMain.SuspendLayout()
            CType(Me.pnlChart, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlChart.SuspendLayout()
            CType(Me.chartControl, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pnlQuickActions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlQuickActions.SuspendLayout()
            Me.SuspendLayout()
            '
            ' pnlMain
            '
            Me.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.pnlMain.Controls.Add(Me.pnlChart)
            Me.pnlMain.Controls.Add(Me.pnlQuickActions)
            Me.pnlMain.Controls.Add(Me.tileControl)
            Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlMain.Location = New System.Drawing.Point(0, 0)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(900, 550)
            Me.pnlMain.TabIndex = 0
            '
            ' tileControl
            '
            Me.tileControl.AllowDrag = False
            Me.tileControl.AllowSelectedItem = False
            Me.tileControl.Dock = System.Windows.Forms.DockStyle.Top
            Me.tileControl.Groups.Add(Me.tileGroupInventory)
            Me.tileControl.Groups.Add(Me.tileGroupOrders)
            Me.tileControl.ItemSize = 140
            Me.tileControl.Location = New System.Drawing.Point(0, 0)
            Me.tileControl.Name = "tileControl"
            Me.tileControl.Padding = New System.Windows.Forms.Padding(20)
            Me.tileControl.Size = New System.Drawing.Size(900, 220)
            Me.tileControl.TabIndex = 0
            '
            ' tileGroupInventory
            '
            Me.tileGroupInventory.Items.Add(Me.tileInventoryValue)
            Me.tileGroupInventory.Items.Add(Me.tileItemCount)
            Me.tileGroupInventory.Items.Add(Me.tileLowStock)
            Me.tileGroupInventory.Name = "tileGroupInventory"
            Me.tileGroupInventory.Text = "Inventory"
            '
            ' tileInventoryValue
            '
            Me.tileInventoryValue.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(CType(52, Byte), CType(152, Byte), CType(219, Byte))
            Me.tileInventoryValue.AppearanceItem.Normal.Options.UseBackColor = True
            Me.tileInventoryValue.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
            Me.tileInventoryValue.Name = "tileInventoryValue"
            '
            ' tileItemCount
            '
            Me.tileItemCount.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(CType(46, Byte), CType(204, Byte), CType(113, Byte))
            Me.tileItemCount.AppearanceItem.Normal.Options.UseBackColor = True
            Me.tileItemCount.Name = "tileItemCount"
            '
            ' tileLowStock
            '
            Me.tileLowStock.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(CType(231, Byte), CType(76, Byte), CType(60, Byte))
            Me.tileLowStock.AppearanceItem.Normal.Options.UseBackColor = True
            Me.tileLowStock.Name = "tileLowStock"
            '
            ' tileGroupOrders
            '
            Me.tileGroupOrders.Items.Add(Me.tilePendingOrders)
            Me.tileGroupOrders.Items.Add(Me.tilePendingPurchases)
            Me.tileGroupOrders.Items.Add(Me.tileTodaySales)
            Me.tileGroupOrders.Name = "tileGroupOrders"
            Me.tileGroupOrders.Text = "Orders & Purchases"
            '
            ' tilePendingOrders
            '
            Me.tilePendingOrders.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(CType(155, Byte), CType(89, Byte), CType(182, Byte))
            Me.tilePendingOrders.AppearanceItem.Normal.Options.UseBackColor = True
            Me.tilePendingOrders.Name = "tilePendingOrders"
            '
            ' tilePendingPurchases
            '
            Me.tilePendingPurchases.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(CType(230, Byte), CType(126, Byte), CType(34, Byte))
            Me.tilePendingPurchases.AppearanceItem.Normal.Options.UseBackColor = True
            Me.tilePendingPurchases.Name = "tilePendingPurchases"
            '
            ' tileTodaySales
            '
            Me.tileTodaySales.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(CType(39, Byte), CType(174, Byte), CType(96, Byte))
            Me.tileTodaySales.AppearanceItem.Normal.Options.UseBackColor = True
            Me.tileTodaySales.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
            Me.tileTodaySales.Name = "tileTodaySales"
            '
            ' pnlChart
            '
            Me.pnlChart.Controls.Add(Me.chartControl)
            Me.pnlChart.Controls.Add(Me.lblChartTitle)
            Me.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlChart.Location = New System.Drawing.Point(0, 220)
            Me.pnlChart.Name = "pnlChart"
            Me.pnlChart.Padding = New System.Windows.Forms.Padding(20, 10, 20, 20)
            Me.pnlChart.Size = New System.Drawing.Size(700, 330)
            Me.pnlChart.TabIndex = 1
            '
            ' lblChartTitle
            '
            Me.lblChartTitle.Appearance.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblChartTitle.Appearance.Options.UseFont = True
            Me.lblChartTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblChartTitle.Location = New System.Drawing.Point(22, 12)
            Me.lblChartTitle.Name = "lblChartTitle"
            Me.lblChartTitle.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
            Me.lblChartTitle.Size = New System.Drawing.Size(156, 28)
            Me.lblChartTitle.TabIndex = 0
            Me.lblChartTitle.Text = "Stock Value by Category"
            '
            ' chartControl
            '
            Me.chartControl.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True
            Me.chartControl.Location = New System.Drawing.Point(22, 40)
            Me.chartControl.Name = "chartControl"
            Me.chartControl.Size = New System.Drawing.Size(656, 268)
            Me.chartControl.TabIndex = 1
            '
            ' pnlQuickActions
            '
            Me.pnlQuickActions.Controls.Add(Me.btnReorderReport)
            Me.pnlQuickActions.Controls.Add(Me.btnInventoryCount)
            Me.pnlQuickActions.Controls.Add(Me.btnNewPurchase)
            Me.pnlQuickActions.Controls.Add(Me.btnNewOrder)
            Me.pnlQuickActions.Controls.Add(Me.lblQuickActions)
            Me.pnlQuickActions.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnlQuickActions.Location = New System.Drawing.Point(700, 220)
            Me.pnlQuickActions.Name = "pnlQuickActions"
            Me.pnlQuickActions.Padding = New System.Windows.Forms.Padding(15)
            Me.pnlQuickActions.Size = New System.Drawing.Size(200, 330)
            Me.pnlQuickActions.TabIndex = 2
            '
            ' lblQuickActions
            '
            Me.lblQuickActions.Appearance.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblQuickActions.Appearance.Options.UseFont = True
            Me.lblQuickActions.Location = New System.Drawing.Point(20, 20)
            Me.lblQuickActions.Name = "lblQuickActions"
            Me.lblQuickActions.Size = New System.Drawing.Size(89, 18)
            Me.lblQuickActions.TabIndex = 0
            Me.lblQuickActions.Text = "Quick Actions"
            '
            ' btnNewOrder
            '
            Me.btnNewOrder.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
            Me.btnNewOrder.Appearance.Options.UseFont = True
            Me.btnNewOrder.Location = New System.Drawing.Point(20, 55)
            Me.btnNewOrder.Name = "btnNewOrder"
            Me.btnNewOrder.Size = New System.Drawing.Size(160, 35)
            Me.btnNewOrder.TabIndex = 1
            Me.btnNewOrder.Text = "New Order"
            '
            ' btnNewPurchase
            '
            Me.btnNewPurchase.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
            Me.btnNewPurchase.Appearance.Options.UseFont = True
            Me.btnNewPurchase.Location = New System.Drawing.Point(20, 100)
            Me.btnNewPurchase.Name = "btnNewPurchase"
            Me.btnNewPurchase.Size = New System.Drawing.Size(160, 35)
            Me.btnNewPurchase.TabIndex = 2
            Me.btnNewPurchase.Text = "New Purchase Order"
            '
            ' btnInventoryCount
            '
            Me.btnInventoryCount.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
            Me.btnInventoryCount.Appearance.Options.UseFont = True
            Me.btnInventoryCount.Location = New System.Drawing.Point(20, 145)
            Me.btnInventoryCount.Name = "btnInventoryCount"
            Me.btnInventoryCount.Size = New System.Drawing.Size(160, 35)
            Me.btnInventoryCount.TabIndex = 3
            Me.btnInventoryCount.Text = "Inventory Count"
            '
            ' btnReorderReport
            '
            Me.btnReorderReport.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
            Me.btnReorderReport.Appearance.Options.UseFont = True
            Me.btnReorderReport.Location = New System.Drawing.Point(20, 190)
            Me.btnReorderReport.Name = "btnReorderReport"
            Me.btnReorderReport.Size = New System.Drawing.Size(160, 35)
            Me.btnReorderReport.TabIndex = 4
            Me.btnReorderReport.Text = "Reorder Report"
            '
            ' tmrRefresh
            '
            Me.tmrRefresh.Interval = 60000
            '
            ' DashboardForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(900, 550)
            Me.Controls.Add(Me.pnlMain)
            Me.Name = "DashboardForm"
            Me.Text = "Dashboard"
            CType(Me.pnlMain, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlMain.ResumeLayout(False)
            CType(Me.pnlChart, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlChart.ResumeLayout(False)
            Me.pnlChart.PerformLayout()
            CType(Me.chartControl, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pnlQuickActions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlQuickActions.ResumeLayout(False)
            Me.pnlQuickActions.PerformLayout()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents pnlMain As DevExpress.XtraEditors.PanelControl
        Friend WithEvents tileControl As DevExpress.XtraEditors.TileControl
        Friend WithEvents tileGroupInventory As DevExpress.XtraEditors.TileGroup
        Friend WithEvents tileInventoryValue As DevExpress.XtraEditors.TileItem
        Friend WithEvents tileItemCount As DevExpress.XtraEditors.TileItem
        Friend WithEvents tileLowStock As DevExpress.XtraEditors.TileItem
        Friend WithEvents tileGroupOrders As DevExpress.XtraEditors.TileGroup
        Friend WithEvents tilePendingOrders As DevExpress.XtraEditors.TileItem
        Friend WithEvents tilePendingPurchases As DevExpress.XtraEditors.TileItem
        Friend WithEvents tileTodaySales As DevExpress.XtraEditors.TileItem
        Friend WithEvents pnlChart As DevExpress.XtraEditors.PanelControl
        Friend WithEvents lblChartTitle As DevExpress.XtraEditors.LabelControl
        Friend WithEvents chartControl As DevExpress.XtraCharts.ChartControl
        Friend WithEvents pnlQuickActions As DevExpress.XtraEditors.PanelControl
        Friend WithEvents lblQuickActions As DevExpress.XtraEditors.LabelControl
        Friend WithEvents btnNewOrder As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnNewPurchase As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnInventoryCount As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnReorderReport As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents tmrRefresh As System.Windows.Forms.Timer

    End Class
End Namespace
