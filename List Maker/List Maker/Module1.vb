Module Module1
    Sub Main()
        Dim total As Integer = 0
        Dim DocLocation As String = "B:\Movies\Movies.txt"
        Dim BackupLocation As String = "C:\Users\Charlie\Documents\Movies.txt"
        Dim FileBase As String = "B:\Movies\"
        Dim Folders() As String = {"Animated", "Documentaries", "Feature"}
        My.Computer.FileSystem.DeleteFile(DocLocation)
        My.Computer.FileSystem.DeleteFile(BackupLocation)
        For Each Category As String In Folders
            My.Computer.FileSystem.WriteAllText(DocLocation, Category & vbCrLf, True)
            For Each Layer1 As String In My.Computer.FileSystem.GetDirectories(FileBase + Category)
                If Char.IsPunctuation(Layer1.Chars(Layer1.Length - 1)) = False Then
                    Dim iFilm As String = Replace(Layer1, FileBase + Category + "\", "")
                    iFilm = "   " + iFilm & vbCrLf
                    My.Computer.FileSystem.WriteAllText(DocLocation, iFilm, True)
                    For Each sFilm As String In My.Computer.FileSystem.GetDirectories(Layer1)
                        sFilm = Replace(sFilm, Layer1 + "\", "")
                        sFilm = "       " + sFilm & vbCrLf
                        My.Computer.FileSystem.WriteAllText(DocLocation, sFilm, True)
                        total += 1
                    Next
                Else
                    Layer1 = Replace(Layer1, FileBase + Category + "\", "")
                    Layer1 = "   " + Layer1 & vbCrLf
                    My.Computer.FileSystem.WriteAllText(DocLocation, Layer1, True)
                    total += 1
                End If
            Next
            My.Computer.FileSystem.WriteAllText(DocLocation, vbCrLf, True)
        Next
        My.Computer.FileSystem.WriteAllText(DocLocation, "Total: " & total.ToString, True)
        My.Computer.FileSystem.CopyFile(DocLocation, BackupLocation)
    End Sub
End Module
