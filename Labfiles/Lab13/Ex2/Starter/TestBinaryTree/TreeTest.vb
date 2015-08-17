Imports System.Collections
Imports System.Collections.Generic
Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BinaryTree
Imports StressTestResult

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



    ''' <summary>
    ''' Creates a tree of TestResults (Deflection value shown in diagram).
    '''             190
    '''         /        \
    '''     114             266
    '''    /   \           /   \
    '''   0    114       190   342
    '''     \                  /
    '''     76               304
    '''     /
    '''    38
    ''' </summary>
    ''' <returns>Tree of TestResults.</returns>
    Private Shared Function CreateATreeOfTestResults() As Tree(Of TestResult)
        Dim resultTree As New Tree(Of TestResult)(New TestResult() With {.Deflection = 190, .AppliedStress = 60, .Temperature = 200, .TestDate = DateTime.Now})
        resultTree.Add(New TestResult() With {.Deflection = 114, .AppliedStress = 40, .Temperature = 200, .TestDate = DateTime.Now})
        resultTree.Add(New TestResult() With {.Deflection = 266, .AppliedStress = 80, .Temperature = 200, .TestDate = DateTime.Now})
        resultTree.Add(New TestResult() With {.Deflection = 114, .AppliedStress = 50, .Temperature = 200, .TestDate = DateTime.Now})
        resultTree.Add(New TestResult() With {.Deflection = 0, .AppliedStress = 10, .Temperature = 200, .TestDate = DateTime.Now})
        resultTree.Add(New TestResult() With {.Deflection = 342, .AppliedStress = 100, .Temperature = 200, .TestDate = DateTime.Now})
        resultTree.Add(New TestResult() With {.Deflection = 76, .AppliedStress = 30, .Temperature = 200, .TestDate = DateTime.Now})
        resultTree.Add(New TestResult() With {.Deflection = 304, .AppliedStress = 90, .Temperature = 200, .TestDate = DateTime.Now})
        resultTree.Add(New TestResult() With {.Deflection = 38, .AppliedStress = 20, .Temperature = 200, .TestDate = DateTime.Now})
        resultTree.Add(New TestResult() With {.Deflection = 190, .AppliedStress = 70, .Temperature = 200, .TestDate = DateTime.Now})

        Return resultTree
    End Function

    ' TestResult objects
    Private deflection0 As New TestResult() With {.Deflection = 0, .AppliedStress = 10, .Temperature = 200, .TestDate = DateTime.Now}
    Private deflection38 As New TestResult() With {.Deflection = 38, .AppliedStress = 20, .Temperature = 200, .TestDate = DateTime.Now}
    Private deflection76 As New TestResult() With {.Deflection = 76, .AppliedStress = 30, .Temperature = 200, .TestDate = DateTime.Now}
    Private deflection114a As New TestResult() With {.Deflection = 114, .AppliedStress = 40, .Temperature = 200, .TestDate = DateTime.Now}
    Private deflection114b As New TestResult() With {.Deflection = 114, .AppliedStress = 50, .Temperature = 200, .TestDate = DateTime.Now}
    Private deflection190a As New TestResult() With {.Deflection = 190, .AppliedStress = 60, .Temperature = 200, .TestDate = DateTime.Now}
    Private deflection190b As New TestResult() With {.Deflection = 190, .AppliedStress = 70, .Temperature = 200, .TestDate = DateTime.Now}
    Private deflection266 As New TestResult() With {.Deflection = 266, .AppliedStress = 80, .Temperature = 200, .TestDate = DateTime.Now}
    Private deflection304 As New TestResult() With {.Deflection = 304, .AppliedStress = 90, .Temperature = 200, .TestDate = DateTime.Now}
    Private deflection342 As New TestResult() With {.Deflection = 342, .AppliedStress = 100, .Temperature = 200, .TestDate = DateTime.Now}
    Private deflection999 As New TestResult() With {.Deflection = 999, .AppliedStress = 999, .Temperature = 200, .TestDate = DateTime.Now}

    ''' <summary>
    ''' A test for System.Collections.Generic.ICollection(Of TItem).Add
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    <DeploymentItem("BinaryTree.dll")>
    Public Sub AddTest()
        Dim resultTree As New Tree(Of TestResult)(New TestResult() With {.Deflection = 190, .AppliedStress = 60, .Temperature = 200, .TestDate = DateTime.Now})
        Dim target = resultTree
        target.Add(New TestResult() With {.Deflection = 114, .AppliedStress = 40, .Temperature = 200, .TestDate = DateTime.Now})
        target.Add(New TestResult() With {.Deflection = 266, .AppliedStress = 80, .Temperature = 200, .TestDate = DateTime.Now})
        target.Add(New TestResult() With {.Deflection = 114, .AppliedStress = 50, .Temperature = 200, .TestDate = DateTime.Now})
        target.Add(New TestResult() With {.Deflection = 0, .AppliedStress = 10, .Temperature = 200, .TestDate = DateTime.Now})
        target.Add(New TestResult() With {.Deflection = 342, .AppliedStress = 100, .Temperature = 200, .TestDate = DateTime.Now})
        target.Add(New TestResult() With {.Deflection = 76, .AppliedStress = 30, .Temperature = 200, .TestDate = DateTime.Now})
        target.Add(New TestResult() With {.Deflection = 304, .AppliedStress = 90, .Temperature = 200, .TestDate = DateTime.Now})
        target.Add(New TestResult() With {.Deflection = 38, .AppliedStress = 20, .Temperature = 200, .TestDate = DateTime.Now})
        target.Add(New TestResult() With {.Deflection = 190, .AppliedStress = 70, .Temperature = 200, .TestDate = DateTime.Now})

        Dim expected As Integer = 10
        Dim actual As Integer = target.Count
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    ''' A test for Clear
    '''</summary>
    <TestMethod()>
    Public Sub ClearTest()
        Dim target As Tree(Of TestResult) = CreateATreeOfTestResults()
        target.Clear()
        Dim expected As Integer = 1
        Dim actual As Integer = target.Count
        Dim expectedValue As TestResult = Nothing
        Dim actualValue As TestResult = target.NodeData
        Assert.AreEqual(expected, actual)
        Assert.AreEqual(expectedValue, actualValue)
    End Sub

    ''' <summary>
    '''A test for Contains where the tree contains the value
    '''</summary>
    <TestMethod()>
    Public Sub ContainsTest1()
        Dim target As Tree(Of TestResult) = CreateATreeOfTestResults()
        Dim actual As Boolean = target.Contains(deflection190a)
        Assert.IsTrue(actual)
    End Sub

    ''' <summary>
    '''A test for Contains where the tree does not contain the value
    '''</summary>
    <TestMethod()>
    Public Sub ContainsTest2()
        Dim target As Tree(Of TestResult) = CreateATreeOfTestResults()
        Dim actual As Boolean = target.Contains(deflection999)
        Assert.IsFalse(actual)
    End Sub

    ''' <summary>
    '''A test for CopyTo - Not Implemented
    '''</summary>
    <TestMethod()>
    <ExpectedException(GetType(NotImplementedException))>
    Public Sub CopyToTest()
        Dim target As Tree(Of TestResult) = CreateATreeOfTestResults()
        Dim arr() As TestResult
        ReDim arr(9)
        target.CopyTo(arr, 0)
    End Sub


    ''' <summary>
    '''A test for IndexOf where item exists
    '''</summary>
    <TestMethod()>
    Public Sub IndexOfTest()
        Dim target As Tree(Of TestResult) = CreateATreeOfTestResults()
        Dim expected As Integer = 3
        Dim actual As Integer = target.IndexOf(deflection114a)
        Assert.AreEqual(expected, actual)
    End Sub

    ''' <summary>
    '''A test for Insert - Not implemented
    '''</summary>
    <TestMethod()>
    <ExpectedException(GetType(NotImplementedException))>
    Public Sub InsertTest()
        Dim target As Tree(Of TestResult) = CreateATreeOfTestResults()
        target.Insert(3, deflection999)
    End Sub

    ''' <summary>
    '''A test for System.Collections.Generic.ICollection(Of TItem).Remove
    '''Remove the root node of the tree where root has no children
    '''</summary>
    <TestMethod()>
    <DeploymentItem("BinaryTree.dll")>
    Public Sub RemoveRootNoChildren()
        Dim resultTree As New Tree(Of TestResult)(New TestResult() With {.Deflection = 190, .AppliedStress = 60, .Temperature = 200, .TestDate = DateTime.Now})
        Dim target = resultTree
        Assert.IsTrue(target.RemoveItem(deflection190a))
        Assert.AreEqual(1, target.Count)
        Assert.AreEqual(deflection190a.Deflection, resultTree.NodeData.Deflection)
    End Sub

    ''' <summary>
    '''A test for System.Collections.Generic.ICollection(Of TItem).Remove
    '''Remove the root node of the tree where root has one child
    '''</summary>
    <TestMethod()>
    <DeploymentItem("BinaryTree.dll")>
    Public Sub RemoveRootOneChild()
        Dim resultTree As New Tree(Of TestResult)(New TestResult() With {.Deflection = 190, .AppliedStress = 60, .Temperature = 200, .TestDate = DateTime.Now})
        resultTree.Add(New TestResult() With {.Deflection = 114, .AppliedStress = 40, .Temperature = 200, .TestDate = DateTime.Now})
        resultTree.Add(New TestResult() With {.Deflection = 114, .AppliedStress = 50, .Temperature = 200, .TestDate = DateTime.Now})
        resultTree.Add(New TestResult() With {.Deflection = 0, .AppliedStress = 10, .Temperature = 200, .TestDate = DateTime.Now})
        resultTree.Add(New TestResult() With {.Deflection = 76, .AppliedStress = 30, .Temperature = 200, .TestDate = DateTime.Now})
        resultTree.Add(New TestResult() With {.Deflection = 38, .AppliedStress = 20, .Temperature = 200, .TestDate = DateTime.Now})
        Dim target = resultTree
        Assert.IsTrue(target.RemoveItem(deflection190a))
        Assert.AreEqual(5, target.Count)
        Assert.AreEqual(deflection114a.Deflection, resultTree.NodeData.Deflection)
        Assert.AreEqual(deflection0.Deflection, resultTree(0).Deflection)
        Assert.AreEqual(deflection38.Deflection, resultTree(1).Deflection)
        Assert.AreEqual(deflection76.Deflection, resultTree(2).Deflection)
        Assert.AreEqual(deflection114a.Deflection, resultTree(3).Deflection)
        Assert.AreEqual(deflection114b.Deflection, resultTree(4).Deflection)
    End Sub

    ''' <summary>
    '''A test for System.Collections.Generic.ICollection(Of TItem).Remove
    '''Remove the root node of the tree where root has two children
    '''</summary>
    <TestMethod()>
    <DeploymentItem("BinaryTree.dll")>
    Public Sub RemoveRootTwoChildren()
        Dim resultTree As Tree(Of TestResult) = CreateATreeOfTestResults()
        Dim target = resultTree
        Assert.IsTrue(target.RemoveItem(deflection190a))
        Assert.AreEqual(9, target.Count)
        Assert.AreEqual(deflection190b.Deflection, resultTree.NodeData.Deflection)
        Assert.AreEqual(deflection0.Deflection, resultTree(0).Deflection)
        Assert.AreEqual(deflection38.Deflection, resultTree(1).Deflection)
        Assert.AreEqual(deflection76.Deflection, resultTree(2).Deflection)
        Assert.AreEqual(deflection114a.Deflection, resultTree(3).Deflection)
        Assert.AreEqual(deflection114b.Deflection, resultTree(4).Deflection)
        Assert.AreEqual(deflection190b.Deflection, resultTree(5).Deflection)
        Assert.AreEqual(deflection266.Deflection, resultTree(6).Deflection)
        Assert.AreEqual(deflection304.Deflection, resultTree(7).Deflection)
        Assert.AreEqual(deflection342.Deflection, resultTree(8).Deflection)
    End Sub

    ''' <summary>
    '''A test for System.Collections.Generic.ICollection(Of TItem).Remove
    '''Remove a node of the tree where the node has no children
    '''</summary>
    <TestMethod()>
    <DeploymentItem("BinaryTree.dll")>
    Public Sub RemoveNodeNoChildren()
        Dim resultTree As Tree(Of TestResult) = CreateATreeOfTestResults()
        Dim target = resultTree
        Assert.IsTrue(target.RemoveItem(deflection304))
        Assert.AreEqual(9, target.Count)
        Assert.AreEqual(deflection190a.Deflection, resultTree.NodeData.Deflection)
        Assert.AreEqual(deflection0.Deflection, resultTree(0).Deflection)
        Assert.AreEqual(deflection38.Deflection, resultTree(1).Deflection)
        Assert.AreEqual(deflection76.Deflection, resultTree(2).Deflection)
        Assert.AreEqual(deflection114a.Deflection, resultTree(3).Deflection)
        Assert.AreEqual(deflection114b.Deflection, resultTree(4).Deflection)
        Assert.AreEqual(deflection190a.Deflection, resultTree(5).Deflection)
        Assert.AreEqual(deflection190b.Deflection, resultTree(6).Deflection)
        Assert.AreEqual(deflection266.Deflection, resultTree(7).Deflection)
        Assert.AreEqual(deflection342.Deflection, resultTree(8).Deflection)
    End Sub

    ''' <summary>
    '''A test for System.Collections.Generic.ICollection(Of TItem).Remove
    '''Remove a node of the tree where the node has one child
    '''</summary>
    <TestMethod()>
    <DeploymentItem("BinaryTree.dll")>
    Public Sub RemoveNodeOneChild()
        Dim resultTree As Tree(Of TestResult) = CreateATreeOfTestResults()
        Dim target = resultTree
        Assert.IsTrue(target.RemoveItem(deflection76))
        Assert.AreEqual(9, target.Count)
        Assert.AreEqual(deflection190a.Deflection, resultTree.NodeData.Deflection)
        Assert.AreEqual(deflection0.Deflection, resultTree(0).Deflection)
        Assert.AreEqual(deflection38.Deflection, resultTree(1).Deflection)
        Assert.AreEqual(deflection114a.Deflection, resultTree(2).Deflection)
        Assert.AreEqual(deflection114b.Deflection, resultTree(3).Deflection)
        Assert.AreEqual(deflection190a.Deflection, resultTree(4).Deflection)
        Assert.AreEqual(deflection190b.Deflection, resultTree(5).Deflection)
        Assert.AreEqual(deflection266.Deflection, resultTree(6).Deflection)
        Assert.AreEqual(deflection304.Deflection, resultTree(7).Deflection)
        Assert.AreEqual(deflection342.Deflection, resultTree(8).Deflection)
    End Sub

    ''' <summary>
    '''A test for System.Collections.Generic.ICollection(Of TItem).Remove
    '''Remove a node of the tree where the node has two children
    '''</summary>
    <TestMethod()>
    <DeploymentItem("BinaryTree.dll")>
    Public Sub RemoveNodeTwoChildren()
        Dim resultTree As Tree(Of TestResult) = CreateATreeOfTestResults()
        Dim target = resultTree
        Assert.IsTrue(target.RemoveItem(deflection266))
        Assert.AreEqual(9, target.Count)
        Assert.AreEqual(deflection190a.Deflection, resultTree.NodeData.Deflection)
        Assert.AreEqual(deflection0.Deflection, resultTree(0).Deflection)
        Assert.AreEqual(deflection38.Deflection, resultTree(1).Deflection)
        Assert.AreEqual(deflection76.Deflection, resultTree(2).Deflection)
        Assert.AreEqual(deflection114a.Deflection, resultTree(3).Deflection)
        Assert.AreEqual(deflection114b.Deflection, resultTree(4).Deflection)
        Assert.AreEqual(deflection190a.Deflection, resultTree(5).Deflection)
        Assert.AreEqual(deflection190b.Deflection, resultTree(6).Deflection)
        Assert.AreEqual(deflection304.Deflection, resultTree(7).Deflection)
        Assert.AreEqual(deflection342.Deflection, resultTree(8).Deflection)
    End Sub

    ''' <summary>
    '''A test for System.Collections.Generic.ICollection(Of TItem).Remove
    '''Try to remove a nonexistent node from the tree.
    '''</summary>
    <TestMethod()>
    <DeploymentItem("BinaryTree.dll")>
    Public Sub RemoveNonexistentNode()
        Dim resultTree As Tree(Of TestResult) = CreateATreeOfTestResults()
        Dim target = resultTree
        Assert.IsFalse(target.RemoveItem(deflection999))
        Assert.AreEqual(10, target.Count)
        Assert.AreEqual(deflection190a.Deflection, resultTree.NodeData.Deflection)
        Assert.AreEqual(deflection0.Deflection, resultTree(0).Deflection)
        Assert.AreEqual(deflection38.Deflection, resultTree(1).Deflection)
        Assert.AreEqual(deflection76.Deflection, resultTree(2).Deflection)
        Assert.AreEqual(deflection114a.Deflection, resultTree(3).Deflection)
        Assert.AreEqual(deflection114b.Deflection, resultTree(4).Deflection)
        Assert.AreEqual(deflection190a.Deflection, resultTree(5).Deflection)
        Assert.AreEqual(deflection190b.Deflection, resultTree(6).Deflection)
        Assert.AreEqual(deflection266.Deflection, resultTree(7).Deflection)
        Assert.AreEqual(deflection304.Deflection, resultTree(8).Deflection)
        Assert.AreEqual(deflection342.Deflection, resultTree(9).Deflection)
    End Sub

    ''' <summary>
    '''A test for RemoveAt with a valid index
    '''</summary>
    <TestMethod()>
    Public Sub RemoveAtTest1()
        Dim target As Tree(Of TestResult) = CreateATreeOfTestResults()
        target.RemoveAt(4)
        Dim actual As Integer = target.Count
        Assert.AreEqual(deflection0.Deflection, target(0).Deflection)
        Assert.AreEqual(deflection38.Deflection, target(1).Deflection)
        Assert.AreEqual(deflection76.Deflection, target(2).Deflection)
        Assert.AreEqual(deflection114a.Deflection, target(3).Deflection)
        Assert.AreEqual(deflection190a.Deflection, target(4).Deflection)
        Assert.AreEqual(deflection190b.Deflection, target(5).Deflection)
        Assert.AreEqual(deflection266.Deflection, target(6).Deflection)
        Assert.AreEqual(deflection304.Deflection, target(7).Deflection)
        Assert.AreEqual(deflection342.Deflection, target(8).Deflection)
        Assert.AreEqual(9, actual)
    End Sub

    ''' <summary>
    '''A test for RemoveAt with an invalid index
    '''</summary>
    <TestMethod()>
    <ExpectedException(GetType(ArgumentOutOfRangeException))>
    Public Sub RemoveAtTest2()
        Dim target As Tree(Of TestResult) = CreateATreeOfTestResults()
        target.RemoveAt(12)
    End Sub

    ''' <summary>
    '''A test for Count
    '''</summary>
    <TestMethod()>
    Public Sub CountTest()
        Dim target As Tree(Of TestResult) = CreateATreeOfTestResults()
        Dim expected As Integer = 10
        Dim actual As Integer = target.Count
        Assert.AreEqual(expected, actual)
    End Sub

    ''' <summary>
    '''A test for IsReadOnly
    '''</summary>
    <TestMethod()>
    Public Sub IsReadOnlyTest()
        Dim target As Tree(Of TestResult) = CreateATreeOfTestResults()
        Assert.IsFalse(target.IsReadOnly)
    End Sub

    ''' <summary>
    '''A test for Item (indexer) with valid indicies
    '''</summary>
    <TestMethod()>
    Public Sub ItemTest1()
        Dim target As Tree(Of TestResult) = CreateATreeOfTestResults()
        Assert.AreEqual(deflection0.Deflection, target(0).Deflection)
        Assert.AreEqual(deflection38.Deflection, target(1).Deflection)
        Assert.AreEqual(deflection76.Deflection, target(2).Deflection)
        Assert.AreEqual(deflection114a.Deflection, target(3).Deflection)
        Assert.AreEqual(deflection114b.Deflection, target(4).Deflection)
        Assert.AreEqual(deflection190a.Deflection, target(5).Deflection)
        Assert.AreEqual(deflection190b.Deflection, target(6).Deflection)
        Assert.AreEqual(deflection266.Deflection, target(7).Deflection)
        Assert.AreEqual(deflection304.Deflection, target(8).Deflection)
        Assert.AreEqual(deflection342.Deflection, target(9).Deflection)
    End Sub

    ''' <summary>
    '''A test for Item (indexer) with invalid indicies
    '''</summary>
    <TestMethod()>
    <ExpectedException(GetType(ArgumentOutOfRangeException))>
    Public Sub ItemTest2()
        Dim target As Tree(Of TestResult) = CreateATreeOfTestResults()
        Dim actual As TestResult = target(-1)
        actual = target(11)
    End Sub
End Class