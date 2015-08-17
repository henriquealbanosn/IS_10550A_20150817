Imports BinaryTree
Imports StressTestResult

Module Module1
    Sub Main()
        ' Integer Tests
        TestIntegerTree()
        TestDeleteRootNodeInteger()
        'TestDeleteNodeNoChildrenInteger()
        'TestDeleteNodeOneChildInteger()
        'TestDeleteNodeTwoChildrenInteger()
        TestIteratorsIntegers()

        ' String Tests
        TestStringTree()
        TestDeleteRootNodeString()
        'TestDeleteNodeNoChildrenString()
        'TestDeleteNodeOneChildString()
        'TestDeleteNodeTwoChildrenString()
        TestIteratorsStrings()

        ' TestResult Tests
        TestTestResultTree()
        TestDeleteRootNodeTestResults()
        'TestDeleteNodeNoChildrenTestResult()
        'TestDeleteNodeOneChildTestResult()
        'TestDeleteNodeTwoChildrenTestResult()
        TestIteratorsTestResults()
    End Sub

#Region "Integer Tests"
    Private Sub TestIntegerTree()
        Console.WriteLine("TestIntegerTree()")
        Dim integerTree As Tree(Of Integer) = CreateATreeOfIntegers()
        Console.WriteLine(vbNewLine & "WalkTree()")
        integerTree.WalkTree()
        Console.WriteLine(vbNewLine & "Count: {0}", integerTree.Count)
        Console.WriteLine(vbNewLine & "Remove(11)")
        Dim colTree = integerTree
        colTree.Remove(11)
        Console.WriteLine(vbNewLine & "Count: {0}", integerTree.Count)
        Console.WriteLine(vbNewLine & "Contains(11): {0}", integerTree.Contains(11))
        Console.WriteLine(vbNewLine & "Contains(-12): {0}", integerTree.Contains(-12))
        Console.WriteLine(vbNewLine & "IndexOf(5): {0}", integerTree.IndexOf(5))
        Console.WriteLine(vbNewLine & "tree(3): {0}", integerTree(3))
        Console.ReadLine()
        Console.Clear()
    End Sub

    Private Sub TestIteratorsIntegers()
        Console.WriteLine("TestIteratorsIntegers()")
        Dim integerTree As Tree(Of Integer) = CreateATreeOfIntegers()
        Console.WriteLine(vbNewLine & "In ascending order")

        For Each item In integerTree
            Console.WriteLine(item.ToString())
        Next

        Console.WriteLine(vbNewLine & "In descending order")

        Try
            For Each item In integerTree.Reverse()
                Console.WriteLine(item.ToString())
            Next
        Catch ex As NotImplementedException
            Console.WriteLine("Not Implemented. You will implement this functionality in Exercise 3")
        End Try

        Console.ReadLine()
        Console.Clear()
    End Sub

    Private Sub TestDeleteRootNodeInteger()
        Console.WriteLine("TestDeleteRootNodeInteger()")
        Dim integerTree As Tree(Of Integer) = CreateATreeOfIntegers()
        Console.WriteLine(vbNewLine & "Before")
        integerTree.WalkTree()
        Console.WriteLine(vbNewLine & "Remove 5 twice")
        Dim colTree = integerTree
        colTree.Remove(5)
        colTree.Remove(5)
        Console.WriteLine(vbNewLine & "After")
        integerTree.WalkTree()
        Console.ReadLine()
        Console.Clear()
    End Sub

    Private Sub TestDeleteNodeNoChildrenInteger()
        Console.WriteLine("TestDeleteNodeNoChildrenInteger()")
        Dim integerTree As Tree(Of Integer) = CreateATreeOfIntegers()
        Console.WriteLine(vbNewLine & "Before")
        integerTree.WalkTree()
        Console.WriteLine(vbNewLine & "Remove 14")
        Dim colTree = integerTree
        colTree.Remove(14)
        Console.WriteLine(vbNewLine & "After")
        integerTree.WalkTree()
        Console.ReadLine()
        Console.Clear()
    End Sub

    Private Sub TestDeleteNodeOneChildInteger()
        Console.WriteLine("TestDeleteNodeOneChildInteger()")
        Dim integerTree As Tree(Of Integer) = CreateATreeOfIntegers()
        Console.WriteLine(vbNewLine & "Before")
        integerTree.WalkTree()
        Console.WriteLine(vbNewLine & "Remove -12")
        Dim colTree = integerTree
        colTree.Remove(-12)
        Console.WriteLine(vbNewLine & "After")
        integerTree.WalkTree()
        Console.ReadLine()
        Console.Clear()
    End Sub

    Private Sub TestDeleteNodeTwoChildrenInteger()
        Console.WriteLine("TestDeleteNodeTwoChildrenInteger()")
        Dim integerTree As Tree(Of Integer) = CreateATreeOfIntegers()
        Console.WriteLine(vbNewLine & "Before")
        integerTree.WalkTree()
        Console.WriteLine(vbNewLine & "Remove 11")
        Dim colTree = integerTree
        colTree.Remove(11)
        Console.WriteLine(vbNewLine & "After")
        integerTree.WalkTree()
        Console.ReadLine()
        Console.Clear()
    End Sub
