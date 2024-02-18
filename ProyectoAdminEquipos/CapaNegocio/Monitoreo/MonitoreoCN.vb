Imports System.Runtime.InteropServices
Imports CapadeDatos
Public Class MonitoreoCN
    Private ReadOnly monitoreocd As New MonitoreoCD()

    Public Async Function ObtenerRegistroMonitoreoCN(id As Integer?) As Task(Of List(Of Monitoreo))
        Return Await monitoreocd.ObtenerRegistroMonitoreo(id)
    End Function
    Public Async Function RegistrarMonitoreoCN(iddispositivo As Integer, estadocpu As String, estadoram As String, estadodisco As String, estadoapp As String) As Task
        Await monitoreocd.RegistrarMonitoreo(iddispositivo, estadocpu, estadoram, estadodisco, estadoapp)
    End Function
    Public Async Function ActualizarRegistroMonitoreoCN(id As Integer, iddispositivo As Integer, estadocpu As String, estadoram As String, estadodisco As String, estadoapp As String) As Task
        Await monitoreocd.ActualizarRegistroMonitoreo(id, iddispositivo, estadocpu, estadoram, estadodisco, estadoapp)
    End Function
    Public Async Function EliminarRegistroMonitoreoCN(id As Integer) As Task
        Await monitoreocd.EliminarRegistroMonitoreo(id)
    End Function
End Class
