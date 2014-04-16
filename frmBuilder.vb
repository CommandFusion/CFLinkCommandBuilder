Imports System.Windows.Forms
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Text.RegularExpressions
Imports GaDotNet.Common
Imports GaDotNet.Common.Data
Imports GaDotNet.Common.Helpers

Public Class frmBuilder
    Implements CommandFusion.CFPlugin

    Public Event AddCommand(sender As CommandFusion.CFPlugin, newCommand As CommandFusion.SystemCommand) Implements CommandFusion.CFPlugin.AddCommand
    Public Event AddFeedback(sender As CommandFusion.CFPlugin, newFB As CommandFusion.SystemFeedback) Implements CommandFusion.CFPlugin.AddFeedback
    Public Event AddMacro(sender As CommandFusion.CFPlugin, newMacro As CommandFusion.SystemMacro) Implements CommandFusion.CFPlugin.AddMacro
    Public Event AddMacros(sender As CommandFusion.CFPlugin, newMacros As List(Of CommandFusion.SystemMacro)) Implements CommandFusion.CFPlugin.AddMacros
    Public Event AddScript(sender As CommandFusion.CFPlugin, ScriptRelativePathToProject As String) Implements CommandFusion.CFPlugin.AddScript
    Public Event AddSystem(sender As CommandFusion.CFPlugin, newSystem As CommandFusion.JSONSystem) Implements CommandFusion.CFPlugin.AddSystem
    Public Event AppendSystem(sender As CommandFusion.CFPlugin, newSystem As CommandFusion.JSONSystem) Implements CommandFusion.CFPlugin.AppendSystem

    Public Event EditMacro(sender As CommandFusion.CFPlugin, existingMacro As String, newMacro As CommandFusion.SystemMacro) Implements CommandFusion.CFPlugin.EditMacro
    Public Event RequestMacroList(sender As CommandFusion.CFPlugin) Implements CommandFusion.CFPlugin.RequestMacroList
    Public Event RequestProjectFileInfo(sender As CommandFusion.CFPlugin) Implements CommandFusion.CFPlugin.RequestProjectFileInfo
    Public Event RequestSystemList(sender As CommandFusion.CFPlugin) Implements CommandFusion.CFPlugin.RequestSystemList
    Public Event ToggleWindow(sender As CommandFusion.CFPlugin) Implements CommandFusion.CFPlugin.ToggleWindow
    Public Event WriteToLog(sender As CommandFusion.CFPlugin, msg As String) Implements CommandFusion.CFPlugin.WriteToLog

    Private pathDiscovery As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & Path.DirectorySeparatorChar & "CommandFusion" & Path.DirectorySeparatorChar & "SystemCommander" & Path.DirectorySeparatorChar & "discovery" & Path.DirectorySeparatorChar
    Private discoveredDevices As Dictionary(Of String, Object)
    Private availableActions As Dictionary(Of String, List(Of Object))
    Private ListOfSystems As List(Of CommandFusion.JSONSystem)
    Private ListOfSystemTypes As List(Of CommandFusion.JSONSystem)
    Private Const NewSystem As String = "Create New System..."
    Private Const OnboardSerialPort As String = "On-board"
    Private Const CCF As String = "Raw CCF Hex Code"
    Private Const GADomain As String = "commandfusion.com"
    Private Const GAEventCategory As String = "CFLink Command Builder"
    Private Const GACode As String = "UA-1634994-6"
    Dim statsMenu As New MenuItem("Send Anonymous Stats")

    Private SelectedAction As String = "Ethernet"
    Private SelectedDevice As Dictionary(Of String, Object)
    Private SelectedModule As Dictionary(Of String, Object)
    Private LastSystemName As String = NewSystem

