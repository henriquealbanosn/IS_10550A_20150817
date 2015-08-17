Public Class Employee
    Public Property Name As String
    Private empSalary As Integer
    Public Property Department As String

    Public Sub New(ByVal name As String)
        Me.Name = name
        ' Set default values for properties not passed ot the constructor.
        Me.empSalary = 10000
        Me.Department = "Customer Service"
    End Sub

    Public Property Salary As Integer
        Get
            Return Me.empSalary
        End Get
        Set(ByVal value As Integer)
            If value >= 0 Then
                Me.empSalary = value
            Else
                Me.empSalary = 0
            End If
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return String.Format("{0} earns ${1} and is in the {2} department.", Me.Name, Me.Salary.ToString(), Department.ToLower())
    End Function
End Class
