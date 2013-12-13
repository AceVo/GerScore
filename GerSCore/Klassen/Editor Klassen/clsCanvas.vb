Public Class clsCanvas
    Inherits PictureBox


    '####################################################################################################
    'Deklaration
    '####################################################################################################

    Private _creater As clsEditor
    Private _zoomfactor As Double = 1
    Private _snaprange As Integer = 10
    Private _screen As New PowerPacks.ShapeContainer

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Sub New(ByVal Creater As clsEditor)
        frmMain.DebugPrefix += 1 : Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Enter in: {0} Sub ->  {1}", "clsCanvas", "New")

        _creater = Creater
        With _screen
            .Parent = Me
            .BackColor = Color.Transparent
            .Anchor = AnchorStyles.None
            .Dock = DockStyle.Fill
            '  .Size = New Size(14300000, 14300000)
        End With

        Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Leave in: {0} Sub ->  {1}", "clsCanvas", "New") : frmMain.DebugPrefix -= 1
    End Sub
    '####################################################################################################
    'Methoden
    '####################################################################################################

    Private Sub Object_fangen(ByVal MousePosition As Point)
        Dim Shape As IShape
        Shape = GetNextObject(MousePosition, _snaprange) 'konzentrische rechteckige Objektsuche an der Mausposition mit max. Abstand ("Ringweise")
        If Not IsNothing(Shape) Then
            Cursor.Position = Me.PointToScreen(Shape.GetClosestSnapPoint(MousePosition))
            Shape.Fokussieren()
        End If
    End Sub

    Private Sub WriteCoordinates()
        _creater.StatusMouse.Text = "X: " & (Me.PointToClient(Cursor.Position).X / _zoomfactor).ToString("#.00") & " mm" & _
                                 "   Y: " & (Me.PointToClient(Cursor.Position).Y / _zoomfactor).ToString("#.00") & " mm"
    End Sub

    Sub ZoomToAll()
        Dim _newzoomfactor As Single
        Dim _zoomrectangle As New Rectangle(Me.Width, Me.Height, 0, 0)
        For Each PartLayer As PowerPacks.ShapeContainer In Me.Screen.Controls
            For Each GerberLayer As PowerPacks.ShapeContainer In PartLayer.Controls
                For Each DrawElement As IShape In GerberLayer.Shapes
                    With DrawElement.Bounds
                        If .X < _zoomrectangle.X Then _zoomrectangle.X = .X
                        If .Y < _zoomrectangle.Y Then _zoomrectangle.Y = .Y
                        If .X + .Width > _zoomrectangle.X + _zoomrectangle.Width Then _zoomrectangle.Width = (.X + .Width - _zoomrectangle.X)
                        If .Y + .Height > _zoomrectangle.Y + _zoomrectangle.Height Then _zoomrectangle.Height = (.Y + .Height - _zoomrectangle.Y)
                    End With
                Next
            Next
        Next
        _newzoomfactor = CSng(Me.Width / _zoomrectangle.Width)
        If Me.Height / _zoomrectangle.Height > _newzoomfactor Then _newzoomfactor = CSng(Me.Height / _zoomrectangle.Height)
        _newzoomfactor = CSng(Math.Floor(_newzoomfactor * _zoomfactor) / _zoomfactor)
        Me.Zoom(_newzoomfactor)
        _screen.Location = New Point(0, 0)
    End Sub

    Sub Zoom(ByVal Factor As Single)
        _zoomfactor = _zoomfactor * Factor
        For Each Part As PowerPacks.ShapeContainer In Me.Screen.Controls
            For Each Gerber As PowerPacks.ShapeContainer In Part.Controls
                For Each Shape As PowerPacks.Shape In Gerber.Shapes
                    Debug.Print(Today.ToString)
                    Shape.Scale(New SizeF(Factor, Factor))
                Next
            Next
        Next
        _screen.Location = New Point(CInt((_screen.Location.X * Factor) - (Me.Width / Factor)), CInt((_screen.Location.Y * Factor) - (Me.Height / Factor)))
        Me.ScreenMiddlepoint(Factor) = PointToClient(Control.MousePosition)
        Me.Refresh()
    End Sub

    '####################################################################################################
    'Funktionen
    '####################################################################################################

    Private Function GetNextObject(ByVal MousePosition As Point, ByVal MaxRange As Integer, Optional ByVal aktRange As Integer = 1) As IShape

        '####################################################################################################
        'konzentrische rechteckige Objektsuche an der Mausposition mit max. Abstand ("Ringweise")
        '   MousePosition:  aktuelle Mausposition in Bilds chirmkoordinaten
        '   MaxRange:       bis zu welchem Abstand von der Mausposition gesucht werden soll (rekursiv)
        '   aktRange:       Indikator für den aktuell abgesuchten "Ring"
        '
        '             -   -  
        '             X   X
        '             M   M
        '             a   a
        '             x   x
        '             -   -
        '
        '    |+YMax|  /---\
        '             |   | 
        '             | X |
        '             |   |
        '    |-YMax|  \---/
        '####################################################################################################

        Dim Shape As IShape
        Dim ShapeCollection As New SortedList   ' Sammlung für die gefundenen Shapes innerhalb des aktuellen "Rings"

        For Each PartContainer As PowerPacks.ShapeContainer In Me.Controls                                ' Durchsuchen aller Partcontainer
            If PartContainer.Visible = True Then                                                    '   - die sichtbar sind
                For Each GerberContainer As PowerPacks.ShapeContainer In PartContainer.Controls     ' Durchsuchen aller Gerbercontainer in den Partcontainern
                    If GerberContainer.Visible = True Then                                          '   - die sichtbar sind
                        For Y As Integer = -aktRange To aktRange
                            For X As Integer = -aktRange To aktRange
                                If Math.Abs(Y) = aktRange Or Math.Abs(X) = aktRange Then            ' Wenn es sich um den äußeren Rand handelt... s. Grafik
                                    Shape = CType(GerberContainer.GetChildAtPoint(New Point(MousePosition.X + X, MousePosition.Y + Y)), IShape)
                                    If Not IsNothing(Shape) Then                                    ' Wenn etwas gefunden wurde...
                                        If Not ShapeCollection.ContainsKey(Shape.Level) Then              ' ... und es noch nicht in der Sammlung vorhanden ist...
                                            ShapeCollection.Add(Shape.Level, Shape)                       ' ... füge es der Sammlung hinzu (Zeichenebene des Shapes, Shape)
                                        End If
                                    End If
                                End If
                            Next
                        Next
                    End If
                Next
            End If
        Next

        If ShapeCollection.Count = 0 And aktRange < MaxRange Then                                   ' Wenn die Sammlung leer ist und noch nicht die maximale Suchreichweite erreicht wurde...
            aktRange += 1                                                                           '   ...erhöhe die Suchreichweite um 1
            Shape = GetNextObject(MousePosition, MaxRange, aktRange)                                '   ...rufe dich selbst wieder auf, mit erhöhter Reichweite
            If Not IsNothing(Shape) Then
                ShapeCollection.Add(Shape.Level, Shape)
            End If
        End If

        If ShapeCollection.Count = 0 Then                                                           ' Wenn die Sammlung leer ist...
            Return Nothing                                                                          '   ...gebe 'Nothing' zurück
        Else
            Return CType(ShapeCollection.GetByIndex(0), IShape)                                     ' ...ansonsten...
        End If

    End Function

    '####################################################################################################
    'Property
    '####################################################################################################

    ReadOnly Property Zoomfactor As Double
        Get
            Return _zoomfactor
        End Get
    End Property

    Property Snaprange As Integer
        Get
            Return _snaprange
        End Get
        Set(ByVal value As Integer)
            _snaprange = value
        End Set
    End Property

    ReadOnly Property Screen As PowerPacks.ShapeContainer
        Get
            Return _screen
        End Get
    End Property

    Property ScreenMiddlepoint(Optional ByVal Factor As Double = 1) As Point
        Get
            Return New Point((-Screen.Location.X) + CInt(Me.Width / 2), (-_screen.Location.Y) + CInt(Me.Height / 2))
        End Get
        Set(value As Point)
            Dim OffsetX As Integer = CInt((Me.Width / 2) - value.X)
            Dim OffsetY As Integer = CInt((Me.Height / 2) - value.Y)
            _screen.Location = New Point(CInt(_screen.Location.X + (OffsetX * Factor)), CInt(_screen.Location.Y + OffsetY * Factor))
            Debug.Print("Screen Location after Change: " & _screen.Location.ToString)
        End Set
    End Property

    '####################################################################################################
    'Events
    '####################################################################################################

    Private Sub clsCanvas_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Select Case e.Button
            Case MouseButtons.Left
                Object_fangen(e.Location)
                Debug.Print("X: " & Me.PointToClient(Cursor.Position).X & "   Y:" & Me.PointToClient(Cursor.Position).Y & _
                            "    X unit: " & (Me.PointToClient(Cursor.Position).X / _zoomfactor).ToString("#.00") & " mm" & _
                      "   Y unit: " & (Me.PointToClient(Cursor.Position).Y / _zoomfactor).ToString("#.00") & " mm Scalefactor: " & _zoomfactor)
                Debug.Print(Me.PointToScreen(Me.Location).ToString)
                Debug.Print(Me.PointToScreen(Me.Screen.Location).ToString)
            Case MouseButtons.Right
                Me.Zoom(2)
                Debug.Print("MousePosition: " & PointToClient(Control.MousePosition).ToString)
        End Select
    End Sub

    Friend Sub clsCanvas_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        If Not Me.RectangleToScreen(Me.ClientRectangle).Contains(Cursor.Position) Then
            _creater.StatusMouse.Text = "X: ... Y: ..."
            _creater.Statusline.Text = "..."
        End If
    End Sub

    Friend Sub clsCanvas_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        WriteCoordinates()
        _creater.Statusline.Text = sender.ToString
    End Sub
End Class
