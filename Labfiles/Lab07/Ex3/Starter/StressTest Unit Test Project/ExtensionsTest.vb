Imports System.Text
Imports StressTest

''' <summary>
''' This is a test class for ExtensionsTest and is intended
''' to contain all StressTestCase_TestStatisticsTest Unit Tests
''' </summary>
''' <remarks></remarks>
<TestClass()>
Public Class ExtensionsTest
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

    ' TODO: - Review and run unit tests
    ''' <summary>
    '''A test for ToBinaryString
    '''</summary>
    <TestMethod()>
    Public Sub ToBinaryStringTest()
        Dim i As Long = 8
        Dim expected As String = "1000"
        Dim actual As String
        actual = i.ToBinaryString()
        Assert.AreEqual(expected, actual)
        i = 10266
        expected = "10100000011010"
        actual = Extensions.ToBinaryString(i)
        Assert.AreEqual(expected, actual)
    End Sub
End Class
