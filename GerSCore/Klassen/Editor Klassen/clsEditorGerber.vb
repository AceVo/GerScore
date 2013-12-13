Public Class clsEditorGerber
    Inherits clsEditorItem
    '####################################################################################################
    'Deklaration
    '####################################################################################################

    Private WithEvents _gerber As clsGerber
    Protected _sc As New PowerPacks.ShapeContainer
    Private _editorpart As clsEditorPart
    Private _colorpicker As clsColorPicker

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Public Sub New(ByVal Gerber As clsGerber, ByVal EditorPart As clsEditorPart, ByVal Editor As clsEditor)
        frmMain.DebugPrefix += 1 : Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Enter in: {0} Sub ->  {1}", "clsEditorGerber", "New")

        _gerber = Gerber
        _editorpart = EditorPart
        _editor = Editor
        _editor.EditorGerber.Add(_gerber.Parent.Name & "\" & _gerber.Name, Me)
        With _sc
            .Parent = _editorpart.Container
            _sc.Parent.Controls.SetChildIndex(_sc, 0)
            .Name = _gerber.Name
            .Location = New Point(0, 0)
            .BackColor = Color.Transparent
            '.AutoScroll = True
            ' AddHandler .Paint, AddressOf _editor.Canvas.PaintTest
        End With
        _colorpicker = New clsColorPicker(_editor, _gerber)

        If _editor.Layerviewer = True Then
            _editor.Layertree.Nodes(_gerber.Parent.Level).Nodes.Insert(_gerber.Level, _gerber.Name)
            _editor.Layertree.Nodes(_gerber.Parent.Level).Nodes(_gerber.Level).Checked = True
        End If

        For Each Shape As clsShapes In _gerber.Shapes
            Select Case Shape.GetType.Name
                Case GetType(clsLine).Name
                    Dim Line As clsLine = CType(Shape, clsLine)
                    Dim drawLine As New clsDrawLine(_gerber, _editor, Line.StartPoint, Line.EndPoint)
                    _sc.Shapes.Add(drawLine)
            End Select
        Next

        Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Leave in: {0} Sub ->  {1}", "clsEditorGerber", "New") : frmMain.DebugPrefix -= 1
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

    ReadOnly Property Name As String
        Get
            Return _gerber.Name
        End Get
    End Property

    ReadOnly Property ColorPicker As clsColorPicker
        Get
            Return _colorpicker
        End Get
    End Property

    Property Visible As Boolean
        Get
            Return _sc.Visible
        End Get
        Set(value As Boolean)
            _sc.Visible = value
        End Set
    End Property

    '####################################################################################################
    'Events
    '####################################################################################################

    Private Sub ColorChange() Handles _gerber.ColorChanged_After
        For Each DrawShape As IShape In _sc.Shapes
            DrawShape.Color = _gerber.Color
        Next
        _colorpicker.BackColor = _gerber.Color
    End Sub

End Class
