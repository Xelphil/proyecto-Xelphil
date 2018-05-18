<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="ProyectoBandadeMusica.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Login ID="oLogin" runat="server"  DisplayRememberMe="false"  RememberMeText="Recordar en este equipo"  UserNameLabelText="" PasswordLabelText="" TitleText="Usuarios registrados" >
        </asp:Login>
    </div>
    </form>
</body>
</html>
