Imports System.Net.Http
Imports System.Text
Imports CapadeDatos.Oficina
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Serialization

Public Class OficinaCD

    Public Async Function AgregarOficina(nombre As String, idcomuna As Integer) As Task
        Try
            Dim nuevaoficina As New Oficina()
            nuevaoficina.Nombre = nombre
            nuevaoficina.ID_COMUNA = idcomuna
            Dim jsonoficina As String = JsonConvert.SerializeObject(nuevaoficina)
            Using httpclient As New HttpClient()
                Dim apiurl As String = "https://localhost:7127/Oficina/AddOficina"
                Dim content As New StringContent(jsonoficina, Encoding.UTF8, "application/json")
                Dim response = Await httpclient.PostAsync(apiurl, content)
                If response.IsSuccessStatusCode Then
                    Dim mensaje = Await response.Content.ReadAsStringAsync()
                    Debug.WriteLine(mensaje)
                Else
                    Dim mensajeerror = response.Content.ReadAsStringAsync()
                End If
            End Using
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

    End Function

    Public Async Function ObtenerOficinas(id As Integer?) As Task(Of List(Of Oficina))
        Try
            Using httpclient As New HttpClient()
                Dim apiurl As String = $"https://localhost:7127/Oficina/GetOficinas/{id}"
                Dim response = Await httpclient.GetAsync(apiurl)
                If response.IsSuccessStatusCode Then
                    Dim jsonstring = Await response.Content.ReadAsStringAsync()
                    Dim oficinas = JsonConvert.DeserializeObject(Of List(Of Oficina))(jsonstring)
                    Return oficinas
                End If
            End Using
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Return Nothing
        End Try
        Return Nothing
    End Function



End Class
