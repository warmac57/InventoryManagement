Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.Utils.Svg
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraEditors
Imports InventoryManagement.Common
Imports InventoryManagement.Forms.Admin
Imports InventoryManagement.Forms.Catalog
Imports InventoryManagement.Forms.Orders
Imports InventoryManagement.Forms.Purchases
Imports InventoryManagement.Forms.InventoryControl
Imports InventoryManagement.Forms.Reports

Namespace Forms

    Partial Public Class MainForm

        Public Sub New()
            InitializeComponent()
            SetupForm()
            SetupRibbonContent()
            UpdateStatusBar()
            ApplyRolePermissions()
            LoadERDImage()
        End Sub

        Private Sub SetupForm()
            Me.Text = $"Inventory Management System - {AppSettings.Instance.CompanyName}"
            tmrDateTime.Start()
        End Sub

        Private Sub SetupRibbonContent()
            ' === HOME PAGE ===
            Dim grpDashboard As New RibbonPageGroup("Dashboard")
            pageHome.Groups.Add(grpDashboard)

            Dim btnDashboard = New BarButtonItem(ribbon.Manager, "Dashboard")
            btnDashboard.ImageOptions.SvgImage = GetSvgImage("dashboard")
            AddHandler btnDashboard.ItemClick, AddressOf Dashboard_Click
            grpDashboard.ItemLinks.Add(btnDashboard)

            ' === CATALOG PAGE ===
            Dim grpItems As New RibbonPageGroup("Items")
            pageCatalog.Groups.Add(grpItems)

            Dim btnItems = New BarButtonItem(ribbon.Manager, "Items")
            btnItems.ImageOptions.SvgImage = GetSvgImage("items")
            AddHandler btnItems.ItemClick, AddressOf Items_Click
            grpItems.ItemLinks.Add(btnItems)

            Dim btnCategories = New BarButtonItem(ribbon.Manager, "Categories")
            btnCategories.ImageOptions.SvgImage = GetSvgImage("categories")
            AddHandler btnCategories.ItemClick, AddressOf Categories_Click
            grpItems.ItemLinks.Add(btnCategories)

            Dim grpSuppliers As New RibbonPageGroup("Suppliers")
            pageCatalog.Groups.Add(grpSuppliers)

            Dim btnSuppliers = New BarButtonItem(ribbon.Manager, "Suppliers")
            btnSuppliers.ImageOptions.SvgImage = GetSvgImage("suppliers")
            AddHandler btnSuppliers.ItemClick, AddressOf Suppliers_Click
            grpSuppliers.ItemLinks.Add(btnSuppliers)

            ' === ORDERS PAGE ===
            Dim grpOrders As New RibbonPageGroup("Sales Orders")
            pageOrders.Groups.Add(grpOrders)

            Dim btnNewOrder = New BarButtonItem(ribbon.Manager, "New Order")
            btnNewOrder.ImageOptions.SvgImage = GetSvgImage("new_order")
            AddHandler btnNewOrder.ItemClick, AddressOf NewOrder_Click
            grpOrders.ItemLinks.Add(btnNewOrder)

            Dim btnViewOrders = New BarButtonItem(ribbon.Manager, "View Orders")
            btnViewOrders.ImageOptions.SvgImage = GetSvgImage("orders")
            AddHandler btnViewOrders.ItemClick, AddressOf ViewOrders_Click
            grpOrders.ItemLinks.Add(btnViewOrders)

            ' === PURCHASING PAGE ===
            Dim grpPurchases As New RibbonPageGroup("Purchase Orders")
            pagePurchasing.Groups.Add(grpPurchases)

            Dim btnNewPurchase = New BarButtonItem(ribbon.Manager, "New Purchase")
            btnNewPurchase.ImageOptions.SvgImage = GetSvgImage("new_purchase")
            AddHandler btnNewPurchase.ItemClick, AddressOf NewPurchase_Click
            grpPurchases.ItemLinks.Add(btnNewPurchase)

            Dim btnViewPurchases = New BarButtonItem(ribbon.Manager, "View Purchases")
            btnViewPurchases.ImageOptions.SvgImage = GetSvgImage("purchases")
            AddHandler btnViewPurchases.ItemClick, AddressOf ViewPurchases_Click
            grpPurchases.ItemLinks.Add(btnViewPurchases)

            Dim btnReceive = New BarButtonItem(ribbon.Manager, "Receive Items")
            btnReceive.ImageOptions.SvgImage = GetSvgImage("receive")
            AddHandler btnReceive.ItemClick, AddressOf ReceiveItems_Click
            grpPurchases.ItemLinks.Add(btnReceive)

            ' === INVENTORY PAGE ===
            Dim grpStock As New RibbonPageGroup("Stock Control")
            pageInventory.Groups.Add(grpStock)

            Dim btnStockLevels = New BarButtonItem(ribbon.Manager, "Stock Levels")
            btnStockLevels.ImageOptions.SvgImage = GetSvgImage("stock")
            AddHandler btnStockLevels.ItemClick, AddressOf StockLevels_Click
            grpStock.ItemLinks.Add(btnStockLevels)

            Dim btnInventoryCount = New BarButtonItem(ribbon.Manager, "Inventory Count")
            btnInventoryCount.ImageOptions.SvgImage = GetSvgImage("count")
            AddHandler btnInventoryCount.ItemClick, AddressOf InventoryCount_Click
            grpStock.ItemLinks.Add(btnInventoryCount)

            Dim btnStockHistory = New BarButtonItem(ribbon.Manager, "Stock History")
            btnStockHistory.ImageOptions.SvgImage = GetSvgImage("history")
            AddHandler btnStockHistory.ItemClick, AddressOf StockHistory_Click
            grpStock.ItemLinks.Add(btnStockHistory)

            ' === REPORTS PAGE ===
            Dim grpReports As New RibbonPageGroup("Reports")
            pageReports.Groups.Add(grpReports)

            Dim btnInventoryReport = New BarButtonItem(ribbon.Manager, "Inventory Report")
            btnInventoryReport.ImageOptions.SvgImage = GetSvgImage("report")
            AddHandler btnInventoryReport.ItemClick, AddressOf InventoryReport_Click
            grpReports.ItemLinks.Add(btnInventoryReport)

            Dim btnOrderReport = New BarButtonItem(ribbon.Manager, "Order Report")
            btnOrderReport.ImageOptions.SvgImage = GetSvgImage("order_report")
            AddHandler btnOrderReport.ItemClick, AddressOf OrderReport_Click
            grpReports.ItemLinks.Add(btnOrderReport)

            Dim btnReorderReport = New BarButtonItem(ribbon.Manager, "Reorder Report")
            btnReorderReport.ImageOptions.SvgImage = GetSvgImage("reorder_report")
            AddHandler btnReorderReport.ItemClick, AddressOf ReorderReport_Click
            grpReports.ItemLinks.Add(btnReorderReport)

            ' === ADMIN PAGE ===
            Dim grpSettings As New RibbonPageGroup("Settings")
            pageAdmin.Groups.Add(grpSettings)

            Dim btnSettings = New BarButtonItem(ribbon.Manager, "Store Settings")
            btnSettings.ImageOptions.SvgImage = GetSvgImage("settings")
            AddHandler btnSettings.ItemClick, AddressOf Settings_Click
            grpSettings.ItemLinks.Add(btnSettings)

            Dim btnUsers = New BarButtonItem(ribbon.Manager, "User Management")
            btnUsers.ImageOptions.SvgImage = GetSvgImage("users")
            AddHandler btnUsers.ItemClick, AddressOf Users_Click
            grpSettings.ItemLinks.Add(btnUsers)

            Dim btnPaymentTerms = New BarButtonItem(ribbon.Manager, "Payment Terms")
            btnPaymentTerms.ImageOptions.SvgImage = GetSvgImage("payment")
            AddHandler btnPaymentTerms.ItemClick, AddressOf PaymentTerms_Click
            grpSettings.ItemLinks.Add(btnPaymentTerms)

            Dim btnUoM = New BarButtonItem(ribbon.Manager, "Units of Measure")
            btnUoM.ImageOptions.SvgImage = GetSvgImage("uom")
            AddHandler btnUoM.ItemClick, AddressOf UnitsOfMeasure_Click
            grpSettings.ItemLinks.Add(btnUoM)

            Dim grpSystem As New RibbonPageGroup("System")
            pageAdmin.Groups.Add(grpSystem)

            Dim btnLogout = New BarButtonItem(ribbon.Manager, "Logout")
            btnLogout.ImageOptions.SvgImage = GetSvgImage("logout")
            AddHandler btnLogout.ItemClick, AddressOf Logout_Click
            grpSystem.ItemLinks.Add(btnLogout)

            Dim btnExit = New BarButtonItem(ribbon.Manager, "Exit")
            btnExit.ImageOptions.SvgImage = GetSvgImage("exit")
            AddHandler btnExit.ItemClick, AddressOf Exit_Click
            grpSystem.ItemLinks.Add(btnExit)
        End Sub

        Private Sub UpdateStatusBar()
            lblUser.Caption = $"User: {SessionManager.Instance.CurrentUser?.Username}"
            lblRole.Caption = $"Role: {SessionManager.Instance.CurrentUser?.Role}"
            lblDateTime.Caption = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        End Sub

        Private Sub ApplyRolePermissions()
            ' Hide admin page for non-admin users
            If Not SessionManager.Instance.IsAdmin Then
                pageAdmin.Visible = False
            End If

            ' Hide sales features for non-sales users
            If Not SessionManager.Instance.HasSalesAccess Then
                pageOrders.Visible = False
            End If

            ' Hide purchasing features for non-purchasing users
            If Not SessionManager.Instance.HasPurchasingAccess Then
                pagePurchasing.Visible = False
            End If
        End Sub

        Private Function GetSvgImage(name As String) As SvgImage
            ' Create colored icons for menu items
            Dim iconColor As Color
            Dim iconChar As String

            Select Case name
                Case "dashboard"
                    iconColor = Color.FromArgb(52, 152, 219)  ' Blue
                    iconChar = "H"
                Case "items"
                    iconColor = Color.FromArgb(46, 204, 113)  ' Green
                    iconChar = "I"
                Case "categories"
                    iconColor = Color.FromArgb(155, 89, 182)  ' Purple
                    iconChar = "C"
                Case "suppliers"
                    iconColor = Color.FromArgb(230, 126, 34)  ' Orange
                    iconChar = "S"
                Case "new_order"
                    iconColor = Color.FromArgb(46, 204, 113)  ' Green
                    iconChar = "+"
                Case "orders"
                    iconColor = Color.FromArgb(52, 152, 219)  ' Blue
                    iconChar = "O"
                Case "new_purchase"
                    iconColor = Color.FromArgb(46, 204, 113)  ' Green
                    iconChar = "+"
                Case "purchases"
                    iconColor = Color.FromArgb(155, 89, 182)  ' Purple
                    iconChar = "P"
                Case "receive"
                    iconColor = Color.FromArgb(39, 174, 96)   ' Dark Green
                    iconChar = "R"
                Case "stock"
                    iconColor = Color.FromArgb(52, 73, 94)    ' Dark Blue
                    iconChar = "S"
                Case "count"
                    iconColor = Color.FromArgb(241, 196, 15)  ' Yellow
                    iconChar = "#"
                Case "history"
                    iconColor = Color.FromArgb(149, 165, 166) ' Gray
                    iconChar = "H"
                Case "report", "order_report", "reorder_report"
                    iconColor = Color.FromArgb(52, 152, 219)  ' Blue
                    iconChar = "R"
                Case "settings"
                    iconColor = Color.FromArgb(149, 165, 166) ' Gray
                    iconChar = "S"
                Case "users"
                    iconColor = Color.FromArgb(52, 73, 94)    ' Dark Blue
                    iconChar = "U"
                Case "payment"
                    iconColor = Color.FromArgb(39, 174, 96)   ' Dark Green
                    iconChar = "$"
                Case "uom"
                    iconColor = Color.FromArgb(230, 126, 34)  ' Orange
                    iconChar = "M"
                Case "logout"
                    iconColor = Color.FromArgb(231, 76, 60)   ' Red
                    iconChar = "X"
                Case "exit"
                    iconColor = Color.FromArgb(192, 57, 43)   ' Dark Red
                    iconChar = "X"
                Case Else
                    iconColor = Color.FromArgb(127, 140, 141) ' Gray
                    iconChar = "?"
            End Select

            Return CreateSvgIcon(iconColor, iconChar)
        End Function

        Private Function CreateSvgIcon(bgColor As Color, letter As String) As SvgImage
            ' Create an SVG icon with a colored circle and letter
            Dim svgContent As String = $"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 32 32"">
  <circle cx=""16"" cy=""16"" r=""14"" fill=""#{bgColor.R:X2}{bgColor.G:X2}{bgColor.B:X2}""/>
  <text x=""16"" y=""21"" font-family=""Segoe UI, Arial"" font-size=""14"" font-weight=""bold"" fill=""white"" text-anchor=""middle"">{letter}</text>
