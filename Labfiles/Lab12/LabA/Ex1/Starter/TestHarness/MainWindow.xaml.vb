Imports GaussianElimination

Class MainWindow
    ''' <summary>
    ''' Solve the simultaneous equations
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SolveButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        ' Array to hold the coefficients of the equations
        Dim coefficients(,) As Double
        ReDim coefficients(Gauss.numberOfEquations, Gauss.numberOfEquations)

        ' Array to hold the constants (Right Hand Side)
        Dim rhs() As Double
        ReDim rhs(Gauss.numberOfEquations)

        ' Array to hold the solution values
        Dim answers() As Double
        ReDim answers(Gauss.numberOfEquations)

        ' Get the user entered data
        CollectAndValidateInput(coefficients, rhs)

        ' Solve the equations
        answers = Gauss.SolveGaussian(coefficients, rhs)

        ' Display the results
        DisplayResults(answers)
    End Sub

    ''' <summary>
    ''' Read the user entered data
    ''' </summary>
    ''' <param name="coefficients">Coefficients for all equations</param>
    ''' <param name="rhs">Constants for all equations</param>
    ''' <remarks></remarks>
    Private Sub CollectAndValidateInput(ByVal coefficients(,) As Double, ByVal rhs() As Double)
        ' No error handling yet
        coefficients(0, 0) = Double.Parse(Me.w1TextBox.Text)
        coefficients(0, 1) = Double.Parse(Me.x1TextBox.Text)
        coefficients(0, 2) = Double.Parse(Me.y1TextBox.Text)
        coefficients(0, 3) = Double.Parse(Me.z1TextBox.Text)
        coefficients(1, 0) = Double.Parse(Me.w2TextBox.Text)
        coefficients(1, 1) = Double.Parse(Me.x2TextBox.Text)
        coefficients(1, 2) = Double.Parse(Me.y2TextBox.Text)
        coefficients(1, 3) = Double.Parse(Me.z2TextBox.Text)
        coefficients(2, 0) = Double.Parse(Me.w3TextBox.Text)
        coefficients(2, 1) = Double.Parse(Me.x3TextBox.Text)
        coefficients(2, 2) = Double.Parse(Me.y3TextBox.Text)
        coefficients(2, 3) = Double.Parse(Me.z3TextBox.Text)
        coefficients(3, 0) = Double.Parse(Me.w4TextBox.Text)
        coefficients(3, 1) = Double.Parse(Me.x4TextBox.Text)
        coefficients(3, 2) = Double.Parse(Me.y4TextBox.Text)
        coefficients(3, 3) = Double.Parse(Me.z4TextBox.Text)

        rhs(0) = Double.Parse(Me.r1TextBox.Text)
        rhs(1) = Double.Parse(Me.r2TextBox.Text)
        rhs(2) = Double.Parse(Me.r3TextBox.Text)
        rhs(3) = Double.Parse(Me.r4TextBox.Text)

        ' Display formatted versions of the equations
        Me.Equation1Label.Content = String.Format("{0}w + {1}x + {2}y + {3}z = {4}", coefficients(0, 0), coefficients(0, 1), coefficients(0, 2), coefficients(0, 3), rhs(0))
        Me.Equation2Label.Content = String.Format("{0}w + {1}x + {2}y + {3}z = {4}", coefficients(1, 0), coefficients(1, 1), coefficients(1, 2), coefficients(1, 3), rhs(1))
        Me.Equation3Label.Content = String.Format("{0}w + {1}x + {2}y + {3}z = {4}", coefficients(2, 0), coefficients(2, 1), coefficients(2, 2), coefficients(2, 3), rhs(2))
        Me.Equation4Label.Content = String.Format("{0}w + {1}x + {2}y + {3}z = {4}", coefficients(3, 0), coefficients(3, 1), coefficients(3, 2), coefficients(3, 3), rhs(3))
    End Sub

    ''' <summary>
    ''' Display formatted results
    ''' </summary>
    ''' <param name="answers">Array containing solution</param>
    ''' <remarks></remarks>
    Private Sub DisplayResults(ByVal answers() As Double)
        Me.ResultsLabel.Content = String.Format("w = {0}, x = {1}, y = {2}, z = {3}", answers(0), answers(1), answers(2), answers(3))
    End Sub
End Class