<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Musicos.aspx.vb" Inherits="contenidos_musico_Musicos" %>

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
       </nav>
        <section>
            <br />
            <asp:FormView ID="fvMusico" runat="server" DataKeyNames="idMusico" DataSourceID="sqlDSmusico">
                <EditItemTemplate>
                    idMusico:
                    <asp:Label ID="idMusicoLabel1" runat="server" Text='<%# Eval("idMusico") %>' />
                    <br />
                    nombre:
                    <asp:TextBox ID="nombreTextBox" runat="server" Text='<%# Bind("nombre") %>' />
                    <br />
                    apellidos:
                    <asp:TextBox ID="apellidosTextBox" runat="server" Text='<%# Bind("apellidos") %>' />
                    <br />
                    direccion:
                    <asp:TextBox ID="direccionTextBox" runat="server" Text='<%# Bind("direccion") %>' />
                    <br />
                    ciudad:
                    <asp:TextBox ID="ciudadTextBox" runat="server" Text='<%# Bind("ciudad") %>' />
                    <br />
                    coche:
                    <asp:CheckBox ID="cocheCheckBox" runat="server" Checked='<%# Bind("coche") %>' />
                    <br />
                    disponibilidad:
                    <asp:CheckBox ID="disponibilidadCheckBox" runat="server" Checked='<%# Bind("disponibilidad") %>' />
                    <br />
                    categoriamusico:
                    <asp:TextBox ID="categoriamusicoTextBox" runat="server" Text='<%# Bind("categoriamusico") %>' />
                    <br />
                    usuario:
                    <asp:TextBox ID="usuarioTextBox" runat="server" Text='<%# Bind("usuario") %>' />
                    <br />
                    password:
                    <asp:TextBox ID="passwordTextBox" runat="server" Text='<%# Bind("password") %>' />
                    <br />
                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar" />
                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                </EditItemTemplate>
                <ItemTemplate>
                    idMusico:
                    <asp:Label ID="idMusicoLabel" runat="server" Text='<%# Eval("idMusico") %>' />
                    <br />
                    nombre:
                    <asp:Label ID="nombreLabel" runat="server" Text='<%# Bind("nombre") %>' />
                    <br />
                    apellidos:
                    <asp:Label ID="apellidosLabel" runat="server" Text='<%# Bind("apellidos") %>' />
                    <br />
                    direccion:
                    <asp:Label ID="direccionLabel" runat="server" Text='<%# Bind("direccion") %>' />
                    <br />
                    ciudad:
                    <asp:Label ID="ciudadLabel" runat="server" Text='<%# Bind("ciudad") %>' />
                    <br />
                    coche:
                    <asp:CheckBox ID="cocheCheckBox" runat="server" Checked='<%# Bind("coche") %>' Enabled="false" />
                    <br />
                    disponibilidad:
                    <asp:CheckBox ID="disponibilidadCheckBox" runat="server" Checked='<%# Bind("disponibilidad") %>' Enabled="false" />
                    <br />
                    categoriamusico:
                    <asp:Label ID="categoriamusicoLabel" runat="server" Text='<%# Bind("categoriamusico") %>' />
                    <br />
                    usuario:
                    <asp:Label ID="usuarioLabel" runat="server" Text='<%# Bind("usuario") %>' />
                    <br />
                    password:
                    <asp:Label ID="passwordLabel" runat="server" Text='<%# Bind("password") %>' />
                    <br />
                    <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Modificar Datos" />
                </ItemTemplate>
            </asp:FormView>
            <asp:SqlDataSource ID="sqlDSmusico" runat="server" ConnectionString="<%$ ConnectionStrings:BandaDeMusicaConnectionString %>" DeleteCommand="DELETE FROM [Musicos] WHERE [idMusico] = @idMusico" InsertCommand="INSERT INTO [Musicos] ([nombre], [apellidos], [direccion], [ciudad], [coche], [disponibilidad], [categoriamusico], [usuario], [password]) VALUES (@nombre, @apellidos, @direccion, @ciudad, @coche, @disponibilidad, @categoriamusico, @usuario, @password)" SelectCommand="SELECT * FROM [Musicos] WHERE ([idMusico] = @idMusico)" UpdateCommand="UPDATE [Musicos] SET [nombre] = @nombre, [apellidos] = @apellidos, [direccion] = @direccion, [ciudad] = @ciudad, [coche] = @coche, [disponibilidad] = @disponibilidad, [categoriamusico] = @categoriamusico, [usuario] = @usuario, [password] = @password WHERE [idMusico] = @idMusico">
                <DeleteParameters>
                    <asp:Parameter Name="idMusico" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:Parameter Name="idMusico" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="nombre" Type="String" />
                    <asp:Parameter Name="apellidos" Type="String" />
                    <asp:Parameter Name="direccion" Type="String" />
                    <asp:Parameter Name="ciudad" Type="String" />
                    <asp:Parameter Name="coche" Type="Boolean" />
                    <asp:Parameter Name="disponibilidad" Type="Boolean" />
                    <asp:Parameter Name="categoriamusico" Type="Int32" />
                    <asp:Parameter Name="usuario" Type="String" />
                    <asp:Parameter Name="password" Type="String" />
                    <asp:Parameter Name="idMusico" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
    <br />
             
        </section>
    </div>
    </form>
</body>
</html>