#Region "Plugin Implementation"
    Public ReadOnly Property Author As String Implements CommandFusion.CFPlugin.Author
        Get
            Return "CommandFusion"
        End Get
    End Property

    Public ReadOnly Property Form As Windows.Forms.Form Implements CommandFusion.CFPlugin.Form
        Get
            Return Me
        End Get
    End Property

    Public Sub DisposePlugin() Implements CommandFusion.CFPlugin.DisposePlugin

    End Sub

    Public Sub GetProjectFileInfo(ProjectFile As IO.FileInfo) Implements CommandFusion.CFPlugin.GetProjectFileInfo

    End Sub

    Public Sub Init(menu As Windows.Forms.MainMenu) Implements CommandFusion.CFPlugin.Init
        Dim pluginMenu As New MenuItem(Me.Name1)
        Dim showHideMenu As New MenuItem("Toggle Window")
        statsMenu.Checked = My.Settings.sendStats

        AddHandler showHideMenu.Click, AddressOf Me.DoToggleWindow
        AddHandler statsMenu.Click, AddressOf Me.DoToggleStats

        pluginMenu.MenuItems.Add(showHideMenu)
        pluginMenu.MenuItems.Add(statsMenu)

        menu.MenuItems.Add(pluginMenu)

        ' Hide the tab buttons, because we only ever show one tab at a time for a dynamic interface
        tabMain.Appearance = TabAppearance.Buttons
        tabMain.SizeMode = TabSizeMode.Fixed
        tabMain.ItemSize = New Drawing.Size(0, 1)

        HideAllTabs()

        tabMain.TabPages.Add(tabHelp)

        LoadOnboardDatabase()
    End Sub

    Public Sub DoToggleWindow(ByVal sender As Object, ByVal e As System.EventArgs)
        RaiseEvent ToggleWindow(Me)
    End Sub

    Public Sub DoToggleStats(ByVal sender As Object, ByVal e As System.EventArgs)
        If My.Settings.sendStats Then
            If MsgBox("Anonymous usage statistics are used to improve our products and no personally identifiable data is tracked." & Environment.NewLine & "Are you sure you want to opt out of sending anonymous usage statistics?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                My.Settings.sendStats = False
                statsMenu.Checked = False
            End If
        Else
            MsgBox("Thank you for enabling anonymous usage statistics. We use this data to improve our products and it does not contain any personally identifiable data.")
            My.Settings.sendStats = True
            statsMenu.Checked = True
        End If
    End Sub

    Public ReadOnly Property Name1 As String Implements CommandFusion.CFPlugin.Name
        Get
            Return "CFLink Command Builder"
        End Get
    End Property

    Public Sub ProjectSelected(selected As Boolean) Implements CommandFusion.CFPlugin.ProjectSelected
        EnableCommandObjects(selected)
        RaiseEvent RequestSystemList(Me)
    End Sub

    Public Sub UpdateMacroList(systemList As List(Of CommandFusion.SystemMacro)) Implements CommandFusion.CFPlugin.UpdateMacroList

    End Sub

    Public Sub UpdateSystemList(systemList As List(Of CommandFusion.JSONSystem), systemTypes As List(Of CommandFusion.JSONSystem)) Implements CommandFusion.CFPlugin.UpdateSystemList
        ListOfSystems = systemList
        ListOfSystemTypes = systemTypes
        cboSystems.Items.Clear()
        cboSystems.Items.Add(NewSystem)
        cboSystems.SelectedIndex = 0
        If systemList IsNot Nothing Then
            For Each aSystem As CommandFusion.JSONSystem In systemList
                cboSystems.Items.Add(aSystem.ToString)
                If LastSystemName = aSystem.Name Then
                    cboSystems.SelectedIndex = cboSystems.Items.Count - 1
                End If
            Next
        End If
    End Sub
#End Region

    Public Function GetSystemByID(ByVal ID As String) As CommandFusion.JSONSystem
        Return ListOfSystemTypes.Find(Function(s) s.ID = ID)
    End Function

    Private Function GetSystem(ByVal name As String) As CommandFusion.JSONSystem
        If ListOfSystems Is Nothing Then
            Return Nothing
        End If

        For Each aSystem As CommandFusion.JSONSystem In ListOfSystems
            If aSystem.ToString = name Then
                Return aSystem
            End If
        Next
        Return Nothing
    End Function

    Private Function GetDeviceBySerial(ByVal serial As String) As Dictionary(Of String, Object)
        If discoveredDevices Is Nothing OrElse Not discoveredDevices.ContainsKey("DeviceList") Then
            Return Nothing
        End If
        For Each aDevice As Dictionary(Of String, Object) In discoveredDevices("DeviceList")
            If aDevice.ContainsKey("SerialNo") AndAlso aDevice("SerialNo") = serial Then
                Return aDevice
            End If
        Next
        Return Nothing
    End Function

    Private Sub AddDeviceToAction(ByVal action As String, ByVal device As Dictionary(Of String, Object))
        ' Only add the device to the action if the device is not already associated with the action
        If Not availableActions(action).Contains(device) Then
            availableActions(action).Add(device)
        End If
    End Sub

    Private Sub toolStrip_Resize(sender As Object, e As EventArgs) Handles ToolStrip.Resize
        cboFiles.Width = btnBrowse.Bounds.Left - lblSelectExport.Bounds.Right - 10
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        dlgOpenFile.InitialDirectory = pathDiscovery
        If dlgOpenFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            cboFiles.Text = dlgOpenFile.FileName
            OpenFile(dlgOpenFile.FileName)
        End If
    End Sub

    Private Sub cboFile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFiles.SelectedIndexChanged
        OpenFile(cboFiles.SelectedItem)
    End Sub

    Public Sub LogEvent(ByVal eventAction As String, ByVal eventLabel As String)
        If My.Settings.sendStats Then
            Dim googleEvent As New GoogleEvent(GADomain, GAEventCategory, eventAction, eventLabel)
            Dim request As TrackingRequest
            request = New RequestFactory(GACode).BuildRequest(googleEvent)
            GoogleTracking.FireTrackingEvent(request)
        End If
    End Sub

    Public Sub OpenFile(ByVal theFile As String)
        If Not File.Exists(theFile) Then
            If File.Exists(pathDiscovery & theFile) Then
                theFile = pathDiscovery & theFile
            Else
                Exit Sub
            End If
        End If
        lblFile.Text = New FileInfo(theFile).Name

        ' Log event
        LogEvent("Loaded Export File", lblFile.Text)

        'lblFilenameInfo.Visible = True
        Dim contents As String = File.ReadAllText(theFile)
        Dim json As New JavaScriptSerializer()
        Try
            discoveredDevices = json.DeserializeObject(contents)
            If Not discoveredDevices.ContainsKey("DeviceList") Then
                MsgBox("The device discovery export file is missing required data. Please try exporting from System Commander again.")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("The device discovery export file is invalid or corrupt. Please try exporting from System Commander again.")
            Exit Sub
        End Try

        ' Setup containers for devices and actions
        Dim deviceCount As Integer = discoveredDevices("DeviceList").Length
        availableActions = New Dictionary(Of String, List(Of Object))
        availableActions("Ethernet") = New List(Of Object)
        availableActions("Serial") = New List(Of Object)
        availableActions("IR") = New List(Of Object)
        availableActions("Relay") = New List(Of Object)
        availableActions("IO Port") = New List(Of Object)
        availableActions("LED") = New List(Of Object)
        availableActions("LED Backlight") = New List(Of Object)

        For Each aDevice As Dictionary(Of String, Object) In discoveredDevices("DeviceList")
            Select Case aDevice("Model")
                Case "LANBridge"
                    AddDeviceToAction("Ethernet", aDevice)
                    If aDevice.ContainsKey("COMMode") AndAlso aDevice("COMMode") = "232" Then
                        AddDeviceToAction("Serial", aDevice)
                    End If

                Case "DIN-MOD4", "MOD4"
                    If aDevice.ContainsKey("COMMode") AndAlso aDevice("COMMode") = "232" Then
                        AddDeviceToAction("Serial", aDevice)
                    End If
                    If aDevice.ContainsKey("Modules") Then
                        ' Loop through the modules
                        For Each aModule As Dictionary(Of String, Object) In aDevice("Modules")
                            Select Case aModule("Model")
                                Case "MOD-IO8"
                                    AddDeviceToAction("IO Port", aDevice)
                                Case "MOD-IR8"
                                    AddDeviceToAction("IR", aDevice)
                                Case "MOD-COM4"
                                    AddDeviceToAction("Serial", aDevice)
                                Case "MOD-LRY8", "MOD-HRY2", "MOD-RY4", "MOD-SSRY4"
                                    AddDeviceToAction("Relay", aDevice)
                            End Select
                        Next
                    End If
                Case "CFMini"
                    If aDevice.ContainsKey("COMMode") AndAlso aDevice("COMMode") = "232" Then
                        AddDeviceToAction("Serial", aDevice)
                    End If
                    AddDeviceToAction("IO Port", aDevice)
                    AddDeviceToAction("IR", aDevice)
                    AddDeviceToAction("Relay", aDevice)
                Case "IRBlaster"
                    AddDeviceToAction("IR", aDevice)
                Case "SW16"
                    AddDeviceToAction("LED", aDevice)
                    AddDeviceToAction("LED Backlight", aDevice)
                Case Else
                    MsgBox("Unknown Model: " & aDevice("Model"))
            End Select
        Next
        UpdateTree()

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Directory.Exists(pathDiscovery) Then
            Exit Sub
        End If

        For Each aFile As String In Directory.GetFiles(pathDiscovery, "*.json")
            cboFiles.Items.Add(New FileInfo(aFile).Name)
        Next
    End Sub

    Private Sub UpdateTree()
        treeDevices.Nodes.Clear()
        For Each anAction As String In availableActions.Keys
            Dim actionNode As New TreeNode(anAction)
            Select Case anAction
                Case "Ethernet"
                    actionNode.ImageIndex = 1
                    actionNode.SelectedImageIndex = 1
                Case "Serial"
                    actionNode.ImageIndex = 2
                    actionNode.SelectedImageIndex = 2
                Case "IR"
                    actionNode.ImageIndex = 3
                    actionNode.SelectedImageIndex = 3
                Case "Relay"
                    actionNode.ImageIndex = 4
                    actionNode.SelectedImageIndex = 4
                Case "IO Port"
                    actionNode.ImageIndex = 5
                    actionNode.SelectedImageIndex = 5
                Case "LED", "LED Backlight"
                    actionNode.ImageIndex = 6
                    actionNode.SelectedImageIndex = 6
                Case Else
                    actionNode.ImageIndex = -1
                    actionNode.SelectedImageIndex = -1
            End Select


            For Each aDevice As Dictionary(Of String, Object) In availableActions(anAction)
                Dim deviceNode As New TreeNode("[" & Integer2HexString(aDevice("CFLinkID")) & "] " & aDevice("Model") & ", " & aDevice("SerialNo"))
                deviceNode.Tag = aDevice
                deviceNode.ImageIndex = -1
                deviceNode.SelectedImageIndex = -1
                deviceNode.NodeFont = New System.Drawing.Font(Me.Font, Drawing.FontStyle.Regular)
                actionNode.Nodes.Add(deviceNode)
                If aDevice.ContainsKey("Modules") Then
                    For Each aModule As Dictionary(Of String, Object) In aDevice("Modules")
                        If anAction.StartsWith(aModule("ModuleType")) Then
                            Dim moduleNode As New TreeNode(aModule("Model"))
                            moduleNode.Tag = aModule
                            moduleNode.ToolTipText = "Module Slot " & aModule("ModuleNumber")
                            moduleNode.ImageIndex = 6 + aModule("ModuleNumber")
                            moduleNode.SelectedImageIndex = 6 + aModule("ModuleNumber")
                            moduleNode.NodeFont = New System.Drawing.Font(Me.Font, Drawing.FontStyle.Regular)
                            deviceNode.Nodes.Add(moduleNode)
                        End If
                    Next
                End If
                ' Force modular controller nodes to expand to show their modules
                deviceNode.Expand()
            Next
            If actionNode.Nodes.Count > 0 Then
                treeDevices.Nodes.Add(actionNode)
            End If
        Next

        HideAllTabs()

        tabMain.TabPages.Add(tabHelp)
    End Sub

    Public Sub HideAllTabs()
        tabMain.TabPages.Clear()
    End Sub

    Private Sub treeDevices_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles treeDevices.AfterSelect
        If e.Node.Level = 0 Then
            SelectedAction = e.Node.Text
            Exit Sub
        ElseIf e.Node.Level = 1 Then
            SelectedAction = e.Node.Parent.Text
            InitPanels(e.Node.Tag)
        ElseIf e.Node.Level = 2 Then
            SelectedAction = e.Node.Parent.Parent.Text
            InitPanels(e.Node.Parent.Tag, e.Node.Tag)
        End If
        treeDevices.Focus()
    End Sub

    'Private Sub treeDevices_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles treeDevices.NodeMouseClick
    '    If e.Node.Level = 1 Then
    '        'SelectedAction = e.Node.Parent.Text
    '        If e.Node.Nodes.Count > 0 Then
    '            ' Selected a modular controller node, so select the first node instead
    '            e.Node.Expand()
    '            treeDevices.SelectedNode = e.Node.Nodes(0)
    '            treeDevices.Focus()
    '            'InitPanels(e.Node.Tag, e.Node.Nodes(0).Tag)
    '        End If
    '    End If
    'End Sub

    Public Sub InitPanels(ByVal aDevice As Dictionary(Of String, Object), Optional ByVal aModule As Dictionary(Of String, Object) = Nothing)
        HideAllTabs()
        SelectedDevice = aDevice
        SelectedModule = aModule
        If aModule Is Nothing Then
            If aDevice.ContainsKey("Model") Then
                Select Case aDevice("Model")
                    Case "CFMini"
                        Select Case SelectedAction
                            Case "Relay"
                                tabMain.TabPages.Add(tabRelays)
                                ' 4 relay ports on-board
                                While dgvPortsRelay.RowCount > 4
                                    dgvPortsRelay.Rows.RemoveAt(dgvPortsRelay.RowCount - 1)
                                End While
                                While dgvPortsRelay.RowCount < 4
                                    dgvPortsRelay.Rows.Add(False, PadZero(dgvPortsRelay.RowCount + 1), "OPEN", 0.1)
                                End While
                            Case "IO Port"
                                dgvPortsIO.Rows.Clear()
                                ' Check to see what IO ports are configured as OUTPUTS on this device
                                For Each aPort As Dictionary(Of String, Object) In aDevice("IOPorts")
                                    If aPort("Mode") > 0 Then
                                        dgvPortsIO.Rows.Add(False, PadZero(aPort("Number")), "OPEN", 0.1)
                                    End If
                                Next
                                If dgvPortsIO.RowCount > 0 Then
                                    tabMain.TabPages.Add(tabIO)
                                Else
                                    lblErrorMsg.Text = "This device does not have any IO ports configured in Output modes. Only output commands can be generated."
                                    tabMain.TabPages.Add(tabError)
                                End If
                            Case "Serial"
                                tabMain.TabPages.Add(tabSerial)
                                ' 1 on-board RS232 port
                                While dgvPortsSerial.RowCount > 1
                                    dgvPortsSerial.Rows.RemoveAt(dgvPortsSerial.RowCount - 1)
                                End While
                                While dgvPortsSerial.RowCount < 1
                                    dgvPortsSerial.Rows.Add(OnboardSerialPort, "")
                                End While
                                dgvPortsSerial.Rows(0).Cells(0).Value = OnboardSerialPort
                            Case "IR"
                                tabMain.TabPages.Add(tabIR)
                                ' 8 IR ports on board
                                While dgvPortsIR.RowCount > 8
                                    dgvPortsIR.Rows.RemoveAt(dgvPortsIR.RowCount - 1)
                                End While
                                While dgvPortsIR.RowCount < 8
                                    dgvPortsIR.Rows.Add(PadZero(dgvPortsIR.RowCount + 1), CCF)
                                End While
                                cboIRPort.Items.Clear()
                                For i As Integer = 1 To 8
                                    cboIRPort.Items.Add(PadZero(i))
                                    dgvPortsIR.Rows(i - 1).Cells(0).Value = PadZero(i)
                                Next
                                cboIRPort.SelectedIndex = 0
                        End Select
                    Case "IRBlaster"
                        Select Case SelectedAction
                            Case "IR"
                                tabMain.TabPages.Add(tabIR)
                                ' 2 IR ports on board
                                While dgvPortsIR.RowCount > 2
                                    dgvPortsIR.Rows.RemoveAt(dgvPortsIR.RowCount - 1)
                                End While
                                While dgvPortsIR.RowCount < 2
                                    dgvPortsIR.Rows.Add(PadZero(dgvPortsIR.RowCount + 1), CCF)
                                End While
                                dgvPortsIR.Rows(0).Cells(0).Value = "Blaster"
                                dgvPortsIR.Rows(1).Cells(0).Value = "Emitter"
                                cboIRPort.Items.Clear()
                                cboIRPort.Items.AddRange({"Blaster", "Emitter"})
                                cboIRPort.SelectedIndex = 0
                        End Select
                    Case "LANBridge"
                        Select Case SelectedAction
                            Case "Serial"
                                tabMain.TabPages.Add(tabSerial)
                                ' 1 on-board RS232 port
                                While dgvPortsSerial.RowCount > 1
                                    dgvPortsSerial.Rows.RemoveAt(dgvPortsSerial.RowCount - 1)
                                End While
                                While dgvPortsSerial.RowCount < 1
                                    dgvPortsSerial.Rows.Add(OnboardSerialPort, "")
                                End While
                                dgvPortsSerial.Rows(0).Cells(0).Value = OnboardSerialPort
                            Case "Ethernet"
                                If aDevice.ContainsKey("Slots") Then
                                    tabMain.TabPages.Add(tabEthernet)
                                    ' add all communication slots, even disabled ones
                                    While dgvPortsEthernet.RowCount > aDevice("Slots").Length
                                        dgvPortsEthernet.Rows.RemoveAt(dgvPortsEthernet.RowCount - 1)
                                    End While
                                    While dgvPortsEthernet.RowCount < aDevice("Slots").Length
                                        dgvPortsEthernet.Rows.Add("00", "Updating...")
                                    End While
                                    ' update each slot details and data field states
                                    Dim i As Integer = 0
                                    For Each aSlot As Dictionary(Of String, Object) In aDevice("Slots")
                                        dgvPortsEthernet.Rows(i).Cells(0).Value = aSlot("Number")
                                        If aSlot("ConnType") = "OFF" Then
                                            dgvPortsEthernet.Rows(i).Cells(1).Value = aSlot("ConnType")
                                            dgvPortsEthernet.Rows(i).Cells(2).ReadOnly = True
                                            dgvPortsEthernet.Rows(i).Cells(2).Style.ForeColor = Drawing.Color.Gray
                                            dgvPortsEthernet.Rows(i).Cells(2).Style.BackColor = Drawing.Color.LightGray
                                            dgvPortsEthernet.Rows(i).Cells(2).Style.SelectionForeColor = Drawing.Color.Gray
                                            dgvPortsEthernet.Rows(i).Cells(2).Style.SelectionBackColor = Drawing.Color.LightGray
                                        Else
                                            dgvPortsEthernet.Rows(i).Cells(1).Value = aSlot("ConnType") & " " & aSlot("ConnMode") & ", " & aSlot("IP") & ":" & aSlot("Port")
                                            dgvPortsEthernet.Rows(i).Cells(2).ReadOnly = False
                                            dgvPortsEthernet.Rows(i).Cells(2).Style.ForeColor = Drawing.SystemColors.ControlText
                                            dgvPortsEthernet.Rows(i).Cells(2).Style.BackColor = Drawing.SystemColors.Window
                                            dgvPortsEthernet.Rows(i).Cells(2).Style.SelectionForeColor = Drawing.SystemColors.HighlightText
                                            dgvPortsEthernet.Rows(i).Cells(2).Style.SelectionBackColor = Drawing.SystemColors.Highlight
                                        End If

                                        i += 1
                                    Next
                                Else
                                    tabMain.TabPages.Add(tabError)
                                    lblErrorMsg.Text = "An invalid Ethernet device was selected (missing Ethernet slot configurations)."
                                End If

                        End Select
                    Case "DIN-MOD4", "MOD4"
                        Select Case SelectedAction
                            Case "Serial"
                                tabMain.TabPages.Add(tabSerial)
                                ' 1 on-board RS232 port
                                While dgvPortsSerial.RowCount > 1
                                    dgvPortsSerial.Rows.RemoveAt(dgvPortsSerial.RowCount - 1)
                                End While
                                While dgvPortsSerial.RowCount < 1
                                    dgvPortsSerial.Rows.Add(OnboardSerialPort, "")
                                End While
                                dgvPortsSerial.Rows(0).Cells(0).Value = OnboardSerialPort
                        End Select
                    Case "SW16"
                        tabMain.TabPages.Add(tabLED)
                        Select Case SelectedAction
                            Case "LED Backlight"
                                'Me.Text = "Build Backlight LED Command"
                                ' Add the backlight LED ports
                                While dgvPortsLED.RowCount > 4
                                    dgvPortsLED.Rows.RemoveAt(dgvPortsLED.RowCount - 1)
                                End While
                                While dgvPortsLED.RowCount < 4
                                    dgvPortsLED.Rows.Add(False, PadZero(dgvPortsLED.RowCount + 1), "OFF", 1.0, 0, 100, 1.0, 1.0, 0)
                                End While
                            Case Else
                                'Me.Text = "Build LED Command"
                                ' Add the LED ports
                                While dgvPortsLED.RowCount > 16
                                    dgvPortsLED.Rows.RemoveAt(dgvPortsLED.RowCount - 1)
                                End While
                                While dgvPortsLED.RowCount < 16
                                    dgvPortsLED.Rows.Add(False, PadZero(dgvPortsLED.RowCount + 1), "OFF", 1.0, 0, 100, 1.0, 1.0, 0)
                                End While
                        End Select
                End Select
            End If
        Else
            Select Case SelectedAction
                Case "Relay"
                    tabMain.TabPages.Add(tabRelays)
                    ' Show the correct number of relay ports based on the module properties
                    While dgvPortsRelay.RowCount > aModule("NumPorts")
                        dgvPortsRelay.Rows.RemoveAt(dgvPortsRelay.RowCount - 1)
                    End While
                    While dgvPortsRelay.RowCount < aModule("NumPorts")
                        dgvPortsRelay.Rows.Add(False, PadZero(dgvPortsRelay.RowCount + 1), "OPEN", 0.1)
                    End While
                Case "IO Port"
                    dgvPortsIO.Rows.Clear()
                    ' Check to see what IO ports are configured as OUTPUTS on this device
                    For Each aPort As Dictionary(Of String, Object) In aModule("Ports")
                        If aPort("Mode") > 0 Then
                            dgvPortsIO.Rows.Add(False, PadZero(aPort("Number")), "OPEN", 0.1)
                        End If
                    Next
                    If dgvPortsIO.RowCount > 0 Then
                        tabMain.TabPages.Add(tabIO)
                    Else
                        lblErrorMsg.Text = "This module does not have any IO ports configured in Output modes. Only output commands can be generated."
                        tabMain.TabPages.Add(tabError)
                    End If
                Case "Serial"
                    dgvPortsSerial.Rows.Clear()
                    ' Check to see what Serial ports are configured
                    For Each aPort As Dictionary(Of String, Object) In aModule("Ports")
                        If aPort("Mode") > 0 Then
                            dgvPortsSerial.Rows.Add(PadZero(aPort("Number")), "")
                        End If
                    Next
                    If dgvPortsSerial.RowCount > 0 Then
                        tabMain.TabPages.Add(tabSerial)
                    Else
                        lblErrorMsg.Text = "This module does not have any serial ports configured in Output modes. Serial ports configured as 'OFF' will be ignored."
                        tabMain.TabPages.Add(tabError)
                    End If
                Case "IR"
                    tabMain.TabPages.Add(tabIR)
                    ' Show the correct number of IR ports based on the module properties
                    While dgvPortsIR.RowCount > aModule("NumPorts")
                        dgvPortsIR.Rows.RemoveAt(dgvPortsIR.RowCount - 1)
                    End While
                    While dgvPortsIR.RowCount < aModule("NumPorts")
                        dgvPortsIR.Rows.Add(PadZero(dgvPortsIR.RowCount + 1), CCF)
                    End While
                    cboIRPort.Items.Clear()
                    For i As Integer = 1 To aModule("NumPorts")
                        cboIRPort.Items.Add(PadZero(i))
                        dgvPortsIR.Rows(i - 1).Cells(0).Value = PadZero(i)
                    Next
                    cboIRPort.SelectedIndex = 0
            End Select
        End If
    End Sub

#Region "ETHERNET"
    Private Sub btnGenerateEthernet_Click(sender As Object, e As EventArgs) Handles btnGenerateEthernet.Click
        ' Loop through ethernet slots
        Dim dataString As String = ""
        Dim commandName As String = ""
        Dim found As Boolean = False
        For i As Integer = 0 To dgvPortsEthernet.Rows.Count - 1
            If dgvPortsEthernet.Rows(i).Cells(1).Value <> "OFF" AndAlso dgvPortsEthernet.Rows(i).Cells(2).Value <> "" Then
                If found Then
                    MsgBox("Only one ethernet slot command can be built at a time. The command has been generated for the first slot in the list only." & Environment.NewLine & _
                           "If you want to create commands for additional slots, please define them individually before adding to your project.")
                    Exit For
                Else
                    ' slot has data to send, so add it to the command string
                    commandName &= "-SLOT" & dgvPortsEthernet.Rows(i).Cells(0).Value
                    dataString &= PadZero(dgvPortsEthernet.Rows(i).Cells(0).Value) & ":" & dgvPortsEthernet.Rows(i).Cells(2).Value
                    found = True
                End If

            End If
        Next

        ' Check that at least one slot was used to send data
        If dataString = "" Then
            MsgBox("You must enter data for at least one ethernet slot to generate the CFLink command.")
            Exit Sub
        End If

        txtCommandValue.Text = BuildCFLinkCommandRAW(SelectedDevice("CFLinkID"), "TLANSND", dataString)
        txtCommandName.Text = SelectedDevice("Model") & "-" & Integer2HexString(SelectedDevice("CFLinkID")) & "_ETH" & commandName

        ' Log event
        LogEvent("Generated Command", "Ethernet")
    End Sub
#End Region

#Region "LED"
    Private Sub dgvPortsLED_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPortsLED.CellValueChanged
        If dgvPortsLED.CurrentCell IsNot Nothing Then
            If dgvPortsLED.CurrentCell.ColumnIndex = 2 Then
                ' Dropdown list change
                If e IsNot Nothing Then
                    dgvPortsLED.SuspendLayout()
                End If
                Select Case dgvPortsLED.CurrentCell.Value.ToString
                    Case "OFF", "ON", "TOGGLE"
                        For i As Integer = 3 To 8
                            dgvPortsLED.CurrentRow.Cells(i).ReadOnly = True
                            dgvPortsLED.CurrentRow.Cells(i).Style.ForeColor = Drawing.Color.Gray
                            dgvPortsLED.CurrentRow.Cells(i).Style.BackColor = Drawing.Color.LightGray
                            dgvPortsLED.CurrentRow.Cells(i).Style.SelectionForeColor = Drawing.Color.Gray
                            dgvPortsLED.CurrentRow.Cells(i).Style.SelectionBackColor = Drawing.Color.LightGray
                        Next
                    Case "PULSE"
                        dgvPortsLED.CurrentRow.Cells(3).ReadOnly = False
                        dgvPortsLED.CurrentRow.Cells(3).Style.ForeColor = Drawing.SystemColors.ControlText
                        dgvPortsLED.CurrentRow.Cells(3).Style.BackColor = Drawing.SystemColors.Window
                        dgvPortsLED.CurrentRow.Cells(3).Style.SelectionForeColor = Drawing.SystemColors.HighlightText
                        dgvPortsLED.CurrentRow.Cells(3).Style.SelectionBackColor = Drawing.SystemColors.Highlight
                        For i As Integer = 4 To 8
                            dgvPortsLED.CurrentRow.Cells(i).ReadOnly = True
                            dgvPortsLED.CurrentRow.Cells(i).Style.ForeColor = Drawing.Color.Gray
                            dgvPortsLED.CurrentRow.Cells(i).Style.BackColor = Drawing.Color.LightGray
                            dgvPortsLED.CurrentRow.Cells(i).Style.SelectionForeColor = Drawing.Color.Gray
                            dgvPortsLED.CurrentRow.Cells(i).Style.SelectionBackColor = Drawing.Color.LightGray
                        Next
                    Case "BLINK", "DIM"
                        dgvPortsLED.CurrentRow.Cells(3).ReadOnly = True
                        dgvPortsLED.CurrentRow.Cells(3).Style.ForeColor = Drawing.Color.Gray
                        dgvPortsLED.CurrentRow.Cells(3).Style.BackColor = Drawing.Color.LightGray
                        dgvPortsLED.CurrentRow.Cells(3).Style.SelectionForeColor = Drawing.Color.Gray
                        dgvPortsLED.CurrentRow.Cells(3).Style.SelectionBackColor = Drawing.Color.LightGray
                        For i As Integer = 4 To 8
                            dgvPortsLED.CurrentRow.Cells(i).ReadOnly = False
                            dgvPortsLED.CurrentRow.Cells(i).Style.ForeColor = Drawing.SystemColors.ControlText
                            dgvPortsLED.CurrentRow.Cells(i).Style.BackColor = Drawing.SystemColors.Window
                            dgvPortsLED.CurrentRow.Cells(i).Style.SelectionForeColor = Drawing.SystemColors.HighlightText
                            dgvPortsLED.CurrentRow.Cells(i).Style.SelectionBackColor = Drawing.SystemColors.Highlight
                        Next
                    Case "RAMP"
                        For i As Integer = 3 To 4
                            dgvPortsLED.CurrentRow.Cells(i).ReadOnly = False
                            dgvPortsLED.CurrentRow.Cells(i).Style.ForeColor = Drawing.SystemColors.ControlText
                            dgvPortsLED.CurrentRow.Cells(i).Style.BackColor = Drawing.SystemColors.Window
                            dgvPortsLED.CurrentRow.Cells(i).Style.SelectionForeColor = Drawing.SystemColors.HighlightText
                            dgvPortsLED.CurrentRow.Cells(i).Style.SelectionBackColor = Drawing.SystemColors.Highlight
                        Next

                        For i As Integer = 5 To 8
                            dgvPortsLED.CurrentRow.Cells(i).ReadOnly = True
                            dgvPortsLED.CurrentRow.Cells(i).Style.ForeColor = Drawing.Color.Gray
                            dgvPortsLED.CurrentRow.Cells(i).Style.BackColor = Drawing.Color.LightGray
                            dgvPortsLED.CurrentRow.Cells(i).Style.SelectionForeColor = Drawing.Color.Gray
                            dgvPortsLED.CurrentRow.Cells(i).Style.SelectionBackColor = Drawing.Color.LightGray
                        Next
                End Select
                If e IsNot Nothing Then
                    dgvPortsLED.ResumeLayout()
                    dgvPortsLED.Refresh()
                End If
            End If
        End If
    End Sub

    Private Sub dgvPortsLED_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvPortsLED.CurrentCellDirtyStateChanged
        dgvPortsLED.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange)
    End Sub

    Private Sub dgvPortsLED_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles dgvPortsLED.EditingControlShowing
        If dgvPortsLED.CurrentCell.ColumnIndex > 2 Then
            Dim txtEdit As TextBox = e.Control
            'remove any existing handler
            RemoveHandler txtEdit.KeyPress, AddressOf txtEditLED_Keypress
            AddHandler txtEdit.KeyPress, AddressOf txtEditLED_Keypress
        End If
    End Sub

    Private Sub txtEditLED_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Test for numeric value or backspace in first column
        If dgvPortsLED.CurrentCell.ColumnIndex = 3 Or dgvPortsLED.CurrentCell.ColumnIndex = 6 Or dgvPortsLED.CurrentCell.ColumnIndex = 7 Then
            If IsNumeric(e.KeyChar.ToString()) _
            Or e.KeyChar = ChrW(Keys.Back) _
            Or e.KeyChar = "." Then
                e.Handled = False 'if numeric display 
            Else
                e.Handled = True  'if non numeric don't display
            End If
        ElseIf dgvPortsLED.CurrentCell.ColumnIndex = 4 Or dgvPortsLED.CurrentCell.ColumnIndex = 5 Or dgvPortsLED.CurrentCell.ColumnIndex = 8 Then
            If IsNumeric(e.KeyChar.ToString()) _
            Or e.KeyChar = ChrW(Keys.Back) Then
                e.Handled = False 'if numeric display 
            Else
                e.Handled = True  'if non numeric don't display
            End If
        End If
    End Sub

    Private Sub dgvPortsLED_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvPortsLED.CellValidating
        Try
            If dgvPortsLED.CurrentCell.ColumnIndex = 6 Or dgvPortsLED.CurrentCell.ColumnIndex = 7 Then
                ' Pulse time change
                If dgvPortsLED.CurrentCell.Value.ToString = "" OrElse dgvPortsLED.CurrentCell.Value.ToString < 0.1 Then
                    MsgBox("A minimum of 0.1 seconds is required.")
                    dgvPortsLED.CurrentCell.Value = 0.1
                    e.Cancel = True
                ElseIf dgvPortsLED.CurrentCell.Value.ToString = "" OrElse dgvPortsLED.CurrentCell.Value.ToString > 999.9 Then
                    MsgBox("A maximum of 999.9 seconds is allowed.")
                    dgvPortsLED.CurrentCell.Value = 999.9
                    e.Cancel = True
                End If
            ElseIf dgvPortsLED.CurrentCell.ColumnIndex = 4 Or dgvPortsLED.CurrentCell.ColumnIndex = 5 Then
                ' min or max level change
                If dgvPortsLED.CurrentCell.Value.ToString = "" OrElse (dgvPortsLED.CurrentCell.Value.ToString < 0 Or dgvPortsLED.CurrentCell.Value.ToString > 100) Then
                    MsgBox("LED levels must be within the range 0 to 100.")
                    e.Cancel = True
                ElseIf dgvPortsLED.CurrentCell.ColumnIndex = 5 AndAlso dgvPortsLED.CurrentCell.Value.ToString = 0 Then
                    MsgBox("LED max level must be above 0 (zero).")
                    e.Cancel = True
                ElseIf Integer.Parse(dgvPortsLED.CurrentRow.Cells(5).Value.ToString) < Integer.Parse(dgvPortsLED.CurrentRow.Cells(4).Value.ToString) Then
                    MsgBox("LED max level must be greater than the LED min value.")
                    e.Cancel = True
                End If
            End If
        Catch ex As NullReferenceException
        End Try
    End Sub

    Private Sub btnGenerateLED_Click(sender As Object, e As EventArgs) Handles btnGenerateLED.Click
        ' Loop through selected LED ports
        Dim dataString As String = ""
        Dim commandName As String = ""
        For i As Integer = 0 To dgvPortsLED.Rows.Count - 1
            If dgvPortsLED.Rows(i).Cells(0).Value = True Then
                ' port is selected, so add it to the command string, with its config details
                dataString &= "|P" & PadZero(dgvPortsLED.Rows(i).Cells(1).Value) & ":"
                Select Case dgvPortsLED.Rows(i).Cells(2).Value.ToString
                    Case "OFF"
                        dataString &= "0"
                    Case "ON"
                        dataString &= "1"
                    Case "TOGGLE"
                        dataString &= "T"
                    Case "PULSE"
                        dataString &= "P:" & PadZero(dgvPortsLED.Rows(i).Cells(3).Value.ToString * 10, 4)
                    Case "BLINK"
                        dataString &= "B:" & PadZero(dgvPortsLED.Rows(i).Cells(4).Value.ToString, 3) & ":" & PadZero(dgvPortsLED.Rows(i).Cells(5).Value.ToString, 3) & ":" & PadZero(dgvPortsLED.Rows(i).Cells(6).Value.ToString * 10, 4) & ":" & PadZero(dgvPortsLED.Rows(i).Cells(7).Value.ToString * 10, 4) & ":" & PadZero(dgvPortsLED.Rows(i).Cells(8).Value.ToString, 4)
                    Case "DIM"
                        dataString &= "D:" & PadZero(dgvPortsLED.Rows(i).Cells(4).Value.ToString, 3) & ":" & PadZero(dgvPortsLED.Rows(i).Cells(5).Value.ToString, 3) & ":" & PadZero(dgvPortsLED.Rows(i).Cells(6).Value.ToString * 10, 4) & ":" & PadZero(dgvPortsLED.Rows(i).Cells(7).Value.ToString * 10, 4) & ":" & PadZero(dgvPortsLED.Rows(i).Cells(8).Value.ToString, 4)
                    Case "RAMP"
                        dataString &= "R:" & PadZero(dgvPortsLED.Rows(i).Cells(4).Value.ToString, 3) & ":" & PadZero(dgvPortsLED.Rows(i).Cells(3).Value.ToString * 10, 4)
                End Select
                commandName &= "_" & dgvPortsLED.Rows(i).Cells(2).Value.ToString & "-P" & PadZero(dgvPortsLED.Rows(i).Cells(1).Value)
            End If
        Next

        ' Check that at least one LED port was selected
        If dataString = "" Then
            MsgBox("You must select at least one LED port to manipulate via it's checkbox.")
            Exit Sub
        End If

        ' Remove leading pipe char
        dataString = dataString.Substring(1)

        txtCommandName.Text = SelectedDevice("Model") & "-" & Integer2HexString(SelectedDevice("CFLinkID")) & "_LED" & commandName
        txtCommandValue.Text = BuildCFLinkCommandRAW(SelectedDevice("CFLinkID"), IIf(SelectedAction <> "LED", "TSWXBKL", "TSWXLED"), dataString)

        ' Log event
        LogEvent("Generated Command", "LED")
    End Sub
