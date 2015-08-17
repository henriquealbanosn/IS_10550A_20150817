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
                regData = Value
            End Set
        End Property

        ' TODO: Add an indexer to enable access to individual bits in the control register.
    End Structure
End Namespace