
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Net
Imports System.Text
Imports Microsoft.Ajax.Utilities
Imports Newtonsoft.Json
Imports CapaNegocio
Public Class Regiones
    Inherits System.Web.UI.Page
    Private ReadOnly regioncn As New RegionCN()
    Protected Async Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Await CargarGridview()
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        If GridView1.SelectedIndex >= 0 Then
            Dim idRegion As Integer = Convert.ToInt32(GridView1.SelectedRow.Cells(1).Text)
            Dim nombreregion As String = GridView1.SelectedRow.Cells(2).Text
            TextBox1.Text = nombreregion
            ViewState("SelectedRegionId") = idRegion
            UpdateButton.Visible = True
        End If
    End Sub
    Protected Async Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Eliminar" Then
            Dim ideliminar As Integer = Convert.ToInt32(e.CommandArgument)
            Await regioncn.EliminarRegionCN(ideliminar)
            Await CargarGridview()
        End If
    End Sub

    Protected Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nombre As String = TextBox1.Text
        Await regioncn.AgregarRegionCN(nombre)
        TextBox1.Text = ""
        Await CargarGridview()
    End Sub

    Private Async Function CargarGridview() As Task
        Dim regiones = Await regioncn.ObtenerregionesCN()
        GridView1.DataSource = regiones
        GridView1.DataBind()
    End Function

    Protected Async Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        Dim idregion As Integer = Convert.ToInt32(ViewState("SelectedRegionId"))
        Dim nombrenuevoregion As String = TextBox1.Text
        Await regioncn.ActualizarRegionCN(idregion, nombrenuevoregion)
        TextBox1.Text = ""
        UpdateButton.Visible = False
        Await CargarGridview()
    End Sub

End Class