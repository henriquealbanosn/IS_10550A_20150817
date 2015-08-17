Imports StressTest.StressTestTypes

Public Class TestManager
    Public Shared Function GenerateResult() As TestCaseResult
        Dim resultCode As Integer

        Dim result As New TestCaseResult()

        resultCode = Utility.Rand.Next(10)
        If resultCode < 8 Then
            result.Result = TestResult.Pass
        Else
            result.Result = TestResult.Fail

            If resultCode = 8 Then
                result.ReasonForFailure = "Beam Snapped"
            Else
                result.ReasonForFailure = "Fractures Detected"
            End If
        End If

        Return result
    End Function
End Class
