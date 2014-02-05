Partial Class clsMainController

    '####################################################################################################
    'Methoden
    '####################################################################################################

    Private Sub PartList_Refresh() Handles _project.PartAdded
        Dim _type As String = "Sub"
        Dim _structname As String = Reflection.MethodBase.GetCurrentMethod.Name
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        Dim Selection As Integer = 0

        With _mainform.lsbParts
            If _project.Parts.Count = 0 Then
                .SelectionMode = SelectionMode.None
                .Items.Add("<keine Parts im Project>")
            Else
                If Not IsNothing(.SelectedItem) Then Selection = .SelectedIndex
                .DataSource = Nothing
                .DataSource = _project.Parts
                .DisplayMember = "Name"
                .SelectionMode = SelectionMode.One
                .SelectedIndex = Selection
            End If
            ' .ClearSelected()
        End With

        clsProgram.DebugPrefix -= 1
    End Sub

    '####################################################################################################
    'Funktionen
    '####################################################################################################

    '####################################################################################################
    'Property
    '####################################################################################################

    '####################################################################################################
    'Events
    '####################################################################################################

End Class
