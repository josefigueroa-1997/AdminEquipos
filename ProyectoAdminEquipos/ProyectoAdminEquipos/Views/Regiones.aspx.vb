
Imports System.Net.Http
Imports ProyectoAdminEquipos.Region
Imports System.Threading.Tasks
Imports System.Net
Imports System.Text
Imports Microsoft.Ajax.Utilities
Imports Newtonsoft.Json

Public Class Regiones
    Inherits System.Web.UI.Page

    Protected Async Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim regiones = Await ObtenerRegiones()
            GridView1.DataSource = regiones
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Async Function ObtenerRegiones() As Task(Of List(Of Region))
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

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nuevaregion As New Region()
        nuevaregion.Nombre = TextBox1.Text
        Dim jsonRegion As String = JsonConvert.SerializeObject(nuevaregion)
        Using httpclient As New HttpClient()
            Dim apiurl As String = "https://localhost:7127/Region/AddRegion"
            Dim content As New StringContent(jsonRegion, Encoding.UTF8, "application/json")
            Dim response = httpclient.PostAsync(apiurl, content).Result
            If response.IsSuccessStatusCode Then
                Dim mensaje = response.Content.ReadAsByteArrayAsync().Result
                Debug.WriteLine(mensaje)
            Else
                Dim mensajeError = response.Content.ReadAsStringAsync().Result
                Debug.Write($"Error al agregar la región: {mensajeError}")
            End If
        End Using
    End Sub
End Class