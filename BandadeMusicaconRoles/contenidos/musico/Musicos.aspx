<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Musicos.aspx.vb" Inherits="contenidos_musico_Musicos" %>

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
        #fvMusico{
            margin:auto;
            font-size: x-large;
        }

        #fvMusico tbody{
            font-size: 0.9em;
            text-align: center;
        }

        #fvMusico tbody td{
            padding: 0.25em;
            background-color:#e8e8e8;
            text-align:center;
        }

        #fvMusico tbody span{
            font-weight:bold;
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
            text-align:center;
            align-items:center;
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
            <h1>Músicos</h1>
            <br />
            <asp:FormView ID="fvMusico" runat="server" DataKeyNames="idMusico" DataSourceID="sqlDSmusico">
                <EditItemTemplate>
                    IdMusico:
                    <asp:Label ID="idMusicoLabel1" runat="server" Text='<%# Eval("idMusico") %>' />
                    <br />
                    Nombre:
                    <asp:TextBox ID="nombreTextBox" runat="server" Text='<%# Bind("nombre") %>' />
                    <br />
                    Apellidos:
                    <asp:TextBox ID="apellidosTextBox" runat="server" Text='<%# Bind("apellidos") %>' />
                    <br />
                    Direccion:
                    <asp:TextBox ID="direccionTextBox" runat="server" Text='<%# Bind("direccion") %>' />
                    <br />
                    Ciudad:
                    <asp:TextBox ID="ciudadTextBox" runat="server" Text='<%# Bind("ciudad") %>' />
                    <br />
                    Coche:
                    <asp:CheckBox ID="cocheCheckBox" runat="server" Checked='<%# Bind("coche") %>' />
                    <br />
                    Disponibilidad:
                    <asp:CheckBox ID="disponibilidadCheckBox" runat="server" Checked='<%# Bind("disponibilidad") %>' />
                    <br />
                    Categoria del músico:
                    <asp:TextBox ID="categoriamusicoTextBox" runat="server" Text='<%# Bind("categoriamusico") %>' />
                    <br />
                    Usuario:
                    <asp:TextBox ID="usuarioTextBox" runat="server" Text='<%# Bind("usuario") %>' />
                    <br />
                    Contraseña:
                    <asp:TextBox ID="passwordTextBox" runat="server" Text='<%# Bind("password") %>' />
                    <br />
                    <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar" />
                    &nbsp;<asp:Button ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                </EditItemTemplate>
                <ItemTemplate>
                    IdMusico:
                    <asp:Label ID="idMusicoLabel" runat="server" Text='<%# Eval("idMusico") %>' />
                    <br />
                    Nombre:
                    <asp:Label ID="nombreLabel" runat="server" Text='<%# Bind("nombre") %>' />
                    <br />
                    Apellidos:
                    <asp:Label ID="apellidosLabel" runat="server" Text='<%# Bind("apellidos") %>' />
                    <br />
                    Direccion:
                    <asp:Label ID="direccionLabel" runat="server" Text='<%# Bind("direccion") %>' />
                    <br />
                    Ciudad:
                    <asp:Label ID="ciudadLabel" runat="server" Text='<%# Bind("ciudad") %>' />
                    <br />
                    Coche:
                    <asp:CheckBox ID="cocheCheckBox" runat="server" Checked='<%# Bind("coche") %>' Enabled="false" />
                    <br />
                    Disponibilidad:
                    <asp:CheckBox ID="disponibilidadCheckBox" runat="server" Checked='<%# Bind("disponibilidad") %>' Enabled="false" />
                    <br />
                    Categoriamusico:
                    <asp:Label ID="categoriamusicoLabel" runat="server" Text='<%# Bind("categoriamusico") %>' />
                    <br />
                    Usuario:
                    <asp:Label ID="usuarioLabel" runat="server" Text='<%# Bind("usuario") %>' />
                    <br />
                    Contraseña:
                    <asp:Label ID="passwordLabel" runat="server" Text='<%# Bind("password") %>' />
                    <br />
                    <asp:Button ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Modificar Datos" />
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
