Class MainWindow 

    Private Sub CalculateButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles CalculateButton.Click
        ' Get a double from the TextBox
        Dim numberDouble As Double

        If Not Double.TryParse(InputTextBox.Text, numberDouble) Then
            MessageBox.Show("Please enter a double")

            Return
        End If

        ' Check that the user has entered a positive number 
        If numberDouble <= 0 Then
            MessageBox.Show("Please enter a positive number")

            Return
        End If

        ' Use the .NET Framework Math.Sqrt method
        Dim squareRoot As Double = Math.Sqrt(numberDouble)

        ' Format the result and display it
        FrameworkLabel.Content = String.Format("{0} (Using the .NET Framework)", squareRoot)

        ' Newton's method for calculating square roots

        ' Get user input as a decimal
        Dim numberDecimal As Decimal

        If Not Decimal.TryParse(InputTextBox.Text, numberDecimal) Then
            MessageBox.Show("Please enter a decimal")

            Return
        End If

        ' Specify 10 to the power of -28 as the minimum delta between
        ' estimates. This is the minimum range supported by the decimal 
        ' type. When the difference between 2 estimates is less than this
        ' value, then stop.
        Dim delta As Decimal = Convert.ToDecimal(Math.Pow(10, -28))

        ' Take an initial guess at an answer to get started
        Dim guess As Decimal = numberDecimal / 2

        ' Estimate result for the first iteration
        Dim result As Decimal = ((numberDecimal / guess) + guess / 2)

        ' While the difference between values for each current iteration 
        ' is not less than delta, then perform another iteration to
        ' refine the answer.

        While Math.Abs(result - guess) > delta
            ' Use the result from the previous iteration
            ' as the starting point
            guess = result

            ' Try again
            result = ((numberDecimal / guess) + guess) / 2
        End While

        ' Display the result
        NewtonLabel.Content = String.Format("{0} (Using Newton)", result)
    End Sub
End Class
