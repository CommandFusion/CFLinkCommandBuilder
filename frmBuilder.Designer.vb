<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuilder
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuilder))
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.splitPanels = New System.Windows.Forms.SplitContainer()
        Me.treeDevices = New System.Windows.Forms.TreeView()
        Me.imgTreeIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.lblFile = New System.Windows.Forms.Label()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabRelays = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGenerateRelay = New System.Windows.Forms.Button()
        Me.dgvPortsRelay = New System.Windows.Forms.DataGridView()
        Me.colCheck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colPort = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAction = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colPulse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabIO = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnGenerateIO = New System.Windows.Forms.Button()
        Me.dgvPortsIO = New System.Windows.Forms.DataGridView()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabSerial = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGenerateSerial = New System.Windows.Forms.Button()
        Me.dgvPortsSerial = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabLED = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnGenerateLED = New System.Windows.Forms.Button()
        Me.dgvPortsLED = New System.Windows.Forms.DataGridView()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTimeOn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTimeOff = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabIR = New System.Windows.Forms.TabPage()
        Me.tabIRModes = New System.Windows.Forms.TabControl()
        Me.tabIRDB = New System.Windows.Forms.TabPage()
        Me.btnAddAllIRCommands = New System.Windows.Forms.Button()
        Me.cboIRPort = New System.Windows.Forms.ComboBox()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.cboCommand = New System.Windows.Forms.ComboBox()
        Me.lblCommand = New System.Windows.Forms.Label()
        Me.cboCodeSet = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboManufacturer = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboDeviceType = New System.Windows.Forms.ComboBox()
        Me.lblDeviceType = New System.Windows.Forms.Label()
        Me.tabIRCommand = New System.Windows.Forms.TabPage()
        Me.btnGenerateIR = New System.Windows.Forms.Button()
        Me.dgvPortsIR = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComboBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tabError = New System.Windows.Forms.TabPage()
        Me.lblErrorMsg = New System.Windows.Forms.Label()
        Me.tabEthernet = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnGenerateEthernet = New System.Windows.Forms.Button()
        Me.dgvPortsEthernet = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDetails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabHelp = New System.Windows.Forms.TabPage()
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCopyCommand = New System.Windows.Forms.Button()
        Me.lblProjectWarning = New System.Windows.Forms.Label()
        Me.btnRefreshSystems = New System.Windows.Forms.Button()
        Me.cboSystems = New System.Windows.Forms.ComboBox()
        Me.lblSystem = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtCommandValue = New System.Windows.Forms.TextBox()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.txtCommandName = New System.Windows.Forms.TextBox()
        Me.lblCommandName = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.toolStrip = New System.Windows.Forms.ToolStrip()
        Me.lblSelectExport = New System.Windows.Forms.ToolStripLabel()
        Me.cboFiles = New System.Windows.Forms.ToolStripComboBox()
        Me.btnBrowse = New System.Windows.Forms.ToolStripButton()
        Me.dlgOpenFile = New System.Windows.Forms.OpenFileDialog()
        CType(Me.splitPanels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitPanels.Panel1.SuspendLayout()
        Me.splitPanels.Panel2.SuspendLayout()
        Me.splitPanels.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabRelays.SuspendLayout()
        CType(Me.dgvPortsRelay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabIO.SuspendLayout()
        CType(Me.dgvPortsIO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSerial.SuspendLayout()
        CType(Me.dgvPortsSerial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabLED.SuspendLayout()
        CType(Me.dgvPortsLED, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabIR.SuspendLayout()
        Me.tabIRModes.SuspendLayout()
        Me.tabIRDB.SuspendLayout()
        Me.tabIRCommand.SuspendLayout()
        CType(Me.dgvPortsIR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabError.SuspendLayout()
        Me.tabEthernet.SuspendLayout()
        CType(Me.dgvPortsEthernet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabHelp.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.toolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'splitPanels
        '
        Me.splitPanels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitPanels.Location = New System.Drawing.Point(0, 25)
        Me.splitPanels.Name = "splitPanels"
        '
        'splitPanels.Panel1
        '
        Me.splitPanels.Panel1.Controls.Add(Me.treeDevices)
        Me.splitPanels.Panel1.Controls.Add(Me.lblFile)
        Me.splitPanels.Panel1MinSize = 184
        '
        'splitPanels.Panel2
        '
        Me.splitPanels.Panel2.Controls.Add(Me.tabMain)
        Me.splitPanels.Panel2.Controls.Add(Me.Panel1)
        Me.splitPanels.Size = New System.Drawing.Size(645, 403)
        Me.splitPanels.SplitterDistance = 184
        Me.splitPanels.TabIndex = 0
        '
        'treeDevices
        '
        Me.treeDevices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeDevices.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.treeDevices.ImageIndex = 0
        Me.treeDevices.ImageList = Me.imgTreeIcons
        Me.treeDevices.Location = New System.Drawing.Point(0, 31)
        Me.treeDevices.Name = "treeDevices"
        Me.treeDevices.SelectedImageIndex = 0
        Me.treeDevices.Size = New System.Drawing.Size(184, 372)
        Me.treeDevices.TabIndex = 1
        '
        'imgTreeIcons
        '
        Me.imgTreeIcons.ImageStream = CType(resources.GetObject("imgTreeIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgTreeIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.imgTreeIcons.Images.SetKeyName(0, "16x16_dot.png")
        Me.imgTreeIcons.Images.SetKeyName(1, "16x16_ethernet.png")
        Me.imgTreeIcons.Images.SetKeyName(2, "16x16_serialcoms.png")
        Me.imgTreeIcons.Images.SetKeyName(3, "16x16_infrared.png")
        Me.imgTreeIcons.Images.SetKeyName(4, "16x16_relay.png")
        Me.imgTreeIcons.Images.SetKeyName(5, "16x16_ioport.png")
        Me.imgTreeIcons.Images.SetKeyName(6, "16x16_blueled.png")
        Me.imgTreeIcons.Images.SetKeyName(7, "16x16_num1.png")
        Me.imgTreeIcons.Images.SetKeyName(8, "16x16_num2.png")
        Me.imgTreeIcons.Images.SetKeyName(9, "16x16_num3.png")
        Me.imgTreeIcons.Images.SetKeyName(10, "16x16_num4.png")
        '
        'lblFile
        '
        Me.lblFile.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblFile.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFile.Location = New System.Drawing.Point(0, 0)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(184, 31)
        Me.lblFile.TabIndex = 0
        Me.lblFile.Text = "Waiting for above selection..."
        Me.lblFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tabRelays)
        Me.tabMain.Controls.Add(Me.tabIO)
        Me.tabMain.Controls.Add(Me.tabSerial)
        Me.tabMain.Controls.Add(Me.tabLED)
        Me.tabMain.Controls.Add(Me.tabIR)
        Me.tabMain.Controls.Add(Me.tabError)
        Me.tabMain.Controls.Add(Me.tabEthernet)
        Me.tabMain.Controls.Add(Me.tabHelp)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.Location = New System.Drawing.Point(0, 0)
        Me.tabMain.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(457, 279)
        Me.tabMain.TabIndex = 0
        '
        'tabRelays
        '
        Me.tabRelays.AutoScroll = True
        Me.tabRelays.Controls.Add(Me.Label1)
        Me.tabRelays.Controls.Add(Me.btnGenerateRelay)
        Me.tabRelays.Controls.Add(Me.dgvPortsRelay)
        Me.tabRelays.Location = New System.Drawing.Point(4, 22)
        Me.tabRelays.Name = "tabRelays"
        Me.tabRelays.Padding = New System.Windows.Forms.Padding(3)
        Me.tabRelays.Size = New System.Drawing.Size(449, 253)
        Me.tabRelays.TabIndex = 0
        Me.tabRelays.Text = "Relays"
        Me.tabRelays.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Generate Relay Command"
        '
        'btnGenerateRelay
        '
        Me.btnGenerateRelay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateRelay.AutoSize = True
        Me.btnGenerateRelay.Location = New System.Drawing.Point(330, 227)
        Me.btnGenerateRelay.Name = "btnGenerateRelay"
        Me.btnGenerateRelay.Size = New System.Drawing.Size(111, 23)
        Me.btnGenerateRelay.TabIndex = 9
        Me.btnGenerateRelay.Text = "Generate Command"
        Me.btnGenerateRelay.UseVisualStyleBackColor = True
        '
        'dgvPortsRelay
        '
        Me.dgvPortsRelay.AllowUserToAddRows = False
        Me.dgvPortsRelay.AllowUserToResizeRows = False
        Me.dgvPortsRelay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPortsRelay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPortsRelay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCheck, Me.colPort, Me.colAction, Me.colPulse})
        Me.dgvPortsRelay.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvPortsRelay.Location = New System.Drawing.Point(6, 23)
        Me.dgvPortsRelay.MultiSelect = False
        Me.dgvPortsRelay.Name = "dgvPortsRelay"
        Me.dgvPortsRelay.RowHeadersVisible = False
        Me.dgvPortsRelay.Size = New System.Drawing.Size(435, 198)
        Me.dgvPortsRelay.TabIndex = 8
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
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle19.Format = "N1"
        DataGridViewCellStyle19.NullValue = "0.1"
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Gray
        Me.colPulse.DefaultCellStyle = DataGridViewCellStyle19
        Me.colPulse.HeaderText = "Pulse Time (ms)"
        Me.colPulse.Name = "colPulse"
        Me.colPulse.ReadOnly = True
        '
        'tabIO
        '
        Me.tabIO.AutoScroll = True
        Me.tabIO.Controls.Add(Me.Label2)
        Me.tabIO.Controls.Add(Me.btnGenerateIO)
        Me.tabIO.Controls.Add(Me.dgvPortsIO)
        Me.tabIO.Location = New System.Drawing.Point(4, 22)
        Me.tabIO.Name = "tabIO"
        Me.tabIO.Padding = New System.Windows.Forms.Padding(3)
        Me.tabIO.Size = New System.Drawing.Size(449, 253)
        Me.tabIO.TabIndex = 1
        Me.tabIO.Text = "IO"
        Me.tabIO.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Generate IO Command"
        '
        'btnGenerateIO
        '
        Me.btnGenerateIO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateIO.AutoSize = True
        Me.btnGenerateIO.Location = New System.Drawing.Point(330, 227)
        Me.btnGenerateIO.Name = "btnGenerateIO"
        Me.btnGenerateIO.Size = New System.Drawing.Size(111, 23)
        Me.btnGenerateIO.TabIndex = 11
        Me.btnGenerateIO.Text = "Generate Command"
        Me.btnGenerateIO.UseVisualStyleBackColor = True
        '
        'dgvPortsIO
        '
        Me.dgvPortsIO.AllowUserToAddRows = False
        Me.dgvPortsIO.AllowUserToResizeRows = False
        Me.dgvPortsIO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPortsIO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPortsIO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewComboBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.dgvPortsIO.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvPortsIO.Location = New System.Drawing.Point(6, 23)
        Me.dgvPortsIO.MultiSelect = False
        Me.dgvPortsIO.Name = "dgvPortsIO"
        Me.dgvPortsIO.RowHeadersVisible = False
        Me.dgvPortsIO.Size = New System.Drawing.Size(435, 198)
        Me.dgvPortsIO.TabIndex = 8
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewCheckBoxColumn1.HeaderText = ""
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ToolTipText = "Include in Command?"
        Me.DataGridViewCheckBoxColumn1.Width = 20
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn1.HeaderText = "Port"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewComboBoxColumn1.HeaderText = "Action"
        Me.DataGridViewComboBoxColumn1.Items.AddRange(New Object() {"OPEN", "CLOSE", "TOGGLE", "PULSE"})
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle20.Format = "N1"
        DataGridViewCellStyle20.NullValue = "0.1"
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Gray
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle20
        Me.DataGridViewTextBoxColumn2.HeaderText = "Pulse Time (ms)"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'tabSerial
        '
        Me.tabSerial.AutoScroll = True
        Me.tabSerial.Controls.Add(Me.Label3)
        Me.tabSerial.Controls.Add(Me.btnGenerateSerial)
        Me.tabSerial.Controls.Add(Me.dgvPortsSerial)
        Me.tabSerial.Location = New System.Drawing.Point(4, 22)
        Me.tabSerial.Name = "tabSerial"
        Me.tabSerial.Size = New System.Drawing.Size(449, 253)
        Me.tabSerial.TabIndex = 2
        Me.tabSerial.Text = "Serial"
        Me.tabSerial.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(153, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Generate Serial Command"
        '
        'btnGenerateSerial
        '
        Me.btnGenerateSerial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateSerial.AutoSize = True
        Me.btnGenerateSerial.Location = New System.Drawing.Point(330, 227)
        Me.btnGenerateSerial.Name = "btnGenerateSerial"
        Me.btnGenerateSerial.Size = New System.Drawing.Size(111, 23)
        Me.btnGenerateSerial.TabIndex = 13
        Me.btnGenerateSerial.Text = "Generate Command"
        Me.btnGenerateSerial.UseVisualStyleBackColor = True
        '
        'dgvPortsSerial
        '
        Me.dgvPortsSerial.AllowUserToAddRows = False
        Me.dgvPortsSerial.AllowUserToResizeRows = False
        Me.dgvPortsSerial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPortsSerial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPortsSerial.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.dgvPortsSerial.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvPortsSerial.Location = New System.Drawing.Point(6, 23)
        Me.dgvPortsSerial.MultiSelect = False
        Me.dgvPortsSerial.Name = "dgvPortsSerial"
        Me.dgvPortsSerial.RowHeadersVisible = False
        Me.dgvPortsSerial.Size = New System.Drawing.Size(435, 198)
        Me.dgvPortsSerial.TabIndex = 8
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn3.HeaderText = "Port"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.HeaderText = "Data to send (enter hex bytes in \x0D format)"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'tabLED
        '
        Me.tabLED.AutoScroll = True
        Me.tabLED.Controls.Add(Me.Label4)
        Me.tabLED.Controls.Add(Me.btnGenerateLED)
        Me.tabLED.Controls.Add(Me.dgvPortsLED)
        Me.tabLED.Location = New System.Drawing.Point(4, 22)
        Me.tabLED.Name = "tabLED"
        Me.tabLED.Size = New System.Drawing.Size(449, 253)
        Me.tabLED.TabIndex = 3
        Me.tabLED.Text = "LED"
        Me.tabLED.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Generate LED Command"
        '
        'btnGenerateLED
        '
        Me.btnGenerateLED.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateLED.AutoSize = True
        Me.btnGenerateLED.Location = New System.Drawing.Point(330, 227)
        Me.btnGenerateLED.Name = "btnGenerateLED"
        Me.btnGenerateLED.Size = New System.Drawing.Size(111, 23)
        Me.btnGenerateLED.TabIndex = 15
        Me.btnGenerateLED.Text = "Generate Command"
        Me.btnGenerateLED.UseVisualStyleBackColor = True
        '
        'dgvPortsLED
        '
        Me.dgvPortsLED.AllowUserToAddRows = False
        Me.dgvPortsLED.AllowUserToResizeRows = False
        Me.dgvPortsLED.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPortsLED.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPortsLED.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn2, Me.DataGridViewTextBoxColumn5, Me.DataGridViewComboBoxColumn2, Me.DataGridViewTextBoxColumn6, Me.colMin, Me.colMax, Me.colTimeOn, Me.colTimeOff, Me.colCount})
        Me.dgvPortsLED.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvPortsLED.Location = New System.Drawing.Point(6, 23)
        Me.dgvPortsLED.MultiSelect = False
        Me.dgvPortsLED.Name = "dgvPortsLED"
        Me.dgvPortsLED.RowHeadersVisible = False
        Me.dgvPortsLED.Size = New System.Drawing.Size(435, 198)
        Me.dgvPortsLED.TabIndex = 8
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewCheckBoxColumn2.HeaderText = ""
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.ToolTipText = "Include in Command?"
        Me.DataGridViewCheckBoxColumn2.Width = 20
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn5.HeaderText = "Port"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 50
        '
        'DataGridViewComboBoxColumn2
        '
        Me.DataGridViewComboBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewComboBoxColumn2.HeaderText = "Action"
        Me.DataGridViewComboBoxColumn2.Items.AddRange(New Object() {"OFF", "ON", "TOGGLE", "PULSE", "DIM", "BLINK", "RAMP"})
        Me.DataGridViewComboBoxColumn2.MinimumWidth = 50
        Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle21.Format = "N1"
        DataGridViewCellStyle21.NullValue = "0.1"
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Gray
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle21
        Me.DataGridViewTextBoxColumn6.HeaderText = "Pulse Time   (0.1 - 999.9s)"
        Me.DataGridViewTextBoxColumn6.MaxInputLength = 5
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 105
        '
        'colMin
        '
        Me.colMin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle22.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle22.Format = "N0"
        DataGridViewCellStyle22.NullValue = "0"
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Gray
        Me.colMin.DefaultCellStyle = DataGridViewCellStyle22
        Me.colMin.HeaderText = "Min (0-100)"
        Me.colMin.MaxInputLength = 3
        Me.colMin.Name = "colMin"
        Me.colMin.ReadOnly = True
        Me.colMin.Width = 80
        '
        'colMax
        '
        Me.colMax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle23.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle23.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle23.Format = "N0"
        DataGridViewCellStyle23.NullValue = "100"
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Gray
        Me.colMax.DefaultCellStyle = DataGridViewCellStyle23
        Me.colMax.HeaderText = "Max (1-100)"
        Me.colMax.MaxInputLength = 3
        Me.colMax.Name = "colMax"
        Me.colMax.ReadOnly = True
        Me.colMax.Width = 80
        '
        'colTimeOn
        '
        Me.colTimeOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle24.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle24.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle24.Format = "N1"
        DataGridViewCellStyle24.NullValue = "0.1"
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Gray
        Me.colTimeOn.DefaultCellStyle = DataGridViewCellStyle24
        Me.colTimeOn.HeaderText = "Time On   (0.1 - 999.9s)"
        Me.colTimeOn.MaxInputLength = 5
        Me.colTimeOn.Name = "colTimeOn"
        Me.colTimeOn.ReadOnly = True
        Me.colTimeOn.Width = 95
        '
        'colTimeOff
        '
        Me.colTimeOff.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle25.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle25.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle25.Format = "N1"
        DataGridViewCellStyle25.NullValue = "0.1"
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.Gray
        Me.colTimeOff.DefaultCellStyle = DataGridViewCellStyle25
        Me.colTimeOff.HeaderText = "Time Off   (0.1 - 999.9s)"
        Me.colTimeOff.MaxInputLength = 5
        Me.colTimeOff.Name = "colTimeOff"
        Me.colTimeOff.ReadOnly = True
        Me.colTimeOff.Width = 95
        '
        'colCount
        '
        Me.colCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle26.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle26.Format = "N0"
        DataGridViewCellStyle26.NullValue = "0"
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.Gray
        Me.colCount.DefaultCellStyle = DataGridViewCellStyle26
        Me.colCount.HeaderText = "Count"
        Me.colCount.Name = "colCount"
        Me.colCount.ReadOnly = True
        Me.colCount.Width = 60
        '
        'tabIR
        '
        Me.tabIR.AutoScroll = True
        Me.tabIR.Controls.Add(Me.tabIRModes)
        Me.tabIR.Controls.Add(Me.Label5)
        Me.tabIR.Location = New System.Drawing.Point(4, 22)
        Me.tabIR.Name = "tabIR"
        Me.tabIR.Size = New System.Drawing.Size(449, 253)
        Me.tabIR.TabIndex = 4
        Me.tabIR.Text = "IR"
        Me.tabIR.UseVisualStyleBackColor = True
        '
        'tabIRModes
        '
        Me.tabIRModes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabIRModes.Controls.Add(Me.tabIRDB)
        Me.tabIRModes.Controls.Add(Me.tabIRCommand)
        Me.tabIRModes.Location = New System.Drawing.Point(9, 23)
        Me.tabIRModes.Name = "tabIRModes"
        Me.tabIRModes.SelectedIndex = 0
        Me.tabIRModes.Size = New System.Drawing.Size(432, 227)
        Me.tabIRModes.TabIndex = 0
        '
        'tabIRDB
        '
        Me.tabIRDB.Controls.Add(Me.btnAddAllIRCommands)
        Me.tabIRDB.Controls.Add(Me.cboIRPort)
        Me.tabIRDB.Controls.Add(Me.lblPort)
        Me.tabIRDB.Controls.Add(Me.cboCommand)
        Me.tabIRDB.Controls.Add(Me.lblCommand)
        Me.tabIRDB.Controls.Add(Me.cboCodeSet)
        Me.tabIRDB.Controls.Add(Me.Label7)
        Me.tabIRDB.Controls.Add(Me.cboManufacturer)
        Me.tabIRDB.Controls.Add(Me.Label8)
        Me.tabIRDB.Controls.Add(Me.cboDeviceType)
        Me.tabIRDB.Controls.Add(Me.lblDeviceType)
        Me.tabIRDB.Location = New System.Drawing.Point(4, 22)
        Me.tabIRDB.Name = "tabIRDB"
        Me.tabIRDB.Padding = New System.Windows.Forms.Padding(3)
        Me.tabIRDB.Size = New System.Drawing.Size(424, 201)
        Me.tabIRDB.TabIndex = 0
        Me.tabIRDB.Text = "From Database"
        Me.tabIRDB.UseVisualStyleBackColor = True
        '
        'btnAddAllIRCommands
        '
        Me.btnAddAllIRCommands.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddAllIRCommands.AutoSize = True
        Me.btnAddAllIRCommands.Enabled = False
        Me.btnAddAllIRCommands.Location = New System.Drawing.Point(262, 141)
        Me.btnAddAllIRCommands.Name = "btnAddAllIRCommands"
        Me.btnAddAllIRCommands.Size = New System.Drawing.Size(157, 23)
        Me.btnAddAllIRCommands.TabIndex = 9
        Me.btnAddAllIRCommands.Text = "Add All Commands To Project"
        Me.btnAddAllIRCommands.UseVisualStyleBackColor = True
        '
        'cboIRPort
        '
        Me.cboIRPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIRPort.FormattingEnabled = True
        Me.cboIRPort.Location = New System.Drawing.Point(81, 6)
        Me.cboIRPort.Name = "cboIRPort"
        Me.cboIRPort.Size = New System.Drawing.Size(78, 21)
        Me.cboIRPort.TabIndex = 1
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Location = New System.Drawing.Point(34, 9)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(43, 13)
        Me.lblPort.TabIndex = 0
        Me.lblPort.Text = "IR Port:"
        '
        'cboCommand
        '
        Me.cboCommand.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCommand.FormattingEnabled = True
        Me.cboCommand.Location = New System.Drawing.Point(81, 114)
        Me.cboCommand.Name = "cboCommand"
        Me.cboCommand.Size = New System.Drawing.Size(338, 21)
        Me.cboCommand.TabIndex = 8
        '
        'lblCommand
        '
        Me.lblCommand.AutoSize = True
        Me.lblCommand.Location = New System.Drawing.Point(18, 117)
        Me.lblCommand.Name = "lblCommand"
        Me.lblCommand.Size = New System.Drawing.Size(57, 13)
        Me.lblCommand.TabIndex = 7
        Me.lblCommand.Text = "Command:"
        '
        'cboCodeSet
        '
        Me.cboCodeSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCodeSet.FormattingEnabled = True
        Me.cboCodeSet.Location = New System.Drawing.Point(81, 87)
        Me.cboCodeSet.Name = "cboCodeSet"
        Me.cboCodeSet.Size = New System.Drawing.Size(78, 21)
        Me.cboCodeSet.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Code Set:"
        '
        'cboManufacturer
        '
        Me.cboManufacturer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboManufacturer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboManufacturer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboManufacturer.FormattingEnabled = True
        Me.cboManufacturer.Location = New System.Drawing.Point(81, 33)
        Me.cboManufacturer.Name = "cboManufacturer"
        Me.cboManufacturer.Size = New System.Drawing.Size(338, 21)
        Me.cboManufacturer.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Manufacturer:"
        '
        'cboDeviceType
        '
        Me.cboDeviceType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDeviceType.FormattingEnabled = True
        Me.cboDeviceType.Location = New System.Drawing.Point(81, 60)
        Me.cboDeviceType.Name = "cboDeviceType"
        Me.cboDeviceType.Size = New System.Drawing.Size(338, 21)
        Me.cboDeviceType.TabIndex = 4
        '
        'lblDeviceType
        '
        Me.lblDeviceType.AutoSize = True
        Me.lblDeviceType.Location = New System.Drawing.Point(4, 63)
        Me.lblDeviceType.Name = "lblDeviceType"
        Me.lblDeviceType.Size = New System.Drawing.Size(71, 13)
        Me.lblDeviceType.TabIndex = 19
        Me.lblDeviceType.Text = "Device Type:"
        '
        'tabIRCommand
        '
        Me.tabIRCommand.Controls.Add(Me.btnGenerateIR)
        Me.tabIRCommand.Controls.Add(Me.dgvPortsIR)
        Me.tabIRCommand.Location = New System.Drawing.Point(4, 22)
        Me.tabIRCommand.Name = "tabIRCommand"
        Me.tabIRCommand.Padding = New System.Windows.Forms.Padding(3)
        Me.tabIRCommand.Size = New System.Drawing.Size(424, 201)
        Me.tabIRCommand.TabIndex = 1
        Me.tabIRCommand.Text = "From Code"
        Me.tabIRCommand.UseVisualStyleBackColor = True
        '
        'btnGenerateIR
        '
        Me.btnGenerateIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateIR.AutoSize = True
        Me.btnGenerateIR.Location = New System.Drawing.Point(310, 172)
        Me.btnGenerateIR.Name = "btnGenerateIR"
        Me.btnGenerateIR.Size = New System.Drawing.Size(111, 23)
        Me.btnGenerateIR.TabIndex = 12
        Me.btnGenerateIR.Text = "Generate Command"
        Me.btnGenerateIR.UseVisualStyleBackColor = True
        '
        'dgvPortsIR
        '
        Me.dgvPortsIR.AllowUserToAddRows = False
        Me.dgvPortsIR.AllowUserToResizeRows = False
        Me.dgvPortsIR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPortsIR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPortsIR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7, Me.DataGridViewComboBoxColumn3, Me.DataGridViewTextBoxColumn8})
        Me.dgvPortsIR.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvPortsIR.Location = New System.Drawing.Point(3, 3)
        Me.dgvPortsIR.MultiSelect = False
        Me.dgvPortsIR.Name = "dgvPortsIR"
        Me.dgvPortsIR.RowHeadersVisible = False
        Me.dgvPortsIR.Size = New System.Drawing.Size(418, 163)
        Me.dgvPortsIR.TabIndex = 9
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn7.HeaderText = "Port"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 50
        '
        'DataGridViewComboBoxColumn3
        '
        Me.DataGridViewComboBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewComboBoxColumn3.HeaderText = "Action"
        Me.DataGridViewComboBoxColumn3.Items.AddRange(New Object() {"Raw CCF Hex Code", "CF String (IR Learner)"})
        Me.DataGridViewComboBoxColumn3.Name = "DataGridViewComboBoxColumn3"
        Me.DataGridViewComboBoxColumn3.Width = 150
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle27.NullValue = Nothing
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle27
        Me.DataGridViewTextBoxColumn8.HeaderText = "IR Code"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Generate IR Command"
        '
        'tabError
        '
        Me.tabError.AutoScroll = True
        Me.tabError.Controls.Add(Me.lblErrorMsg)
        Me.tabError.Location = New System.Drawing.Point(4, 22)
        Me.tabError.Name = "tabError"
        Me.tabError.Size = New System.Drawing.Size(449, 253)
        Me.tabError.TabIndex = 5
        Me.tabError.Text = "Error"
        Me.tabError.UseVisualStyleBackColor = True
        '
        'lblErrorMsg
        '
        Me.lblErrorMsg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrorMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorMsg.ForeColor = System.Drawing.Color.Red
        Me.lblErrorMsg.Location = New System.Drawing.Point(9, 9)
        Me.lblErrorMsg.Name = "lblErrorMsg"
        Me.lblErrorMsg.Size = New System.Drawing.Size(437, 281)
        Me.lblErrorMsg.TabIndex = 0
        Me.lblErrorMsg.Text = "Label6"
        '
        'tabEthernet
        '
        Me.tabEthernet.Controls.Add(Me.Label9)
        Me.tabEthernet.Controls.Add(Me.btnGenerateEthernet)
        Me.tabEthernet.Controls.Add(Me.dgvPortsEthernet)
        Me.tabEthernet.Location = New System.Drawing.Point(4, 22)
        Me.tabEthernet.Name = "tabEthernet"
        Me.tabEthernet.Size = New System.Drawing.Size(449, 253)
        Me.tabEthernet.TabIndex = 6
        Me.tabEthernet.Text = "Ethernet"
        Me.tabEthernet.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(169, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Generate Ethernet Command"
        '
        'btnGenerateEthernet
        '
        Me.btnGenerateEthernet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateEthernet.AutoSize = True
        Me.btnGenerateEthernet.Location = New System.Drawing.Point(330, 227)
        Me.btnGenerateEthernet.Name = "btnGenerateEthernet"
        Me.btnGenerateEthernet.Size = New System.Drawing.Size(111, 23)
        Me.btnGenerateEthernet.TabIndex = 16
        Me.btnGenerateEthernet.Text = "Generate Command"
        Me.btnGenerateEthernet.UseVisualStyleBackColor = True
        '
        'dgvPortsEthernet
        '
        Me.dgvPortsEthernet.AllowUserToAddRows = False
        Me.dgvPortsEthernet.AllowUserToResizeRows = False
        Me.dgvPortsEthernet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPortsEthernet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPortsEthernet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn9, Me.colDetails, Me.DataGridViewTextBoxColumn10})
        Me.dgvPortsEthernet.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvPortsEthernet.Location = New System.Drawing.Point(6, 23)
        Me.dgvPortsEthernet.MultiSelect = False
        Me.dgvPortsEthernet.Name = "dgvPortsEthernet"
        Me.dgvPortsEthernet.RowHeadersVisible = False
        Me.dgvPortsEthernet.Size = New System.Drawing.Size(435, 198)
        Me.dgvPortsEthernet.TabIndex = 15
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn9.HeaderText = "Slot"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 50
        '
        'colDetails
        '
        Me.colDetails.HeaderText = "Details"
        Me.colDetails.Name = "colDetails"
        Me.colDetails.ReadOnly = True
        Me.colDetails.Width = 150
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn10.HeaderText = "Data to send (enter hex bytes in \x0D format)"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'tabHelp
        '
        Me.tabHelp.Controls.Add(Me.lblHelp)
        Me.tabHelp.Location = New System.Drawing.Point(4, 22)
        Me.tabHelp.Name = "tabHelp"
        Me.tabHelp.Size = New System.Drawing.Size(449, 253)
        Me.tabHelp.TabIndex = 7
        Me.tabHelp.Text = "Help"
        Me.tabHelp.UseVisualStyleBackColor = True
        '
        'lblHelp
        '
        Me.lblHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHelp.Location = New System.Drawing.Point(0, 0)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(449, 253)
        Me.lblHelp.TabIndex = 0
        Me.lblHelp.Text = resources.GetString("lblHelp.Text")
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnCopyCommand)
        Me.Panel1.Controls.Add(Me.lblProjectWarning)
        Me.Panel1.Controls.Add(Me.btnRefreshSystems)
        Me.Panel1.Controls.Add(Me.cboSystems)
        Me.Panel1.Controls.Add(Me.lblSystem)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.txtCommandValue)
        Me.Panel1.Controls.Add(Me.lblValue)
        Me.Panel1.Controls.Add(Me.txtCommandName)
        Me.Panel1.Controls.Add(Me.lblCommandName)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 279)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(457, 124)
        Me.Panel1.TabIndex = 1
        '
        'btnCopyCommand
        '
        Me.btnCopyCommand.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyCommand.AutoSize = True
        Me.btnCopyCommand.Enabled = False
        Me.btnCopyCommand.Location = New System.Drawing.Point(259, 88)
        Me.btnCopyCommand.Name = "btnCopyCommand"
        Me.btnCopyCommand.Size = New System.Drawing.Size(91, 23)
        Me.btnCopyCommand.TabIndex = 9
        Me.btnCopyCommand.Text = "Copy Command"
        Me.btnCopyCommand.UseVisualStyleBackColor = True
        '
        'lblProjectWarning
        '
        Me.lblProjectWarning.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProjectWarning.AutoSize = True
        Me.lblProjectWarning.ForeColor = System.Drawing.Color.Red
        Me.lblProjectWarning.Location = New System.Drawing.Point(50, 93)
        Me.lblProjectWarning.Name = "lblProjectWarning"
        Me.lblProjectWarning.Size = New System.Drawing.Size(203, 13)
        Me.lblProjectWarning.TabIndex = 70
        Me.lblProjectWarning.Text = "You must open a guiDesigner project first."
        Me.lblProjectWarning.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblProjectWarning.Visible = False
        '
        'btnRefreshSystems
        '
        Me.btnRefreshSystems.AutoSize = True
        Me.btnRefreshSystems.Image = CType(resources.GetObject("btnRefreshSystems.Image"), System.Drawing.Image)
        Me.btnRefreshSystems.Location = New System.Drawing.Point(132, 62)
        Me.btnRefreshSystems.Name = "btnRefreshSystems"
        Me.btnRefreshSystems.Size = New System.Drawing.Size(141, 23)
        Me.btnRefreshSystems.TabIndex = 3
        Me.btnRefreshSystems.Text = " Refresh System List"
        Me.btnRefreshSystems.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRefreshSystems.UseVisualStyleBackColor = True
        '
        'cboSystems
        '
        Me.cboSystems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSystems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSystems.FormattingEnabled = True
        Me.cboSystems.Location = New System.Drawing.Point(60, 36)
        Me.cboSystems.Name = "cboSystems"
        Me.cboSystems.Size = New System.Drawing.Size(213, 21)
        Me.cboSystems.TabIndex = 1
        '
        'lblSystem
        '
        Me.lblSystem.AutoSize = True
        Me.lblSystem.Location = New System.Drawing.Point(10, 39)
        Me.lblSystem.Name = "lblSystem"
        Me.lblSystem.Size = New System.Drawing.Size(44, 13)
        Me.lblSystem.TabIndex = 0
        Me.lblSystem.Text = "System:"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.AutoSize = True
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(356, 88)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(88, 23)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "Add To Project"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtCommandValue
        '
        Me.txtCommandValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCommandValue.Location = New System.Drawing.Point(335, 62)
        Me.txtCommandValue.Name = "txtCommandValue"
        Me.txtCommandValue.Size = New System.Drawing.Size(109, 20)
        Me.txtCommandValue.TabIndex = 7
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Location = New System.Drawing.Point(292, 65)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(37, 13)
        Me.lblValue.TabIndex = 6
        Me.lblValue.Text = "Value:"
        '
        'txtCommandName
        '
        Me.txtCommandName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCommandName.Location = New System.Drawing.Point(335, 36)
        Me.txtCommandName.Name = "txtCommandName"
        Me.txtCommandName.Size = New System.Drawing.Size(109, 20)
        Me.txtCommandName.TabIndex = 5
        '
        'lblCommandName
        '
        Me.lblCommandName.AutoSize = True
        Me.lblCommandName.Location = New System.Drawing.Point(291, 39)
        Me.lblCommandName.Name = "lblCommandName"
        Me.lblCommandName.Size = New System.Drawing.Size(38, 13)
        Me.lblCommandName.TabIndex = 4
        Me.lblCommandName.Text = "Name:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(455, 23)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "New Command Details"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'toolStrip
        '
        Me.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblSelectExport, Me.cboFiles, Me.btnBrowse})
        Me.toolStrip.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip.Name = "toolStrip"
        Me.toolStrip.Size = New System.Drawing.Size(645, 25)
        Me.toolStrip.TabIndex = 1
        Me.toolStrip.Text = "ToolStrip1"
        '
        'lblSelectExport
        '
        Me.lblSelectExport.Name = "lblSelectExport"
        Me.lblSelectExport.Size = New System.Drawing.Size(152, 22)
        Me.lblSelectExport.Text = "Select Discovery Export File:"
        '
        'cboFiles
        '
        Me.cboFiles.AutoSize = False
        Me.cboFiles.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFiles.Name = "cboFiles"
        Me.cboFiles.Size = New System.Drawing.Size(250, 23)
        '
        'btnBrowse
        '
        Me.btnBrowse.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnBrowse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnBrowse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBrowse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(49, 22)
        Me.btnBrowse.Text = "Browse"
        '
        'dlgOpenFile
        '
        Me.dlgOpenFile.DefaultExt = "json"
        Me.dlgOpenFile.Filter = "JSON files|*.json"
        Me.dlgOpenFile.InitialDirectory = "%appdata%\CommandFusion\SystemCommander\discovery"
        '
        'frmBuilder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(645, 428)
        Me.Controls.Add(Me.splitPanels)
        Me.Controls.Add(Me.toolStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimumSize = New System.Drawing.Size(645, 292)
        Me.Name = "frmBuilder"
        Me.Text = "CFLink Command Builder"
        Me.splitPanels.Panel1.ResumeLayout(False)
        Me.splitPanels.Panel2.ResumeLayout(False)
        CType(Me.splitPanels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitPanels.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabRelays.ResumeLayout(False)
        Me.tabRelays.PerformLayout()
        CType(Me.dgvPortsRelay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabIO.ResumeLayout(False)
        Me.tabIO.PerformLayout()
        CType(Me.dgvPortsIO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSerial.ResumeLayout(False)
        Me.tabSerial.PerformLayout()
        CType(Me.dgvPortsSerial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabLED.ResumeLayout(False)
        Me.tabLED.PerformLayout()
        CType(Me.dgvPortsLED, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabIR.ResumeLayout(False)
        Me.tabIR.PerformLayout()
        Me.tabIRModes.ResumeLayout(False)
        Me.tabIRDB.ResumeLayout(False)
        Me.tabIRDB.PerformLayout()
        Me.tabIRCommand.ResumeLayout(False)
        Me.tabIRCommand.PerformLayout()
        CType(Me.dgvPortsIR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabError.ResumeLayout(False)
        Me.tabEthernet.ResumeLayout(False)
        Me.tabEthernet.PerformLayout()
        CType(Me.dgvPortsEthernet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabHelp.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.toolStrip.ResumeLayout(False)
        Me.toolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents splitPanels As System.Windows.Forms.SplitContainer
    Friend WithEvents treeDevices As System.Windows.Forms.TreeView
    Friend WithEvents toolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents cboFiles As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnBrowse As System.Windows.Forms.ToolStripButton
    Friend WithEvents imgTreeIcons As System.Windows.Forms.ImageList
    Friend WithEvents dlgOpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabRelays As System.Windows.Forms.TabPage
    Friend WithEvents tabIO As System.Windows.Forms.TabPage
    Friend WithEvents dgvPortsRelay As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGenerateRelay As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnGenerateIO As System.Windows.Forms.Button
    Friend WithEvents dgvPortsIO As System.Windows.Forms.DataGridView
    Friend WithEvents tabSerial As System.Windows.Forms.TabPage
    Friend WithEvents tabLED As System.Windows.Forms.TabPage
    Friend WithEvents tabIR As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnGenerateSerial As System.Windows.Forms.Button
    Friend WithEvents dgvPortsSerial As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnGenerateLED As System.Windows.Forms.Button
    Friend WithEvents dgvPortsLED As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTimeOn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTimeOff As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tabError As System.Windows.Forms.TabPage
    Friend WithEvents lblErrorMsg As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnRefreshSystems As System.Windows.Forms.Button
    Friend WithEvents cboSystems As System.Windows.Forms.ComboBox
    Friend WithEvents lblSystem As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtCommandValue As System.Windows.Forms.TextBox
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents txtCommandName As System.Windows.Forms.TextBox
    Friend WithEvents lblCommandName As System.Windows.Forms.Label
    Friend WithEvents colCheck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colPort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAction As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colPulse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblSelectExport As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblFile As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tabIRModes As System.Windows.Forms.TabControl
    Friend WithEvents tabIRDB As System.Windows.Forms.TabPage
    Friend WithEvents cboIRPort As System.Windows.Forms.ComboBox
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents cboCommand As System.Windows.Forms.ComboBox
    Friend WithEvents lblCommand As System.Windows.Forms.Label
    Friend WithEvents cboCodeSet As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboManufacturer As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboDeviceType As System.Windows.Forms.ComboBox
    Friend WithEvents lblDeviceType As System.Windows.Forms.Label
    Friend WithEvents tabIRCommand As System.Windows.Forms.TabPage
    Friend WithEvents dgvPortsIR As System.Windows.Forms.DataGridView
    Friend WithEvents btnGenerateIR As System.Windows.Forms.Button
    Friend WithEvents btnAddAllIRCommands As System.Windows.Forms.Button
    Friend WithEvents tabEthernet As System.Windows.Forms.TabPage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnGenerateEthernet As System.Windows.Forms.Button
    Friend WithEvents dgvPortsEthernet As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDetails As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblProjectWarning As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCopyCommand As System.Windows.Forms.Button
    Friend WithEvents tabHelp As System.Windows.Forms.TabPage
    Friend WithEvents lblHelp As System.Windows.Forms.Label
End Class
