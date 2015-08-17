Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MatrixMultiplication

'''<summary>
'''This is a test class for MatrixTest and is intended
'''to contain all MatrixTest Unit Tests
'''</summary>
<TestClass()>
Public Class MatrixTest
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

    '''<summary>
    '''A test for MatrixMultiply
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub MatrixMultiplyTest1()
        Dim matrix1(,) As Double = {{4, 6}, {2, 2}, {5, 1}}
        Dim matrix2(,) As Double = {{1, 5, 1}, {7, 3, 1}}
        Dim expected(,) As Double = {{19, 17}, {39, 49}}
        Dim actual(,) As Double
        actual = Matrix.MatrixMultiply(matrix1, matrix2)
        Assert.AreEqual(expected(0, 0), actual(0, 0), 0.000001)
        Assert.AreEqual(expected(0, 1), actual(0, 1), 0.000001)
        Assert.AreEqual(expected(1, 0), actual(1, 0), 0.000001)
        Assert.AreEqual(expected(1, 1), actual(1, 1), 0.000001)
    End Sub

    ''' <summary>
    '''A test for MatrixMultiply - checking for negative values
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    <ExpectedException(GetType(ArgumentException))>
    Public Sub MatrixMultiplyTest2()
        Dim matrix1(,) As Double = {{4, 6}, {2, 2}, {5, 1}}
        Dim matrix2(,) As Double = {{1, 5, 1}, {7, -3, 1}}
        Dim actual(,) As Double
        actual = Matrix.MatrixMultiply(matrix1, matrix2)
    End Sub

    ''' <summary>
    '''A test for MatrixMultiply - checking for incompatible matrices
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    <ExpectedException(GetType(ArgumentException))>
    Public Sub MatrixMultiplyTest3()
        Dim matrix1(,) As Double = {{4, 6}, {2, 2}, {5, 1}, {4, 4}}
        Dim matrix2(,) As Double = {{1, 5, 1}, {7, 3, 1}}
        Dim actual(,) As Double
        actual = Matrix.MatrixMultiply(matrix1, matrix2)
    End Sub
End Class
