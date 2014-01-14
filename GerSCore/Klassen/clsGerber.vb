<Serializable> Public Class clsGerber

    Private _className As String = "clsGerber"

    Private _name As String
    Private _color As Color
    Private _parent As clsPart
    Private _shapes As New List(Of clsShapes)

    Friend Event ColorChanged_Before()
    Friend Event ColorChanged_After()

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Public Sub New(ByRef Parent As clsPart)
        Dim _type As String = "Sub"
        Dim _structname As String = "New(Parent)"
        _name = InputBox("Bezeichnung des Gerbers eingeben", "Gerbername")
        frmMain.DebugPrefix += 1 : Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name)

        _parent = Parent
        Call Me.init() 'Anweisung für alle Konstruktoren gültig

        Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Leave in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name) : frmMain.DebugPrefix -= 1
    End Sub

    Public Sub New(ByVal Name As String, ByRef Parent As clsPart)
        Dim _type As String = "Sub"
        Dim _structname As String = "New(Name, Parent)"
        Me.Name = Name
        frmMain.DebugPrefix += 1 : Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name)

        _parent = Parent
        Call Me.init() 'Anweisung für alle Konstruktoren gültig

        Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Leave in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name) : frmMain.DebugPrefix -= 1
    End Sub

    Private Sub init()
        ' *****************************************************
        ' Anweisungen für alle Konstruktoren
        ' *****************************************************
        Dim _type As String = "Sub"
        Dim _structname As String = "init"
        frmMain.DebugPrefix += 1 : Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name)

        Me.Color = RandomColor()

        Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Leave in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name) : frmMain.DebugPrefix -= 1
    End Sub

    '####################################################################################################
    'Methoden
    '####################################################################################################

    '####################################################################################################
    'Funktionen
    '####################################################################################################

    Private Function RandomColor() As Color
        '****************************************************************************************************
        'Gibt eine Zufallsfarbe aus der Palette der KnownColors der Systemfarben ausschließlich der Standard
        'Formfarben zurück.
        '*  Es wird geprüft, ob diese Farbe bereits verwendet wurde und wenn ja, die Funktion
        '   erneut aufgerufen.
        '*  Es wird geprüft, ob die Farbe der Hintergrundfarbe des GerberZeichenElements entspricht und wenn
        '   ja, die Funktion erneut aufgerufen
        '****************************************************************************************************

        Dim farbe As Color = Color.FromName([Enum].GetNames(GetType(KnownColor))(frmMain.rnd.Next(28, 167)))
        If frmMain.UsedColor.Contains(farbe) Then
            farbe = RandomColor()
        End If

        Return farbe

    End Function

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

    Property Color As Color
        Get
            Return _color
        End Get
        Set(ByVal value As Color)
            If Not frmMain.UsedColor.Contains(value) Or value = _color Then
                frmMain.UsedColor.Remove(_color)
                frmMain.UsedColor.Add(value)
                _color = value
                RaiseEvent ColorChanged_After()
            Else
                MsgBox("Diese Farbe wird bereits verwendet! Wählen Sie eine andere Farbe aus.", MsgBoxStyle.Critical)
                With frmMain.dlgColor
                    .Color = _color
                    If .ShowDialog() = DialogResult.OK Then
                        Me.Color = .Color
                    End If
                End With
            End If
        End Set
    End Property

    ReadOnly Property Parent As clsPart
        Get
            Return _parent
        End Get
    End Property

    ReadOnly Property Level As Integer
        Get
            Return Me.Parent.Gerber.IndexOf(Me)
        End Get
    End Property

    Property Shapes As List(Of clsShapes)
        Get
            Return _shapes
        End Get
        Set(value As List(Of clsShapes))
            _shapes = value
        End Set
    End Property

    '####################################################################################################
    'Events
    '####################################################################################################

End Class
