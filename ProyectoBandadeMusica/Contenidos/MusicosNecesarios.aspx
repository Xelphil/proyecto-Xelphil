<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="MusicosNecesarios.aspx.vb" Inherits="ProyectoBandadeMusica.Formulario_web14" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>hola</h1>
    <asp:Panel ID="pnDatos" runat="server">
    <asp:Label ID="lbPrecio" runat="server" Text="Precio: "></asp:Label>
    <asp:TextBox ID="tbPrecio" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Se requiere introducir un nombre al músico" ControlToValidate="tbNombre" ValidationGroup="DatosMusico"></asp:RequiredFieldValidator>
    <br />
       <%--<div>
            <asp:Label ID="lbInstrumento" runat="server" Text="Categoria de Musico: "></asp:Label>
            <asp:DropDownList ID="ddlInstrumento" runat="server" DataSourceID="SqlDSInstrumento" DataTextField="instrumento" DataValueField="id"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDSInstrumento" runat="server" ConnectionString="<%$ ConnectionStrings:BandaDeMusicaConnectionString %>" SelectCommand="SELECT  *  FROM Instrumentos"></asp:SqlDataSource>
            <asp:Label ID="lbCantidadInstrumentos" runat="server" Text="CantidadInstrumentos: "></asp:Label>
            <asp:TextBox ID="tbCantidadInstrumentos" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVCantidadinstrumentos" runat="server" ErrorMessage="Se requiere introducir una cantidad" ControlToValidate="tbNombre" ValidationGroup="DatosInstrumentosnec"></asp:RequiredFieldValidator>
        </div>--%>
    <asp:Button ID="btInstrumentosNec" runat="server" Text="Añadir Musicos Necesarios"/>
       <br />

    <asp:Button ID="btGuardar" runat="server" Text="Guardar" ValidationGroup="DatosMusico"/>
    <asp:Button ID="btCancelar" runat="server" Text="Cancelar" />
   </asp:Panel>
</asp:Content>
