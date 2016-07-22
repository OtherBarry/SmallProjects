Imports System.IO
Public Class Form1
    Protected Overrides Sub SetVisibleCore(ByVal value As Boolean)
        If Not Me.IsHandleCreated Then
            Me.CreateHandle()
            value = False
        End If
        Dim watchfolder As FileSystemWatcher
        watchfolder = New FileSystemWatcher()
        watchfolder.Path = "M:\TV Shows"
        watchfolder.IncludeSubdirectories = True
        watchfolder.NotifyFilter = (NotifyFilters.LastAccess Or NotifyFilters.LastWrite Or NotifyFilters.FileName Or NotifyFilters.DirectoryName)
        AddHandler watchfolder.Created, AddressOf logchange
        watchfolder.EnableRaisingEvents = True
    End Sub
    Private Sub logchange(ByVal source As Object, ByVal e As System.IO.FileSystemEventArgs)
        Dim Transcode As New Process
        Dim TranscodeInfo As New ProcessStartInfo("cmd.exe", "/C python ""C:\Users\charl\Documents\MP4 Converter\manual.py"" -a -i """ & e.FullPath & """")
        TranscodeInfo.CreateNoWindow = True
        TranscodeInfo.UseShellExecute = False
        TranscodeInfo.RedirectStandardOutput = True
        Transcode.StartInfo = TranscodeInfo
        Transcode.Start()
        Transcode.WaitForExit()
    End Sub
End Class



