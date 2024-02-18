<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistrarMonitoreo.aspx.vb" Async="true" MasterPageFile="~/Site.Master" Inherits="ProyectoAdminEquipos.RegistrarMonitoreo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <form id="form1" runat="server">
        <div class="overflow-x-auto">
            
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
            CssClass="min-w-full bg-white border rounded-lg shadow overflow-hidden">
            <Columns>
             <asp:CommandField ShowSelectButton="True" />
             <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900" />
             <asp:BoundField DataField="ID_Aplicacion" HeaderText="ID_APP" SortExpression="Nombre" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" />  
             <asp:BoundField DataField="ID_Dispositivo" HeaderText="IDDISPOSITIVO" SortExpression="Nombre" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" />
           
        </Columns>
        <HeaderStyle CssClass="bg-gray-50" />
        <RowStyle CssClass="even:bg-gray-100 odd:bg-gray-50" />
    </asp:GridView>
            
            <br />
            ID Dispositivo:
            <asp:TextBox ID="TextBox1" runat="server" CssClass="border p-2 mt-2" Enabled="false"></asp:TextBox>
&nbsp; Estado CPU:
            <asp:DropDownList ID="ddlcpu" runat="server" CssClass="border p-2 mt-2">
            </asp:DropDownList>
&nbsp; Estado RAM:
            <asp:DropDownList ID="ddlram" runat="server" CssClass="border p-2 mt-2">
            </asp:DropDownList>
            <br />
            <br />
            Estado Disco Duro:
            <asp:DropDownList ID="ddldiscoduro" runat="server" CssClass="border p-2 mt-2">
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Estado App:
            <asp:DropDownList ID="ddlapp" runat="server" CssClass="border p-2 mt-2">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Registrar" CssClass="bg-green-500 text-white px-4 py-2 rounded"/>
            <br />
            
        </div>


    </form>



</asp:Content>