Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Forms.Orders
Imports InventoryManagement.Forms.Purchases
Imports InventoryManagement.Forms.InventoryControl
Imports InventoryManagement.Forms.Reports

Namespace Forms

    Partial Public Class DashboardForm

        Private ReadOnly _dashboardDAO As New DashboardDAO()

        Public Sub New()
            InitializeComponent()
            SetupTiles()
            SetupChart()
            LoadDashboardData()
            tmrRefresh.Start()
        End Sub

        Private Sub SetupTiles()
            ' Inventory Value Tile
            SetupTileElements(tileInventoryValue, "INVENTORY VALUE", "$0.00", "Total stock value")

            ' Item Count Tile
            SetupTileElements(tileItemCount, "ITEMS", "0", "Active items")

            ' Low Stock Tile
            SetupTileElements(tileLowStock, "LOW STOCK", "0", "Items need reorder")

            ' Pending Orders Tile
            SetupTileElements(tilePendingOrders, "PENDING ORDERS", "0", "Awaiting approval")

            ' Pending Purchases Tile
            SetupTileElements(tilePendingPurchases, "PENDING PO", "0", "Awaiting receipt")

            ' Today's Sales Tile
            SetupTileElements(tileTodaySales, "TODAY'S SALES", "$0.00", "Orders delivered today")
        End Sub

        Private Sub SetupTileElements(tile As TileItem, header As String, value As String, footer As String)
            tile.Elements.Clear()

            ' Header element
            Dim headerElement As New TileItemElement()
            headerElement.Text = header
            headerElement.TextAlignment = TileItemContentAlignment.TopLeft
            headerElement.Appearance.Normal.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            tile.Elements.Add(headerElement)

            ' Value element (large number)
            Dim valueElement As New TileItemElement()
            valueElement.Text = value
            valueElement.TextAlignment = TileItemContentAlignment.MiddleCenter
            valueElement.Appearance.Normal.Font = New Font("Segoe UI Light", 24, FontStyle.Regular)
            tile.Elements.Add(valueElement)

            ' Footer element
            Dim footerElement As New TileItemElement()
            footerElement.Text = footer
            footerElement.TextAlignment = TileItemContentAlignment.BottomLeft
            footerElement.Appearance.Normal.Font = New Font("Segoe UI", 8, FontStyle.Regular)
            tile.Elements.Add(footerElement)
        End Sub

        Private Sub UpdateTileValue(tile As TileItem, value As String)
            If tile.Elements.Count >= 2 Then
                tile.Elements(1).Text = value
            End If
        End Sub

        Private Sub SetupChart()
            chartControl.Series.Clear()

            Dim series As New Series("Stock Value", ViewType.Pie)
            series.Label.TextPattern = "{A}: {VP:P0}"
            chartControl.Series.Add(series)

            ' Configure pie chart
            Dim pieView = TryCast(series.View, PieSeriesView)
            If pieView IsNot Nothing Then
                pieView.ExplodeMode = PieExplodeMode.None
                pieView.RuntimeExploding = True
            End If

            ' Configure legend
            chartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True
            chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right
            chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.Center
        End Sub

        Private Sub LoadDashboardData()
            Try
                ' Load metrics
                Dim metrics = _dashboardDAO.GetDashboardMetrics()

                ' Update tiles
                UpdateTileValue(tileInventoryValue, metrics.TotalInventoryValue.ToString("C0"))
                UpdateTileValue(tileItemCount, metrics.TotalItemCount.ToString("N0"))
                UpdateTileValue(tileLowStock, metrics.LowStockCount.ToString("N0"))
                UpdateTileValue(tilePendingOrders, metrics.PendingOrderCount.ToString("N0"))
                UpdateTileValue(tilePendingPurchases, metrics.PendingPurchaseCount.ToString("N0"))
                UpdateTileValue(tileTodaySales, metrics.TodaySalesTotal.ToString("C0"))

                ' Update low stock tile color based on count
                If metrics.LowStockCount > 0 Then
                    tileLowStock.AppearanceItem.Normal.BackColor = Color.FromArgb(231, 76, 60) ' Red
                Else
                    tileLowStock.AppearanceItem.Normal.BackColor = Color.FromArgb(46, 204, 113) ' Green
                End If

                ' Load chart data
                LoadChartData()

            Catch ex As Exception
                XtraMessageBox.Show("Error loading dashboard: " & ex.Message, "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub LoadChartData()
            Try
                Dim categoryData = _dashboardDAO.GetStockValueByCategory()

                If chartControl.Series.Count > 0 Then
                    Dim series = chartControl.Series(0)
                    series.Points.Clear()

                    For Each item In categoryData
                        Dim point As New SeriesPoint(item.CategoryName, item.StockValue)
                        series.Points.Add(point)
                    Next
                End If

            Catch ex As Exception
                ' Silently fail for chart - dashboard still works
            End Try
        End Sub

        Private Sub tmrRefresh_Tick(sender As Object, e As EventArgs) Handles tmrRefresh.Tick
            LoadDashboardData()
        End Sub

        Private Sub btnNewOrder_Click(sender As Object, e As EventArgs) Handles btnNewOrder.Click
            Dim frm As New OrderEditForm()
            frm.MdiParent = Me.MdiParent
            frm.Show()
        End Sub

        Private Sub btnNewPurchase_Click(sender As Object, e As EventArgs) Handles btnNewPurchase.Click
            Dim frm As New PurchaseEditForm()
            frm.MdiParent = Me.MdiParent
            frm.Show()
        End Sub

        Private Sub btnInventoryCount_Click(sender As Object, e As EventArgs) Handles btnInventoryCount.Click
            Dim frm As New InventoryCountForm()
            frm.MdiParent = Me.MdiParent
            frm.Show()
        End Sub

        Private Sub btnReorderReport_Click(sender As Object, e As EventArgs) Handles btnReorderReport.Click
            Dim frm As New ReorderReportForm()
            frm.MdiParent = Me.MdiParent
            frm.Show()
        End Sub

        Private Sub tileInventoryValue_ItemClick(sender As Object, e As TileItemEventArgs) Handles tileInventoryValue.ItemClick
            ' Open inventory report
            Dim frm As New InventoryReportForm()
            frm.MdiParent = Me.MdiParent
            frm.Show()
        End Sub

        Private Sub tileLowStock_ItemClick(sender As Object, e As TileItemEventArgs) Handles tileLowStock.ItemClick
            ' Open reorder report
            Dim frm As New ReorderReportForm()
            frm.MdiParent = Me.MdiParent
            frm.Show()
        End Sub

        Private Sub tilePendingOrders_ItemClick(sender As Object, e As TileItemEventArgs) Handles tilePendingOrders.ItemClick
            ' Open order list
            Dim frm As New OrderListForm()
            frm.MdiParent = Me.MdiParent
            frm.Show()
        End Sub

        Private Sub tilePendingPurchases_ItemClick(sender As Object, e As TileItemEventArgs) Handles tilePendingPurchases.ItemClick
            ' Open purchase list
            Dim frm As New PurchaseListForm()
            frm.MdiParent = Me.MdiParent
            frm.Show()
        End Sub

        Private Sub DashboardForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            tmrRefresh.Stop()
        End Sub

    End Class

End Namespace
