Imports System.IO
Public Class clsMainController

    '####################################################################################################
    'Deklaration
    '####################################################################################################

    Private _className As String = "clsMainController"

    Private WithEvents _mainform As frmMain = clsProgramm.MainForm
    Private WithEvents _project As clsProjekt
    Private _fs As FileStream

    Public rnd As New Random

    Private Event ProjectInit()

    Friend Event ProjectSaved()

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Public Sub New()
        Dim _type As String = "Sub"
        Dim _structname As String = "New"
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        ' ....

        clsProgramm.DebugPrefix -= 1
    End Sub
    '####################################################################################################
    'Methoden
    '####################################################################################################

    Private Sub MenuRecentProjectsInit()
        Dim _type As String = "Sub"
        Dim _structname As String = "MenuRecentProjectsInit"
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        With My.Settings
            If IsNothing(.RecentProjects) Then .RecentProjects = New Specialized.StringCollection

            _mainform.RecentProjectsToolStripMenuItem.DropDownItems.Clear()
            If .RecentProjects.Count = 0 Then
                _mainform.RecentProjectsToolStripMenuItem.DropDownItems.Add("<...nichts...>")
                Exit Sub
            End If
            For Each Element In .RecentProjects
                If Not IO.File.Exists(Element) Then .RecentProjects.Remove(Element)
            Next
            If .RecentProjects.Count > 10 Then
                For i = .RecentProjects.Count To 11 Step -1
                    .RecentProjects.RemoveAt(i - 1)
                Next
            End If
            _mainform.RecentProjectsToolStripMenuItem.DropDownItems.Clear()
            For Each Element In .RecentProjects
                Dim Item As New ToolStripMenuItem(Element)
                AddHandler Item.Click, AddressOf RecentProject_Click
                _mainform.RecentProjectsToolStripMenuItem.DropDownItems.Add(Item)
            Next
        End With

        clsProgramm.DebugPrefix -= 1
    End Sub

    Private Sub MenuRecentProjects_Add(ByVal Path As String)
        Dim _type As String = "Sub"
        Dim _structname As String = " MenuRecentProjects_Add"
        Dim _name As String = Path
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name)

        With My.Settings
            If .RecentProjects.Contains(Path) Then
                .RecentProjects.Remove(Path)
            End If
            .RecentProjects.Insert(0, Path)
        End With
        MenuRecentProjectsInit()

        clsProgramm.DebugPrefix -= 1
    End Sub

    '####################################################################################################
    'Funktionen
    '####################################################################################################

    '####################################################################################################
    'Property
    '####################################################################################################

    Friend ReadOnly Property Project As clsProjekt
        Get
            Return _project
        End Get
    End Property

    '####################################################################################################
    'Events
    '####################################################################################################

    Private Sub MainForm_Loaded() Handles _mainform.Load
        Dim _type As String = "Event"
        Dim _structname As String = "MainForm_Loaded"
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        Randomize()
        MenuRecentProjectsInit()

        clsProgramm.DebugPrefix -= 1
    End Sub

    Private Sub Project_New() Handles _mainform.ProjectNew
        Dim _type As String = "Event"
        Dim _structname As String = "Project_New"
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        _project = clsProjekt.Instance
        RaiseEvent ProjectInit()

        clsProgramm.DebugPrefix -= 1
    End Sub

    Private Sub Project_Open(Optional ByVal Path As String = "") Handles _mainform.ProjectOpen
        Dim _type As String = "Event"
        Dim _structname As String = "openProject"
        Dim _name As String = Path
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name)

        With _mainform
            If Path = "" Then
                .dlgOpen.FileName = ""
                .dlgOpen.Filter = "GerSCore Projekte (*.gsProj)|*.gsProj"
                If IO.Directory.Exists(My.Settings.RecentPath) Then .dlgOpen.InitialDirectory = My.Settings.RecentPath
                If .dlgOpen.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Path = .dlgOpen.FileName
                Else
                    Exit Sub
                End If
            End If
        End With
        If IO.File.Exists(Path) Then
            Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
            _fs = New FileStream(Path, FileMode.Open)
            Debug.Print(Path.ToString)
            _project = CType(bf.Deserialize(_fs), clsProjekt)
            _project.Project_initiated(True)
            Debug.Print("geladen")
            _fs.Close()
            My.Settings.RecentPath = Path
            MenuRecentProjects_Add(Path)
        Else
            MsgBox("Der Pfad wurde nicht gefunden!", MsgBoxStyle.Critical, "Projekt Öffnen gescheitert!")
        End If

        RaiseEvent ProjectInit()

        clsProgramm.DebugPrefix -= 1
    End Sub

    Private Sub Project_Save(ByVal SaveAtPath As Boolean) Handles _mainform.ProjectSave
        Dim _type As String = "Event"
        Dim _structname As String = "Project_Save"
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        Dim Path As String
        Dim fs As FileStream

        With _mainform
            If SaveAtPath Then
                Path = _project.Path
            Else
                .dlgSave.Filter = "GerSCore Projekte (*.gsProj)|*.gsProj"
                If IO.Directory.Exists(My.Settings.RecentPath) Then .dlgSave.InitialDirectory = My.Settings.RecentPath
                If .dlgSave.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Path = .dlgSave.FileName
                Else
                    Exit Sub
                End If
            End If
            Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
            fs = New FileStream(Path, FileMode.Create)
            Debug.Print(Path.ToString)
            bf.Serialize(fs, _project)
            Debug.Print("gespeichert")
            fs.Close()
            My.Settings.RecentPath = Path
            '_path = Path
            RaiseEvent ProjectSaved()
        End With

        clsProgramm.DebugPrefix -= 1
    End Sub

    Private Sub Project_Init() Handles Me.ProjectInit
        Dim _type As String = "Event"
        Dim _structname As String = "Project_Init"
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        _mainform.DatenToolStripMenuItem.Enabled = True
        _mainform.SpeichernunterToolStripMenuItem.Enabled = True
        _mainform.pnlProjekt.Visible = True
        If Not Project.Path = "" Then
            _mainform.SpeichernToolStripMenuItem.Enabled = True
        End If

        clsProgramm.DebugPrefix -= 1
    End Sub

    Private Sub RecentProject_Click(Sender As Object, e As EventArgs)
        Dim _type As String = "Event"
        Dim _structname As String = "RecentProject_Click"
        Dim _name As String = Sender.ToString
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name)

        Project_Open(CType(Sender, ToolStripMenuItem).Text)
        RaiseEvent ProjectInit()

        clsProgramm.DebugPrefix -= 1
    End Sub

    Private Sub Title_update() Handles _project.SaveStatusChanged, Me.ProjectInit
        Dim _type As String = "Event"
        Dim _structname As String = "Title_update"
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        With _mainform
            .Text = "GerScore - Gerber Shift Correction - " & _project.Name
            If Not _project.SaveStatus Then
                .Text = .Text & "*"
            End If
        End With

        clsProgramm.DebugPrefix -= 1
    End Sub

    Private Sub Project_Namechanged() Handles _project.NameChanged, Me.ProjectInit
        Dim _type As String = "Event"
        Dim _structname As String = "Project_Namechanged"
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        _mainform.lblProjectName.Text = Project.Name

        clsProgramm.DebugPrefix -= 1
    End Sub

    Private Sub Tests_init() Handles _mainform.TestInit
        Dim _type As String = "Event"
        Dim _structname As String = "Tests_init"
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        Project.AddPart("Testpart1")
        Project.AddPart("Testpart2")
        Project.AddPart("Testpart3")
        Project.Parts(0).AddGerber("Testgerber1")
        Project.Parts(0).AddGerber("Testgerber2")
        Project.Parts(1).AddGerber("Testgerber1")
        Project.Parts(1).AddGerber("Testgerber2")
        Project.Parts(2).AddGerber("Testgerber1")
        Project.Parts(2).AddGerber("Testgerber2")

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

        clsProgramm.DebugPrefix -= 1
    End Sub

End Class
