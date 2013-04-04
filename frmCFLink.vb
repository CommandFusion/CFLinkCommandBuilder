Imports System.Windows.Forms
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Text.RegularExpressions

Public Class frmCFLink
    Implements CommandFusion.CFPlugin

    Public Event AddCommand(sender As CommandFusion.CFPlugin, newCommand As CommandFusion.SystemCommand) Implements CommandFusion.CFPlugin.AddCommand
    Public Event AddFeedback(sender As CommandFusion.CFPlugin, newFB As CommandFusion.SystemFeedback) Implements CommandFusion.CFPlugin.AddFeedback
    Public Event AddMacro(sender As CommandFusion.CFPlugin, newMacro As CommandFusion.SystemMacro) Implements CommandFusion.CFPlugin.AddMacro
    Public Event AddMacros(sender As CommandFusion.CFPlugin, newMacros As List(Of CommandFusion.SystemMacro)) Implements CommandFusion.CFPlugin.AddMacros
    Public Event AddScript(sender As CommandFusion.CFPlugin, ScriptRelativePathToProject As String) Implements CommandFusion.CFPlugin.AddScript
    Public Event AddSystem(sender As CommandFusion.CFPlugin, newSystem As CommandFusion.SystemClass) Implements CommandFusion.CFPlugin.AddSystem
    Public Event AppendSystem(sender As CommandFusion.CFPlugin, newSystem As CommandFusion.SystemClass) Implements CommandFusion.CFPlugin.AppendSystem

    Public Event EditMacro(sender As CommandFusion.CFPlugin, existingMacro As String, newMacro As CommandFusion.SystemMacro) Implements CommandFusion.CFPlugin.EditMacro
    Public Event RequestMacroList(sender As CommandFusion.CFPlugin) Implements CommandFusion.CFPlugin.RequestMacroList
    Public Event RequestProjectFileInfo(sender As CommandFusion.CFPlugin) Implements CommandFusion.CFPlugin.RequestProjectFileInfo
    Public Event RequestSystemList(sender As CommandFusion.CFPlugin) Implements CommandFusion.CFPlugin.RequestSystemList
    Public Event ToggleWindow(sender As CommandFusion.CFPlugin) Implements CommandFusion.CFPlugin.ToggleWindow
    Public Event WriteToLog(sender As CommandFusion.CFPlugin, msg As String) Implements CommandFusion.CFPlugin.WriteToLog

    Private pathDiscovery As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & Path.DirectorySeparatorChar & "CommandFusion" & Path.DirectorySeparatorChar & "SystemCommander" & Path.DirectorySeparatorChar & "discovery" & Path.DirectorySeparatorChar
    Private discoveredDevices As Dictionary(Of String, Object)
    Private availableActions As Dictionary(Of String, List(Of String))
    Private ListOfSystems As List(Of CommandFusion.SystemClass)
    Private Const NewSystem As String = "Create New System..."

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
        AddHandler showHideMenu.Click, AddressOf Me.DoToggleWindow
        pluginMenu.MenuItems.Add(showHideMenu)
        menu.MenuItems.Add(pluginMenu)
    End Sub

    Public Sub DoToggleWindow(ByVal sender As Object, ByVal e As System.EventArgs)
        RaiseEvent ToggleWindow(Me)
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

    Public Sub UpdateSystemList(systemList As List(Of CommandFusion.SystemClass)) Implements CommandFusion.CFPlugin.UpdateSystemList
        ListOfSystems = systemList
        cboSystems.Items.Clear()
        cboSystems.Items.Add(NewSystem)
        If systemList IsNot Nothing Then
            For Each aSystem As CommandFusion.SystemClass In systemList
                cboSystems.Items.Add(aSystem.ToString)
            Next
        End If
    End Sub
