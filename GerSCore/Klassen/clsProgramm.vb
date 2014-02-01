Public Class clsProgram
    '####################################################################################################
    'Deklaration
    '####################################################################################################

    Private _className As String = "clsProgramm"

    Public Shared MainForm As frmMain
    Public Shared MainController As clsMainController

    Public Shared FhGGreen As Color = Color.FromArgb(23, 156, 125)
    Public Shared FhgGreenLight As Color = Color.FromArgb(109, 191, 169)
    Public Shared FhGGreenVeryLight As Color = Color.FromArgb(180, 220, 211)

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
