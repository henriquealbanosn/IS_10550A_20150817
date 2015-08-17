' System.IO contains the StreamReader class, used to read data from CSV files
Imports System.IO

' Microsoft.Win32 contains the Open File and Save File common dialogs 
' used to prompt the user for the names of the CSV files and the Excel worksheet
Imports Microsoft.Win32

' TODO: Add the Microsoft.Office.Interop.Excel namespace

Class GraphWindow
    ''' <summary>
    ''' graphData contains the stress analysis data
    ''' <para>
    ''' This variable is a List of StressData objects. Each StressData object holds
    ''' the stress analysis results for single temperature
    ''' </para>
    ''' </summary>
    ''' <remarks></remarks>
    Private graphData As List(Of StressData) = Nothing

    ''' <summary>
    ''' Initialize the WPF window and the graphData variable
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        InitializeComponent()
        Me.graphData = New List(Of StressData)()
    End Sub

    ''' <summary>
    ''' Read a CSV data containing stress analysis data and populate a StressData object with this information
    ''' <para>
    ''' The data is held in the following format:
    ''' <code>
    ''' 298
    ''' 100,15
    ''' 200,35
    ''' 300,55
    ''' ...
    ''' 1500,550
    ''' </code>
    ''' </para>
    ''' <para>
    ''' The first line specifies the temperature used for the test (in Kelvin).
    ''' </para>
    ''' <para>
    ''' Subsequent lines contain pairs of values: the applied stress (in kN), and the deflection resulting from this stress (in mm).
    ''' </para>
    ''' <para>
    ''' The applied stress is specified in 100 kN increments, from 100kN to 1500 kN. 
    ''' The deflection data for a specified stress may be absent (usually if the applied stress caused a complete failure).
    ''' </para>
    ''' </summary>
    ''' <param name="strData">
    ''' The StressData object to populate. This object must have been created prior to calling the method.
    ''' </param>
    ''' <param name="fileName">
    ''' The name of the file containing the CSV data
    ''' </param>
    ''' <returns>
    ''' True if the StressData object was populated successfully, false otherwise
    ''' </returns>
    ''' <remarks></remarks>
    Private Function populateFromFile(ByVal strData As StressData, ByVal fileName As String) As Boolean
        Try
            ' Open the CSV file for reading 
            Using dataFile As New StreamReader(fileName)
                ' Read the temperature held in the first line of the file and save it in the StressData object
                strData.Temperature = Short.Parse(dataFile.ReadLine())

                ' Initialize the List of stress/deflection pairs in the StressData object
                strData.Data = New Dictionary(Of Short, Short?)()

                Dim separators() As Char = {","c}

                ' Read each line until the end of the file
                While Not dataFile.EndOfStream
                    Dim nextStressDataLine As String = dataFile.ReadLine()

                    ' Parse the data. Split it using the comma as the separator
                    Dim nextStressDataValues() As String = nextStressDataLine.Split(separators)
                    Dim appliedStress As Short

                    ' Parse the applied stress value. This should be a short. 
                    ' If it is not, then skip this line
                    If Short.TryParse(nextStressDataValues(0), appliedStress) Then
                        ' Parse the deflection value. This should also be a short.
                        ' If it is, then add the applied stress/deflection pair to the List in the StressData object
                        ' Otherwise add the applied stress but specify a null value for the deflection
                        Dim deflection As Short

                        If Short.TryParse(nextStressDataValues(1), deflection) Then
                            strData.Data.Add(appliedStress, deflection)
                        Else
                            strData.Data.Add(appliedStress, Nothing)
                        End If
                    End If
                End While

                ' On success, return true
                Return True
            End Using
        Catch ex As Exception
            ' If an exception occurs, alert the user and return false
            MessageBox.Show(ex.Message)

            Return False
        End Try
    End Function

    ''' <summary>
    ''' Event-handling method for the Click event of the getData button on the WPF form.
    ''' <para>
    ''' This method gets the name of a file containing CSV data, creates a StressData object, 
    ''' and then calls the <c>populateFromFile</c> method to read the data and populate it.
    ''' </para>
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetDataButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        ' Prompt the user for the name of the file containing the CSV data by using the Open File common dialog.
        Dim openDialog As New OpenFileDialog()
        openDialog.DefaultExt = "txt"
        openDialog.Multiselect = False
        openDialog.InitialDirectory = "D:\Labfiles\Lab15\"
        openDialog.ValidateNames = True
        openDialog.Title = "Graph Data"

        ' If the user specifies a valid filename, create a StressData object and populate it
        ' with data in the file.
        ' Display the data when it has been read in.
        If openDialog.ShowDialog().Value Then
            Dim strData As New StressData()

            If populateFromFile(strData, openDialog.FileName) Then
                Me.graphData.Add(strData)
                displayData(strData)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Display the data in a StressData object by adding it to a TreeView control on the WPF form.
    ''' </summary>
    ''' <param name="strData">
    ''' The StressData object containing the data to add to the TreeView control
    ''' </param>
    ''' <remarks></remarks>
    Private Sub displayData(ByVal strData As StressData)
        ' Create a new TreeViewItem object and fill it with the data from the StressData object
        Dim displayItem As New TreeViewItem()
        displayItem.Header = String.Format("Temperature: {0}K", strData.Temperature)

        For Each itm In strData.Data
            displayItem.Items.Add(String.Format("Stress: {0}kN" & vbTab & vbTab & "Deflection: {1}mm", itm.Key, If(itm.Value Is Nothing, -1, itm.Value)))
        Next

        ' Add the TreeViewItem object to the TreeView control and display it on the WPF form
        Me.DataDisplayTreeView.Items.Add(displayItem)
    End Sub

    '''<summary>
    '''Event-handling method for the Click event of the generateGraph button on the WPF form.
    '''<para>
    '''This method copies the data in the list of StressData objects in the graphData variable
    '''to a an Excel spreadsheet, and then generates an Excel chart.
    '''</para>
    '''The spreadsheet and chart is saved in a file with the name specified by the user.
    '''</summary>
    ''' <remarks></remarks>
    Private Sub GenerateGraphButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        ' Verify that the graphData variable actually contains some data.
        ' Do not invoke Excel or attempt to generate a chart if there is no data.
        If graphData.Count > 0 Then
            Dim excelApp As Excel.Application = Nothing

            Try
                ' Prompt the user for the name of the Excel file to create by using
                ' the Save File common dialog
                Dim saveDialog As New SaveFileDialog()
                saveDialog.DefaultExt = "xlsx"
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx;*.xls"
                saveDialog.InitialDirectory = "D:\Labfiles\Lab15\"
                saveDialog.OverwritePrompt = True
                saveDialog.FileName = "StressData"
                saveDialog.ValidateNames = True
                saveDialog.Title = "Graph Data"

                If saveDialog.ShowDialog().Value Then
                    ' TODO: If the user specifies a valid file name, start Excel 
                    ' and create a new workbook and worksheet to hold the data

                    ' TODO: Copy the data from the graphData variable to the new worksheet and generate a graph
                    ' The dataRange variable specifies the cells on the worksheet that hold the data

                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                ' TODO: Close Excel and release any resources
            End Try
        Else
            ' If the graphData variable is empty, display a message to the user
            MessageBox.Show("No data loaded")
        End If
    End Sub

    ''' <summary>
    ''' Generate a chart from the data in an Excel worksheet, add it to the workbook, and save it.
    ''' </summary>
    ''' <param name="fileName">
    ''' The name of the file to save the Excel workbook.
    ''' </param>
    ''' <param name="excelWB">
    ''' The Excel workbook to add the chart to.
    ''' </param>
    ''' <param name="dataRange">
    ''' The range specifying the data to use for the chart.
    ''' </param>
    ''' <remarks></remarks>
    Private Shared Sub generateExcelChart(ByVal fileName As String, ByVal excelWB As Excel.Workbook, ByVal dataRange As Excel.Range)
        ' TODO: Generate a line graph based on the data in the dataRange range.

        ' TODO: Save the Excel workbook           
    End Sub

    ''' <summary>
    ''' Copy the data from the graphData variable to an Excel worksheet.
    ''' </summary>
    ''' <param name="excelWS">
    ''' The Excel worksheet to hold the data.
    ''' </param>
    ''' <param name="dataRange">
    ''' The range in the Excel worksheet that holds the data. This is an <c>out</c> parameter.
    ''' </param>
    ''' <param name="excelData">
    ''' The data to copy to the worksheet
    ''' </param>
    ''' <returns>
    ''' True if the data is copied sucessfully, false otherwise.
    ''' </returns>
    ''' <remarks></remarks>
    Private Function transferDataToExcelSheet(ByVal excelWS As Excel.Worksheet, ByRef dataRange As Excel.Range, ByVal excelData As List(Of StressData)) As Boolean
        Try
            ' TODO: Copy the data for the applied stresses to the first column in the worksheet. 
            ' This should be a list of values: 100, 200, 300, ..., 1500
            ' Each set of data in the list in the graphData object uses the same set of stresses.

            ' Copy the deflection data for each set of test results to a new column in the worksheet
            For Each deflectionData As StressData In excelData
                ' TODO: Give each column a header that specifies the temperature

                ' Copy the delection data to this column in the worksheet
                For Each deflection As Short? In deflectionData.Data.Values
                    ' TODO: Only copy the deflection value if it is not null
                    If Not deflection Is Nothing Then

                    End If
                Next
            Next

            ' TODO: Specify the range of cells in the spreadsheet containing the data in the dataRange variable

            ' Return true to indicate that the data has been successfully copied
            Return True
        Catch ex As Exception
            ' If an exception occurs display a message, set dataRange to null, and return false
            MessageBox.Show(ex.Message)
            dataRange = Nothing

            Return False
        End Try
    End Function
End Class