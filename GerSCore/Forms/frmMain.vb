Public Class frmMain

    '####################################################################################################
    'Deklaration
    '####################################################################################################

    Private _usedcolors As New List(Of Color)

    Friend Event ProjectNew()
    Friend Event ProjectOpen()
    Friend Event ProjectSave(ByVal SaveAtPath As Boolean)
    Friend Event TestInit()

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    '####################################################################################################
    'Methoden
    '####################################################################################################

    '####################################################################################################
    'Funktionen
    '####################################################################################################

    '####################################################################################################
    'Property
    '####################################################################################################

    Friend Property UsedColor As List(Of Color)
        Get
            Return _usedcolors
        End Get
        Set(value As List(Of Color))
            _usedcolors = value
        End Set
    End Property

    '####################################################################################################
    'Events
    '####################################################################################################

    Private Sub PartBibliothekToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartBibliothekToolStripMenuItem.Click
        frmPartLib.ShowDialog()
    End Sub

    Private Sub BeendenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeendenToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NeuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeuToolStripMenuItem.Click
        RaiseEvent ProjectNew()
    End Sub

    Private Sub SpeichernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeichernToolStripMenuItem.Click
        RaiseEvent ProjectSave(True)
    End Sub

    Private Sub SpeichernunterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeichernunterToolStripMenuItem.Click
        RaiseEvent ProjectSave(False)
    End Sub

    Private Sub TestsInitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestsInitToolStripMenuItem.Click
        RaiseEvent TestInit()
    End Sub

    Private Sub ÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÖffnenToolStripMenuItem.Click
        RaiseEvent ProjectOpen()
    End Sub

End Class
