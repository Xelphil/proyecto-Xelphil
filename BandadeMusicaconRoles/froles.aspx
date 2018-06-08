<%@ Page Language="VB" AutoEventWireup="false" CodeFile="froles.aspx.vb" Inherits="_froles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

<style type ="text/css">
html, body 
{
    font-family: Arial, sans-serif;
    font-size: 13px;
    color: #404040;
    direction: ltr;
    -webkit-text-size-adjust: none;
}

.intro
{
    margin-top:20px; 
    text-align: center;
    font-family: 'Open Sans', arial;
    color: #555;
    font-size: 18px;
    font-weight: 400;
}

.aviso
{
    margin:15px auto;
    text-align:center;
}

.tarjeta-in
{
    height: 350px;
    width:350px;
    background-color: #f7f7f7;
    border-radius: 2px;
    box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
    margin: 10px auto 25px;
    text-align: center;
}

.circle-mask {
        display: block;
        height: 96px;
        width: 96px;
        overflow: hidden;
        border-radius: 50%;
        margin-left: auto;
        margin-right: auto;
        margin-bottom: 10px;
        background-size: 96px;
        background-repeat: no-repeat;
        background-image: url("imagenes/avatar_2x.png");
        transition: opacity 0.075s;
}

.circle 
{
    height: 96px;
    width: 96px;
    border-radius: 50%;
    opacity: 0.99;
    overflow: hidden;
    background-repeat: no-repeat;
    background-position: center center;
}

.textbox
{
     border-color:#b9b9b9;
     border-width:1px;
     border-style:ridge;
     width:300px;
     height :44px;
     font-size:16px;
     padding-left:10px;
}

.boton
{
    width:300px;
    height :44px;
    border: 1px solid #2f5bb7;
    color: #fff;
    text-shadow: 0 1px rgba(0,0,0,0.3);
    background-color: #357ae8;
    font-size:16px;
}

.validator
{
   color:red;
   font-size:13px;
}
</style>

<script type="text/javascript">

function maximizar()
{
        window.moveTo(0, 0);
        if (document.all) {
            top.window.resizeTo(screen.availWidth, screen.availHeight);
        }
        else if (document.layers || document.getElementById) {
            if (top.window.outerHeight < screen.availHeight || top.window.outerWidth < screen.availWidth) {
                top.window.outerHeight = screen.availHeight;
                top.window.outerWidth = screen.availWidth;
            }
        }
}

</script>
</head>
<body onload="maximizar()">
    <form id="miForm" runat="server">
        <div class="intro">
             <div class="aviso">
                  <asp:Label ID="aviso" runat="server" Text="Seleccione su rol de trabajo" />
             </div>
        </div>
        <div class="tarjeta-in">
             <div style="padding-top:25px;">
                <div class="circle-mask" >
                     <canvas id="canvas" class="circle" width="96" height="96"></canvas>
                </div>
             </div>
             <div style="margin-top:40px;">
                   <asp:DropDownList ID="DDLroles" runat="server" CssClass="textbox" />
             </div>
            
             <div style="margin-top:40px">
                 <asp:Button ID="BTempezar" runat="server" Text="Comenzar trabajo" CssClass="boton" />
             </div>

             <div style="text-align:left;padding-left:20px;margin-top:20px">
                   <asp:CheckBox ID="CKcontinuar" runat="server" Checked="True"  Text="Seguir con la misma cuenta"/>
             </div>
        </div>
    </form>
</body>
</html>
