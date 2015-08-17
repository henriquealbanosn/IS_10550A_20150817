''' <summary>
''' This generic class is an implementation of IBinaryTree and IList.
''' <para>
''' This class implements a recursive definition of a tree, where each node in the tree
''' has left and right children, which are also trees.
''' </para>
''' </summary>
''' <typeparam name="TItem">Type of item to store in the tree, must implement IComparable.</typeparam>
''' <remarks></remarks>
Public Class Tree(Of TItem As IComparable)
    Implements IBinaryTree(Of TItem), IList(Of TItem)

    ''' <summary>
    ''' Data of type TItem to store in the tree.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NodeData As TItem

    ''' <summary>
    ''' The left branch of the Tree.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LeftTree As Tree(Of TItem)

    ''' <summary>
    ''' The right branch of the tree.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RightTree As Tree(Of TItem)

    ' Add a private integer variable position to define
    ' the node's position in the tree.
    Private position As Integer

    ''' <summary>
    ''' Constructor to initialize a new Tree node.
    ''' </summary>
    ''' <param name="nodeValue">Value of type TItem to add to the Tree.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal nodeValue As TItem)
        Me.NodeData = nodeValue
        Me.LeftTree = Nothing
        Me.RightTree = Nothing

        Me.position = -1
    End Sub

#Region "IBinaryTree(Of TItem) members"
    ''' <summary>
    ''' Adds a new item to the tree, duplicates are allowed.
    ''' <para>
    ''' Performs a recursive descent searching for the node where the new item should be added.
    ''' </para>
    ''' </summary>
    ''' <param name="newItem">Item of type TItem to add.</param>
    ''' <remarks></remarks>
    Public Sub Add(ByVal newItem As TItem) Implements IBinaryTree(Of TItem).Add
        ' If we're adding something, the position field will become 
        ' invalid. Reset position to -1.
        Me.position = -1

        ' Get the value of the current node.
        Dim currentNodeValue As TItem = Me.NodeData

        ' Do we need to insert on the left tree?
        If currentNodeValue.CompareTo(newItem) > 0 Then
            ' Is the left tree null?
            If Me.LeftTree Is Nothing Then
                Me.LeftTree = New Tree(Of TItem)(newItem)
            Else ' Call Add recursively.
                Me.LeftTree.Add(newItem)
            End If
        Else ' Insert in the right tree.
            ' Is the right tree null?
            If Me.RightTree Is Nothing Then
                Me.RightTree = New Tree(Of TItem)(newItem)
            Else ' Call Add recursively.
                Me.RightTree.Add(newItem)
            End If
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

        ' If we're deleting something, the position field will become 
        ' invalid. Reset position to -1
        Me.position = -1

        ' Do we need to scan the LeftTree for the item?
        If Me.NodeData.CompareTo(itemToRemove) > 0 AndAlso Not Me.LeftTree Is Nothing Then
            ' Check the left tree.
            ' Note that we are looking down 2 levels - we can't remove
            ' 'Me', only the LeftTree or RightTree properties.
            If Me.LeftTree.NodeData.CompareTo(itemToRemove) = 0 Then
                ' LeftTree has no children - set LeftTree to null.
                If Me.LeftTree.LeftTree Is Nothing AndAlso Me.LeftTree.RightTree Is Nothing Then
                    Me.LeftTree = Nothing
                Else ' Remove LeftTree.
                    RemoveNodeWithChildren(Me.LeftTree)
                End If
            Else
                ' Keep looking - call Remove recursively.
                Me.LeftTree.Remove(itemToRemove)
            End If
        End If

        ' Do we need to scan the RightTree for the item?
        If Me.NodeData.CompareTo(itemToRemove) < 0 AndAlso Not Me.RightTree Is Nothing Then
            ' Check the RightTree.
            ' Note that we are looking down 2 levels - we can't remove
            ' 'Me', only LeftTree or RightTree.
            If Me.RightTree.NodeData.CompareTo(itemToRemove) = 0 Then
                ' RightTree has no children – set RightTree to null.
                If Me.RightTree.LeftTree Is Nothing AndAlso Me.RightTree.RightTree Is Nothing Then
                    Me.RightTree = Nothing
                Else ' Remove the RightTree.
                    RemoveNodeWithChildren(Me.RightTree)
                End If
            Else
                ' Keep looking - call Remove recursively.
                Me.RightTree.Remove(itemToRemove)
            End If
        End If

        ' This will only apply at the root node.
        If Me.NodeData.CompareTo(itemToRemove) = 0 Then
            ' No children - do nothing, a tree must have at least one node. 
            If Me.LeftTree Is Nothing AndAlso Me.RightTree Is Nothing Then
                Return
            Else ' The root node has children.
                RemoveNodeWithChildren(Me)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Walks the tree in Node value order, writing results to the Console.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub WalkTree() Implements IBinaryTree(Of TItem).WalkTree
        ' Recursive descent of Left tree
        If Not Me.LeftTree Is Nothing Then
            Me.LeftTree.WalkTree()
        End If

        Console.WriteLine(Me.NodeData.ToString())

        ' Recursive descent of Right tree
        If Not Me.RightTree Is Nothing Then
            Me.RightTree.WalkTree()
        End If
    End Sub
#End Region

#Region "Utility methods"
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
    ''' Utility method used by the Remove method.
    ''' <para>
    ''' It removes a node that has either one or two children.
    ''' </para>
    ''' </summary>
    ''' <param name="node"></param>
    ''' <remarks></remarks>
    Private Sub RemoveNodeWithChildren(ByVal node As Tree(Of TItem))
        ' Check node has children
        If node.LeftTree Is Nothing AndAlso node.RightTree Is Nothing Then
            Throw New ArgumentException("Node has no children")
        End If

        ' Tree node has only one child - replace Tree node with its child node
        If node.LeftTree Is Nothing Xor node.RightTree Is Nothing Then
            If node.LeftTree Is Nothing Then
                node.CopyNodeToThis(node.RightTree)
            Else
                node.CopyNodeToThis(node.LeftTree)
            End If
        Else
            ' Node has two children - replace Tree node's value with its "in order successor" node value
            ' and then remove the in order successor node.

            ' Find the in order successor – the leftmost descendant of its RightTree node.
            Dim successor As Tree(Of TItem) = GetLeftMostDescendant(node.RightTree)

            ' Copy the node value from the in order successor.
            node.NodeData = successor.NodeData

            ' Remove the in order successor node.
            If node.RightTree.RightTree Is Nothing AndAlso node.RightTree.LeftTree Is Nothing Then
                node.RightTree = Nothing ' Successor node had no children.
            Else
                node.RightTree.Remove(successor.NodeData) ' Recursive call.
            End If
        End If
    End Sub

    Private Function IndexTree(ByVal index As Integer) As Integer
        If Not Me.LeftTree Is Nothing Then
            index = Me.LeftTree.IndexTree(index)
        End If

        Me.position = index

        Index += 1

        If Not Me.RightTree Is Nothing Then
            index = Me.RightTree.IndexTree(index)
        End If

        Return index
    End Function

    Private Function GetItemAtIndex(ByVal index As Integer) As Tree(Of TItem)
        ' Add the index values if they're not already there
        If Me.position = -1 Then
            Me.IndexTree(0)
        End If

        If Me.position > index Then
            Return Me.LeftTree.GetItemAtIndex(index)
        End If

        If Me.position < index Then
            Return Me.RightTree.GetItemAtIndex(index)
        End If

        Return Me
    End Function

    Private Function GetCount(ByVal accumulator As Integer) As Integer
        If Not Me.LeftTree Is Nothing Then
            accumulator = LeftTree.GetCount(accumulator)
        End If

        Accumulator += 1

        If Not Me.RightTree Is Nothing Then
            accumulator = RightTree.GetCount(accumulator)
        End If

        Return accumulator
    End Function
