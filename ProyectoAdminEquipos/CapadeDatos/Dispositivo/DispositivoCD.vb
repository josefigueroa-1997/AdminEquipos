Imports System.ComponentModel
Imports System.Net.Http
Imports System.Runtime.InteropServices
Imports System.Text
Imports Newtonsoft.Json

Public Class DispositivoCD

    Public Async Function ObtenerDispositivos(id As Integer?) As Task(Of List(Of Dispositivo))
        Try
            Using httpclient As New HttpClient()
                Dim apiurl As String = $"https://localhost:7127/Dispositivo/GetDispositivos/{id}"
                Dim response = Await httpclient.GetAsync(apiurl)
                If response.IsSuccessStatusCode Then
                    Dim jsonstring = Await response.Content.ReadAsStringAsync()
                    Dim dispositivo = JsonConvert.DeserializeObject(Of List(Of Dispositivo))(jsonstring)
                    Return dispositivo
                End If
            End Using
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Async Function AgregarDispositivo(idoficina As Integer, tipodispositivo As String, cpu As String, ram As String, discoduro As String) As Task
        Try
            Dim nuevodispositivo As New Dispositivo()
            nuevodispositivo.Id_oficina = idoficina
            nuevodispositivo.tipodispositivo = tipodispositivo
            nuevodispositivo.cpu = cpu
            nuevodispositivo.ram = ram
            nuevodispositivo.disco_duro = discoduro
            Dim jsonstring As String = JsonConvert.SerializeObject(nuevodispositivo)
            Using httpclient As New HttpClient()
                Dim apiurl As String = "https://localhost:7127/Dispositivo/AddDispositivo"
                Dim content As New StringContent(jsonstring, Encoding.UTF8, "application/json")
                Dim response = Await httpclient.PostAsync(apiurl, content)
                If response.IsSuccessStatusCode Then
                    Dim mensaje = response.Content.ReadAsStringAsync()
                    Debug.WriteLine(mensaje)
                Else
                    Dim mensajerror = response.Content.ReadAsStringAsync()
                    Debug.WriteLine(mensajerror)
                End If
            End Using
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Function

    Public Async Function ActualizarDispositivo(iddispositivo As Integer, idoficina As Integer, tipodispositivo As String, cpu As String, ram As String, discoduro As String) As Task
        Try
            Dim actualizardisp As New Dispositivo()
            actualizardisp.Id_oficina = idoficina
            actualizardisp.tipodispositivo = tipodispositivo
            actualizardisp.cpu = cpu
            actualizardisp.ram = ram
            actualizardisp.disco_duro = discoduro
            Dim jsondispositivo As String = JsonConvert.SerializeObject(actualizardisp)
            Using httpclient As New HttpClient()
                Dim apiurl As String = $"https://localhost:7127/Dispositivo/UpdateDispositivo/{iddispositivo}"
                Dim content As New StringContent(jsondispositivo, Encoding.UTF8, "application/json")
                Dim response = Await httpclient.PutAsync(apiurl, content)
                If response.IsSuccessStatusCode Then
                    Dim mensaje = response.Content.ReadAsStringAsync()
                    Debug.WriteLine(mensaje)
                Else
                    Dim mensajeerror = response.Content.ReadAsStringAsync()
                    Debug.WriteLine(mensajeerror)
                End If
            End Using
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Function

    Public Async Function EliminarDispositivo(id As Integer) As Task
        Try
            Using httpclient As New HttpClient
                Dim apiurl As String = $"https://localhost:7127/Dispositivo/UpdateDispositivo/{id}"
                Dim response = Await httpclient.DeleteAsync(apiurl)
                If response.IsSuccessStatusCode Then
                    Dim mensaje = response.Content.ReadAsStringAsync()
                    Debug.WriteLine(mensaje)
                Else
                    Dim mensajeerror = response.Content.ReadAsStringAsync()
                    Debug.WriteLine(mensajeerror)
                End If
            End Using
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Function

End Class
