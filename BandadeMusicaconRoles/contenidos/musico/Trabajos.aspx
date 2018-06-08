<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Trabajos.aspx.vb" Inherits="contenidos_musico_Trabajos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
            <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Ent_Cliente/Imagenes/emblemmatic-bandademusica-logo-10.png"/>
            <asp:Button ID="btCerrarSesion" runat="server" Text="Cerrar Sesion" />
        </div> 
       <nav>
           <asp:Button ID="btTrabajos" runat="server" Text="Trabajos" />
           <asp:Button ID="btMusicos" runat="server" Text="Musicos" />
           <asp:Button ID="btGastos" runat="server" Text="Gastos" />
       </nav>
        <section>
            <h1>Trabajos</h1>
     <asp:Panel ID="pnBuscador" runat="server">
            <asp:Panel ID="pnBuscar" runat="server">
                <asp:Label ID="lbBuscar" runat="server" Text="Buscar por: "></asp:Label>
                <asp:DropDownList ID="ddlBuscar" runat="server">
                    <asp:ListItem Text="Nombre" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Ciudad" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Completo" Value="3"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="tbBuscar" runat="server"></asp:TextBox>
                <asp:Button ID="btBusqueda" runat="server" Text="Buscar..." />
            </asp:Panel>
            <asp:GridView ID="gvMusicos" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" InsertVisible="False" SortExpression="id" Visible="false"/>
                    <asp:BoundField DataField="nombre" HeaderText="Nombre del Trabajo" SortExpression="nombre" />
                    <asp:BoundField DataField="fecha" HeaderText="Fecha del Trabajo" SortExpression="fecha" />
                    <asp:BoundField DataField="lugar" HeaderText="Lugar del Trabajo" SortExpression="lugar" />
                    <asp:BoundField DataField="ciudad" HeaderText="Ciudad donde se realiza el trabajo(Convenio)" SortExpression="ciudad" />
                    <asp:BoundField DataField="direccion" HeaderText="Direccion del Trabajo" SortExpression="direccion" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion del Trabajo" SortExpression="descripcion" />
                    <asp:BoundField DataField="categoriatrabajo" HeaderText="Categoria del Trabajo" SortExpression="categoriatrabajo"/>
                    <asp:CheckBoxField DataField="completo" HeaderText="¿Esta completo el trabajo?" SortExpression="completo" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
            <asp:Button ID="btMusicoTrabajos" runat="server" Text="Buscar trabajos disponibles" />
    <br />
        </section>
    </div>
    </form>
</body>
</html>
