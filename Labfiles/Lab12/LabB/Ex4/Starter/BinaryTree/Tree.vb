Public Class Tree(Of TItem As IComparable)
    Implements IBinaryTree(Of TItem)

    Public Property NodeData As TItem

    Public Property LeftTree As Tree(Of TItem)

    Public Property RightTree As Tree(Of TItem)

    Public Sub New(ByVal nodeValue As TItem)
        Me.NodeData = nodeValue
        Me.LeftTree = Nothing
        Me.RightTree = Nothing
    End Sub

    Public Sub Add(ByVal newItem As TItem) Implements IBinaryTree(Of TItem).Add
        Dim currentNodeValue As TItem = Me.NodeData

        ' Check if the item should be inserted in the left tree.
        If currentNodeValue.CompareTo(newItem) > 0 Then
            ' Is the left tree null?
            If Me.LeftTree Is Nothing Then
                Me.LeftTree = New Tree(Of TItem)(newItem)
            Else ' Call the Add method recursively.
                Me.LeftTree.Add(newItem)
            End If
        Else ' Insert in the right tree.
            ' Is the right tree null?
            If Me.RightTree Is Nothing Then
                Me.RightTree = New Tree(Of TItem)(newItem)
            Else ' Call the Add method recursively.
                Me.RightTree.Add(newItem)
            End If
        End If
    End Sub

    Public Sub WalkTree() Implements IBinaryTree(Of TItem).WalkTree
        ' Recursive descent of the left tree.
        If Not Me.LeftTree Is Nothing Then
            Me.LeftTree.WalkTree()
        End If

        Console.WriteLine(Me.NodeData.ToString())

        ' Recursive descent of the right tree.
        If Not Me.RightTree Is Nothing Then
            Me.RightTree.WalkTree()
        End If
    End Sub


    ''' <summary>
    ''' Removes an item from the tree.
    ''' <para>
    ''' Note that you cannot remove the last node from the tree.
    ''' </para>
    ''' <para>
    ''' If the item is not found in the tree, nothing happens.
    ''' </para>
    ''' <para>
    ''' The remove algorithm needs to treat removing the root node differently from other
    ''' nodes - if the root node has no children it can't be removed.
    ''' </para>
    ''' <para>
    ''' In general remove has to deal with 3 scenarios - nodes with no children,
    ''' nodes with a single child, and nodes with two children.
    ''' </para>
    ''' </summary>
    ''' <param name="itemToRemove"></param>
    ''' <remarks></remarks>
    Public Sub Remove(ByVal itemToRemove As TItem) Implements IBinaryTree(Of TItem).Remove
        ' Cannot remove null.
        If itemToRemove Is Nothing Then Return

        ' Check if the item could be in the left tree.
        If Me.NodeData.CompareTo(itemToRemove) > 0 AndAlso Not Me.LeftTree Is Nothing Then
            ' Check the left tree.
            ' Check 2 levels down the tree - cannot remove
            ' 'this', only the LeftTree or RightTree properties.
            If Me.LeftTree.NodeData.CompareTo(itemToRemove) = 0 Then
                ' The LeftTree property has no children - set the
                ' LeftTree property to null.
                If Me.LeftTree.LeftTree Is Nothing AndAlso Me.LeftTree.RightTree Is Nothing Then
                    Me.LeftTree = Nothing
                Else ' Remove LeftTree.
                    RemoveNodeWithChildren(Me.LeftTree)
                End If
            Else
                ' Keep looking - call the Remove method recursively.
                Me.LeftTree.Remove(itemToRemove)
            End If
        End If

        ' Check if the item could be in the right tree.?
        If Me.NodeData.CompareTo(itemToRemove) < 0 AndAlso Not Me.RightTree Is Nothing Then
            ' Check the right tree.
            ' Check 2 levels down the tree - cannot remove
            ' 'this', only the LeftTree or RightTree properties.
            If Me.RightTree.NodeData.CompareTo(itemToRemove) = 0 Then
                ' The RightTree property has no children – set the
                ' RightTree property to null.
                If Me.RightTree.LeftTree Is Nothing AndAlso Me.RightTree.RightTree Is Nothing Then
                    Me.RightTree = Nothing
                Else ' Remove the RightTree.
                    RemoveNodeWithChildren(Me.RightTree)
                End If
            Else
                ' Keep looking - call the Remove method recursively.
                Me.RightTree.Remove(itemToRemove)
            End If
        End If

        ' This will only apply at the root node.
        If Me.NodeData.CompareTo(itemToRemove) = 0 Then
            ' No children - do nothing, a tree must have at least
            ' one node. 
            If Me.LeftTree Is Nothing AndAlso Me.RightTree Is Nothing Then
                Return
            Else ' The root node has children.
                RemoveNodeWithChildren(Me)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Utility method used by the Remove method.
    ''' <para>
    ''' It removes a node that has either one or two children.
    ''' </para>
    ''' </summary>
    ''' <param name="node"></param>
    ''' <remarks></remarks>
    Private Sub RemoveNodeWithChildren(ByVal node As Tree(Of TItem))
        ' Check whether the node has children.
        If node.LeftTree Is Nothing AndAlso node.RightTree Is Nothing Then
            Throw New ArgumentException("Node has no children")
        End If

        ' The tree node has only one child - replace the
        ' tree node with its child node.
        If node.LeftTree Is Nothing Xor node.RightTree Is Nothing Then
            If node.LeftTree Is Nothing Then
                node.CopyNodeToThis(node.RightTree)
            Else
                node.CopyNodeToThis(node.LeftTree)
            End If
        Else
            ' The tree node has two children - replace the tree node's value
            ' with its "in order successor" node value and then remove the
            ' in order successor node.
            ' Find the in order successor – the leftmost descendant of
            ' its RightTree node.
            Dim successor As Tree(Of TItem) = GetLeftMostDescendant(node.RightTree)

            ' Copy the node value from the in order successor.
            node.NodeData = successor.NodeData

            ' Remove the in order successor node.
            If node.RightTree.RightTree Is Nothing AndAlso node.RightTree.LeftTree Is Nothing Then
                node.RightTree = Nothing ' The successor node had no
                ' children.
            Else
                node.RightTree.Remove(successor.NodeData)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Utility method to copy values from another tree node to this node.
    ''' </summary>
    ''' <param name="node">Tree node to copy from.</param>
    Private Sub CopyNodeToThis(ByVal node As Tree(Of TItem))
        Me.NodeData = node.NodeData
        Me.LeftTree = node.LeftTree
        Me.RightTree = node.RightTree
    End Sub

    ''' <summary>
    ''' Utility method to find the left most descendant of a tree node.
    ''' </summary>
    ''' <param name="node">Tree node to start from.</param>
    ''' <returns>Left most descendant.</returns>
    ''' <remarks></remarks>
    Private Function GetLeftMostDescendant(ByVal node As Tree(Of TItem)) As Tree(Of TItem)
        While Not node.LeftTree Is Nothing
            node = node.LeftTree
        End While

        Return node
    End Function

    ' TODO: - Add the BuildTree generic method.
End Class