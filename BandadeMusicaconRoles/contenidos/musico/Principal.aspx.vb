
Partial Class contenidos_administrador_Principal
    Inherits System.Web.UI.Page
    Private Sub contenidos_administrador_Principal_Load(sender As Object, e As EventArgs) Handles Me.Load
        'MsgBox(Session("dUsuario").Rows(0).item(0))
        Label1.Text = Session("dUsuario").Rows(0).item(1) & " " & Session("dUsuario").Rows(0).item(2)
    End Sub
    Protected Sub btMusicos_Click(sender As Object, e As EventArgs) Handles btMusicos.Click
        Response.Redirect("~/Contenidos/musico/Musicos.aspx")
    End Sub

    Protected Sub btCerrarSesion_Click(sender As Object, e As EventArgs) Handles btCerrarSesion.Click
        codigo.salir(Context.User.Identity.Name)
    End Sub

    Protected Sub btTrabajos_Click(sender As Object, e As EventArgs) Handles btTrabajos.Click
        Response.Redirect("~/Contenidos/musico/Trabajos.aspx")
    End Sub

    Protected Sub btGastos_Click(sender As Object, e As EventArgs) Handles btGastos.Click
        Response.Redirect("~/Contenidos/musico/Gastos.aspx")
    End Sub

End Class
