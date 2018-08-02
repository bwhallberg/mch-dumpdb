<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblDatab = New System.Windows.Forms.Label()
        Me.txtDBName = New System.Windows.Forms.TextBox()
        Me.btnOpenDB = New System.Windows.Forms.Button()
        Me.OpenFileDialogDB = New System.Windows.Forms.OpenFileDialog()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.txtStart = New System.Windows.Forms.TextBox()
        Me.txtEnd = New System.Windows.Forms.TextBox()
        Me.lblEnd = New System.Windows.Forms.Label()
        Me.txtNumberPY = New System.Windows.Forms.TextBox()
        Me.lblNumberPY = New System.Windows.Forms.Label()
        Me.lbFields = New System.Windows.Forms.ListBox()
        Me.lblFields = New System.Windows.Forms.Label()
        Me.BtnCopyData = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Year = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(45, 399)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(481, 399)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblDatab
        '
        Me.lblDatab.AutoSize = True
        Me.lblDatab.Location = New System.Drawing.Point(165, 9)
        Me.lblDatab.Name = "lblDatab"
        Me.lblDatab.Size = New System.Drawing.Size(57, 13)
        Me.lblDatab.TabIndex = 2
        Me.lblDatab.Text = "Data Base"
        '
        'txtDBName
        '
        Me.txtDBName.Location = New System.Drawing.Point(122, 22)
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.Size = New System.Drawing.Size(454, 20)
        Me.txtDBName.TabIndex = 3
        '
        'btnOpenDB
        '
        Me.btnOpenDB.Location = New System.Drawing.Point(28, 22)
        Me.btnOpenDB.Name = "btnOpenDB"
        Me.btnOpenDB.Size = New System.Drawing.Size(75, 23)
        Me.btnOpenDB.TabIndex = 4
        Me.btnOpenDB.Text = "Open"
        Me.btnOpenDB.UseVisualStyleBackColor = True
        '
        'OpenFileDialogDB
        '
        Me.OpenFileDialogDB.FileName = "OpenFileDialogDB"
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Location = New System.Drawing.Point(25, 57)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(29, 13)
        Me.lblStart.TabIndex = 6
        Me.lblStart.Text = "Start"
        '
        'txtStart
        '
        Me.txtStart.Location = New System.Drawing.Point(60, 54)
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Size = New System.Drawing.Size(100, 20)
        Me.txtStart.TabIndex = 7
        '
        'txtEnd
        '
        Me.txtEnd.Location = New System.Drawing.Point(227, 54)
        Me.txtEnd.Name = "txtEnd"
        Me.txtEnd.Size = New System.Drawing.Size(100, 20)
        Me.txtEnd.TabIndex = 9
        '
        'lblEnd
        '
        Me.lblEnd.AutoSize = True
        Me.lblEnd.Location = New System.Drawing.Point(192, 57)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(26, 13)
        Me.lblEnd.TabIndex = 8
        Me.lblEnd.Text = "End"
        '
        'txtNumberPY
        '
        Me.txtNumberPY.Location = New System.Drawing.Point(456, 54)
        Me.txtNumberPY.Name = "txtNumberPY"
        Me.txtNumberPY.Size = New System.Drawing.Size(100, 20)
        Me.txtNumberPY.TabIndex = 11
        '
        'lblNumberPY
        '
        Me.lblNumberPY.AutoSize = True
        Me.lblNumberPY.Location = New System.Drawing.Point(363, 57)
        Me.lblNumberPY.Name = "lblNumberPY"
        Me.lblNumberPY.Size = New System.Drawing.Size(87, 13)
        Me.lblNumberPY.TabIndex = 10
        Me.lblNumberPY.Text = "Number per Year"
        '
        'lbFields
        '
        Me.lbFields.FormattingEnabled = True
        Me.lbFields.Location = New System.Drawing.Point(28, 109)
        Me.lbFields.Name = "lbFields"
        Me.lbFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbFields.Size = New System.Drawing.Size(548, 95)
        Me.lbFields.TabIndex = 12
        '
        'lblFields
        '
        Me.lblFields.AutoSize = True
        Me.lblFields.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFields.Location = New System.Drawing.Point(25, 93)
        Me.lblFields.Name = "lblFields"
        Me.lblFields.Size = New System.Drawing.Size(95, 13)
        Me.lblFields.TabIndex = 13
        Me.lblFields.Text = "Fields to Export"
        '
        'BtnCopyData
        '
        Me.BtnCopyData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCopyData.Location = New System.Drawing.Point(252, 399)
        Me.BtnCopyData.Name = "BtnCopyData"
        Me.BtnCopyData.Size = New System.Drawing.Size(75, 23)
        Me.BtnCopyData.TabIndex = 14
        Me.BtnCopyData.Text = "&Copy Data"
        Me.BtnCopyData.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Year})
        Me.DataGridView1.Location = New System.Drawing.Point(28, 231)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(548, 150)
        Me.DataGridView1.TabIndex = 15
        '
        'Year
        '
        Me.Year.HeaderText = "Year"
        Me.Year.Name = "Year"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(588, 434)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.BtnCopyData)
        Me.Controls.Add(Me.lblFields)
        Me.Controls.Add(Me.lbFields)
        Me.Controls.Add(Me.txtNumberPY)
        Me.Controls.Add(Me.lblNumberPY)
        Me.Controls.Add(Me.txtEnd)
        Me.Controls.Add(Me.lblEnd)
        Me.Controls.Add(Me.txtStart)
        Me.Controls.Add(Me.lblStart)
        Me.Controls.Add(Me.btnOpenDB)
        Me.Controls.Add(Me.txtDBName)
        Me.Controls.Add(Me.lblDatab)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "Form1"
        Me.Text = "MCH Database Dump"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOK As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents lblDatab As Label
    Friend WithEvents txtDBName As TextBox
    Friend WithEvents btnOpenDB As Button
    Friend WithEvents OpenFileDialogDB As OpenFileDialog
    Friend WithEvents lblStart As Label
    Friend WithEvents txtStart As TextBox
    Friend WithEvents txtEnd As TextBox
    Friend WithEvents lblEnd As Label
    Friend WithEvents txtNumberPY As TextBox
    Friend WithEvents lblNumberPY As Label
    Friend WithEvents lbFields As ListBox
    Friend WithEvents lblFields As Label
    Friend WithEvents BtnCopyData As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Year As DataGridViewTextBoxColumn
End Class