#End Region

#Region "String Tests"
    Private Sub TestStringTree()
        Console.WriteLine("TestStringTree()")
        Dim stringTree As Tree(Of String) = CreateATreeOfStrings()
        Console.WriteLine(vbNewLine & "WalkTree()")
        stringTree.WalkTree()
        Console.WriteLine(vbNewLine & "Count: {0}", stringTree.Count)
        Console.WriteLine(vbNewLine & "Remove(""p936"")")
        Dim colTree = stringTree
        colTree.Remove("p936")
        Console.WriteLine(vbNewLine & "Count: {0}", stringTree.Count)
        Console.WriteLine(vbNewLine & "Contains(""p936""): {0}", stringTree.Contains("p936"))
        Console.WriteLine(vbNewLine & "Contains(""a279""): {0}", stringTree.Contains("a279"))
        Console.WriteLine(vbNewLine & "IndexOf(""h624""): {0}", stringTree.IndexOf("h624"))
        Console.WriteLine(vbNewLine & "Tree(3): {0}", stringTree(3))
        Console.ReadLine()
        Console.Clear()
    End Sub

    Private Sub TestIteratorsStrings()
        Console.WriteLine("TestIteratorsStrings()")
        Dim stringTree As Tree(Of String) = CreateATreeOfStrings()
        Console.WriteLine(vbNewLine & "In ascending order")

        For Each item In stringTree
            Console.WriteLine(item.ToString())
        Next

        Console.WriteLine(vbNewLine & "In descending order")

        Try
            For Each item In stringTree.Reverse()
                Console.WriteLine(item.ToString())
            Next
        Catch ex As NotImplementedException
            Console.WriteLine("Not Implemented. You will implement this functionality in Exercise 3")
        End Try

        Console.ReadLine()
        Console.Clear()
    End Sub

    Private Sub TestDeleteRootNodeString()
        Console.WriteLine("TestDeleteRootNodeString()")
        Dim stringTree As Tree(Of String) = CreateATreeOfStrings()
        Console.WriteLine(vbNewLine & "Before")
        stringTree.WalkTree()
        Console.WriteLine(vbNewLine & "Remove k203 twice")
        Dim colTree = stringTree
        colTree.Remove("k203")
        colTree.Remove("k203")
        Console.WriteLine(vbNewLine & "After")
        stringTree.WalkTree()
        Console.ReadLine()
        Console.Clear()
    End Sub

    Private Sub TestDeleteNodeNoChildrenString()
        Console.WriteLine("TestDeleteNodeNoChildrenString()")
        Dim stringTree As Tree(Of String) = CreateATreeOfStrings()
        Console.WriteLine(vbNewLine & "Before")
        stringTree.WalkTree()
        Console.WriteLine(vbNewLine & "Remove r483")
        Dim colTree As ICollection(Of String) = stringTree
        colTree.Remove("r483")
        Console.WriteLine(vbNewLine & "After")
        stringTree.WalkTree()
        Console.ReadLine()
        Console.Clear()
    End Sub

    Private Sub TestDeleteNodeOneChildString()
        Console.WriteLine("TestDeleteNodeOneChildString()")
        Dim stringTree As Tree(Of String) = CreateATreeOfStrings()
        Console.WriteLine(vbNewLine & "Before")
        stringTree.WalkTree()
        Console.WriteLine(vbNewLine & "Remove a279")
        Dim colTree = stringTree
        colTree.Remove("a279")
        Console.WriteLine(vbNewLine & "After")
        stringTree.WalkTree()
        Console.ReadLine()
        Console.Clear()
    End Sub

    Private Sub TestDeleteNodeTwoChildrenString()
        Console.WriteLine("TestDeleteNodeTwoChildrenString()")
        Dim stringTree As Tree(Of String) = CreateATreeOfStrings()
        Console.WriteLine(vbNewLine & "Before")
        stringTree.WalkTree()
        Console.WriteLine(vbNewLine & "Remove p936")
        Dim colTree = stringTree
        colTree.Remove("p936")
        Console.WriteLine(vbNewLine & "After")
        stringTree.WalkTree()
        Console.ReadLine()
        Console.Clear()
    End Sub