#End Region

#Region "RELAY"

    Private Sub dgvPorts_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPortsRelay.CellValueChanged
        Try
            If dgvPortsRelay.CurrentCell IsNot Nothing Then
                If e.ColumnIndex = 2 Then
                    ' Dropdown list change

                    If dgvPortsRelay.CurrentCell.Value.ToString = "PULSE" Then
                        dgvPortsRelay.CurrentRow.Cells(3).ReadOnly = False
                        dgvPortsRelay.CurrentRow.Cells(3).Style.ForeColor = Drawing.SystemColors.ControlText
                        dgvPortsRelay.CurrentRow.Cells(3).Style.BackColor = Drawing.SystemColors.Window
                        dgvPortsRelay.CurrentRow.Cells(3).Style.SelectionForeColor = Drawing.SystemColors.HighlightText
                        dgvPortsRelay.CurrentRow.Cells(3).Style.SelectionBackColor = Drawing.SystemColors.Highlight
                    Else
                        dgvPortsRelay.CurrentRow.Cells(3).ReadOnly = True
                        dgvPortsRelay.CurrentRow.Cells(3).Style.ForeColor = Drawing.Color.Gray
                        dgvPortsRelay.CurrentRow.Cells(3).Style.BackColor = Drawing.Color.LightGray
                        dgvPortsRelay.CurrentRow.Cells(3).Style.SelectionForeColor = Drawing.Color.Gray
                        dgvPortsRelay.CurrentRow.Cells(3).Style.SelectionBackColor = Drawing.Color.LightGray
                    End If
                End If
            End If
        Catch ex As NullReferenceException

        End Try
    End Sub

    Private Sub dgvPortsRelay_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvPortsRelay.CurrentCellDirtyStateChanged
        If dgvPortsRelay.CurrentCell.ColumnIndex = 2 Then
            dgvPortsRelay.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange)
        End If

    End Sub

    Private Sub dgvPortsRelay_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles dgvPortsRelay.EditingControlShowing
        If dgvPortsRelay.CurrentCell.ColumnIndex > 2 Then
            Dim txtEdit As TextBox = e.Control
            'remove any existing handler
            RemoveHandler txtEdit.KeyPress, AddressOf txtEditRelay_Keypress
            AddHandler txtEdit.KeyPress, AddressOf txtEditRelay_Keypress
        End If
    End Sub

    Private Sub txtEditRelay_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Test for numeric value or backspace in first column
        If dgvPortsRelay.CurrentCell.ColumnIndex = 3 Then
            If IsNumeric(e.KeyChar.ToString()) _
            Or e.KeyChar = ChrW(Keys.Back) _
            Or e.KeyChar = "." Then
                e.Handled = False 'if numeric display 
            Else
                e.Handled = True  'if non numeric don't display
            End If
        End If
    End Sub

    Private Sub dgvPortsRelay_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvPortsRelay.CellValidating
        Try
            If dgvPortsRelay.CurrentCell.ColumnIndex = 3 Then
                ' Pulse time change
                If dgvPortsRelay.CurrentCell.Value.ToString = "" OrElse dgvPortsRelay.CurrentCell.Value.ToString < 0.1 Then
                    MsgBox("A minimum of 0.1 seconds is required for relay pulsing.")
                    dgvPortsRelay.CurrentCell.Value = 0.1
                    e.Cancel = True
                ElseIf dgvPortsRelay.CurrentCell.Value.ToString > 999.9 Then
                    MsgBox("A maximum of 999.9 seconds is allowed for relay pulsing.")
                    dgvPortsRelay.CurrentCell.Value = 999.9
                    e.Cancel = True
                End If
            End If
        Catch ex As NullReferenceException
        End Try
    End Sub

    Private Sub btnGenerateRelay_Click(sender As Object, e As EventArgs) Handles btnGenerateRelay.Click
        ' Loop through selected relay ports
        Dim dataString As String = ""
        Dim commandName As String = ""
        For i As Integer = 0 To dgvPortsRelay.Rows.Count - 1
            If dgvPortsRelay.Rows(i).Cells(0).Value = True Then
                ' port is selected, so add it to the command string, with its config details
                dataString &= "|P" & PadZero(dgvPortsRelay.Rows(i).Cells(1).Value) & ":"
                Select Case dgvPortsRelay.Rows(i).Cells(2).Value.ToString
                    Case "OPEN"
                        dataString &= "0"
                    Case "CLOSE"
                        dataString &= "1"
                    Case "TOGGLE"
                        dataString &= "T"
                    Case "PULSE"
                        dataString &= "P:" & PadZero(dgvPortsRelay.Rows(i).Cells(3).Value.ToString * 10, 5)
                End Select
                commandName &= "_" & dgvPortsRelay.Rows(i).Cells(2).Value.ToString & "-P" & PadZero(dgvPortsRelay.Rows(i).Cells(1).Value)
            End If
        Next

        ' Check that at least one relay port was selected
        If dataString = "" Then
            MsgBox("You must select at least one relay port to manipulate via it's checkbox.")
            Exit Sub
        End If

        If SelectedModule Is Nothing Then
            dataString = dataString.Substring(1)
        Else
            Dim moduleString As String = "M" & SelectedModule("ModuleNumber")
            dataString = moduleString & dataString
            commandName = "_" & moduleString & commandName
        End If

        txtCommandName.Text = SelectedDevice("Model") & "-" & Integer2HexString(SelectedDevice("CFLinkID")) & "_RELAYS" & commandName
        txtCommandValue.Text = BuildCFLinkCommandRAW(SelectedDevice("CFLinkID"), "TRLYSET", dataString)

        ' Log event
        LogEvent("Generated Command", "Relay")
    End Sub
