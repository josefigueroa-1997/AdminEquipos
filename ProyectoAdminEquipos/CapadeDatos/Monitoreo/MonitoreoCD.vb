
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class MonitoreoCD

    Public Async Function ObtenerRegistroMonitoreo(id As Integer?) As Task(Of List(Of Monitoreo))
        Try
            Using httpclient As New HttpClient()
                Dim apiurl As String = $"https://localhost:7127/Monitoreo/GetMonitoreo/{id}"
                Dim response = Await httpclient.GetAsync(apiurl)
                If response.IsSuccessStatusCode Then
                    Dim jsonstring = Await response.Content.ReadAsStringAsync()
                    Dim monitoreo = JsonConvert.DeserializeObject(Of List(Of Monitoreo))(jsonstring)
                    Return monitoreo
                End If
            End Using
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Return Nothing
        End Try

        Return Nothing
    End Function

    Public Async Function RegistrarMonitoreo(iddispositivo As Integer, estadocpu As String, estadoram As String, estadodisco As String, estadoapp As String) As Task
        Try
            Dim nuevomonitoreo As New Monitoreo()
            nuevomonitoreo.ID_DISPOSITIVO_APP = iddispositivo
            nuevomonitoreo.ESTADO_CPU = estadocpu
            nuevomonitoreo.ESTADO_RAM = estadoram
            nuevomonitoreo.ESTADO_DISCODURO = estadodisco
            nuevomonitoreo.ESTADO_APLICACION = estadoapp
            Dim jsonmonitoreo As String = JsonConvert.SerializeObject(nuevomonitoreo)
            Using httpclient As New HttpClient()
                Dim apiurl As String = "https://localhost:7127/Monitoreo/AddMonitoreo"
                Dim content As New StringContent(jsonmonitoreo, Encoding.UTF8, "application/json")
                Dim response = Await httpclient.PostAsync(apiurl, content)
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

    Public Async Function ActualizarRegistroMonitoreo(id As Integer, iddispositivo As Integer, estadocpu As String, estadoram As String, estadodisco As String, estadoapp As String) As Task
        Try
            Dim monitoreo As New Monitoreo()
            monitoreo.ID_DISPOSITIVO_APP = iddispositivo
            monitoreo.ESTADO_CPU = estadocpu
            monitoreo.ESTADO_RAM = estadoram
            monitoreo.ESTADO_DISCODURO = estadodisco
            monitoreo.ESTADO_APLICACION = estadoapp
            Dim jsonmonitoreo = JsonConvert.SerializeObject(monitoreo)

            Using httpclient As New HttpClient()
                Dim apiurl As String = $"https://localhost:7127/Monitoreo/UpdateMonitoreo/{id}"
                Dim content As New StringContent(jsonmonitoreo, Encoding.UTF8, "application/json")
                Dim response = Await httpclient.PutAsync(apiurl, content)

                If response.IsSuccessStatusCode Then
                    Dim mensaje = Await response.Content.ReadAsStringAsync()
                    Debug.WriteLine("La actualización fue exitosa: " & mensaje)
                Else
                    Dim mensajeError = Await response.Content.ReadAsStringAsync()
                    Debug.WriteLine("Error al actualizar el registro de monitoreo: " & mensajeError)
                    ' Lanzar la excepción para que pueda ser manejada por el código que llamó a este método
                    Throw New Exception("La solicitud de actualización no fue exitosa.")
                End If
            End Using
        Catch ex As Exception
            ' Manejar y registrar la excepción
            Debug.WriteLine("Error al actualizar el registro de monitoreo: " & ex.Message)
            ' Lanzar la excepción nuevamente para que pueda ser manejada por el código que llamó a este método
            Throw
        End Try
    End Function

    Public Async Function EliminarRegistroMonitoreo(id As Integer) As Task
        Try
            Using httpclient As New HttpClient()
                Dim apiurl As String = $"https://localhost:7127/Monitoreo/DeleteMonitoreo/{id}"
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
