Public Class clsDrawLine

    Inherits PowerPacks.LineShape
    Implements IShape

    Private _classname As String = "clsDrawLine"

    Private _snappoints As New List(Of Point)
    Private _color As Color
    Private _focuscolor As Color = Color.Red
    Private _gerber As clsGerber
    Private WithEvents _editor As clsEditor
    Private _unit As String
    Private _ustartpoint As Point
    Private _uendpoint As Point
    Private WithEvents _canvas As clsCanvas
    Private _disposed As Boolean = False

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Sub New(ByRef Gerber As clsGerber, ByVal Editor As clsEditor, _
            ByVal StartPoint_w_Unit As Point, ByVal EndPoint_w_Unit As Point, Optional ByVal Unit As String = "mm")
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} Sub ->  {1}", "clsDrawLine", "New")

        Me.Gerber = Gerber
        Me.UStartPoint = StartPoint_w_Unit
        Me.UEndPoint = EndPoint_w_Unit
        Me.StartPoint = New Point(Me.UStartPoint.X * CInt(Editor.Scalefactor), Me.UStartPoint.Y * CInt(Editor.Scalefactor))
        Me.EndPoint = New Point(Me.UEndPoint.X * CInt(Editor.Scalefactor), Me.UEndPoint.Y * CInt(Editor.Scalefactor))
        _editor = Editor
        Me.BorderWidth = 5
        _canvas = _editor.Canvas

        Me.init()

        clsProgramm.DebugPrefix -= 1
    End Sub

    '####################################################################################################
    'Methoden
    '####################################################################################################

    Private Sub init()
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} Sub ->  {1}", "clsDrawLine", "init")

        Me.BorderColor = Me.Color
        Me.BorderStyle = Drawing2D.DashStyle.Solid
        Me.SelectionColor = Drawing.Color.Transparent
        AddHandler Me.MouseMove, AddressOf _canvas.clsCanvas_MouseMove
        AddHandler Me.MouseLeave, AddressOf _canvas.clsCanvas_MouseLeave

        clsProgramm.DebugPrefix -= 1
    End Sub

    Private Sub calc_snappoints() Handles Me.StartPointChanged, Me.EndPointChanged
        _snappoints.Clear()
        _snappoints.Add(Me.StartPoint)
        _snappoints.Add(Me.EndPoint)
        _snappoints.Add(Me.MiddlePoint)
    End Sub

    Private Sub Fokussieren() Implements IShape.Fokussieren
        Me.Focus()
        Me.OnMouseMove(Nothing)
    End Sub

    Overloads Sub Dispose()
        Dispose(_disposed)
    End Sub

    Protected Overloads Sub Dispose(ByVal disposing As Boolean)
        Dim _type As String = "Sub"
        Dim _structname As String = "Dispose"
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2}", _classname, _type, _structname)

        If Not disposing Then
            _snappoints = Nothing
            _gerber = Nothing
            _editor = Nothing
            RemoveHandler Me.MouseMove, AddressOf _canvas.clsCanvas_MouseMove
            RemoveHandler Me.MouseLeave, AddressOf _canvas.clsCanvas_MouseLeave
            _canvas = Nothing
            _disposed = True
        End If

        Me.Events.Dispose()

        clsProgramm.DebugPrefix -= 1
    End Sub

    '####################################################################################################
    'Funktionen
    '####################################################################################################

    Function GetClosestSnapPoint(ByVal Mouseposition As Point) As Point Implements IShape.GetClosestSnapPoint

        Dim Abstand As Double
        Dim gefAbstand As Double = Nothing
        Dim Punkt As Point

        For Each Fangpunkt As Point In _snappoints
            Abstand = Math.Sqrt(Math.Pow((Mouseposition.X - Fangpunkt.X), 2) + Math.Pow((Mouseposition.Y - Fangpunkt.Y), 2))
            If Abstand < gefAbstand Or gefAbstand = 0 Then
                gefAbstand = Abstand
                Punkt = Fangpunkt
            End If
        Next

        Return Punkt

    End Function

    '####################################################################################################
    'Property
    '####################################################################################################

    ReadOnly Property SnapPoints As List(Of Point)
        Get
            Return _snappoints
        End Get
    End Property

    ReadOnly Property MiddlePoint As Point
        Get
            Dim Mittelpunkt_X As Integer
            Dim Mittelpunkt_Y As Integer
            Mittelpunkt_X = CInt(((Me.EndPoint.X - Me.StartPoint.X) / 2) + Me.StartPoint.X)
            Mittelpunkt_Y = CInt(((Me.EndPoint.Y - Me.StartPoint.Y) / 2) + Me.StartPoint.Y)
            Return New Point(Mittelpunkt_X, Mittelpunkt_Y)
        End Get
    End Property

    Property Unit As String
        Get
            Return _unit
        End Get
        Set(value As String)
            _unit = value
        End Set
    End Property

    Property UStartPoint As Point
        Get
            Return _ustartpoint
        End Get
        Set(value As Point)
            _ustartpoint = value
        End Set
    End Property

    Property UEndPoint As Point
        Get
            Return _uendpoint
        End Get
        Set(value As Point)
            _uendpoint = value
        End Set
    End Property

    ReadOnly Property Level As Single Implements IShape.Level
        Get
            Return CSng(_gerber.Parent.Level + (_gerber.Level / 10))
        End Get
    End Property

    Property Gerber As clsGerber
        Get
            Return _gerber
        End Get
        Set(ByVal value As clsGerber)
            _gerber = value
        End Set
    End Property

    Property Color As Color Implements IShape.Color
        Get
            _color = Me.Gerber.Color
            Return _color
        End Get
        Set(value As Color)
            _color = value
            Me.BorderColor = _color
        End Set
    End Property

    ReadOnly Property Bounds As Rectangle Implements IShape.Bounds
        Get
            Return New Rectangle(Me.StartPoint.X, Me.StartPoint.Y, Me.EndPoint.X - Me.StartPoint.X, Me.EndPoint.Y - Me.StartPoint.Y)
        End Get
    End Property

    '####################################################################################################
    'Events
    '####################################################################################################

    Private Sub clsLine_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.BorderColor = _focuscolor
    End Sub

    Private Sub clsLine_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.BorderColor = Me.Color
    End Sub


    Protected Overrides Sub Finalize()
        Debug.Print("clsDrawLine Finalize")
        MyBase.Finalize()
    End Sub
End Class
