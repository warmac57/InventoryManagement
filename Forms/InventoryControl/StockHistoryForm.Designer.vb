Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Namespace Forms.InventoryControl
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class StockHistoryForm
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
            Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
            Me.btnRefresh = New DevExpress.XtraEditors.SimpleButton()
            Me.gridHistory = New DevExpress.XtraGrid.GridControl()
            Me.gridView = New DevExpress.XtraGrid.Views.Grid.GridView()
            CType(Me.pnlToolbar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlToolbar.SuspendLayout()
            CType(Me.dtpFromDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtpFromDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtpToDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtpToDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridHistory, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            ' pnlToolbar
            '
            Me.pnlToolbar.Controls.Add(Me.btnRefresh)
            Me.pnlToolbar.Controls.Add(Me.btnSearch)
            Me.pnlToolbar.Controls.Add(Me.dtpToDate)
            Me.pnlToolbar.Controls.Add(Me.lblTo)
            Me.pnlToolbar.Controls.Add(Me.dtpFromDate)
            Me.pnlToolbar.Controls.Add(Me.lblFrom)
            Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
            Me.pnlToolbar.Name = "pnlToolbar"
            Me.pnlToolbar.Size = New System.Drawing.Size(984, 45)
            Me.pnlToolbar.TabIndex = 0
            '
            ' lblFrom
            '
            Me.lblFrom.Location = New System.Drawing.Point(10, 14)
            Me.lblFrom.Name = "lblFrom"
            Me.lblFrom.Size = New System.Drawing.Size(28, 13)
            Me.lblFrom.TabIndex = 0
            Me.lblFrom.Text = "From:"
            '
            ' dtpFromDate
            '
            Me.dtpFromDate.EditValue = Nothing
            Me.dtpFromDate.Location = New System.Drawing.Point(50, 10)
            Me.dtpFromDate.Name = "dtpFromDate"
            Me.dtpFromDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dtpFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dtpFromDate.Size = New System.Drawing.Size(120, 20)
            Me.dtpFromDate.TabIndex = 1
            '
            ' lblTo
            '
            Me.lblTo.Location = New System.Drawing.Point(185, 14)
            Me.lblTo.Name = "lblTo"
            Me.lblTo.Size = New System.Drawing.Size(16, 13)
            Me.lblTo.TabIndex = 2
            Me.lblTo.Text = "To:"
            '
            ' dtpToDate
            '
            Me.dtpToDate.EditValue = Nothing
            Me.dtpToDate.Location = New System.Drawing.Point(210, 10)
            Me.dtpToDate.Name = "dtpToDate"
            Me.dtpToDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dtpToDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dtpToDate.Size = New System.Drawing.Size(120, 20)
            Me.dtpToDate.TabIndex = 3
            '
            ' btnSearch
            '
            Me.btnSearch.Location = New System.Drawing.Point(350, 8)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(80, 28)
            Me.btnSearch.TabIndex = 4
            Me.btnSearch.Text = "Search"
            '
            ' btnRefresh
            '
            Me.btnRefresh.Location = New System.Drawing.Point(440, 8)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(80, 28)
            Me.btnRefresh.TabIndex = 5
            Me.btnRefresh.Text = "Refresh"
            '
            ' gridHistory
            '
            Me.gridHistory.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gridHistory.Location = New System.Drawing.Point(0, 45)
            Me.gridHistory.MainView = Me.gridView
            Me.gridHistory.Name = "gridHistory"
            Me.gridHistory.Size = New System.Drawing.Size(984, 516)
            Me.gridHistory.TabIndex = 1
            Me.gridHistory.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridView})
            '
            ' gridView
            '
            Me.gridView.GridControl = Me.gridHistory
            Me.gridView.Name = "gridView"
            Me.gridView.OptionsBehavior.Editable = False
            Me.gridView.OptionsView.ShowGroupPanel = False
            '
            ' StockHistoryForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(984, 561)
            Me.Controls.Add(Me.gridHistory)
            Me.Controls.Add(Me.pnlToolbar)
            Me.Name = "StockHistoryForm"
            Me.Text = "Stock History"
            CType(Me.pnlToolbar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlToolbar.ResumeLayout(False)
            Me.pnlToolbar.PerformLayout()
            CType(Me.dtpFromDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtpFromDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtpToDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtpToDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridHistory, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents pnlToolbar As DevExpress.XtraEditors.PanelControl
        Friend WithEvents lblFrom As DevExpress.XtraEditors.LabelControl
        Friend WithEvents dtpFromDate As DevExpress.XtraEditors.DateEdit
        Friend WithEvents lblTo As DevExpress.XtraEditors.LabelControl
        Friend WithEvents dtpToDate As DevExpress.XtraEditors.DateEdit
        Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnRefresh As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents gridHistory As DevExpress.XtraGrid.GridControl
        Friend WithEvents gridView As DevExpress.XtraGrid.Views.Grid.GridView

    End Class
End Namespace
