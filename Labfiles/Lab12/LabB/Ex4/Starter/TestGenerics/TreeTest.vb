Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports BinaryTree



'''<summary>
'''This is a test class for TreeTest and is intended
'''to contain all TreeTest Unit Tests
'''</summary>
<TestClass()> _
Public Class TreeTest


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
    '''A test for Tree`1 Constructor
    '''</summary>
    Public Sub TreeConstructorTestHelper(Of TItem As IComparable)(ByVal nodeValue As TItem)
        Dim target As Tree(Of TItem) = New Tree(Of TItem)(nodeValue)
        Assert.AreEqual(target.NodeData, nodeValue)
    End Sub

    <TestMethod()> _
    Public Sub TreeConstructorTest()
        TreeConstructorTestHelper(Of Integer)(4)
    End Sub

    '''<summary>
    '''A test for Add
    '''</summary>
    Public Sub AddTestHelper(Of TItem As IComparable)(ByVal nodeValue As TItem, ByVal newItem As TItem)
        Dim target As New Tree(Of TItem)(nodeValue)
        target.Add(newItem)
        Assert.IsNotNull(target.RightTree)
    End Sub

    <TestMethod()> _
    Public Sub AddTest()
        AddTestHelper(Of Integer)(3, 4)
    End Sub

    <TestMethod()> _
    Public Sub RemoveTest()
        Dim tree As New Tree(Of Integer)(5)
        tree.Add(4)
        tree.Add(6)
        tree.Add(7)
        tree.Add(9)
        tree.Add(8)
        tree.Add(10)
        tree.Add(4)
        tree.Add(1)
        tree.Add(3)
        tree.Add(9)
        tree.Add(15)
        tree.Remove(6)
        tree.Remove(8)
        tree.Remove(4)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    <TestMethod()> _
    Public Sub WalkTreeTest()
        Dim target As New Tree(Of Integer)(4)
        target.Add(1)
        target.Add(3)
        target.WalkTree()
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for NodeData
    '''</summary>
    Public Sub NodeDataTestHelper(Of TItem As IComparable)(ByVal nodeValue As TItem)
        Dim target As Tree(Of TItem) = New Tree(Of TItem)(nodeValue)
        Dim expected As TItem = nodeValue
        Dim actual As TItem = target.NodeData
        Assert.AreEqual(expected, actual)
    End Sub

    <TestMethod()> _
    Public Sub NodeDataTest()
        NodeDataTestHelper(Of Integer)(5)
    End Sub

    <TestMethod()> _
    Public Sub BuildTreeTest()
        Dim testTree As Tree(Of Integer) = Tree(Of Integer).BuildTree(Of Integer)(4, {4, 6, 7, 9, 1, 6, 10})
        Assert.IsNotNull(testTree)
    End Sub
End Class