#End Region

#Region "TestResult Tests"
    Private Sub TestTestResultTree()
        Dim def266 As New TestResult() With {.Deflection = 266, .AppliedStress = 80, .Temperature = 200, .TestDate = DateTime.Now}
        Dim def0 As New TestResult() With {.Deflection = 0, .AppliedStress = 10, .Temperature = 200, .TestDate = DateTime.Now}
        Dim def114 As New TestResult() With {.Deflection = 114, .AppliedStress = 50, .Temperature = 200, .TestDate = DateTime.Now}
        Console.WriteLine("TestTestResultTree()")
        Dim resultTree As Tree(Of TestResult) = CreateATreeOfTestResults()
        Console.WriteLine(vbNewLine & "WalkTree()")
        resultTree.WalkTree()
        Console.WriteLine(vbNewLine & "Count: {0}", resultTree.Count)
        Console.WriteLine(vbNewLine & "Remove(def266)")
        Dim colTree = resultTree
        colTree.Remove(def266)
        Console.WriteLine(vbNewLine & "Count: {0}", resultTree.Count)
        Console.WriteLine(vbNewLine & "Contains(def266): {0}", resultTree.Contains(def266))
        Console.WriteLine(vbNewLine & "Contains(def0): {0}", resultTree.Contains(def0))
        Console.WriteLine(vbNewLine & "IndexOf(def114): {0}", resultTree.IndexOf(def114))
        Console.WriteLine(vbNewLine & "Tree(3): {0}", resultTree(3))
        Console.ReadLine()
        Console.Clear()
    End Sub

    Private Sub TestIteratorsTestResults()
        Console.WriteLine("TestIteratorsTestResults()")
        Dim resultTree As Tree(Of TestResult) = CreateATreeOfTestResults()
        Console.WriteLine(vbNewLine & "In ascending order")

        For Each item In resultTree
            Console.WriteLine(item.ToString())
        Next

        Console.WriteLine(vbNewLine & "In descending order")

        Try
            For Each item In resultTree.Reverse()
                Console.WriteLine(item.ToString())
            Next
        Catch ex As NotImplementedException
            Console.WriteLine("Not Implemented. You will implement this functionality in Exercise 3")
        End Try

        Console.ReadLine()
        Console.Clear()
    End Sub

    Private Sub TestDeleteRootNodeTestResults()
        Dim def190 As New TestResult() With {.Deflection = 190, .AppliedStress = 70, .Temperature = 200, .TestDate = DateTime.Now}
        Console.WriteLine("TestDeleteRootNodeTestResults()")
        Dim resultTree As Tree(Of TestResult) = CreateATreeOfTestResults()
        Console.WriteLine(vbNewLine & "Before")
        resultTree.WalkTree()
        Console.WriteLine(vbNewLine & "Remove def190 twice")
        Dim colTree = resultTree
        colTree.Remove(def190)
        colTree.Remove(def190)
        Console.WriteLine(vbNewLine & "After")
        resultTree.WalkTree()
        Console.ReadLine()
        Console.Clear()
    End Sub

    Private Sub TestDeleteNodeNoChildrenTestResult()
        Dim def304 As New TestResult() With {.Deflection = 304, .AppliedStress = 90, .Temperature = 200, .TestDate = DateTime.Now}
        Console.WriteLine("TestDeleteNodeNoChildrenTestResult()")
        Dim resultTree As Tree(Of TestResult) = CreateATreeOfTestResults()
        Console.WriteLine(vbNewLine & "Before")
        resultTree.WalkTree()
        Console.WriteLine(vbNewLine & "Remove def304")
        Dim colTree = resultTree
        colTree.Remove(def304)
        Console.WriteLine(vbNewLine & "After")
        resultTree.WalkTree()
        Console.ReadLine()
        Console.Clear()
    End Sub

    Private Sub TestDeleteNodeOneChildTestResult()
        Dim def0 As New TestResult() With {.Deflection = 0, .AppliedStress = 10, .Temperature = 200, .TestDate = DateTime.Now}
        Console.WriteLine("TestDeleteNodeOneChildTestResult()")
        Dim resultTree As Tree(Of TestResult) = CreateATreeOfTestResults()
        Console.WriteLine(vbNewLine & "Before")
        resultTree.WalkTree()
        Console.WriteLine(vbNewLine & "Remove def0")
        Dim colTree = resultTree
        colTree.Remove(def0)
        Console.WriteLine(vbNewLine & "After")
        resultTree.WalkTree()
        Console.ReadLine()
        Console.Clear()
    End Sub

    Private Sub TestDeleteNodeTwoChildrenTestResult()
        Dim def266 = New TestResult() With {.Deflection = 266, .AppliedStress = 80, .Temperature = 200, .TestDate = DateTime.Now}
        Console.WriteLine("TestDeleteNodeTwoChildrenTestResult()")
        Dim resultTree As Tree(Of TestResult) = CreateATreeOfTestResults()
        Console.WriteLine(vbNewLine & "Before")
        resultTree.WalkTree()
        Console.WriteLine(vbNewLine & "Remove def266")
        Dim colTree = resultTree
        colTree.Remove(def266)
        Console.WriteLine(vbNewLine & "After")
        resultTree.WalkTree()
        Console.ReadLine()
        Console.Clear()
    End Sub
