Namespace ControlRegisterIndexing
    Public Structure ControlRegister
        Private regData As Integer

        ''' <summary>
        ''' Enables direct access to the registerData field.
        ''' </summary>
        Public Property RegisterData As Integer
            Get
                Return regData
            End Get
            Set(ByVal value As Integer)
                regData = value
            End Set
        End Property

        Default Public Property Index(ByVal idx As Integer) As Integer
            Get
                Dim isSet As Boolean = (RegisterData And (1 << idx)) <> 0

                Return If(isSet, 1, 0)
            End Get
            Set(ByVal value As Integer)
                If value <> 0 AndAlso value <> 1 Then
                    Throw New ArgumentException("Argument must be 1 or 0")
                End If

                If value = 1 Then
                    RegisterData = RegisterData Or (1 << idx)
                Else
                    RegisterData = RegisterData And Not (1 << idx)
                End If
            End Set
        End Property
    End Structure
End Namespace