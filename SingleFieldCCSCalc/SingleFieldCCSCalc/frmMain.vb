Imports System.IO
Imports System.Xml
Imports Microsoft.VisualBasic

Public Class frmMain

    Dim tFix As Double
    Dim beta As Double
    Dim gasType As String
    Dim DEBUG_MODE As Boolean = True

    Public Structure CCS_Calculation
        Dim IonicMass As Single
        Dim CCS As Single
    End Structure

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Ensure that the correct Attribution is made as per the licencing
        lbl_Atribution.Text = "Icons made by Freepik from Flaticon is licensed by Creative Commons BY 3.0"
        lbl_Atribution.Links.Add(14, 7, "http://www.freepik.com")
        lbl_Atribution.Links.Add(27, 8, "https://www.flaticon.com/")
        lbl_Atribution.Links.Add(51, 23, "http://creativecommons.org/licenses/by/3.0/")

        lbl_Developer.Text = "Made in UK by Chris Page"
        lbl_Developer.Links.Add(14, 10, "mailto: chris.page@agilent.com")

        lbl_Github.Text = "Find on Github"
        lbl_Github.Links.Add(0, 14, "https://github.com/pageyboy/SingleFieldCCSCalc")

        If DEBUG_MODE = True Then
            txtBox_CalFilePath.Text = "D:\Data\Single field_Sulfa_AIF.d\AcqData\OverrideImsCal.xml"
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
            lbl_TFix.Text = tFix
            lbl_Beta.Text = beta
            txtBox_CalFilePath.Text = IMSCalPath
            comboBox_DriftGas.SelectedText = gasType
            Debug.Print("TFix: " & tFix & " Beta: " & beta & " Drift Gas Type: " & gasType)
            dgv_Results.ReadOnly = False
        Else
            MessageBox.Show("Data file hasn't been calibrated", "No IMS cal file found", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub comboBox_DriftGas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBox_DriftGas.SelectedIndexChanged
        gasType = comboBox_DriftGas.Text
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
        If e.RowIndex > -1 And e.ColumnIndex < 4 Then
            Dim readyToCalc As Boolean = True
            For i As Integer = 0 To 2
                If IsDBNull(dgv_Results.Rows(e.RowIndex).Cells(i).Value) Or Not IsNumeric(dgv_Results.Rows(e.RowIndex).Cells(i).Value) Then
                    readyToCalc = False
                End If
            Next
            If readyToCalc = True Then
                Debug.Print("Ready to calculate CCS")
                Dim DriftTime As Double = dgv_Results.Rows(e.RowIndex).Cells(0).Value
                Dim MassToCharge As Double = dgv_Results.Rows(e.RowIndex).Cells(1).Value
                Dim ChargeState As Integer = dgv_Results.Rows(e.RowIndex).Cells(2).Value
                Dim CCSResults As CCS_Calculation
                CCSResults = CalculateCCS(DriftTime, MassToCharge, ChargeState, gasType, tFix, beta)
                dgv_Results.Rows(e.RowIndex).Cells(3).Value = Format(CCSResults.IonicMass, "0.0000")
                dgv_Results.Rows(e.RowIndex).Cells(4).Value = Format(CCSResults.CCS, "0.0")
            End If
        End If

    End Sub

    Private Sub dgv_Results_Click(sender As Object, e As EventArgs) Handles dgv_Results.Click
        If txtBox_CalFilePath.Text = "" Then
            MessageBox.Show(Me, "Please select a calibration file first", "Calibration File Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
