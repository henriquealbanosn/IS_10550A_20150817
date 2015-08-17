Module Module1
    Sub Main()
        Dim people As New SortedList()
        people.Add("Richard", New Person With {.Name = "Richard", .Age = 32})

        Dim louisa As New Person() With
        {
            .Name = "Louisa",
            .Age = 25
        }

        people.Add(louisa.Name, louisa)

        Dim personFromCollection As Person = CType(people("Richard"), Person)

        If Not personFromCollection Is Nothing Then
            Console.WriteLine("Name: {0}, Age: {1}", personFromCollection.Name, personFromCollection.Age.ToString())
        End If

        Console.ReadLine()

        For Each entry As DictionaryEntry In people
            Dim per As Person = CType(entry.Value, Person)
            Console.WriteLine("Name: {0}, Age: {1}", per.Name, per.Age.ToString())
        Next

        Console.ReadLine()
    End Sub
End Module