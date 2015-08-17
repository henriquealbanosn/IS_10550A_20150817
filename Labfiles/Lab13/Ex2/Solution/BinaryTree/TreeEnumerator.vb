Public Class TreeEnumerator(Of TItem As IComparable)
    Implements IEnumerator(Of TItem)

    Private currentData As Tree(Of TItem) = Nothing

    Private currentItem As TItem = Nothing

    Private enumData As Queue(Of TItem) = Nothing

    Public Sub New(ByVal data As Tree(Of TItem))
        Me.currentData = data
    End Sub

    Private Sub Populate(ByVal enumQueue As Queue(Of TItem), ByVal populatedTree As Tree(Of TItem))
        If Not populatedTree.LeftTree Is Nothing Then
            Populate(enumQueue, populatedTree.LeftTree)
        End If

        enumQueue.Enqueue(populatedTree.NodeData)

        If Not populatedTree.RightTree Is Nothing Then
            Populate(enumQueue, populatedTree.RightTree)
        End If
    End Sub

    Public ReadOnly Property Current As TItem Implements System.Collections.Generic.IEnumerator(Of TItem).Current
        Get
            If Me.enumData Is Nothing Then
                Throw New InvalidOperationException("Use MoveNext before calling Current")
            End If

            Return Me.currentItem
        End Get
    End Property

    Public ReadOnly Property Current1 As Object Implements System.Collections.IEnumerator.Current
        Get
            Return Me.Current
        End Get
    End Property

    Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        If Me.enumData Is Nothing Then
            Me.enumData = New Queue(Of TItem)()
            Populate(Me.enumData, Me.currentData)
        End If

        If Me.enumData.Count > 0 Then
            Me.currentItem = Me.enumData.Dequeue()

            Return True
        End If

        Return False
    End Function

    Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        Populate(Me.enumData, Me.currentData)
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                Me.enumData.Clear()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class