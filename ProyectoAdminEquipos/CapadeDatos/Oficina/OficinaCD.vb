Imports System.Net.Http
Imports System.Security.Cryptography
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

    Public Async Function ActualizarOficina(idoficina As Integer, idcomuna As Integer, nombreoficina As String) As Task
        Try
            Dim editaroficina As New Oficina()
            editaroficina.Nombre = nombreoficina
            editaroficina.ID_COMUNA = idcomuna
            Dim jsonoficina = JsonConvert.SerializeObject(editaroficina)
            Using httpclient As New HttpClient()
                Dim apiurl As String = $"https://localhost:7127/Oficina/UpdateOficina/{idoficina}"
                Dim content As New StringContent(jsonoficina, Encoding.UTF8, "application/json")
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

    Public Async Function EliminarOficina(idoficina As Integer) As Task
        Try
            Using httpclient As New HttpClient()
                Dim apiurl As String = $"https://localhost:7127/Oficina/DeleteOficina/{idoficina}"
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

    Public Function ObtenerRegionOficina(idoficina As Integer, oficinas As List(Of Oficina)) As Integer
        For Each i In oficinas
            If i.Id = idoficina Then
                Return i.ID_REGION
            End If
        Next
        Return Nothing
    End Function
    Public Function ObtenerComunaOficina(idoficina As Integer, oficinas As List(Of Oficina)) As String
        For Each i In oficinas
            If i.Id = idoficina Then
                Return i.NombreComuna
            End If
        Next
        Return Nothing
    End Function

End Class
