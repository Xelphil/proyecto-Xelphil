<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Gastos.aspx.vb" Inherits="contenidos_musico_Gastos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        *{
            font-family: Calibri;
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
            <h1> Gastos Músicos</h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:Panel ID="pnBuscador" runat="server">
            <asp:Panel ID="pnBuscar" runat="server">
                <asp:Label ID="lbBuscar" runat="server" Text="Buscar por: "></asp:Label>
                <asp:DropDownList ID="ddlBuscar" runat="server">
                    <asp:ListItem Text="Nombre" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Trabajo" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Pagado" Value="3"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="tbBuscar" runat="server"></asp:TextBox>
                <asp:Button ID="btBusqueda" runat="server" Text="Buscar..." />
            </asp:Panel>
            <asp:GridView ID="gvMusicos" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" InsertVisible="False" SortExpression="id" Visible="false"/>
                    <asp:BoundField DataField="NombredelGasto" HeaderText="Nombre del Gasto" SortExpression="NombredelGasto" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion del Gasto" SortExpression="descripcion" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha del Gasto" SortExpression="Fecha" />
                    <asp:CheckBoxField DataField="pagado" HeaderText="¿Gasto Pagado?" SortExpression="pagado" />
                    <asp:BoundField DataField="trabajo" HeaderText="Trabajo al que pertenece el gasto" SortExpression="trabajo" />
                    <asp:BoundField DataField="musicocongasto" HeaderText="¿Gasto del Musico?" SortExpression="musicocongasto" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <asp:Button ID="btCrear" runat="server" Text="Crear Gasto" />
    <br />
   <asp:Panel ID="pnDatos" runat="server">
    <asp:Label ID="lbNombre" runat="server" Text="Nombre del Gasto: "></asp:Label>
    <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Se requiere introducir un nombre del gasto" ControlToValidate="tbNombre" ValidationGroup="DatosMusico"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbdescripcion" runat="server" Text="Descripcion: "></asp:Label>
    <asp:TextBox ID="tbdescripcion" runat="server"></asp:TextBox>
    <br />
    
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
                <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ErrorMessage="Se requiere introducir una fecha del gasto" ControlToValidate="tbNombre" ValidationGroup="DatosMusico"></asp:RequiredFieldValidator>
            </ContentTemplate>
        </asp:UpdatePanel>
    <asp:Label ID="lbpagado" runat="server" Text="¿Pagado?: "></asp:Label>
    <asp:CheckBox ID="cbpagado" runat="server" />
    <br />
       <asp:Label ID="lbTrabajo" runat="server" Text="Trabajo al que pertenece el gasto: "></asp:Label>
    <asp:DropDownList ID="ddlTrabajo" runat="server" DataSourceID="SqlDStrabajo" DataTextField="nombre" DataValueField="id"></asp:DropDownList>
       <asp:SqlDataSource ID="SqlDStrabajo" runat="server" ConnectionString="<%$ ConnectionStrings:BandaDeMusicaConnectionString %>" SelectCommand="SELECT [id], [nombre] FROM [Trabajo]"></asp:SqlDataSource>
    <br />
    <asp:Label ID="lbmusicocongasto" runat="server" Text="Musico con gasto: "></asp:Label>
       <asp:TextBox ID="tbmusicocongasto" runat="server" Enabled="false"></asp:TextBox>
    <br />
    <asp:Button ID="btGuardar" runat="server" Text="Guardar" ValidationGroup="DatosMusico"/>
    <asp:Button ID="btCancelar" runat="server" Text="Cancelar" />
   </asp:Panel>
        </section>
    </div>
    </form>
</body>
</html>
