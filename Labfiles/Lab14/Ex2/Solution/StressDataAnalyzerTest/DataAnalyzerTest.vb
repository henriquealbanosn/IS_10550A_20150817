Imports System
Imports System.Collections.Generic
Imports StressTestResult
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports StressDataAnalyzer

'''<summary>
'''This is a test class for DataAnalyzerTest and is intended
'''to contain all DataAnalyzerTest Unit Tests
'''</summary>
<TestClass()> _
Public Class DataAnalyzerTest
    Private testContextInstance As TestContext

    Private testQueryCriteria(,) As Object = {{DateTime.MinValue, DateTime.MaxValue, CType(100, Short), CType(500, Short), CType(10, Short), CType(5000, Short), CType(0, Short), CType(1500, Short), 41073, 1065864},
                                   {New DateTime(2009, 11, 1), New DateTime(2010, 2, 1), CType(280, Short), CType(400, Short), CType(10, Short), CType(1000, Short), CType(200, Short), CType(750, Short), 1180, 30252},
                                   {New DateTime(2009, 8, 1), New DateTime(2010, 3, 31), CType(320, Short), CType(320, Short), CType(10, Short), CType(5000, Short), CType(0, Short), CType(1500, Short), 785, 20377},
                                   {New DateTime(2009, 8, 1), New DateTime(2010, 3, 31), CType(500, Short), CType(500, Short), CType(10, Short), CType(5000, Short), CType(0, Short), CType(1500, Short), 829, 21513},
                                   {New DateTime(2010, 6, 1), New DateTime(2010, 6, 30), CType(200, Short), CType(500, Short), CType(10, Short), CType(5000, Short), CType(0, Short), CType(1500, Short), 0, 99}
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
    '''A test for FormatResults
    '''</summary>
    <TestMethod(), _
     DeploymentItem("StressDataAnalyzer.exe")> _
    Public Sub CreateQueryandFormatResultsTest()
        Dim target As DataAnalyzer_Accessor
        target.ReadTestData()

        For testCount As Integer = 0 To testQueryCriteria.GetLength(0) - 1
            Dim dateRangeSpecified As Boolean = CType(testQueryCriteria(testCount, 0), Boolean)
            Dim dateStart As DateTime = CType(testQueryCriteria(testCount, 0), DateTime)
            Dim dateEnd As DateTime = CType(testQueryCriteria(testCount, 1), DateTime)

            If dateEnd < DateTime.MaxValue Then
                dateEnd = dateEnd.AddDays(1)
            End If

            Dim temperatureRangeSpecified As Boolean = CType(testQueryCriteria(testCount, 3), Boolean)
            Dim temperatureStart As Short = CType(testQueryCriteria(testCount, 2), Short)
            Dim temperatureEnd As Short = CType(testQueryCriteria(testCount, 3), Short)
            Dim stressRangeSpecified As Boolean = CType(testQueryCriteria(testCount, 6), Boolean)
            Dim appliedStressStart As Short = CType(testQueryCriteria(testCount, 4), Short)
            Dim appliedStressEnd As Short = CType(testQueryCriteria(testCount, 5), Short)
            Dim deflectionRangeSpecified As Boolean = CType(testQueryCriteria(testCount, 9), Boolean)
            Dim deflectionStart As Short = CType(testQueryCriteria(testCount, 6), Short)
            Dim deflectionEnd As Short = CType(testQueryCriteria(testCount, 7), Short)
            Dim expectedCount As Integer = CType(testQueryCriteria(testCount, 8), Integer)

            Dim orderby As OrderByKey_Accessor = New OrderByKey_Accessor()
            orderby.value__ = 0
            Dim limitRows As Boolean = False
            Dim rowCount As Integer = 0

            Dim actual As IEnumerable(Of TestResult) = target.CreateQuery(dateRangeSpecified, dateStart, dateEnd,
                    temperatureRangeSpecified, temperatureStart, temperatureEnd,
                    stressRangeSpecified, appliedStressStart, appliedStressEnd,
                    deflectionRangeSpecified, deflectionStart, deflectionEnd,
                    orderby, limitRows, rowCount)
            Dim actualCount As Integer = actual.Count()
            Assert.AreEqual(expectedCount, actualCount)

            Dim actualFormattedResults As String = target.FormatResults(actual)
            Dim actualFormattedResultsLength As Integer = actualFormattedResults.Length
            Dim expectedFormattedResultsLength As Integer = CType(testQueryCriteria(testCount, 13), Integer)
            Assert.AreEqual(expectedFormattedResultsLength, actualFormattedResultsLength)
        Next
    End Sub
End Class
