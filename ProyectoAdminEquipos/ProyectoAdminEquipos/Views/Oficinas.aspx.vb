
Imports CapaNegocio

Imports System.Threading.Tasks
Public Class Oficinas
    Inherits System.Web.UI.Page
    Private ReadOnly comunacn As New ComunaCN()
    Private ReadOnly regioncn As New RegionCN()
    Private ReadOnly oficinacn As New OficinaCN()
    Protected Async Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Await CargarDropDownList()
            Dim id As Integer?
            If Not String.IsNullOrEmpty(Request.QueryString("id")) Then
                id = Integer.Parse(Request.QueryString("id"))
            End If
            Await cargargridview(id)
            Await CargarddlComunas(id, ddlRegiones.SelectedValue)
        End If
    End Sub
    Protected Async Sub ddlRegiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlRegiones.SelectedIndexChanged
        Dim id As Integer?
        If Not String.IsNullOrEmpty(Request.QueryString("id")) Then
            id = Integer.Parse(Request.QueryString("id"))
        End If
        Await CargarddlComunas(id, ddlRegiones.SelectedValue)
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        If GridView1.SelectedIndex >= 0 Then
            Dim idoficina As Integer = Convert.ToInt32(GridView1.SelectedRow.Cells(1).Text)
            ViewState("IdSeleccionado") = idoficina
            Dim nombreoficina As String = GridView1.SelectedRow.Cells(2).Text
            TextBox1.Text = nombreoficina
            Dim idcomuna As Integer = Convert.ToInt32(GridView1.SelectedRow.Cells(3).Text)
            Dim idregiones As Integer = Convert.ToInt32(GridView1.SelectedRow.Cells(5).Text)
            ddlRegiones.SelectedValue = idregiones
            ddlComunas.SelectedValue = idcomuna
        End If
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand


    End Sub
    Private Async Function cargargridview(id As Integer?) As Task
        Dim oficinas = Await oficinacn.ObtenerOficinas(id)
        GridView1.DataSource = oficinas
        GridView1.DataBind()
    End Function
    Protected Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nombreoficina As String = TextBox1.Text
        Debug.WriteLine(nombreoficina)
        Dim idcomuna As Integer = ddlComunas.SelectedItem.Value
        Debug.WriteLine(idcomuna)
        Await oficinacn.AgregarOficinaCN(nombreoficina, idcomuna)
        TextBox1.Text = ""
        ddlRegiones.SelectedIndex = 0
        Dim id As Integer?
        If Not String.IsNullOrEmpty(Request.QueryString("id")) Then
            id = Integer.Parse(Request.QueryString("id"))
        End If
        Await cargargridview(id)
    End Sub
    Private Async Function CargarDropDownList() As Task
        Dim regiones = Await regioncn.ObtenerregionesCN()
        ddlRegiones.DataSource = regiones
        ddlRegiones.DataValueField = "Id"
        ddlRegiones.DataTextField = "Nombre"
        ddlRegiones.DataBind()
    End Function
    Public Async Function CargarddlComunas(idcomunas As Integer?, idregion As Integer?) As Task
        Dim comunas = Await comunacn.ObtenerComunasCN(idcomunas, idregion)
        ddlComunas.DataSource = comunas
        ddlComunas.DataValueField = "Id"
        ddlComunas.DataTextField = "Nombre"
        ddlComunas.DataBind()
    End Function


End Class