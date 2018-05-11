<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="Musicos.aspx.vb" Inherits="ProyectoBandadeMusica.Formulario_web1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <h1>Músicos</h1>

   <asp:Panel ID="pnDatos" runat="server">
    <asp:Label ID="lbNombre" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Se requiere introducir un nombre al músico" ControlToValidate="tbNombre"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbApellidos" runat="server" Text="Apellidos: "></asp:Label>
    <asp:TextBox ID="tbApellidos" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvApellidos" runat="server" ErrorMessage="Se requiere introducir los apellidos al músico" ControlToValidate="tbApellidos"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbDireccion" runat="server" Text="Direccion: "></asp:Label>
    <asp:TextBox ID="tbDireccion" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ErrorMessage="Se requiere introducir la dirección al músico" ControlToValidate="tbDireccion"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbCiudad" runat="server" Text="Ciudad: "></asp:Label>
    <asp:TextBox ID="tbCiudad" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvCiudad" runat="server" ErrorMessage="Se requiere introducir la ciudad al músico" ControlToValidate="tbCiudad"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbCoche" runat="server" Text="Coche: "></asp:Label>
    <asp:CheckBox ID="cbCoche" runat="server" />
    <br />
    <asp:Label ID="lbDisponibilidad" runat="server" Text="Disponibilidad: "></asp:Label>
    <asp:CheckBox ID="cbDisponibilidad" runat="server" />
    <br />
    <asp:Label ID="lbCategoriaMusico" runat="server" Text="Categoria de Musico: "></asp:Label>
    <asp:DropDownList ID="ddlCategoriaMusico" runat="server" DataSourceID="SqlDSCategoriaMusico" DataTextField="instrumento" DataValueField="id"></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDSCategoriaMusico" runat="server" ConnectionString="<%$ ConnectionStrings:BandaDeMusicaConnectionString %>" SelectCommand="select CategoriaMusico.id, Instrumentos.instrumento from CategoriaMusico join Instrumentos on CategoriaMusico.instrumento=Instrumentos.id"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDSBandadeMusica" runat="server"></asp:SqlDataSource>
    <br />
    <asp:Button ID="btGuardar" runat="server" Text="Guardar" />
    <asp:Button ID="btCancelar" runat="server" Text="Cancelar" />
   </asp:Panel>
</asp:Content>
