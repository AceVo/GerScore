Public Class frmPartLib
    Private _editor As clsEditor
    Private Main As clsMainController = clsProgramm.MainController

    Private Sub frmPartLib_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.KeyPreview = True

        _editor = New clsEditor(pnlEditor)
        AddHandler _editor.Layertree.AfterSelect, AddressOf Layertree_AfterSelect

        If Main.Project Is Nothing Then
            Me.Text = "Gerber Shift Correction"
        Else
            Me.Text = "Gerber Shift Correction - Part Bibliothek - " & clsProgramm.MainController.Project.Name
        End If
    End Sub

    Private Sub PartlisteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartlisteToolStripMenuItem.Click
        frmPartlist.ShowDialog()
    End Sub

    Private Sub SchließenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SchließenToolStripMenuItem.Click
        _editor.Dispose()
        _editor = Nothing
        Me.Close()
        GC.Collect() : GC.WaitForPendingFinalizers()
    End Sub

    Private Sub NeuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeuToolStripMenuItem.Click
        Dim part As New clsPart(InputBox("Bezeichnung des Parts eingeben", "Partname"))
    End Sub

    Private Sub Layertree_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)
        LöschenToolStripMenuItem.Enabled = True
        GerberLayerHinzufügenToolStripMenuItem.Enabled = True
    End Sub

End Class