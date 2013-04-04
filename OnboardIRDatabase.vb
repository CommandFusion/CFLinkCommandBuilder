Public Class OnboardIRDatabase
    Public Categories As New List(Of IRCategory)
    Public DeviceTypes As New List(Of IRDeviceType)

    Public Class IRCategory
        Public Name As String
        Public Letter As Char
        Public Manufacturers As New List(Of IRManufacturer)

        Public Sub New(ByVal Name As String, ByVal Letter As Char)
            Me.Name = Name
            Me.Letter = Letter
        End Sub

        Public ReadOnly Property DeviceNumber() As Integer
            Get
                If Me.Letter = "M" Then ' M and R share the same device type, so to make life easy, just first check if its M otherwise use the string character position call below
                    Return 7
                Else
                    Return "TCNSV YRAD".IndexOf(Me.Letter) ' Device type 5 does not exist (so just use a space).
                End If
            End Get
        End Property
    End Class

    Public Class IRManufacturer
        Public Name As String
        Public CodeSets As New List(Of String)

        Public Sub New(ByVal Name As String)
            Me.Name = Name
        End Sub
    End Class

    Public Class IRDeviceType
        Public Letter As Char
        Public KeyCodes As New List(Of String)

        Public Sub New(ByVal Letter As String)
            Me.Letter = Letter
        End Sub

        Public ReadOnly Property DeviceNumber() As Integer
            Get
                If Me.Letter = "M" Then ' M and R share the same device type, so to make life easy, just first check if its M otherwise use the string character position call below
                    Return 7
                Else
                    Return "TCNSV YRAD".IndexOf(Me.Letter)
                End If
            End Get
        End Property
    End Class

    Public Class IRCategoryComparer
        Implements IComparer(Of IRCategory)
        Public Function Compare(ByVal x As IRCategory, ByVal y As IRCategory) As Integer Implements System.Collections.Generic.IComparer(Of IRCategory).Compare
            Return x.Name.CompareTo(y.Name)
        End Function
    End Class

    Public Function GetUniqueManufacturers() As String()
        Dim mans As New List(Of String)
        For Each aCat As IRCategory In Me.Categories
            For Each aMan As IRManufacturer In aCat.Manufacturers
                If Not mans.Contains(aMan.Name) Then
                    mans.Add(aMan.Name)
                End If
            Next
        Next

        mans.Sort()

        Return mans.ToArray
    End Function

    Public Function GetManufacturersDeviceTypes(ByVal theManufacturer As String) As String()
        Dim deviceTypes As New List(Of String)
        For Each aCat As IRCategory In Me.Categories
            For Each aMan As IRManufacturer In aCat.Manufacturers
                If aMan.Name = theManufacturer Then
                    deviceTypes.Add(aCat.Name)
                End If
            Next
        Next

        deviceTypes.Sort()

        Return deviceTypes.ToArray
    End Function

    Public Function GetCodeSets(ByVal theManufacturer As String, ByVal theCategory As String) As String()
        Dim codeSets As New List(Of String)
        For Each aCat As IRCategory In Me.Categories
            If aCat.Name = theCategory Then
                For Each aMan As IRManufacturer In aCat.Manufacturers
                    If aMan.Name = theManufacturer Then
                        aMan.CodeSets.Sort()
                        Return aMan.CodeSets.ToArray
                    End If
                Next
            End If
        Next
        Return Nothing
    End Function

    Public Function GetDeviceType(ByVal theCategory As String) As IRDeviceType
        For Each aCat As IRCategory In Me.Categories
            If aCat.Name = theCategory Then
                Return Me.GetDeviceType(aCat.Letter)
            End If
        Next
        MsgBox(theCategory)
        Return Nothing
    End Function

    Public Function GetDeviceType(ByVal Letter As Char) As IRDeviceType
        For Each aDeviceType As IRDeviceType In Me.DeviceTypes
            ' R and M are the same
            If aDeviceType.Letter = Letter Or (aDeviceType.Letter = "R" And Letter = "M") Then
                Return aDeviceType
            End If
        Next
        Return Nothing
    End Function

    Public Function GetCommands(ByVal theCategory As String) As String()
        For Each aCat As IRCategory In Me.Categories
            If aCat.Name = theCategory Then
                Dim theDeviceType As IRDeviceType = Me.GetDeviceType(aCat.Letter)
                If theDeviceType IsNot Nothing Then
                    If Not theDeviceType.KeyCodes Is Nothing Then
                        Return theDeviceType.KeyCodes.ToArray
                    End If
                End If
            End If
        Next
        Return Nothing
    End Function

    Public Function SplitDelimitedLine(ByVal CurrentLine As String, ByVal Delimiter As String, ByVal Qualifier As String) As List(Of String) ' Collection
        Dim i As Integer
        Dim SplitString As New List(Of String) 'Collection()
        Dim CountDelimiter As Boolean
        Dim Total As Integer
        Dim Ch As Char
        Dim Section As String
        ' We want to count the delimiter unless it is within the text qualifier 
        CountDelimiter = True
        Total = 0
        Section = ""
        For i = 1 To Len(CurrentLine)
            Ch = Mid(CurrentLine, i, 1)
            Select Case Ch
                Case Qualifier
                    If CountDelimiter Then
                        CountDelimiter = False
                    Else
                        CountDelimiter = True
                    End If
                Case Delimiter
                    If CountDelimiter Then
                        ' Add current section to collection 
                        SplitString.Add(Replace(Section, Chr(10), ""))
                        Section = ""
                        Total = Total + 1
                    Else
                        Section = Section & Ch
                    End If
                Case Else
                    Section = Section & Ch
            End Select
        Next
        ' Get the last field - as most files will not have an ending delimiter 
        If CountDelimiter Then
            ' Add current section to collection 
            SplitString.Add(Replace(Section, Chr(10), ""))
        End If
        SplitDelimitedLine = SplitString
    End Function

    Public Sub ExportDocumentation()
        Dim theFile As String = "irdatabase-codesets.js"
        Dim theContents As String = "manufacturers = ["

        For Each aManufacturer As String In Me.GetUniqueManufacturers
            theContents &= "{ name: """ & aManufacturer & """, types: ["
            For Each aDeviceType As String In Me.GetManufacturersDeviceTypes(aManufacturer)
                Try
                    theContents &= "{ name: """ & aDeviceType & """, number: " & theDB.GetDeviceType(aDeviceType).DeviceNumber.ToString.PadLeft(2, "0") & ", codesets: ["
                Catch ex As Exception
                End Try

                For Each aCodeSet As String In Me.GetCodeSets(aManufacturer, aDeviceType)
                    theContents &= """" & aCodeSet & ""","
                Next
                theContents = theContents.Substring(0, theContents.Length - 1) & "]},"

            Next
            theContents = theContents.Substring(0, theContents.Length - 1)
            theContents &= "]},"
        Next
        theContents = theContents.Substring(0, theContents.Length - 1) & "];" & Environment.NewLine
        theContents &= "deviceTypes = ["

        For Each aDeviceType As IRDeviceType In Me.DeviceTypes
            Try
                theContents &= "{ number: """ & aDeviceType.DeviceNumber & """, keycodes: ["

                For Each aCode As String In aDeviceType.KeyCodes
                    theContents &= """" & aCode & ""","
                Next

                theContents = theContents.Substring(0, theContents.Length - 1) & "]},"
            Catch ex As Exception
            End Try
        Next

        theContents = theContents.Substring(0, theContents.Length - 1) & "];"

        Dim theStream As IO.StreamWriter = IO.File.CreateText(theFile)
        theStream.Write(theContents)
        theStream.Close()
        Process.Start(theFile)
    End Sub
End Class
