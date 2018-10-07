<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class preview
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
        Me.prev_report = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'prev_report
        '
        Me.prev_report.ActiveViewIndex = -1
        Me.prev_report.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.prev_report.Cursor = System.Windows.Forms.Cursors.Default
        Me.prev_report.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prev_report.Location = New System.Drawing.Point(0, 0)
        Me.prev_report.Name = "prev_report"
        Me.prev_report.Size = New System.Drawing.Size(751, 534)
        Me.prev_report.TabIndex = 0
        Me.prev_report.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'preview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 534)
        Me.Controls.Add(Me.prev_report)
        Me.Name = "preview"
        Me.Text = "preview"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents prev_report As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
