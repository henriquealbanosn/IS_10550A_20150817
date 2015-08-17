Imports BinaryTree

Module Module1

    Sub Main()
        Dim integerTree As IBinaryTree(Of Integer) = Tree(Of Integer).BuildTree(Of Integer)(1, {4, 7, 3, 4, 5})

        Console.WriteLine("Current Tree: ")
        integerTree.WalkTree()
        Console.WriteLine("Add 15")
        integerTree.Add(15)
        Console.WriteLine("Current Tree: ")
        integerTree.WalkTree()
        Console.WriteLine("Remove 5")
        integerTree.Remove(5)
        Console.WriteLine("Current Tree: ")
        integerTree.WalkTree()
        Console.ReadLine()
    End Sub

End Module
