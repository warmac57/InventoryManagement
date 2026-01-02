Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports InventoryManagement.BusinessLogic
Imports InventoryManagement.DataAccess
Imports InventoryManagement.Entities

Namespace Forms.InventoryControl

    Partial Public Class InventoryCountForm

        Private _countId As Integer
        Private _count As InventoryCount
        Private ReadOnly _inventoryManager As New InventoryManager()
        Private ReadOnly _itemDAO As New ItemDAO()

        Public Sub New(Optional countId As Integer = 0)
            _countId = countId
            InitializeComponent()
            SetupForm()
            LoadData()
        End Sub

        Private Sub SetupForm()
            Me.Text = If(_countId = 0, "New Inventory Count", "Edit Inventory Count")

            ' Configure item lookup columns
            cboItem.Properties.Columns.Clear()
            cboItem.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Item_Code", "Code", 80))
            cboItem.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Item_Name", "Name", 200))
            cboItem.Properties.PopupWidth = 300
            cboItem.Properties.DataSource = _itemDAO.GetActiveItems()

            AddHandler cboItem.EditValueChanged, AddressOf Item_Changed
            AddHandler txtCountedQty.EditValueChanged, AddressOf Count_Changed
        End Sub

        Private Sub LoadData()
            If _countId > 0 Then
                Dim dao As New InventoryCountDAO()
                _count = dao.GetById(_countId)
                If _count IsNot Nothing Then
                    cboItem.EditValue = _count.Item_ID
                    cboItem.Properties.ReadOnly = True
                    txtSystemQty.Value = _count.System_Quantity
                    txtCountedQty.Value = _count.Quantity_Counted
                    txtVariance.Text = _count.Quantity_Change.ToString("N2")
                    txtVarianceValue.EditValue = _count.Variance_Value
                    txtNotes.Text = _count.Notes
                    lblStatus.Text = _count.Count_Status
                    UpdateButtonStates()
                End If
            Else
                _count = New InventoryCount()
            End If
        End Sub

        Private Sub Item_Changed(sender As Object, e As EventArgs)
            If cboItem.EditValue IsNot Nothing Then
                Dim item = _itemDAO.GetById(CInt(cboItem.EditValue))
                If item IsNot Nothing Then
                    txtSystemQty.Value = item.Stock_Quantity
                    _count.System_Quantity = item.Stock_Quantity
                    _count.Unit_Cost = item.Current_Item_Cost
                    _count.Item_ID = item.Item_ID
                    CalculateVariance()
                End If
            End If
        End Sub

        Private Sub Count_Changed(sender As Object, e As EventArgs)
            CalculateVariance()
        End Sub

        Private Sub CalculateVariance()
            _count.Quantity_Counted = txtCountedQty.Value
            _count.CalculateVariance()
            txtVariance.Text = _count.Quantity_Change.ToString("N2")
            txtVarianceValue.EditValue = _count.Variance_Value

            If _count.Quantity_Change < 0 Then
                txtVariance.ForeColor = Color.Red
            ElseIf _count.Quantity_Change > 0 Then
                txtVariance.ForeColor = Color.Green
            Else
                txtVariance.ForeColor = Color.Black
            End If
        End Sub

        Private Sub UpdateButtonStates()
            Dim canEdit = _count.CanEdit
            txtCountedQty.Properties.ReadOnly = Not canEdit
            txtNotes.Properties.ReadOnly = Not canEdit
            btnSave.Enabled = canEdit
            btnApply.Enabled = _count.Count_Status = "Completed" OrElse _count.Count_Status = "Initiated" OrElse _count.Count_Status = "InProgress"
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If cboItem.EditValue Is Nothing Then
                XtraMessageBox.Show("Please select an item.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                _count.Notes = txtNotes.Text
                _count.Count_Status = "Completed"
                _inventoryManager.SaveInventoryCount(_count)
                XtraMessageBox.Show("Count saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _countId = _count.Count_ID
                LoadData()
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
            If _count.Count_ID = 0 Then
                XtraMessageBox.Show("Please save the count first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                If XtraMessageBox.Show("This will update the inventory. Continue?", "Confirm",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    _inventoryManager.ApplyInventoryCount(_count.Count_ID)
                    XtraMessageBox.Show("Count applied to inventory.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End If
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub

    End Class

End Namespace
