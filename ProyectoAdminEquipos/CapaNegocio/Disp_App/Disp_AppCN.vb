Imports CapadeDatos

Public Class Disp_AppCN
    Private ReadOnly dispappcd As New Disp_AppCD()
    Public Async Function ObtenerDispositivoAplicacionCN() As Task(Of List(Of Dis_App))
        Return Await dispappcd.ObtenerDispositivoAplicacion()
    End Function
End Class
