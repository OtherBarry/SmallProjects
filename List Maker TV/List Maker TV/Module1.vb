Module Module1
    Sub Main()
        Dim DocLocation As String = "F:\TV\TV Shows.txt"
        Dim BackupLocation As String = "C:\Users\Charlie\Documents\TV Shows.txt"
        My.Computer.FileSystem.DeleteFile(DocLocation)
        My.Computer.FileSystem.DeleteFile(BackupLocation)
        For Each foundShow As String In My.Computer.FileSystem.GetDirectories("F:\TV")
            Dim showName As String = Replace(foundShow, "F:\TV\", "")
            My.Computer.FileSystem.WriteAllText(DocLocation, showName & vbCrLf, True)
            For Each foundSeason As String In My.Computer.FileSystem.GetDirectories(foundShow)
                foundSeason = Replace(foundSeason, foundShow + "\", "")
                foundSeason = "   " + foundSeason & vbCrLf
                My.Computer.FileSystem.WriteAllText(DocLocation, foundSeason, True)
            Next
        Next
        My.Computer.FileSystem.CopyFile(DocLocation, BackupLocation)
    End Sub
End Module
