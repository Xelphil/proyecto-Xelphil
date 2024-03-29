﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="InstrumentosNecesarios.aspx.vb" Inherits="contenidos_administrador_InstrumentosNecesarios" %>

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
            <asp:Panel ID="pnBuscar" runat="server">
                <asp:Label ID="lbBuscar" runat="server" Text="Buscar por: "></asp:Label>
                <asp:DropDownList ID="ddlBuscar" runat="server">
                    <asp:ListItem Text="Nombre" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Precio" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Cantidad" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Instrumento" Value="4"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="tbBuscar" runat="server"></asp:TextBox>
                <asp:Button ID="btBusqueda" runat="server" Text="Buscar..." />
            </asp:Panel>
    <asp:GridView ID="gvMusicos" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    <asp:BoundField DataField="id" HeaderText="Cod. Instru. Nec." ReadOnly="True" InsertVisible="False" SortExpression="id"/>
                    <asp:BoundField DataField="idcategoriatrabajo" HeaderText="idcategoriatrabajo" SortExpression="idcategoriatrabajo" Visible="false"/>
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre"/>
                    <asp:BoundField DataField="precio" HeaderText="Precio" SortExpression="precio" />
                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" SortExpression="cantidad" />
                    <asp:BoundField DataField="instrumento" HeaderText="Instrumento" SortExpression="instrumento" />
                </Columns>
            </asp:GridView>
    <asp:Button ID="btCrear" runat="server" Text="Añadir cantidad de instrumentos a Categoría" />
        <asp:Button ID="btModificar" runat="server" Text="Modificar cantidad de instrumentos a Categoría" />
        <asp:Button ID="btBorrar" runat="server" Text="Borrar cantidad de instrumentos a Categoría" />
    <br />
    <asp:Panel ID="pnDatos" runat="server">
            <asp:Label ID="lbCodCat" runat="server" Text="Cod. Categoría: "></asp:Label>
            <asp:TextBox ID="tbCodCat" runat="server" Enabled="false"></asp:TextBox>
        <br />
            <asp:RequiredFieldValidator ID="rfvIdCatTrab" runat="server" ErrorMessage="Se requiere seleccionar una categoría de trabajo" ControlToValidate="tbCodCat" ValidationGroup="DatosInstrumentosnec" cssClass="validator"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lbCantidadInstrumentos" runat="server" Text="CantidadInstrumentos: "></asp:Label>
            <asp:TextBox ID="tbCantidadInstrumentos" runat="server" TextMode="Number"></asp:TextBox>
        <br />    
        <asp:RequiredFieldValidator ID="RFVCantidadinstrumentos" runat="server" ErrorMessage="Se requiere introducir una cantidad" ControlToValidate="tbCantidadInstrumentos" ValidationGroup="DatosInstrumentosnec" cssClass="validator"></asp:RequiredFieldValidator>
           <br />
           <asp:Label ID="lbTipoIntru" runat="server" Text="Tipo de Intrumento: "></asp:Label>
           <asp:DropDownList ID="ddlTipoIntru" runat="server" DataSourceID="SqlDSInstrumentos" DataTextField="instrumento" DataValueField="id"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDSInstrumentos" runat="server" ConnectionString="<%$ ConnectionStrings:BandaDeMusicaConnectionString %>" SelectCommand="SELECT * FROM [Instrumentos]"></asp:SqlDataSource>
        <br />    
        <asp:RequiredFieldValidator ID="rfvTipoIntru" runat="server" ErrorMessage="Se requiere seleccionar un instrumento" ControlToValidate="ddlTipoIntru" ValidationGroup="DatosInstrumentosnec" cssClass="validator"></asp:RequiredFieldValidator>
        <br />
    <asp:Button ID="btGuardar" runat="server" Text="Guardar" ValidationGroup="DatosInstrumentosnec"/>
    <asp:Button ID="btCancelar" runat="server" Text="Cancelar" />
   </asp:Panel>
        </section>
    </div>
    </form>
</body>
</html>
