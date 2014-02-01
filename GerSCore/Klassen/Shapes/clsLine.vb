<Serializable> Public Class clsLine
    Inherits clsShapes

    Private _className As String = "clsLine"

    Private _startpoint As Point
    Private _endpoint As Point

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Sub New(ByVal Parent As clsGerber, ByVal StartPoint As Point, ByVal EndPoint As Point, Optional ByVal Unit As String = "mm")
        Dim _type As String = "Sub"
        Dim _structname As String = "New"
        Dim _name = Parent.Name
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3} -> {4} : {5}", _className, _type, _structname, _name, StartPoint, EndPoint)

        Me.Parent = Parent
        Me.StartPoint = StartPoint
        Me.EndPoint = EndPoint

        Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Leave in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name) : clsProgram.DebugPrefix -= 1
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
    Property StartPoint As Point
        Get
            Return _startpoint
        End Get
        Set(value As Point)
            _startpoint = value
        End Set
    End Property

    Property EndPoint As Point
        Get
            Return _endpoint
        End Get
        Set(value As Point)
            _endpoint = value
        End Set
    End Property

    '####################################################################################################
    'Events
    '####################################################################################################

End Class
