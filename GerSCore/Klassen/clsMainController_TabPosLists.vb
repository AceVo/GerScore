Partial Class clsMainController

    '####################################################################################################
    'Methoden
    '####################################################################################################

    Private Sub PosListListInit()
        Dim _type As String = "Sub"
        Dim _structname As String = Reflection.MethodBase.GetCurrentMethod.Name
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        With _mainform.lsbPosLists

            If _project.PositionLists.Count = 0 Then
                .SelectionMode = SelectionMode.None
                .Items.Add("<keine Positionslisten im Projekt>")
            Else
                .SelectionMode = SelectionMode.One
                .ValueMember = "TableName"
                For Each Element As clsPosList In _project.PositionLists
                    .Items.Add(Element)
                Next
                _mainform.dgvPosList.DataSource = .Items(0)
            End If
            .ClearSelected()

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

    Private Sub PosListListEntry_Click(sender As ListBox, e As EventArgs) Handles _mainform.PosListListEntryClick
        Dim _type As String = "Event"
        Dim _structname As String = Reflection.MethodBase.GetCurrentMethod.Name
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        _mainform.dgvPosList.DataSource = sender.SelectedItem

        clsProgram.DebugPrefix -= 1
    End Sub

    Private Sub PosListEntry_Add() Handles _mainform.PosListEntryAddClick
        Dim _type As String = "Event"
        Dim _structname As String = "PosListEntry_Add"
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2}", _className, _type, _structname)

        Dim Poslist As clsPosList = CType(_mainform.dgvPosList.DataSource, clsPosList)
        Dim NewRow As DataRow = Poslist.NewRow

        NewRow("PosName") = "Position_" & Poslist.Rows.Count + 1
        Poslist.Rows.Add(NewRow)

        clsProgram.DebugPrefix -= 1
    End Sub

    Private Sub PosListCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles _mainform.PosListCellBeginEdit
        Dim _type As String = "Event"
        Dim _structname As String = "PosListCellBeginEdit"
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2}", _className, _type, _structname)

        If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Then
            _mainform.dgvPosList.CurrentCell.Style.Format = "#0.000"
        ElseIf e.ColumnIndex = 3 Then
            _mainform.dgvPosList.CurrentCell.Style.Format = "#0.00"
        End If

        clsProgram.DebugPrefix -= 1
    End Sub

    Private Sub PosListCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles _mainform.PosListCellEndEdit
        Dim _type As String = "Event"
        Dim _structname As String = "PosListCellEndEdit"
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2}", _className, _type, _structname)

        If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Then
            _mainform.dgvPosList.CurrentCell.Style.Format = "#0.000 mm"
        ElseIf e.ColumnIndex = 3 Then
            _mainform.dgvPosList.CurrentCell.Style.Format = "#0.00 °"
        End If

        clsProgram.DebugPrefix -= 1
    End Sub

End Class
