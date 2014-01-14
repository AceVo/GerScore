Imports System.IO
<Serializable> Public Class clsProjekt

    Private _className As String = "clsProject"

    Private Shared mobjSingletonProject As clsProjekt
    Private _name As String
    Private _saved As Boolean = False
    <NonSerialized> Private _path As String

    Public Parts As New List(Of clsPart)

    Private Event Project_changed()
    Private Event Project_saved()


    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Private Sub New()
        Dim _type As String = "Sub"
        Dim _structname As String = "New"
        _name = "Neues Projekt"
        frmMain.DebugPrefix += 1 : Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name)

        Project_initiated()

        Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Leave in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name) : frmMain.DebugPrefix -= 1
    End Sub

    Protected Friend Sub Project_initiated(Optional ByVal Loaded As Boolean = False)
        Dim _type As String = "Sub"
        Dim _structname As String = "Project_initiated"
        frmMain.DebugPrefix += 1 : Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name)

        frmMain.DatenToolStripMenuItem.Enabled = True
        frmMain.pnlProjekt.Visible = True
        frmMain.SpeichernunterToolStripMenuItem.Enabled = True

        If Loaded = True Then
            frmMain.SpeichernToolStripMenuItem.Enabled = True
            _path = My.Settings.RecentPath
            _saved = True
            Title_update()
        Else
            RaiseEvent Project_changed()
        End If

        Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Leave in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name) : frmMain.DebugPrefix -= 1
    End Sub

    '####################################################################################################
    'Methoden
    '####################################################################################################

    Public Sub AddPart(ByVal Name As String)
        Dim _type As String = "Method"
        Dim _structname As String = "AddPart"
        Dim _name2 = Name
        frmMain.DebugPrefix += 1 : Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3} -> {4}", _className, _type, _structname, _name, _name2)

        Me.Parts.Add(New clsPart(Name))

        RaiseEvent Project_changed()

        Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Leave in: {0} {1} ->  {2} : {3} -> {4}", _className, _type, _structname, _name, _name2) : frmMain.DebugPrefix -= 1
    End Sub

    Public Sub Save(Optional ByVal Path As String = "")
        Dim fs As FileStream
        With frmMain

            If Path = "" Then
                .dlgSave.Filter = "GerSCore Projekte (*.gsProj)|*.gsProj"
                If IO.Directory.Exists(My.Settings.RecentPath) Then .dlgSave.InitialDirectory = My.Settings.RecentPath
                If .dlgSave.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Path = .dlgSave.FileName
                End If
            End If
            Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
            fs = New FileStream(Path, FileMode.Create)
            Debug.Print(Path.ToString)
            bf.Serialize(fs, Me)
            Debug.Print("gespeichert")
            fs.Close()
            My.Settings.RecentPath = Path
            _path = Path
            RaiseEvent Project_saved()
        End With
    End Sub

    Private Sub Title_update()
        frmMain.Text = "GerScore - Gerber Shift Correction - " & Me.Name
        If Not _saved Then
            frmMain.Text = frmMain.Text & "*"
        End If
    End Sub
    '####################################################################################################
    'Funktionen
    '####################################################################################################


    '####################################################################################################
    'Property
    '####################################################################################################

    Property Name As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value

            RaiseEvent Project_changed()
        End Set
    End Property

    ReadOnly Property Path As String
        Get
            Return _path
        End Get
    End Property

    ''' <summary>
    ''' Project Singleton Instance
    ''' </summary>
    ''' <value></value>
    ''' <returns>Gibt eine Instanz der Klasse clsProject zurück</returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property Instance As clsProjekt
        Get
            If IsNothing(mobjSingletonProject) Then
                mobjSingletonProject = New clsProjekt
            End If

            Return mobjSingletonProject
        End Get
    End Property

    '####################################################################################################
    'Events
    '####################################################################################################

    Private Sub Project_edited() Handles Me.Project_changed
        _saved = False
        Title_update()
    End Sub

    Private Sub Project_save() Handles Me.Project_saved
        _saved = True
        frmMain.SpeichernToolStripMenuItem.Enabled = True
        frmMain.MenuRecentProjects_Add(_path)
        frmMain.MenuRecentProjectsInit()
        Title_update()
    End Sub
End Class
