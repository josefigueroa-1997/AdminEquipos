Imports CapadeDatos

Public Class DispositivoCN

    Private ReadOnly dispositivocd As New DispositivoCD()

    Public Async Function ObtenerDispositivoCN(id As Integer?) As Task(Of List(Of Dispositivo))
        Return Await dispositivocd.ObtenerDispositivos(id)
    End Function

    Public Async Function AgregarDispositivoCN(idoficina As Integer, tipodispositivo As String, cpu As String, ram As String, discoduro As String) As Task
        Await dispositivocd.AgregarDispositivo(idoficina, tipodispositivo, cpu, ram, discoduro)
    End Function

    Public Async Function ActualizarDispositivoCN(iddispositivo As Integer, idoficina As Integer, tipodispositivo As String, cpu As String, ram As String, discoduro As String) As Task
        Await dispositivocd.ActualizarDispositivo(iddispositivo, idoficina, tipodispositivo, cpu, ram, discoduro)
    End Function

    Public Async Function EliminarDispositivoCN(id As Integer) As Task
        Await dispositivocd.EliminarDispositivo(id)
    End Function


End Class
