Imports System.Windows.Forms
Imports System.Text.RegularExpressions

Public Class frmRelays

    Public theDevice As Dictionary(Of String, Object)

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        ' Check that all fields have been entered correctly

        ' check that at least one relay port was selected
        Dim count As Integer = 0
        For Each aRow As DataGridViewRow In dgvPorts.Rows
            If aRow.Cells(0).Value = True Then
                count += 1
                If aRow.Cells(2).Value.ToString = "PULSE" AndAlso aRow.Cells(3).Value.ToString < 100 Then
                    MsgBox("A minimum of 100 milliseconds is required for pulsing a relay.")
                    Exit Sub
                End If
            End If
        Next

        If count = 0 Then
            MsgBox("You must select at least one relay port to manipulate via it's checkbox. Otherwise press cancel to go back.")
            Exit Sub
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cboModules_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboModules.SelectedIndexChanged
        dgvPorts.Rows.Clear()
        ' Get the selected module from the device object
        Dim theRegex As New Regex("M(\d+)")
        If theRegex.IsMatch(cboModules.SelectedItem) Then
            Dim moduleNum As Integer = theRegex.Match(cboModules.SelectedItem).Groups(1).Value
            Dim theModule As Dictionary(Of String, Object) = theDevice("Modules")(moduleNum - 1)
            For i As Integer = 1 To theModule("NumPorts")
                dgvPorts.Rows.Add(False, PadZero(i), "OPEN", 0)
            Next
        End If
    End Sub

    Private Sub dgvPorts_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPorts.CellValueChanged
        If dgvPorts.CurrentCell IsNot Nothing Then
            If e.ColumnIndex = 2 Then
                ' Dropdown list change

                If dgvPorts.CurrentCell.Value.ToString = "PULSE" Then
                    dgvPorts.CurrentRow.Cells(3).ReadOnly = False
                    dgvPorts.CurrentRow.Cells(3).Style.ForeColor = Drawing.SystemColors.ControlText
                    dgvPorts.CurrentRow.Cells(3).Style.BackColor = Drawing.SystemColors.Window
                    dgvPorts.CurrentRow.Cells(3).Style.SelectionForeColor = Drawing.SystemColors.HighlightText
                    dgvPorts.CurrentRow.Cells(3).Style.SelectionBackColor = Drawing.SystemColors.Highlight
                Else
                    dgvPorts.CurrentRow.Cells(3).ReadOnly = True
                    dgvPorts.CurrentRow.Cells(3).Style.ForeColor = Drawing.Color.Gray
                    dgvPorts.CurrentRow.Cells(3).Style.BackColor = Drawing.Color.LightGray
                    dgvPorts.CurrentRow.Cells(3).Style.SelectionForeColor = Drawing.Color.Gray
                    dgvPorts.CurrentRow.Cells(3).Style.SelectionBackColor = Drawing.Color.LightGray
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
