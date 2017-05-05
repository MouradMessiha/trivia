<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
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

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
      Me.tspMain = New System.Windows.Forms.ToolStrip
      Me.btnMode = New System.Windows.Forms.ToolStripDropDownButton
      Me.mnuManual = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuTimer = New System.Windows.Forms.ToolStripMenuItem
      Me.txtDisplay = New System.Windows.Forms.TextBox
      Me.tspMain.SuspendLayout()
      Me.SuspendLayout()
      '
      'tspMain
      '
      Me.tspMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnMode})
      Me.tspMain.Location = New System.Drawing.Point(0, 0)
      Me.tspMain.Name = "tspMain"
      Me.tspMain.Size = New System.Drawing.Size(673, 25)
      Me.tspMain.TabIndex = 0
      '
      'btnMode
      '
      Me.btnMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuManual, Me.mnuTimer})
      Me.btnMode.Image = CType(resources.GetObject("btnMode.Image"), System.Drawing.Image)
      Me.btnMode.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.btnMode.Name = "btnMode"
      Me.btnMode.Size = New System.Drawing.Size(70, 22)
      Me.btnMode.Text = "Manual"
      '
      'mnuManual
      '
      Me.mnuManual.Image = CType(resources.GetObject("mnuManual.Image"), System.Drawing.Image)
      Me.mnuManual.Name = "mnuManual"
      Me.mnuManual.Size = New System.Drawing.Size(119, 22)
      Me.mnuManual.Text = "Manual"
      '
      'mnuTimer
      '
      Me.mnuTimer.Image = CType(resources.GetObject("mnuTimer.Image"), System.Drawing.Image)
      Me.mnuTimer.Name = "mnuTimer"
      Me.mnuTimer.Size = New System.Drawing.Size(119, 22)
      Me.mnuTimer.Text = "Timer"
      '
      'txtDisplay
      '
      Me.txtDisplay.BackColor = System.Drawing.SystemColors.Window
      Me.txtDisplay.Dock = System.Windows.Forms.DockStyle.Fill
      Me.txtDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDisplay.Location = New System.Drawing.Point(0, 25)
      Me.txtDisplay.MaxLength = 0
      Me.txtDisplay.Multiline = True
      Me.txtDisplay.Name = "txtDisplay"
      Me.txtDisplay.ReadOnly = True
      Me.txtDisplay.Size = New System.Drawing.Size(673, 57)
      Me.txtDisplay.TabIndex = 1
      '
      'frmMain
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(673, 82)
      Me.ControlBox = False
      Me.Controls.Add(Me.txtDisplay)
      Me.Controls.Add(Me.tspMain)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "frmMain"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Trivia"
      Me.tspMain.ResumeLayout(False)
      Me.tspMain.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents tspMain As System.Windows.Forms.ToolStrip
   Friend WithEvents btnMode As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents mnuManual As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuTimer As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents txtDisplay As System.Windows.Forms.TextBox

End Class
