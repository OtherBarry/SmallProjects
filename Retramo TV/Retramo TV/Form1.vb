Imports System.IO
Public Class Form1
    Protected Overrides Sub SetVisibleCore(ByVal value As Boolean)
        If Not Me.IsHandleCreated Then
            Me.CreateHandle()
            value = False
        End If
        MyBase.SetVisibleCore(value)
        Dim watchfolder As FileSystemWatcher
        watchfolder = New FileSystemWatcher()
        watchfolder.Path = "H:\Downloads\Sonarr"
        watchfolder.IncludeSubdirectories = False
        watchfolder.NotifyFilter = (NotifyFilters.LastAccess Or NotifyFilters.LastWrite Or NotifyFilters.FileName Or NotifyFilters.DirectoryName)
        AddHandler watchfolder.Created, AddressOf logchange
        watchfolder.EnableRaisingEvents = True
    End Sub
    Private Sub logchange(ByVal source As Object, ByVal e As System.IO.FileSystemEventArgs)
        Dim rename As New Process
        Dim renameInfo As New ProcessStartInfo("cmd.exe", "/C filebot -rename ""H:\Downloads\Sonarr"" --format ""{n}/{'Season '+s}/{n} - {s00e00} - {t}"" -non-strict -r")
        renameInfo.CreateNoWindow = True
        renameInfo.UseShellExecute = False
        renameInfo.RedirectStandardOutput = True
        rename.StartInfo = renameInfo
        Dim Transcode As New Process
        Dim TranscodeInfo As New ProcessStartInfo("cmd.exe", "/C python ""C:\Users\charl\Documents\MP4 Converter\manual.py"" -a -i ""H:\Downloads\TVTBC""")
        TranscodeInfo.CreateNoWindow = True
        TranscodeInfo.UseShellExecute = False
        TranscodeInfo.RedirectStandardOutput = True
        Transcode.StartInfo = TranscodeInfo
        GetVideoFiles("H:\Downloads\Sonarr")
        rename.Start()
        rename.WaitForExit()
        MoveAllItems("H:\Downloads\Sonarr", "H:\Downloads\TVTBC")
        Transcode.Start()
        Transcode.WaitForExit()
        MoveAllItems("H:\Downloads\TVTBC", "M:\TV Shows")
    End Sub
    Sub MoveAllItems(ByVal fromPath As String, ByVal toPath As String)
        My.Computer.FileSystem.CopyDirectory(fromPath, toPath, True)
        For Each Dir As String In Directory.GetDirectories(fromPath)
            My.Computer.FileSystem.DeleteDirectory(Dir, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
        Next
    End Sub
    Sub GetVideoFiles(ByVal path As String)
        For Each dir As String In Directory.GetDirectories(path)
            For Each file As String In Directory.GetFiles(dir)
                Dim filechars() As Char = file.ToCharArray
                Dim ext As String = filechars(filechars.Length - 3) + filechars(filechars.Length - 2) + filechars(filechars.Length - 1)
                If ext = "avi" Or ext = "mkv" Or ext = "m4v" Or ext = "mp4" Or ext = "mov" Or ext = "srt" And Not file.Contains("sample") Then
                    Dim filenew As String = Replace(file, dir, "")
                    System.IO.File.Move(file, path + filenew)
                End If
            Next
            My.Computer.FileSystem.DeleteDirectory(dir, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
        Next
    End Sub
End Class
