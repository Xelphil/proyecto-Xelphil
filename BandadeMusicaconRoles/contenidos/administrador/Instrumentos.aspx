﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Instrumentos.aspx.vb" Inherits="contenidos_administrador_Instrumentos" %>

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
        #gvInstrumentos {
            margin:auto;
        }

        #gvInstrumentos tbody{
            font-size: 0.9em;
            text-align: center;
            margin:auto;
        }
        #gvInstrumentos tbody th{
            padding: 0.2em;
            background-color: #909090;
            color: white;
        }

        #gvInstrumentos tbody td{
            padding: 0.25em;
            background-color:#e8e8e8;
        }

        #gvInstrumentos input{
            padding: 0.5em;
            border-radius: 0.5em;
            transition: background-color 1s,color 1s ease-out;
            font-weight: bold;
            margin-right: 0.25em;
        }

        #gvInstrumentos input:hover{
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
        #clFecha{
            margin:auto;
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
            <h1>Instrumentos</h1>
    <asp:Panel ID="pnBuscador" runat="server">
            <asp:Panel ID="pnBuscar" runat="server">
                <asp:Label ID="lbBuscar" runat="server" Text="Buscar por: "></asp:Label>
                <asp:DropDownList ID="ddlBuscar" runat="server">
                    <asp:ListItem Text="Nombre" Value="1"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="tbBuscar" runat="server"></asp:TextBox>
                <asp:Button ID="btBusqueda" runat="server" Text="Buscar..." />
            </asp:Panel>
            <asp:GridView ID="gvInstrumentos" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" InsertVisible="False" SortExpression="id" Visible="false"/>
                    <asp:BoundField DataField="instrumento" HeaderText="Nombre del Instrumento" SortExpression="nombre" />
                </Columns>
            </asp:GridView>
        <asp:Button ID="btCrear" runat="server" Text="Añadir Instrumento" />
        <asp:Button ID="btModificar" runat="server" Text="Modificar Instrumento" />
        <asp:Button ID="btBorrar" runat="server" Text="Borrar Instrumento" />
        </asp:Panel>
    <br />
   <asp:Panel ID="pnDatos" runat="server">
    <asp:Label ID="lbNombre" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
       <br />
    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Se requiere introducir un nombre al instrumento" ControlToValidate="tbNombre" ValidationGroup="DatosMusico" cssClass="validator"></asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="btGuardar" runat="server" Text="Guardar" ValidationGroup="DatosMusico"/>
    <asp:Button ID="btCancelar" runat="server" Text="Cancelar" />
   </asp:Panel>
        </section>
    </div>
    </form>
</body>
</html>
