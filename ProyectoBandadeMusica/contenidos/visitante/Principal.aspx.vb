
Partial Class contenidos_visitante_Principal
    Inherits System.Web.UI.Page

    Protected Sub btCerrarSesion_Click(sender As Object, e As EventArgs) Handles btCerrarSesion.Click
        Response.Redirect("~/login.aspx")
    End Sub
End Class
