<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MnuStrMain = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NeuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecentProjectsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.SpeichernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpeichernunterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DruckenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeitenansichtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RückgängigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WiederholenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.AusschneidenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EinfügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.AlleauswählenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtrasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnpassenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HilfeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InhaltToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SuchenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProjektToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PartBibliothekToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestsInitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlProjekt = New System.Windows.Forms.Panel()
        Me.lstParts = New System.Windows.Forms.ListBox()
        Me.lblProjectName = New System.Windows.Forms.Label()
        Me.dlgColor = New System.Windows.Forms.ColorDialog()
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog()
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.MnuStrMain.SuspendLayout()
        Me.pnlProjekt.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuStrMain
        '
        Me.MnuStrMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(137, Byte), Integer))
        Me.MnuStrMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.BearbeitenToolStripMenuItem, Me.ExtrasToolStripMenuItem, Me.HilfeToolStripMenuItem, Me.DatenToolStripMenuItem})
        Me.MnuStrMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuStrMain.Name = "MnuStrMain"
        Me.MnuStrMain.Size = New System.Drawing.Size(1187, 24)
        Me.MnuStrMain.TabIndex = 0
        Me.MnuStrMain.Text = "Hauptmenü Streifen"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuToolStripMenuItem, Me.ÖffnenToolStripMenuItem, Me.RecentProjectsToolStripMenuItem, Me.toolStripSeparator, Me.SpeichernToolStripMenuItem, Me.SpeichernunterToolStripMenuItem, Me.toolStripSeparator1, Me.DruckenToolStripMenuItem, Me.SeitenansichtToolStripMenuItem, Me.toolStripSeparator2, Me.BeendenToolStripMenuItem})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.DateiToolStripMenuItem.Text = "&Datei"
        '
        'NeuToolStripMenuItem
        '
        Me.NeuToolStripMenuItem.Image = CType(resources.GetObject("NeuToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NeuToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NeuToolStripMenuItem.Name = "NeuToolStripMenuItem"
        Me.NeuToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NeuToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.NeuToolStripMenuItem.Text = "&Neues Projekt..."
        '
        'ÖffnenToolStripMenuItem
        '
        Me.ÖffnenToolStripMenuItem.Image = CType(resources.GetObject("ÖffnenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ÖffnenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ÖffnenToolStripMenuItem.Name = "ÖffnenToolStripMenuItem"
        Me.ÖffnenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.ÖffnenToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.ÖffnenToolStripMenuItem.Text = "Projekt &öffnen..."
        '
        'RecentProjectsToolStripMenuItem
        '
        Me.RecentProjectsToolStripMenuItem.Name = "RecentProjectsToolStripMenuItem"
        Me.RecentProjectsToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.RecentProjectsToolStripMenuItem.Text = "zuletzt geöffnete Projekte"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(205, 6)
        '
        'SpeichernToolStripMenuItem
        '
        Me.SpeichernToolStripMenuItem.Enabled = False
        Me.SpeichernToolStripMenuItem.Image = CType(resources.GetObject("SpeichernToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SpeichernToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SpeichernToolStripMenuItem.Name = "SpeichernToolStripMenuItem"
        Me.SpeichernToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SpeichernToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.SpeichernToolStripMenuItem.Text = "Projekt &Speichern"
        '
        'SpeichernunterToolStripMenuItem
        '
        Me.SpeichernunterToolStripMenuItem.Enabled = False
        Me.SpeichernunterToolStripMenuItem.Name = "SpeichernunterToolStripMenuItem"
        Me.SpeichernunterToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.SpeichernunterToolStripMenuItem.Text = "Projekt Speichern &unter..."
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(205, 6)
        '
        'DruckenToolStripMenuItem
        '
        Me.DruckenToolStripMenuItem.Enabled = False
        Me.DruckenToolStripMenuItem.Image = CType(resources.GetObject("DruckenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DruckenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DruckenToolStripMenuItem.Name = "DruckenToolStripMenuItem"
        Me.DruckenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.DruckenToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.DruckenToolStripMenuItem.Text = "&Drucken"
        '
        'SeitenansichtToolStripMenuItem
        '
        Me.SeitenansichtToolStripMenuItem.Enabled = False
        Me.SeitenansichtToolStripMenuItem.Image = CType(resources.GetObject("SeitenansichtToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SeitenansichtToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SeitenansichtToolStripMenuItem.Name = "SeitenansichtToolStripMenuItem"
        Me.SeitenansichtToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.SeitenansichtToolStripMenuItem.Text = "&Seitenansicht"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(205, 6)
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        Me.BeendenToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.BeendenToolStripMenuItem.Text = "&Beenden"
        '
        'BearbeitenToolStripMenuItem
        '
        Me.BearbeitenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RückgängigToolStripMenuItem, Me.WiederholenToolStripMenuItem, Me.toolStripSeparator3, Me.AusschneidenToolStripMenuItem, Me.KopierenToolStripMenuItem, Me.EinfügenToolStripMenuItem, Me.toolStripSeparator4, Me.AlleauswählenToolStripMenuItem})
        Me.BearbeitenToolStripMenuItem.Enabled = False
        Me.BearbeitenToolStripMenuItem.Name = "BearbeitenToolStripMenuItem"
        Me.BearbeitenToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.BearbeitenToolStripMenuItem.Text = "&Bearbeiten"
        Me.BearbeitenToolStripMenuItem.Visible = False
        '
        'RückgängigToolStripMenuItem
        '
        Me.RückgängigToolStripMenuItem.Name = "RückgängigToolStripMenuItem"
        Me.RückgängigToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.RückgängigToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.RückgängigToolStripMenuItem.Text = "&Rückgängig"
        '
        'WiederholenToolStripMenuItem
        '
        Me.WiederholenToolStripMenuItem.Name = "WiederholenToolStripMenuItem"
        Me.WiederholenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.WiederholenToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.WiederholenToolStripMenuItem.Text = "Wiede&rholen"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(188, 6)
        '
        'AusschneidenToolStripMenuItem
        '
        Me.AusschneidenToolStripMenuItem.Image = CType(resources.GetObject("AusschneidenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AusschneidenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AusschneidenToolStripMenuItem.Name = "AusschneidenToolStripMenuItem"
        Me.AusschneidenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.AusschneidenToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.AusschneidenToolStripMenuItem.Text = "&Ausschneiden"
        '
        'KopierenToolStripMenuItem
        '
        Me.KopierenToolStripMenuItem.Image = CType(resources.GetObject("KopierenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.KopierenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.KopierenToolStripMenuItem.Name = "KopierenToolStripMenuItem"
        Me.KopierenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.KopierenToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.KopierenToolStripMenuItem.Text = "&Kopieren"
        '
        'EinfügenToolStripMenuItem
        '
        Me.EinfügenToolStripMenuItem.Image = CType(resources.GetObject("EinfügenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EinfügenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EinfügenToolStripMenuItem.Name = "EinfügenToolStripMenuItem"
        Me.EinfügenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.EinfügenToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.EinfügenToolStripMenuItem.Text = "&Einfügen"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(188, 6)
        '
        'AlleauswählenToolStripMenuItem
        '
        Me.AlleauswählenToolStripMenuItem.Name = "AlleauswählenToolStripMenuItem"
        Me.AlleauswählenToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.AlleauswählenToolStripMenuItem.Text = "&Alle auswählen"
        '
        'ExtrasToolStripMenuItem
        '
        Me.ExtrasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnpassenToolStripMenuItem, Me.OptionenToolStripMenuItem})
        Me.ExtrasToolStripMenuItem.Enabled = False
        Me.ExtrasToolStripMenuItem.Name = "ExtrasToolStripMenuItem"
        Me.ExtrasToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.ExtrasToolStripMenuItem.Text = "E&xtras"
        Me.ExtrasToolStripMenuItem.Visible = False
        '
        'AnpassenToolStripMenuItem
        '
        Me.AnpassenToolStripMenuItem.Name = "AnpassenToolStripMenuItem"
        Me.AnpassenToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.AnpassenToolStripMenuItem.Text = "&Anpassen"
        '
        'OptionenToolStripMenuItem
        '
        Me.OptionenToolStripMenuItem.Name = "OptionenToolStripMenuItem"
        Me.OptionenToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.OptionenToolStripMenuItem.Text = "&Optionen"
        '
        'HilfeToolStripMenuItem
        '
        Me.HilfeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InhaltToolStripMenuItem, Me.IndexToolStripMenuItem, Me.SuchenToolStripMenuItem, Me.toolStripSeparator5, Me.InfoToolStripMenuItem})
        Me.HilfeToolStripMenuItem.Enabled = False
        Me.HilfeToolStripMenuItem.Name = "HilfeToolStripMenuItem"
        Me.HilfeToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HilfeToolStripMenuItem.Text = "&Hilfe"
        Me.HilfeToolStripMenuItem.Visible = False
        '
        'InhaltToolStripMenuItem
        '
        Me.InhaltToolStripMenuItem.Name = "InhaltToolStripMenuItem"
        Me.InhaltToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.InhaltToolStripMenuItem.Text = "I&nhalt"
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.IndexToolStripMenuItem.Text = "&Index"
        '
        'SuchenToolStripMenuItem
        '
        Me.SuchenToolStripMenuItem.Name = "SuchenToolStripMenuItem"
        Me.SuchenToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.SuchenToolStripMenuItem.Text = "&Suchen"
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New System.Drawing.Size(110, 6)
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.InfoToolStripMenuItem.Text = "Inf&o..."
        '
        'DatenToolStripMenuItem
        '
        Me.DatenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProjektToolStripMenuItem, Me.PartBibliothekToolStripMenuItem, Me.TestsInitToolStripMenuItem})
        Me.DatenToolStripMenuItem.Enabled = False
        Me.DatenToolStripMenuItem.Name = "DatenToolStripMenuItem"
        Me.DatenToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.DatenToolStripMenuItem.Text = "&Daten"
        '
        'ProjektToolStripMenuItem
        '
        Me.ProjektToolStripMenuItem.Name = "ProjektToolStripMenuItem"
        Me.ProjektToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.ProjektToolStripMenuItem.Text = "Projekt Eigenschaften..."
        '
        'PartBibliothekToolStripMenuItem
        '
        Me.PartBibliothekToolStripMenuItem.Name = "PartBibliothekToolStripMenuItem"
        Me.PartBibliothekToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.PartBibliothekToolStripMenuItem.Text = "Part &Bibliothek"
        '
        'TestsInitToolStripMenuItem
        '
        Me.TestsInitToolStripMenuItem.Name = "TestsInitToolStripMenuItem"
        Me.TestsInitToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.TestsInitToolStripMenuItem.Text = "Tests init"
        '
        'pnlProjekt
        '
        Me.pnlProjekt.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(137, Byte), Integer))
        Me.pnlProjekt.Controls.Add(Me.lstParts)
        Me.pnlProjekt.Controls.Add(Me.lblProjectName)
        Me.pnlProjekt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlProjekt.Location = New System.Drawing.Point(0, 24)
        Me.pnlProjekt.Name = "pnlProjekt"
        Me.pnlProjekt.Size = New System.Drawing.Size(1187, 647)
        Me.pnlProjekt.TabIndex = 1
        Me.pnlProjekt.Visible = False
        '
        'lstParts
        '
        Me.lstParts.BackColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lstParts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstParts.FormattingEnabled = True
        Me.lstParts.Location = New System.Drawing.Point(12, 66)
        Me.lstParts.Name = "lstParts"
        Me.lstParts.Size = New System.Drawing.Size(120, 93)
        Me.lstParts.TabIndex = 1
        '
        'lblProjectName
        '
        Me.lblProjectName.AutoSize = True
        Me.lblProjectName.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProjectName.Location = New System.Drawing.Point(12, 12)
        Me.lblProjectName.Name = "lblProjectName"
        Me.lblProjectName.Size = New System.Drawing.Size(180, 29)
        Me.lblProjectName.TabIndex = 0
        Me.lblProjectName.Text = "lblProjectName"
        '
        'dlgColor
        '
        Me.dlgColor.AnyColor = True
        Me.dlgColor.FullOpen = True
        '
        'dlgOpen
        '
        Me.dlgOpen.FileName = "OpenFileDialog1"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1187, 671)
        Me.Controls.Add(Me.pnlProjekt)
        Me.Controls.Add(Me.MnuStrMain)
        Me.MainMenuStrip = Me.MnuStrMain
        Me.Name = "frmMain"
        Me.Text = "Gerber Shift Correction"
        Me.MnuStrMain.ResumeLayout(False)
        Me.MnuStrMain.PerformLayout()
        Me.pnlProjekt.ResumeLayout(False)
        Me.pnlProjekt.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MnuStrMain As System.Windows.Forms.MenuStrip
    Friend WithEvents DateiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NeuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ÖffnenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SpeichernToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpeichernunterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DruckenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SeitenansichtToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BeendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BearbeitenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RückgängigToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WiederholenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AusschneidenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KopierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EinfügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AlleauswählenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExtrasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnpassenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HilfeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InhaltToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SuchenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents InfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlProjekt As System.Windows.Forms.Panel
    Friend WithEvents DatenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PartBibliothekToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dlgColor As System.Windows.Forms.ColorDialog
    Friend WithEvents TestsInitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dlgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents RecentProjectsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblProjectName As System.Windows.Forms.Label
    Friend WithEvents ProjektToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lstParts As System.Windows.Forms.ListBox

End Class
