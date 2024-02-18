<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Monitoreos.aspx.vb" Async="true" MasterPageFile="~/Site.Master" Inherits="ProyectoAdminEquipos.Monitoreos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <form method="post" runat="server">
        <div class="overflow-x-auto">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/RegistrarMonitoreo.aspx" CssClass="inline-block bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">Registrar Monitoreo</asp:HyperLink>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand"
            CssClass="min-w-full bg-white border rounded-lg shadow overflow-hidden">
            <Columns>
             <asp:CommandField ShowSelectButton="True" />
             <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900" />
             <asp:BoundField DataField="ID_DISPOSITIVO_APP" HeaderText="ID_DISPOSITIVO" SortExpression="Nombre" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" />  
             <asp:BoundField DataField="ESTADO_CPU" HeaderText="ESTADO_CPU" SortExpression="Nombre" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" />
             <asp:BoundField DataField="ESTADO_RAM" HeaderText="ESTADO_RAM" SortExpression="Nombre" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" />
             <asp:BoundField DataField="ESTADO_DISCODURO" HeaderText="ESTADO_DISCODURO" SortExpression="Nombre" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" />
             <asp:BoundField DataField="ESTADO_APLICACION" HeaderText="ESTADO_APLICACION" SortExpression="Nombre" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" />
             <asp:BoundField DataField="tipodispositivo" HeaderText="tipodispositivo" SortExpression="Nombre" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" />
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
    </form>

</asp:Content>