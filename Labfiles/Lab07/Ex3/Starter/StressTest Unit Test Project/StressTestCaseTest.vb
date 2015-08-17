Imports System.Text
Imports StressTest

''' <summary>
''' This is a test class for StressTestCaseTest and is intended
''' to contain all StressTestCaseTest Unit Tests
''' </summary>
''' <remarks></remarks>
<TestClass()>
Public Class StressTestCaseTest
    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = value
        End Set
    End Property

#Region "Additional test attributes"
    '
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region

    ''' <summary>
    '''A test for PerformStressTest
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub PerformStressTestTest()
        Dim target As New StressTestCase()
        target.PerformStressTest()
        Dim tcr As TestCaseResult = CType(target.GetStressTestResult(), TestCaseResult)
        Assert.IsNotNull(tcr)
    End Sub

    ''' <summary>
    '''A test for ToString
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub ToStringTest()
        Dim expected As String = "Material: StainlessSteel, CrossSection: IBeam, Length: 4000mm, Height: 20mm, Width: 15mm, No Stress Test Performed"
        Dim actual As String
        Dim target As New StressTestCase()
        actual = target.ToString()
        Assert.AreEqual(expected, actual)
    End Sub

    ''' <summary>
    '''A test for GetStressTestResult
    '''</summary>
    <TestMethod()>
    Public Sub GetStressTestResultTest1()
        Dim target As New StressTestCase()
        Dim actual As Object
        actual = target.GetStressTestResult()
        Assert.IsNull(actual)
    End Sub

    ''' <summary>
    '''A test for GetStressTestResult when a test has been performed
    '''</summary>
    <TestMethod()>
    Public Sub GetStressTestResultTest2()
        Dim target As New StressTestCase()
        Dim actual As TestCaseResult
        target.PerformStressTest()
        actual = CType(target.GetStressTestResult(), TestCaseResult)
        Assert.IsNotNull(actual)
    End Sub

    ''' <summary>
    '''A test for GetStatistics
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub GetStatisticsTest()
        Dim stc As New StressTestCase()
        StressTestCase.ResetStatistics()
        ' Perform 2 tests
        stc.PerformStressTest()
        stc.PerformStressTest()
        Dim actual As Integer = StressTestCase.GetStatistics().GetNumberOfTestsPerformed()
        Assert.AreEqual(2, actual)
    End Sub

    ''' <summary>
    '''A test for GetStatistics
    '''Demonstrate use of value type for statistics
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub GetStatisticsTest2()
        Dim stc As New StressTestCase()
        StressTestCase.ResetStatistics()
        stc.PerformStressTest()
        stc.PerformStressTest()
        Dim copy As TestStatistics = StressTestCase.GetStatistics()
        copy.IncrementTests(True)
        Dim actual As Integer = StressTestCase.GetStatistics().GetNumberOfTestsPerformed()

        Assert.AreEqual(2, actual)
    End Sub

    ''' <summary>
    '''A test for StressTestCase parameterized Constructor
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub StressTestCaseConstructorTest()
        Dim girderMaterial As Material = Material.Composite
        Dim xSection As CrossSection = CrossSection.CShaped
        Dim lengthInMm As Integer = 5000
        Dim heightInMm As Integer = 32
        Dim widthInMm As Integer = 18
        Dim expected As String = "Material: Composite, CrossSection: CShaped, Length: 5000mm, Height: 32mm, Width: 18mm, No Stress Test Performed"
        Dim actual As String
        Dim target As New StressTestCase(girderMaterial, xSection, lengthInMm, heightInMm, widthInMm)
        actual = target.ToString()
        Assert.AreEqual(expected, actual)
    End Sub

    ''' <summary>
    '''A test for StressTestCase default Constructor
    '''</summary>
    <TestMethod()>
    Public Sub StressTestCaseConstructorTest1()
        Dim expected As String = "Material: StainlessSteel, CrossSection: IBeam, Length: 4000mm, Height: 20mm, Width: 15mm, No Stress Test Performed"
        Dim actual As String
        Dim target As New StressTestCase()
        actual = target.ToString()
        Assert.AreEqual(expected, actual)
    End Sub
End Class
