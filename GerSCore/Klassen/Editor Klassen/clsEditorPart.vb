<Serializable> Public Class clsEditorPart
    Inherits clsEditorItem
    Implements IDisposable

    '####################################################################################################
    'Deklaration
    '####################################################################################################

    Private _className As String = "clsEditorPart"

    Private _part As clsPart
    Private _sc As New PowerPacks.ShapeContainer

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Public Sub New(ByVal Part As clsPart, ByVal Editor As clsEditor)
        Dim _type As String = "Sub"
        Dim _structname As String = "New"
        Dim _name As String = Part.Name
        frmMain.DebugPrefix += 1 : Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name)

        _part = Part
        _editor = Editor
        _editor.EditorParts.Add(_part.Name, Me)

        With _sc
            .Parent = _editor.Canvas.Screen
            _editor.Canvas.Screen.Controls.SetChildIndex(_sc, 0)
            .Name = _part.Name
            .Location = New Point(0, 0)
            .BackColor = Color.Transparent
        End With

        If _editor.Layerviewer = True Then
            _editor.Layertree.Nodes.Insert(_part.Level, _part.Name)
            _editor.Layertree.Nodes(_part.Level).Checked = True
        End If

        Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Leave in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name) : frmMain.DebugPrefix -= 1
    End Sub

    '####################################################################################################
    'Methoden
    '####################################################################################################

    Overrides Sub Dispose(ByVal disposing As Boolean)
        frmMain.DebugPrefix += 1 : Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Enter in: {0} Sub ->  {1}", "clsEditorPart", "Dispose")
        If Not disposing Then
            _part = Nothing
            _sc.Parent = Nothing
            _sc.Dispose()
            _sc = Nothing
            _editor = Nothing
            _disposed = True
        End If
        Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Leave in: {0} Sub ->  {1}", "clsEditorPart", "Dispose") : frmMain.DebugPrefix -= 1
    End Sub

    '####################################################################################################
    'Funktionen
    '####################################################################################################

    '####################################################################################################
    'Property
    '####################################################################################################

    ReadOnly Property Container As PowerPacks.ShapeContainer
        Get
            Return _sc
        End Get
    End Property

    ReadOnly Property Name As String
        Get
            Return _part.Name
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

    Protected Overrides Sub Finalize()
        Debug.Print("clsEditorPart Finalize")
        MyBase.Finalize()
    End Sub
End Class
