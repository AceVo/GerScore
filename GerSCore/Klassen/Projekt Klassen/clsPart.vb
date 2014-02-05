<Serializable> Public Class clsPart

    Private _className As String = "clsPart"

    Private _name As String
    Private _gerber As New List(Of clsGerber)

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Public Sub New(ByVal Name As String)
        Dim _type As String = "Sub"
        Dim _structname As String = "New"
        _name = Name
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name)

        clsProgram.DebugPrefix -= 1
    End Sub

    Public Sub New()
        Dim _type As String = "Sub"
        Dim _structname As String = "New"
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2}", _className, _type, _structname)

        clsProgram.DebugPrefix -= 1
    End Sub

    '####################################################################################################
    'Methoden
    '####################################################################################################

    Public Sub AddGerber(ByVal Name As String)
        Dim _type As String = "Sub"
        Dim _structname As String = "AddGerber"
        Dim _name2 = Name
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3} -> {4}", _className, _type, _structname, _name, _name2)

        Me.Gerber.Add(New clsGerber(Name, Me))

        clsProgram.DebugPrefix -= 1
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
            Return clsProgram.MainController.Project.Parts.IndexOf(Me)
        End Get
    End Property

    '####################################################################################################
    'Events
    '####################################################################################################

End Class
