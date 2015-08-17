Imports System.Text
Imports System.IO
Imports FileEditor

''' <summary>
''' This is a test class for TextFileOperationsTest and is intended
''' to contain all TextFileOperationsTest Unit Tests
''' </summary>
''' <remarks></remarks>
<TestClass()>
Public Class TextFileOperationsTest
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

    ' TODO: - Complete Unit Tests

    ''' <summary>
    '''A test for ReadTextFileContents
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub ReadTextFileContentsTest1()
        Dim fileName As String = "..\..\..\CommandsTest.txt"
        Dim expected As String = "Move(9.23,78)" & vbNewLine & "Rotate(65.3)" & vbNewLine & "Wait(10)" & vbNewLine & "Move(1,1)" & vbNewLine
        Dim actual As String = Nothing
        'actual = FileEditor.TextFileOperations.ReadTextFileContents(fileName)
        Assert.AreEqual(expected, actual)
    End Sub

    ''' <summary>
    '''A test for WriteTextFileContents
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub WriteTextFileContentsTest1()
        Dim fileName As String = "..\..\..\WriteTest.txt"
        Dim text As String = "This is a test file\r\nWith some simple content\r\n"
        'FileEditor.TextFileOperations.WriteTextFileContents(fileName, text)
        Dim expected As String = File.ReadAllText(fileName)
        Assert.AreEqual(expected, text)
        File.Delete(fileName)
    End Sub
End Class
