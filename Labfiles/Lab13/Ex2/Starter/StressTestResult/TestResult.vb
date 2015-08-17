''' <summary>
''' Structure that models the result of a stress test for girders.
''' <para>
''' A stress test contains the following information:
''' <list type="bullet">
''' <item>
''' TestDate: The date and time that the test was conducted.
''' </item>
''' <item>
''' Temperature: The temperature, in K, at which the test was performed.
''' </item>
''' <item>
''' AppliedStress: The stress, in kN, applied to the girder.
''' </item>
''' <item>
''' Deflection: The resulting deflection, in mm, of the mid-point of the girder.
''' </item>
''' </list>
''' </para>
''' </summary>
<Serializable()>
Public Structure TestResult
    Implements IComparable(Of TestResult), IComparable

    ''' <summary>
    ''' Compare stress test results based on the recorded deflection.
    ''' </summary>
    ''' <param name="other">
    ''' The stress test result to compare against.
    ''' </param>
    ''' <returns>
    ''' <list type="bullet">
    ''' <item>
    ''' If Me.Deflection &lt; other.Deflection, then -1.
    ''' </item>
    ''' <item>
    ''' If Me.Deflection = other.Deflection, then 0.
    ''' </item>
    ''' <item>
    ''' If Me.Deflection > other.Deflection, then 1.
    ''' </item>
    ''' </list>
    ''' </returns>
    Public Function CompareTo(ByVal other As TestResult) As Integer Implements IComparable(Of StressTestResult.TestResult).CompareTo
        Dim result As Integer = 0

        If Me.Deflection < other.Deflection Then
            result = -1
        End If

        If Me.Deflection = other.Deflection Then
            result = 0
        End If

        If Me.Deflection > other.Deflection Then
            result = 1
        End If

        Return result
    End Function

    ''' <summary>
    ''' The date and time that the test was conducted.
    ''' </summary>
    ''' <remarks></remarks>
    Public Property TestDate As DateTime

    ''' <summary>
    ''' The temperature, in K, at which the stress test was performed.
    ''' <para>
    ''' This value cannot be negative.
    ''' </para>
    ''' </summary>
    ''' <remarks></remarks>
    Private temp As Short
    Public Property Temperature As Short
        Get
            Return Me.temp
        End Get
        Set(ByVal value As Short)
            If value < 0 Then
                Throw New ArgumentOutOfRangeException("Temperature cannot be less than zero")
            Else
                Me.temp = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' The stress applied to the girder, in kN.
    ''' <para>
    ''' This value cannot be negative.
    ''' </para>
    ''' </summary>
    ''' <remarks></remarks>
    Private appStress As Short
    Public Property AppliedStress As Short
        Get
            Return Me.appStress
        End Get
        Set(ByVal value As Short)
            If value < 0 Then
                Throw New ArgumentOutOfRangeException("Applied stress cannot be less than zero")
            Else
                Me.appStress = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' The resulting deflection of the girder, in mm.
    ''' <para>
    ''' This value cannot be negative.
    ''' </para>
    ''' </summary>
    ''' <remarks></remarks>
    Private deflect As Short
    Public Property Deflection As Short
        Get
            Return Me.deflect
        End Get
        Set(ByVal value As Short)
            If value < 0 Then
                Throw New ArgumentOutOfRangeException("Deflection cannot be less than zero")
            Else
                Me.deflect = value
            End If
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim s As String = String.Format("Deflection: {0}, AppliedStress: {1}, Temperature: {2}, Date: {3}", Deflection, AppliedStress, Temperature, TestDate.ToShortDateString())

        Return s
    End Function

    ''' <summary>
    ''' Dummy function to make the project compile
    ''' </summary>
    ''' <param name="other"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CompareTo1(ByVal other As Object) As Integer Implements System.IComparable.CompareTo
        'CompareTo(CType(other, TestResult))
        Dim result As Integer = 0

        If Me.Deflection < other.Deflection Then
            result = -1
        End If

        If Me.Deflection = other.Deflection Then
            result = 0
        End If

        If Me.Deflection > other.Deflection Then
            result = 1
        End If

        Return result
    End Function
End Structure