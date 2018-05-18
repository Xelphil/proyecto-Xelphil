Public Class Login
    Inherits System.Web.UI.Page

    Private Sub login_Init(sender As Object, e As EventArgs) Handles Me.Init
        CType(oLogin.FindControl("Username"), TextBox).Attributes.Add("placeholder", "Usuario")
        CType(oLogin.FindControl("Password"), TextBox).Attributes.Add("placeholder", "Contraseña")

        If Request.IsAuthenticated Then ' El usuario se encuentra autenticado, ya que se creó una cookie persistente con el tique de validación. Se redirecciona directamente a principal.aspx.
            Response.Redirect("contenidos/Musicos.aspx")
        End If
    End Sub

    Protected Sub oLogin_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles oLogin.Authenticate
        If codigo.searchUsuario(oLogin.UserName, oLogin.Password) Then
            ' Emite un vale de autenticación para el usuario que es guardado en la cookie predeterminada (persistente o no).
            ' A su vez, redirige al usuario autenticado hacia la dirección URL originalmente solicitada.
            FormsAuthentication.RedirectFromLoginPage(oLogin.UserName, oLogin.RememberMeSet) ' La persistencia de la cookie depende de la opción marcada en el checkbox "Recuérdame".
            ' La cookie, si es persistente, tiene el tiempo de expiración establecido en la propiedad Timeout del Web.config
            ' sino, expira cuando finalice la sesion del explorador.
            Response.Redirect("contenidos/Musicos.aspx")
        End If
    End Sub

End Class