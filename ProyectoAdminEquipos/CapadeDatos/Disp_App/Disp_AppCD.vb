Imports System.Net.Http
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Serialization

Public Class Disp_AppCD

    Public Async Function ObtenerDispositivoAplicacion() As Task(Of List(Of Dis_App))
        Try
            Using httpclient As New HttpClient()
                Dim apiurl As String = "https://localhost:7127/DispositivoApp/GetDispositivoApp"
                Dim response = Await httpclient.GetAsync(apiurl)
                If response.IsSuccessStatusCode Then
                    Dim jsonstring = Await response.Content.ReadAsStringAsync()
                    Dim disapp = JsonConvert.DeserializeObject(Of List(Of Dis_App))(jsonstring)
                    Return disapp
                End If
            End Using
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Return Nothing
        End Try
        Return Nothing
    End Function


End Class
