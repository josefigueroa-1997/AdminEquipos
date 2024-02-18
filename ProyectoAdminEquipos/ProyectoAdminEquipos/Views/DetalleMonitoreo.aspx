<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DetalleMonitoreo.aspx.vb" MasterPageFile="~/Site.Master" Async="true" Inherits="ProyectoAdminEquipos.DetalleMonitoreo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <form id="form1" runat="server">

        ID:
        <asp:TextBox ID="txtid" runat="server" Enabled="false" CssClass="border p-2 mt-2"></asp:TextBox>
&nbsp;Estado CPU:
        <asp:TextBox ID="txtcpu" runat="server" CssClass="border p-2 mt-2"></asp:TextBox>
&nbsp;Estado RAM:
        <asp:TextBox ID="txtram" runat="server" CssClass="border p-2 mt-2"></asp:TextBox>
        <br />
        <br />
        Estado Disco Duro:<asp:TextBox ID="txtdisco" runat="server" CssClass="border p-2 mt-2"></asp:TextBox>
&nbsp;Estado Aplicación:
        <asp:TextBox ID="txtapp" runat="server" CssClass="border p-2 mt-2"></asp:TextBox>
        &nbsp;IDDispositivo:
        <asp:TextBox ID="txtiddispapp" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Editar" CssClass="bg-green-500 text-white px-4 py-2 rounded" />

    </form>


</asp:Content>

