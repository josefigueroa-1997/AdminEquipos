Imports System.Reflection.Emit
Imports CapaNegocio

Public Class RegistrarMonitoreo
    Inherits System.Web.UI.Page
    Private ReadOnly dispappcn As New Disp_AppCN()
    Protected ReadOnly monitoreocn As New MonitoreoCN()
    Protected Async Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Await CargarGridview()
            cargarddls()
        End If
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        If GridView1.SelectedIndex >= 0 Then
            TextBox1.Text = GridView1.SelectedRow.Cells(1).Text
        End If
    End Sub
    Protected Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim iddispositivo As Integer = Convert.ToInt32(TextBox1.Text)
        Dim estadocpu As String = ddlcpu.SelectedValue
        Dim estadoram As String = ddlram.SelectedValue
        Dim estadodisco As String = ddldiscoduro.SelectedValue
        Dim estadoapp As String = ddlapp.SelectedValue
        Await monitoreocn.RegistrarMonitoreoCN(iddispositivo, estadocpu, estadoram, estadodisco, estadoapp)
        Response.Redirect("Monitoreos.aspx")
    End Sub

    Private Async Function CargarGridview() As Threading.Tasks.Task
        Dim dispapp = Await dispappcn.ObtenerDispositivoAplicacionCN()
        GridView1.DataSource = dispapp
        GridView1.DataBind()
    End Function

    Private Sub cargarddls()
        ddlcpu.Items.Add(New ListItem("Correcto", "Correcto"))
        ddlcpu.Items.Add(New ListItem("Problema", "Problema"))
        ddlcpu.Items.Add(New ListItem("No tiene Solución", "No Tiene Solución"))
        ddlram.Items.Add(New ListItem("Correcto", "Correcto"))
        ddlram.Items.Add(New ListItem("Problema", "Problema"))
        ddlram.Items.Add(New ListItem("No tiene Solución", "No Tiene Solución"))
        ddldiscoduro.Items.Add(New ListItem("Correcto", "Correcto"))
        ddldiscoduro.Items.Add(New ListItem("Problema", "Problema"))
        ddldiscoduro.Items.Add(New ListItem("No tiene Solución", "No Tiene Solución"))
        ddlapp.Items.Add(New ListItem("Correcto", "Correcto"))
        ddlapp.Items.Add(New ListItem("Problema", "Problema"))
        ddlapp.Items.Add(New ListItem("No tiene Solución", "No Tiene Solución"))
    End Sub


End Class