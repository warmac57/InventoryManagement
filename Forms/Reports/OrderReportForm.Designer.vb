Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Namespace Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class OrderReportForm
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
            Me.lblFrom = New DevExpress.XtraEditors.LabelControl()
            Me.dtpFromDate = New DevExpress.XtraEditors.DateEdit()
            Me.lblTo = New DevExpress.XtraEditors.LabelControl()
            Me.dtpToDate = New DevExpress.XtraEditors.DateEdit()
            Me.lblStatusLabel = New DevExpress.XtraEditors.LabelControl()
            Me.cboStatus = New DevExpress.XtraEditors.ComboBoxEdit()
            Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
            Me.btnExport = New DevExpress.XtraEditors.SimpleButton()
            Me.lblTotalSales = New DevExpress.XtraEditors.LabelControl()
            Me.gridOrders = New DevExpress.XtraGrid.GridControl()
            Me.gridView = New DevExpress.XtraGrid.Views.Grid.GridView()
            CType(Me.pnlToolbar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlToolbar.SuspendLayout()
            CType(Me.dtpFromDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtpFromDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtpToDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtpToDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            ' pnlToolbar
            '
            Me.pnlToolbar.Controls.Add(Me.lblTotalSales)
            Me.pnlToolbar.Controls.Add(Me.btnExport)
            Me.pnlToolbar.Controls.Add(Me.btnSearch)
            Me.pnlToolbar.Controls.Add(Me.cboStatus)
            Me.pnlToolbar.Controls.Add(Me.lblStatusLabel)
            Me.pnlToolbar.Controls.Add(Me.dtpToDate)
            Me.pnlToolbar.Controls.Add(Me.lblTo)
            Me.pnlToolbar.Controls.Add(Me.dtpFromDate)
            Me.pnlToolbar.Controls.Add(Me.lblFrom)
            Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
            Me.pnlToolbar.Name = "pnlToolbar"
            Me.pnlToolbar.Size = New System.Drawing.Size(984, 50)
            Me.pnlToolbar.TabIndex = 0
            '
            ' lblFrom
            '
            Me.lblFrom.Location = New System.Drawing.Point(10, 16)
            Me.lblFrom.Name = "lblFrom"
            Me.lblFrom.Size = New System.Drawing.Size(28, 13)
            Me.lblFrom.TabIndex = 0
            Me.lblFrom.Text = "From:"
            '
            ' dtpFromDate
            '
            Me.dtpFromDate.EditValue = Nothing
            Me.dtpFromDate.Location = New System.Drawing.Point(50, 12)
            Me.dtpFromDate.Name = "dtpFromDate"
            Me.dtpFromDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dtpFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dtpFromDate.Size = New System.Drawing.Size(120, 20)
            Me.dtpFromDate.TabIndex = 1
            '
            ' lblTo
            '
            Me.lblTo.Location = New System.Drawing.Point(185, 16)
            Me.lblTo.Name = "lblTo"
            Me.lblTo.Size = New System.Drawing.Size(16, 13)
            Me.lblTo.TabIndex = 2
            Me.lblTo.Text = "To:"
            '
            ' dtpToDate
            '
            Me.dtpToDate.EditValue = Nothing
            Me.dtpToDate.Location = New System.Drawing.Point(210, 12)
            Me.dtpToDate.Name = "dtpToDate"
            Me.dtpToDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dtpToDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dtpToDate.Size = New System.Drawing.Size(120, 20)
            Me.dtpToDate.TabIndex = 3
            '
            ' lblStatusLabel
            '
            Me.lblStatusLabel.Location = New System.Drawing.Point(350, 16)
            Me.lblStatusLabel.Name = "lblStatusLabel"
            Me.lblStatusLabel.Size = New System.Drawing.Size(35, 13)
            Me.lblStatusLabel.TabIndex = 4
            Me.lblStatusLabel.Text = "Status:"
            '
            ' cboStatus
            '
            Me.cboStatus.Location = New System.Drawing.Point(395, 12)
            Me.cboStatus.Name = "cboStatus"
            Me.cboStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.cboStatus.Properties.Items.AddRange(New Object() {"All", "Draft", "Submitted", "Approved", "Processing", "Shipped", "Delivered", "Cancelled"})
            Me.cboStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            Me.cboStatus.Size = New System.Drawing.Size(120, 20)
            Me.cboStatus.TabIndex = 5
            '
            ' btnSearch
            '
            Me.btnSearch.Location = New System.Drawing.Point(530, 10)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(80, 28)
            Me.btnSearch.TabIndex = 6
            Me.btnSearch.Text = "Search"
            '
            ' btnExport
            '
            Me.btnExport.Location = New System.Drawing.Point(620, 10)
            Me.btnExport.Name = "btnExport"
            Me.btnExport.Size = New System.Drawing.Size(80, 28)
            Me.btnExport.TabIndex = 7
            Me.btnExport.Text = "Export"
            '
            ' lblTotalSales
            '
            Me.lblTotalSales.Appearance.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblTotalSales.Appearance.Options.UseFont = True
            Me.lblTotalSales.Location = New System.Drawing.Point(800, 16)
            Me.lblTotalSales.Name = "lblTotalSales"
            Me.lblTotalSales.Size = New System.Drawing.Size(0, 18)
            Me.lblTotalSales.TabIndex = 8
            '
            ' gridOrders
            '
            Me.gridOrders.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gridOrders.Location = New System.Drawing.Point(0, 50)
            Me.gridOrders.MainView = Me.gridView
            Me.gridOrders.Name = "gridOrders"
            Me.gridOrders.Size = New System.Drawing.Size(984, 511)
            Me.gridOrders.TabIndex = 1
            Me.gridOrders.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridView})
            '
            ' gridView
            '
            Me.gridView.GridControl = Me.gridOrders
            Me.gridView.Name = "gridView"
            Me.gridView.OptionsBehavior.Editable = False
            Me.gridView.OptionsView.ShowGroupPanel = False
            Me.gridView.OptionsView.ShowFooter = True
            '
            ' OrderReportForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(984, 561)
            Me.Controls.Add(Me.gridOrders)
            Me.Controls.Add(Me.pnlToolbar)
            Me.Name = "OrderReportForm"
            Me.Text = "Order Report"
            CType(Me.pnlToolbar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlToolbar.ResumeLayout(False)
            Me.pnlToolbar.PerformLayout()
            CType(Me.dtpFromDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtpFromDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtpToDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtpToDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridOrders, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents pnlToolbar As DevExpress.XtraEditors.PanelControl
        Friend WithEvents lblFrom As DevExpress.XtraEditors.LabelControl
        Friend WithEvents dtpFromDate As DevExpress.XtraEditors.DateEdit
        Friend WithEvents lblTo As DevExpress.XtraEditors.LabelControl
        Friend WithEvents dtpToDate As DevExpress.XtraEditors.DateEdit
        Friend WithEvents lblStatusLabel As DevExpress.XtraEditors.LabelControl
        Friend WithEvents cboStatus As DevExpress.XtraEditors.ComboBoxEdit
        Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnExport As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents lblTotalSales As DevExpress.XtraEditors.LabelControl
        Friend WithEvents gridOrders As DevExpress.XtraGrid.GridControl
        Friend WithEvents gridView As DevExpress.XtraGrid.Views.Grid.GridView

    End Class
End Namespace