#End Region

#Region "SERIAL"
    Private Sub btnGenerateSerial_Click(sender As Object, e As EventArgs) Handles btnGenerateSerial.Click
        ' Loop through selected serial ports
        Dim dataString As String = ""
        Dim commandName As String = ""
        For i As Integer = 0 To dgvPortsSerial.Rows.Count - 1
            If dgvPortsSerial.Rows(i).Cells(1).Value <> "" Then
                ' port has data to send, so add it to the command string
                If SelectedDevice("Model").ToString.EndsWith("MOD4") AndAlso dgvPortsSerial.Rows(i).Cells(0).Value <> OnboardSerialPort Then
                    dataString &= "|P" & PadZero(dgvPortsSerial.Rows(i).Cells(0).Value) & ":"
                    commandName &= "-P" & PadZero(dgvPortsSerial.Rows(i).Cells(0).Value)
                Else
                    commandName &= "-ONBOARD"
                End If
                dataString &= dgvPortsSerial.Rows(i).Cells(1).Value
            End If
        Next

        ' Check that at least one relay port was selected
        If dataString = "" Then
            MsgBox("You must enter data for at least one serial port to generate the CFLink command.")
            Exit Sub
        End If

        If SelectedModule Is Nothing Then
            txtCommandValue.Text = BuildCFLinkCommandRAW(SelectedDevice("CFLinkID"), "TCFXSPW", dataString)
        Else
            Dim moduleString As String = "M" & SelectedModule("ModuleNumber")
            dataString = moduleString & dataString
            commandName = "_" & moduleString & commandName
            txtCommandValue.Text = BuildCFLinkCommandRAW(SelectedDevice("CFLinkID"), "TCOMSPW", dataString)
        End If

        txtCommandName.Text = SelectedDevice("Model") & "-" & Integer2HexString(SelectedDevice("CFLinkID")) & "_SERIAL" & commandName

        ' Log event
        LogEvent("Generated Command", "Serial")
    End Sub
