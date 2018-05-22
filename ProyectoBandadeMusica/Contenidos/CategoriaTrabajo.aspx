<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="CategoriaTrabajo.aspx.vb" Inherits="ProyectoBandadeMusica.Formulario_web4" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Categoría Músicos</h1>
    <asp:Panel ID="pnBuscador" runat="server">
            <asp:Panel ID="pnBuscar" runat="server">
                <asp:Label ID="lbBuscar" runat="server" Text="Buscar por: "></asp:Label>
                <asp:DropDownList ID="ddlBuscar" runat="server">
                    <asp:ListItem Text="Sueldo" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Instrumento" Value="2"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="tbBuscar" runat="server"></asp:TextBox>
                <asp:Button ID="btBusqueda" runat="server" Text="Buscar..." />
            </asp:Panel>
            <asp:GridView ID="gvMusicos" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    <asp:BoundField DataField="id" HeaderText="Cod. Categoría" ReadOnly="True" InsertVisible="False" SortExpression="id"/>
                    <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
                </Columns>
            </asp:GridView>
        <asp:Button ID="btCrear" runat="server" Text="Crear Categoría" />
        <asp:Button ID="btModificar" runat="server" Text="Modificar Categoría" />
        <asp:Button ID="btBorrar" runat="server" Text="Borrar Categoría" />
        </asp:Panel>
    <br />
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
