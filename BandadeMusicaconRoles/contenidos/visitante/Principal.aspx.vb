
Partial Class contenidos_visitante_Principal
    Inherits System.Web.UI.Page

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("~/login.aspx")
    End Sub
End Class