#End Region

    Public Sub Add1(ByVal item As TItem) Implements System.Collections.Generic.ICollection(Of TItem).Add
    End Sub

    Public Sub Clear() Implements System.Collections.Generic.ICollection(Of TItem).Clear
        LeftTree = Nothing
        RightTree = Nothing
        NodeData = Nothing
    End Sub

    Public Function Contains(ByVal item As TItem) As Boolean Implements System.Collections.Generic.ICollection(Of TItem).Contains
        If NodeData.CompareTo(item) = 0 Then
            Return True
        End If

        If NodeData.CompareTo(item) > 0 Then
            If Not Me.LeftTree Is Nothing Then
                Return Me.LeftTree.Contains(item)
            End If
        Else
            If Not Me.RightTree Is Nothing Then
                Return Me.RightTree.Contains(item)
            End If
        End If

        Return False
    End Function

    Public Sub CopyTo(ByVal array() As TItem, ByVal arrayIndex As Integer) Implements System.Collections.Generic.ICollection(Of TItem).CopyTo
        Throw New NotImplementedException
    End Sub

    Public ReadOnly Property Count As Integer Implements System.Collections.Generic.ICollection(Of TItem).Count
        Get
            Return Me.GetCount(0)
        End Get
    End Property

    Public ReadOnly Property IsReadOnly As Boolean Implements System.Collections.Generic.ICollection(Of TItem).IsReadOnly
        Get
            Return False
        End Get
    End Property

    Public Function RemoveItem(ByVal item As TItem) As Boolean Implements System.Collections.Generic.ICollection(Of TItem).Remove
        If Me.Contains(item) Then
            Me.RemoveItem(item)

            Return True
        End If

        Return False
    End Function

    ' TODO: - Update the Tree class to return the TreeEnumerator class.
    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of TItem) Implements System.Collections.Generic.IEnumerable(Of TItem).GetEnumerator

    End Function

    Public Function IndexOf(ByVal item As TItem) As Integer Implements System.Collections.Generic.IList(Of TItem).IndexOf
        If item Is Nothing Then Return -1

        ' Add the index values if they're not already there
        If Me.position = -1 Then
            Me.IndexTree(0)
        End If

        ' Find the item - searching the tree for a matching Node.
        If item.CompareTo(Me.NodeData) < 0 Then
            If Me.LeftTree Is Nothing Then
                Return -1
            End If

            Return Me.LeftTree.IndexOf(item)
        End If

        If item.CompareTo(Me.NodeData) > 0 Then
            If Me.RightTree Is Nothing Then
                Return -1
            End If

            Return Me.RightTree.IndexOf(item)
        End If

        Return Me.position
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal item As TItem) Implements System.Collections.Generic.IList(Of TItem).Insert
        Throw New NotImplementedException
    End Sub

    Default Public Property Item(ByVal index As Integer) As TItem Implements System.Collections.Generic.IList(Of TItem).Item
        Get
            If index < 0 OrElse index >= Count Then
                Throw New ArgumentOutOfRangeException("index", index, "Indexer out of range")
            End If

            Return GetItemAtIndex(index).NodeData
        End Get
        Set(ByVal value As TItem)

        End Set
    End Property

    Public Sub RemoveAt(ByVal index As Integer) Implements System.Collections.Generic.IList(Of TItem).RemoveAt
        Throw New NotImplementedException
    End Sub

    Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Throw New NotImplementedException
    End Function
End Class