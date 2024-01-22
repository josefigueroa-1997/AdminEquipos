<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Comunas.aspx.vb" MasterPageFile="~/Site.Master" Inherits="ProyectoAdminEquipos.Comunas" Async="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <form method="post" runat="server">
        <div class="overflow-x-auto">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand"
            CssClass="min-w-full bg-white border rounded-lg shadow overflow-hidden">
            <Columns>
             <asp:CommandField ShowSelectButton="True" />
             <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900" />
             <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" />
             <asp:BoundField DataField="ID_REGION" HeaderText="Id Region" SortExpression="Nombre" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" />  
             <asp:BoundField DataField="NombreRegion" HeaderText="Nombre Region" SortExpression="Nombre" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" />   
                <asp:TemplateField HeaderText="Acciones" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">
                <ItemTemplate>
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="text-red-500 hover:text-red-700 focus:outline-none focus:underline" />
                </ItemTemplate>
              </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="bg-gray-50" />
        <RowStyle CssClass="even:bg-gray-100 odd:bg-gray-50" />
    </asp:GridView>
        </div>

        <label class="text-xl font-bold">Nombre</label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="border p-2 mt-2" />
         <label class="text-xl font-bold">Región</label>
         <asp:DropDownList ID="ddlRegiones" runat="server" CssClass="border p-2 mt-2" Height="43px"></asp:DropDownList>
        
        <br />
        <asp:Button ID="Button1" runat="server" Text="Enviar" OnClick="Button1_Click" CssClass="bg-blue-500 text-white px-4 py-2 rounded" />
        <asp:Button ID="UpdateButton" Visible="false" runat="server" Text="Editar" OnClick="UpdateButton_Click" CssClass="bg-green-500 text-white px-4 py-2 rounded" />
    </form>
        <div style="color:red;">
            <asp:Label ID="Label1" Visible="false" runat="server" Text="Label">Esa Región ya se encuentra registrado</asp:Label>
        </div>
        
 </asp:Content>     