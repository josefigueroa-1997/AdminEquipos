Imports CapadeDatos.Region
Imports System.Threading.Tasks
Imports System.Net
Imports System.Text
Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Reflection.Emit


Public Class RegionCD
    Public Async Function ObtenerRegion() As Task(Of List(Of Region))
        Try
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
            Using httpClient As New HttpClient()
                Dim apiurl As String = "https://localhost:7127/Region/GetRegiones"
                Dim response = Await httpClient.GetAsync(apiurl)
                If response.IsSuccessStatusCode Then

                    Dim jsonString = Await response.Content.ReadAsStringAsync()
                    Dim regiones = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of Region))(jsonString)
                    Return regiones
                Else
                    Return Nothing
                End If
                If Not response.IsSuccessStatusCode Then
                    Dim errorString = Await response.Content.ReadAsStringAsync()
                    Debug.WriteLine($"Error en la respuesta de la API: {errorString}")
                End If
            End Using
        Catch ex As HttpRequestException
            Debug.WriteLine($"Error al enviar la solicitud http:{ex.Message}")
            If ex.InnerException IsNot Nothing Then
                Debug.WriteLine($"InnerException: {ex.InnerException.Message}")
            End If
        End Try
        Return Nothing
    End Function

    Public Async Function AgregarRegion(nombre As String) As Task
        Try
            Dim nuevaregion As New Region()
            nuevaregion.Nombre = nombre
            Dim jsonRegion As String = JsonConvert.SerializeObject(nuevaregion)
            Using httpclient As New HttpClient()
                Dim apiurl As String = "https://localhost:7127/Region/AddRegion"
                Dim content As New StringContent(jsonRegion, Encoding.UTF8, "application/json")
                Dim response = Await httpclient.PostAsync(apiurl, content)
                If response.IsSuccessStatusCode Then
                    Dim mensaje = Await response.Content.ReadAsByteArrayAsync()
                    Debug.WriteLine(mensaje)
                Else
                    Dim mensajeError = response.Content.ReadAsStringAsync().Result
                    Debug.Write($"Error al agregar la región: {mensajeError}")
                End If
            End Using

        Catch ex As Exception
            Debug.WriteLine($"Error inesperado: {ex.Message}")
        End Try
    End Function
    Public Async Function UpdateRegion(idregion As Integer, nombre As String) As Task
        Try
            Dim actualizarregion As New Region()
            actualizarregion.Nombre = nombre
            Dim jsonregion As String = JsonConvert.SerializeObject(actualizarregion)
            Using httpclient As New HttpClient()
                Dim apiurl As String = $"https://localhost:7127/Region/UpdateRegion/{idregion}"
                Dim content As New StringContent(jsonregion, Encoding.UTF8, "application/json")
                Dim response = Await httpclient.PutAsync(apiurl, content)

                If response.IsSuccessStatusCode Then
                    Dim mensaje = Await response.Content.ReadAsStringAsync()
                    Debug.WriteLine(mensaje)

                Else
                    Dim mensajeerror = response.Content.ReadAsStringAsync()
                    Debug.WriteLine(mensajeerror)
                End If
            End Using
        Catch ex As Exception
            Debug.WriteLine($"Error inesperado: {ex.Message}")
        End Try
    End Function
    Public Async Function EliminarRegion(idregion As Integer) As Task
        Try
            Using httpclient As New HttpClient()
                Dim apiurl As String = $"https://localhost:7127/Region/DeleteRegion/{idregion}"
                Dim response = Await httpclient.DeleteAsync(apiurl)
                If response.IsSuccessStatusCode Then
                    Dim mensaje = Await response.Content.ReadAsStringAsync()
                    Debug.WriteLine(mensaje)
                End If
            End Using
        Catch ex As Exception
            Debug.WriteLine($"Error al eliminar la región:{ex.Message}")
        End Try
    End Function
End Class


