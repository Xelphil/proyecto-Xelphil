<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Trabajos.aspx.vb" Inherits="contenidos_musico_Trabajos" %>

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

        #gvMusicos tbody{
            font-size: 0.9em;
            text-align: center;
        }

        #gvMusicos {
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
        #pnDatos{
            text-align:left;
        }
        #btCrear,#btGuardar{
            background-color: #009688;
        }
        #btCrear:hover,#btGuardar:hover{
            background-color:#005996;
            color: white;
        }
        #btCancelar{
            background-color: #f44336;
        }
        #btCancelar:hover{
            background-color:#d2190b;
            color: white;
        }
        #btMusicoTrabajos{
            margin-top: 10px;
        }
        #pnBuscar{
            margin-bottom: 10px;
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
