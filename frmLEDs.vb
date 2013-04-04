Imports System.Windows.Forms
Imports System.Text.RegularExpressions

Public Class frmLEDs

    Public theDevice As Dictionary(Of String, Object)

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        ' Check that all fields have been entered correctly

        ' check that at least one IO port was selected
        Dim count As Integer = 0
        For Each aRow As DataGridViewRow In dgvPorts.Rows
            If aRow.Cells(0).Value = True Then
                count += 1
                If aRow.Cells(2).Value.ToString = "PULSE" Then
                    If aRow.Cells(3).Value.ToString = "" OrElse aRow.Cells(3).Value.ToString < 0.1 Then
                        MsgBox("A minimum of 0.1 seconds is required for pulsing an LED.")
                        Exit Sub
                    End If
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

    Public Sub Init(ByVal aDevice As Dictionary(Of String, Object), Optional ByVal BacklightLEDs As Boolean = False)
        theDevice = aDevice
        dgvPorts.Rows.Clear()
        If theDevice.ContainsKey("Model") Then
            Select Case theDevice("Model")
                Case "SW16"
                    If BacklightLEDs Then
                        Me.Text = "Build Backlight LED Command"
                        ' Add the backlight LED ports
                        For i As Integer = 1 To 4
                            dgvPorts.Rows.Add(False, PadZero(i), "OFF", 1.0, 0, 100, 1.0, 1.0, 0)
                        Next
                    Else
                        Me.Text = "Build LED Command"
                        ' Add the LED ports
                        For i As Integer = 1 To 16
                            dgvPorts.Rows.Add(False, PadZero(i), "OFF", 1.0, 0, 100, 1.0, 1.0, 0)
                        Next
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
            If dgvPorts.CurrentCell.ColumnIndex = 2 Then
                ' Dropdown list change
                If e IsNot Nothing Then
                    dgvPorts.SuspendLayout()
                End If
                Select Case dgvPorts.CurrentCell.Value.ToString
                    Case "OFF", "ON", "TOGGLE"
                        For i As Integer = 3 To 8
                            dgvPorts.CurrentRow.Cells(i).ReadOnly = True
                            dgvPorts.CurrentRow.Cells(i).Style.ForeColor = Drawing.Color.Gray
                            dgvPorts.CurrentRow.Cells(i).Style.BackColor = Drawing.Color.LightGray
                            dgvPorts.CurrentRow.Cells(i).Style.SelectionForeColor = Drawing.Color.Gray
                            dgvPorts.CurrentRow.Cells(i).Style.SelectionBackColor = Drawing.Color.LightGray
                        Next
                    Case "PULSE"
                        dgvPorts.CurrentRow.Cells(3).ReadOnly = False
                        dgvPorts.CurrentRow.Cells(3).Style.ForeColor = Drawing.SystemColors.ControlText
                        dgvPorts.CurrentRow.Cells(3).Style.BackColor = Drawing.SystemColors.Window
                        dgvPorts.CurrentRow.Cells(3).Style.SelectionForeColor = Drawing.SystemColors.HighlightText
                        dgvPorts.CurrentRow.Cells(3).Style.SelectionBackColor = Drawing.SystemColors.Highlight
                        For i As Integer = 4 To 8
                            dgvPorts.CurrentRow.Cells(i).ReadOnly = True
                            dgvPorts.CurrentRow.Cells(i).Style.ForeColor = Drawing.Color.Gray
                            dgvPorts.CurrentRow.Cells(i).Style.BackColor = Drawing.Color.LightGray
                            dgvPorts.CurrentRow.Cells(i).Style.SelectionForeColor = Drawing.Color.Gray
                            dgvPorts.CurrentRow.Cells(i).Style.SelectionBackColor = Drawing.Color.LightGray
                        Next
                    Case "BLINK", "DIM"
                        dgvPorts.CurrentRow.Cells(3).ReadOnly = True
                        dgvPorts.CurrentRow.Cells(3).Style.ForeColor = Drawing.Color.Gray
                        dgvPorts.CurrentRow.Cells(3).Style.BackColor = Drawing.Color.LightGray
                        dgvPorts.CurrentRow.Cells(3).Style.SelectionForeColor = Drawing.Color.Gray
                        dgvPorts.CurrentRow.Cells(3).Style.SelectionBackColor = Drawing.Color.LightGray
                        For i As Integer = 4 To 8
                            dgvPorts.CurrentRow.Cells(i).ReadOnly = False
                            dgvPorts.CurrentRow.Cells(i).Style.ForeColor = Drawing.SystemColors.ControlText
                            dgvPorts.CurrentRow.Cells(i).Style.BackColor = Drawing.SystemColors.Window
                            dgvPorts.CurrentRow.Cells(i).Style.SelectionForeColor = Drawing.SystemColors.HighlightText
                            dgvPorts.CurrentRow.Cells(i).Style.SelectionBackColor = Drawing.SystemColors.Highlight
                        Next
                    Case "RAMP"
                        For i As Integer = 3 To 4
                            dgvPorts.CurrentRow.Cells(i).ReadOnly = False
                            dgvPorts.CurrentRow.Cells(i).Style.ForeColor = Drawing.SystemColors.ControlText
                            dgvPorts.CurrentRow.Cells(i).Style.BackColor = Drawing.SystemColors.Window
                            dgvPorts.CurrentRow.Cells(i).Style.SelectionForeColor = Drawing.SystemColors.HighlightText
                            dgvPorts.CurrentRow.Cells(i).Style.SelectionBackColor = Drawing.SystemColors.Highlight
                        Next

                        For i As Integer = 5 To 8
                            dgvPorts.CurrentRow.Cells(i).ReadOnly = True
                            dgvPorts.CurrentRow.Cells(i).Style.ForeColor = Drawing.Color.Gray
                            dgvPorts.CurrentRow.Cells(i).Style.BackColor = Drawing.Color.LightGray
                            dgvPorts.CurrentRow.Cells(i).Style.SelectionForeColor = Drawing.Color.Gray
                            dgvPorts.CurrentRow.Cells(i).Style.SelectionBackColor = Drawing.Color.LightGray
                        Next
                End Select
                If e IsNot Nothing Then
                    dgvPorts.ResumeLayout()
                    dgvPorts.Refresh()
                End If
            End If
        End If
    End Sub

    Private Sub dgvPorts_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvPorts.CurrentCellDirtyStateChanged
        dgvPorts.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange)
    End Sub

    Private Sub dgvPorts_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles dgvPorts.EditingControlShowing
        If dgvPorts.CurrentCell.ColumnIndex > 2 Then
            Dim txtEdit As TextBox = e.Control
            'remove any existing handler
            RemoveHandler txtEdit.KeyPress, AddressOf txtEdit_Keypress
            AddHandler txtEdit.KeyPress, AddressOf txtEdit_Keypress
        End If
    End Sub

    Private Sub txtEdit_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Test for numeric value or backspace in first column
        If dgvPorts.CurrentCell.ColumnIndex = 3 Or dgvPorts.CurrentCell.ColumnIndex = 6 Or dgvPorts.CurrentCell.ColumnIndex = 7 Then
            If IsNumeric(e.KeyChar.ToString()) _
            Or e.KeyChar = ChrW(Keys.Back) _
            Or e.KeyChar = "." Then
                e.Handled = False 'if numeric display 
            Else
                e.Handled = True  'if non numeric don't display
            End If
        ElseIf dgvPorts.CurrentCell.ColumnIndex = 4 Or dgvPorts.CurrentCell.ColumnIndex = 5 Or dgvPorts.CurrentCell.ColumnIndex = 8 Then
            If IsNumeric(e.KeyChar.ToString()) _
            Or e.KeyChar = ChrW(Keys.Back) Then
                e.Handled = False 'if numeric display 
            Else
                e.Handled = True  'if non numeric don't display
            End If
        End If
    End Sub

    Private Sub dgvPorts_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvPorts.CellValidating
        Try
            If dgvPorts.CurrentCell.ColumnIndex = 6 Or dgvPorts.CurrentCell.ColumnIndex = 7 Then
                ' Pulse time change
                If dgvPorts.CurrentCell.Value.ToString = "" OrElse dgvPorts.CurrentCell.Value.ToString < 0.1 Then
                    MsgBox("A minimum of 0.1 seconds is required.")
                    dgvPorts.CurrentCell.Value = 0.1
                    e.Cancel = True
                ElseIf dgvPorts.CurrentCell.Value.ToString = "" OrElse dgvPorts.CurrentCell.Value.ToString > 999.9 Then
                    MsgBox("A maximum of 999.9 seconds is allowed.")
                    dgvPorts.CurrentCell.Value = 999.9
                    e.Cancel = True
                End If
            ElseIf dgvPorts.CurrentCell.ColumnIndex = 4 Or dgvPorts.CurrentCell.ColumnIndex = 5 Then
                ' min or max level change
                If dgvPorts.CurrentCell.Value.ToString = "" OrElse (dgvPorts.CurrentCell.Value.ToString < 0 Or dgvPorts.CurrentCell.Value.ToString > 100) Then
                    MsgBox("LED levels must be within the range 0 to 100.")
                    e.Cancel = True
                ElseIf dgvPorts.CurrentCell.ColumnIndex = 5 AndAlso dgvPorts.CurrentCell.Value.ToString = 0 Then
                    MsgBox("LED max level must be above 0 (zero).")
                    e.Cancel = True
                ElseIf Integer.Parse(dgvPorts.CurrentRow.Cells(5).Value.ToString) < Integer.Parse(dgvPorts.CurrentRow.Cells(4).Value.ToString) Then
                    MsgBox("LED max level must be greater than the LED min value.")
                    e.Cancel = True
                End If
            End If
        Catch ex As NullReferenceException
        End Try
    End Sub

    Private Sub txtReverse_TextChanged(sender As Object, e As EventArgs) Handles txtReverse.TextChanged
        ' Reverse engineer a CFLink command for LEDs
        Dim theRegex As New Regex(".*?(P[P\d:TBDR\|]+)")
        If theRegex.IsMatch(txtReverse.Text) Then
            Dim data As String = theRegex.Match(txtReverse.Text).Groups(1).Value
            Dim portRegex As New Regex("P(\d+):([10TPBDR])(?::(\d+))?(?::(\d+))?(?::(\d+))?(?::(\d+))?(?::(\d+))?")
            Dim portMatches As MatchCollection = portRegex.Matches(data)
            dgvPorts.SuspendLayout()
            For Each aMatch As Match In portMatches
                ' Find the row matching the captured port number
                For Each aRow As DataGridViewRow In dgvPorts.Rows
                    If aRow.Cells(1).Value = aMatch.Groups(1).Value Then
                        aRow.Cells(0).Value = True
                        Select Case aMatch.Groups(2).Value
                            Case "0"
                                aRow.Cells(2).Value = "OFF"
                            Case "1"
                                aRow.Cells(2).Value = "ON"
                            Case "T"
                                aRow.Cells(2).Value = "TOGGLE"
                            Case "P"
                                aRow.Cells(2).Value = "PULSE"
                                If aMatch.Groups(4).Value <> "" Then
                                    aRow.Cells(3).Value = aMatch.Groups(4).Value / 10
                                End If
                            Case "B"
                                aRow.Cells(2).Value = "BLINK"
                                If aMatch.Groups(3).Value <> "" Then
                                    aRow.Cells(4).Value = aMatch.Groups(3).Value
                                End If
                                If aMatch.Groups(4).Value <> "" Then
                                    aRow.Cells(5).Value = aMatch.Groups(4).Value
                                End If
                                If aMatch.Groups(5).Value <> "" Then
                                    aRow.Cells(6).Value = aMatch.Groups(5).Value / 10
                                End If
                                If aMatch.Groups(6).Value <> "" Then
                                    aRow.Cells(7).Value = aMatch.Groups(6).Value / 10
                                End If
                                If aMatch.Groups(7).Value <> "" Then
                                    aRow.Cells(8).Value = aMatch.Groups(7).Value
                                End If
                            Case "D"
                                aRow.Cells(2).Value = "DIM"
                                If aMatch.Groups(3).Value <> "" Then
                                    aRow.Cells(4).Value = aMatch.Groups(3).Value
                                End If
                                If aMatch.Groups(4).Value <> "" Then
                                    aRow.Cells(5).Value = aMatch.Groups(4).Value
                                End If
                                If aMatch.Groups(5).Value <> "" Then
                                    aRow.Cells(6).Value = aMatch.Groups(5).Value / 10
                                End If
                                If aMatch.Groups(6).Value <> "" Then
                                    aRow.Cells(7).Value = aMatch.Groups(6).Value / 10
                                End If
                                If aMatch.Groups(7).Value <> "" Then
                                    aRow.Cells(8).Value = aMatch.Groups(7).Value
                                End If
                            Case "R"
                                aRow.Cells(2).Value = "RAMP"
                                If aMatch.Groups(4).Value <> "" Then
                                    aRow.Cells(3).Value = aMatch.Groups(4).Value / 10
                                End If
                                If aMatch.Groups(3).Value <> "" Then
                                    aRow.Cells(4).Value = aMatch.Groups(3).Value
                                End If
                        End Select
                        Try

                            
                        Catch ex As Exception
                            MsgBox("Error parsing port data: " & Environment.NewLine & _
                                   ex.ToString)
                        End Try
                        dgvPorts.CurrentCell = aRow.Cells(2)
                        dgvPorts_CellValueChanged(dgvPorts, Nothing)
                    End If
                Next
            Next
            dgvPorts.ResumeLayout()
            dgvPorts.Refresh()
        End If

    End Sub

End Class
