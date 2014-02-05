Public Class frmMain

    '####################################################################################################
    'Deklaration
    '####################################################################################################

    Private _className As String = Me.GetType.Name

    Private _usedcolors As New List(Of Color)
    Private WithEvents _controller As clsMainController = clsProgram.MainController

    Friend Event ProjectNewClick()
    Friend Event ProjectOpenClick()
    Friend Event ProjectSaveClick(ByVal SaveAtPath As Boolean)

    Friend Event PartAddClick()

    Friend Event PosListDataSourceChanged(sender As Object, e As EventArgs)
    Friend Event PosListAddClick()
    Friend Event PosListListSelectedIndexChanged(sender As ListBox, e As EventArgs)
    Friend Event PosListEntryAddClick()
    Friend Event PosListCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs)
    Friend Event PosListCellEndEdit(sender As Object, e As DataGridViewCellEventArgs)

    Friend Event TestInitClick()

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Form generell
        BackColor = clsProgram.FhgGreenLight
        MnuStrMain.BackColor = clsProgram.FhGGreen
        ' Projekt Panel
        pnlProjekt.BackColor = clsProgram.FhGGreen
        lblProjectName.ForeColor = clsProgram.FhGGreenVeryLight
        SplitContainer1.IsSplitterFixed = True
        '   -Tabpage Overview
        tbpOverview.BackColor = clsProgram.FhGGreen
        lsbParts.BackColor = clsProgram.FhgGreenLight
        '   -Tabpage Positionlists
        tbpPosList.BackColor = clsProgram.FhGGreen
        dgvPosList.BackgroundColor = clsProgram.FhgGreenLight
        btnAddPosition.BackColor = clsProgram.FhGGreenVeryLight

    End Sub

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
        RaiseEvent ProjectNewClick()
    End Sub

    Private Sub SpeichernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeichernToolStripMenuItem.Click
        RaiseEvent ProjectSaveClick(True)
    End Sub

    Private Sub SpeichernunterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeichernunterToolStripMenuItem.Click
        RaiseEvent ProjectSaveClick(False)
    End Sub

    Private Sub TestsInitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestsInitToolStripMenuItem.Click
        RaiseEvent TestInitClick()
    End Sub

    Private Sub ÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÖffnenToolStripMenuItem.Click
        RaiseEvent ProjectOpenClick()
    End Sub

    Private Sub SplitContainer1_SizeChanged(sender As Object, e As EventArgs) Handles SplitContainer1.SizeChanged
        lblProjectName.Location = New Point(CInt((SplitContainer1.Width / 2) - (lblProjectName.Width / 2)), _
                            CInt((SplitContainer1.Panel1.Height / 2) - (lblProjectName.Height / 2)))
    End Sub

    Private Sub PartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartToolStripMenuItem.Click
        RaiseEvent PartAddClick()
    End Sub

    Private Sub PositionslisteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PositionslisteToolStripMenuItem.Click
        RaiseEvent PosListAddClick()
    End Sub

    Private Sub btnAddPosition_Click(sender As Object, e As EventArgs) Handles btnAddPosition.Click
        RaiseEvent PosListEntryAddClick()
    End Sub

    Private Sub lsbPosLists_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsbPosLists.SelectedIndexChanged
        RaiseEvent PosListListSelectedIndexChanged(CType(sender, ListBox), e)
    End Sub

    Private Sub dgvPosList_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvPosList.DataSourceChanged
        RaiseEvent PosListDataSourceChanged(sender, e)
    End Sub

    Private Sub dgvPosList_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvPosList.CellBeginEdit
        RaiseEvent PosListCellBeginEdit(sender, e)
    End Sub

    Private Sub dgvPosList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPosList.CellEndEdit
        RaiseEvent PosListCellEndEdit(sender, e)
    End Sub

End Class
