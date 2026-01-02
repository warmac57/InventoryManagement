Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports InventoryManagement.Common

Namespace Forms.Admin

    Partial Public Class SettingsForm

        Public Sub New()
            InitializeComponent()
            LoadSettings()
        End Sub

        Private Sub LoadSettings()
            Dim settings = AppSettings.Instance
            txtCompanyName.Text = settings.CompanyName
            txtTaxRate.Value = settings.TaxRate
            txtOrderPrefix.Text = settings.OrderNumberPrefix
            txtPurchasePrefix.Text = settings.PurchaseNumberPrefix
            chkNegativeStock.Checked = settings.NegativeStockAllowed
            chkInStockCheck.Checked = settings.InStockCheck
            chkMovingAverage.Checked = settings.MovingAveragePrice
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            Try
                Dim settings = AppSettings.Instance

                settings.SaveSetting("Company_Name", txtCompanyName.Text)
                settings.SaveSetting("Tax_Rate", txtTaxRate.Value.ToString())
                settings.SaveSetting("Order_Number_Prefix", txtOrderPrefix.Text)
                settings.SaveSetting("Purchase_Number_Prefix", txtPurchasePrefix.Text)
                settings.SaveSetting("Negative_Stock_Allowed", chkNegativeStock.Checked.ToString())
                settings.SaveSetting("In_Stock_Check", chkInStockCheck.Checked.ToString())
                settings.SaveSetting("Moving_Average_Price", chkMovingAverage.Checked.ToString())

                ' Update cached values
                settings.CompanyName = txtCompanyName.Text
                settings.TaxRate = txtTaxRate.Value
                settings.OrderNumberPrefix = txtOrderPrefix.Text
                settings.PurchaseNumberPrefix = txtPurchasePrefix.Text
                settings.NegativeStockAllowed = chkNegativeStock.Checked
                settings.InStockCheck = chkInStockCheck.Checked
                settings.MovingAveragePrice = chkMovingAverage.Checked

                XtraMessageBox.Show("Settings saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub

    End Class

End Namespace
