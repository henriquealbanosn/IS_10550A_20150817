Namespace DataAccess.UserManagement
    Public Class User
        Public Property UserId As Integer
        Public Property UserName As String
        Public Property FirstName As String
        Public Property LastName As String

        Sub New(ByVal userId As Integer, ByVal firstName As String, ByVal lastName As String)
            Me.UserId = userId
            Me.FirstName = firstName
            Me.LastName = lastName
            Me.UserName = String.Format("{0}.{1}", firstName, lastName)
        End Sub
    End Class
End Namespace
