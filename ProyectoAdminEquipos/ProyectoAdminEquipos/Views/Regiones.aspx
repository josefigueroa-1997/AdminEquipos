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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <label>Nombre</label>
        <asp:TextBox ID="TextBox1"  runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Enviar" OnClick="Button1_Click"/>
        <asp:Button ID="UpdateButton" Visible="false" runat="server" Text="Editar" OnClick="UpdateButton_Click" />
        <br />
        <div style="color:red;">
            <asp:Label ID="Label1" Visible="false" runat="server" Text="Label">Esa Región ya se encuentra registrado</asp:Label>
        </div>
        
       
    </form>
</body>
</html>
