Imports System.Windows
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports DynamicLanguageInterop

'''<summary>
'''This is a test class for InteropTestWindowTest and is intended
'''to contain all InteropTestWindowTest Unit Tests
'''</summary>
<TestClass()>
Public Class InteropTestWindowTest
    Private testContextInstance As TestContext

    Private stringTestData() As String = {"the", "cat", "sat", "on", "the", "mat", "the", "dog", "had", "a", "bone"}
    Private intTestData() As Integer = {1, 3, 5, 7, 9, 11, 10, 8, 6, 4, 2, 0, 1, 3, 5, 7, 9, 11}

    Private badTrapezoidTestData(,) As Object = {{0, 0, 0, 0, "Length of SideAB must be greater than zero"},
                                           {90, 15, 10, 20, "VertexA must be less than 90 degrees"},
                                           {45, 10, 20, 1, "SideAB must not be shorter than SideCD"},
                                           {45, 50, 40, 50, "Height and length of SideCD are too big compared to SideAB"}
                                      }

    Dim goodTrapezoidTestData(,) As Integer = {{45, 200, 100, 10, 1500},
                                     {89, 200, 150, 200, 35000},
                                     {45, 100, 2, 90, 4590},
                                     {10, 200, 90, 2, 290}
                                              }
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
    '''A test for ShuffleData
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    <DeploymentItem("DynamicLanguageInterop.exe")>
    Public Sub ShuffleDataTest()
        Dim target As New InteropTestWindow_Accessor()

        ' Do string tests first
        Dim data() As String
        ReDim data(stringTestData.Length)

        stringTestData.CopyTo(data, 0)
        target.ShuffleData(data)

        ' Check that the array still has the same number of elements after shuffling
        Assert.AreEqual(stringTestData.Length, data.Length)

        ' Verify that each word occurs the correct number of times
        Dim searchData() As String = Nothing
        Dim searchStringTestData() As String = Nothing

        For Each word As String In stringTestData
            searchData = Array.FindAll(CType(data, String()), Function(s) s = word)
            searchStringTestData = Array.FindAll(CType(stringTestData, String()), Function(s) s = word)
            Assert.AreEqual(searchData.Length, searchStringTestData.Length)
        Next

        ' Do integer tests
        Dim intData() As Object
        ReDim intData(intTestData.Length)

        intTestData.CopyTo(intData, 0)
        target.ShuffleData(intData)

        ' Check that the array still has the same number of elements after shuffling
        Assert.AreEqual(intTestData.Length, intData.Length)

        ' Verify that each word occurs the correct number of times
        Dim searchIntData() As Object = Nothing
        Dim searchIntTestData() As Integer = Nothing

        For Each number As Integer In intTestData
            searchIntData = Array.FindAll(intData, Function(i) CType(i, Integer) = number)
            searchIntTestData = Array.FindAll(CType(intTestData, Integer()), Function(i) i = number)
            Assert.AreEqual(searchIntData.Length, searchIntTestData.Length)
        Next
    End Sub

    ''' <summary>
    '''A test for CreateTrapezoid
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    <DeploymentItem("DynamicLanguageInterop.exe")>
    Public Sub CreateTrapezoidTest()
        Dim target As New InteropTestWindow_Accessor()

        ' Tests that should not create a trapezoid successfully
        For testCount As Integer = 0 To badTrapezoidTestData.GetLength(0) - 1
            Dim vertexAInDegrees As Integer = CType(badTrapezoidTestData(testCount, 0), Integer)
            Dim lengthSideAB As Integer = CType(badTrapezoidTestData(testCount, 1), Integer)
            Dim lengthSideCD As Integer = CType(badTrapezoidTestData(testCount, 2), Integer)
            Dim heightOfTrapezoid As Integer = CType(badTrapezoidTestData(testCount, 3), Integer)
            Dim actual = Nothing

            Try
                actual = target.CreateTrapezoid(vertexAInDegrees, lengthSideAB, lengthSideCD, heightOfTrapezoid)
            Catch ex As Exception
                ' Verify that the correct exception was raised
                Assert.AreEqual(ex.Message, badTrapezoidTestData(testCount, 4))
            End Try

            ' Verify that the trapezoid was not created
            Assert.IsNull(actual)
        Next

        ' Tests that should successfully create a trapezoid
        For testCount As Integer = 0 To goodTrapezoidTestData.GetLength(0) - 1
            Dim vertexAInDegrees As Integer = CType(goodTrapezoidTestData(testCount, 0), Integer)
            Dim lengthSideAB As Integer = CType(goodTrapezoidTestData(testCount, 1), Integer)
            Dim lengthSideCD As Integer = CType(goodTrapezoidTestData(testCount, 2), Integer)
            Dim heightOfTrapezoid As Integer = CType(goodTrapezoidTestData(testCount, 3), Integer)
            Dim actual = Nothing
            actual = target.CreateTrapezoid(vertexAInDegrees, lengthSideAB, lengthSideCD, heightOfTrapezoid)

            ' Verify that the trapezoid was created successfully
            Assert.IsNotNull(actual)

            ' Verify that the trapezoid has the expected area
            Assert.AreEqual(actual.area(), goodTrapezoidTestData(testCount, 4))
        Next
    End Sub
End Class
