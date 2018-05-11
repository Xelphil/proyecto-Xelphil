<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="Musicos.aspx.vb" Inherits="ProyectoBandadeMusica.Formulario_web1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Músicos</h1>
    <br />
    <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
    <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lbApellidos" runat="server" Text="Apellidos"></asp:Label>
    <asp:TextBox ID="tbApellidos" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lbDireccion" runat="server" Text="Direccion"></asp:Label>
    <asp:TextBox ID="tbDireccion" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lbCoche" runat="server" Text="Coche"></asp:Label>
    <asp:CheckBox ID="cbCoche" runat="server" />
    <br />
    <asp:Label ID="lbDisponibilidad" runat="server" Text="Disponibilidad"></asp:Label>
    <asp:CheckBox ID="cbDisponibilidad" runat="server" />
    <br />
    <asp:Label ID="lbCategoriaMusico" runat="server" Text="Categoria de Musico"></asp:Label>
    <asp:DropDownList ID="ddlCategoriaMusico" runat="server"></asp:DropDownList>
    <br />
</asp:Content>
