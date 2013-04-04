<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelays
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.lblModelTitle = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblIDTitle = New System.Windows.Forms.Label()
        Me.lblSerial = New System.Windows.Forms.Label()
        Me.lblSerialTitle = New System.Windows.Forms.Label()
        Me.dgvPorts = New System.Windows.Forms.DataGridView()
        Me.colCheck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colPort = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAction = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colPulse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblModule = New System.Windows.Forms.Label()
        Me.cboModules = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvPorts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 183)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'lblModelTitle
        '
        Me.lblModelTitle.AutoSize = True
        Me.lblModelTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblModelTitle.Name = "lblModelTitle"
        Me.lblModelTitle.Size = New System.Drawing.Size(70, 13)
        Me.lblModelTitle.TabIndex = 1
        Me.lblModelTitle.Text = "Model Name:"
        Me.lblModelTitle.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModel.Location = New System.Drawing.Point(88, 9)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(50, 13)
        Me.lblModel.TabIndex = 2
        Me.lblModel.Text = "MODEL"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.Location = New System.Drawing.Point(88, 27)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(21, 13)
        Me.lblID.TabIndex = 4
        Me.lblID.Text = "00"
        '
        'lblIDTitle
        '
        Me.lblIDTitle.AutoSize = True
        Me.lblIDTitle.Location = New System.Drawing.Point(25, 27)
        Me.lblIDTitle.Name = "lblIDTitle"
        Me.lblIDTitle.Size = New System.Drawing.Size(57, 13)
        Me.lblIDTitle.TabIndex = 3
        Me.lblIDTitle.Text = "CFLink ID:"
        Me.lblIDTitle.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSerial
        '
        Me.lblSerial.AutoSize = True
        Me.lblSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerial.Location = New System.Drawing.Point(88, 46)
        Me.lblSerial.Name = "lblSerial"
        Me.lblSerial.Size = New System.Drawing.Size(63, 13)
        Me.lblSerial.TabIndex = 6
        Me.lblSerial.Text = "00000000"
        '
        'lblSerialTitle
        '
        Me.lblSerialTitle.AutoSize = True
        Me.lblSerialTitle.Location = New System.Drawing.Point(21, 46)
        Me.lblSerialTitle.Name = "lblSerialTitle"
        Me.lblSerialTitle.Size = New System.Drawing.Size(61, 13)
        Me.lblSerialTitle.TabIndex = 5
        Me.lblSerialTitle.Text = "Serial Num:"
        Me.lblSerialTitle.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dgvPorts
        '
        Me.dgvPorts.AllowUserToAddRows = False
        Me.dgvPorts.AllowUserToResizeRows = False
        Me.dgvPorts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPorts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPorts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCheck, Me.colPort, Me.colAction, Me.colPulse})
        Me.dgvPorts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvPorts.Location = New System.Drawing.Point(12, 62)
        Me.dgvPorts.MultiSelect = False
        Me.dgvPorts.Name = "dgvPorts"
        Me.dgvPorts.RowHeadersVisible = False
        Me.dgvPorts.Size = New System.Drawing.Size(411, 115)
        Me.dgvPorts.TabIndex = 7
        '
        'colCheck
        '
        Me.colCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colCheck.HeaderText = ""
        Me.colCheck.Name = "colCheck"
        Me.colCheck.ToolTipText = "Include in Command?"
        Me.colCheck.Width = 20
        '
        'colPort
        '
        Me.colPort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colPort.HeaderText = "Port"
        Me.colPort.Name = "colPort"
        Me.colPort.ReadOnly = True
        Me.colPort.Width = 50
        '
        'colAction
        '
        Me.colAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colAction.HeaderText = "Action"
        Me.colAction.Items.AddRange(New Object() {"OPEN", "CLOSE", "TOGGLE", "PULSE"})
        Me.colAction.Name = "colAction"
        '
        'colPulse
        '
        Me.colPulse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPulse.HeaderText = "Pulse Time (ms)"
        Me.colPulse.Name = "colPulse"
        Me.colPulse.ReadOnly = True
        '
        'lblModule
        '
        Me.lblModule.AutoSize = True
        Me.lblModule.Location = New System.Drawing.Point(221, 9)
        Me.lblModule.Name = "lblModule"
        Me.lblModule.Size = New System.Drawing.Size(45, 13)
        Me.lblModule.TabIndex = 8
        Me.lblModule.Text = "Module:"
        Me.lblModule.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblModule.Visible = False
        '
        'cboModules
        '
        Me.cboModules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModules.FormattingEnabled = True
        Me.cboModules.Location = New System.Drawing.Point(272, 6)
        Me.cboModules.Name = "cboModules"
        Me.cboModules.Size = New System.Drawing.Size(151, 21)
        Me.cboModules.TabIndex = 9
        Me.cboModules.Visible = False
        '
        'frmRelays
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(435, 224)
        Me.Controls.Add(Me.cboModules)
        Me.Controls.Add(Me.lblModule)
        Me.Controls.Add(Me.dgvPorts)
        Me.Controls.Add(Me.lblSerial)
        Me.Controls.Add(Me.lblSerialTitle)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.lblIDTitle)
        Me.Controls.Add(Me.lblModel)
        Me.Controls.Add(Me.lblModelTitle)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRelays"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Build Relay Command"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dgvPorts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lblModelTitle As System.Windows.Forms.Label
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents lblIDTitle As System.Windows.Forms.Label
    Friend WithEvents lblSerial As System.Windows.Forms.Label
    Friend WithEvents lblSerialTitle As System.Windows.Forms.Label
    Friend WithEvents dgvPorts As System.Windows.Forms.DataGridView
    Friend WithEvents colCheck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colPort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAction As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colPulse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblModule As System.Windows.Forms.Label
    Friend WithEvents cboModules As System.Windows.Forms.ComboBox

End Class
