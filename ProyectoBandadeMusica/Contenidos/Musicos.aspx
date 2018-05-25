<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="Musicos.aspx.vb" Inherits="ProyectoBandadeMusica.Formulario_web1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Músicos</h1>
    <asp:Panel ID="pnBuscador" runat="server">
            <asp:Panel ID="pnBuscar" runat="server">
                <asp:Label ID="lbBuscar" runat="server" Text="Buscar por: "></asp:Label>
                <asp:DropDownList ID="ddlBuscar" runat="server">
                    <asp:ListItem Text="Usuario" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Admin" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Musico" Value="3"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="tbBuscar" runat="server"></asp:TextBox>
                <asp:Button ID="btBusqueda" runat="server" Text="Buscar..." />
            </asp:Panel>
            <asp:GridView ID="gvMusicos" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" InsertVisible="False" SortExpression="id" Visible="false"/>
                    <asp:BoundField DataField="usuario" HeaderText="Nombre del Usuario" SortExpression="usuario" />
                    <asp:BoundField DataField="contraseña" HeaderText="Contraseña del Usuario" SortExpression="contraseña" visible="false"/>
                    <asp:BoundField DataField="admin" HeaderText="¿Es Admin?" SortExpression="admin" />
                    <asp:BoundField DataField="musico" HeaderText="Cod. el Músico" SortExpression="musico" />
                </Columns>
            </asp:GridView>
        <asp:Button ID="btCrear" runat="server" Text="Crear Usuario" />
        <asp:Button ID="btModificar" runat="server" Text="Modificar Usuario" />
        <asp:Button ID="btBorrar" runat="server" Text="Borrar Usuario" />
        </asp:Panel>
    <br />
   <asp:Panel ID="pnDatos" runat="server">
    <asp:Label ID="lbUsuario" runat="server" Text="Usuario: "></asp:Label>
    <asp:TextBox ID="tbUsuario" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Se requiere introducir Usuario" ControlToValidate="tbUsuario" ValidationGroup="DatosMusico"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbPass1" runat="server" Text="Contraseña: "></asp:Label>
    <asp:TextBox ID="tbPass1" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvApellidos" runat="server" ErrorMessage="Se requiere introducir la contraseña" ControlToValidate="tbPass1" ValidationGroup="DatosMusico"></asp:RequiredFieldValidator>
    <br />
       <asp:Label ID="lbPass2" runat="server" Text="Contraseña: "></asp:Label>
    <asp:TextBox ID="tbPass2" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Se requiere introducir la confirmación de la contraseña" ControlToValidate="tbPass2" ValidationGroup="DatosMusico"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbAdmin" runat="server" Text="Admin: "></asp:Label>
    <asp:TextBox ID="tbAdmin" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lbCoche" runat="server" Text="Coche: "></asp:Label>
    <asp:CheckBox ID="cbCoche" runat="server" />
    <br />
    <asp:Button ID="btGuardar" runat="server" Text="Guardar" ValidationGroup="DatosMusico"/>
    <asp:Button ID="btCancelar" runat="server" Text="Cancelar" />
   </asp:Panel>
</asp:Content>
