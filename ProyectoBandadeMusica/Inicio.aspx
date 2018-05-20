<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Inicio.aspx.vb" Inherits="ProyectoBandadeMusica.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="login">
        <asp:Login ID="oLogin" runat="server" DisplayRememberMe="false" TitleText="INICIO DE SESIÓN" UserNameLabelText="" PasswordLabelText="" LoginButtonText="ACCEDER" FailureText="El usuario no existe.">
        </asp:Login>
        <br />
        <asp:Button ID="btVisitante" runat="server" Text="Acceder como Visitante" />
    </div>
    </form>
</body>
</html>
