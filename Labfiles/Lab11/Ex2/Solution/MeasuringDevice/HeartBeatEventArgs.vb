Public Class HeartBeatEventArgs
    Inherits EventArgs

    Private heartBeatTimeStamp As DateTime
    Public Property TimeStamp As DateTime
        Get
            Return heartBeatTimeStamp
        End Get
        Private Set(ByVal value As DateTime)
            heartBeatTimeStamp = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()

        Me.TimeStamp = DateTime.Now
    End Sub

    Public Delegate Sub HeartBeatEventHandler(ByVal sender As Object, ByVal args As HeartBeatEventArgs)
End Class
