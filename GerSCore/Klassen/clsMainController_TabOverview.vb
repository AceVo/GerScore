Partial Class clsMainController

    '####################################################################################################
    'Methoden
    '####################################################################################################

    '####################################################################################################
    'Funktionen
    '####################################################################################################

    '####################################################################################################
    'Property
    '####################################################################################################

    '####################################################################################################
    'Events
    '####################################################################################################

    Private Sub PartListInit()
        Dim _type As String = "Sub"
        Dim _structname As String = "PartListInit"
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        With _mainform.lsbParts

            If _project.Parts.Count = 0 Then
                .SelectionMode = SelectionMode.None
                .Items.Add("<keine Parts im Project>")
            Else
                .SelectionMode = SelectionMode.One
                .ValueMember = "Name"
                For Each Element As clsPart In _project.Parts
                    .Items.Add(Element)
                Next
            End If
            .ClearSelected()

        End With

        clsProgram.DebugPrefix -= 1
    End Sub

End Class
