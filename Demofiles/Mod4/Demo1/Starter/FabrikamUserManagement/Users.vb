Namespace DataAccess.UserManagement
    Public Class Users
        Public Shared Function GetUserById(ByVal userId As Integer) As User
            Dim result As User = Nothing

            Dim allUsers As List(Of User) = GetAllUsers()

            If allUsers.Exists(Function(usr) usr.UserId = userId) Then
                result = (From users In allUsers
                          Where users.UserId = userId
                          Select users).Single()
            End If

            Return result
        End Function

        Private Shared Function GetAllUsers() As List(Of User)
            Return New List(Of User) From
            {
                New User(1, "Peter", "Roberts"),
                New User(2, "Eric", "Hunter"),
                New User(3, "Sam", "Williams"),
                New User(4, "Derek", "Jones")
            }
        End Function
    End Class
End Namespace