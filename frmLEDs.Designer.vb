<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLEDs
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.colMin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTimeOn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTimeOff = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblModule = New System.Windows.Forms.Label()
        Me.cboModules = New System.Windows.Forms.ComboBox()
        Me.lblReverse = New System.Windows.Forms.Label()
        Me.txtReverse = New System.Windows.Forms.TextBox()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(553, 224)
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
        Me.dgvPorts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCheck, Me.colPort, Me.colAction, Me.colPulse, Me.colMin, Me.colMax, Me.colTimeOn, Me.colTimeOff, Me.colCount})
        Me.dgvPorts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvPorts.Location = New System.Drawing.Point(12, 62)
        Me.dgvPorts.MultiSelect = False
        Me.dgvPorts.Name = "dgvPorts"
        Me.dgvPorts.RowHeadersVisible = False
        Me.dgvPorts.Size = New System.Drawing.Size(687, 156)
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
        Me.colAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colAction.HeaderText = "Action"
        Me.colAction.Items.AddRange(New Object() {"OFF", "ON", "TOGGLE", "PULSE", "DIM", "BLINK", "RAMP"})
        Me.colAction.MinimumWidth = 50
        Me.colAction.Name = "colAction"
        '
        'colPulse
        '
        Me.colPulse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle7.Format = "N1"
        DataGridViewCellStyle7.NullValue = "0.1"
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Gray
        Me.colPulse.DefaultCellStyle = DataGridViewCellStyle7
        Me.colPulse.HeaderText = "Pulse Time   (0.1 - 999.9s)"
        Me.colPulse.MaxInputLength = 5
        Me.colPulse.Name = "colPulse"
        Me.colPulse.ReadOnly = True
        Me.colPulse.Width = 105
        '
        'colMin
        '
        Me.colMin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = "0"
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Gray
        Me.colMin.DefaultCellStyle = DataGridViewCellStyle8
        Me.colMin.HeaderText = "Min (0-100)"
        Me.colMin.MaxInputLength = 3
        Me.colMin.Name = "colMin"
        Me.colMin.ReadOnly = True
        Me.colMin.Width = 80
        '
        'colMax
        '
        Me.colMax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = "100"
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Gray
        Me.colMax.DefaultCellStyle = DataGridViewCellStyle9
        Me.colMax.HeaderText = "Max (1-100)"
        Me.colMax.MaxInputLength = 3
        Me.colMax.Name = "colMax"
        Me.colMax.ReadOnly = True
        Me.colMax.Width = 80
        '
        'colTimeOn
        '
        Me.colTimeOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle10.Format = "N1"
        DataGridViewCellStyle10.NullValue = "0.1"
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Gray
        Me.colTimeOn.DefaultCellStyle = DataGridViewCellStyle10
        Me.colTimeOn.HeaderText = "Time On   (0.1 - 999.9s)"
        Me.colTimeOn.MaxInputLength = 5
        Me.colTimeOn.Name = "colTimeOn"
        Me.colTimeOn.ReadOnly = True
        Me.colTimeOn.Width = 95
        '
        'colTimeOff
        '
        Me.colTimeOff.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle11.Format = "N1"
        DataGridViewCellStyle11.NullValue = "0.1"
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Gray
        Me.colTimeOff.DefaultCellStyle = DataGridViewCellStyle11
        Me.colTimeOff.HeaderText = "Time Off   (0.1 - 999.9s)"
        Me.colTimeOff.MaxInputLength = 5
        Me.colTimeOff.Name = "colTimeOff"
        Me.colTimeOff.ReadOnly = True
        Me.colTimeOff.Width = 95
        '
        'colCount
        '
        Me.colCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle12.Format = "N0"
        DataGridViewCellStyle12.NullValue = "0"
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Gray
        Me.colCount.DefaultCellStyle = DataGridViewCellStyle12
        Me.colCount.HeaderText = "Count"
        Me.colCount.Name = "colCount"
        Me.colCount.ReadOnly = True
        Me.colCount.Width = 60
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
        'lblReverse
        '
        Me.lblReverse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblReverse.AutoSize = True
        Me.lblReverse.Location = New System.Drawing.Point(12, 232)
        Me.lblReverse.Name = "lblReverse"
        Me.lblReverse.Size = New System.Drawing.Size(136, 13)
        Me.lblReverse.TabIndex = 10
        Me.lblReverse.Text = "Reverse CFLink Command:"
        '
        'txtReverse
        '
        Me.txtReverse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReverse.Location = New System.Drawing.Point(154, 229)
        Me.txtReverse.Name = "txtReverse"
        Me.txtReverse.Size = New System.Drawing.Size(393, 20)
        Me.txtReverse.TabIndex = 11
        '
        'frmLEDs
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(711, 265)
        Me.Controls.Add(Me.txtReverse)
        Me.Controls.Add(Me.lblReverse)
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
        Me.MinimumSize = New System.Drawing.Size(727, 299)
        Me.Name = "frmLEDs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Build LED Command"
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
    Friend WithEvents lblModule As System.Windows.Forms.Label
    Friend WithEvents cboModules As System.Windows.Forms.ComboBox
    Friend WithEvents colCheck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colPort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAction As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colPulse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTimeOn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTimeOff As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblReverse As System.Windows.Forms.Label
    Friend WithEvents txtReverse As System.Windows.Forms.TextBox

End Class
