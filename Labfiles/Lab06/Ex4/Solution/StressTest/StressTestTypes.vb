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

Public Structure TestCaseResult
    Public Result As TestResult

    Public ReasonForFailure As String
End Structure

Public Class StressTestCase
    ''' <summary>
    ''' Girder material type (enumeration type)
    ''' </summary>
    ''' <remarks></remarks>

    Public GirderMaterial As Material
    ''' <summary>
    ''' Girder cross-section (enumeration type)
    ''' </summary>
    ''' <remarks></remarks>

    Public XSection As CrossSection
    ''' <summary>
    ''' Girder length in millimeters
    ''' </summary>
    ''' <remarks></remarks>
    Public LengthInMm As Integer

    ''' <summary>
    ''' Girder height in millimeters
    ''' </summary>
    ''' <remarks></remarks>
    Public HeightInMm As Integer

    ''' <summary>
    ''' Girder width in millimeters
    ''' </summary>
    ''' <remarks></remarks>
    Public WidthInMm As Integer

    ''' <summary>
    ''' Details of test result (structure type)
    ''' </summary>
    ''' <remarks></remarks>
    Public Result? As TestCaseResult

    ''' <summary>
    ''' No argument constructor (invokes parameterised constructor passing default values)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Me.New(Material.StainlessSteel, CrossSection.IBeam, 4000, 20, 15)
    End Sub

    ''' <summary>
    ''' Constructor
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
        Dim currentTestCase As New TestCaseResult()

        ' List of possible reasons for a failure
        Dim failureReasons() As String = {"Fracture detected", "Beam snapped", "Beam dimensions wrong", "Beam warped", "Other"}

        ' Fails 1 time in 10
        If Utility.Rand.Next(10) = 9 Then
            currentTestCase.Result = TestResult.Fail
            Dim failureCode As Integer = Utility.Rand.Next(5)
            currentTestCase.ReasonForFailure = failureReasons(failureCode)
            Result = currentTestCase
        Else
            currentTestCase.Result = TestResult.Pass
            Result = currentTestCase
        End If
    End Sub

    ''' <summary>
    ''' Return the results of the test
    ''' </summary>
    ''' <returns>Results of test</returns>
    ''' <remarks></remarks>
    Public Function GetStressTestResult() As TestCaseResult?
        Return Result
    End Function

    ''' <summary>
    ''' Override of ToString
    ''' </summary>
    ''' <returns>Formatted string</returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Return String.Format("Material: {0}, CrossSection: {1}, Length: {2}mm, Height: {3}mm, Width: {4}mm",
            GirderMaterial.ToString(), XSection.ToString(), LengthInMm, HeightInMm, WidthInMm)
    End Function

End Class
