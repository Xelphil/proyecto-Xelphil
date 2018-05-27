<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="Musicos.aspx.vb" Inherits="ProyectoBandadeMusica.Formulario_web1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Músicos</h1>
     <asp:Panel ID="pnBuscador" runat="server">
            <asp:Panel ID="pnBuscar" runat="server">
                <asp:Label ID="lbBuscar" runat="server" Text="Buscar por: "></asp:Label>
                <asp:DropDownList ID="ddlBuscar" runat="server">
                    <asp:ListItem Text="Nombre" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Coche" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Disponibilidad" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Categoria" Value="4"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="tbBuscar" runat="server"></asp:TextBox>
                <asp:Button ID="btBusqueda" runat="server" Text="Buscar..." />
            </asp:Panel>
            <asp:GridView ID="gvMusicos" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" InsertVisible="False" SortExpression="id" Visible="false"/>
                    <asp:BoundField DataField="nombre" HeaderText="Nombre del Músico" SortExpression="nombre" />
                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos del Músico" SortExpression="apellidos" />
                    <asp:BoundField DataField="direccion" HeaderText="Direccion del Músico" SortExpression="direccion" />
                    <asp:BoundField DataField="ciudad" HeaderText="Ciudad donde vive el Músico" SortExpression="ciudad" />
                    <asp:CheckBoxField DataField="coche" HeaderText="¿Tiene Coche?" SortExpression="coche" />
                    <asp:CheckBoxField DataField="disponibilidad" HeaderText="¿Esta Disponible?" SortExpression="disponibilidad" />
                    <asp:BoundField DataField="categoriamusico" HeaderText="Categoria del Músico" SortExpression="categoriamusico"/>
                    <asp:BoundField DataField="instrumento" HeaderText="Instrumento del Músico" SortExpression="instrumento" />
                </Columns>
            </asp:GridView>
        <asp:Button ID="btCrear" runat="server" Text="Crear Músico" />
        <asp:Button ID="btModificar" runat="server" Text="Modificar Músico" />
        <asp:Button ID="btBorrar" runat="server" Text="Borrar Músico" />
        </asp:Panel>
    <br />
   <asp:Panel ID="pnDatos" runat="server">
    <asp:Label ID="lbNombre" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Se requiere introducir un nombre al músico" ControlToValidate="tbNombre" ValidationGroup="DatosMusico"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbApellidos" runat="server" Text="Apellidos: "></asp:Label>
    <asp:TextBox ID="tbApellidos" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvApellidos" runat="server" ErrorMessage="Se requiere introducir los apellidos al músico" ControlToValidate="tbApellidos" ValidationGroup="DatosMusico"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbDireccion" runat="server" Text="Direccion: "></asp:Label>
    <asp:TextBox ID="tbDireccion" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ErrorMessage="Se requiere introducir la dirección al músico" ControlToValidate="tbDireccion" ValidationGroup="DatosMusico"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbCiudad" runat="server" Text="Ciudad: "></asp:Label>
    <asp:TextBox ID="tbCiudad" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvCiudad" runat="server" ErrorMessage="Se requiere introducir la ciudad al músico" ControlToValidate="tbCiudad" ValidationGroup="DatosMusico"></asp:RequiredFieldValidator>
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
    <asp:Button ID="btGuardar" runat="server" Text="Guardar" ValidationGroup="DatosMusico"/>
    <asp:Button ID="btCancelar" runat="server" Text="Cancelar" />
   </asp:Panel>
</asp:Content>