#End Region

#Region "Create Some Trees"

    ''' <summary>
    ''' Creates a tree of integers.
    '''             10
    '''         /        \
    '''      5              11
    '''    /   \           /   \
    '''  -12     5       10     15
    '''     \                  /
    '''      0               14
    '''     /
    '''    -8
    ''' </summary>
    ''' <returns>Tree of integers.</returns>
    Private Function CreateATreeOfIntegers() As Tree(Of Integer)
        Dim integerTree As New Tree(Of Integer)(10)
        Dim colTree = integerTree
        colTree.Add(5)
        colTree.Add(11)
        colTree.Add(5)
        colTree.Add(-12)
        colTree.Add(15)
        colTree.Add(0)
        colTree.Add(14)
        colTree.Add(-8)
        colTree.Add(10)

        Return integerTree
    End Function

    ''' <summary>
    ''' Creates a tree of strings.
    '''            k203
    '''         /        \
    '''      h624          p936
    '''    /   \           /   \
    ''' a279   h624      k203  z837
    '''     \                  /
    '''    e762              r483
    '''     /
    '''   d776
    ''' </summary>
    ''' <returns>Tree of strings.</returns>
    Private Function CreateATreeOfStrings() As Tree(Of String)
        Dim stringTree As New Tree(Of String)("k203")
        Dim colTree = stringTree
        colTree.Add("h624")
        colTree.Add("p936")
        colTree.Add("h624")
        colTree.Add("a279")
        colTree.Add("z837")
        colTree.Add("e762")
        colTree.Add("r483")
        colTree.Add("d776")
        colTree.Add("k203")

        Return stringTree
    End Function

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
    Private Function CreateATreeOfTestResults() As Tree(Of TestResult)
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
#End Region
End Module