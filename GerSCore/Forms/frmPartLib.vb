Public Class frmPartLib

    Private Sub frmPartLib_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.KeyPreview = True

        Dim Editor As New clsEditor(pnlEditor)
        AddHandler Editor.Layertree.AfterSelect, AddressOf Layertree_AfterSelect
        'Editor.Canvas.Invalidate()

        If frmMain.Project Is Nothing Then
            Me.Text = "Gerber Shift Correction"
        Else
            Me.Text = "Gerber Shift Correction - Part Bibliothek - " & frmMain.Project.Name
        End If
    End Sub

    Private Sub PartlisteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartlisteToolStripMenuItem.Click
        frmPartlist.ShowDialog()
    End Sub

    Private Sub SchließenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SchließenToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NeuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeuToolStripMenuItem.Click
        Dim part As New clsPart(InputBox("Bezeichnung des Parts eingeben", "Partname"))
    End Sub

    Private Sub Layertree_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)
        LöschenToolStripMenuItem.Enabled = True
        GerberLayerHinzufügenToolStripMenuItem.Enabled = True
    End Sub

End Class