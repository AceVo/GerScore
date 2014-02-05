<Serializable> Class clsPosList
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

        Me.RemotingFormat = SerializationFormat.Binary

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

End Class
