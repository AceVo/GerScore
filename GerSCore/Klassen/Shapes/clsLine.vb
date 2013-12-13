Public Class clsLine
    Inherits clsShapes

    Private _startpoint As Point
    Private _endpoint As Point

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    ''' <summary>
    ''' Initializes a new instance of the clsLine class, specifiying the Parent Gerberinstance where it will be parented
    ''' <paramref name="Parent">
    ''' Dies ist ein Test
    ''' </paramref>
    ''' </summary>
    Sub New(ByVal Parent As clsGerber, ByVal StartPoint As Point, ByVal EndPoint As Point, Optional ByVal Unit As String = "mm")
        Me.Parent = Parent
        Me.StartPoint = StartPoint
        Me.EndPoint = EndPoint
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
