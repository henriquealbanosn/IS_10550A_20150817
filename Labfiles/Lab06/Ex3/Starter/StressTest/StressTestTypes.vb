
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

' TODO: - Add the StressTestCase class