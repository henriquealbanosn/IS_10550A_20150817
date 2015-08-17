Imports System.Text
Imports StressTest

''' <summary>
''' This is a test class for StressTestCase_TestStatisticsTest and is intended
''' to contain all StressTestCase_TestStatisticsTest Unit Tests
''' </summary>
''' <remarks></remarks>
<TestClass()>
Public Class StressTestCase_TestStatisticsTest
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
    '''A test for GetNumberOfFailures
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub GetNumberOfFailuresTest()
        Dim target = New TestStatistics()
        target.IncrementTests(False)
        target.IncrementTests(False)
        Dim expected As Integer = 2
        Dim actual As Integer
        actual = target.GetNumberOfFailures()
        Assert.AreEqual(expected, actual)
    End Sub

    ''' <summary>
    '''A test for GetNumberOfTestsPerformed
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub GetNumberOfTestsPerformedTest()
        Dim target As New TestStatistics()
        target.IncrementTests(True)
        target.IncrementTests(False)
        target.IncrementTests(True)
        Dim expected As Integer = 3
        Dim actual As Integer
        actual = target.GetNumberOfTestsPerformed()
        Assert.AreEqual(expected, actual)
    End Sub

    ''' <summary>
    '''A test for IncrementTests
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub IncrementTestsTest()
        Dim target As New TestStatistics()
        target.IncrementTests(True)
        target.IncrementTests(False)
        target.IncrementTests(True)
        target.IncrementTests(True)
        Dim expected As Integer = 4
        Dim actual As Integer
        actual = target.GetNumberOfTestsPerformed()
        Assert.AreEqual(expected, actual)
    End Sub
End Class
