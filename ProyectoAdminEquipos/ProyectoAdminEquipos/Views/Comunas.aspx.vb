Imports CapaNegocio
Imports System.Threading.Tasks
Public Class Comunas
    Inherits System.Web.UI.Page
    Protected ReadOnly comunacn As New ComunaCN()
    Protected ReadOnly regioncn As New RegionCN()
    Protected Async Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim id As Integer?

            If Not String.IsNullOrEmpty(Request.QueryString("id")) Then
                id = Integer.Parse(Request.QueryString("id"))
            End If

            Await CargarGridView(id)
            Await CargarDropDownList()
        End If
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        If GridView1.SelectedIndex >= 0 Then
            Dim idComuna As Integer = Convert.ToInt32(GridView1.SelectedRow.Cells(1).Text)
            Dim nombreregion As String = GridView1.SelectedRow.Cells(2).Text
            Dim idRegion As Integer = Convert.ToInt32(GridView1.SelectedRow.Cells(3).Text)
            ddlRegiones.SelectedValue = idRegion
            TextBox1.Text = nombreregion
            ViewState("SelectedComunaId") = idComuna

            UpdateButton.Visible = True
        End If
    End Sub
    Protected Async Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Eliminar" Then
            Dim ideliminar As Integer = Convert.ToInt32(e.CommandArgument)
            Await comunacn.EliminarComunaCN(ideliminar)
            Dim id As Integer?
            If Not String.IsNullOrEmpty(Request.QueryString("id")) Then
                id = Integer.Parse(Request.QueryString("id"))
            End If
            Await CargarGridView(id)
        End If
    End Sub
    Protected Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nombre = TextBox1.Text
        Dim selectedvalue = ddlRegiones.SelectedItem().Value.ToString()
        Dim idregion As Integer = Integer.Parse(selectedvalue)
        Await comunacn.AgregarComunaCN(idregion, nombre)
        TextBox1.Text = ""
        ddlRegiones.SelectedIndex = 0
        Dim id As Integer?
        If Not String.IsNullOrEmpty(Request.QueryString("id")) Then
            id = Integer.Parse(Request.QueryString("id"))
        End If
        Await CargarGridView(id)
    End Sub
    Private Async Function CargarGridView(id As Integer?) As Task
        Dim comunas = Await comunacn.ObtenerComunasCN(id)
        GridView1.DataSource = comunas
        GridView1.DataBind()
    End Function
    Private Async Function CargarDropDownList() As Task
        Dim regiones = Await regioncn.ObtenerregionesCN()
        ddlRegiones.DataSource = regiones
        ddlRegiones.DataValueField = "Id"
        ddlRegiones.DataTextField = "Nombre"
        ddlRegiones.DataBind()
    End Function

    Protected Async Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        Dim idcomuna As Integer = Convert.ToInt32(ViewState("SelectedComunaId"))
        Dim idregion As Integer = ddlRegiones.SelectedItem.Value
        Dim nombrecomuna As String = TextBox1.Text
        Await comunacn.ActualizarComunaCN(idcomuna, idregion, nombrecomuna)
        TextBox1.Text = ""
        ddlRegiones.SelectedIndex = 0
        Dim id As Integer?
        If Not String.IsNullOrEmpty(Request.QueryString("id")) Then
            id = Integer.Parse(Request.QueryString("id"))
        End If
        UpdateButton.Visible = False
        Await CargarGridView(id)
    End Sub

End Class