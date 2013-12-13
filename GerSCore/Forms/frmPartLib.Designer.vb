<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPartLib
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
        Me.components = New System.ComponentModel.Container()
        Me.mnuPartLibrary = New System.Windows.Forms.MenuStrip()
        Me.PartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NeuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GerberLayerHinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PartlisteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SchließenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.pnlEditor = New System.Windows.Forms.Panel()
        Me.mnuPartLibrary.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuPartLibrary
        '
        Me.mnuPartLibrary.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PartToolStripMenuItem, Me.SchließenToolStripMenuItem, Me.TestToolStripMenuItem})
        Me.mnuPartLibrary.Location = New System.Drawing.Point(0, 0)
        Me.mnuPartLibrary.Name = "mnuPartLibrary"
        Me.mnuPartLibrary.Size = New System.Drawing.Size(1246, 24)
        Me.mnuPartLibrary.TabIndex = 0
        Me.mnuPartLibrary.Text = "MenuStrip1"
        '
        'PartToolStripMenuItem
        '
        Me.PartToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuToolStripMenuItem, Me.GerberLayerHinzufügenToolStripMenuItem, Me.LöschenToolStripMenuItem, Me.ToolStripSeparator1, Me.PartlisteToolStripMenuItem})
        Me.PartToolStripMenuItem.Name = "PartToolStripMenuItem"
        Me.PartToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.PartToolStripMenuItem.Text = "&Part"
        '
        'NeuToolStripMenuItem
        '
        Me.NeuToolStripMenuItem.Name = "NeuToolStripMenuItem"
        Me.NeuToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.NeuToolStripMenuItem.Text = "Erstellen"
        '
        'GerberLayerHinzufügenToolStripMenuItem
        '
        Me.GerberLayerHinzufügenToolStripMenuItem.Enabled = False
        Me.GerberLayerHinzufügenToolStripMenuItem.Name = "GerberLayerHinzufügenToolStripMenuItem"
        Me.GerberLayerHinzufügenToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.GerberLayerHinzufügenToolStripMenuItem.Text = "Gerber Layer hinzufügen"
        '
        'LöschenToolStripMenuItem
        '
        Me.LöschenToolStripMenuItem.Enabled = False
        Me.LöschenToolStripMenuItem.Name = "LöschenToolStripMenuItem"
        Me.LöschenToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.LöschenToolStripMenuItem.Text = "Löschen"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(200, 6)
        '
        'PartlisteToolStripMenuItem
        '
        Me.PartlisteToolStripMenuItem.Enabled = False
        Me.PartlisteToolStripMenuItem.Name = "PartlisteToolStripMenuItem"
        Me.PartlisteToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.PartlisteToolStripMenuItem.Text = "Part&liste..."
        '
        'SchließenToolStripMenuItem
        '
        Me.SchließenToolStripMenuItem.Name = "SchließenToolStripMenuItem"
        Me.SchließenToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.SchließenToolStripMenuItem.Text = "Schließen"
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.TestToolStripMenuItem.Text = "Test"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'pnlEditor
        '
        Me.pnlEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlEditor.Location = New System.Drawing.Point(0, 24)
        Me.pnlEditor.Name = "pnlEditor"
        Me.pnlEditor.Padding = New System.Windows.Forms.Padding(2)
        Me.pnlEditor.Size = New System.Drawing.Size(1246, 544)
        Me.pnlEditor.TabIndex = 1
        '
        'frmPartLib
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(1246, 568)
        Me.Controls.Add(Me.pnlEditor)
        Me.Controls.Add(Me.mnuPartLibrary)
        Me.MainMenuStrip = Me.mnuPartLibrary
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPartLib"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Part Library"
        Me.mnuPartLibrary.ResumeLayout(False)
        Me.mnuPartLibrary.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuPartLibrary As System.Windows.Forms.MenuStrip
    Friend WithEvents PartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NeuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PartlisteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SchließenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GerberLayerHinzufügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents pnlEditor As System.Windows.Forms.Panel
End Class
