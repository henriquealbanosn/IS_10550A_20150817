''' <summary>
''' Interface that defines the basic functionality of a generic binary tree.
''' </summary>
''' <typeparam name="TItem">Type of item to store in the tree, must implement IComparable.</typeparam>
''' <remarks></remarks>
Public Interface IBinaryTree(Of TItem As IComparable)
    ''' <summary>
    ''' Adds a new item to the tree.
    ''' </summary>
    ''' <param name="newItem">Item to add.</param>
    ''' <remarks></remarks>
    Sub Add(ByVal newItem As TItem)

    ''' <summary>
    ''' Remove an item from the tree.
    ''' <para>
    ''' This method will search for an item with the same value in the tree, to remove.
    ''' </para>
    ''' <para>
    ''' Nothing will happen if there isn't a matching item in the tree.
    ''' </para>
    ''' </summary>
    ''' <param name="itemToRemove">Item to remove.</param>
    ''' <remarks></remarks>
    Sub Remove(ByVal itemToRemove As TItem)

    ''' <summary>
    ''' Displays the contents of the tree in order.
    ''' </summary>
    ''' <remarks></remarks>
    Sub WalkTree()
End Interface