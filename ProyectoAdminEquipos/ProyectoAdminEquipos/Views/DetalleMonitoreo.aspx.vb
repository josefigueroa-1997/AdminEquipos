
Imports System.Threading
Imports CapaNegocio
Imports Microsoft.AspNet.FriendlyUrls

Public Class DetalleMonitoreo
    Inherits System.Web.UI.Page
    Private ReadOnly monitoreocn As New MonitoreoCN()

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        If Not IsPostBack Then
            Dim id As Integer
            If Not String.IsNullOrEmpty(Request.QueryString("Id")) Then
                id = Integer.Parse(Request.QueryString("Id"))
            End If
            LlenarCampos(id)
        End If

    End Sub

    Protected Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim id As Integer = Convert.ToInt32(txtid.Text)
            Dim iddisp As Integer = Convert.ToInt32(txtiddispapp.Text)
            Dim estadocpu As String = txtcpu.Text
            Dim estadoram As String = txtram.Text
            Dim estadodisco As String = txtdisco.Text
            Dim estadoapp As String = txtapp.Text
            Await monitoreocn.ActualizarRegistroMonitoreoCN(id, iddisp, estadocpu, estadoram, estadodisco, estadoapp)
            Response.Redirect("Monitoreos.aspx")
        Catch ex As Exception
            Debug.WriteLine(ex.StackTrace)
        End Try

    End Sub

    Private Async Sub LlenarCampos(id As Integer)
        Dim monitoreo = Await monitoreocn.ObtenerRegistroMonitoreoCN(id)
        For Each i In monitoreo
            txtid.Text = i.Id
            txtcpu.Text = i.ESTADO_CPU
            txtram.Text = i.ESTADO_RAM
            txtdisco.Text = i.ESTADO_DISCODURO
            txtapp.Text = i.ESTADO_APLICACION
            txtiddispapp.Text = i.ID_DISPOSITIVO_APP
        Next
    End Sub


End Class