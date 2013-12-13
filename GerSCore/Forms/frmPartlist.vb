Public Class frmPartlist

    Private Sub frmPartlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If frmMain.Project Is Nothing Then
            Me.Text = "Gerber Shift Correction"
        Else
            Me.Text = "Gerber Shift Correction - Part Bibliothek - Part Liste - " & frmMain.Project.Name
        End If
    End Sub

    Private Sub SchließenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SchließenToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class