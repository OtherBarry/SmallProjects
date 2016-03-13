Module Module1

    Sub Main()
        My.Computer.FileSystem.DeleteFile("F:\TV\TV Shows.txt")
        For Each foundShow As String In My.Computer.FileSystem.GetDirectories("F:\TV")
            Dim showName As String = Replace(foundShow, "F:\TV\", "")
            My.Computer.FileSystem.WriteAllText("F:\TV\TV Shows.txt", showName & vbCrLf, True)
            For Each foundSeason As String In My.Computer.FileSystem.GetDirectories(foundShow)
                foundSeason = Replace(foundSeason, foundShow + "\", "")
                foundSeason = "   " + foundSeason & vbCrLf
                My.Computer.FileSystem.WriteAllText("F:\TV\TV Shows.txt", foundSeason, True)
            Next
        Next
    End Sub

End Module
