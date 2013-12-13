Public Class frmMain

    Private Shared _project As clsProjekt
    Private Shared _usedcolors As New List(Of Color)
    Public DebugPrefix As String
    Public rnd As New Random

    Public Shared ReadOnly Property Project As clsProjekt
        Get
            Return _project
        End Get
    End Property

    Public Shared Property UsedColor As List(Of Color)
        Get
            Return _usedcolors
        End Get
        Set(value As List(Of Color))
            _usedcolors = value
        End Set
    End Property

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Debug.Print("-------------------------------------------------------------------------------------")
        Randomize()
        Titel_aktualisieren()
    End Sub

    Private Sub BeendenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeendenToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NeuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeuToolStripMenuItem.Click
        _project = New clsProjekt
        Titel_aktualisieren()
    End Sub

    Public Sub Titel_aktualisieren()
        If _project Is Nothing Then
            Me.Text = "Gerber Shift Correction"
        Else
            Me.Text = "Gerber Shift Correction - " & _project.Name
        End If
    End Sub

    Private Sub PartBibliothekToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartBibliothekToolStripMenuItem.Click
        frmPartLib.ShowDialog()
    End Sub

    Private Sub Tests_init()

        Me.NeuToolStripMenuItem.PerformClick()

        Project.AddPart("Testpart1")
        Project.AddPart("Testpart2")
        Project.AddPart("Testpart3")
        Project.Parts(0).AddGerber("Testgerber1", Project.Parts(0))
        Project.Parts(0).AddGerber("Testgerber2", Project.Parts(0))
        Project.Parts(1).AddGerber("Testgerber1", Project.Parts(1))
        Project.Parts(1).AddGerber("Testgerber2", Project.Parts(1))
        Project.Parts(2).AddGerber("Testgerber1", Project.Parts(2))
        Project.Parts(2).AddGerber("Testgerber2", Project.Parts(2))

        Project.Parts(0).Gerber(0).Shapes.Add(New clsLine(Project.Parts(0).Gerber(0), New Point(10, 10), New Point(850 - 30, 500)))
        Project.Parts(0).Gerber(0).Shapes.Add(New clsLine(Project.Parts(0).Gerber(0), New Point(0, 0), New Point(935, 0)))
        Project.Parts(0).Gerber(0).Shapes.Add(New clsLine(Project.Parts(0).Gerber(0), New Point(0, 0), New Point(0, 508)))
        Project.Parts(0).Gerber(0).Shapes.Add(New clsLine(Project.Parts(0).Gerber(0), New Point(0, 0), New Point(939, 514)))
        Project.Parts(0).Gerber(0).Shapes.Add(New clsLine(Project.Parts(0).Gerber(0), New Point(0, 514), New Point(939, 0)))
        Project.Parts(0).Gerber(1).Shapes.Add(New clsLine(Project.Parts(0).Gerber(1), New Point(60, 10), New Point(850 - 60, 500)))
        Project.Parts(1).Gerber(0).Shapes.Add(New clsLine(Project.Parts(1).Gerber(0), New Point(90, 10), New Point(850 - 90, 500)))
        Project.Parts(1).Gerber(1).Shapes.Add(New clsLine(Project.Parts(1).Gerber(1), New Point(120, 10), New Point(850 - 120, 500)))
        Project.Parts(2).Gerber(0).Shapes.Add(New clsLine(Project.Parts(2).Gerber(0), New Point(150, 10), New Point(850 - 150, 500)))
        Project.Parts(2).Gerber(1).Shapes.Add(New clsLine(Project.Parts(2).Gerber(1), New Point(180, 10), New Point(850 - 180, 500)))

        Me.PartBibliothekToolStripMenuItem.PerformClick()

    End Sub

    Private Sub frmMain_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Tests_init()
    End Sub

End Class
