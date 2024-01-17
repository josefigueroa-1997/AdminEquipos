Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.Web.Optimization

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Se desencadena al iniciar la aplicación
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        ServicePointManager.ServerCertificateValidationCallback = AddressOf ValidateServerCertificate
    End Sub
    Private Shared Function ValidateServerCertificate(sender As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) As Boolean
        ' Aquí puedes personalizar la lógica de validación del certificado
        ' Devuelve True para ignorar los errores de certificado
        Return True
    End Function
End Class