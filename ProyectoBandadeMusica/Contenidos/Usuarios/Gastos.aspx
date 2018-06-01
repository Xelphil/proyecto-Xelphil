﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="Gastos.aspx.vb" Inherits="ProyectoBandadeMusica.Formulario_web15" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Músicos</h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:Panel ID="pnBuscador" runat="server">
            <asp:Panel ID="pnBuscar" runat="server">
                <asp:Label ID="lbBuscar" runat="server" Text="Buscar por: "></asp:Label>
                <asp:DropDownList ID="ddlBuscar" runat="server">
                    <asp:ListItem Text="Nombre" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Fecha" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Pagado" Value="3"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="tbBuscar" runat="server"></asp:TextBox>
                <asp:Button ID="btBusqueda" runat="server" Text="Buscar..." />
            </asp:Panel>
            <asp:GridView ID="gvMusicos" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
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
        <asp:Button ID="btModificar" runat="server" Text="Modificar Gasto" />
        <asp:Button ID="btBorrar" runat="server" Text="Borrar Gasto" />
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
    <asp:DropDownList ID="ddlmusicocongasto" runat="server" DataSourceID="SqlDSmusicocongasto" DataTextField="nombre" DataValueField="id">
        <asp:ListItem Value="0">Sin Musico</asp:ListItem>
       </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDSmusicocongasto" runat="server" ConnectionString="<%$ ConnectionStrings:BandaDeMusicaConnectionString %>" SelectCommand="SELECT [id], [nombre] FROM [Musicos]"></asp:SqlDataSource>
    <br />
    <asp:Button ID="btGuardar" runat="server" Text="Guardar" ValidationGroup="DatosMusico"/>
    <asp:Button ID="btCancelar" runat="server" Text="Cancelar" />
   </asp:Panel>
</asp:Content>
