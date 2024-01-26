Imports CapadeDatos

Public Class OficinaCN

    Private ReadOnly oficinacd As New OficinaCD()

    Public Async Function AgregarOficinaCN(nombre As String, idcomuna As Integer) As Task
        Await oficinacd.AgregarOficina(nombre, idcomuna)
    End Function

    Public Async Function ObtenerOficinas(id As Integer?) As Task(Of List(Of Oficina))
        Return Await oficinacd.ObtenerOficinas(id)
    End Function

End Class
