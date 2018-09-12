<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.comboBox_DriftGas = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_Beta = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_TFix = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_ChooseCalFile = New System.Windows.Forms.Button()
        Me.txtBox_CalFilePath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv_Results = New System.Windows.Forms.DataGridView()
        Me.lbl_Github = New System.Windows.Forms.LinkLabel()
        Me.lbl_Developer = New System.Windows.Forms.LinkLabel()
        Me.lbl_Atribution = New System.Windows.Forms.LinkLabel()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Adduct = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgv_Results, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lbl_Github)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lbl_Developer)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lbl_Atribution)
        Me.SplitContainer1.Size = New System.Drawing.Size(847, 589)
        Me.SplitContainer1.SplitterDistance = 529
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.comboBox_DriftGas)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lbl_Beta)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lbl_TFix)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btn_ChooseCalFile)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtBox_CalFilePath)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgv_Results)
        Me.SplitContainer2.Size = New System.Drawing.Size(847, 529)
        Me.SplitContainer2.SplitterDistance = 65
        Me.SplitContainer2.TabIndex = 0
        '
        'comboBox_DriftGas
        '
        Me.comboBox_DriftGas.FormattingEnabled = True
        Me.comboBox_DriftGas.Items.AddRange(New Object() {"N2", "Ar", "CO2", "CO", "He", "H2", "Ne", "NO2", "NO", "N2O", "O2", "SF6"})
        Me.comboBox_DriftGas.Location = New System.Drawing.Point(602, 34)
        Me.comboBox_DriftGas.Name = "comboBox_DriftGas"
        Me.comboBox_DriftGas.Size = New System.Drawing.Size(121, 21)
        Me.comboBox_DriftGas.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(540, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Gas Type:"
        '
        'lbl_Beta
        '
        Me.lbl_Beta.AutoSize = True
        Me.lbl_Beta.Location = New System.Drawing.Point(328, 38)
        Me.lbl_Beta.Name = "lbl_Beta"
        Me.lbl_Beta.Size = New System.Drawing.Size(205, 13)
        Me.lbl_Beta.TabIndex = 15
        Me.lbl_Beta.Text = "                                                                  "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(292, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Beta:"
        '
        'lbl_TFix
        '
        Me.lbl_TFix.AutoSize = True
        Me.lbl_TFix.Location = New System.Drawing.Point(51, 38)
        Me.lbl_TFix.Name = "lbl_TFix"
        Me.lbl_TFix.Size = New System.Drawing.Size(205, 13)
        Me.lbl_TFix.TabIndex = 13
        Me.lbl_TFix.Text = "                                                                  "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "TFix:"
        '
        'btn_ChooseCalFile
        '
        Me.btn_ChooseCalFile.Location = New System.Drawing.Point(758, 5)
        Me.btn_ChooseCalFile.Name = "btn_ChooseCalFile"
        Me.btn_ChooseCalFile.Size = New System.Drawing.Size(75, 21)
        Me.btn_ChooseCalFile.TabIndex = 11
        Me.btn_ChooseCalFile.Text = "Choose"
        Me.btn_ChooseCalFile.UseVisualStyleBackColor = True
        '
        'txtBox_CalFilePath
        '
        Me.txtBox_CalFilePath.Enabled = False
        Me.txtBox_CalFilePath.Location = New System.Drawing.Point(118, 6)
        Me.txtBox_CalFilePath.Name = "txtBox_CalFilePath"
        Me.txtBox_CalFilePath.Size = New System.Drawing.Size(634, 20)
        Me.txtBox_CalFilePath.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "IMS Calibration File:"
        '
        'dgv_Results
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Results.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_Results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Results.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Adduct, Me.Column3, Me.Column4, Me.Column5})
        Me.dgv_Results.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Results.Location = New System.Drawing.Point(0, 0)
        Me.dgv_Results.Name = "dgv_Results"
        Me.dgv_Results.ReadOnly = True
        Me.dgv_Results.Size = New System.Drawing.Size(847, 460)
        Me.dgv_Results.TabIndex = 1
        '
        'lbl_Github
        '
        Me.lbl_Github.Location = New System.Drawing.Point(428, 34)
        Me.lbl_Github.Name = "lbl_Github"
        Me.lbl_Github.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Github.Size = New System.Drawing.Size(405, 13)
        Me.lbl_Github.TabIndex = 36
        Me.lbl_Github.TabStop = True
        Me.lbl_Github.Text = "Fork Github Placeholder"
        Me.lbl_Github.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Developer
        '
        Me.lbl_Developer.Location = New System.Drawing.Point(430, 12)
        Me.lbl_Developer.Name = "lbl_Developer"
        Me.lbl_Developer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Developer.Size = New System.Drawing.Size(405, 13)
        Me.lbl_Developer.TabIndex = 35
        Me.lbl_Developer.TabStop = True
        Me.lbl_Developer.Text = "Developer Placeholder"
        Me.lbl_Developer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Atribution
        '
        Me.lbl_Atribution.AutoSize = True
        Me.lbl_Atribution.Location = New System.Drawing.Point(10, 12)
        Me.lbl_Atribution.Name = "lbl_Atribution"
        Me.lbl_Atribution.Size = New System.Drawing.Size(113, 13)
        Me.lbl_Atribution.TabIndex = 34
        Me.lbl_Atribution.TabStop = True
        Me.lbl_Atribution.Text = "Attribution Placeholder"
        '
        'Column1
        '
        Me.Column1.HeaderText = "tD (Drift Time)"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "m/z"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Adduct
        '
        Me.Adduct.HeaderText = "Adduct"
        Me.Adduct.Items.AddRange(New Object() {"[M+H]+", "[M+Na]+", "[M+K]+", "[M+NH4]+", "", "[M-H]-"})
        Me.Adduct.Name = "Adduct"
        Me.Adduct.ReadOnly = True
        Me.Adduct.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Adduct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Column3
        '
        Me.Column3.HeaderText = "z"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Ionic Mass"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "CCS (A^2)"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(847, 589)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmMain"
        Me.Text = "Single Field CCS Calculator"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgv_Results, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents comboBox_DriftGas As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lbl_Beta As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lbl_TFix As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btn_ChooseCalFile As Button
    Friend WithEvents txtBox_CalFilePath As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgv_Results As DataGridView
    Friend WithEvents lbl_Developer As LinkLabel
    Friend WithEvents lbl_Atribution As LinkLabel
    Friend WithEvents lbl_Github As LinkLabel
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Adduct As DataGridViewComboBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
End Class