#End Region

#Region "IO"

    Private Sub dgvPortsIO_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPortsIO.CellValueChanged
        Try
            If dgvPortsIO.CurrentCell IsNot Nothing Then
                If e.ColumnIndex = 2 Then
                    ' Dropdown list change

                    If dgvPortsIO.CurrentCell.Value.ToString = "PULSE" Then
                        dgvPortsIO.CurrentRow.Cells(3).ReadOnly = False
                        dgvPortsIO.CurrentRow.Cells(3).Style.ForeColor = Drawing.SystemColors.ControlText
                        dgvPortsIO.CurrentRow.Cells(3).Style.BackColor = Drawing.SystemColors.Window
                        dgvPortsIO.CurrentRow.Cells(3).Style.SelectionForeColor = Drawing.SystemColors.HighlightText
                        dgvPortsIO.CurrentRow.Cells(3).Style.SelectionBackColor = Drawing.SystemColors.Highlight
                    Else
                        dgvPortsIO.CurrentRow.Cells(3).ReadOnly = True
                        dgvPortsIO.CurrentRow.Cells(3).Style.ForeColor = Drawing.Color.Gray
                        dgvPortsIO.CurrentRow.Cells(3).Style.BackColor = Drawing.Color.LightGray
                        dgvPortsIO.CurrentRow.Cells(3).Style.SelectionForeColor = Drawing.Color.Gray
                        dgvPortsIO.CurrentRow.Cells(3).Style.SelectionBackColor = Drawing.Color.LightGray
                    End If
                End If
            End If
        Catch ex As NullReferenceException

        End Try
    End Sub

    Private Sub dgvPortsIO_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvPortsIO.CurrentCellDirtyStateChanged
        If dgvPortsIO.CurrentCell.ColumnIndex = 2 Then
            dgvPortsIO.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange)
        End If

    End Sub

    Private Sub dgvPortsIO_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles dgvPortsIO.EditingControlShowing
        If dgvPortsIO.CurrentCell.ColumnIndex > 2 Then
            Dim txtEdit As TextBox = e.Control
            'remove any existing handler
            RemoveHandler txtEdit.KeyPress, AddressOf txtEditIO_Keypress
            AddHandler txtEdit.KeyPress, AddressOf txtEditIO_Keypress
        End If
    End Sub

    Private Sub txtEditIO_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Test for numeric value or backspace in first column
        If dgvPortsIO.CurrentCell.ColumnIndex = 3 Then
            If IsNumeric(e.KeyChar.ToString()) _
            Or e.KeyChar = ChrW(Keys.Back) _
            Or e.KeyChar = "." Then
                e.Handled = False 'if numeric display 
            Else
                e.Handled = True  'if non numeric don't display
            End If
        End If
    End Sub

    Private Sub dgvPortsIO_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvPortsIO.CellValidating
        Try
            If dgvPortsIO.CurrentCell.ColumnIndex = 3 Then
                ' Pulse time change
                If dgvPortsIO.CurrentCell.Value.ToString = "" OrElse dgvPortsIO.CurrentCell.Value.ToString < 0.1 Then
                    MsgBox("A minimum of 0.1 seconds is required for output pulsing.")
                    dgvPortsIO.CurrentCell.Value = 0.1
                    e.Cancel = True
                ElseIf dgvPortsIO.CurrentCell.Value.ToString > 999.9 Then
                    MsgBox("A maximum of 999.9 seconds is allowed for output pulsing.")
                    dgvPortsIO.CurrentCell.Value = 999.9
                    e.Cancel = True
                End If
            End If
        Catch ex As NullReferenceException
        End Try
    End Sub

    Private Sub btnGenerateIO_Click(sender As Object, e As EventArgs) Handles btnGenerateIO.Click
        ' Loop through selected IO ports
        Dim dataString As String = ""
        Dim commandName As String = ""
        For i As Integer = 0 To dgvPortsIO.Rows.Count - 1
            If dgvPortsIO.Rows(i).Cells(0).Value = True Then
                ' port is selected, so add it to the command string, with its config details
                dataString &= "|P" & PadZero(dgvPortsIO.Rows(i).Cells(1).Value) & ":"
                Select Case dgvPortsIO.Rows(i).Cells(2).Value.ToString
                    Case "OPEN"
                        dataString &= "0"
                    Case "CLOSE"
                        dataString &= "1"
                    Case "TOGGLE"
                        dataString &= "T"
                    Case "PULSE"
                        dataString &= "P:" & PadZero(dgvPortsIO.Rows(i).Cells(3).Value.ToString * 10, 5)
                End Select
                commandName &= "_" & dgvPortsIO.Rows(i).Cells(2).Value.ToString & "-P" & PadZero(dgvPortsIO.Rows(i).Cells(1).Value)
            End If
        Next

        ' Check that at least one relay port was selected
        If dataString = "" Then
            MsgBox("You must select at least one IO port to manipulate via it's checkbox.")
            Exit Sub
        End If

        If SelectedModule Is Nothing Then
            dataString = dataString.Substring(1)
        Else
            Dim moduleString As String = "M" & SelectedModule("ModuleNumber")
            dataString = moduleString & dataString
            commandName = "_" & moduleString & commandName
        End If

        txtCommandName.Text = SelectedDevice("Model") & "-" & Integer2HexString(SelectedDevice("CFLinkID")) & "_OUPUT" & commandName
        txtCommandValue.Text = BuildCFLinkCommandRAW(SelectedDevice("CFLinkID"), "TIOXSET", dataString)

        ' Log event
        LogEvent("Generated Command", "IO")
    End Sub
