Imports CapadeDatos.Comuna
Imports System.Threading.Tasks
Imports System.Net
Imports System.Text
Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Reflection.Emit

Public Class ComunaCD

    Public Async Function ObtenerComunas(id As Integer?, idregion As Integer?) As Task(Of List(Of Comuna))
        Try
            Using httpclient As New HttpClient()
                Dim apiurl As String = $"https://localhost:7127/Comuna/GetComunas?id={id}&idregion={idregion}"
                Dim response = Await httpclient.GetAsync(apiurl)
                If response.IsSuccessStatusCode Then
                    Dim jsonstring = Await response.Content.ReadAsStringAsync()
                    Dim comunas = JsonConvert.DeserializeObject(Of List(Of Comuna))(jsonstring)
                    Return comunas
                End If
            End Using
        Catch ex As HttpRequestException
            Debug.WriteLine($"Error al enviar la solicitud http:{ex.Message}")
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Async Function AgregarComuna(idregion As Integer, nombre As String) As Task
        Try
            Dim nuevacomuna As New Comuna()
            nuevacomuna.ID_REGION = idregion
            nuevacomuna.Nombre = nombre
            Dim jsonComuna As String = JsonConvert.SerializeObject(nuevacomuna)
            Using httpclient As New HttpClient()
                Dim apiurl As String = "https://localhost:7127/Comuna/AddComuna"
                Dim content As New StringContent(jsonComuna, Encoding.UTF8, "application/json")
                Dim response = Await httpclient.PostAsync(apiurl, content)
                If response.IsSuccessStatusCode Then
                    Dim mensaje = Await response.Content.ReadAsStringAsync()
                    Debug.WriteLine(mensaje)
                Else
                    Dim mensajeerror = Await response.Content.ReadAsStringAsync()
                    Debug.WriteLine(mensajeerror)
                End If
            End Using
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Function

    Public Async Function EditarComuna(idcomuna As Integer, idregion As Integer, nombre As String) As Task
        Dim actualizarcomuna As New Comuna()
        actualizarcomuna.ID_REGION = idregion
        actualizarcomuna.Nombre = nombre
        Dim jsoncomuna = JsonConvert.SerializeObject(actualizarcomuna)
        Using httpclient As New HttpClient()
            Dim apiurl As String = $"https://localhost:7127/Comuna/UpdateComuna/{idcomuna}"
            Dim content As New StringContent(jsoncomuna, Encoding.UTF8, "application/json")
            Dim response = Await httpclient.PutAsync(apiurl, content)
            If response.IsSuccessStatusCode Then
                Dim mensaje = Await response.Content.ReadAsStringAsync()
                Debug.WriteLine(mensaje)
            Else
                Dim mensajeerror = Await response.Content.ReadAsStringAsync()
                Debug.WriteLine(mensajeerror)
            End If
        End Using
    End Function

    Public Async Function EliminarComuna(idcomuna As Integer) As Task
        Try
            Using httpclient As New HttpClient()
                Dim apiurl = $"https://localhost:7127/Comuna/DeleteComuna/{idcomuna}"
                Dim response = Await httpclient.DeleteAsync(apiurl)
                If response.IsSuccessStatusCode Then
                    Dim mensaje = response.Content.ReadAsStringAsync()
                    Debug.WriteLine(mensaje)
                Else
                    Dim mensaejerror = response.Content.ReadAsStringAsync()
                    Debug.WriteLine(mensaejerror)
                End If
            End Using

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Function

End Class
