Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Entities

Namespace Forms.Admin

    Partial Public Class UnitOfMeasureListForm

        Private ReadOnly _uomDAO As New UnitOfMeasureDAO()

        Public Sub New()
            InitializeComponent()
            SetupGrid()
        End Sub

        Private Sub SetupGrid()
            gridView.Columns.Clear()

            Dim colCode As New GridColumn()
            colCode.FieldName = "UoM_Code"
            colCode.Caption = "Code"
            colCode.Width = 80
            colCode.Visible = True
            gridView.Columns.Add(colCode)

            Dim colName As New GridColumn()
            colName.FieldName = "UoM_Name"
            colName.Caption = "Name"
            colName.Width = 150
            colName.Visible = True
            gridView.Columns.Add(colName)

            Dim colFactor As New GridColumn()
            colFactor.FieldName = "Conversion_Factor"
            colFactor.Caption = "Conversion Factor"
            colFactor.Width = 120
            colFactor.Visible = True
            gridView.Columns.Add(colFactor)

            Dim colActive As New GridColumn()
            colActive.FieldName = "Is_Active"
            colActive.Caption = "Active"
            colActive.Width = 60
            colActive.Visible = True
            gridView.Columns.Add(colActive)

            gridView.BestFitColumns()
        End Sub

        Private Sub LoadData()
            Try
                gridControl.DataSource = _uomDAO.GetAll()
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub AddNew()
            Dim frm As New UnitOfMeasureEditForm()
            If frm.ShowDialog() = DialogResult.OK Then LoadData()
        End Sub

        Private Sub EditSelected()
            If gridView.FocusedRowHandle < 0 Then Return
            Dim uom = TryCast(gridView.GetFocusedRow(), UnitOfMeasure)
            If uom IsNot Nothing Then
                Dim frm As New UnitOfMeasureEditForm(uom.UoM_ID)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End If
        End Sub

        Private Sub DeleteSelected()
            If gridView.FocusedRowHandle < 0 Then Return
            Dim uom = TryCast(gridView.GetFocusedRow(), UnitOfMeasure)
            If uom IsNot Nothing Then
                If XtraMessageBox.Show($"Delete '{uom.UoM_Name}'?", "Confirm",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Try
                        _uomDAO.Delete(uom.UoM_ID)
                        LoadData()
                    Catch ex As Exception
                        XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End Sub

        Private Sub UnitOfMeasureListForm_Load(sender As Object, e As EventArgs) Handles Me.Load
            LoadData()
        End Sub

        Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            AddNew()
        End Sub

        Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
            EditSelected()
        End Sub

        Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
            DeleteSelected()
        End Sub

        Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
            LoadData()
        End Sub

        Private Sub gridView_DoubleClick(sender As Object, e As EventArgs) Handles gridView.DoubleClick
            EditSelected()
        End Sub

    End Class

End Namespace
