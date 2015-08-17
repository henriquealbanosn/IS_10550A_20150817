Imports System.Threading

Public Class HeartBeat
    Public Event Beat(ByVal sender As Object, ByVal e As HeartbeatEventArgs)

    Private beatStop As Boolean = False
    Private count As Integer

    Public Sub New()
        count = 0
    End Sub

    Public Sub Start()
        Dim beatThread As New Thread(New ThreadStart(Sub()
                                                         While Not beatStop
                                                             OnBeat(Me, New HeartbeatEventArgs(count))
                                                             count += 1
                                                             Thread.Sleep(3000)
                                                         End While
                                                     End Sub))

        beatThread.Start()
    End Sub

    Public Sub [Stop]()
        beatStop = True
    End Sub

    Protected Overridable Sub OnBeat(ByVal sender As Object, ByVal e As HeartbeatEventArgs)
        RaiseEvent Beat(sender, e)
    End Sub
End Class

Public Class HeartbeatEventArgs
    Inherits EventArgs

    Public Sub New(ByVal count As Integer)
        MyBase.New()

        Me.Count = count
    End Sub

    Public Property Count As Integer
End Class