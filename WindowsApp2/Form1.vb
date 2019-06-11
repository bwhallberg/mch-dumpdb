Option Explicit On
Imports System.Runtime.InteropServices
Imports System
Imports System.IO

Public Class Form1
    Private FieldNameFile As String
    Private FieldDescFile As String
    Private FieldExportFile As String
    Private TempStr As String
    Private StartYear As Integer
    Private EndYear As Integer
    Private InYear As Integer
    Private Observations As Integer
    Private NumRecords As Integer
    Private Vlsperrec As Integer = 20
    Private lstCol As Integer = 0


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnOpenDB_Click(sender As Object, e As EventArgs) Handles btnOpenDB.Click
        Dim strText As String
        OpenFileDialogDB.Title = "Open Database file"
        OpenFileDialogDB.InitialDirectory = "."
        OpenFileDialogDB.Filter = "Data Files (*.dat)|*.dat"
        If OpenFileDialogDB.ShowDialog() =
            System.Windows.Forms.DialogResult.OK Then

            Try
                strText = OpenFileDialogDB.FileName
                txtDBName.Text = strText
            Catch ex As Exception
                MessageBox.Show("Error Getting File", "Error")
            End Try
            '
            '  If there was data on the form, delete it
            '
            txtEnd.Text = " "
            txtNumberPY.Text = " "
            txtStart.Text = " "

            For i As Integer = lbFields.Items.Count - 1 To 0 Step -1
                lbFields.Items.RemoveAt(i)
            Next

            If DataGridView1.Columns.Count > 1 Then
                For i = DataGridView1.Columns.Count - 1 To 1 Step -1
                    DataGridView1.Columns.RemoveAt(i)
                Next
            End If


            If DataGridView1.Rows.Count > 1 Then
                For i = DataGridView1.Rows.Count - 1 To 0 Step -1
                    If DataGridView1.Rows(i).IsNewRow = False Then
                        DataGridView1.Rows.RemoveAt(i)
                    End If
                Next
            End If

            lstCol = 0

        End If

    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim strIdx As Integer
        Dim line As String = ""
        Dim lined As String = ""
        Dim dline As String = ""
        Dim Quarter = {"Q1", "Q2", "Q3", "Q4"}
        Dim Months = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}

        TempStr = txtDBName.Text
        TempStr = Trim(TempStr)

        strIdx = InStr(1, TempStr, ".DAT")
        FieldNameFile = Microsoft.VisualBasic.Left(TempStr, strIdx) + "nme"
        FieldDescFile = Microsoft.VisualBasic.Left(TempStr, strIdx) + "dsc"
        FieldExportFile = Microsoft.VisualBasic.Left(TempStr, strIdx) + "csv"

        Try
            ' Create an instance of StreamReader to read from a file.
            Dim sr As StreamReader = New StreamReader(FieldNameFile)
            ' Read and display the lines from the file until the end 
            ' of the file is reached.
            line = sr.ReadToEnd()
            sr.Close()
        Catch Ex As Exception
            ' Let the user know what went wrong.
            Console.WriteLine("The file could not be read:")
            Console.WriteLine(Ex.Message)
        End Try

        Try
            ' Create an instance of StreamReader to read from a file.
            Dim sr As StreamReader = New StreamReader(FieldDescFile)
            ' Read and display the lines from the file until the end 
            ' of the file is reached.
            lined = sr.ReadToEnd()
            sr.Close()
        Catch Ex As Exception
            ' Let the user know what went wrong.
            Console.WriteLine("The file could not be read:")
            Console.WriteLine(Ex.Message)
        End Try

        For i As Integer = 1 To Len(line) Step 8
            TempStr = Trim(Mid(line, i, 8))
            If i = 1 Then
                StartYear = Microsoft.VisualBasic.Left(TempStr, 4)
                txtStart.Text = Microsoft.VisualBasic.Left(TempStr, 4)
                EndYear = Microsoft.VisualBasic.Right(TempStr, 4)
                txtEnd.Text = Microsoft.VisualBasic.Right(TempStr, 4)
            End If
            If i = 9 Then
                InYear = TempStr
                txtNumberPY.Text = TempStr
            End If
            'Debug.Write(TempStr & Environment.NewLine)
            If i > 9 Then
                TempStr = TempStr & " - " & Trim(Mid(lined, ((i - 17) / 8 * 80) + 1, 80))
                lbFields.Items.Add(TempStr)
            End If
        Next

        '  The data file will have Observations for each variable
        '    This is the number of years of observations * the number of them per year
        '    Data can be Yearly, Quarterly, or Monthly
        '  The data file puts the observations into records with 20 Observations per Record
        Observations = (EndYear - StartYear + 1) * InYear
        NumRecords = Int(Observations / Vlsperrec)
        If NumRecords * Vlsperrec < Observations Then
            NumRecords = NumRecords + 1
        End If

        If InYear = 4 Then
            DataGridView1.Columns.Add("Quarter", "Quarter")
        End If
        If InYear = 12 Then
            DataGridView1.Columns.Add("Month", "Month")
        End If


        For i As Integer = StartYear To EndYear
            If InYear = 1 Then
                DataGridView1.Rows.Add(Convert.ToString(i))
            ElseIf InYear = 4 Then
                For j As Integer = 0 To 3
                    DataGridView1.Rows.Add(Convert.ToString(i), Quarter(j))
                    lstCol = 1
                Next j
            ElseIf InYear = 12 Then
                For j As Integer = 0 To 11
                    DataGridView1.Rows.Add(Convert.ToString(i), Months(j))
                    lstCol = 1
                Next
            End If
        Next

    End Sub

    Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" _
        (ByRef hpvDest As Byte, ByVal hpvSource As String, ByVal cbCopy As Integer)

    Private Declare Sub CopyMemory1 Lib "kernel32" Alias "RtlMoveMemory" _
        (ByRef hpvDest As Single, ByRef hpvSource As Byte, ByVal cbCopy As Integer)

    ' Substitutes for the old CV* and MK* functions
    ' from qbasic.
    '
    ' Calling CV* functions with a string of the wrong length
    ' (ie. calling CVL with a 8 byte string instead of a 4
    '  byte string) will cause an error.
    '
    '
    '
    ' CVSMBF, CVDMBF, MKSMBF and MKDMBF Functions
    ' -------------------------------------------
    '
    ' Microsoft Binary Format <-> IEEE floating point functions
    ' were converted from C source found on borland's ftp site.
    '
    ' These routines (CVSMBF, CVDMBF, MKSMBF, MKDMBF) do not
    ' handle IEEE NAN's and infinites.  IEEE denormals are
    ' treated as 0's.
    '
    ' Conversion of doubles can cause overflows when the numbers
    ' simply cannot be converted.  See the code and comments
    ' for more details.
    '
    '
    ' Single Precision Format:
    '    MS Binary Format:
    '    byte order =>    m3  |  m2  | m1 | exponent
    '    m1 is the most significant byte => sbbb|bbbb
    '    m3 is the least significant byte
    '          m = mantissa byte
    '          s = sign bit
    '          b = bit
    '
    '    IEEE Format:
    '        m3        m2        m1    exponent
    '    mmmm|mmmm mmmm|mmmm emmm|mmmm seee|eeee
    '          s = sign mit
    '          e = exponent bit
    '          m = mantissa bit
    '
    '
    ' Double Precision Format:
    '    MS Binary Format:
    '    byte order => m7 | m6 | m5 | m4 | m3 | m2 | m1 | exponent
    '    m1 is the most significant byte => smmm|mmmm
    '    m7 is the least significant byte
    '          m = mantissa byte
    '          s = sign bit
    '          b = bit
    '
    '    IEEE Format:
    '     byte 8    byte 7    byte 6    byte 5    byte 4   and so on
    '    seee|eeee eeee|mmmm mmmm|mmmm mmmm|mmmm mmmm|mmmm ....
    '          m = mantissa byte
    '          s = sign bit
    '          b = bit
    '
    Public Function CVSMBF(ByVal s As String) As Single
        Dim msbin(4) As Byte
        Dim ieee(4) As Byte
        Dim ieee_exp As Byte
        Dim sng As Single

        If Len(s) <> 4 Then
            MsgBox("Invalid string in CVSMBF.")
            CVSMBF = 0
            Exit Function
        End If

        'Debug.WriteLine(Convert.ToString(Asc(Mid(s, 4, 1)), 16) & " " & Convert.ToString(Asc(Mid(s, 3, 1)), 16) & " " & Convert.ToString(Asc(Mid(s, 2, 1)), 16) & " " & Convert.ToString(Asc(Mid(s, 1, 1)), 16))

        ' copy s and to msbin
        Call CopyMemory(msbin(0), s, 4)

        'Debug.WriteLine(Convert.ToString(msbin(3), 16) & " " & Convert.ToString(msbin(2), 16) & " " & Convert.ToString(msbin(1), 16) & " " & Convert.ToString(msbin(0), 16))

        ' Any msbin with an exponent of zero = 0
        If msbin(3) = 0 Then
            CVSMBF = 0
            Exit Function
        End If

        ieee(3) = msbin(2) And &H80

        ' MBF is bias 128 and IEEE is bias 127.  Also, MBF places
        ' the decimal point before the assumed bit, while IEEE
        ' places the decimal point after the assumed bit.
        ieee_exp = msbin(3) - 2   ' Actually ms_bin(3)-1-128+127

        ' The first 7 bits of the exponent in ieee(3)
        ieee(3) = ieee(3) Or (ieee_exp \ 2)

        ' The one remaining bit in the first bit of ieee(2)
        ieee(2) = ieee(2) Or ((ieee_exp And 1) * 128)

        ' mask out the msbin sign bit
        ieee(2) = ieee(2) Or (msbin(2) And &H7F)

        ieee(1) = msbin(1)
        ieee(0) = msbin(0)

        'Debug.WriteLine(Convert.ToString(ieee(3), 16) & " " & Convert.ToString(ieee(2), 16) & " " & Convert.ToString(ieee(1), 16) & " " & Convert.ToString(ieee(0), 16))

        'Copy ieee to sng
        Call CopyMemory1(sng, ieee(0), 4)

        CVSMBF = sng
    End Function

    Private Sub BtnCopyData_Click(sender As Object, e As EventArgs) Handles BtnCopyData.Click
        Dim bts() As Byte
        Dim theObs As Integer
        Dim x As Integer
        Dim TempStrArry() As String

        Try
            ' Create an instance of StreamReader to read from a file.
            bts = My.Computer.FileSystem.ReadAllBytes(txtDBName.Text)
            'dline = My.Computer.FileSystem.ReadAllText(txtDBName.Text, System.Text.Encoding.UTF32)
            'Dim sr As StreamReader = New StreamReader(txtDBName.Text)
            ' Read and display the lines from the file until the end 
            ' of the file is reached.
            'line = sr.ReadToEnd()
            'sr.Close()
        Catch Ex As Exception
            ' Let the user know what went wrong.
            Console.WriteLine("The file could not be read:")
            Console.WriteLine(Ex.Message)
        End Try

        For Each x In lbFields.SelectedIndices
            '  Get the column name no description from the selected variable
            '    also add a column to the data grid for the values
            TempStr = lbFields.Items.Item(x)
            TempStrArry = Split(TempStr)
            TempStr = TempStrArry(0)
            DataGridView1.Columns.Add(TempStr, TempStr)
            lstCol = lstCol + 1
            Dim offset As Integer = (Vlsperrec * NumRecords * x) * 4
            '
            '  Now loop thru the data, convert it and storeit in the data grid
            '
            For i As Integer = 1 To Observations
                theObs = (i - 1) * 4 + offset
                TempStr = Chr(bts(theObs)) & Chr(bts(theObs + 1)) & Chr(bts(theObs + 2)) & Chr(bts(theObs + 3))
                DataGridView1.Rows.Item(i - 1).Cells.Item(lstCol).Value = CVSMBF(TempStr)
            Next i
        Next x

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnExportData.Click

        ' create an empty string for the file
        Dim thecsvfile As String = String.Empty
        ' Get column headers
        For Each column As DataGridViewColumn In DataGridView1.Columns
            thecsvfile = thecsvfile & column.HeaderText & ","
        Next
        ' trim extra comma
        thecsvfile = thecsvfile.TrimEnd(",")
        ' Add the line to the csv file
        thecsvfile = thecsvfile & vbCr & vbLf
        ' now get the data
        For Each row As DataGridViewRow In DataGridView1.Rows
            ' get the cells
            For Each cell As DataGridViewCell In row.Cells
                ' add to csv file
                thecsvfile = thecsvfile & cell.FormattedValue & ","
            Next
            ' trim extra comma
            thecsvfile = thecsvfile.TrimEnd(",")
            ' Add the line to the csv file
            thecsvfile = thecsvfile & vbCr & vbLf
        Next
        Try
            ' write the file
            My.Computer.FileSystem.WriteAllText(FieldExportFile, thecsvfile, False)
        Catch Ex As Exception
            ' Let the user know what went wrong.
            Console.WriteLine("The file could not be written:")
            Console.WriteLine(Ex.Message)
        End Try

    End Sub

    Private Sub OpenFileDialogDB_FileOk(sender As Object, e As ComponentModel.CancelEventArgs) Handles OpenFileDialogDB.FileOk

    End Sub

    Private Sub SaveFileDialogDB_FileOk(sender As Object, e As ComponentModel.CancelEventArgs) Handles SaveFileDialogDB.FileOk

    End Sub
End Class


