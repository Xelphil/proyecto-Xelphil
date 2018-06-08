<%@ Page Language="VB" AutoEventWireup="false" CodeFile="InstrumentosNecesarios.aspx.vb" Inherits="contenidos_administrador_InstrumentosNecesarios" %>

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
                    <asp:BoundField DataField="idcategoriatrabajo" HeaderText="Cod. Categoría" ReadOnly="True" InsertVisible="False" SortExpression="idcategoriatrabajo"/>
                    <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre"/>
                    <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
                    <asp:BoundField DataField="cantidad" HeaderText="cantidad" SortExpression="cantidad" />
                    <asp:BoundField DataField="instrumento" HeaderText="instrumento" SortExpression="instrumento" />
                </Columns>
            </asp:GridView>
    <asp:Button ID="btCrear" runat="server" Text="Añadir cantidad de instrumentos a Categoría" />
        <asp:Button ID="btModificar" runat="server" Text="Modificar cantidad de instrumentos a Categoría" />
        <asp:Button ID="btBorrar" runat="server" Text="Borrar cantidad de instrumentos a Categoría" />
    <br />
    <asp:Panel ID="pnDatos" runat="server">
            <asp:Label ID="lbCodCat" runat="server" Text="Cod. Categoría: "></asp:Label>
            <asp:TextBox ID="tbCodCat" runat="server" Enabled="false"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvIdCatTrab" runat="server" ErrorMessage="Se requiere seleccionar una categoría de trabajo" ControlToValidate="tbCodCat" ValidationGroup="DatosInstrumentosnec"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lbCantidadInstrumentos" runat="server" Text="CantidadInstrumentos: "></asp:Label>
            <asp:TextBox ID="tbCantidadInstrumentos" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVCantidadinstrumentos" runat="server" ErrorMessage="Se requiere introducir una cantidad" ControlToValidate="tbCantidadInstrumentos" ValidationGroup="DatosInstrumentosnec"></asp:RequiredFieldValidator>
           <br />
           <asp:Label ID="lbTipoIntru" runat="server" Text="Tipo de Intrumento: "></asp:Label>
           <asp:DropDownList ID="ddlTipoIntru" runat="server" DataSourceID="SqlDSInstrumentos" DataTextField="instrumento" DataValueField="id"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDSInstrumentos" runat="server" ConnectionString="<%$ ConnectionStrings:BandaDeMusicaConnectionString %>" SelectCommand="SELECT * FROM [Instrumentos]"></asp:SqlDataSource>
            <asp:RequiredFieldValidator ID="rfvTipoIntru" runat="server" ErrorMessage="Se requiere seleccionar un instrumento" ControlToValidate="ddlTipoIntru" ValidationGroup="DatosInstrumentosnec"></asp:RequiredFieldValidator>
        <br />
    <asp:Button ID="btGuardar" runat="server" Text="Guardar" ValidationGroup="DatosInstrumentosnec"/>
    <asp:Button ID="btCancelar" runat="server" Text="Cancelar" />
   </asp:Panel>
        </section>
    </div>
    </form>
</body>
</html>
