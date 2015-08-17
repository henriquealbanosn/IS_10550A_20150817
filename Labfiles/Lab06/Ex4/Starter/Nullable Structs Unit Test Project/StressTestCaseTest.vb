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
        Dim target As New StressTestCase(girderMaterial, xSection, lengthInMm, heightInMm, widthInMm)
        Assert.AreEqual(Material.Composite, target.GirderMaterial)
        Assert.AreEqual(CrossSection.CShaped, target.XSection)
        Assert.AreEqual(5000, target.LengthInMm)
        Assert.AreEqual(32, target.HeightInMm)
        Assert.AreEqual(18, target.WidthInMm)
    End Sub

    ' TODO: - Examine and run unit tests updated to deal with nullable type

    ''' <summary>
    '''A test for StressTestCase default Constructor
    '''</summary>
    <TestMethod()>
    Public Sub StressTestCaseConstructorTest1()
        Dim target As New StressTestCase()
        Assert.AreEqual(Material.StainlessSteel, target.GirderMaterial)
        Assert.AreEqual(CrossSection.IBeam, target.XSection)
        Assert.AreEqual(4000, target.LengthInMm)
        Assert.AreEqual(20, target.HeightInMm)
        Assert.AreEqual(15, target.WidthInMm)
    End Sub

    ''' <summary>
    '''A test for GetStressTestResult
    '''</summary>
    <TestMethod()>
    Public Sub GetStressTestResultTest()
        Dim target As New StressTestCase()
        Assert.IsFalse(target.GetStressTestResult().HasValue)
        target.PerformStressTest()
        Assert.IsTrue(target.GetStressTestResult().HasValue)
    End Sub

    ''' <summary>
    '''A test for PerformStressTest
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub PerformStressTestTest()
        For i As Integer = 0 To 29
            Dim target As New StressTestCase()
            target.PerformStressTest()

            Dim actual As TestCaseResult? = target.GetStressTestResult()
            Assert.IsTrue(actual.HasValue)

            If actual.Value.Result = TestResult.Fail Then
                Assert.IsTrue(actual.Value.ReasonForFailure.Length > 0)
            Else
                Assert.IsTrue(actual.Value.ReasonForFailure Is Nothing)
            End If
        Next
    End Sub

    ''' <summary>
    '''A test for ToString
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub ToStringTest()
        Dim target As New StressTestCase()
        Dim expected As String = "Material: StainlessSteel, CrossSection: IBeam, Length: 4000mm, Height: 20mm, Width: 15mm"
        Dim actual As String
        actual = target.ToString()
        Assert.AreEqual(expected, actual)
    End Sub
End Class
