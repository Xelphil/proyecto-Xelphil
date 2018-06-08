<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Musicos.aspx.vb" Inherits="contenidos_administrador_Musicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Image ID="imgLogo" runat="server" ImageUrl="~/imagenes/emblemmatic-bandademusica-logo-10.png"/>
            <asp:Button ID="btCerrarSesion" runat="server" Text="Cerrar Sesion" />
        </div> 
       <nav>
           <asp:Button ID="btTrabajos" runat="server" Text="Trabajos" />
           <asp:Button ID="btMusicos" runat="server" Text="Musicos" />
           <asp:Button ID="btGastos" runat="server" Text="Gastos" />
           <asp:Button ID="btCatTrab" runat="server" Text="Categoría Trabajos" />
           <asp:Button ID="btCatMus" runat="server" Text="Categoría Musicos" />
           <asp:Button ID="btInstrumentos" runat="server" Text="Instrumentos" />
           <asp:Button ID="btUsuarios" runat="server" Text="Usuarios" />
       </nav>
        <section>
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
            <asp:GridView ID="gvMusicos" runat="server" AutoGenerateColumns="False" DataKeyNames="idMusico">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
                    <asp:BoundField DataField="idMusico" HeaderText="idMusico" ReadOnly="True" InsertVisible="False" SortExpression="idMusico" Visible="false"/>
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
        </asp:Panel>
        <asp:Button ID="btCrear" runat="server" Text="Crear Músico" />
        <asp:Button ID="btModificar" runat="server" Text="Modificar Músico" />
        <asp:Button ID="btBorrar" runat="server" Text="Borrar Músico" />
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
    <asp:Label ID="lbUsuario" runat="server" Text="Usuario: "></asp:Label>
    <asp:TextBox ID="tbUsuario" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Se requiere introducir Usuario" ControlToValidate="tbUsuario" ValidationGroup="DatosMusico"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbPass1" runat="server" Text="Contraseña: "></asp:Label>
    <asp:TextBox ID="tbPass1" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Se requiere introducir la contraseña" ControlToValidate="tbPass1" ValidationGroup="DatosMusico"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbPass2" runat="server" Text="Repite Contraseña: "></asp:Label>
    <asp:TextBox ID="tbPass2" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Se requiere introducir la confirmación de la contraseña" ControlToValidate="tbPass2" ValidationGroup="DatosMusico"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Las contraseñas no coinciden" ControlToCompare="tbPass1" ControlToValidate="tbPass2"></asp:CompareValidator>
    <br />
    <asp:Button ID="btGuardar" runat="server" Text="Guardar" ValidationGroup="DatosMusico"/>
    <asp:Button ID="btCancelar" runat="server" Text="Cancelar" />
   </asp:Panel>
        </section>
    </div>
    </form>
</body>
</html>
