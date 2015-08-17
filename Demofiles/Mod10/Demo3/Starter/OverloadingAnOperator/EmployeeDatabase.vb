Public Class EmployeeDatabase
    Private employees() As Employee
    Private topOfArray As Integer

    Public Sub New()
        ReDim employees(1000)
        topOfArray = 0
    End Sub

    Public Sub AddToDatabase(ByVal emp As Employee)
        employees(topOfArray) = emp
        topOfArray += 1
    End Sub

    Default Public ReadOnly Property Index(ByVal name As String) As Employee
        Get
            For Each emp As Employee In employees
                If emp.Name.Equals(name) Then
                    Return emp
                End If
            Next
            Return Nothing
        End Get
    End Property

    'Public Shared operator +(ByVal database As EmployeeDatabase, ByVal emp As Employee) As EmployeeDatabase 
    '    database.AddToDatabase(emp)
    '
    '    Return database
    'End Operator
End Class