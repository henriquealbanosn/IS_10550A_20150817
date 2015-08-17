Public Interface IBinaryTree(Of TItem As IComparable(Of TItem))
    Sub Add(ByVal newItem As TItem)

    Sub Remove(ByVal itemToRemove As TItem)

    Sub WalkTree()
End Interface
