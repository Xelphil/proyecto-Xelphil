<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CategoriaTrabajo.aspx.vb" Inherits="contenidos_administrador_CategoriaTrabajo" %>

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
        </section>
    </div>
    </form>
</body>
</html>
