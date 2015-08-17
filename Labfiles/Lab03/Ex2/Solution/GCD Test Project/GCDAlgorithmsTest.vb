Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports GreatestCommonDivisor



'''<summary>
'''This is a test class for GCDAlgorithmsTest and is intended
'''to contain all GCDAlgorithmsTest Unit Tests
'''</summary>
<TestClass()> _
Public Class GCDAlgorithmsTest


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
            testContextInstance = Value
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


    '''<summary>
    '''A test for FindGCDEuclid
    '''</summary>
    <TestMethod()> _
    Public Sub FindGCDEuclidTest()
        Dim a As Integer = 2806 ' TODO: Initialize to an appropriate value
        Dim b As Integer = 345 ' TODO: Initialize to an appropriate value
        Dim expected As Integer = 23 ' TODO: Initialize to an appropriate value
        Dim actual As Integer
        actual = GCDAlgorithms.FindGCDEuclid(a, b)
        Assert.AreEqual(expected, actual)
    End Sub

    <TestMethod()>
    Public Sub FindGCDEuclidTest1()
        Dim a As Integer = 7396
        Dim b As Integer = 1978
        Dim c As Integer = 1204
        Dim expected As Integer = 86
        Dim actual As Integer = GCDAlgorithms.FindGCDEuclid(a, b, c)
        Assert.AreEqual(expected, actual)
    End Sub

    <TestMethod()>
    Public Sub FindGCDEuclidTest2()
        Dim a As Integer = 7396
        Dim b As Integer = 1978
        Dim c As Integer = 1204
        Dim d As Integer = 430
        Dim expected As Integer = 86
        Dim actual As Integer = GCDAlgorithms.FindGCDEuclid(a, b, c, d)
        Assert.AreEqual(expected, actual)
    End Sub

    <TestMethod()>
    Public Sub FindGCDEuclidTest3()
        Dim a As Integer = 7396
        Dim b As Integer = 1978
        Dim c As Integer = 1204
        Dim d As Integer = 430
        Dim e As Integer = 258
        Dim expected As Integer = 86
        Dim actual As Integer = GCDAlgorithms.FindGCDEuclid(a, b, c, d, e)
        Assert.AreEqual(expected, actual)
    End Sub
End Class
