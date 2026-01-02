Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon

Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MainForm
        Inherits RibbonForm

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
            Me.ribbon = New DevExpress.XtraBars.Ribbon.RibbonControl()
            Me.ribbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
            Me.pageHome = New DevExpress.XtraBars.Ribbon.RibbonPage()
            Me.pageCatalog = New DevExpress.XtraBars.Ribbon.RibbonPage()
            Me.pageOrders = New DevExpress.XtraBars.Ribbon.RibbonPage()
            Me.pagePurchasing = New DevExpress.XtraBars.Ribbon.RibbonPage()
            Me.pageInventory = New DevExpress.XtraBars.Ribbon.RibbonPage()
            Me.pageReports = New DevExpress.XtraBars.Ribbon.RibbonPage()
            Me.pageAdmin = New DevExpress.XtraBars.Ribbon.RibbonPage()
            Me.lblUser = New DevExpress.XtraBars.BarStaticItem()
            Me.lblRole = New DevExpress.XtraBars.BarStaticItem()
            Me.lblDateTime = New DevExpress.XtraBars.BarStaticItem()
            Me.tmrDateTime = New System.Windows.Forms.Timer(Me.components)
            Me.pnlERD = New DevExpress.XtraEditors.PanelControl()
            Me.pnlERDHeader = New DevExpress.XtraEditors.PanelControl()
            Me.chkShowERD = New DevExpress.XtraEditors.CheckEdit()
            Me.lblERDTitle = New DevExpress.XtraEditors.LabelControl()
            Me.pnlERDScroll = New DevExpress.XtraEditors.XtraScrollableControl()
            Me.picERD = New System.Windows.Forms.PictureBox()
            CType(Me.ribbon, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pnlERD, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlERD.SuspendLayout()
            CType(Me.pnlERDHeader, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlERDHeader.SuspendLayout()
            CType(Me.chkShowERD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.picERD, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            ' ribbon
            '
            Me.ribbon.ExpandCollapseItem.Id = 0
            Me.ribbon.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbon.ExpandCollapseItem, Me.ribbon.SearchEditItem, Me.lblUser, Me.lblRole, Me.lblDateTime})
            Me.ribbon.Location = New System.Drawing.Point(0, 0)
            Me.ribbon.MaxItemId = 4
            Me.ribbon.Name = "ribbon"
            Me.ribbon.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.pageHome, Me.pageCatalog, Me.pageOrders, Me.pagePurchasing, Me.pageInventory, Me.pageReports, Me.pageAdmin})
            Me.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False
            Me.ribbon.Size = New System.Drawing.Size(1200, 158)
            Me.ribbon.StatusBar = Me.ribbonStatusBar
            '
            ' ribbonStatusBar
            '
            Me.ribbonStatusBar.ItemLinks.Add(Me.lblUser)
            Me.ribbonStatusBar.ItemLinks.Add(Me.lblRole)
            Me.ribbonStatusBar.ItemLinks.Add(Me.lblDateTime)
            Me.ribbonStatusBar.Location = New System.Drawing.Point(0, 777)
            Me.ribbonStatusBar.Name = "ribbonStatusBar"
            Me.ribbonStatusBar.Ribbon = Me.ribbon
            Me.ribbonStatusBar.Size = New System.Drawing.Size(1200, 23)
            '
            ' pageHome
            '
            Me.pageHome.Name = "pageHome"
            Me.pageHome.Text = "Home"
            '
            ' pageCatalog
            '
            Me.pageCatalog.Name = "pageCatalog"
            Me.pageCatalog.Text = "Catalog"
            '
            ' pageOrders
            '
            Me.pageOrders.Name = "pageOrders"
            Me.pageOrders.Text = "Orders"
            '
            ' pagePurchasing
            '
            Me.pagePurchasing.Name = "pagePurchasing"
            Me.pagePurchasing.Text = "Purchasing"
            '
            ' pageInventory
            '
            Me.pageInventory.Name = "pageInventory"
            Me.pageInventory.Text = "Inventory"
            '
            ' pageReports
            '
            Me.pageReports.Name = "pageReports"
            Me.pageReports.Text = "Reports"
            '
            ' pageAdmin
            '
            Me.pageAdmin.Name = "pageAdmin"
            Me.pageAdmin.Text = "Administration"
            '
            ' lblUser
            '
            Me.lblUser.Caption = "User: "
            Me.lblUser.Id = 1
            Me.lblUser.Name = "lblUser"
            '
            ' lblRole
            '
            Me.lblRole.Caption = "Role: "
            Me.lblRole.Id = 2
            Me.lblRole.Name = "lblRole"
            '
            ' lblDateTime
            '
            Me.lblDateTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
            Me.lblDateTime.Caption = ""
            Me.lblDateTime.Id = 3
            Me.lblDateTime.Name = "lblDateTime"
            '
            ' tmrDateTime
            '
            Me.tmrDateTime.Interval = 1000
            '
            ' pnlERD
            '
            Me.pnlERD.Controls.Add(Me.pnlERDScroll)
            Me.pnlERD.Controls.Add(Me.pnlERDHeader)
            Me.pnlERD.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnlERD.Location = New System.Drawing.Point(800, 158)
            Me.pnlERD.Name = "pnlERD"
            Me.pnlERD.Size = New System.Drawing.Size(400, 619)
            Me.pnlERD.TabIndex = 2
            '
            ' pnlERDHeader
            '
            Me.pnlERDHeader.Controls.Add(Me.chkShowERD)
            Me.pnlERDHeader.Controls.Add(Me.lblERDTitle)
            Me.pnlERDHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlERDHeader.Location = New System.Drawing.Point(2, 2)
            Me.pnlERDHeader.Name = "pnlERDHeader"
            Me.pnlERDHeader.Size = New System.Drawing.Size(396, 30)
            Me.pnlERDHeader.TabIndex = 0
            '
            ' lblERDTitle
            '
            Me.lblERDTitle.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.lblERDTitle.Appearance.Options.UseFont = True
            Me.lblERDTitle.Location = New System.Drawing.Point(10, 8)
            Me.lblERDTitle.Name = "lblERDTitle"
            Me.lblERDTitle.Size = New System.Drawing.Size(108, 13)
            Me.lblERDTitle.TabIndex = 0
            Me.lblERDTitle.Text = "Entity Relationship Diagram"
            '
            ' chkShowERD
            '
            Me.chkShowERD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.chkShowERD.EditValue = True
            Me.chkShowERD.Location = New System.Drawing.Point(290, 5)
            Me.chkShowERD.Name = "chkShowERD"
            Me.chkShowERD.Properties.Caption = "Show ERD"
            Me.chkShowERD.Size = New System.Drawing.Size(100, 20)
            Me.chkShowERD.TabIndex = 1
            '
            ' pnlERDScroll
            '
            Me.pnlERDScroll.Controls.Add(Me.picERD)
            Me.pnlERDScroll.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlERDScroll.Location = New System.Drawing.Point(2, 32)
            Me.pnlERDScroll.Name = "pnlERDScroll"
            Me.pnlERDScroll.Size = New System.Drawing.Size(396, 585)
            Me.pnlERDScroll.TabIndex = 1
            '
            ' picERD
            '
            Me.picERD.Location = New System.Drawing.Point(0, 0)
            Me.picERD.Name = "picERD"
            Me.picERD.Size = New System.Drawing.Size(100, 100)
            Me.picERD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.picERD.TabIndex = 0
            Me.picERD.TabStop = False
            '
            ' MainForm
            '
            Me.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1200, 800)
            Me.Controls.Add(Me.pnlERD)
            Me.Controls.Add(Me.ribbonStatusBar)
            Me.Controls.Add(Me.ribbon)
            Me.IsMdiContainer = True
            Me.Name = "MainForm"
            Me.Ribbon = Me.ribbon
            Me.StatusBar = Me.ribbonStatusBar
            Me.Text = "Inventory Management System"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            CType(Me.ribbon, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pnlERD, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlERD.ResumeLayout(False)
            CType(Me.pnlERDHeader, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlERDHeader.ResumeLayout(False)
            Me.pnlERDHeader.PerformLayout()
            CType(Me.chkShowERD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.picERD, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Friend Shadows WithEvents ribbon As DevExpress.XtraBars.Ribbon.RibbonControl
        Friend WithEvents ribbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
        Friend WithEvents pageHome As DevExpress.XtraBars.Ribbon.RibbonPage
        Friend WithEvents pageCatalog As DevExpress.XtraBars.Ribbon.RibbonPage
        Friend WithEvents pageOrders As DevExpress.XtraBars.Ribbon.RibbonPage
        Friend WithEvents pagePurchasing As DevExpress.XtraBars.Ribbon.RibbonPage
        Friend WithEvents pageInventory As DevExpress.XtraBars.Ribbon.RibbonPage
        Friend WithEvents pageReports As DevExpress.XtraBars.Ribbon.RibbonPage
        Friend WithEvents pageAdmin As DevExpress.XtraBars.Ribbon.RibbonPage
        Friend WithEvents lblUser As DevExpress.XtraBars.BarStaticItem
        Friend WithEvents lblRole As DevExpress.XtraBars.BarStaticItem
        Friend WithEvents lblDateTime As DevExpress.XtraBars.BarStaticItem
        Friend WithEvents tmrDateTime As System.Windows.Forms.Timer
        Friend WithEvents pnlERD As DevExpress.XtraEditors.PanelControl
        Friend WithEvents pnlERDHeader As DevExpress.XtraEditors.PanelControl
        Friend WithEvents lblERDTitle As DevExpress.XtraEditors.LabelControl
        Friend WithEvents chkShowERD As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents pnlERDScroll As DevExpress.XtraEditors.XtraScrollableControl
        Friend WithEvents picERD As System.Windows.Forms.PictureBox

    End Class
End Namespace
