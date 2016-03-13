Module Module1

    Sub Main()
        My.Computer.FileSystem.DeleteFile("B:\Movies\Movies.txt")
        My.Computer.FileSystem.WriteAllText("B:\Movies\Movies.txt", "Animated" & vbCrLf, True)
        For Each foundFile As String In My.Computer.FileSystem.GetDirectories("B:\Movies\Animated")
            If Char.IsPunctuation(foundFile.Chars(foundFile.Length - 1)) = False Then
                Dim otherFile As String = Replace(foundFile, "B:\Movies\Animated\", "")
                otherFile = "   " + otherFile & vbCrLf
                My.Computer.FileSystem.WriteAllText("B:\Movies\Movies.txt", otherFile, True)
                For Each moreFiles As String In My.Computer.FileSystem.GetDirectories(foundFile)
                    moreFiles = Replace(moreFiles, foundFile + "\", "")
                    moreFiles = "       " + moreFiles & vbCrLf
                    My.Computer.FileSystem.WriteAllText("B:\Movies\Movies.txt", moreFiles, True)
                Next
            Else
                foundFile = Replace(foundFile, "B:\Movies\Animated\", "")
                foundFile = "   " + foundFile & vbCrLf
                My.Computer.FileSystem.WriteAllText("B:\Movies\Movies.txt", foundFile, True)
            End If
        Next
        My.Computer.FileSystem.WriteAllText("B:\Movies\Movies.txt", vbCrLf & "Documentaries" & vbCrLf, True)
        For Each foundFile As String In My.Computer.FileSystem.GetDirectories("B:\Movies\Documentaries")
            If Char.IsPunctuation(foundFile.Chars(foundFile.Length - 1)) = False Then
                Dim otherFile As String = Replace(foundFile, "B:\Movies\Documentaries\", "")
                otherFile = "   " + otherFile & vbCrLf
                My.Computer.FileSystem.WriteAllText("B:\Movies\Movies.txt", otherFile, True)
                For Each moreFiles As String In My.Computer.FileSystem.GetDirectories(foundFile)
                    moreFiles = Replace(moreFiles, foundFile + "\", "")
                    moreFiles = "       " + moreFiles & vbCrLf
                    My.Computer.FileSystem.WriteAllText("B:\Movies\Movies.txt", moreFiles, True)
                Next
            Else
                foundFile = Replace(foundFile, "B:\Movies\Documentaries\", "")
                foundFile = "   " + foundFile & vbCrLf
                My.Computer.FileSystem.WriteAllText("B:\Movies\Movies.txt", foundFile, True)
            End If
        Next
        My.Computer.FileSystem.WriteAllText("B:\Movies\Movies.txt", vbCrLf & "Feature" & vbCrLf, True)
        For Each foundFile As String In My.Computer.FileSystem.GetDirectories("B:\Movies\Feature")
            If Char.IsPunctuation(foundFile.Chars(foundFile.Length - 1)) = False Then
                Dim otherFile As String = Replace(foundFile, "B:\Movies\Feature\", "")
                otherFile = "   " + otherFile & vbCrLf
                My.Computer.FileSystem.WriteAllText("B:\Movies\Movies.txt", otherFile, True)
                For Each moreFiles As String In My.Computer.FileSystem.GetDirectories(foundFile)
                    moreFiles = Replace(moreFiles, foundFile + "\", "")
                    moreFiles = "       " + moreFiles & vbCrLf
                    My.Computer.FileSystem.WriteAllText("B:\Movies\Movies.txt", moreFiles, True)
                Next
            Else
                foundFile = Replace(foundFile, "B:\Movies\Feature\", "")
                foundFile = "   " + foundFile & vbCrLf
                My.Computer.FileSystem.WriteAllText("B:\Movies\Movies.txt", foundFile, True)
            End If
        Next
    End Sub

End Module
