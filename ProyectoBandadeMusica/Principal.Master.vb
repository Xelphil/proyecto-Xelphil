Public Class Principal
    Inherits System.Web.UI.MasterPage
    Protected Sub btMusicos_Click(sender As Object, e As EventArgs) Handles btMusicos.Click
        Response.Redirect("~/Contenidos/Musicos.aspx")
    End Sub

    Protected Sub btInstrumentos_Click(sender As Object, e As EventArgs) Handles btInstrumentos.Click
        Response.Redirect("~/Contenidos/Instrumentos.aspx")
    End Sub

    Protected Sub btCatMus_Click(sender As Object, e As EventArgs) Handles btCatMus.Click
        Response.Redirect("~/Contenidos/CategoriaMusico.aspx")
    End Sub

    Protected Sub btCerrarSesion_Click(sender As Object, e As EventArgs) Handles btCerrarSesion.Click
        Session("usuario") = Nothing
        Response.Redirect("~/Inicio.aspx")
    End Sub

    Protected Sub btCatTrab_Click(sender As Object, e As EventArgs) Handles btCatTrab.Click

    End Sub

    Protected Sub btTrabajos_Click(sender As Object, e As EventArgs) Handles btTrabajos.Click

    End Sub

    Protected Sub btGastos_Click(sender As Object, e As EventArgs) Handles btGastos.Click

    End Sub

    Protected Sub btUsuarios_Click(sender As Object, e As EventArgs) Handles btUsuarios.Click

    End Sub
End Class