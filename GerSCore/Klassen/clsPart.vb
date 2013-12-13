Public Class clsPart
    Private _name As String
    Private _gerber As New List(Of clsGerber)

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Public Sub New(ByVal Name As String)
        _name = Name
    End Sub

    '####################################################################################################
    'Methoden
    '####################################################################################################

    Public Sub AddGerber(ByVal Name As String, ByRef Parent As clsPart)
        Me.Gerber.Add(New clsGerber(Name, Parent))
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
            Return frmMain.Project.Parts.IndexOf(Me)
        End Get
    End Property

    '####################################################################################################
    'Events
    '####################################################################################################

End Class