#End Region

    Private Function GetSystem(ByVal name As String) As CommandFusion.SystemClass
        If ListOfSystems Is Nothing Then
            Return Nothing
        End If

        For Each aSystem As CommandFusion.SystemClass In ListOfSystems
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
        If Not availableActions(action).Contains(device("SerialNo")) Then
            availableActions(action).Add(device("SerialNo"))
        End If
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        dlgOpenFile.InitialDirectory = pathDiscovery
        If dlgOpenFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            cboFile.Text = dlgOpenFile.FileName
            OpenFile(dlgOpenFile.FileName)
        End If
    End Sub

    Private Sub cboFile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFile.SelectedIndexChanged
        OpenFile(cboFile.SelectedItem)
    End Sub

    Public Sub OpenFile(ByVal theFile As String)
        If Not File.Exists(theFile) Then
            Exit Sub
        End If
        lblFilenameInfo.Text = New FileInfo(theFile).Name
        lblFilenameInfo.Visible = True
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
        availableActions = New Dictionary(Of String, List(Of String))
        availableActions("Ethernet") = New List(Of String)
        availableActions("IR") = New List(Of String)
        availableActions("IO Port") = New List(Of String)
        availableActions("Serial") = New List(Of String)
        availableActions("Relay") = New List(Of String)
        availableActions("LED") = New List(Of String)
        availableActions("LED Backlight") = New List(Of String)

        cboActions.Items.Clear()
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
        ' Only add actions that have assigned devices (via serial numbers)
        For Each anAction As String In availableActions.Keys
            If availableActions(anAction) IsNot Nothing AndAlso availableActions(anAction).Count > 0 Then
                cboActions.Items.Add(anAction)
            End If
        Next
        cboActions.Enabled = True
        cboDevices.Items.Clear()
        cboDevices.Enabled = False
        btnGo.Enabled = False
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each aFile As String In Directory.GetFiles(pathDiscovery, "*.json")
            cboFile.Items.Add(aFile)
        Next
    End Sub

    Private Sub cboActions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboActions.SelectedIndexChanged
        cboDevices.Items.Clear()
        For Each aSerialNo As String In availableActions(cboActions.SelectedItem)
            Dim aDevice As Dictionary(Of String, Object) = GetDeviceBySerial(aSerialNo)
            If aDevice IsNot Nothing Then
                cboDevices.Items.Add("[" & Integer2HexString(aDevice("CFLinkID")) & "] " & aDevice("Model") & ", " & aSerialNo)
            End If
        Next
        cboDevices.Enabled = True
        btnGo.Enabled = True
    End Sub

    Private Sub cboDevices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDevices.SelectedIndexChanged, btnGo.Click
        If cboDevices.SelectedItem Is Nothing Then
            Exit Sub
        End If
        Dim theRegex As New Regex("\[(..)\] (.*?)\,\s+(.*)")
        If theRegex.IsMatch(cboDevices.SelectedItem) Then
            Dim aMatch As Match = theRegex.Match(cboDevices.SelectedItem)
            If aMatch.Groups.Count >= 3 Then
                Dim serialNo As String = aMatch.Groups(3).Value
                Dim theDevice As Dictionary(Of String, Object) = GetDeviceBySerial(serialNo)
                Select Case cboActions.SelectedItem
                    Case "Relay"
                        ShowRelays(theDevice)
                    Case "IO Port"
                        ShowIOs(theDevice)
                    Case "LED"
                        ShowLEDs(theDevice)
                    Case "LED Backlight"
                        ShowLEDs(theDevice, True)
                    Case "Serial"
                        ShowSerial(theDevice)
                End Select
            End If
        End If
    End Sub

    Private Sub EnableCommandObjects(Optional ByVal enabled As Boolean = True)
        cboSystems.Enabled = enabled
        'txtCommandName.Enabled = enabled
        'txtCommandValue.Enabled = enabled
        btnAdd.Enabled = enabled
    End Sub

    Private Sub ShowRelays(ByVal theDevice As Dictionary(Of String, Object))
        Dim relayForm As New frmRelays
        relayForm.Init(theDevice)
        If relayForm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            ' Loop through selected relay ports
            Dim dataString As String = ""
            Dim commandName As String = ""
            For i As Integer = 0 To relayForm.dgvPorts.Rows.Count - 1
                If relayForm.dgvPorts.Rows(i).Cells(0).Value = True Then
                    ' port is selected, so add it to the command string, with its config details
                    dataString &= "|P" & PadZero(relayForm.dgvPorts.Rows(i).Cells(1).Value) & ":"
                    Select Case relayForm.dgvPorts.Rows(i).Cells(2).Value.ToString
                        Case "OPEN"
                            dataString &= "0"
                        Case "CLOSE"
                            dataString &= "1"
                        Case "TOGGLE"
                            dataString &= "T"
                        Case "PULSE"
                            dataString &= "P:" & PadZero(relayForm.dgvPorts.Rows(i).Cells(3).Value.ToString / 100, 5)
                    End Select
                    commandName &= "_" & relayForm.dgvPorts.Rows(i).Cells(2).Value.ToString & "-P" & PadZero(relayForm.dgvPorts.Rows(i).Cells(1).Value)
                End If
            Next
            Select Case theDevice("Model")
                Case "CFMini"
                    dataString = dataString.Substring(1)
                Case "DIN-MOD4", "MOD4"
                    Dim theRegex As New Regex("(M\d+)")
                    If theRegex.IsMatch(relayForm.cboModules.SelectedItem) Then
                        Dim moduleString As String = theRegex.Match(relayForm.cboModules.SelectedItem).Groups(1).Value
                        dataString = moduleString & dataString
                        commandName = "_" & moduleString & commandName
                    End If
            End Select

            txtCommandName.Text = theDevice("Model") & "-" & Integer2HexString(theDevice("CFLinkID")) & "_RELAYS" & commandName
            txtCommandValue.Text = BuildCFLinkCommandRAW(theDevice("CFLinkID"), "TRLYSET", dataString)

        End If
    End Sub

    Private Sub ShowIOs(ByVal theDevice As Dictionary(Of String, Object))
        Dim ioForm As New frmIOPorts
        ioForm.Init(theDevice)
        If ioForm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            ' Loop through selected relay ports
            Dim dataString As String = ""
            Dim commandName As String = ""
            For i As Integer = 0 To ioForm.dgvPorts.Rows.Count - 1
                If ioForm.dgvPorts.Rows(i).Cells(0).Value = True Then
                    ' port is selected, so add it to the command string, with its config details
                    dataString &= "|P" & PadZero(ioForm.dgvPorts.Rows(i).Cells(1).Value) & ":"
                    Select Case ioForm.dgvPorts.Rows(i).Cells(2).Value.ToString
                        Case "OPEN"
                            dataString &= "0"
                        Case "CLOSE"
                            dataString &= "1"
                        Case "TOGGLE"
                            dataString &= "T"
                        Case "PULSE"
                            dataString &= "P:" & PadZero(ioForm.dgvPorts.Rows(i).Cells(3).Value.ToString / 100, 5)
                    End Select
                    commandName &= "_" & ioForm.dgvPorts.Rows(i).Cells(2).Value.ToString & "-P" & PadZero(ioForm.dgvPorts.Rows(i).Cells(1).Value)
                End If
            Next
            Select Case theDevice("Model")
                Case "CFMini"
                    dataString = dataString.Substring(1)
                Case "DIN-MOD4", "MOD4"
                    Dim theRegex As New Regex("(M\d+)")
                    If theRegex.IsMatch(ioForm.cboModules.SelectedItem) Then
                        Dim moduleString As String = theRegex.Match(ioForm.cboModules.SelectedItem).Groups(1).Value
                        dataString = moduleString & dataString
                        commandName = "_" & moduleString & commandName
                    End If
            End Select

            txtCommandName.Text = theDevice("Model") & "-" & Integer2HexString(theDevice("CFLinkID")) & "_IO" & commandName
            txtCommandValue.Text = BuildCFLinkCommandRAW(theDevice("CFLinkID"), "TIOXSET", dataString)

        End If
    End Sub

    Private Sub ShowLEDs(ByVal theDevice As Dictionary(Of String, Object), Optional ByVal BacklightLEDs As Boolean = False)
        ledForm.Init(theDevice, BacklightLEDs)
        If ledForm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            ' Loop through selected relay ports
            Dim dataString As String = ""
            Dim commandName As String = ""
            For i As Integer = 0 To ledForm.dgvPorts.Rows.Count - 1
                If ledForm.dgvPorts.Rows(i).Cells(0).Value = True Then
                    ' port is selected, so add it to the command string, with its config details
                    dataString &= "|P" & PadZero(ledForm.dgvPorts.Rows(i).Cells(1).Value) & ":"
                    Select Case ledForm.dgvPorts.Rows(i).Cells(2).Value.ToString
                        Case "OFF"
                            dataString &= "0"
                        Case "ON"
                            dataString &= "1"
                        Case "TOGGLE"
                            dataString &= "T"
                        Case "PULSE"
                            dataString &= "P:" & PadZero(ledForm.dgvPorts.Rows(i).Cells(3).Value.ToString * 10, 4)
                        Case "BLINK"
                            dataString &= "B:" & PadZero(ledForm.dgvPorts.Rows(i).Cells(4).Value.ToString, 3) & ":" & PadZero(ledForm.dgvPorts.Rows(i).Cells(5).Value.ToString, 3) & ":" & PadZero(ledForm.dgvPorts.Rows(i).Cells(6).Value.ToString * 10, 4) & ":" & PadZero(ledForm.dgvPorts.Rows(i).Cells(7).Value.ToString * 10, 4) & ":" & PadZero(ledForm.dgvPorts.Rows(i).Cells(8).Value.ToString, 4)
                        Case "DIM"
                            dataString &= "D:" & PadZero(ledForm.dgvPorts.Rows(i).Cells(4).Value.ToString, 3) & ":" & PadZero(ledForm.dgvPorts.Rows(i).Cells(5).Value.ToString, 3) & ":" & PadZero(ledForm.dgvPorts.Rows(i).Cells(6).Value.ToString * 10, 4) & ":" & PadZero(ledForm.dgvPorts.Rows(i).Cells(7).Value.ToString * 10, 4) & ":" & PadZero(ledForm.dgvPorts.Rows(i).Cells(8).Value.ToString, 4)
                        Case "RAMP"
                            dataString &= "R:" & PadZero(ledForm.dgvPorts.Rows(i).Cells(4).Value.ToString, 3) & ":" & PadZero(ledForm.dgvPorts.Rows(i).Cells(3).Value.ToString * 10, 4)
                    End Select
                    commandName &= "_" & ledForm.dgvPorts.Rows(i).Cells(2).Value.ToString & "-P" & PadZero(ledForm.dgvPorts.Rows(i).Cells(1).Value)
                End If
            Next
            Select Case theDevice("Model")
                Case "SW16"
                    dataString = dataString.Substring(1)
            End Select

            txtCommandName.Text = theDevice("Model") & "-" & Integer2HexString(theDevice("CFLinkID")) & "_LED" & commandName
            txtCommandValue.Text = BuildCFLinkCommandRAW(theDevice("CFLinkID"), IIf(BacklightLEDs, "TSWXBKL", "TSWXLED"), dataString)

        End If
    End Sub

    Private Sub ShowSerial(ByVal theDevice As Dictionary(Of String, Object))
        Dim serialForm As New frmRS232
        serialForm.Init(theDevice)
        If serialForm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            ' Loop through ports
            Dim dataString As String = ""
            Dim commandName As String = ""
            For i As Integer = 0 To serialForm.dgvPorts.Rows.Count - 1
                If serialForm.dgvPorts.Rows(i).Cells(1).Value <> "" Then
                    ' port has data to send, so add it to the command string, with its config details
                    If theDevice("Model").ToString.EndsWith("MOD4") AndAlso serialForm.dgvPorts.Rows(i).Cells(0).Value <> "On-board" Then
                        dataString &= "|P" & PadZero(serialForm.dgvPorts.Rows(i).Cells(0).Value) & ":"
                        commandName &= "-P" & PadZero(serialForm.dgvPorts.Rows(i).Cells(0).Value)
                    Else
                        commandName &= "-ONBOARD"
                    End If
                    dataString &= serialForm.dgvPorts.Rows(i).Cells(1).Value
                End If
            Next
            If theDevice("Model").ToString.EndsWith("MOD4") AndAlso serialForm.cboModules.SelectedItem IsNot Nothing Then
                Dim theRegex As New Regex("(M\d+)")
                If theRegex.IsMatch(serialForm.cboModules.SelectedItem) Then
                    Dim moduleString As String = theRegex.Match(serialForm.cboModules.SelectedItem).Groups(1).Value
                    dataString = moduleString & dataString
                    commandName = "_" & moduleString & commandName
                    txtCommandValue.Text = BuildCFLinkCommandRAW(theDevice("CFLinkID"), "TCOMSPW", dataString)
                Else
                    txtCommandValue.Text = BuildCFLinkCommandRAW(theDevice("CFLinkID"), "TCFXSPW", dataString)
                End If
            Else
                txtCommandValue.Text = BuildCFLinkCommandRAW(theDevice("CFLinkID"), "TCFXSPW", dataString)
            End If

            txtCommandName.Text = theDevice("Model") & "-" & Integer2HexString(theDevice("CFLinkID")) & "_SERIAL" & commandName
        End If
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

            Dim newSystem As New CommandFusion.SystemClass

            ' Create a new default system using the selected discovered devices
            For Each aDevice As Dictionary(Of String, Object) In discoveredDevices("DeviceList")
                If aDevice("IsEthernet") Then
                    newSystem.Name = aDevice("Model") & "-" & Integer2HexString(aDevice("CFLinkID"))
                    newSystem.Protocol = "UDP"
                    newSystem.IPAddress = aDevice("NetworkName")
                    newSystem.PortDestination = 10207
                    newSystem.PortOrigin = 10207
                    newSystem.Queue = False
                    newSystem.EOM = "\xF5\xF5"
                    newSystem.AcceptBroadcasts = True
                    newSystem.AcceptIncoming = True
                    newSystem.AlwaysOn = True
                    Exit For
                End If
            Next

            newCommand.Name = txtCommandName.Text
            newCommand.Value = txtCommandValue.Text
            newCommand.System = newSystem
            newSystem.Commands.Add(newCommand)

            RaiseEvent AddSystem(Me, newSystem)
        Else
            If ListOfSystems IsNot Nothing AndAlso ListOfSystems.Count > 0 Then
                Dim theSystem As CommandFusion.SystemClass = GetSystem(cboSystems.SelectedItem)
                If theSystem IsNot Nothing Then
                    newCommand.Name = txtCommandName.Text
                    newCommand.Value = txtCommandValue.Text
                    newCommand.System = theSystem
                    theSystem.Commands.Add(newCommand)

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
End Class