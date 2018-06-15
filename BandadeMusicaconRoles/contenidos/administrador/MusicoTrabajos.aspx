<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MusicoTrabajos.aspx.vb" Inherits="contenidos_administrador_MusicoTrabajos" %>

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
            align-items:center;
            align-content:center;
        }
        #gvMusicos {
            margin:auto;
        }

        #gvMusicos tbody{
            font-size: 0.9em;
            text-align: center;
            margin:auto;
        }
        #gvMusicos tbody th{
            padding: 0.2em;
            background-color: #909090;
            color: white;
        }

        #gvMusicos tbody td{
            padding: 0.25em;
            background-color:#e8e8e8;
        }

        #gvMusicos input{
            padding: 0.5em;
            border-radius: 0.5em;
            transition: background-color 1s,color 1s ease-out;
            font-weight: bold;
            margin-right: 0.25em;
        }

        #gvMusicos input:hover{
            background-color:#595959;
            color:white;
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
            text-align:center;
        }
        #btCrear,#btGuardar{
            background-color: #009688;
        }
        #btCrear:hover,#btGuardar:hover{
            background-color:#005996;
            color: white;
        }
        #btModificar{
            background-color: #03a9f4;
        }
        #btModificar:hover{
            background-color:#0227c2;
            color: white;
        }
        #btCancelar,#btBorrar{
            background-color: #f44336;
        }
        #btCancelar:hover,#btBorrar:hover{
            background-color:#d2190b;
            color: white;
        }
        #pnBuscar{
            margin-bottom: 10px;
        }
        #pnDatos{
            align-items:center;
        }
        .validator{
            color:red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="cab">
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
            <h1>Musicos Trabajos</h1>
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
            <br />
         <asp:Button ID="btCrear" runat="server" Text="Crear relación Músico/Trabajo" />
        <asp:Button ID="btBorrar" runat="server" Text="Borrar relación Músico/Trabajo" />
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
