Module CommonCode
    Public theDB As New OnboardIRDatabase

#Region " Data Conversion "

    Public Function Integer2HexString(ByVal CFLinkID As Integer) As String
        Try
            Return Convert.ToString(CFLinkID, 16).PadLeft(2, "0").ToUpper()
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function HexString2Integer(ByVal CFLinkID As String) As Integer
        Try
            Return Integer.Parse(CFLinkID, Globalization.NumberStyles.HexNumber)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function Number2Letter(ByVal TheNum As Integer) As Char
        Return Chr(65 + TheNum)
    End Function

    Public Function ValidHexChars(ByRef theString As String) As Boolean
        Dim isValidE As Boolean = False
        If theString <> String.Empty Then
            If (System.Text.RegularExpressions.Regex.IsMatch(theString, "[A-Fa-f0-9]", System.Text.RegularExpressions.RegexOptions.IgnoreCase)) Then
                isValidE = True
            End If
        End If

        Return isValidE
    End Function

    Public Function BuildCFLinkCommand(ByVal CFLinkID As Integer, ByVal Command As String, Optional ByVal Data As String = "") As String
        Dim ID As String = ""
        ' If no CFLink ID, use FF
        If CFLinkID <> Nothing Then
            ID = "\x" & Integer2HexString(CFLinkID)
        Else
            ID = "\xFF"
        End If

        'Return "\xF2" & ID & "\xF3" & Command & "\xF4" & Data & "\xF5\xF5"
        Return "\xF2" & ID & "\xF3" & Command & "\xF4" & "Å" & Data & "Å" & "\xF5\xF5"
    End Function


    Public Function BuildCFLinkCommandRAW(ByVal CFLinkID As Integer, ByVal Command As String, Optional ByVal Data As String = "") As String
        Dim ID As String = ""
        ' If no CFLink ID, use FF
        If CFLinkID <> Nothing Then
            ID = "\x" & Integer2HexString(CFLinkID)
        Else
            ID = "\xFF"
        End If

        Return "\xF2" & ID & "\xF3" & Command & "\xF4" & Data & "\xF5\xF5"
        'Return "\xF2" & ID & "\xF3" & Command & "\xF4" & "Å" & Data & "Å" & "\xF5\xF5"
    End Function


    Public Sub GenerateReadable(ByVal bytes As Byte(), ByRef readable As String, ByRef hexonly As String)
        Dim tmpMsg As String = System.Text.Encoding.ASCII.GetString(bytes)
        Dim i As Integer = 0
        readable = ""
        For Each aByte As Byte In bytes
            If Int32.Parse(aByte) >= 32 And Int32.Parse(aByte) < 127 Then
                readable &= tmpMsg(i)
            Else
                readable &= "\x" & Conversion.Hex(aByte).PadLeft(2, "0")
            End If
            hexonly &= Conversion.Hex(aByte).PadLeft(2, "0")
            i += 1
        Next
    End Sub

    Public Function GenerateReadableFromString(ByVal Msg As String) As String
        Dim bytes As Byte() = System.Text.Encoding.GetEncoding(1252).GetBytes(Msg)
        Dim i As Integer = 0
        Dim readable As String = ""
        For Each aByte As Byte In bytes
            If Int32.Parse(aByte) >= 32 And Int32.Parse(aByte) < 127 Then
                readable &= Msg(i)
            Else
                readable &= "\x" & Conversion.Hex(aByte).PadLeft(2, "0")
            End If
            'hexonly &= Conversion.Hex(aByte).PadLeft(2, "0")
            i += 1
        Next
        Return readable
    End Function

    Public Function GenerateByteArray(ByVal msg As String) As Byte()
        Dim newBytes As New List(Of Byte)

        For i As Integer = 0 To msg.Length - 1
            If msg(i) = "\" And msg(i + 1) = "x" Then
                Dim hexChars As String = msg(i + 2) & msg(i + 3)
                newBytes.Add(Byte.Parse(hexChars, System.Globalization.NumberStyles.HexNumber))
                i += 3
            Else
                newBytes.Add(System.Text.Encoding.ASCII.GetBytes(msg(i))(0))
            End If
        Next

        Dim sendBytes(newBytes.Count - 1) As [Byte]
        newBytes.CopyTo(sendBytes)

        Return sendBytes

    End Function

    Public Function ToAscii(ByVal Data As String) As String
        Return System.Text.Encoding.ASCII.GetString(System.Text.Encoding.Unicode.GetBytes(Data))
    End Function

    Public Function BytesToAscii(ByVal Data As Byte()) As String
        Return System.Text.Encoding.GetEncoding(1252).GetString(Data)
    End Function

    Public Function BooleanToInt(ByVal value As Boolean) As Integer
        If value Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Public Function IsHex(ByVal str As String) As Boolean
        Try
            Dim num As Long = CLng("&H" & str)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function PadZero(ByVal value As Integer, Optional ByVal zeroes As Integer = 2, Optional ByVal decimals As Integer = 0) As String
        Dim fmt As String = New String("0"c, zeroes) & IIf(decimals > 0, "." & New String("#"c, decimals), "")
        Return value.ToString(fmt)
    End Function
#End Region

End Module
