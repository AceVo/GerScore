'Imports System.IO
Public Class frmMain

    '####################################################################################################
    'Deklaration
    '####################################################################################################

    ' Private _main As New clsMainController(Me)
    'Private WithEvents _project As clsProjekt
    Private _usedcolors As New List(Of Color)
    ' Dim fs As FileStream

    Friend Event ProjectNew()
    Friend Event ProjectOpen()
    Friend Event ProjectSave(ByVal SaveAtPath As Boolean)
    Friend Event TestInit()
    'Private Event ProjectInit()
    'Public rnd As New Random

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    '####################################################################################################
    'Methoden
    '####################################################################################################

    'Private Sub openProject(Optional ByVal Path As String = "")
    '    If Path = "" Then
    '        dlgOpen.FileName = ""
    '        dlgOpen.Filter = "GerSCore Projekte (*.gsProj)|*.gsProj"
    '        If IO.Directory.Exists(My.Settings.RecentPath) Then dlgOpen.InitialDirectory = My.Settings.RecentPath
    '        If dlgOpen.ShowDialog = Windows.Forms.DialogResult.OK Then
    '            Path = dlgOpen.FileName
    '        Else
    '            Exit Sub
    '        End If
    '    End If
    '    If IO.File.Exists(Path) Then
    '        Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
    '        fs = New FileStream(Path, FileMode.Open)
    '        Debug.Print(Path.ToString)
    '        _project = CType(bf.Deserialize(fs), clsProjekt)
    '        _project.Project_initiated(True)
    '        Debug.Print("geladen")
    '        fs.Close()
    '        My.Settings.RecentPath = Path
    '        MenuRecentProjects_Add(Path)
    '    Else
    '        MsgBox("Der Pfad wurde nicht gefunden!", MsgBoxStyle.Critical, "Projekt Öffnen gescheitert!")
    '    End If
    'End Sub

    'Private Sub Tests_init()
    '    clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} Sub ->  {1}", "frmMain", "Tests_init")

    '    Me.NeuToolStripMenuItem.PerformClick()

    '    Project.AddPart("Testpart1")
    '    Project.AddPart("Testpart2")
    '    Project.AddPart("Testpart3")
    '    Project.Parts(0).AddGerber("Testgerber1")
    '    Project.Parts(0).AddGerber("Testgerber2")
    '    Project.Parts(1).AddGerber("Testgerber1")
    '    Project.Parts(1).AddGerber("Testgerber2")
    '    Project.Parts(2).AddGerber("Testgerber1")
    '    Project.Parts(2).AddGerber("Testgerber2")

    '    Project.Parts(0).Gerber(0).Shapes.Add(New clsLine(Project.Parts(0).Gerber(0), New Point(10, 10), New Point(850 - 30, 500)))
    '    Project.Parts(0).Gerber(0).Shapes.Add(New clsLine(Project.Parts(0).Gerber(0), New Point(0, 0), New Point(935, 0)))
    '    Project.Parts(0).Gerber(0).Shapes.Add(New clsLine(Project.Parts(0).Gerber(0), New Point(0, 0), New Point(0, 508)))
    '    Project.Parts(0).Gerber(0).Shapes.Add(New clsLine(Project.Parts(0).Gerber(0), New Point(0, 0), New Point(939, 514)))
    '    Project.Parts(0).Gerber(0).Shapes.Add(New clsLine(Project.Parts(0).Gerber(0), New Point(0, 514), New Point(939, 0)))
    '    Project.Parts(0).Gerber(1).Shapes.Add(New clsLine(Project.Parts(0).Gerber(1), New Point(60, 10), New Point(850 - 60, 500)))
    '    Project.Parts(1).Gerber(0).Shapes.Add(New clsLine(Project.Parts(1).Gerber(0), New Point(90, 10), New Point(850 - 90, 500)))
    '    Project.Parts(1).Gerber(1).Shapes.Add(New clsLine(Project.Parts(1).Gerber(1), New Point(120, 10), New Point(850 - 120, 500)))
    '    Project.Parts(2).Gerber(0).Shapes.Add(New clsLine(Project.Parts(2).Gerber(0), New Point(150, 10), New Point(850 - 150, 500)))
    '    Project.Parts(2).Gerber(1).Shapes.Add(New clsLine(Project.Parts(2).Gerber(1), New Point(180, 10), New Point(850 - 180, 500)))

    '    Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Leave in: {0} Sub ->  {1}", "frmMain", "Tests_init") : clsProgramm.DebugPrefix -= 1
    'End Sub

    'Protected Friend Sub MenuRecentProjectsInit()
    '    With My.Settings
    '        If IsNothing(.RecentProjects) Then .RecentProjects = New Specialized.StringCollection
    '        RecentProjectsToolStripMenuItem.DropDownItems.Clear()
    '        If .RecentProjects.Count = 0 Then
    '            RecentProjectsToolStripMenuItem.DropDownItems.Add("<...nichts...>")
    '            Exit Sub
    '        End If
    '        For Each Element In .RecentProjects
    '            If Not IO.File.Exists(Element) Then .RecentProjects.Remove(Element)
    '        Next
    '        If .RecentProjects.Count > 10 Then
    '            For i = .RecentProjects.Count To 11 Step -1
    '                .RecentProjects.RemoveAt(i - 1)
    '            Next
    '        End If
    '        RecentProjectsToolStripMenuItem.DropDownItems.Clear()
    '        For Each Element In .RecentProjects
    '            Dim Item As New ToolStripMenuItem(Element)
    '            AddHandler Item.Click, AddressOf RecentProject_Click
    '            RecentProjectsToolStripMenuItem.DropDownItems.Add(Item)
    '        Next
    '    End With
    'End Sub

    'Protected Friend Sub MenuRecentProjects_Add(ByVal Path As String)
    '    With My.Settings
    '        If .RecentProjects.Contains(Path) Then
    '            .RecentProjects.Remove(Path)
    '        End If
    '        .RecentProjects.Insert(0, Path)
    '    End With
    '    MenuRecentProjectsInit()
    'End Sub

    '####################################################################################################
    'Funktionen
    '####################################################################################################

    '####################################################################################################
    'Property
    '####################################################################################################

    'Friend ReadOnly Property Project As clsProjekt
    '    Get
    '        Return _project
    '    End Get
    'End Property

    Friend Property UsedColor As List(Of Color)
        Get
            Return _usedcolors
        End Get
        Set(value As List(Of Color))
            _usedcolors = value
        End Set
    End Property

    'ReadOnly Property Main As clsMainController
    '    Get
    '        Return _main
    '    End Get
    'End Property

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
        ' _project.Save(Project.Path)
    End Sub

    Private Sub SpeichernunterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeichernunterToolStripMenuItem.Click
        RaiseEvent ProjectSave(False)
        ' _project.Save()
    End Sub

    Private Sub TestsInitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestsInitToolStripMenuItem.Click
        RaiseEvent TestInit()
        ' Tests_init()
    End Sub

    Private Sub ÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÖffnenToolStripMenuItem.Click
        RaiseEvent ProjectOpen()
        'openProject()
        'RaiseEvent ProjectInit()
    End Sub

    'Private Sub Title_update() Handles _project.SaveStatusChanged, Me.ProjectInit
    '    Me.Text = "GerScore - Gerber Shift Correction - " & _project.Name
    '    If Not _project.SaveStatus Then
    '        Me.Text = Me.Text & "*"
    '    End If
    'End Sub

    'Private Sub Project_Namechanged() Handles _project.NameChanged, Me.ProjectInit
    '    lblProjectName.Text = _project.Name
    'End Sub


End Class
