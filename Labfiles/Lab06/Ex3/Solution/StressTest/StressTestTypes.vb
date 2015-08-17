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
    Public GirderMaterial As Material
    Public XSection As CrossSection
    Public LengthInMm As Integer
    Public HeightInMm As Integer
    Public WidthInMm As Integer
    Public Result As TestCaseResult

    Public Sub New()
        Me.New(Material.StainlessSteel, CrossSection.IBeam, 4000, 20, 15)
    End Sub

    Public Sub New(ByVal girderMaterial As Material, ByVal xSection As CrossSection, ByVal lengthInMm As Integer, ByVal heightInMm As Integer, ByVal widthInMm As Integer)
        Me.GirderMaterial = girderMaterial
        Me.XSection = xSection
        Me.LengthInMm = lengthInMm
        Me.HeightInMm = heightInMm
        Me.WidthInMm = widthInMm
    End Sub

    Public Sub PerformStressTest()
        Dim failureReasons() As String =
        {
            "Fracture detected",
            "Beam snapped",
            "Beam dimensions wrong",
            "Beam warped",
            "Other"
        }

        If Utility.Rand.Next(10) = 9 Then
            Result.Result = TestResult.Fail
            Dim failureCode As Integer = Utility.Rand.Next(5)
            Result.ReasonForFailure = failureReasons(failureCode)
        Else
            Result.Result = TestResult.Pass
        End If
    End Sub

    Public Function GetStressTestResult() As TestCaseResult
        Return Result
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("Material: {0}, CrossSection: {1}, Length: {2}mm, Height: {3}mm, Width: {4}mm",
            GirderMaterial.ToString(), XSection.ToString(),
            LengthInMm, HeightInMm, WidthInMm)
    End Function

End Class
