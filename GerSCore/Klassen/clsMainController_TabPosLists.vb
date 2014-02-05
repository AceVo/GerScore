Partial Class clsMainController

    Private WithEvents btnParts As New Button

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Sub Mainform_loaded_TabPosLists() Handles _mainform.Load
        Dim _type As String = "Event"
        Dim _structname As String = Reflection.MethodBase.GetCurrentMethod.Name
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        Setup_GridView()
        Add_GridView_Button()

        clsProgram.DebugPrefix -= 1
    End Sub

    '####################################################################################################
    'Methoden
    '####################################################################################################

    Private Sub Setup_GridView()
        Dim _type As String = "Sub"
        Dim _structname As String = Reflection.MethodBase.GetCurrentMethod.Name
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        Dim dgv As DataGridView = _mainform.dgvPosList
        Dim column As DataGridViewColumn = New DataGridViewTextBoxColumn

        dgv.AutoGenerateColumns = False
        dgv.AutoSize = True

        'initialize and add a Textboxcolumn as Positionnamecolumn
        column.DataPropertyName = "PosName"
        column.Name = "PosName"
        column.HeaderText = "Positionsbezeichnung"
        dgv.Columns.Add(column)

        'initialize and add a Textboxcolumn as X-Positioncolumn
        column = New DataGridViewTextBoxColumn
        column.DataPropertyName = "XPos"
        column.Name = "XPos"
        column.HeaderText = "X-Position"
        column.DefaultCellStyle.Format = "'0,000 mm"
        dgv.Columns.Add(column)

        'initialize and add a Textboxcolumn as Y-Positioncolumn
        column = New DataGridViewTextBoxColumn
        column.DataPropertyName = "YPos"
        column.Name = "YPos"
        column.HeaderText = "Y-Position"
        column.DefaultCellStyle.Format = "'0,000 mm"
        dgv.Columns.Add(column)

        'initialize and add a Textboxcolumn as Anglecolumn
        column = New DataGridViewTextBoxColumn
        column.DataPropertyName = "Angle"
        column.Name = "Angle"
        column.HeaderText = "Winkel"
        column.DefaultCellStyle.Format = "'0,00 °"
        dgv.Columns.Add(column)

        'initialize and add a Textboxcolumn as Partcolumn
        column = New DataGridViewTextBoxColumn
        column.DataPropertyName = "Part"
        column.Name = "Part"
        column.HeaderText = "Bauteil"
        column.Visible = False
        dgv.Columns.Add(column)

        column = New DataGridViewTextBoxColumn
        column.Name = "PartName"
        column.HeaderText = "Bauteilname"
        dgv.Columns.Add(column)

        clsProgram.DebugPrefix -= 1
    End Sub

    Private Sub Add_GridView_Button()
        Dim _type As String = "Sub"
        Dim _structname As String = Reflection.MethodBase.GetCurrentMethod.Name
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        ' Add a Button to the DataGridview of the PositionListsTab at the Mainform
        With btnParts
            .Name = "btnParts"
            .Size = New Size(22, 20)
            .FlatStyle = FlatStyle.Popup
            .FlatAppearance.BorderSize = 0
            .Visible = False
            .Text = "..."
        End With
        _mainform.dgvPosList.Controls.Add(btnParts)

        clsProgram.DebugPrefix -= 1
    End Sub

    Private Sub PosListList_Refresh() Handles _project.PositionListAdded
        Dim _type As String = "Sub"
        Dim _structname As String = Reflection.MethodBase.GetCurrentMethod.Name
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        Dim Selection As Integer = 0

        With _mainform.lsbPosLists
            If _project.PositionLists.Count = 0 Then
                .SelectionMode = SelectionMode.None
                .Items.Add("keine Positionslisten")
            Else
                If Not IsNothing(.SelectedItem) Then Selection = .SelectedIndex
                .DataSource = Nothing
                .DataSource = _project.PositionLists
                .DisplayMember = "TableName"
                .SelectionMode = SelectionMode.One
                .SelectedIndex = Selection
            End If
        End With

        clsProgram.DebugPrefix -= 1
    End Sub

    Private Sub Fill_PartNames_to_Gridview(sender As DataGridView, e As EventArgs)
        Dim _type As String = "Sub"
        Dim _structname As String = Reflection.MethodBase.GetCurrentMethod.Name
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        Dim dgv As DataGridView = sender

        For Each Element As DataGridViewRow In sender.Rows()
            If Not IsDBNull(Element.Cells("Part").Value) Then
                Element.Cells("PartName").Value = CType(Element.Cells("Part").Value, clsPart).Name
            End If
        Next

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

    Private Sub PosListList_SelectedIndexChanged(sender As ListBox, e As EventArgs) Handles _mainform.PosListListSelectedIndexChanged
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

        Dim dgv As DataGridView = CType(sender, DataGridView)

        Select Case dgv.Columns(e.ColumnIndex).Name
            Case "XPos", "YPos"
                _mainform.dgvPosList.CurrentCell.Style.Format = "#0.000"
            Case "Angle"
                _mainform.dgvPosList.CurrentCell.Style.Format = "#0.00"
            Case "PartName"
                Dim lCell As Rectangle = _mainform.dgvPosList.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                Dim lLoc As New Point(lCell.Right - btnParts.Width - 2, lCell.Top)
                btnParts.Location = lLoc
                btnParts.Visible = True
        End Select

        clsProgram.DebugPrefix -= 1
    End Sub

    Private Sub PosListCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles _mainform.PosListCellEndEdit
        Dim _type As String = "Event"
        Dim _structname As String = "PosListCellEndEdit"
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2}", _className, _type, _structname)

        Dim dgv As DataGridView = CType(sender, DataGridView)

        Select Case dgv.Columns(e.ColumnIndex).Name
            Case "XPos", "YPos"
                _mainform.dgvPosList.CurrentCell.Style.Format = "#0.000 mm"
            Case "Angle"
                _mainform.dgvPosList.CurrentCell.Style.Format = "#0.00 °"
            Case "PartName"
                btnParts.Visible = False
        End Select

        clsProgram.DebugPrefix -= 1
    End Sub

    Private Sub btnParts_Click(sender As Object, e As EventArgs) Handles btnParts.Click
        Dim _type As String = "Event"
        Dim _structname As String = Reflection.MethodBase.GetCurrentMethod.Name
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        Dim result = dlgParts.ShowDialog(_mainform)

        If result = DialogResult.OK Then
            _mainform.dgvPosList.CurrentCell.Value = dlgParts.SelectedItem.Name
            _mainform.dgvPosList.CurrentRow.Cells("Part").Value = dlgParts.SelectedItem
        End If
        _mainform.dgvPosList.EndEdit()

        clsProgram.DebugPrefix -= 1
    End Sub

    Private Sub PosListDataSourceChanged(sender As Object, e As EventArgs) Handles _mainform.PosListDataSourceChanged
        Dim _type As String = "Event"
        Dim _structname As String = Reflection.MethodBase.GetCurrentMethod.Name
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} ", _className, _type, _structname)

        Fill_PartNames_to_Gridview(CType(sender, DataGridView), e)

        clsProgram.DebugPrefix -= 1
    End Sub
End Class
