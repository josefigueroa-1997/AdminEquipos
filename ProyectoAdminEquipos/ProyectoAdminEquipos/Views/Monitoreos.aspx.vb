Imports System.Reflection.Emit
Imports CapaNegocio
Public Class Monitoreos
    Inherits System.Web.UI.Page
    Private ReadOnly monitoreocn As New MonitoreoCN()
    Protected Async Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim id As Integer?
            If Not String.IsNullOrEmpty(Request.QueryString("id")) Then
                id = Integer.Parse(Request.QueryString("id"))
            End If
            Await CargarGridview(id)
        End If
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim index As Integer = GridView1.SelectedIndex
        If index >= 0 Then
            Dim id As Integer = Convert.ToInt32(GridView1.SelectedRow.Cells(1).Text)
            Response.Redirect("DetalleMonitoreo.aspx?Id=" & id)
        End If
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand


    End Sub
    Private Async Function CargarGridview(id As Integer?) As Threading.Tasks.Task
        Dim monitoreo = Await monitoreocn.ObtenerRegistroMonitoreoCN(id)
        GridView1.DataSource = monitoreo
        GridView1.DataBind()
    End Function


End Class