</svg>"
            Try
                Using stream As New System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(svgContent))
                    Return SvgImage.FromStream(stream)
                End Using
            Catch
                Return Nothing
            End Try
        End Function

        Private Sub ShowChildForm(Of T As {Form, New})()
            ' Check if form is already open
            For Each frm As Form In Me.MdiChildren
                If TypeOf frm Is T Then
                    frm.Activate()
                    Return
                End If
            Next

            ' Create new instance
            Dim newForm As New T()
            newForm.MdiParent = Me
            newForm.Show()
        End Sub

        ' Event Handlers
        Private Sub Dashboard_Click(sender As Object, e As ItemClickEventArgs)
            ShowChildForm(Of DashboardForm)()
        End Sub

        Private Sub Items_Click(sender As Object, e As ItemClickEventArgs)
            ShowChildForm(Of ItemListForm)()
        End Sub

        Private Sub Categories_Click(sender As Object, e As ItemClickEventArgs)
            ShowChildForm(Of CategoryListForm)()
        End Sub

        Private Sub Suppliers_Click(sender As Object, e As ItemClickEventArgs)
            ShowChildForm(Of SupplierListForm)()
        End Sub

        Private Sub NewOrder_Click(sender As Object, e As ItemClickEventArgs)
            Dim frm As New OrderEditForm()
            frm.MdiParent = Me
            frm.Show()
        End Sub

        Private Sub ViewOrders_Click(sender As Object, e As ItemClickEventArgs)
            ShowChildForm(Of OrderListForm)()
        End Sub

        Private Sub NewPurchase_Click(sender As Object, e As ItemClickEventArgs)
            Dim frm As New PurchaseEditForm()
            frm.MdiParent = Me
            frm.Show()
        End Sub

        Private Sub ViewPurchases_Click(sender As Object, e As ItemClickEventArgs)
            ShowChildForm(Of PurchaseListForm)()
        End Sub

        Private Sub ReceiveItems_Click(sender As Object, e As ItemClickEventArgs)
            ShowChildForm(Of PurchaseListForm)()
        End Sub

        Private Sub StockLevels_Click(sender As Object, e As ItemClickEventArgs)
            ShowChildForm(Of StockLevelForm)()
        End Sub

        Private Sub InventoryCount_Click(sender As Object, e As ItemClickEventArgs)
            ShowChildForm(Of InventoryCountListForm)()
        End Sub

        Private Sub StockHistory_Click(sender As Object, e As ItemClickEventArgs)
            ShowChildForm(Of StockHistoryForm)()
        End Sub

        Private Sub InventoryReport_Click(sender As Object, e As ItemClickEventArgs)
            ShowChildForm(Of InventoryReportForm)()
        End Sub

        Private Sub OrderReport_Click(sender As Object, e As ItemClickEventArgs)
            ShowChildForm(Of OrderReportForm)()
        End Sub

        Private Sub ReorderReport_Click(sender As Object, e As ItemClickEventArgs)
            ShowChildForm(Of ReorderReportForm)()
        End Sub

        Private Sub Settings_Click(sender As Object, e As ItemClickEventArgs)
            ShowChildForm(Of SettingsForm)()
        End Sub

        Private Sub Users_Click(sender As Object, e As ItemClickEventArgs)
            ShowChildForm(Of UserListForm)()
        End Sub

        Private Sub PaymentTerms_Click(sender As Object, e As ItemClickEventArgs)
            ShowChildForm(Of PaymentTermListForm)()
        End Sub

        Private Sub UnitsOfMeasure_Click(sender As Object, e As ItemClickEventArgs)
            ShowChildForm(Of UnitOfMeasureListForm)()
        End Sub

        Private Sub Logout_Click(sender As Object, e As ItemClickEventArgs)
            If XtraMessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                SessionManager.Instance.Logout()
                Me.Close()
                ' The main program will handle showing the login form again
            End If
        End Sub

        Private Sub Exit_Click(sender As Object, e As ItemClickEventArgs)
            If XtraMessageBox.Show("Are you sure you want to exit?", "Confirm Exit",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Application.Exit()
            End If
        End Sub

        Private Sub tmrDateTime_Tick(sender As Object, e As EventArgs) Handles tmrDateTime.Tick
            If lblDateTime IsNot Nothing Then
                lblDateTime.Caption = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            End If
        End Sub

        Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            tmrDateTime.Stop()
        End Sub

        Private Sub LoadERDImage()
            Try
                Dim imagePath = System.IO.Path.Combine(Application.StartupPath, "DMP-inventory-entity.jpg")
                If System.IO.File.Exists(imagePath) Then
                    picERD.Image = Image.FromFile(imagePath)
                Else
                    ' Try solution folder path during development
                    imagePath = System.IO.Path.Combine(Application.StartupPath, "..", "..", "..", "DMP-inventory-entity.jpg")
                    If System.IO.File.Exists(imagePath) Then
                        picERD.Image = Image.FromFile(imagePath)
                    Else
                        lblERDTitle.Text = "ERD image not found"
                    End If
                End If
            Catch ex As Exception
                lblERDTitle.Text = "Error loading ERD: " & ex.Message
            End Try
        End Sub

        Private Sub chkShowERD_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowERD.CheckedChanged
            pnlERDScroll.Visible = chkShowERD.Checked
            If Not chkShowERD.Checked Then
                pnlERD.Width = 120
            Else
                pnlERD.Width = 400
            End If
        End Sub

    End Class

End Namespace
