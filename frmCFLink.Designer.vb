<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCFLink
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCFLink))
        Me.lblSelectCFLink = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.dlgOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.cboFile = New System.Windows.Forms.ComboBox()
        Me.cboActions = New System.Windows.Forms.ComboBox()
        Me.lblChooseAction = New System.Windows.Forms.Label()
        Me.lblFilenameInfo = New System.Windows.Forms.Label()
        Me.cboDevices = New System.Windows.Forms.ComboBox()
        Me.lblCommandName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCommandName = New System.Windows.Forms.TextBox()
        Me.txtCommandValue = New System.Windows.Forms.TextBox()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblSystem = New System.Windows.Forms.Label()
        Me.cboSystems = New System.Windows.Forms.ComboBox()
        Me.btnRefreshSystems = New System.Windows.Forms.Button()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblSelectCFLink
        '
        Me.lblSelectCFLink.AutoSize = True
        Me.lblSelectCFLink.Location = New System.Drawing.Point(13, 13)
        Me.lblSelectCFLink.Name = "lblSelectCFLink"
        Me.lblSelectCFLink.Size = New System.Drawing.Size(190, 13)
        Me.lblSelectCFLink.TabIndex = 0
        Me.lblSelectCFLink.Text = "1. Select CFLink Discovery Export File:"
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.AutoSize = True
        Me.btnBrowse.Location = New System.Drawing.Point(176, 28)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(61, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'dlgOpenFile
        '
        Me.dlgOpenFile.DefaultExt = "json"
        Me.dlgOpenFile.Filter = "JSON files|*.json"
        Me.dlgOpenFile.InitialDirectory = "%appdata%\CommandFusion\SystemCommander\discovery"
        '
        'cboFile
        '
        Me.cboFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFile.DropDownWidth = 300
        Me.cboFile.FormattingEnabled = True
        Me.cboFile.Location = New System.Drawing.Point(12, 29)
        Me.cboFile.Name = "cboFile"
        Me.cboFile.Size = New System.Drawing.Size(158, 21)
        Me.cboFile.TabIndex = 3
        '
        'cboActions
        '
        Me.cboActions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboActions.Enabled = False
        Me.cboActions.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboActions.FormattingEnabled = True
        Me.cboActions.Location = New System.Drawing.Point(12, 92)
        Me.cboActions.Name = "cboActions"
        Me.cboActions.Size = New System.Drawing.Size(225, 22)
        Me.cboActions.TabIndex = 5
        '
        'lblChooseAction
        '
        Me.lblChooseAction.AutoSize = True
        Me.lblChooseAction.Location = New System.Drawing.Point(13, 76)
        Me.lblChooseAction.Name = "lblChooseAction"
        Me.lblChooseAction.Size = New System.Drawing.Size(115, 13)
        Me.lblChooseAction.TabIndex = 4
        Me.lblChooseAction.Text = "2. Choose Action Type"
        '
        'lblFilenameInfo
        '
        Me.lblFilenameInfo.AutoSize = True
        Me.lblFilenameInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilenameInfo.Location = New System.Drawing.Point(13, 53)
        Me.lblFilenameInfo.Name = "lblFilenameInfo"
        Me.lblFilenameInfo.Size = New System.Drawing.Size(57, 13)
        Me.lblFilenameInfo.TabIndex = 7
        Me.lblFilenameInfo.Text = "Filename"
        Me.lblFilenameInfo.Visible = False
        '
        'cboDevices
        '
        Me.cboDevices.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDevices.Enabled = False
        Me.cboDevices.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDevices.FormattingEnabled = True
        Me.cboDevices.Location = New System.Drawing.Point(12, 135)
        Me.cboDevices.Name = "cboDevices"
        Me.cboDevices.Size = New System.Drawing.Size(186, 22)
        Me.cboDevices.TabIndex = 9
        '
        'lblCommandName
        '
        Me.lblCommandName.AutoSize = True
        Me.lblCommandName.Location = New System.Drawing.Point(19, 220)
        Me.lblCommandName.Name = "lblCommandName"
        Me.lblCommandName.Size = New System.Drawing.Size(38, 13)
        Me.lblCommandName.TabIndex = 8
        Me.lblCommandName.Text = "Name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 172)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "4. Add command to your project"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(194, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "3. Choose CFLink Device to manipulate"
        '
        'txtCommandName
        '
        Me.txtCommandName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCommandName.Location = New System.Drawing.Point(63, 217)
        Me.txtCommandName.Name = "txtCommandName"
        Me.txtCommandName.Size = New System.Drawing.Size(174, 20)
        Me.txtCommandName.TabIndex = 12
        '
        'txtCommandValue
        '
        Me.txtCommandValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCommandValue.Location = New System.Drawing.Point(63, 243)
        Me.txtCommandValue.Name = "txtCommandValue"
        Me.txtCommandValue.Size = New System.Drawing.Size(174, 20)
        Me.txtCommandValue.TabIndex = 14
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Location = New System.Drawing.Point(20, 246)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(37, 13)
        Me.lblValue.TabIndex = 13
        Me.lblValue.Text = "Value:"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.AutoSize = True
        Me.btnAdd.Location = New System.Drawing.Point(149, 269)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(88, 23)
        Me.btnAdd.TabIndex = 15
        Me.btnAdd.Text = "Add To Project"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblSystem
        '
        Me.lblSystem.AutoSize = True
        Me.lblSystem.Location = New System.Drawing.Point(13, 192)
        Me.lblSystem.Name = "lblSystem"
        Me.lblSystem.Size = New System.Drawing.Size(44, 13)
        Me.lblSystem.TabIndex = 16
        Me.lblSystem.Text = "System:"
        '
        'cboSystems
        '
        Me.cboSystems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSystems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSystems.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSystems.FormattingEnabled = True
        Me.cboSystems.Location = New System.Drawing.Point(63, 189)
        Me.cboSystems.Name = "cboSystems"
        Me.cboSystems.Size = New System.Drawing.Size(135, 22)
        Me.cboSystems.TabIndex = 17
        '
        'btnRefreshSystems
        '
        Me.btnRefreshSystems.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshSystems.AutoSize = True
        Me.btnRefreshSystems.Image = CType(resources.GetObject("btnRefreshSystems.Image"), System.Drawing.Image)
        Me.btnRefreshSystems.Location = New System.Drawing.Point(204, 188)
        Me.btnRefreshSystems.Name = "btnRefreshSystems"
        Me.btnRefreshSystems.Size = New System.Drawing.Size(33, 23)
        Me.btnRefreshSystems.TabIndex = 18
        Me.btnRefreshSystems.UseVisualStyleBackColor = True
        '
        'btnGo
        '
        Me.btnGo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGo.AutoSize = True
        Me.btnGo.Enabled = False
        Me.btnGo.Location = New System.Drawing.Point(204, 135)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(33, 23)
        Me.btnGo.TabIndex = 19
        Me.btnGo.Text = "GO"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'frmCFLink
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(249, 302)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.btnRefreshSystems)
        Me.Controls.Add(Me.cboSystems)
        Me.Controls.Add(Me.lblSystem)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtCommandValue)
        Me.Controls.Add(Me.lblValue)
        Me.Controls.Add(Me.txtCommandName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboDevices)
        Me.Controls.Add(Me.lblCommandName)
        Me.Controls.Add(Me.lblFilenameInfo)
        Me.Controls.Add(Me.cboActions)
        Me.Controls.Add(Me.lblChooseAction)
        Me.Controls.Add(Me.cboFile)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.lblSelectCFLink)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimumSize = New System.Drawing.Size(249, 198)
        Me.Name = "frmCFLink"
        Me.Text = "CFLink Command Builder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSelectCFLink As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents dlgOpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cboFile As System.Windows.Forms.ComboBox
    Friend WithEvents cboActions As System.Windows.Forms.ComboBox
    Friend WithEvents lblChooseAction As System.Windows.Forms.Label
    Friend WithEvents lblFilenameInfo As System.Windows.Forms.Label
    Friend WithEvents cboDevices As System.Windows.Forms.ComboBox
    Friend WithEvents lblCommandName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCommandName As System.Windows.Forms.TextBox
    Friend WithEvents txtCommandValue As System.Windows.Forms.TextBox
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblSystem As System.Windows.Forms.Label
    Friend WithEvents cboSystems As System.Windows.Forms.ComboBox
    Friend WithEvents btnRefreshSystems As System.Windows.Forms.Button
    Friend WithEvents btnGo As System.Windows.Forms.Button
End Class
