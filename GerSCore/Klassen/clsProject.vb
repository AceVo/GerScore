
Public Class clsProjekt
    Private _name As String
    Public Parts As New List(Of clsPart)


    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Public Sub New(Optional ByRef strName As String = "Neues Projekt*")
        frmMain.DebugPrefix += 1 : Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Enter in: {0} Sub ->  {1}", "clsProject", "New")

        _name = strName
        frmMain.DatenToolStripMenuItem.Enabled = True
        frmMain.pnlProjekt.Visible = True

        Debug.Print(StrDup(frmMain.DebugPrefix, "+") & " " & "Leave in: {0} Sub ->  {1}", "clsProject", "New") : frmMain.DebugPrefix -= 1

    End Sub

    '####################################################################################################
    'Methoden
    '####################################################################################################

    Public Sub AddPart(ByVal Name As String)
        Me.Parts.Add(New clsPart(Name))
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

    '####################################################################################################
    'Events
    '####################################################################################################

End Class
