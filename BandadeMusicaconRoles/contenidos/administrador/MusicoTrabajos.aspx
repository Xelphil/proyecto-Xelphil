<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MusicoTrabajos.aspx.vb" Inherits="contenidos_administrador_MusicoTrabajos" %>

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
            <h1>Trabajos</h1>
     <asp:Panel ID="pnBuscador" runat="server">
            <asp:Panel ID="pnBuscar" runat="server">
                <asp:Label ID="lbBuscar" runat="server" Text="Buscar por: "></asp:Label>
                <asp:DropDownList ID="ddlBuscar" runat="server">
                    <asp:ListItem Text="Nombre Trabajo" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Nombre Músico" Value="2"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="tbBuscar" runat="server"></asp:TextBox>
                <asp:Button ID="btBusqueda" runat="server" Text="Buscar..." />
            </asp:Panel>
            <asp:GridView ID="gvMusicos" runat="server" AutoGenerateColumns="False" DataKeyNames="idTrabajo">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre del Trabajo" SortExpression="nombre"/>
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion del Trabajo" SortExpression="descripcion" />
                    <asp:BoundField DataField="fecha" HeaderText="Fecha del Trabajo" SortExpression="fecha" />
                    <asp:BoundField DataField="idTrabajo" HeaderText="idTrabajo" SortExpression="idTrabajo" ReadOnly="True" />
                    <asp:BoundField DataField="nombre1" HeaderText="Nombre del Musico" SortExpression="nombre1" />
                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos del Musico" SortExpression="apellidos" />
                    <asp:BoundField DataField="idMusicos" HeaderText="idMusicos" SortExpression="idMusicos" ReadOnly="True" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
         <asp:Button ID="btMusicoTrabajos" runat="server" Text="Volver a trabajos" />
         <asp:Button ID="btCrear" runat="server" Text="Crear Músico" />
        <asp:Button ID="btBorrar" runat="server" Text="Borrar Músico" />
    <br />
   <asp:Panel ID="pnDatos" runat="server">

    <asp:Label ID="lbTrabajo" runat="server" Text="Trabajo: "></asp:Label>
    <asp:DropDownList ID="ddltrabajo" runat="server" DataSourceID="SqlDCategoriaTrabajo" DataTextField="nombre" DataValueField="id"></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDCategoriaTrabajo" runat="server" ConnectionString="<%$ ConnectionStrings:BandaDeMusicaConnectionString %>" SelectCommand="SELECT [nombre], [id] FROM [Trabajo]"></asp:SqlDataSource>
    <br />
    <asp:Label ID="lbMusico" runat="server" Text="Musico: "></asp:Label>
    <asp:DropDownList ID="ddlMusico" runat="server" DataSourceID="SqlDataSource1" DataTextField="nombre" DataValueField="idMusico" ></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BandaDeMusicaConnectionString %>" SelectCommand="SELECT [idMusico], [nombre] FROM [Musicos]"></asp:SqlDataSource>
    <br />
    <asp:Button ID="btGuardar" runat="server" Text="Añadir Musico al trabajo" ValidationGroup="DatosMusico"/>
    <asp:Button ID="btCancelar" runat="server" Text="Cancelar" />
   </asp:Panel>
        </section>
    </div>
    </form>
</body>
</html>
