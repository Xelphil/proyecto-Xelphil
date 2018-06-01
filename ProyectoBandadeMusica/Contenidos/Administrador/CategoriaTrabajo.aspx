<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="CategoriaTrabajo.aspx.vb" Inherits="ProyectoBandadeMusica.Formulario_web4" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Categoría Trabajos</h1>
    <asp:Panel ID="pnBuscador" runat="server">
            <asp:Panel ID="pnBuscar" runat="server">
                <asp:Label ID="lbBuscar" runat="server" Text="Buscar por: "></asp:Label>
                <asp:DropDownList ID="ddlBuscar" runat="server">
                    <asp:ListItem Text="Nombre" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Precio" Value="2"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="tbBuscar" runat="server"></asp:TextBox>
                <asp:Button ID="btBusqueda" runat="server" Text="Buscar..." />
            </asp:Panel>
            <asp:GridView ID="gvMusicos" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    <asp:BoundField DataField="id" HeaderText="Cod. Categoría" ReadOnly="True" InsertVisible="False" SortExpression="id"/>
                    <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre"/>
                    <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
                </Columns>
            </asp:GridView>
        <asp:Button ID="btCrear" runat="server" Text="Crear Categoría" />
        <asp:Button ID="btModificar" runat="server" Text="Modificar Categoría" />
        <asp:Button ID="btBorrar" runat="server" Text="Borrar Categoría" />
        </asp:Panel>
    <br />
   <asp:Panel ID="pnDatos" runat="server">
       <asp:Label ID="lbNombre" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvnombre" runat="server" ErrorMessage="Se requiere introducir un nombre a la categoria" ControlToValidate="tbNombre" ValidationGroup="DatosMusico"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbPrecio" runat="server" Text="Precio: "></asp:Label>
    <asp:TextBox ID="tbPrecio" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvprecio" runat="server" ErrorMessage="Se requiere introducir un precio a la categoria" ControlToValidate="tbPrecio" ValidationGroup="DatosMusico"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Button ID="btGuardar" runat="server" Text="Guardar" ValidationGroup="DatosMusico"/>
    <asp:Button ID="btCancelar" runat="server" Text="Cancelar" />
   </asp:Panel>
    <asp:Button ID="btInstrumentosNec" runat="server" Text="Añadir Musicos Necesarios" Enabled="false"/>
</asp:Content>
