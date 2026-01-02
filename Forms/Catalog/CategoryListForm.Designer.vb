Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Namespace Forms.Catalog
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CategoryListForm
        Inherits XtraForm

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
            Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
            Me.btnEdit = New DevExpress.XtraEditors.SimpleButton()
            Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
            Me.gridControl = New DevExpress.XtraGrid.GridControl()
            Me.gridView = New DevExpress.XtraGrid.Views.Grid.GridView()
            CType(Me.pnlToolbar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlToolbar.SuspendLayout()
            CType(Me.gridControl, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            ' pnlToolbar
            '
            Me.pnlToolbar.Controls.Add(Me.btnRefresh)
            Me.pnlToolbar.Controls.Add(Me.btnDelete)
            Me.pnlToolbar.Controls.Add(Me.btnEdit)
            Me.pnlToolbar.Controls.Add(Me.btnAdd)
            Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
            Me.pnlToolbar.Name = "pnlToolbar"
            Me.pnlToolbar.Size = New System.Drawing.Size(900, 45)
            Me.pnlToolbar.TabIndex = 0
            '
            ' btnAdd
            '
            Me.btnAdd.Location = New System.Drawing.Point(10, 8)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(100, 28)
            Me.btnAdd.TabIndex = 0
            Me.btnAdd.Text = "Add New"
            '
            ' btnEdit
            '
            Me.btnEdit.Location = New System.Drawing.Point(120, 8)
            Me.btnEdit.Name = "btnEdit"
            Me.btnEdit.Size = New System.Drawing.Size(80, 28)
            Me.btnEdit.TabIndex = 1
            Me.btnEdit.Text = "Edit"
            '
            ' btnDelete
            '
            Me.btnDelete.Location = New System.Drawing.Point(210, 8)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(80, 28)
            Me.btnDelete.TabIndex = 2
            Me.btnDelete.Text = "Delete"
            '
            ' btnRefresh
            '
            Me.btnRefresh.Location = New System.Drawing.Point(300, 8)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(80, 28)
            Me.btnRefresh.TabIndex = 3
            Me.btnRefresh.Text = "Refresh"
            '
            ' gridControl
            '
            Me.gridControl.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gridControl.Location = New System.Drawing.Point(0, 45)
            Me.gridControl.MainView = Me.gridView
            Me.gridControl.Name = "gridControl"
            Me.gridControl.Size = New System.Drawing.Size(900, 505)
            Me.gridControl.TabIndex = 1
            Me.gridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridView})
            '
            ' gridView
            '
            Me.gridView.GridControl = Me.gridControl
            Me.gridView.Name = "gridView"
            Me.gridView.OptionsBehavior.Editable = False
            Me.gridView.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.gridView.OptionsView.ShowGroupPanel = False
            '
            ' CategoryListForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(900, 550)
            Me.Controls.Add(Me.gridControl)
            Me.Controls.Add(Me.pnlToolbar)
            Me.Name = "CategoryListForm"
            Me.Text = "Category Management"
            CType(Me.pnlToolbar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlToolbar.ResumeLayout(False)
            CType(Me.gridControl, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents pnlToolbar As DevExpress.XtraEditors.PanelControl
        Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnEdit As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnRefresh As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents gridControl As DevExpress.XtraGrid.GridControl
        Friend WithEvents gridView As DevExpress.XtraGrid.Views.Grid.GridView

    End Class
End Namespace
