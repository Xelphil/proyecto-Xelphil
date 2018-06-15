<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Trabajos.aspx.vb" Inherits="contenidos_administrador_Trabajos" %>

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
                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
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
            <asp:Button ID="btMusicoTrabajos" runat="server" Text="Asignar trabajos disponibles a un músico" />
        <br />
            <asp:Button ID="btCrear" runat="server" Text="Crear Músico" />
        <asp:Button ID="btModificar" runat="server" Text="Modificar Músico" />
        <asp:Button ID="btBorrar" runat="server" Text="Borrar Músico" />          
    <br />
   <asp:Panel ID="pnDatos" runat="server">
    <asp:Label ID="lbNombre" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
       <br />
    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Se requiere introducir un nombre al músico" ControlToValidate="tbNombre" ValidationGroup="DatosMusico" cssClass="validator"></asp:RequiredFieldValidator>
    <br />
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="lbFecha" runat="server" Text="Fecha: "></asp:Label>
                <asp:Calendar ID="clFecha" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                   </asp:Calendar>
                <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ErrorMessage="Se requiere introducir una fecha del gasto" ControlToValidate="tbNombre" ValidationGroup="DatosMusico" cssClass="validator"></asp:RequiredFieldValidator>
            </ContentTemplate>
        </asp:UpdatePanel>
       <asp:Label ID="lbLugar" runat="server" Text="Lugar: "></asp:Label>
    <asp:TextBox ID="tbLugar" runat="server"></asp:TextBox>
       <br />
    <asp:RequiredFieldValidator ID="rfvLugar" runat="server" ErrorMessage="Se requiere introducir el lugar del trabajo" ControlToValidate="tbLugar" ValidationGroup="DatosMusico" cssClass="validator"></asp:RequiredFieldValidator>
    <br />
       <asp:Label ID="lbCiudad" runat="server" Text="Ciudad: "></asp:Label>
    <asp:TextBox ID="tbCiudad" runat="server"></asp:TextBox>
       <br />
    <asp:RequiredFieldValidator ID="rfvCiudad" runat="server" ErrorMessage="Se requiere introducir la ciudad al músico" ControlToValidate="tbCiudad" ValidationGroup="DatosMusico" cssClass="validator"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbDireccion" runat="server" Text="Direccion: "></asp:Label>
    <asp:TextBox ID="tbDireccion" runat="server"></asp:TextBox>
       <br />
    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ErrorMessage="Se requiere introducir la dirección al músico" ControlToValidate="tbDireccion" ValidationGroup="DatosMusico" cssClass="validator"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbDescripcion" runat="server" Text="Descripción: "></asp:Label>
    <asp:TextBox ID="tbDescripcion" runat="server" TextMode="MultiLine"></asp:TextBox>
    <br />
       <asp:Label ID="lbCategoriatrabajo" runat="server" Text="Categoria de Trabajo: "></asp:Label>
    <asp:DropDownList ID="ddlcategoriatrabajo" runat="server" DataSourceID="SqlDCategoriaTrabajo" DataTextField="nombre" DataValueField="id"></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDCategoriaTrabajo" runat="server" ConnectionString="<%$ ConnectionStrings:BandaDeMusicaConnectionString %>" SelectCommand="SELECT [id], [nombre] FROM [CategoriaTrabajo]"></asp:SqlDataSource>
    <br />
    <asp:Label ID="lbCompleto" runat="server" Text="¿Trabajo Completo?: "></asp:Label>
    <asp:CheckBox ID="cbCompleto" runat="server" />
    <br />
    <asp:Button ID="btGuardar" runat="server" Text="Guardar" ValidationGroup="DatosMusico"/>
    <asp:Button ID="btCancelar" runat="server" Text="Cancelar" />
   </asp:Panel>
        </section>
    </div>
    </form>
</body>
</html>
