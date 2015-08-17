Imports System.Text

Class MainWindow

    Private Sub ConvertButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles ConvertButton.Click
        ' Get the integer entered by the user
        Dim i As Integer

        If Not Integer.TryParse(InputTextBox.Text, i) Then
            MessageBox.Show("TextBox does not contain an integer")

            Return
        End If

        ' Check that the user has not entered a negative number 
        If i < 0 Then
            MessageBox.Show("Please enter a positive number or zero")

            Return
        End If

        ' Remainder will hold the remainder after dividing i by 2
        ' after each iteration of the algorithm
        Dim remainder As Integer = 0

        ' Binary will be used to construct the string of bits
        ' that represent i as a binary value
        Dim binary As New StringBuilder()

        ' Generate the binary representation of i
        Do Until i = 0
            remainder = i Mod 2
            i = i \ 2
            binary.Insert(0, remainder)
        Loop

        ' Display the result
        BinaryLabel.Content = binary.ToString()
    End Sub
End Class
