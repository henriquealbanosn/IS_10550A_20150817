Imports FabrikamUserManagement.DataAccess.UserManagement

Module Module1
    Sub Main()
        Dim usr As User = Nothing

        Try
            usr = Users.GetUserById(5)

            Console.WriteLine(usr.UserName)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Console.ReadKey()
    End Sub
End Module