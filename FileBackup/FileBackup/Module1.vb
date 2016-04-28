Module Module1
    Sub Main()
        Dim OriginalLocations() As String = {"M:\", "C:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive\csgo\cfg\", "C:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive\csgo\"}
        Dim FileNames() As String = {"Media List.txt", "autoexec.cfg", "autobuy.txt"}
        Dim BackupLocations() As String = {"C:\Users\charl\Documents\Backups\", "G:\Backups\", "M:\Backups\", "H:\Backups\"}
        For i As Integer = 0 To FileNames.Length - 1
            For Each Location As String In BackupLocations
                My.Computer.FileSystem.DeleteFile(Location + FileNames(i))
            Next
        Next
        For i As Integer = 0 To FileNames.Length - 1
            For Each Location As String In BackupLocations
                My.Computer.FileSystem.CopyFile(OriginalLocations(i) + FileNames(i), Location + FileNames(i))
            Next
        Next
    End Sub
End Module
