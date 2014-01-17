<Serializable> Public Class clsPart

    Private _className As String = "clsPart"

    <NonSerialized> Private Main As clsMainController = clsProgramm.MainController

    Private _name As String
    Private _gerber As New List(Of clsGerber)

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Public Sub New(ByVal Name As String)
        Dim _type As String = "Sub"
        Dim _structname As String = "New"
        _name = Name
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name)

        Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Leave in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name) : clsProgramm.DebugPrefix -= 1
    End Sub

    '####################################################################################################
    'Methoden
    '####################################################################################################

    Public Sub AddGerber(ByVal Name As String)
        Dim _type As String = "Sub"
        Dim _structname As String = "AddGerber"
        Dim _name2 = Name
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3} -> {4}", _className, _type, _structname, _name, _name2)

        Me.Gerber.Add(New clsGerber(Name, Me))

        Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Leave in: {0} {1} ->  {2} : {3} -> {4}", _className, _type, _structname, _name, _name2) : clsProgramm.DebugPrefix -= 1
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
        End Set
    End Property

    Property Gerber As List(Of clsGerber)
        Get
            Return _gerber
        End Get
        Set(value As List(Of clsGerber))
            _gerber = value
        End Set
    End Property

    ReadOnly Property Level As Integer
        Get
            Return Main.Project.Parts.IndexOf(Me)
        End Get
    End Property

    '####################################################################################################
    'Events
    '####################################################################################################

End Class
