Public Class clsMausobjekt
    Public Objekt As PowerPacks.Shape
    Public MausX As Integer
    Public MausY As Integer

    Private _Abstand As Double

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Public Sub New(ByRef m_Objekt As PowerPacks.Shape, ByVal m_MausX As Integer, ByVal m_MausY As Integer)

        Objekt = m_Objekt
        MausX = m_MausX
        MausY = m_MausY

    End Sub

    '####################################################################################################
    'Funktionen
    '####################################################################################################

    '####################################################################################################
    'Property
    '####################################################################################################

    Public ReadOnly Property Abstand As Double

        Get
            _Abstand = Math.Sqrt(Math.Pow(MausX, 2) + Math.Pow(MausY, 2))
            Return _Abstand
        End Get

    End Property

End Class
