Imports System.Text
Imports System.Dynamic

' TODO: Add Namespaces containing IronPython and IronRuby runtime support and interop types

''' <summary>
''' WPF application to demonstrate C# interoperability with Python and Ruby.
''' <para>
''' The Python script implements the Fisher-Yates-Durstenfeld algorithm to randomly shuffle data in a collection. 
''' It is used for generating random sequences with a specified set of values.
''' </para>
''' The Ruby script implements a trapezoid class. It is used for architectural modelling.
''' </summary>
''' <remarks></remarks>
Class InteropTestWindow
    ''' <summary>
    ''' pythonLibPath holds the name of the folder containing the modules provided with Python.
    ''' <para>
    ''' pythonCode and rubyCode hold the paths to the Python and Ruby scripts used by this application.
    ''' </para>
    ''' </summary>
    ''' <remarks></remarks>
    Private Const pythonLibPath As String = "C:\Program Files (x86)\IronPython 2.6 for .NET 4.0\Lib"
    Private Const pythonCode As String = "D:\Labfiles\Lab15\Python\Shuffler.py"
    Private Const rubyCode As String = "D:\Labfiles\Lab15\Ruby\Trapezoid.rb"

    ''' <summary>
    ''' Event-handling method for the Click event of the Shuffle button on the Python Test tab.
    ''' <para>
    ''' This method reads the data provided by the user, divides it into a list of words or numbers, and stores this list in an array.
    ''' The method then calls the ShuffleData method to randomly shuffle this data, and then displays the result.
    ''' </para>
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShuffleButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Try
            ' PythonTestDataTextBox holds the user input.
            ' This can be a series of words or numbers, seperated by spaces.
            ' inputData is populated with an array of strings, where each string is the text of a word or number.
            Dim inputData() As String = Me.PythonTestDataTextBox.Text.Split(" "c)

            ' data will hold a copy of the strings from inputData and convert them to numbers
            ' depending on whether the user specified that the data was numeric or text
            Dim data As Object()
            ReDim data(inputData.Length - 1)

            If Me.IntegerRadioButton.IsChecked.Value Then
                For n As Integer = 0 To inputData.Length - 1
                    data(n) = Int32.Parse(inputData(n))
                Next
            Else
                inputData.CopyTo(data, 0)
            End If

            ' Shuffle the data array
            ShuffleData(data)

            ' Display the shuffled results in the shuffledData TextBox
            Me.ShuffledDataTextBox.Clear()
            Dim result As New StringBuilder()

            For Each item In data

                result.Append(item.ToString())
                result.Append(" "c)
            Next

            Me.ShuffledDataTextBox.Text = result.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' This method calls the Python script to create an instance of the Shuffler class and shuffle the data.
    ''' </summary>
    ''' <param name="data">
    ''' The array containing the data to be shuffled.
    ''' </param>
    ''' <remarks></remarks>
    Private Sub ShuffleData(ByVal data() As Object)
        ' TODO: Create an instance of the Python runtime, and add a reference to the folder holding the "random" module.
        ' (The Python script references this module)

        ' TODO: Run the script and create an instance of the Shuffler class by using the CreateShuffler method in the script.

        ' TODO: Shuffle the data            
    End Sub

    ''' <summary>
    ''' Event-handling method for the Visualize button on the Ruby Test tab.
    ''' <para>
    ''' This method retrieves the parameters that define a trapezoid from the slider controls
    ''' on the form, and call the CreateTrapezoid method to create an instance of the Ruby
    ''' Trapezoid class using these values.
    ''' </para>
    ''' <para>
    ''' A graphical representation of the trapezoid is displayed on a canvas in the lower part of the tab.
    ''' </para>
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub VisualizeButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Try
            ' TODO: Retrieve the values specified by the user. These values are used to create the trapezoid.

            ' TODO: Call the CreateTrapezoid method and build a trapezoid object.

            ' TODO: Display the lengths of each side, the internal angles, and the area of the trapezoid.

            ' TODO: Display a graphical representation of the trapezoid.                
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' This method displays the length of each side of the trapezoid, together with the internal angles, and the area.
    ''' The results are displayed in a formatted TextBlock control.
    ''' </summary>
    ''' <param name="trapezoid">
    ''' The trapezoid to display the details for.
    ''' </param>
    ''' <param name="trapezoidStatistics">
    ''' The TextBlock control to display the results in.
    ''' </param>
    ''' <remarks></remarks>
    Private Sub DisplayStatistics(ByVal trapezoid As Object, ByVal trapezoidStatistics As TextBlock)
        ' TODO: Use a StringBuilder object to construct a string holding the details of the trapezoid.

        ' TODO: Call the to_s method of the trapezoid object to return the details of the trapezoid as a string.
        ' Note: The ToString method invokes to_s.

        ' TODO: Calculate the area of the trapezoid by using the area method of the trapezoid class
        ' and append it to the string holding the details of the trapezoid

        ' TODO: Display the details of the trapezoid in the TextBlock control
    End Sub

    ''' <summary>
    ''' This method displays a graphical representation of a trapezoid on a canvas.
    ''' </summary>
    ''' <param name="trapezoid">
    ''' The trapezoid to display.
    ''' </param>
    ''' <param name="renderCanvas">
    ''' The canvas to display the trapezoid on.
    ''' </param>
    ''' <remarks></remarks>
    Private Sub RenderTrapezoid(ByVal trapezoid As Object, ByVal renderCanvas As Canvas)
        ' Draw the trapezoid by using a filled polygon.
        Dim renderedTrapezoid As New Polygon()
        renderedTrapezoid.Stroke = Brushes.DeepSkyBlue
        renderedTrapezoid.StrokeThickness = 1
        renderedTrapezoid.Fill = Brushes.DeepSkyBlue

        ' Define the first point of the polygon (Vertex A) to point 1,1 
        Dim pointOfVertexA As New Point(1, 1)

        ' Define the second point of the polygon (Vertex B).
        ' The side AB forms the base of the polygon, so Vertex B has the same y-coordinate as
        ' Vertex A, and the x-coordinate is the length of the base of the trapezoid.
        Dim pointOfVertexB As New Point(trapezoid.sideAB, 1)

        ' Define the third point of the polygon (Vertex C).
        ' The x-coordinate depends on the angle of Vertex B and the length of side BC:
        '  
        '           D----------------C
        '          /|                |\
        '         / |                | \
        '        /  |h              h|  \
        '       /   |                |   \
        '      A----F----------------E----B
        ' 
        ' Using trigonomtry, length of sideEB = h / tan(Vertex B)
        ' 
        ' The x-coordinate of Vertex C (side AE) is length of sideAB - length of sideEB
        ' The y-coordinate of Vertex C is h
        Dim vertexBInRadians As Double = trapezoid.vertexB * Math.PI / 180
        Dim xCoordOfPointC As Double = trapezoid.sideAB - (trapezoid.h / Math.Tan(vertexBInRadians))
        Dim pointOfVertexC As New Point(xCoordOfPointC, trapezoid.h)

        ' Define the fourth point of the polygon (Vertex D).
        ' The x-coordinate of Vertex D is the x-coordinate of Vertex C - the length of sideCD.
        ' The y-coordinate of Vertex D is h
        Dim xCoordOfPointD As Double = xCoordOfPointC - trapezoid.sideCD
        Dim pointOfVertexD As New Point(xCoordOfPointD, trapezoid.h)

        ' Add the four points to the polygon
        renderedTrapezoid.Points.Add(pointOfVertexA)
        renderedTrapezoid.Points.Add(pointOfVertexB)
        renderedTrapezoid.Points.Add(pointOfVertexC)
        renderedTrapezoid.Points.Add(pointOfVertexD)

        ' By default, the polygon will appear upside down and in the wrong place on the canvas,
        ' so it needs to be rotated, translated, and scaled to fit
        Dim rotateTransform As Transform = New RotateTransform(180)
        Dim translateTransform As Transform = New TranslateTransform(renderCanvas.Width, renderCanvas.Height + 40)
        Dim scaleTransform As Transform = New ScaleTransform(1.25, 1.25, renderCanvas.Width * 2, renderCanvas.Height * 2)
        Dim transformations As New TransformGroup()
        transformations.Children.Add(rotateTransform)
        transformations.Children.Add(translateTransform)
        transformations.Children.Add(scaleTransform)
        renderedTrapezoid.RenderTransform = transformations

        ' Display the polygon on the canvas
        renderCanvas.Children.Clear()
        renderCanvas.Children.Add(renderedTrapezoid)

        ' Label each of the vertices
        ' (The positioning is only approximate in this example)
        ' Start with Vertex A in the bottom left
        Dim labelA As New Label()
        Canvas.SetLeft(labelA, 400)
        Canvas.SetTop(labelA, 260)
        labelA.Content = "A"
        labelA.FontFamily = New FontFamily("Book Antiqua")
        labelA.FontStyle = FontStyles.Italic
        labelA.FontWeight = FontWeights.Bold
        renderCanvas.Children.Add(labelA)

        ' Vertex B is in the bottom right.
        ' The x-coordinate (the Left property) depends on the width of the trapezoid
        Dim labelB As New Label()
        Canvas.SetLeft(labelB, 250 - trapezoid.sideAB)
        Canvas.SetTop(labelB, 260)
        labelB.Content = "B"
        labelB.FontFamily = New FontFamily("Book Antiqua")
        labelB.FontStyle = FontStyles.Italic
        labelB.FontWeight = FontWeights.Bold
        renderCanvas.Children.Add(labelB)

        ' Vertex C is in the top right.
        ' The x-coordinate (Left property) is the same as that for Vertex B
        ' The y-coordinate (Top property) depends on the height of the trapezoid
        Dim labelC As New Label()
        Canvas.SetLeft(labelC, 250 - trapezoid.sideAB)
        Canvas.SetTop(labelC, 225 - trapezoid.h)
        labelC.Content = "C"
        labelC.FontFamily = New FontFamily("Book Antiqua")
        labelC.FontStyle = FontStyles.Italic
        labelC.FontWeight = FontWeights.Bold
        renderCanvas.Children.Add(labelC)

        ' Vertex D is the top left.
        ' The x-coordinate (Left property) as the same as that for Vertex A
        ' The y-coordinate (Top property) as the same as that for Vertex C
        Dim labelD As New Label()
        Canvas.SetLeft(labelD, 400)
        Canvas.SetTop(labelD, 225 - trapezoid.h)
        labelD.Content = "D"
        labelD.FontFamily = New FontFamily("Book Antiqua")
        labelD.FontStyle = FontStyles.Italic
        labelD.FontWeight = FontWeights.Bold
        renderCanvas.Children.Add(labelD)
    End Sub

    ''' <summary>
    ''' This method calls the Ruby script to create a trapezoid object.
    ''' </summary>
    ''' <param name="vertexAInDegrees">
    ''' The angle of Vertex A, in degrees.
    ''' </param>
    ''' <param name="lengthSideAB">
    ''' The length of the base of the trapezoid.
    ''' </param>
    ''' <param name="lengthSideCD">
    ''' The length of the top edge of the trapezoid.
    ''' </param>
    ''' <param name="heightOfTrapezoid">
    ''' The height of the trapezoid.
    ''' </param>
    ''' <returns>
    ''' A trapezoid object.
    ''' </returns>
    ''' <remarks></remarks>
    Private Function CreateTrapezoid(ByVal vertexAInDegrees As Integer, ByVal lengthSideAB As Integer, ByVal lengthSideCD As Integer, ByVal heightOfTrapezoid As Integer) As Object
        Throw New NotImplementedException()
        ' TODO: Create an instance of the Ruby runtime.

        ' TODO: Run the Ruby script that defines the Trapezoid class.

        ' TODO: Call the CreateTrapezoid method in the Ruby script to create a trapezoid object.

        ' TODO: Return the trapezoid object.            
    End Function
End Class
