Public Class clsColorPicker
    Inherits PowerPacks.OvalShape

    Private _farbe As Color
    Private _gerber As clsGerber
    Private _target As clsEditor

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

End Class
