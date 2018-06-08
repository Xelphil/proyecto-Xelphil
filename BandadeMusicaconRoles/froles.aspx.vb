Imports System.Data

Partial Class _froles
    Inherits System.Web.UI.Page

    Dim us As Int32

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        us = Context.User.Identity.Name
        If Roles.GetRolesForUser(us).Count = 0 Then
            If Not IsPostBack Then
                For Each fila As DataRow In Session("dUsuario").Rows
                    DDLroles.Items.Add(New ListItem With {.Text = fila("Rol"), .Value = fila("idRol")})
                Next
            End If
        Else
            ' Si tiene roles dados de alta en aspdbnet se redirecciona a su zona. Solo debería tener un rol en cada momento.
            Response.Redirect(codigo.Redireccion(Roles.GetRolesForUser(us)(0)))
        End If
    End Sub

    Protected Sub BTempezar_Click(sender As Object, e As EventArgs) Handles BTempezar.Click
        us = Context.User.Identity.Name
        If CKcontinuar.Checked Then
            If us <> Nothing Then
                ' Añadimos el usuario al rol elegido (aspdbnet)
                codigo.usuarioINrol(us, DDLroles.SelectedValue)
                ' Redireccionamos a su zona.
                Response.Redirect(codigo.Redireccion(DDLroles.SelectedValue).ToString)
            Else
                Response.Redirect(codigo.Redireccion(Roles.GetRolesForUser(us)(0)))
            End If
        Else
            Session("cookiePermanente") = False
            codigo.salir(us)
        End If
    End Sub

End Class
