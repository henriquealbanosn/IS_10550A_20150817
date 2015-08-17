Public Class StressTestTypes
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

    ' TODO: - Declare a structure
    ' Add the TestCaseResult structure
End Class
