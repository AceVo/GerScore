<Serializable> Public Class clsPosList
    Inherits DataTable
    '####################################################################################################
    'Deklaration
    '####################################################################################################

    Private _className As String = Me.GetType.Name

    Private _posname As New DataColumn("PosName", GetType(String))
    Private _xpos As New DataColumn("XPos", GetType(Double))
    Private _ypos As New DataColumn("YPos", GetType(Double))
    Private _angle As New DataColumn("Angle", GetType(Double))
    Private _part As New DataColumn("Part", GetType(clsPart))

    Friend Event NameChanged()

    '####################################################################################################
    'Konstruktoren
    '####################################################################################################

    Public Sub New()
        Dim _type As String = "Sub"
        Dim _structname As String = "New"
        Me.TableName = "Neue Positionsliste " & clsProgram.MainController.Project.PositionLists.Count + 1
        Dim _name As String = Me.TableName
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2} : {3}", _className, _type, _structname, _name)

        _posname.Unique = True
        _posname.Caption = "Positionsbezeichnung"
        _xpos.DefaultValue = 0
        _xpos.Caption = "X-Position"
        _ypos.DefaultValue = 0
        _ypos.Caption = "Y-Position"
        _angle.DefaultValue = 0
        _angle.Caption = "Winkel"
        _part.Caption = "Bauteil"

        Me.Columns.Add(_posname)
        Me.Columns.Add(_xpos)
        Me.Columns.Add(_ypos)
        Me.Columns.Add(_angle)
        Me.Columns.Add(_part)

        clsProgram.DebugPrefix -= 1
    End Sub

    Protected Sub New(ByVal info As Runtime.Serialization.SerializationInfo, ByVal context As Runtime.Serialization.StreamingContext)
        MyBase.New(info, context)
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

    '####################################################################################################
    'Events
    '####################################################################################################

    Private Sub clsPosList_RowChanged(sender As Object, e As DataRowChangeEventArgs) Handles Me.RowChanged
        Dim _type As String = "Event"
        Dim _structname As String = "RowChanged"
        clsProgram.DebugPrefix += 1 : Debug.Print(StrDup(clsProgram.DebugPrefix, "+") & " " & "Enter in: {0} {1} ->  {2}", _className, _type, _structname)

        'If e.Action = DataRowAction.Add Then
        '    e.Row.Item(_posname) = "Position_" & Me.Rows.Count
        'End If

        clsProgram.DebugPrefix -= 1
    End Sub

End Class
