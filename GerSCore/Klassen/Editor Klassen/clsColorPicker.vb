Public Class clsColorPicker
    Inherits PowerPacks.OvalShape

    Private _classname As String = "clsColorPicker"

    Private _farbe As Color
    Private _gerber As clsGerber
    Private _target As clsEditor
    Private _disposed As Boolean = False

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Public Sub New(ByRef Target As clsEditor, ByRef Gerber As clsGerber)

        '**************************************************************************************************
        'anschließend werden die Standardeigenschaften des ColorPickers gesetzt
        '**************************************************************************************************

        With Me
            .Name = Gerber.Name
            .Parent = Target.ColorContainer
            .Gerber = Gerber
            .BackStyle = PowerPacks.BackStyle.Opaque
            .BorderStyle = Drawing2D.DashStyle.Custom
            .SelectionColor = Color.Transparent
            .Height = 10
            .Width = 10
            .Visible = False
            .BackColor = _gerber.Color
        End With

    End Sub

    '####################################################################################################
    'Funktionen
    '####################################################################################################

    Overloads Sub Dispose()
        Dispose(_disposed)
    End Sub

    Protected Overloads Sub Dispose(ByVal disposing As Boolean)
        Dim _type As String = "Sub"
        Dim _structname As String = "Dispose"
        clsProgramm.DebugPrefix += 1 : Debug.Print(StrDup(clsProgramm.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2}", _classname, _type, _structname)

        If Not disposing Then
            Me.Parent.Shapes.Remove(Me)
            _gerber = Nothing
            _target = Nothing
            Me.Parent = Nothing
            _disposed = True
        End If

        clsProgramm.DebugPrefix -= 1
    End Sub

    '####################################################################################################
    'Events
    '####################################################################################################

    Private Sub clsColorPicker_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        '****************************************************************************************************
        'Beim Click auf den ColorPicker wird der Dialog zur Auswahl der gewünschten Farbe aufgerufen und
        'anschließend an das entsprechenden Gerberlayer übergeben
        '****************************************************************************************************
        With frmMain.dlgColor
            .Color = Me.BackColor
            If .ShowDialog() = DialogResult.OK Then
                Me.Gerber.Color = .Color
            End If
        End With
    End Sub

    '####################################################################################################
    'Property
    '####################################################################################################
    Property Gerber As clsGerber
        Get
            Return _gerber
        End Get
        Set(value As clsGerber)
            _gerber = value
        End Set
    End Property

    Protected Overrides Sub Finalize()
        Debug.Print("clsColorPicker Finalize")
        MyBase.Finalize()
    End Sub
End Class
