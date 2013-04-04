Imports System.Windows.Forms
Imports System.Text.RegularExpressions

Public Class frmIOPorts

    Public theDevice As Dictionary(Of String, Object)

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        ' Check that all fields have been entered correctly

        ' check that at least one IO port was selected
        Dim count As Integer = 0
        For Each aRow As DataGridViewRow In dgvPorts.Rows
            If aRow.Cells(0).Value = True Then
                count += 1
                If aRow.Cells(2).Value.ToString = "PULSE" AndAlso aRow.Cells(3).Value.ToString < 100 Then
                    MsgBox("A minimum of 100 milliseconds is required for pulsing an IO Port.")
                    Exit Sub
                End If
            End If
        Next

        If count = 0 Then
            MsgBox("You must select at least one IO port to manipulate via it's checkbox. Otherwise press cancel to go back.")
            Exit Sub
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub Init(aDevice)
        theDevice = aDevice
        dgvPorts.Rows.Clear()
        If theDevice.ContainsKey("Model") Then
            Select Case theDevice("Model")
                Case "CFMini"
                    ' Check the available IO ports to see what modes they are in
                    dgvPorts.Rows.Add(False, "01", "OPEN", 0)
                    dgvPorts.Rows.Add(False, "02", "OPEN", 0)
                    dgvPorts.Rows.Add(False, "03", "OPEN", 0)
                    dgvPorts.Rows.Add(False, "04", "OPEN", 0)
                Case "DIN-MOD4", "MOD4"
                    ' Detect which modules are relay modules
                    If theDevice.ContainsKey("Modules") Then
                        cboModules.Items.Clear()
                        For Each aModule As Dictionary(Of String, Object) In theDevice("Modules")
                            If aModule("ModuleType") = "IO" Then
                                ' Check the available IO ports to see what modes they are in
                                If aModule.ContainsKey("Ports") Then
                                    Dim found As Boolean = False
                                    For Each aPort As Dictionary(Of String, Object) In aModule("Ports")
                                        If aPort("Mode") = 3 Or aPort("Mode") = 4 Then
                                            found = True
                                        End If
                                    Next
                                    If found Then
                                        cboModules.Items.Add("M" & aModule("ModuleNumber") & " - " & aModule("Model"))
                                    End If
                                End If

                            End If
                        Next
                    End If
                    cboModules.Visible = True
                    lblModule.Visible = True
                    If cboModules.Items.Count > 0 Then
                        cboModules.SelectedIndex = 0
                    Else
                        MsgBox("There are no IO modules with ports configured as output modes on this device. You can only manipulate outputs via the CFLink Command Builder.")
                    End If
            End Select
        End If
        lblModel.Text = theDevice("Model")
        lblID.Text = Integer2HexString(theDevice("CFLinkID"))
        lblSerial.Text = theDevice("SerialNo")

    End Sub

    Private Sub cboModules_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboModules.SelectedIndexChanged
        dgvPorts.Rows.Clear()
        ' Get the selected module from the device object
        Dim theRegex As New Regex("M(\d+)")
        If theRegex.IsMatch(cboModules.SelectedItem) Then
            Dim moduleNum As Integer = theRegex.Match(cboModules.SelectedItem).Groups(1).Value
            Dim theModule As Dictionary(Of String, Object) = theDevice("Modules")(moduleNum - 1)
            For Each aPort As Dictionary(Of String, Object) In theModule("Ports")
                If aPort("Mode") = 3 Or aPort("Mode") = 4 Then
                    dgvPorts.Rows.Add(False, PadZero(aPort("Number")), "OPEN", 0)
                End If
            Next
        End If
    End Sub

    Private Sub dgvPorts_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPorts.CellValueChanged
        If dgvPorts.CurrentCell IsNot Nothing Then
            If e.ColumnIndex = 2 Then
                ' Dropdown list change

                If dgvPorts.CurrentCell.Value.ToString = "PULSE" Then
                    dgvPorts.CurrentRow.Cells(3).ReadOnly = False
                    dgvPorts.CurrentRow.Cells(3).Style.ForeColor = Drawing.Color.Black
                Else
                    dgvPorts.CurrentRow.Cells(3).ReadOnly = True
                    dgvPorts.CurrentRow.Cells(3).Style.ForeColor = Drawing.Color.Gray
                End If
            ElseIf e.ColumnIndex = 3 Then
                ' Pulse time change
                If dgvPorts.CurrentCell.Value.ToString < 100 Then
                    MsgBox("A minimum of 100 milliseconds is required.")
                    dgvPorts.CurrentCell.Value = 100
                End If
            End If
        End If
    End Sub

End Class