#End Region

#Region "IR"
    Private Sub LoadOnboardDatabase()
        Try
            If theDB.Categories.Count > 0 Then
                Exit Sub
            End If

            'MsgBox(Me.GetType.Assembly.GetName.ToString)
            Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.Load("CFLink Command Builder")

            ' Open file with the Using statement.
            Dim my_namespace As String = "CFLinkCommandBuilder"
            If asm.GetManifestResourceStream(my_namespace & ".UEI_Brand_List.txt") Is Nothing Then
                MsgBox("IR Database Resource could not be loaded!")
                Exit Sub
            End If

            Using r As StreamReader = New StreamReader(asm.GetManifestResourceStream(my_namespace & ".UEI_Brand_List.txt"))
                ' Store contents in this String.
                Dim line As String

                Dim foundFirstCategory As Boolean = False
                Dim categoryRegex As New Regex("^###### Setup Codes For (.*) \((\w)\) ######$") ' Example format: ###### Setup Codes For Video - DVD (Y) ######
                Dim categoryRegexSub As New Regex("^--- (.*) \((\w)\) ---$") ' Example format: --- Cable/PVR Combination (C) ---
                Dim manufacturerRegex As New Regex("^([^\s#-].*?)\s\s+(\d+,?\s?)+$") ' Example format: Comcast                                 1376, 1877, 1982, 2576
                Dim currentManRegex As New Regex("^\s+(\d+,?\s?)+$") ' Example format:                                         1376, 1877, 1982, 2576
                Dim currentCategory As OnboardIRDatabase.IRCategory = Nothing
                Dim currentManufacturer As OnboardIRDatabase.IRManufacturer = Nothing
                Dim currentMainCategoryName As String = ""

                ' Read first line.
                line = r.ReadLine

                ' Loop over each line in file, While line is Not Nothing.
                Do While (Not line Is Nothing)
                    Dim catMatch As Match = categoryRegex.Match(line)
                    Dim catMatchSub As Match = categoryRegexSub.Match(line)
                    Dim manMatch As Match = manufacturerRegex.Match(line)
                    Dim currentManMatch As Match = currentManRegex.Match(line)
                    If Not foundFirstCategory And Not catMatch.Success Then
                        ' Read in the next line and skip to it now.
                        line = r.ReadLine
                        Continue Do
                    End If

                    If catMatch.Success Then
                        ' Found a new category
                        foundFirstCategory = True

                        currentCategory = New OnboardIRDatabase.IRCategory(catMatch.Groups(1).Value, catMatch.Groups(2).Value.ToUpper)
                        currentMainCategoryName = currentCategory.Name

                        theDB.Categories.Add(currentCategory)

                    ElseIf catMatchSub.Success Then
                        ' Found a new sub category
                        foundFirstCategory = True

                        currentCategory = New OnboardIRDatabase.IRCategory(currentMainCategoryName & ": " & catMatchSub.Groups(1).Value, catMatchSub.Groups(2).Value.ToUpper)

                        theDB.Categories.Add(currentCategory)
                    ElseIf currentCategory IsNot Nothing And manMatch.Success Then
                        Dim newMan As New OnboardIRDatabase.IRManufacturer(manMatch.Groups(1).Value)
                        For Each aCapture As Capture In manMatch.Groups(2).Captures
                            newMan.CodeSets.Add(aCapture.Value.Replace(",", "").Replace(" ", ""))
                        Next

                        currentCategory.Manufacturers.Add(newMan)
                        currentManufacturer = newMan
                    ElseIf currentCategory IsNot Nothing And currentManufacturer IsNot Nothing And currentManMatch.Success Then
                        For Each aCapture As Capture In currentManMatch.Groups(1).Captures
                            currentManufacturer.CodeSets.Add(aCapture.Value.Replace(",", "").Replace(" ", ""))
                        Next
                    End If

                    ' Read in the next line.
                    line = r.ReadLine
                Loop

            End Using

            Using r As StreamReader = New StreamReader(asm.GetManifestResourceStream(my_namespace & ".UEI_KeyCodes.csv"))
                ' Store contents in this String.
                Dim line As String

                ' Read first line (header).
                Dim header As String = r.ReadLine
                Dim headerItems As String() = header.Split(",")
                Dim numDevices As Integer = headerItems.Count - 2

                theDB.DeviceTypes.Clear()
                For Each headerItem As String In headerItems
                    ' First check its a device type header
                    If headerItem.Length = 1 Then
                        theDB.DeviceTypes.Add(New OnboardIRDatabase.IRDeviceType(headerItem))
                    End If
                Next

                ' Read second line (first line of data).
                line = r.ReadLine

                ' Loop over each line in file, While list is Not Nothing.
                Do While (Not line Is Nothing)

                    Dim keyItems As String() = theDB.SplitDelimitedLine(line, ",", """").ToArray

                    For i As Integer = 2 To keyItems.Length - 1
                        theDB.DeviceTypes(i - 2).KeyCodes.Add(keyItems(i))
                    Next

                    ' Read next line of data
                    line = r.ReadLine
                Loop

            End Using

            theDB.Categories.Sort(New OnboardIRDatabase.IRCategoryComparer)

            UpdateDatabaseFields()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub UpdateDatabaseFields()
        ' Clear fields
        cboDeviceType.Items.Clear()
        cboManufacturer.Items.Clear()

        cboManufacturer.Items.AddRange(theDB.GetUniqueManufacturers)
    End Sub

    Private Sub cboManufacturer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboManufacturer.SelectedIndexChanged
        cboDeviceType.Items.Clear()
        cboDeviceType.Items.AddRange(theDB.GetManufacturersDeviceTypes(cboManufacturer.Text))
        If cboDeviceType.Items.Count > 0 Then
            cboDeviceType.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboDeviceType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDeviceType.SelectedIndexChanged
        ' Update the list of codesets
        cboCodeSet.Items.Clear()
        Dim theCodes As String() = theDB.GetCodeSets(cboManufacturer.Text, cboDeviceType.Text)
        If theCodes IsNot Nothing Then
            cboCodeSet.Items.AddRange(theCodes)
            If cboCodeSet.Items.Count > 0 Then
                cboCodeSet.SelectedIndex = 0
            End If
        End If

        ' Update the list of commands
        cboCommand.Items.Clear()
        Dim theCommands As String() = theDB.GetCommands(cboDeviceType.Text)
        If theCommands IsNot Nothing Then
            cboCommand.Items.AddRange(theCommands)
            If cboCommand.Items.Count > 0 Then
                cboCommand.SelectedIndex = 0
            End If
        End If

        btnAddAllIRCommands.Enabled = btnAdd.Enabled
    End Sub

    Private Sub cboCommand_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCommand.SelectedIndexChanged
        Dim newCmdName As String = SelectedDevice("Model") & "-" & Integer2HexString(SelectedDevice("CFLinkID")) & "_IRDB-" & cboDeviceType.Text & "-" & cboCodeSet.Text.PadLeft(4, "0") & "-" & cboCommand.SelectedItem.ToString
        Me.txtCommandName.Text = Regex.Replace(newCmdName, "[^\w\s]", "-")
        Me.txtCommandValue.Text = BuildCFLinkCommandRAW(SelectedDevice("CFLinkID"), "TIRXSND", "P" & PadZero(cboIRPort.SelectedIndex + 1) & ":DBA:" & theDB.GetDeviceType(cboDeviceType.Text).DeviceNumber.ToString.PadLeft(2, "0") & ":" & cboCodeSet.Text.PadLeft(4, "0") & ":" & (cboCommand.SelectedIndex + 1).ToString.PadLeft(2, "0"))
    End Sub

    Private Sub btnAddAllIRCommands_Click(sender As Object, e As EventArgs) Handles btnAddAllIRCommands.Click

        If cboSystems.SelectedIndex = -1 Then
            MsgBox("Please select a system to add the command to.")
            cboSystems.Focus()
            Exit Sub
        End If

        If MsgBox("All IR commands for the chosen device and codeset will be added to the system you have selected in the 'New Command Details' window below. Do you want to continue?", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        If cboCodeSet.SelectedIndex <> -1 AndAlso cboDeviceType.SelectedIndex <> -1 Then

            Dim theSystem As CommandFusion.JSONSystem = Nothing

            If cboSystems.SelectedItem = NewSystem Then
                If discoveredDevices Is Nothing OrElse Not discoveredDevices.ContainsKey("DeviceList") Then
                    MsgBox("Please select a valid device discovery export file first.")
                    Exit Sub
                End If

                Try
                    theSystem = GetSystemByID("udp-socket").Clone
                Catch ex As Exception
                    MsgBox("Unable to create a new UDP socket system. Please see the log for more details.")
                    RaiseEvent WriteToLog(Me, "ERROR: System could not be cloned." & Environment.NewLine & ex.ToString)
                    Exit Sub
                End Try

                ' Create a new default system using the selected discovered devices
                For Each aDevice As Dictionary(Of String, Object) In discoveredDevices("DeviceList")
                    If aDevice("IsEthernet") Then
                        theSystem.Name = aDevice("Model") & "-" & Integer2HexString(aDevice("CFLinkID"))
                        theSystem.ID = "udp-socket"
                        theSystem.GetSetting("protocol").Value = "udp"
                        theSystem.GetSetting("ip").Value = aDevice("NetworkName")
                        theSystem.GetSetting("port").Value = 10207
                        theSystem.GetSetting("origin").Value = 10207
                        theSystem.GetSetting("offlinequeue").Value = False
                        theSystem.GetSetting("eom").Value = "\xF5\xF5"
                        theSystem.GetSetting("acceptBroadcasts").Value = True
                        theSystem.GetSetting("accept").Value = True
                        theSystem.GetSetting("alwayson").Value = True
                        Exit For
                    End If
                Next

                LastSystemName = theSystem.Name
            Else
                If ListOfSystems IsNot Nothing AndAlso ListOfSystems.Count > 0 Then
                    theSystem = GetSystem(cboSystems.SelectedItem)
                    If theSystem IsNot Nothing Then
                        theSystem = theSystem.Clone
                        LastSystemName = theSystem.Name
                    Else
                        MsgBox("The system could not be found in the currently open project.")
                        Exit Sub
                    End If
                Else
                    MsgBox("Please add a System to your guiDesigner project.")
                    Exit Sub
                End If
            End If

            For i As Integer = 0 To cboCommand.Items.Count - 1
                ' Add the command to the selected project
                Dim newCommand As New CommandFusion.SystemCommand
                Dim newCmdName As String = SelectedDevice("Model") & "-" & Integer2HexString(SelectedDevice("CFLinkID")) & "_IRDB-" & cboManufacturer.Text & "-" & cboCodeSet.Text.PadLeft(4, "0") & "-" & cboCommand.Items(i).ToString
                newCommand.Name = Regex.Replace(newCmdName, "[^\w\s]", "-")
                newCommand.Value = BuildCFLinkCommandRAW(SelectedDevice("CFLinkID"), "TIRXSND", "P" & cboIRPort.SelectedItem.ToString & ":DBA:" & theDB.GetDeviceType(cboDeviceType.Text).DeviceNumber.ToString.PadLeft(2, "0") & ":" & cboCodeSet.Text.PadLeft(4, "0") & ":" & (i + 1).ToString.PadLeft(2, "0"))
                newCommand.System = theSystem.Name
                theSystem.Commands.Add(newCommand)
            Next

            If cboSystems.SelectedItem = NewSystem Then
                RaiseEvent AddSystem(Me, theSystem)
                RaiseEvent RequestSystemList(Me)
            Else
                RaiseEvent AppendSystem(Me, theSystem)
            End If

            ' Log event
            LogEvent("Generated Command", "IR DB All Commands")
        Else
            btnAddAllIRCommands.Enabled = False
        End If
    End Sub

    Private Sub btnGenerateIR_Click(sender As Object, e As EventArgs) Handles btnGenerateIR.Click
        ' Loop through selected IR ports
        Dim dataString As String = ""
        Dim commandName As String = ""
        For i As Integer = 0 To dgvPortsIR.Rows.Count - 1
            If dgvPortsIR.Rows(i).Cells(2).Value <> "" Then
                ' port has data to send, so add it to the command string
                Dim portNum As String = dgvPortsIR.Rows(i).Cells(0).Value
                Dim portName As String = dgvPortsIR.Rows(i).Cells(0).Value
                Select Case portNum
                    Case "Blaster"
                        portNum = "01"
                    Case "Emitter"
                        portNum = "02"
                    Case Else
                        portNum = PadZero(portNum)
                        portName = "P" & PadZero(portNum)
                End Select
                dataString &= "|P" & portNum & ":" & IIf(dgvPortsIR.Rows(i).Cells(1).Value.ToString = CCF, "RAW", "STR") & ":" & dgvPortsIR.Rows(i).Cells(2).Value
                commandName &= "-" & portName
            End If
        Next

        ' Check that at least one IR port has data
        If dataString = "" Then
            MsgBox("You must enter data for at least one IR port to generate the CFLink command.")
            Exit Sub
        End If

        If SelectedModule Is Nothing Then
            dataString = dataString.Substring(1)
            txtCommandValue.Text = BuildCFLinkCommandRAW(SelectedDevice("CFLinkID"), "TIRXSND", dataString)
        Else
            Dim moduleString As String = "M" & SelectedModule("ModuleNumber")
            dataString = moduleString & dataString
            commandName = "_" & moduleString & commandName
            txtCommandValue.Text = BuildCFLinkCommandRAW(SelectedDevice("CFLinkID"), "TIRXSND", dataString)
        End If

        txtCommandName.Text = SelectedDevice("Model") & "-" & Integer2HexString(SelectedDevice("CFLinkID")) & "_IR" & commandName

        ' Log event
        LogEvent("Generated Command", "IR Code")
    End Sub

#End Region

    Private Sub EnableCommandObjects(Optional ByVal enabled As Boolean = True)
        cboSystems.Enabled = enabled
        'txtCommandName.Enabled = enabled
        'txtCommandValue.Enabled = enabled
        btnAdd.Enabled = enabled
        btnAddAllIRCommands.Enabled = enabled
        lblProjectWarning.Visible = Not enabled
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If cboSystems.SelectedIndex = -1 Then
            MsgBox("Please select a system to add the command to.")
            cboSystems.Focus()
            Exit Sub
        End If

        If txtCommandName.Text = "" Then
            MsgBox("Please enter a command name.")
            txtCommandName.Focus()
            Exit Sub
        End If

        If txtCommandValue.Text = "" Then
            MsgBox("Please enter a command value.")
            txtCommandValue.Focus()
            Exit Sub
        End If

        Dim newCommand As New CommandFusion.SystemCommand()
        If cboSystems.SelectedItem = NewSystem Then
            If discoveredDevices Is Nothing OrElse Not discoveredDevices.ContainsKey("DeviceList") Then
                MsgBox("Please select a valid device discovery export file first.")
                Exit Sub
            End If

            Dim newSystem As CommandFusion.JSONSystem = Nothing

            Try
                NewSystem = GetSystemByID("udp-socket").Clone
            Catch ex As Exception
                MsgBox("Unable to create a new UDP socket system. Please see the log for more details.")
                RaiseEvent WriteToLog(Me, "ERROR: System could not be cloned." & Environment.NewLine & ex.ToString)
                Exit Sub
            End Try

            ' Create a new default system using the selected discovered devices
            For Each aDevice As Dictionary(Of String, Object) In discoveredDevices("DeviceList")
                If aDevice("IsEthernet") Then
                    newSystem.Name = aDevice("Model") & "-" & Integer2HexString(aDevice("CFLinkID"))
                    newSystem.ID = "udp-socket"
                    newSystem.GetSetting("protocol").Value = "udp"
                    newSystem.GetSetting("ip").Value = aDevice("IPAddress")
                    newSystem.GetSetting("port").Value = 10207
                    newSystem.GetSetting("origin").Value = 10207
                    newSystem.GetSetting("offlinequeue").Value = False
                    newSystem.GetSetting("eom").Value = "\xF5\xF5"
                    newSystem.GetSetting("acceptBroadcasts").Value = True
                    newSystem.GetSetting("accept").Value = True
                    newSystem.GetSetting("alwayson").Value = True
                    Exit For
                End If
            Next

            newCommand.Name = txtCommandName.Text
            newCommand.Value = txtCommandValue.Text
            newCommand.System = newSystem.Name
            newSystem.Commands.Add(newCommand)

            LastSystemName = newSystem.Name

            RaiseEvent AddSystem(Me, newSystem)
            RaiseEvent RequestSystemList(Me)

        Else
            If ListOfSystems IsNot Nothing AndAlso ListOfSystems.Count > 0 Then
                Dim theSystem As CommandFusion.JSONSystem = GetSystem(cboSystems.SelectedItem)
                If theSystem IsNot Nothing Then
                    theSystem = theSystem.Clone
                    newCommand.Name = txtCommandName.Text
                    newCommand.Value = txtCommandValue.Text
                    newCommand.System = theSystem.Name
                    theSystem.Commands.Add(newCommand)

                    LastSystemName = theSystem.Name

                    RaiseEvent AppendSystem(Me, theSystem)
                End If
            Else
                MsgBox("Please add a System to your guiDesigner project.")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnRefreshSystems_Click(sender As Object, e As EventArgs) Handles btnRefreshSystems.Click
        RaiseEvent RequestSystemList(Me)
    End Sub

    Private Sub btnCopyCommand_Click(sender As Object, e As EventArgs) Handles btnCopyCommand.Click
        If txtCommandValue.Text = "" Then
            MsgBox("The command value is empty, copying has been aborted.")
        Else
            My.Computer.Clipboard.SetText(txtCommandValue.Text)
            MsgBox("The command value has been copied to your clipboard." & Environment.NewLine & "You can now paste the command into the System Commander test window if you want to test the CFLink command in a live system.", MsgBoxStyle.Information)
        End If
        
    End Sub

    Private Sub txtCommandValue_TextChanged(sender As Object, e As EventArgs) Handles txtCommandValue.TextChanged
        If txtCommandValue.Text <> "" Then
            btnCopyCommand.Enabled = True
        Else
            btnCopyCommand.Enabled = False
        End If
    End Sub

End Class