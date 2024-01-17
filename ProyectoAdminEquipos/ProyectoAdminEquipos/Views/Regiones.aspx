<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Regiones.aspx.vb" Inherits="ProyectoAdminEquipos.Regiones" Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form method="post" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>

        <label>Nombre</label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Enviar" OnClick="Button1_Click"/>

    </form>
</body>
</html>
