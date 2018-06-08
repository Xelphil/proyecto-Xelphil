
Partial Class contenidos_administrador_Principal
    Inherits System.Web.UI.Page
    Private Sub contenidos_administrador_Principal_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label1.Text = Session("dUsuario").Rows(0).item(1) & " " & Session("dUsuario").Rows(0).item(2)
    End Sub
    Protected Sub btMusicos_Click(sender As Object, e As EventArgs) Handles btMusicos.Click
        Response.Redirect("~/Contenidos/administrador/Musicos.aspx")
    End Sub

    Protected Sub btInstrumentos_Click(sender As Object, e As EventArgs) Handles btInstrumentos.Click
        Response.Redirect("~/Contenidos/administrador/Instrumentos.aspx")
    End Sub

    Protected Sub btCatMus_Click(sender As Object, e As EventArgs) Handles btCatMus.Click
        Response.Redirect("~/Contenidos/administrador/CategoriaMusico.aspx")
    End Sub

    Protected Sub btCerrarSesion_Click(sender As Object, e As EventArgs) Handles btCerrarSesion.Click
        codigo.salir(Context.User.Identity.Name)
    End Sub

    Protected Sub btCatTrab_Click(sender As Object, e As EventArgs) Handles btCatTrab.Click
        Response.Redirect("~/Contenidos/administrador/CategoriaTrabajo.aspx")
    End Sub

    Protected Sub btTrabajos_Click(sender As Object, e As EventArgs) Handles btTrabajos.Click
        Response.Redirect("~/Contenidos/administrador/Trabajos.aspx")
    End Sub

    Protected Sub btGastos_Click(sender As Object, e As EventArgs) Handles btGastos.Click
        Response.Redirect("~/Contenidos/administrador/Gastos.aspx")
    End Sub

    Protected Sub btUsuarios_Click(sender As Object, e As EventArgs) Handles btUsuarios.Click
        Response.Redirect("~/Contenidos/administrador/Usuarios.aspx")
    End Sub

End Class
