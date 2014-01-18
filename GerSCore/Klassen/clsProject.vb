Imports System.IO
<Serializable> Public Class clsProjekt

    Private _className As String = "clsProject"

    Private Shared mobjSingletonProject As clsProjekt
    Private _name As String
    Private _saved As Boolean = False
    <NonSerialized> Private _path As String
    <NonSerialized> Private WithEvents _controller As clsMainController

    Friend Parts As New List(Of clsPart)

    Private Event Loaded()
    Private Event Created()
    <NonSerialized> Friend Event SaveStatusChanged()
    <NonSerialized> Friend Event NameChanged()
    <NonSerialized> Friend Event PartAdded()


    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Private Sub New()
        Dim _type As String = "Sub"
        Dim _structname As String = "New"
        _name = "Neues Projekt"
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name)

        Project_initiated()

        Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Leave in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name) : clsProgramm.DebugPrefix -= 1
    End Sub

    Friend Sub Project_initiated(Optional ByVal Loaded As Boolean = False)
        Dim _type As String = "Sub"
        Dim _structname As String = "Project_initiated"
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name)

        _controller = clsProgramm.MainController

        If Loaded Then
            clsProgramm.MainForm.SpeichernToolStripMenuItem.Enabled = True
            RaiseEvent Loaded()
        Else
            RaiseEvent Created()
        End If

        Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Leave in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name) : clsProgramm.DebugPrefix -= 1
    End Sub

    '####################################################################################################
    'Methoden
    '####################################################################################################

    Friend Sub AddPart(ByVal Name As String)
        Dim _type As String = "Method"
        Dim _structname As String = "AddPart"
        Dim _name2 = Name
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3} -> {4}", _className, _type, _structname, _name, _name2)

        Me.Parts.Add(New clsPart(Name))

        RaiseEvent PartAdded()

        clsProgramm.DebugPrefix -= 1
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
            RaiseEvent NameChanged()
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

    ReadOnly Property SaveStatus As Boolean
        Get
            Return _saved
        End Get
    End Property

    '####################################################################################################
    'Events
    '####################################################################################################

    Private Sub Project_edited() Handles Me.NameChanged, Me.PartAdded, Me.Created
        Dim _type As String = "Event"
        Dim _structname As String = "Project_edited"
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        _saved = False
        RaiseEvent SaveStatusChanged()

        clsProgramm.DebugPrefix -= 1
    End Sub

    Private Sub Project_save() Handles Me.Loaded, _controller.ProjectSaved
        Dim _type As String = "Event"
        Dim _structname As String = "Project_save"
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        _saved = True
        _path = My.Settings.RecentPath
        RaiseEvent SaveStatusChanged()

        clsProgramm.DebugPrefix -= 1
    End Sub

End Class
