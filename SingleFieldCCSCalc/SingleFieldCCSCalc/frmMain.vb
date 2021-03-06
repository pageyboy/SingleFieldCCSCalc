﻿Imports System.IO
Imports System.Reflection
Imports System.Xml

Public Class frmMain

    Dim tFix As Double
    Dim beta As Double
    Dim gasType As String
    Dim DEBUG_MODE As Boolean = False

    Public Structure CCS_Calculation
        Dim IonicMass As Single
        Dim CCS As Single
    End Structure

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim fileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(assemblyLocation).FileVersion
        Debug.Print(fileVersion)

        Me.Text = "Single Field CCS Calculator - v" & fileVersion

        ' Ensure that the correct Attribution is made as per the licencing
        lbl_Atribution.Text = "Icons made by Freepik from Flaticon is licensed by Creative Commons BY 3.0"
        lbl_Atribution.Links.Add(14, 7, "http://www.freepik.com")
        lbl_Atribution.Links.Add(27, 8, "https://www.flaticon.com/")
        lbl_Atribution.Links.Add(51, 23, "http://creativecommons.org/licenses/by/3.0/")

        lbl_Developer.Text = "Made in UK by Chris Page"
        lbl_Developer.Links.Add(14, 10, "mailto:chris.page@agilent.com?subject=Single%20Field%20CCS%20Calculator%20-%20v" & fileVersion)

        lbl_Github.Text = "Visit Github for the latest updates and information"
        lbl_Github.Links.Add(6, 6, "https://github.com/pageyboy/SingleFieldCCSCalc")

        If DEBUG_MODE = True Then
            txtBox_CalFilePath.Text = "D:\Data\IMQTOF Training 17 Sep 2018\Single field_Sulfa_AIF.d\AcqData\OverrideImsCal.xml"
            ReadIMSCal(txtBox_CalFilePath.Text)
        End If

    End Sub

    ' Subs to handle clicking of links
    Private Sub lbl_Atribution_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbl_Atribution.LinkClicked
        Dim target As String = Convert.ToString(e.Link.LinkData)
        System.Diagnostics.Process.Start(target)
    End Sub

    Private Sub lbl_Developer_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbl_Developer.LinkClicked
        Dim target As String = Convert.ToString(e.Link.LinkData)
        System.Diagnostics.Process.Start(target)
    End Sub

    Private Sub lbl_Github_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbl_Github.LinkClicked
        Dim target As String = Convert.ToString(e.Link.LinkData)
        System.Diagnostics.Process.Start(target)
    End Sub

    Private Sub btn_ChooseCalFile_Click(sender As Object, e As EventArgs) Handles btn_ChooseCalFile.Click
        Dim FolderBrowserDialog1 As New FolderBrowserDialog()
        Dim currentFile As String = txtBox_CalFilePath.Text

        If currentFile <> "" Then
            Dim index As Integer = currentFile.IndexOf("AcqData\OverrideImsCal.xml")
            Dim selectedPath As String = currentFile.Substring(0, index)
            FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop
            FolderBrowserDialog1.SelectedPath = selectedPath
        End If

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Dim IMSCalFilePath As String = FolderBrowserDialog1.SelectedPath & "\AcqData\OverrideImsCal.xml"
            ReadIMSCal(IMSCalFilePath)
        End If
    End Sub

    Sub ReadIMSCal(IMSCalPath As String)
        If File.Exists(IMSCalPath) Then
            Dim IMSCalFile = XDocument.Load(IMSCalPath)
            tFix = IMSCalFile.Descendants("TFix").Value
            beta = IMSCalFile.Descendants("Beta").Value
            gasType = IMSCalFile.Descendants("DriftGas").Value
            lbl_TFix.Text = Format(tFix, "0.000000")
            lbl_Beta.Text = Format(beta, "0.000000")
            txtBox_CalFilePath.Text = IMSCalPath
            comboBox_DriftGas.SelectedItem = gasType
            Debug.Print("TFix: " & tFix & " Beta: " & beta & " Drift Gas Type: " & gasType)
            dgv_Results.ReadOnly = False
        Else
            MessageBox.Show("Data file hasn't been calibrated", "No IMS cal file found", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub comboBox_DriftGas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBox_DriftGas.SelectedIndexChanged
        gasType = comboBox_DriftGas.Text
        For rowIndex As Integer = 0 To dgv_Results.Rows.Count - 1
            If readyForCalc(rowIndex) Then
                updateDGVWithResults(rowIndex)
            End If
        Next
    End Sub

    Function CalculateCCS(tD As Double, MassToCharge As Double, ChargeState As Integer, DriftGas As String, TFix As Double, Beta As Double)
        Dim DriftGasMass As Single
        Select Case DriftGas
            Case "N2"
                DriftGasMass = 28.0123
            Case "Ar"
                DriftGasMass = 39.948
            Case "CO2"
                DriftGasMass = 44.0098
            Case "CO"
                DriftGasMass = 28.0101
            Case "He"
                DriftGasMass = 4.0026
            Case "H2"
                DriftGasMass = 2.0159
            Case "Ne"
                DriftGasMass = 20.1797
            Case "NO2"
                DriftGasMass = 46.0055
            Case "NO"
                DriftGasMass = 30.0061
            Case "N2O"
                DriftGasMass = 44.0128
            Case "O2"
                DriftGasMass = 31.9988
            Case "SF6"
                DriftGasMass = 146.0554
        End Select

        Dim CCSResults As CCS_Calculation

        CCSResults.IonicMass = (MassToCharge * ChargeState)
        Dim Gamma As Double = (Math.Sqrt(CCSResults.IonicMass / (CCSResults.IonicMass + DriftGasMass))) / ChargeState
        Dim GammaXCCS As Double = (tD - TFix) / Beta
        CCSResults.CCS = GammaXCCS / Gamma
        Debug.Print("tD: " & tD)
        Debug.Print("m/z: " & MassToCharge)
        Debug.Print("Ionic Mass:" & CCSResults.IonicMass)
        Debug.Print("Drift Gas Mass: " & DriftGasMass)
        Debug.Print("z: " & ChargeState)
        Debug.Print("Gamma: " & Gamma)
        Debug.Print("tfix: " & TFix)
        Debug.Print("Beta: " & Beta)
        Debug.Print("Gamma * CCS: " & GammaXCCS)
        Debug.Print("CCS: " & CCSResults.CCS)
        Return CCSResults

    End Function

    Private Sub dgv_Results_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Results.CellValueChanged
        If e.RowIndex > -1 And e.ColumnIndex < 3 Then
            Try
                If readyForCalc(e.RowIndex) Then
                    updateDGVWithResults(e.RowIndex)
                End If
            Catch ex As Exception
                MessageBox.Show(Me, "Calculation failed", "Calculation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub

    Private Sub dgv_Results_Click(sender As Object, e As EventArgs) Handles dgv_Results.Click
        If txtBox_CalFilePath.Text = "" Then
            MessageBox.Show(Me, "Please select a calibration file first", "Calibration File Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function readyForCalc(rowIndex As Integer) As Boolean
        Dim readyToCalc As Boolean = False
        For i As Integer = 0 To 2 Step 1
            If String.IsNullOrEmpty(Convert.ToString(dgv_Results.Rows(rowIndex).Cells(i).Value)) Then
                readyToCalc = False
                Return False
            Else
                readyToCalc = True
            End If
        Next
        If readyToCalc = True Then Return True
    End Function

    Private Sub updateDGVWithResults(rowIndex As Integer)
        Dim DriftTime As Double = dgv_Results.Rows(rowIndex).Cells(0).Value
        Dim MassToCharge As Double = dgv_Results.Rows(rowIndex).Cells(1).Value
        Dim ChargeState As Integer = dgv_Results.Rows(rowIndex).Cells(2).Value
        Dim CCSResults As CCS_Calculation
        CCSResults = CalculateCCS(DriftTime, MassToCharge, ChargeState, gasType, tFix, beta)
        dgv_Results.Rows(rowIndex).Cells(3).Value = Format(CCSResults.IonicMass, "0.0000")
        dgv_Results.Rows(rowIndex).Cells(4).Value = Format(CCSResults.CCS, "0.00")
    End Sub

    Private Sub btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click
        dgv_Results.Rows.Clear()
    End Sub

    Private Sub btn_Export_Click(sender As Object, e As EventArgs) Handles btn_Export.Click
        Dim dgvExport As DataGridView = Me.dgv_Results
        Dim fileName As String = ""
        SaveFileDialog1.Filter = "CSV|*.csv"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If SaveFileDialog1.CheckPathExists = True Then
                File.Delete(SaveFileDialog1.FileName)
                fileName = SaveFileDialog1.FileName

                Dim versionNumber As Version = Assembly.GetExecutingAssembly().GetName.Version
                Dim objWriter As New System.IO.StreamWriter(fileName, False)

                Dim fileContents As String = "Single Field Collisional Cross Section" & vbCrLf
                fileContents &= "Date Exported: " & Format(Now(), "dd MMM yyyy hh:mm:ss") & vbCrLf
                fileContents &= "Version: " & versionNumber.ToString() & vbCrLf
                fileContents &= "IMS Calibration File: " & txtBox_CalFilePath.Text & vbCrLf
                fileContents &= "TFix: " & lbl_TFix.Text & vbCrLf
                fileContents &= "Beta: " & lbl_Beta.Text & vbCrLf
                fileContents &= vbCrLf
                fileContents &= "tD (Drift Time),m/z,z,Ionic Mass,CCS (A^2)" & vbCrLf

                Debug.Print(fileContents)


                If dgv_Results.Rows.Count > 0 Then
                    For dgvRow = 0 To dgv_Results.Rows.Count - 1
                        For dgvColumn = 0 To 4
                            If Not IsNothing(dgv_Results(dgvColumn, dgvRow).Value) Then
                                fileContents &= dgv_Results(dgvColumn, dgvRow).Value.ToString()
                                If dgvColumn < 4 Then
                                    fileContents &= ","
                                Else
                                    fileContents &= vbCrLf
                                End If
                            End If
                        Next
                    Next

                    objWriter.WriteLine(fileContents)
                    objWriter.Close()
                End If

            End If
        End If
    End Sub
End Class
