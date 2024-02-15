<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Dispositivo.aspx.vb" MasterPageFile="~/Site.Master" Async="true" Inherits="ProyectoAdminEquipos.Dispositivo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <form method="post" runat="server">
        <div class="overflow-x-auto">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand"
            CssClass="min-w-full bg-white border rounded-lg shadow overflow-hidden">
            <Columns>
             <asp:CommandField ShowSelectButton="True" />
             <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900" />
             <asp:BoundField DataField="Id_oficina" HeaderText="ID Oficina" SortExpression="Nombre" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" />  
             <asp:BoundField DataField="nombreoficina" HeaderText="Nombre Oficina" SortExpression="Nombre" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" />   
             <asp:BoundField DataField="tipodispositivo" HeaderText="Tipo Dispositivo" SortExpression="Nombre" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" />   
             <asp:BoundField DataField="cpu" HeaderText="cpu" SortExpression="Nombre" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" />   
             <asp:BoundField DataField="ram" HeaderText="Ram" SortExpression="Nombre" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" />   
             <asp:BoundField DataField="disco_duro" HeaderText="Disco Duro" SortExpression="Nombre" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" />   

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
      <label class="text-xl font-bold">Agregar Dispositivo</label>
        <br />
     <label class="text-xl font-bold">Oficina</label>
     <asp:DropDownList ID="ddlOficina" runat="server" CssClass="border p-2 mt-2" Height="43px"></asp:DropDownList>
        <br />
     <label class="text-xl font-bold">Seleccione un tipo de dispositivo</label>
    <asp:RadioButtonList ID="tipodispositivo" runat="server" CssClass="flex flex-col space-y-2">
        <asp:ListItem Text="PC" Value="pc"></asp:ListItem>
        <asp:ListItem Text="Impresora" Value="impresora"></asp:ListItem>
        <asp:ListItem Text="Servidor" Value="servidor"></asp:ListItem>
        <asp:ListItem Text="Celular" Value="celular"></asp:ListItem>
    </asp:RadioButtonList>
    <label class="text-xl font-bold">cpu</label>
        <asp:TextBox ID="txtcpu" runat="server" CssClass="border p-2 mt-2" />
    <label class="text-xl font-bold">Ram</label>
        <asp:TextBox ID="txtram" runat="server" CssClass="border p-2 mt-2" />
    <label class="text-xl font-bold">Disco Duro</label>
        <asp:TextBox ID="txtdiscoduro" runat="server" CssClass="border p-2 mt-2" />
        <br />
    <asp:Button ID="Button1" runat="server" Text="Enviar" OnClick="Button1_Click" CssClass="bg-blue-500 text-white px-4 py-2 rounded" />
        <asp:Button ID="UpdateButton" Visible="false" runat="server" Text="Editar" OnClick="UpdateButton_Click" CssClass="bg-green-500 text-white px-4 py-2 rounded" />
    </form>


</asp:Content>