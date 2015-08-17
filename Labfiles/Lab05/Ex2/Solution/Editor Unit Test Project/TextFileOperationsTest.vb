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

    ''' <summary>
    '''A test for ReadTextFileContents
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub ReadAndFilterTextFileContentsTest()
        Dim fileName As String = "..\..\..\CommandsTest.txt"
        Dim expected As String = "Move x, 10" & vbNewLine & "Move y, 20" & vbNewLine & "If x &lt; y Add x, y" & vbNewLine & "If x &gt; y &amp; x &lt; 20 Sub X, Y" & vbNewLine & "Store 30" & vbNewLine

        Dim actual As String = Nothing
        actual = FileEditor.TextFileOperations.ReadAndFilterTextFileContents(fileName)
        Assert.AreEqual(expected, actual)
    End Sub

    ''' <summary>
    '''A test for WriteTextFileContents
    '''</summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub WriteTextFileContentsTest1()
        Dim fileName As String = "..\..\..\WriteTest.txt"
        Dim text As String = "This is a test file" & vbNewLine & "With some simple content" & vbNewLine
        FileEditor.TextFileOperations.WriteTextFileContents(fileName, text)
        Dim expected As String = File.ReadAllText(fileName)
        Assert.AreEqual(expected, text)
        File.Delete(fileName)
    End Sub
End Class
