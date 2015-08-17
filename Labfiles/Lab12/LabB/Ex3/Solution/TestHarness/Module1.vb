Imports BinaryTree

Module Module1

    Sub Main()
        Dim tree As IBinaryTree(Of Integer) = New Tree(Of Integer)(5)

        tree.Add(1)
        tree.Add(4)
        tree.Add(7)
        tree.Add(3)
        tree.Add(4)

        Console.WriteLine("Current Tree: ")
        tree.WalkTree()
        Console.WriteLine("Add 15")
        tree.Add(15)
        Console.WriteLine("Current Tree: ")
        tree.WalkTree()
        Console.WriteLine("Remove 5")
        tree.Remove(5)
        Console.WriteLine("Current Tree: ")
        tree.WalkTree()
        Console.ReadLine()
    End Sub

End Module
