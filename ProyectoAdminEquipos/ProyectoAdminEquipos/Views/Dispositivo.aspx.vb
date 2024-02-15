Imports CapaNegocio
Imports System.EnterpriseServices
Imports System.Reflection.Emit
Imports System.Runtime.InteropServices
Imports System.Threading.Tasks

Public Class Dispositivo
    Inherits System.Web.UI.Page
    Private ReadOnly dispositivocn As New DispositivoCN()
    Private ReadOnly oficinacn As New OficinaCN()
    Protected Async Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim id As Integer?
            If Not String.IsNullOrEmpty(Request.QueryString("id")) Then
                id = Integer.Parse(Request.QueryString("id"))
            End If
            Await Cargargridview(id)
            Await cargarddloficinas(id)
        End If
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        If GridView1.SelectedIndex >= 0 Then
            Dim iddispositivo As Integer = Convert.ToInt32(GridView1.SelectedRow.Cells(1).Text)
            ViewState("idseleccionado") = iddispositivo
            txtcpu.Text = GridView1.SelectedRow.Cells(5).Text
            txtram.Text = GridView1.SelectedRow.Cells(6).Text
            txtdiscoduro.Text = GridView1.SelectedRow.Cells(7).Text
            ddlOficina.SelectedValue = Convert.ToInt32(GridView1.SelectedRow.Cells(2).Text)
            tipodispositivo.SelectedValue = GridView1.SelectedRow.Cells(4).Text
            UpdateButton.Visible = True
        End If
    End Sub
    Protected Async Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Eliminar" Then
            Dim iddispositivo As Integer = Convert.ToInt32(e.CommandArgument)
            Await EliminarDispositivo(iddispositivo)
            LimpiarParam()
        End If

    End Sub

    Private Async Function cargarddloficinas(id As Integer?) As Task
        Dim oficina = Await oficinacn.ObtenerOficinas(id)
        ddlOficina.DataSource = oficina
        ddlOficina.DataTextField = "Nombre"
        ddlOficina.DataValueField = "Id"
        ddlOficina.DataBind()
    End Function


    Private Async Function Cargargridview(id As Integer?) As Task
        Dim dispositivos = Await dispositivocn.ObtenerDispositivoCN(id)
        GridView1.DataSource = dispositivos
        GridView1.DataBind()
    End Function
    Protected Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim idoficina As Integer = ddlOficina.SelectedValue
        Dim tipodispositivoseleccionado As String = tipodispositivo.SelectedValue
        Dim cpu As String = txtcpu.Text
        Dim ram As String = txtram.Text
        Dim discoduro As String = txtdiscoduro.Text
        Await dispositivocn.AgregarDispositivoCN(idoficina, tipodispositivoseleccionado, cpu, ram, discoduro)
        LimpiarParam()
    End Sub

    Protected Async Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        Dim iddispositivo As Integer = Convert.ToInt32(ViewState("idseleccionado"))
        Dim idoficina As Integer = ddlOficina.SelectedValue
        Dim tipodisp As String = tipodispositivo.SelectedValue
        Dim cpu As String = txtcpu.Text
        Dim ram As String = txtram.Text
        Dim discoduro As String = txtdiscoduro.Text
        Await dispositivocn.ActualizarDispositivoCN(iddispositivo, idoficina, tipodisp, cpu, ram, discoduro)
        LimpiarParam()
    End Sub

    Private Async Function EliminarDispositivo(id As Integer) As Task
        Await dispositivocn.EliminarDispositivoCN(id)
    End Function
    Private Async Sub LimpiarParam()
        ddlOficina.SelectedIndex = 0
        txtram.Text = ""
        txtdiscoduro.Text = ""
        txtcpu.Text = ""
        tipodispositivo.ClearSelection()
        UpdateButton.Visible = False
        Dim id As Integer?
        If Not String.IsNullOrEmpty(Request.QueryString("id")) Then
            id = Integer.Parse(Request.QueryString("id"))
        End If
        Await Cargargridview(id)
    End Sub
End Class