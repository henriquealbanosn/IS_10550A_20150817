Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Module Module1
    Sub Main()
        '------------------------------------------
        ' Reading and Writing from Files.
        '------------------------------------------

        Dim filePath As String = "C:\Users\Student\Documents\MyTextFile.txt"
        Dim fileContents As String

        ' Writing examples
        Dim fileLines() As String = {"Line 1", "Line 2", "Line 3"}
        File.AppendAllLines(filePath, fileLines)

        fileContents = "I am writing this text to a file called MyTextFile.txt"
        File.AppendAllText(filePath, fileContents)

        Dim fileBytes() As Byte = {12, 134, 12, 8, 32}
        File.WriteAllBytes(filePath, fileBytes)

        File.WriteAllLines(filePath, fileLines)

        File.WriteAllText(filePath, fileContents)

        ' Reading examples
        Dim data() As Byte = File.ReadAllBytes(filePath)
        Dim lines() As String = File.ReadAllLines(filePath)
        Dim data2 As String = File.ReadAllText(filePath)

        '------------------------------------------
        ' Manipulating Directories.
        '------------------------------------------

        Dim dirPath As String = "C:\Users\Student\Documents\"

        ' Directory class members
        Directory.CreateDirectory(dirPath)
        'Directory.Delete(dirPath) ' You may want to change the path before demonstrating Delete()
        Dim dirs() As String = Directory.GetDirectories(dirPath)
        Dim files() As String = Directory.GetFiles(dirPath)

        ' DirectoryInfo class members
        Dim dir As New DirectoryInfo(dirPath)
        Dim exists As Boolean = dir.Exists
        Dim dirs2() As DirectoryInfo = dir.GetDirectories()
        Dim files2() As FileInfo = dir.GetFiles()
        Dim fullName As String = dir.FullName

        ' Enumerating directory contents
        dirPath = "C:\Users\Student\Documents"

        ' Get all sub directories in the Documents directory.
        Dim subDirs() As String = Directory.GetDirectories(dirPath)

        For Each dir3 As String In subDirs
            ' Display the directory name.
            Console.WriteLine("{0} contains the following files:", dir3)

            ' Get all the files in each directory.
            files = Directory.GetFiles(dir3)

            For Each file As String In files
                ' Display the file name.
                Console.WriteLine(file)
            Next
        Next

        '------------------------------------------
        ' Using the Common File System Dialog Boxes
        '------------------------------------------

        ' Open and Save dialog examples
        Dim openDlg As New OpenFileDialog()
        Dim saveDlg As New SaveFileDialog()

        openDlg.Title = "Browse for a file to open"
        openDlg.Multiselect = False
        openDlg.InitialDirectory = "C:\Users\Student\Documents"
        openDlg.Filter = "Word (*.doc) |*.doc;"

        saveDlg.Title = "Browse for a save location"
        saveDlg.DefaultExt = "doc"
        saveDlg.AddExtension = True
        saveDlg.InitialDirectory = "C:\Users\Student\Documents"
        saveDlg.OverwritePrompt = True

        openDlg.ShowDialog()
        saveDlg.ShowDialog()

        Dim selectedFileName As String = openDlg.FileName
        Dim selectedFileName2 As String = saveDlg.FileName

        '------------------------------------------
        ' Reading and Writing Binary data
        '------------------------------------------

        ' Writing
        Dim destinationFilePath As String = "C:\Users\Student\Documents\BinaryDataFile.bin"

        ' Collection of bytes.
        Dim dataCollection() As Byte = {1, 4, 6, 7, 12, 33, 26, 98, 82, 101}

        ' Create a FileStream object so that you can interact with the file 
        ' system.
        Dim destFile As New FileStream(destinationFilePath, FileMode.Create, FileAccess.Write)

        ' Create a BinaryWriter object passing in the FileStream object.
        Dim writer As New BinaryWriter(destFile)

        ' Write each byte to stream.
        For Each dataItem As Byte In dataCollection
            writer.Write(dataItem)
        Next

        ' Close both streams to flush the data to the file.
        writer.Close()
        destFile.Close()

        ' Reading

        ' Source file path.
        Dim sourceFilePath As String = "C:\Users\Student\Documents\BinaryDataFile.bin"

        ' Create a FileStream object so that you can interact with the file 
        ' system.
        Dim sourceFile As New FileStream(sourceFilePath, FileMode.Open, FileAccess.Read)

        ' Create a BinaryWriter object passing in the FileStream object.
        Dim reader As New BinaryReader(sourceFile)

        ' Store the current position of the stream.
        Dim position As Integer = 0
        ' Store the length of the stream.
        Dim length As Integer = CType(reader.BaseStream.Length, Integer)

        ' Create an array to store each byte from the file.
        Dim dataCollection2() As Byte
        ReDim dataCollection2(length)
        Dim returnedByte As Integer

        While (returnedByte = reader.Read) <> -1
            ' Set the value at the next index.
            dataCollection2(position) = CType(returnedByte, Byte)

            ' Advance our position variable.
            position += 1
        End While

        ' Close the streams to release any file handles.
        reader.Close()
        sourceFile.Close()

        '------------------------------------------
        ' Reading and Writing BText
        '------------------------------------------

        ' Writing
        destinationFilePath = "C:\Users\Student\Documents\TextDataFile.txt"

        Dim data4 As String = "Hello, this will be written in plain text"

        ' Create a FileStream object so that you can interact with the file 
        ' system.
        Dim destFile1 As New FileStream(destinationFilePath, FileMode.Create, FileAccess.Write)

        ' Create a new StreamWriter object.
        Dim writer1 As New StreamWriter(destFile1)

        ' Write the string to the file.
        writer1.WriteLine(data4)

        ' Always close the underlying streams to flush the data to the file 
        ' and release any file handles.
        writer1.Close()
        destFile1.Close()

        ' Reading
        sourceFilePath = "C:\Users\Student\Documents\TextDataFile.txt"

        ' Create a FileStream object so that you can interact with the file 
        ' system.
        Dim sourceFile3 As New FileStream(sourceFilePath, FileMode.Open, FileAccess.Read)

        Dim reader3 As New StreamReader(sourceFile3)
        Dim fileContents3 As New StringBuilder()

        ' Check to see if the end of the file
        ' has been reached.
        While reader3.Peek() <> -1
            ' Read the next character.
            fileContents3.Append(CType(CChar(CStr(reader3.Read)), Char))
        End While

        ' Store the file contents in a new string variable.
        Dim data5 As String = fileContents3.ToString()

        ' Always close the underlying streams release any file handles.
        reader.Close()
        sourceFile3.Close()
    End Sub
End Module