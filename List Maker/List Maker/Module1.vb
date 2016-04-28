Module Module1
    Sub Main()
        Dim filmTotal As Integer = 0
        Dim DocLocation As String = "M:\Media List.txt"
        Dim BackupLocation As String = "C:\Users\charl\Documents\Media List.txt"
        My.Computer.FileSystem.DeleteFile(DocLocation)
        My.Computer.FileSystem.DeleteFile(BackupLocation)
        My.Computer.FileSystem.WriteAllText(DocLocation, "Movies" & vbCrLf, True)
        For Each film As String In My.Computer.FileSystem.GetDirectories("M:\Movies\")
            film = Replace(film, "M:\Movies\", "")
            film = "  " + film & vbCrLf
            My.Computer.FileSystem.WriteAllText(DocLocation, film, True)
            filmTotal += 1
        Next
        My.Computer.FileSystem.WriteAllText(DocLocation, "Total Films: " + filmTotal.ToString & vbCrLf & vbCrLf, True)
        My.Computer.FileSystem.WriteAllText(DocLocation, "TV Shows" & vbCrLf, True)
        For Each Show As String In My.Computer.FileSystem.GetDirectories("M:\TV Shows\")
            Dim output As String = Replace(Show, "M:\TV Shows\", "")
            output = "  " + output & vbCrLf
            My.Computer.FileSystem.WriteAllText(DocLocation, vbCrLf & output, True)
            For Each Season As String In My.Computer.FileSystem.GetDirectories(Show)
                Season = Replace(Season, Show + "\", "")
                Season = "      " + Season & vbCrLf
                My.Computer.FileSystem.WriteAllText(DocLocation, Season, True)
            Next
        Next
        My.Computer.FileSystem.CopyFile(DocLocation, BackupLocation)
    End Sub
End Module
