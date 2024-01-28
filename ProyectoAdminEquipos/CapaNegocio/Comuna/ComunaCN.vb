Imports CapadeDatos
Public Class ComunaCN

    Private ReadOnly comunacd As New ComunaCD

    Public Async Function ObtenerComunasCN(id As Integer?, idregion As Integer?) As Task(Of List(Of Comuna))
        Return Await comunacd.ObtenerComunas(id, idregion)
    End Function
    Public Async Function AgregarComunaCN(idregion As Integer, nombre As String) As Task
        Await comunacd.AgregarComuna(idregion, nombre)
    End Function
    Public Async Function ActualizarComunaCN(idcomuna As Integer, idregion As Integer, nombre As String) As Task
        Await comunacd.EditarComuna(idcomuna, idregion, nombre)
    End Function
    Public Async Function EliminarComunaCN(idcomuna As Integer) As Task
        Await comunacd.EliminarComuna(idcomuna)
    End Function
    Public Sub AgregarElementoddl(comunas As List(Of Comuna))
        comunacd.Agregarelemento(comunas)
    End Sub
    Public Function ObtenerIdComunaCN(nombre As String, comuna As List(Of Comuna)) As Integer
        Return comunacd.ObtenerIdComuna(nombre, comuna)
    End Function
End Class
