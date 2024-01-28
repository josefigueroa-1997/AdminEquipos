Imports CapadeDatos

Public Class OficinaCN

    Private ReadOnly oficinacd As New OficinaCD()

    Public Async Function AgregarOficinaCN(nombre As String, idcomuna As Integer) As Task
        Await oficinacd.AgregarOficina(nombre, idcomuna)
    End Function

    Public Async Function ObtenerOficinas(id As Integer?) As Task(Of List(Of Oficina))
        Return Await oficinacd.ObtenerOficinas(id)
    End Function

    Public Async Function ActualizarOficinaCN(idoficina As Integer, idcomuna As Integer, nombreoficina As String) As Task
        Await oficinacd.ActualizarOficina(idoficina, idcomuna, nombreoficina)
    End Function
    Public Async Function EliminarOficinaCN(idoficina As Integer) As Task
        Await oficinacd.EliminarOficina(idoficina)
    End Function
    Public Function ObtenerRegionOficinaCN(idoficina As Integer, oficinas As List(Of Oficina)) As Integer
        Return oficinacd.ObtenerRegionOficina(idoficina, oficinas)
    End Function
    Public Function ObtenerComunaOficinaCN(idoficina As Integer, oficinas As List(Of Oficina)) As String
        Return oficinacd.ObtenerComunaOficina(idoficina, oficinas)
    End Function
End Class
