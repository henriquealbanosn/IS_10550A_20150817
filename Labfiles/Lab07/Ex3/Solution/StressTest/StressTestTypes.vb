''' <summary>
''' Enumeration of girder material types
''' </summary>
''' <remarks></remarks>
Public Enum Material
    StainlessSteel
    Aluminum
    ReinforcedConcrete
    Composite
    Titanium
End Enum

''' <summary>
''' Enumeration of girder cross-sections
''' </summary>
''' <remarks></remarks>
Public Enum CrossSection
    IBeam
    Box
    ZShaped
    CShaped
End Enum

''' <summary>
''' Enumeration of test results
''' </summary>
''' <remarks></remarks>
Public Enum TestResult
    Pass
    Fail
End Enum

''' <summary>
''' Structure containing test results
''' </summary>
''' <remarks></remarks>
Public Structure TestCaseResult
    ''' <summary>
    ''' Test result (enumeration type)
    ''' </summary>
    ''' <remarks></remarks>
    Public Result As TestResult

    ''' <summary>
    ''' Description of reason for failure
    ''' </summary>
    ''' <remarks></remarks>
    Public ReasonForFailure As String

    Public FailureData As Long
End Structure

''' <summary>
''' Defines details of a complete girder stress test
''' </summary>
''' <remarks></remarks>
Public Class StressTestCase
    ''' <summary>
    ''' Girder material type (enumeration type)
    ''' </summary>
    ''' <remarks></remarks>
    Private GirderMaterial As Material

    ''' <summary>
    ''' Girder cross-section (enumeration type)
    ''' </summary>
    ''' <remarks></remarks>
    Private XSection As CrossSection

    ''' <summary>
    ''' Girder length in millimeters
    ''' </summary>
    ''' <remarks></remarks>
    Private LengthInMm As Integer

    ''' <summary>
    ''' Girder height in millimeters
    ''' </summary>
    ''' <remarks></remarks>
    Private HeightInMm As Integer

    ''' <summary>
    ''' Girder width in millimeters
    ''' </summary>
    ''' <remarks></remarks>
    Private WidthInMm As Integer

    ''' <summary>
    ''' Details of test result (structure type)
    ''' </summary>
    ''' <remarks></remarks>
    Private Result? As TestCaseResult

    ' Exercise 2
    ''' <summary>
    ''' Track the number of tests and number of failures
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared statistics As TestStatistics

    ' Exercise 2
    ''' <summary>
    ''' Return the test statistics
    ''' </summary>
    ''' <returns>Test statistics</returns>
    ''' <remarks></remarks>
    Public Shared Function GetStatistics() As TestStatistics
        Return statistics
    End Function

    ''' <summary>
    ''' Reset the test statistics to zeros
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub ResetStatistics()
        statistics.ResetCounters()
    End Sub

    ''' <summary>
    ''' No argument constructor (invokes parameterised constructor passing default values)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Me.New(Material.StainlessSteel, CrossSection.IBeam, 4000, 20, 15)
    End Sub

    ''' <summary>
    ''' Constructor - initializes Result to null
    ''' </summary>
    ''' <param name="girderMaterial">Girder material type (enumeration type)</param>
    ''' <param name="xSection">Girder cross-secion type (enumeration type)</param>
    ''' <param name="lengthInMm">Girder length in millimeters</param>
    ''' <param name="heightInMm">Girder height in millimeters</param>
    ''' <param name="widthInMm">Girder width in millimeters</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal girderMaterial As Material, ByVal xSection As CrossSection, ByVal lengthInMm As Integer, ByVal heightInMm As Integer, ByVal widthInMm As Integer)
        Me.GirderMaterial = girderMaterial
        Me.XSection = xSection
        Me.LengthInMm = lengthInMm
        Me.HeightInMm = heightInMm
        Me.WidthInMm = widthInMm

        Me.Result = Nothing
    End Sub

    ''' <summary>
    ''' Execute a stress test and save the results in the testCaseResult field
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PerformStressTest()
        Dim tcr As New TestCaseResult()

        ' List of possible reasons for a failure
        Dim failureReasons() As String = {"Fracture detected", "Beam snapped", "Beam dimensions wrong", "Beam warped", "Other"}

        ' Fails 1 time in 10
        If Utility.Rand.Next(10) = 9 Then
            tcr.Result = TestResult.Fail
            tcr.ReasonForFailure = failureReasons(Utility.Rand.Next(5))

            tcr.FailureData = Utility.Rand.Next(Integer.MaxValue)

            ' Exercise 2
            statistics.IncrementTests(False)
        Else
            tcr.Result = TestResult.Pass

            ' Exercise 2
            statistics.IncrementTests(True)
        End If

        Result = tcr
    End Sub

    ''' <summary>
    ''' Return the results of the test
    ''' Needs a cast and could return null
    ''' </summary>
    ''' <returns>Results of test</returns>
    ''' <remarks></remarks>
    Public Function GetStressTestResult() As TestCaseResult?
        If Result.HasValue Then
            Return Result.Value
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Override of ToString
    ''' </summary>
    ''' <returns>Formatted string</returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Dim stressTestPerformed As String

        If Result.HasValue Then
            stressTestPerformed = "Stress Test Completed"
        Else
            stressTestPerformed = "No Stress Test Performed"
        End If

        Return String.Format("Material: {0}, CrossSection: {1}, Length: {2}mm, Height: {3}mm, Width: {4}mm, {5}",
            GirderMaterial.ToString(), XSection.ToString(), LengthInMm, HeightInMm, WidthInMm, stressTestPerformed)
    End Function
End Class

' Exercise 2 Structure

''' <summary>
''' Record number of tests performed and number of failures
''' </summary>
''' <remarks></remarks>
Public Structure TestStatistics
    Private numberOfTestsPerformed As Integer
    Private numberOfFailures As Integer

    ''' <summary>
    ''' Add a test
    ''' </summary>
    ''' <param name="success">Success or failure</param>
    ''' <remarks></remarks>
    Public Sub IncrementTests(ByVal success As Boolean)
        numberOfTestsPerformed += 1

        If Not success Then
            numberOfFailures += 1
        End If
    End Sub

    ''' <summary>
    ''' Get the number of tests that have beeen performed
    ''' </summary>
    ''' <returns>Number of tests</returns>
    ''' <remarks></remarks>
    Public Function GetNumberOfTestsPerformed() As Integer
        Return numberOfTestsPerformed
    End Function

    ''' <summary>
    ''' Get the number of failed tests
    ''' </summary>
    ''' <returns>Number of failed tests</returns>
    ''' <remarks></remarks>
    Public Function GetNumberOfFailures() As Integer
        Return numberOfFailures
    End Function

    ''' <summary>
    ''' Reset all counters to zero
    ''' (Visible only in this assembly)
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub ResetCounters()
        numberOfFailures = 0
        numberOfTestsPerformed = 0
    End Sub
End Structure
