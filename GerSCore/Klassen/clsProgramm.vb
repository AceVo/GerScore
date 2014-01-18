Public Class clsProgramm
    '####################################################################################################
    'Deklaration
    '####################################################################################################

    Private _className As String = "clsProgramm"

    Public Shared MainForm As frmMain
    Public Shared MainController As clsMainController

    Public Shared DebugPrefix As Integer = 0

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Public Shared Sub Main()
        Debug.Print(StrDup(75, "-"))

        MainForm = New frmMain
        MainController = New clsMainController
        MainForm.ShowDialog()

        My.Settings.Save()

    End Sub

End Class
