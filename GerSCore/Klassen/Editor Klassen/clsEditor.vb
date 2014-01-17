Public Class clsEditor
    Implements IDisposable
    '####################################################################################################
    'Deklaration
    '####################################################################################################

    Private _className As String = "clsEditor"

    Private WithEvents pcbCanvas As New clsCanvas(Me)
    Private sstStatus As New StatusStrip
    Private WithEvents splContainerEditor As SplitContainer
    Private WithEvents splContainerCanvas As New SplitContainer
    Private WithEvents trvLayer As TreeView
    Private tstLayerViewer As ToolStrip
    Private WithEvents tsbTest As ToolStripButton
    Private pnlColor As Panel
    Private scColorPicker As PowerPacks.ShapeContainer
    Private tslStatusLabel As New ToolStripStatusLabel
    Private tslMousePos As New ToolStripStatusLabel

    Private _project As clsProjekt = clsProgramm.MainController.Project
    Private _backcolor As Color
    Private _target As Control
    Private _layerviewer As Boolean
    Private _EditorParts As New Dictionary(Of String, clsEditorPart)
    Private _EditorGerber As New Dictionary(Of String, clsEditorGerber)
    Private _unit As String = "mm"
    Private _disposed As Boolean = False

    Private Event CursorChanged()

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Sub New(ByVal Target As Control, Optional ByVal LayerViewer As Boolean = True)
        Dim _type As String = "Sub"
        Dim _structname As String = "New"
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2}", _className, _type, _structname)

        _target = Target
        _layerviewer = LayerViewer
        _backcolor = Color.Black
        frmMain.UsedColor.Add(_backcolor)

        AddHandler _target.FindForm.KeyDown, AddressOf KeyDown
        DrawMousePointer()

        If LayerViewer = True Then

            splContainerEditor = New SplitContainer
            trvLayer = New TreeView
            pnlColor = New Panel
            scColorPicker = New PowerPacks.ShapeContainer
            tstLayerViewer = New ToolStrip
            tsbTest = New ToolStripButton

            ' Splitcontainer zum einteilen in Layerviewer und Canvas-Feld
            With splContainerEditor
                .Parent = _target
                .Dock = DockStyle.Fill
                .SplitterWidth = 3
                .SplitterDistance = 300
                .Orientation = Orientation.Vertical
                .BorderStyle = BorderStyle.None
                .BackColor = Color.Transparent
                AddHandler .SizeChanged, AddressOf Me.SizeChanged
            End With

            ' Panel zur Anordnung der Colorpicker
            With pnlColor
                .Parent = splContainerEditor.Panel1
                .Dock = DockStyle.Right
                .BackColor = _backcolor
                .Width = 30
            End With

            With scColorPicker
                .Parent = pnlColor
                .Dock = DockStyle.Fill
            End With

            ' Treeview zur Anzeige der Parts und Gerber
            With trvLayer
                .Parent = splContainerEditor.Panel1
                .Dock = DockStyle.Left
                .BorderStyle = BorderStyle.None
                .CheckBoxes = True
                .BackColor = _backcolor
                .ForeColor = Color.White
                .Width = splContainerEditor.Panel1.Width - pnlColor.Width
            End With

            ' Buttonleiste
            With tstLayerViewer
                .Parent = splContainerEditor.Panel1
                .Dock = DockStyle.Top
                .GripStyle = ToolStripGripStyle.Hidden
                .Items.Add(tsbTest)
            End With

            ' Testbutton
            With tsbTest
                .Text = "A"
                '.Image = ???
            End With

        End If

        ' Splitcontainer zum Anordnen der Statusleiste und des Canvasfenster
        ' wird bei eingeschaltetem Layerviewer im 2. Panel platziert, ansonsten im Target-Objekt
        With splContainerCanvas
            If _layerviewer = True Then
                .Parent = splContainerEditor.Panel2
            Else
                .Parent = _target
            End If
            .Dock = DockStyle.Fill
            .SplitterWidth = 1
            .IsSplitterFixed = True
            .Orientation = Orientation.Horizontal
            .BorderStyle = BorderStyle.None
            .BackColor = Color.Transparent
            .Panel1.AutoScroll = True
        End With

        ' Statusleiste unterm Canvas Fenster
        With sstStatus
            .Parent = splContainerCanvas.Panel2
            .Dock = DockStyle.Bottom
            .Items.Add(tslStatusLabel)
            .Items.Add(tslMousePos)
        End With

        ' Statuslabel in der Statuseiste
        With tslStatusLabel
            .Spring = True
            .Text = "..."
            .BorderSides = ToolStripStatusLabelBorderSides.Right
        End With

        ' Anzeige der Mouseposition in der Statusleiste
        With tslMousePos
            .Text = "X: ... Y: ... "
        End With

        ' Canvas(Zeichnungsfläche)
        With pcbCanvas
            .Parent = splContainerCanvas.Panel1
            .Dock = DockStyle.Fill
            .BackColor = _backcolor
            .BorderStyle = BorderStyle.Fixed3D
        End With

        Daten_einlesen()
        Canvas.Screen.Location = New Point(0, 0)

        clsProgramm.DebugPrefix -= 1
    End Sub

    '####################################################################################################
    'Methoden
    '####################################################################################################

    Private Sub Daten_einlesen()
        Dim _type As String = "Sub"
        Dim _structname As String = "Daten_einlesen"
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2}", _className, _type, _structname)
        For Each Part As clsPart In _project.Parts
            Dim EditorPart As New clsEditorPart(Part, Me)
            For Each Gerber As clsGerber In Part.Gerber
                Dim EditorGerber As New clsEditorGerber(Gerber, EditorPart, Me)
            Next
        Next

        If _layerviewer Then trvLayer.ExpandAll()

        clsProgramm.DebugPrefix -= 1
    End Sub

    Private Sub DrawMousePointer() Handles Me.CursorChanged

        Dim Range As Integer
        Dim CursorPen As New Pen(Color.White, 1)
        Dim b As Bitmap

        If Canvas.Snaprange < 15 Then
            Range = 15
        Else
            Range = Canvas.Snaprange
        End If
        b = New Bitmap((2 * (Range + 1)), (2 * (Range + 1)))
        Dim gr As Graphics = Graphics.FromImage(b)

        gr.TranslateTransform(Range, Range)

        gr.DrawRectangle(CursorPen, New Rectangle(-Canvas.Snaprange, -Canvas.Snaprange, Canvas.Snaprange * 2, Canvas.Snaprange * 2))
        gr.DrawLine(CursorPen, New Point(0, 15), New Point(0, -15))
        gr.DrawLine(CursorPen, New Point(-15, 0), New Point(15, 0))
        Canvas.Cursor = New Cursor(b.GetHicon)

    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(_disposed)
    End Sub

    Protected Sub Dispose(ByVal disposing As Boolean)
        Dim _type As String = "Sub"
        Dim _structname As String = "Dispose"
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2}", _className, _type, _structname)


        If Not disposing Then

            RemoveHandler _target.FindForm.KeyDown, AddressOf KeyDown

            For Each Gerber As clsEditorGerber In _EditorGerber.Values
                Gerber.Dispose()
            Next
            _EditorGerber = Nothing
            For Each Part As clsEditorPart In _EditorParts.Values
                Part.Dispose()
            Next
            _EditorParts = Nothing

            sstStatus.Dispose()
            tslStatusLabel.Dispose()
            tslMousePos.Dispose()
            Canvas.Dispose()
            splContainerCanvas.Dispose()
            If Layerviewer = True Then
                For i = scColorPicker.Shapes.Count - 1 To 0 Step -1
                    CType(scColorPicker.Shapes.Item(i), clsColorPicker).Dispose()
                Next
                scColorPicker.Dispose()
                trvLayer.Dispose()
                tstLayerViewer.Dispose()
                tsbTest.Dispose()
                splContainerEditor.Dispose()
            End If
            _disposed = True
        End If
        clsProgramm.DebugPrefix -= 1
    End Sub

    '####################################################################################################
    'Funktionen
    '####################################################################################################


    '####################################################################################################
    'Property
    '####################################################################################################

    ReadOnly Property Canvas As clsCanvas
        Get
            Return pcbCanvas
        End Get
    End Property

    ReadOnly Property Layertree As TreeView
        Get
            Return trvLayer
        End Get
    End Property

    ReadOnly Property Statusline As ToolStripStatusLabel
        Get
            Return tslStatusLabel
        End Get
    End Property

    ReadOnly Property StatusMouse As ToolStripLabel
        Get
            Return tslMousePos
        End Get
    End Property

    ReadOnly Property ColorContainer As PowerPacks.ShapeContainer
        Get
            Return scColorPicker
        End Get
    End Property

    ReadOnly Property Layerviewer As Boolean
        Get
            Return _layerviewer
        End Get
    End Property

    ReadOnly Property EditorParts As Dictionary(Of String, clsEditorPart)
        Get
            Return _EditorParts
        End Get
    End Property

    ReadOnly Property EditorGerber As Dictionary(Of String, clsEditorGerber)
        Get
            Return _EditorGerber
        End Get
    End Property

    ReadOnly Property Scalefactor As Double
        Get
            Return Canvas.Zoomfactor
        End Get
    End Property

    '####################################################################################################
    'Events
    '####################################################################################################

    Private Sub trvLayer_AfterCheck(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) Handles trvLayer.AfterCheck
        '****************************************************************************************************
        'Aktionen, die beim Klick auf die Checkboxes des TreeView Controls geschehen
        'Ein- und Ausschalten der Layer
        '   entweder den gesamten Part, wenn Level=0
        '   oder nur das einzelne Gerberlayer, wenn Level=1
        '   außerdem wird geprüft, ob das entsprechende Element schon erzeugt wurde
        '   !!zum Aktualisieren wird die PictureBox refreshed
        '****************************************************************************************************
        If e.Node.Level = 0 AndAlso _EditorParts.ContainsKey(e.Node.Text) Then
            With _EditorParts(e.Node.Text)
                If e.Node.Checked Then
                    .Visible = True
                Else
                    .Visible = False
                End If
            End With
        ElseIf e.Node.Level = 1 AndAlso _EditorGerber.ContainsKey(e.Node.FullPath) Then
            With _EditorGerber(e.Node.FullPath)
                If e.Node.Checked Then
                    .Visible = True
                Else
                    .Visible = False
                End If
            End With
        End If
        Canvas.Invalidate()
    End Sub

    Friend Sub SizeChanged(sender As Object, e As EventArgs) Handles splContainerCanvas.SizeChanged
        splContainerCanvas.SplitterDistance = splContainerCanvas.Height - sstStatus.Height
        trvLayer.Width = splContainerEditor.Panel1.Width - pnlColor.Width
    End Sub

    Private Sub Refresh_ColorPickerPos() Handles trvLayer.AfterCollapse, trvLayer.AfterExpand
        ' ****************************************************************************************************
        ' Methode zum Repositionieren und Ein- und Ausschalten der Colorpicker
        ' ****************************************************************************************************

        Dim YPos As Integer = 0
        For Each nodepart As TreeNode In trvLayer.Nodes         ' Durchgehen aller Ober-Knotenpunkte
            YPos += trvLayer.ItemHeight                         ' Y-Pos um Itemhöhe erhöhen(Partnode)
            If nodepart.IsExpanded Then
                ' ****************************************************************************************************
                ' Wenn der Ober-Knoten expandiert ist, sollen die ColorPicker für die GerberLayer des entsprechenden
                ' Parts sichtbar und richtig positioniert werden.
                ' ****************************************************************************************************
                For Each nodegerber As TreeNode In nodepart.Nodes
                    YPos += trvLayer.ItemHeight             ' Y-Pos um Itemhöhe erhöhen (Gerbernode)
                    _EditorGerber(nodegerber.FullPath).ColorPicker.Location = New Point(10, CInt(YPos - trvLayer.ItemHeight / 2 - 5))
                    _EditorGerber(nodegerber.FullPath).ColorPicker.Visible = True
                Next
            Else
                ' **************************************************************************************************
                ' Wenn der Ober-Knoten NICHT expandiert ist, sollen die ColorPicker für die GerberLayer des 
                ' entsprechenden Parts unsichtbar werden. YPos wird entsprechend NICHT um die Itemhöhe der
                ' gerbernodes erhöht!
                ' **************************************************************************************************
                For Each nodegerber As TreeNode In nodepart.Nodes
                    _EditorGerber(nodegerber.FullPath).ColorPicker.Visible = False
                Next
            End If
        Next
    End Sub

    Private Sub KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.PageUp
                Canvas.Snaprange = Canvas.Snaprange + 2
                RaiseEvent CursorChanged()
            Case Keys.PageDown
                If Not Canvas.Snaprange < 5 Then
                    Canvas.Snaprange = Canvas.Snaprange - 2
                    RaiseEvent CursorChanged()
                End If
            Case Keys.Home
                Canvas.ZoomToAll()
            Case Keys.R
                Canvas.Invalidate()
        End Select
        e.Handled = True
    End Sub

    Protected Overrides Sub Finalize()
        Debug.Print("clsEditor Finalize")
        MyBase.Finalize()
    End Sub
End Class
