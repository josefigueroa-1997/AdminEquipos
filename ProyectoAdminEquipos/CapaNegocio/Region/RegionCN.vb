Imports System.Runtime.InteropServices
Imports CapadeDatos
Imports Newtonsoft.Json

Public Class RegionCN
    Private ReadOnly regioncd As New RegionCD()
    Public Async Function ObtenerregionesCN() As Task(Of List(Of Region))
        Return Await regioncd.ObtenerRegion()
    End Function
    Public Async Function AgregarRegionCN(nombre As String) As Task
        Await regioncd.AgregarRegion(nombre)
    End Function
    Public Async Function ActualizarRegionCN(id As Integer, nombre As String) As Task
        Await regioncd.UpdateRegion(id, nombre)
    End Function
    Public Async Function EliminarRegionCN(id As Integer) As Task
        Await regioncd.EliminarRegion(id)
    End Function
End Class
