Imports System.Windows.Forms
Imports DevExpress.LookAndFeel
Imports DevExpress.Skins
Imports InventoryManagement.Forms

Module Program
    <STAThread>
    Sub Main()
        ' Enable visual styles
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        ' Set DevExpress skin
        UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Bezier)

        ' Show login form first
        Dim loginForm As New LoginForm()
        If loginForm.ShowDialog() = DialogResult.OK Then
            ' Login successful, show main form
            Application.Run(New MainForm())
        End If
    End Sub
End Module
