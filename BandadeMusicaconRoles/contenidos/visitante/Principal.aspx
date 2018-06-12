<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Principal.aspx.vb" Inherits="contenidos_visitante_Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        *{
            font-family: Calibri;
            margin: 5px;
        }
        #cab{
            border: 2px solid #007ba7;
            border-top-left-radius: 0.5em;
            border-top-right-radius: 0.5em;
            padding: 1em;
            display:flex;
            justify-content:space-between;
        }

        nav{
            display:flex;
            padding: 0.2em;
            justify-content:space-around;
            background-color:#e8e8e8;
        }

        #gvTrabajos tbody{
            font-size: 0.9em;
            text-align: center;
        }
        #gvTrabajos tbody th{
            padding: 0.2em;
            background-color: #909090;
            color: white;
        }

        #gvTrabajos tbody td{
            padding: 0.25em;
            background-color:#e8e8e8;
        }

        input[type=submit]{
            padding: 0.5em;
            border-radius: 0.5em;
            transition: background-color 1s,color 1s ease-out;
            font-weight: bold;
            margin-right: 0.25em;
        }
        input[type=submit]:hover{
            background-color:#333333;
            color:white;
        }
        section{
            text-align:center
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="cab">
            <asp:Image ID="imgLogo" runat="server" ImageUrl="~/imagenes/emblemmatic-bandademusica-logo-10.png"/>
            <asp:Button ID="Button1" runat="server" Text="Volver al sistema de acceso" />
        </div>
        <asp:GridView ID="gvTrabajos" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
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
