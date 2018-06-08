<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Principal.aspx.vb" Inherits="contenidos_visitante_Principal" %>

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
            <asp:Button ID="Button1" runat="server" Text="Volver al sistema de acceso" />
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="nombre" HeaderText="Nombre del Trabajo" SortExpression="nombre" />
                <asp:BoundField DataField="fecha" HeaderText="Fecha del Trabajo" SortExpression="fecha" />
                <asp:BoundField DataField="lugar" HeaderText="Lugar del Trabajo" SortExpression="lugar" />
                <asp:BoundField DataField="ciudad" HeaderText="Ciudad donde se realiza el Trabajo" SortExpression="ciudad" />
                <asp:BoundField DataField="direccion" HeaderText="Direccion donde se realiza el Trabajo" SortExpression="direccion" />
                <asp:BoundField DataField="descripcion" HeaderText="Descripcion del Trabajo" SortExpression="descripcion" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BandaDeMusicaConnectionString %>" SelectCommand="SELECT [nombre], [fecha], [lugar], [ciudad], [direccion], [descripcion], [categoriatrabajo], [completo] FROM [Trabajo]"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
