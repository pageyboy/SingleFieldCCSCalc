Public Class frmMain
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

End Class
